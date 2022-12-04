/*
 * BRIEFING
	This program encodes videos of any extension supported by ffmpeg to HEVC in mp4.
	It uses settings defined in a settings.json file, which is created if it doesn't exist.
	The settings.json file is used to define the source and destination folders, the CQP value, and other settings.
	The program will encode all videos in the source folder, unless they are set to be ignored in the settings.json file.
	If the videos are encoded successfully, the source video will be deleted. The encoded video is then copied and moved to the destination folder.
	A log file will also be created in a folder called "_logs" in the program's folder.
	The log file will contain the output of the ffmpeg command, as well as the settings used to encode each video.
	It will also contain the time it took to encode each video, the size of the video before and after encoding, and the date and time the video was encoded.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WMPLib;

namespace custom_ffmpeg_compressor
{
	internal class hevc_ffmpeg
	{
		static string currentDirectory = Directory.GetCurrentDirectory();

		static CompressorSettings settings = new CompressorSettings();
		static string[] files = { };

		static string logFileForFile = "";

		static string[] processAndCurrentFileLogs = { };

		static bool shouldEncode = true;

		static void Main(string[] args)
		{
			// [PREPARATION] //

			LogManager.Init();

			LogManager.WriteToProcessLog("Preparing module...", true);
			

			// ---[READ SETTINGS]--- //
			settings = RetrieveSettings();

			files = Directory.GetFiles(settings.sourceFolder);

			// Create the ffmpeg command
			string command = "ffmpeg -hwaccel_output_format cuda -i \"{0}\" -map 0:v -map 0:a -map_metadata 0 -c:v hevc_nvenc -rc constqp -qp " + settings.cqp + " -b:v 0K -c:a copy -movflags +faststart -movflags use_metadata_tags -y \"{1}\"";

			LogManager.WriteToProcessLog("Using ffmpeg command: " + command, true);
			
			
			
			// ---[ENCODE FILES]--- //
			foreach (string file in files)
			{
				if (!shouldEncode)
				{
					break;
				}

				string fileName = Path.GetFileName(file);

				// Create a log file for the file in the _logs folder
				logFileForFile = LogManager.CreateLogFile(Array.IndexOf(files, file).ToString());

				processAndCurrentFileLogs = new string[] { LogManager.processLogPath, logFileForFile };

				LogManager.WriteEmptyToLog(LogManager.processLogPath, 1);
				LogManager.WriteToLogs(processAndCurrentFileLogs, string.Format("-----[{0}]-----", fileName), false);
				LogManager.WriteToProcessLog(string.Format("Loaded file {0}", fileName), true);



				// Check if the file is in the list of ignored files
				if (!settings.ignoredFiles.Contains(fileName))
				{
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);


					// Get the file size before encoding
					long fileSize = new FileInfo(file).Length;
					double fileSizeMB = fileSize / 1000000.0;

					// Write the file size to the log files
					LogManager.WriteToLogs(processAndCurrentFileLogs, string.Format("File size: {0} MB", fileSizeMB), true);


					// ---[COMPRESS FILE]--- //
					string encodedFileName = CompressFile(file, command);

					// ---[COMPARE FILES]--- //
					CompareFiles(file, encodedFileName);

					// Log that the file was processed
					LogManager.WriteEmptyToLogs(processAndCurrentFileLogs, 1);
					LogManager.WriteToLogs(processAndCurrentFileLogs, "\tFile has finished processing", true);
					LogManager.WriteEmptyToLogs(processAndCurrentFileLogs, 1);

				}
				else
				{
					// Write that the file is in the list of ignored files to the log file
					LogManager.WriteEmptyToLog(LogManager.processLogPath, 1);
					LogManager.WriteToProcessLog(string.Format("File {0} is in ignored files list. Skipping...", fileName), true);
					LogManager.WriteEmptyToLog(LogManager.processLogPath, 1);
				}
			}

			// [FINISH PROCESSING] //
			LogManager.WriteEmptyToLog(LogManager.processLogPath, 1);
			LogManager.WriteToProcessLog("All files have finished processing.", true);
			LogManager.WriteEmptyToLog(LogManager.processLogPath, 1);

			Console.WriteLine("Program has finished");
		}


		// [FUNCTIONS] //






		///<summary>
		///Compares the original and encoded file, and modifies them accordingly.
		///</summary>
		static void CompareFiles(string original, string encoded)
		{
			// [LENGTH COMPARISON] //

			// Get original file length
			WindowsMediaPlayer wmp = new WindowsMediaPlayerClass();
			IWMPMedia mediainfo = wmp.newMedia(original);
			var originalDuration = mediainfo.duration;

			// Get encoded file length
			mediainfo = wmp.newMedia(encoded);
			var encodedDuration = mediainfo.duration;
			wmp.close();

			// Compare the lengths
			double lenDifference = Math.Abs(originalDuration - encodedDuration);
			if (lenDifference != 0)
			{
				LogManager.WriteToLogs(processAndCurrentFileLogs, "\tLength difference: " + lenDifference + " seconds", false);
				LogManager.WriteToLogs(processAndCurrentFileLogs, "\tFailed to complete encoding. Dropping all other files.", true);
				shouldEncode = false;
				return;
			}

			// [SIZE COMPARISON] //

			// Get original file size
			long originalFileSize = new FileInfo(original).Length;
			double originalFileSizeMB = originalFileSize / 1000000.0;

			// Get encoded file size
			long encodedFileSize = new FileInfo(encoded).Length;
			double encodedFileSizeMB = encodedFileSize / 1000000.0;

			// Write the file sizes to the log files
			LogManager.WriteToLogs(processAndCurrentFileLogs, "\tOriginal file size: " + originalFileSizeMB + " MB", false);
			LogManager.WriteToLogs(processAndCurrentFileLogs, "\tEncoded file size: " + encodedFileSizeMB + " MB", false);

			// Calculate the difference in file size
			double sizeDifference = originalFileSizeMB - encodedFileSizeMB;
			LogManager.WriteToLogs(processAndCurrentFileLogs, "\tSize difference: " + sizeDifference + " MB", false);

			// Calculate the percentage of the original file size that the encoded file is
			double percentage = (encodedFileSizeMB / originalFileSizeMB) * 100;
			LogManager.WriteToLogs(processAndCurrentFileLogs, "\tPercentage of original file size: " + percentage + "%", false);



			// Compare the file sizes
			if (encodedFileSize < originalFileSize)
			{
				// [ENCODED FILE IS SMALLER] //
				LogManager.WriteToLogs(processAndCurrentFileLogs, "\tEncoded file is smaller than the original file", false);

				// Delete the original file
				if ((bool)settings.deleteSource)
				{
					File.Delete(original);
					LogManager.WriteToLogs(processAndCurrentFileLogs, "\tDeleted original file", true);
				}

				string encodedFileCopyName = Path.GetFileNameWithoutExtension(encoded) + "_TEMP" + Path.GetExtension(encoded);

				// Copy the encoded file to the same folder, with the suffix "TEMP"
				File.Copy(encoded, encodedFileCopyName);

				// Move the copy of the encoded file to the destination folder
				File.Move(encodedFileCopyName, settings.destinationFolder + "\\" + Path.GetFileNameWithoutExtension(original) + ".mp4");
				
				// Check that the move was successfull
				if (File.Exists(settings.destinationFolder + "\\" + Path.GetFileNameWithoutExtension(original) + ".mp4") == true)
				{
					LogManager.WriteToLogs(processAndCurrentFileLogs, "\tMoved encoded file to destination folder", true);
					File.Delete(encoded);
					LogManager.WriteToLogs(processAndCurrentFileLogs, "\tDeleted original encoded file from source folder", true);
				}
				else
				{
					LogManager.WriteToLogs(processAndCurrentFileLogs, "\tFailed to move encoded file to destination folder. Assuming destination drive is full.", true);
					settings.deleteSource = false;
				}
			}
			else
			{
				// [ENCODED FILE IS LARGER] //
				LogManager.WriteToLogs(processAndCurrentFileLogs, "\tEncoded file is larger than the original file", false);

				// Delete the encoded file
				File.Delete(encoded);
				LogManager.WriteToLogs(processAndCurrentFileLogs, "\tDeleted encoded file", true);
			}

			// [FINISH COMPARISON] //
			LogManager.WriteToLogs(processAndCurrentFileLogs, "Successfully compared files", true);
		}




		///<summary>
		///Runs the given ffmpeg command on the given file.
		///</summary>
		static string CompressFile(string fileName, string command)
		{
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);

			// Create a new process
			string encodedFileName = string.Format("{0}\\{1}{2}.mp4", settings.sourceFolder, fileNameWithoutExtension, settings.suffix);
			string processCommand = string.Format(command, fileName, encodedFileName);

			Process process = new Process();
			int exitCode = 0;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.CreateNoWindow = !settings.showProcessWindow;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.Arguments = "/C " + processCommand;

			LogManager.WriteToProcessLog("Started compression of file [" + fileName + "]", true);
			process.Start();


			LogManager.WriteToLogs(processAndCurrentFileLogs, "--- PROCESS OUTPUT ---", true);
			// Log the output stream while the process is running
			while (!process.StandardOutput.EndOfStream)
			{
				string line = process.StandardOutput.ReadLine();
				LogManager.WriteToLogs(processAndCurrentFileLogs, line, true);
			}

			process.WaitForExit();

			LogManager.WriteToLogs(processAndCurrentFileLogs, "", false);
			LogManager.WriteToLogs(processAndCurrentFileLogs, "--- PROCESS OUTPUT ---", true);

			exitCode = process.ExitCode;
			string stdout = process.StandardOutput.ReadToEnd();
			string stderr = process.StandardError.ReadToEnd();

			process.Close();
			LogManager.WriteToProcessLog(string.Format("Finished compression of file [{0}] with exit code {1}", fileName, exitCode), true);

			return encodedFileName;

		}









		static CompressorSettings RetrieveSettings()
		{
			// Get the settings from the settings.settings file
			CompressorSettings settings = new CompressorSettings();

			LogManager.WriteToProcessLog("Successfully retrieved settings", true);
			settings.logSettings();
			
			return settings;
		}
	}
}
