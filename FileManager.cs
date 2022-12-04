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
        private static string _ver = "rev2";

        private static bool initialised = false;

        static CompressorSettings settings = new CompressorSettings();



        /// <summary>
        /// Initialises the FileManager.
        /// </summary>
        public static void Init()
        {
            if (initialised) LogManager.processLog.Log("Attempted to intialise FileManager when already initialised", true, LogManager.LogLevelEnum.Warning);

            initialised = true;
            LogManager.processLog.Log(string.Format("FileManager {0} initialised", _ver));
        }



        

        /// <summary>
        /// Copies a file from one location to another.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="destinationPath"></param>
        /// <param name="overwrite"></param>
        public static bool CopyFile(string filePath, string destinationPath, bool overwrite)
        {
            if (!initialised) LogManager.processLog.Log("Attempted to copy file when FileManager was not initialised", true, LogManager.LogLevelEnum.Warning);

            if (File.Exists(destinationPath) && !overwrite)
            {
                LogManager.processLog.Log(string.Format("File {0} already exists at {1} and overwrite is set to false", filePath, destinationPath), true, LogManager.LogLevelEnum.Warning);
                return false;
            }
            
            try
            {
                File.Copy(filePath, destinationPath, overwrite);
                LogManager.processLog.Log(string.Format("Copied file {0} to {1}", filePath, destinationPath));
                return true;
            }
            catch (Exception e)
            {
                LogManager.processLog.Log(string.Format("Failed to copy file [{0}] to [{1}]", filePath, destinationPath), true, LogManager.LogLevelEnum.Error);
                LogManager.processLog.Log(string.Format("Exception: [{0}]", e.Message), true, LogManager.LogLevelEnum.Error);
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
            if (!initialised) LogManager.processLog.Log("Attempted to move file when FileManager was not initialised", true, LogManager.LogLevelEnum.Warning);

            if (File.Exists(destinationPath) && !overwrite)
            {
                LogManager.processLog.Log(string.Format("File {0} already exists at {1} and overwrite is set to false", filePath, destinationPath), true, LogManager.LogLevelEnum.Warning);
                return false;
            }

            try
            {
                File.Move(filePath, destinationPath);
                LogManager.processLog.Log(string.Format("Moved file {0} to {1}", filePath, destinationPath));
                return true;
            }
            catch (Exception e)
            {
                LogManager.processLog.Log(string.Format("Failed to move file [{0}] to [{1}]", filePath, destinationPath), true, LogManager.LogLevelEnum.Error);
                LogManager.processLog.Log(string.Format("Exception: [{0}]", e.Message), true, LogManager.LogLevelEnum.Error);
                return false;
            }
        }



        public static bool DeleteFile(string filePath, bool permanent)
        {
            if (!initialised) LogManager.processLog.Log("Attempted to delete file when FileManager was not initialised", true, LogManager.LogLevelEnum.Warning);

            if (!File.Exists(filePath))
            {
                LogManager.processLog.Log(string.Format("File [{0}] does not exist.", filePath), true, LogManager.LogLevelEnum.Warning);
                return false;
            }

            try
            {
                FileSystem.DeleteFile(filePath, UIOption.OnlyErrorDialogs, permanent ? RecycleOption.DeletePermanently : RecycleOption.SendToRecycleBin);
                LogManager.processLog.Log(string.Format("Deleted file [{0}]", filePath));
                return true;
            }
            catch (Exception e)
            {
                LogManager.processLog.Log(string.Format("Failed to delete file [{0}]", filePath), true, LogManager.LogLevelEnum.Error);
                LogManager.processLog.Log(string.Format("Exception: [{0}]", e.Message), true, LogManager.LogLevelEnum.Error);
                return false;
            }
        }
    }
}
