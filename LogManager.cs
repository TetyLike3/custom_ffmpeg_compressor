using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Configuration;

namespace custom_ffmpeg_compressor
{
    internal class LogManager
    {
        private static string _ver = "rev1";

        private static string logFolderPath = string.Empty;
        public static string processLogPath { get; private set; }
        private static string timestampFormat;
        private static bool initialised = false;


        ///<summary>
        ///Initialises the LogManager.
        ///</summary>
        public static void Init([CallerFilePath] string callerModulePath = "")
        {
            if (initialised) WriteToProcessLog("Attempted to initialise when LogManager was already initialised", true);
            
            // Get the timestamp format, the log folder path and create a process log
            timestampFormat = Properties.Settings.Default.timestampFormat;
            if (logFolderPath == string.Empty) logFolderPath = Directory.GetCurrentDirectory() + "\\logs";
            if (!Directory.Exists(logFolderPath))
            {
                Directory.CreateDirectory(logFolderPath);
            }

            processLogPath = CreateLogFile(Path.GetFileNameWithoutExtension(callerModulePath) + "_MAIN_PROCESS");

            initialised = true;
            WriteToProcessLog(string.Format("LogManager {0} initialised", _ver), true);
        }


        ///<summary>
        ///Sets the folder for all logs to be stored in.
        ///</summary>
        public static void SetLogFolder(string folder)
        {
            if (initialised) WriteToProcessLog("Attempted to set log folder when LogManager was initialised", true);
            logFolderPath = folder;
        }


        ///<summary>
        ///Creates a new log file with the given name.
        ///</summary>
        public static string CreateLogFile(string logName)
        {
            string logFileName = logFolderPath + "\\log_" + logName + "_" + DateTime.Now.ToString(timestampFormat).Replace(":", "-").Replace("\\", "-") + ".txt";
            return logFileName;
        }



        ///<summary>
        ///Writes to the process log.
        ///</summary>
        public static void WriteToProcessLog(string message, bool timestamp)
        {
            message += Environment.NewLine;
            _ = timestamp == true? message = string.Format("[{0}] - {1}", DateTime.Now.ToString(timestampFormat), message) : message;
            
            File.AppendAllText(processLogPath, message);
        }


        ///<summary>
        ///Writes to a given log file.
        ///</summary>
        public static void WriteToLog(string logFile, string message, bool timestamp)
        {
            message += Environment.NewLine;
            _ = timestamp == true ? message = string.Format("[{0}] - {1}", DateTime.Now.ToString(timestampFormat), message) : message;

            File.AppendAllText(logFile, message + Environment.NewLine);
        }



        ///<summary>
        ///Writes to multiple logs.
        ///</summary>
        public static void WriteToLogs(string[] logFiles, string message, bool timestamp)
        {
            message += Environment.NewLine;
            _ = timestamp == true ? message = string.Format("[{0}] - {1}", DateTime.Now.ToString(timestampFormat), message) : message;

            foreach (string logFile in logFiles)
            {
                File.AppendAllText(logFile, message);
            }
        }





        ///<summary>
        ///Writes a given number of empty lines to a given log file.
        ///</summary>
        public static void WriteEmptyToLog(string logFile, int count)
        {
            for (int i = 0; i < count; i++)
            {
                File.AppendAllText(logFile, Environment.NewLine);
            }
        }



        ///<summary>
        ///Writes a given number of empty lines to multiple logs.
        ///</summary>
        public static void WriteEmptyToLogs(string[] logFiles, int count)
        {
            foreach (string logFile in logFiles)
            {
                for (int i = 0; i < count; i++)
                {
                    File.AppendAllText(logFile, Environment.NewLine);
                }
            }
        }
    }
}