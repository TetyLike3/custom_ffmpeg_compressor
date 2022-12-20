using System;
using System.Drawing;
using System.Windows.Forms;

namespace custom_ffmpeg_compressor
{
    public partial class form_hevc_ffmpeg : Form
    {

        public bool shouldPause = true;
        public bool isClosed = false;
        public bool shouldStop = false;
        public bool waitForVideo = false;

        // Dictionary for colours for each module state
        internal static System.Collections.Generic.Dictionary<ModuleStatusEnum, Color> moduleStateColours = new System.Collections.Generic.Dictionary<ModuleStatusEnum, Color>()
        {
            {ModuleStatusEnum.idle, Color.Gray},
            {ModuleStatusEnum.running, Color.LightGreen},
            {ModuleStatusEnum.paused, Color.Orange},
            {ModuleStatusEnum.stopped, Color.Red}
        };

        public form_hevc_ffmpeg()
        {
            InitializeComponent();
        }


        public void OnFinished()
        {
            if (CloseProgramRadio.Checked) CloseForm();
        }

        internal void UpdateModuleStatus(ModuleStatusEnum state)
        {
            // Displays the module status in the form
            if (InvokeRequired)
            {
                Invoke(new Action<ModuleStatusEnum>(UpdateModuleStatus), new object[] { state });
                return;
            }

            ModuleStatus.Text = "Module status: " + state.ToString();
            ModuleStatus.ForeColor = moduleStateColours[state];
        }
        


        private void CloseForm()
        {
            isClosed = true;
            Close();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            shouldPause = !shouldPause;

            if (shouldPause)
            {
                // Pause
                PauseButton.BackColor = Color.Green;
                PauseButton.Text = "Resume";   
            }
            else
            {
                // Resume
                PauseButton.BackColor = Color.DarkOrange;
                PauseButton.Text = "Pause";
            }
        }

        private void CloseButton_Click(object sender, EventArgs e) => CloseForm();

        private void WaitForVideoCheck_CheckedChanged(object sender, EventArgs e) { waitForVideo = WaitForVideoCheck.Checked; }

        private void form_hevc_ffmpeg_FormClosing(object sender, FormClosingEventArgs e) { isClosed = true; }

        private void StopButton_Click(object sender, EventArgs e)
        {
            shouldStop = !shouldStop;
            

            if (shouldStop)
            {
                // If the program should stop
                StopButton.BackColor = Color.Green;
                StopButton.Text = "Start";
                PauseButton.Enabled = false;
                PauseButton.BackColor = Color.Gray;
            }
            else
            {
                // If the program should start
                StopButton.BackColor = Color.Red;
                StopButton.Text = "Stop";

                
                PauseButton.Enabled = true;

                // Force the program to resume
                shouldPause = false;
                PauseButton.BackColor = Color.DarkOrange;
                PauseButton.Text = "Pause";
            }
        }

        internal void UpdateLog(string message)
        {
            LogPreview.Text += (Environment.NewLine + message);

            // Scroll to the bottom
            LogPreview.SelectionStart = LogPreview.Text.Length;
            LogPreview.ScrollToCaret();
        }
    }
}
