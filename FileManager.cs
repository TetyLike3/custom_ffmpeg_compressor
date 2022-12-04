using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custom_ffmpeg_compressor
{
    internal class FileManager
    {
        private static string _ver = "rev1";

        private static bool initialised = false;

        static CompressorSettings settings = new CompressorSettings();



        /// <summary>
        /// Initialises the FileManager.
        /// </summary>
        public static void Init()
        {
            if (initialised) LogManager.WriteToProcessLog("Attempted to initialise when FileManager was already initialised", true);

            initialised = true;
            LogManager.WriteToProcessLog(string.Format("FileManager {0} initialised", _ver), true);
        }



        

        /// <summary>
        /// Copies a file from one location to another.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="destinationPath"></param>
        /// <param name="overwrite"></param>
        public static bool CopyFile(string filePath, string destinationPath, bool overwrite)
        {
            if (!initialised) LogManager.WriteToProcessLog("Attempted to copy file when FileManager was not initialised", true);

            if (File.Exists(destinationPath) && !overwrite)
            {
                LogManager.WriteToProcessLog(string.Format("File {0} already exists and overwrite is set to false", destinationPath), true);
                return false;
            }

            try
            {
                File.Copy(filePath, destinationPath, overwrite);
                LogManager.WriteToProcessLog(string.Format("Copied file {0} to {1}", filePath, destinationPath), true);
                return true;
            }
            catch (Exception e)
            {
                LogManager.WriteToProcessLog(string.Format("Failed to copy file {0} to {1}", filePath, destinationPath), true);
                LogManager.WriteToProcessLog(string.Format("Exception: {0}", e.Message), true);
                return false;
            }
        }



        /// <summary>
        /// Moves a file from one location to another.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="destinationPath"></param>
        /// <param name="overwrite"></param>
        public static bool MoveFile(string filePath, string destinationPath, bool overwrite)
        {
            if (!initialised) LogManager.WriteToProcessLog("Attempted to move file when FileManager was not initialised", true);

            if (File.Exists(destinationPath) && !overwrite)
            {
                LogManager.WriteToProcessLog(string.Format("File {0} already exists and overwrite is set to false", destinationPath), true);
                return false;
            }

            try
            {
                File.Move(filePath, destinationPath);
                LogManager.WriteToProcessLog(string.Format("Moved file {0} to {1}", filePath, destinationPath), true);
                return true;
            }
            catch (Exception e)
            {
                LogManager.WriteToProcessLog(string.Format("Failed to move file {0} to {1}", filePath, destinationPath), true);
                LogManager.WriteToProcessLog(string.Format("Exception: {0}", e.Message), true);
                return false;
            }
        }



        public static bool DeleteFile(string filePath, bool permanent)
        {
            if (!initialised) LogManager.WriteToProcessLog("Attempted to delete file when FileManager was not initialised", true);

            if (!File.Exists(filePath))
            {
                LogManager.WriteToProcessLog(string.Format("File {0} does not exist", filePath), true);
                return false;
            }

            try
            {
                FileSystem.DeleteFile(filePath, UIOption.OnlyErrorDialogs, permanent ? RecycleOption.DeletePermanently : RecycleOption.SendToRecycleBin);
                LogManager.WriteToProcessLog(string.Format("Deleted file {0}", filePath), true);
                return true;
            }
            catch (Exception e)
            {
                LogManager.WriteToProcessLog(string.Format("Failed to delete file {0}", filePath), true);
                LogManager.WriteToProcessLog(string.Format("Exception: {0}", e.Message), true);
                return false;
            }
        }
    }
}
