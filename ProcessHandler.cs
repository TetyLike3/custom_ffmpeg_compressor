using custom_ffmpeg_compressor.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace custom_ffmpeg_compressor
{
    
    internal class ProcessHandler
    {
        
    }


    internal enum ProcessStatesEnum
    {
        Idle,
        Running,
        Paused,
        Stopped
    }

    internal class ProcessClass
    {
        public Process process { get; set; }
        public string ProcessName { get; set; }
        public string ProcessArguments { get; set; }
        public string ProcessOutput { get; set; }
        public string ProcessError { get; set; }
        public int ProcessExitCode { get; set; } = -1;
        public int ProcessID { get; set; } = -1;
        public bool CreateWindow { get; set; }
        public ProcessStatesEnum ProcessState { get; set; }

        public ProcessClass(string processName, string processArguments, bool createWindow)
        {
            ProcessName = processName;
            ProcessArguments = processArguments;
            CreateWindow = createWindow;
        }

        public void StartProcess()
        {
            process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C " + ProcessArguments;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            //process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.CreateNoWindow = !CreateWindow;
            
            process.Start();
            
            ProcessState = ProcessStatesEnum.Running;

            LogManager.processLog.Log(string.Format("Process [{0}] started with args [{1}]", ProcessName, ProcessArguments));

            ProcessID = process.Id;


            EventHandler Process_Exited = (sender, e) =>
            {
                ProcessState = ProcessStatesEnum.Stopped;
                ProcessExitCode = process.ExitCode;
                LogManager.processLog.Log(string.Format("Process [{0}] has exited with code [{1}]", ProcessName, ProcessExitCode));
                process.Dispose();
                LogManager.processLog.Log(string.Format("Process [{0}] has been disposed", ProcessName));
            };
            process.Exited += Process_Exited;

            LogManager.processLog.Log(string.Format("Process [{0}] exit event connected", ProcessName));
        }

        public void StopProcess(bool shouldKill = false)
        {
            if (ProcessState == ProcessStatesEnum.Stopped) LogManager.processLog.Log(string.Format("Process [{0}] is already stopped", ProcessName));
            else if (ProcessExitCode != -1) LogManager.processLog.Log(string.Format("Process [{0}] was exited with code [{1}]", ProcessName, ProcessExitCode));
            else
            {
                if (shouldKill) process.Kill();
                else process.CloseMainWindow();
                ProcessState = ProcessStatesEnum.Stopped;
            }
        }

        public void PauseProcess()
        {
            if (ProcessState == ProcessStatesEnum.Paused) LogManager.processLog.Log(string.Format("Process [{0}] is already paused", ProcessName));
            else if (ProcessExitCode != -1) LogManager.processLog.Log(string.Format("Process [{0}] was exited with code [{1}]", ProcessName, ProcessExitCode));
            else
            {
                if (ProcessState == ProcessStatesEnum.Running)
                {
                    LogManager.processLog.Log(string.Format("Process [{0}] has paused", ProcessName));
                    ProcessState = ProcessStatesEnum.Paused;
                    // [PLACEHOLDER LINE] // Suspend here
                }
                else LogManager.processLog.Log(string.Format("Process [{0}] is not running", ProcessName));
            }
        }

        public void ResumeProcess()
        {
            if (ProcessState == ProcessStatesEnum.Running) LogManager.processLog.Log(string.Format("Process [{0}] is already running", ProcessName));
            else if (ProcessExitCode != -1) LogManager.processLog.Log(string.Format("Process [{0}] was exited with code [{1}]", ProcessName, ProcessExitCode));
            else
            {
                if (ProcessState == ProcessStatesEnum.Paused)
                {
                    LogManager.processLog.Log(string.Format("Process [{0}] has resumed", ProcessName));
                    ProcessState = ProcessStatesEnum.Running;
                    // [PLACEHOLDER LINE] // Resume here
                }
                else LogManager.processLog.Log(string.Format("Process [{0}] is not paused", ProcessName));
            }
        }

        internal void SendCommandToProcess(string v)
        {
            if (ProcessState == ProcessStatesEnum.Running)
            {
                process.StandardInput.WriteLine(v);
                LogManager.processLog.Log(string.Format("Command [{0}] sent to process [{1}]", v, ProcessName));
            }
            else LogManager.processLog.Log(string.Format("Process [{0}] is not running", ProcessName));
        }

        internal void SendKeyToProcess(Keys key)
        {
            // Send the key to the process
            if (ProcessState == ProcessStatesEnum.Running)
            {
                // [PLACEHOLDER LINE] // Send key here
                LogManager.processLog.Log(string.Format("Key [{0}] sent to process [{1}]", key, ProcessName));
            }
            else LogManager.processLog.Log(string.Format("Process [{0}] is not running", ProcessName));
        }
    }


    /*
     * 
     * \
     * \\
     * \\\ TODO: 
     * /// Figure out why the fuckin process wont fuckin resume or pause or whatever the fuck its not doing
     * //
     * /
     * 
    */
}