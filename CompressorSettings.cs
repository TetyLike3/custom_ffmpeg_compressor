using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;



namespace custom_ffmpeg_compressor
{
    internal class CompressorSettings
    {
        public string sourceFolder { get; set; } = "/";
        public string destinationFolder { get; set; } = "/";
        public int cqp { get; set; } = 24;
        public bool deleteSource { get; set; } = true;
        public bool deleteCopy { get; set; } = true;
        public string suffix { get; set; } = "_COMPRESSED";
        public List<string> ignoredFiles { get; set; } = new List<string>();
        public bool showProcessWindow { get; set; } = true;
        public bool deletePermanently { get; set; } = false;




        public CompressorSettings()
        {
            // Load settings from .config file using Properties
            sourceFolder = Properties.Settings.Default.sourceFolderPath;
            destinationFolder = Properties.Settings.Default.destinationFolderPath;
            cqp = Properties.Settings.Default.cqp;
            deleteSource = Properties.Settings.Default.deleteOnEncodeSuccess;
            deleteCopy = Properties.Settings.Default.deleteOnCopySuccess;
            suffix = Properties.Settings.Default.outputSuffix;
            showProcessWindow = Properties.Settings.Default.showProcessWindow;
            deletePermanently = Properties.Settings.Default.deletePermanently;
            // Load ignored files if any
            if (Properties.Settings.Default.ignoredFiles != null)
            {
                ignoredFiles = Properties.Settings.Default.ignoredFiles.Cast<string>().ToList();
            }
            else
            {
                ignoredFiles = new List<string>() { "" };
            }
        }


        ///<summary>
        ///Logs all current settings to the process logd
        ///</summary>
        public void logSettings()
        {
            LogManager.WriteEmptyToLog(LogManager.processLogPath,1);
            LogManager.WriteToProcessLog("-----[SETTINGS]-----", false);
            foreach (var property in typeof(CompressorSettings).GetProperties())
            {
                LogManager.WriteToProcessLog(string.Format("\t{0}: {1}", property.Name, property.GetValue(this)), false);
            }
            LogManager.WriteToProcessLog("-----[SETTINGS]-----", false);
            LogManager.WriteEmptyToLog(LogManager.processLogPath, 1);
        }
    }
}
