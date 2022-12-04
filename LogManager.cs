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
        private static string _ver = "rev3";

        public static string logFolderPath { get; private set; } = string.Empty;
        public static string processLogPath { get; private set; }
        public static LogFile processLog { get; private set; }
        private static string globalTimestampFormat;
        private static bool initialised = false;

        private static string _sessionid = Math.Round(TimeSpan.FromTicks(DateTime.Now.Ticks).TotalSeconds).ToString();


        ///<summary>
        ///Initialises the LogManager.
        ///</summary>
        public static void Init([CallerFilePath] string callerModulePath = "")
        {
            if (initialised) processLog.Log("Attempted to initialise when LogManager was already initialised");
            else
            {
                initialised = true;
                // Get the timestamp format, the log folder path and create a process log
                globalTimestampFormat = Properties.Settings.Default.timestampFormat;
                logFolderPath = Directory.GetCurrentDirectory() + "\\logs\\S-ID_" + _sessionid;
                if (!Directory.Exists(logFolderPath)) Directory.CreateDirectory(logFolderPath);

                string processLogName = Path.GetFileNameWithoutExtension(callerModulePath) + "_MAIN_PROCESS";
                processLog = new LogFile(processLogName, DateTime.MaxValue, true, globalTimestampFormat);
                
                processLog.Log(string.Format("LogManager {0} initialised", _ver));
            }
        }


        public static void LogMultiple(string message, LogFile[] logFiles, bool timestamp = true, LogLevelEnum level = LogLevelEnum.Info, [CallerMemberName] string caller = null)
        {
            if (!initialised) Console.WriteLine("LogManager not initialised");
            else
            {
                foreach (LogFile logFile in logFiles)
                {
                    logFile.Log(message, timestamp, level, caller);
                }
            }
        }

        public static void LogWithProcessLog(string message, LogFile logFile, bool timestamp = true, LogLevelEnum level = LogLevelEnum.Info, [CallerMemberName] string caller = null)
        {
            if (!initialised) Console.WriteLine("LogManager not initialised");
            else
            {
                logFile.Log(message, timestamp, level, caller);
                processLog.Log(message, timestamp, level, caller);
            }
        }




        internal enum LogLevelEnum
        {
            Debug,
            Info,
            Warning,
            Error,
            Fatal
        }

        internal class LogFile
        {
            public string logName { get; private set; }
            public string logPath { get; private set; }
            public int indent { get; private set; } = 0;
            public bool logToConsole { get; private set; } = false;
            public string timestampFormat { get; private set; }

            public DateTime expiry { get; private set; }


            public LogFile(string name, DateTime expiry, bool logToConsole = false, string timestampFormat = "dd-MM-yyyy HH:mm:ss.fff")
            {
                if (!initialised) Console.WriteLine("LogManager not initialised");
                else //if (File.Exists(logPath)) LogManager.processLog.Log("Attempted to create a log file that already exists.");
                {
                    this.logName = Path.GetFileNameWithoutExtension(name);
                    //this.logPath = string.Format("{0}\\{1}_{2}.log", logFolderPath, name, DateTime.Now.ToString(timestampFormat).Replace(":","-"));
                    this.logPath = string.Format("{0}\\{1}.log", logFolderPath, name);
                    this.expiry = expiry;
                    this.logToConsole = logToConsole;
                    this.timestampFormat = timestampFormat;
                    Log(string.Format("LogFile {0} created", logName));
                }
            }



            public void Log(string message, bool timestamp = true, LogLevelEnum level = LogLevelEnum.Info, [CallerMemberName] string caller = null)
            {
                string logMessage = string.Empty;

                // Add indentation
                for (int i = 0; i < this.indent; i++) logMessage += "\t";
                
                // Add timestamp
                _ = timestamp ? logMessage = DateTime.Now.ToString(this.timestampFormat) : logMessage = "";


                // Format message
                logMessage = string.Format("[{0}] [{1}]  {2}: {3}", logMessage, level.ToString().ToUpper(), caller, message);

                if (this.logToConsole) Console.WriteLine(logMessage);

                File.AppendAllText(this.logPath, logMessage + Environment.NewLine);
            }


            public void Clear()
            {
                File.WriteAllText(logPath, "");
            }


            public void Indent() { indent++; }
            public void Unindent() { indent--; }
            public void LogBreak(int count = 1)
            {
                for (int i = 0; i < count; i++) File.AppendAllText(logPath, Environment.NewLine);
            }

        }

        /*
        public static void WriteToProcessLog(string message, bool timestamp = true, LogLevelEnum level = LogLevelEnum.Info, [CallerMemberName] string caller = null)
        {
            if (!initialised) Console.WriteLine("Attempted to write to process log when LogManager was not initialised");
            else processLog.Log(message, timestamp, level, caller);
        }

        public static void WriteEmptyToProcessLog(int count = 1)
        {
            if (!initialised) Console.WriteLine("Attempted to write to process log when LogManager was not initialised");
            else processLog.LogBreak(count);
        }

        public static void IndentProcessLog()
        {
            if (!initialised) Console.WriteLine("Attempted to indent process log when LogManager was not initialised");
            else processLog.Indent();
        }

        public static void UnindentProcessLog()
        {
            if (!initialised) Console.WriteLine("Attempted to unindent process log when LogManager was not initialised");
            else processLog.Unindent();
        }
        */
    }
}