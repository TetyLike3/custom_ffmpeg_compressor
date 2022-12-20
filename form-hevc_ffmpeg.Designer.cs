namespace custom_ffmpeg_compressor
{
    partial class form_hevc_ffmpeg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label FileProgressLabel;
            System.Windows.Forms.Label TotalProgressLabel;
            this.ModuleName = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.SettingsGroup = new System.Windows.Forms.GroupBox();
            this.controlsGroup = new System.Windows.Forms.GroupBox();
            this.StopButton = new System.Windows.Forms.Button();
            this.WaitForVideoCheck = new System.Windows.Forms.CheckBox();
            this.PauseButton = new System.Windows.Forms.Button();
            this.ModuleSettingsGroup = new System.Windows.Forms.GroupBox();
            this.QualitySettingsGroup = new System.Windows.Forms.GroupBox();
            this.CQPSetting = new System.Windows.Forms.TrackBar();
            this.CQPLabel = new System.Windows.Forms.Label();
            this.OnFinishedGroup = new System.Windows.Forms.GroupBox();
            this.CloseProgramRadio = new System.Windows.Forms.RadioButton();
            this.DoNothingRadio = new System.Windows.Forms.RadioButton();
            this.StatusGroup = new System.Windows.Forms.GroupBox();
            this.ModuleStatus = new System.Windows.Forms.Label();
            this.FileProgressBar = new System.Windows.Forms.ProgressBar();
            this.TotalProgressBar = new System.Windows.Forms.ProgressBar();
            this.CloseButton = new System.Windows.Forms.Button();
            this.NightModeButton = new System.Windows.Forms.Button();
            this.LogPreview = new System.Windows.Forms.TextBox();
            FileProgressLabel = new System.Windows.Forms.Label();
            TotalProgressLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SettingsGroup.SuspendLayout();
            this.controlsGroup.SuspendLayout();
            this.ModuleSettingsGroup.SuspendLayout();
            this.QualitySettingsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CQPSetting)).BeginInit();
            this.OnFinishedGroup.SuspendLayout();
            this.StatusGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileProgressLabel
            // 
            FileProgressLabel.AutoSize = true;
            FileProgressLabel.BackColor = System.Drawing.Color.Transparent;
            FileProgressLabel.Location = new System.Drawing.Point(6, 35);
            FileProgressLabel.Name = "FileProgressLabel";
            FileProgressLabel.Size = new System.Drawing.Size(67, 13);
            FileProgressLabel.TabIndex = 3;
            FileProgressLabel.Text = "File Progress";
            // 
            // TotalProgressLabel
            // 
            TotalProgressLabel.AutoSize = true;
            TotalProgressLabel.BackColor = System.Drawing.Color.Transparent;
            TotalProgressLabel.Location = new System.Drawing.Point(6, 77);
            TotalProgressLabel.Name = "TotalProgressLabel";
            TotalProgressLabel.Size = new System.Drawing.Size(75, 13);
            TotalProgressLabel.TabIndex = 1;
            TotalProgressLabel.Text = "Total Progress";
            // 
            // ModuleName
            // 
            this.ModuleName.AutoSize = true;
            this.ModuleName.BackColor = System.Drawing.Color.Transparent;
            this.ModuleName.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModuleName.ForeColor = System.Drawing.Color.DimGray;
            this.ModuleName.Location = new System.Drawing.Point(12, 9);
            this.ModuleName.Name = "ModuleName";
            this.ModuleName.Size = new System.Drawing.Size(218, 25);
            this.ModuleName.TabIndex = 0;
            this.ModuleName.Text = "HEVC FFmpeg Module";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // SettingsGroup
            // 
            this.SettingsGroup.Controls.Add(this.controlsGroup);
            this.SettingsGroup.Controls.Add(this.ModuleSettingsGroup);
            this.SettingsGroup.Controls.Add(this.OnFinishedGroup);
            this.SettingsGroup.Location = new System.Drawing.Point(12, 38);
            this.SettingsGroup.Name = "SettingsGroup";
            this.SettingsGroup.Size = new System.Drawing.Size(812, 197);
            this.SettingsGroup.TabIndex = 1;
            this.SettingsGroup.TabStop = false;
            this.SettingsGroup.Text = "Settings";
            // 
            // controlsGroup
            // 
            this.controlsGroup.Controls.Add(this.StopButton);
            this.controlsGroup.Controls.Add(this.WaitForVideoCheck);
            this.controlsGroup.Controls.Add(this.PauseButton);
            this.controlsGroup.Location = new System.Drawing.Point(521, 19);
            this.controlsGroup.Name = "controlsGroup";
            this.controlsGroup.Size = new System.Drawing.Size(179, 172);
            this.controlsGroup.TabIndex = 1;
            this.controlsGroup.TabStop = false;
            this.controlsGroup.Text = "Controls";
            // 
            // StopButton
            // 
            this.StopButton.BackColor = System.Drawing.Color.Crimson;
            this.StopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopButton.ForeColor = System.Drawing.Color.Snow;
            this.StopButton.Location = new System.Drawing.Point(6, 45);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 2;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = false;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // WaitForVideoCheck
            // 
            this.WaitForVideoCheck.AutoSize = true;
            this.WaitForVideoCheck.BackColor = System.Drawing.Color.Transparent;
            this.WaitForVideoCheck.Location = new System.Drawing.Point(87, 20);
            this.WaitForVideoCheck.Name = "WaitForVideoCheck";
            this.WaitForVideoCheck.Size = new System.Drawing.Size(92, 17);
            this.WaitForVideoCheck.TabIndex = 1;
            this.WaitForVideoCheck.Text = "Wait for video";
            this.WaitForVideoCheck.UseVisualStyleBackColor = false;
            this.WaitForVideoCheck.Click += new System.EventHandler(this.WaitForVideoCheck_CheckedChanged);
            // 
            // PauseButton
            // 
            this.PauseButton.BackColor = System.Drawing.Color.DarkOrange;
            this.PauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PauseButton.ForeColor = System.Drawing.Color.Snow;
            this.PauseButton.Location = new System.Drawing.Point(6, 16);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(75, 23);
            this.PauseButton.TabIndex = 0;
            this.PauseButton.Text = "Resume";
            this.PauseButton.UseVisualStyleBackColor = false;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // ModuleSettingsGroup
            // 
            this.ModuleSettingsGroup.Controls.Add(this.QualitySettingsGroup);
            this.ModuleSettingsGroup.Location = new System.Drawing.Point(7, 19);
            this.ModuleSettingsGroup.Name = "ModuleSettingsGroup";
            this.ModuleSettingsGroup.Size = new System.Drawing.Size(508, 172);
            this.ModuleSettingsGroup.TabIndex = 1;
            this.ModuleSettingsGroup.TabStop = false;
            this.ModuleSettingsGroup.Text = "Module Settings";
            // 
            // QualitySettingsGroup
            // 
            this.QualitySettingsGroup.Controls.Add(this.CQPSetting);
            this.QualitySettingsGroup.Controls.Add(this.CQPLabel);
            this.QualitySettingsGroup.Location = new System.Drawing.Point(11, 19);
            this.QualitySettingsGroup.Name = "QualitySettingsGroup";
            this.QualitySettingsGroup.Size = new System.Drawing.Size(200, 147);
            this.QualitySettingsGroup.TabIndex = 1;
            this.QualitySettingsGroup.TabStop = false;
            this.QualitySettingsGroup.Text = "Quality";
            // 
            // CQPSetting
            // 
            this.CQPSetting.Location = new System.Drawing.Point(6, 37);
            this.CQPSetting.Maximum = 52;
            this.CQPSetting.Minimum = 12;
            this.CQPSetting.Name = "CQPSetting";
            this.CQPSetting.Size = new System.Drawing.Size(188, 45);
            this.CQPSetting.TabIndex = 2;
            this.CQPSetting.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.CQPSetting.Value = 24;
            // 
            // CQPLabel
            // 
            this.CQPLabel.AutoSize = true;
            this.CQPLabel.BackColor = System.Drawing.Color.Transparent;
            this.CQPLabel.Location = new System.Drawing.Point(6, 21);
            this.CQPLabel.Name = "CQPLabel";
            this.CQPLabel.Size = new System.Drawing.Size(29, 13);
            this.CQPLabel.TabIndex = 1;
            this.CQPLabel.Text = "CQP";
            // 
            // OnFinishedGroup
            // 
            this.OnFinishedGroup.Controls.Add(this.CloseProgramRadio);
            this.OnFinishedGroup.Controls.Add(this.DoNothingRadio);
            this.OnFinishedGroup.Location = new System.Drawing.Point(706, 19);
            this.OnFinishedGroup.Name = "OnFinishedGroup";
            this.OnFinishedGroup.Size = new System.Drawing.Size(95, 172);
            this.OnFinishedGroup.TabIndex = 0;
            this.OnFinishedGroup.TabStop = false;
            this.OnFinishedGroup.Text = "When finished:";
            // 
            // CloseProgramRadio
            // 
            this.CloseProgramRadio.AutoSize = true;
            this.CloseProgramRadio.BackColor = System.Drawing.Color.Transparent;
            this.CloseProgramRadio.Location = new System.Drawing.Point(6, 42);
            this.CloseProgramRadio.Name = "CloseProgramRadio";
            this.CloseProgramRadio.Size = new System.Drawing.Size(93, 17);
            this.CloseProgramRadio.TabIndex = 1;
            this.CloseProgramRadio.Text = "Close Program";
            this.CloseProgramRadio.UseVisualStyleBackColor = false;
            // 
            // DoNothingRadio
            // 
            this.DoNothingRadio.AutoSize = true;
            this.DoNothingRadio.BackColor = System.Drawing.Color.Transparent;
            this.DoNothingRadio.Checked = true;
            this.DoNothingRadio.Location = new System.Drawing.Point(6, 19);
            this.DoNothingRadio.Name = "DoNothingRadio";
            this.DoNothingRadio.Size = new System.Drawing.Size(79, 17);
            this.DoNothingRadio.TabIndex = 0;
            this.DoNothingRadio.TabStop = true;
            this.DoNothingRadio.Text = "Do Nothing";
            this.DoNothingRadio.UseVisualStyleBackColor = false;
            // 
            // StatusGroup
            // 
            this.StatusGroup.Controls.Add(this.LogPreview);
            this.StatusGroup.Controls.Add(this.ModuleStatus);
            this.StatusGroup.Controls.Add(FileProgressLabel);
            this.StatusGroup.Controls.Add(this.FileProgressBar);
            this.StatusGroup.Controls.Add(TotalProgressLabel);
            this.StatusGroup.Controls.Add(this.TotalProgressBar);
            this.StatusGroup.Location = new System.Drawing.Point(12, 241);
            this.StatusGroup.Name = "StatusGroup";
            this.StatusGroup.Size = new System.Drawing.Size(812, 188);
            this.StatusGroup.TabIndex = 2;
            this.StatusGroup.TabStop = false;
            this.StatusGroup.Text = "Status";
            // 
            // ModuleStatus
            // 
            this.ModuleStatus.AutoSize = true;
            this.ModuleStatus.BackColor = System.Drawing.Color.Transparent;
            this.ModuleStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModuleStatus.ForeColor = System.Drawing.Color.Gray;
            this.ModuleStatus.Location = new System.Drawing.Point(6, 16);
            this.ModuleStatus.Name = "ModuleStatus";
            this.ModuleStatus.Size = new System.Drawing.Size(98, 13);
            this.ModuleStatus.TabIndex = 4;
            this.ModuleStatus.Text = "Module Status: Idle";
            // 
            // FileProgressBar
            // 
            this.FileProgressBar.Location = new System.Drawing.Point(6, 51);
            this.FileProgressBar.Name = "FileProgressBar";
            this.FileProgressBar.Size = new System.Drawing.Size(758, 23);
            this.FileProgressBar.TabIndex = 2;
            // 
            // TotalProgressBar
            // 
            this.TotalProgressBar.Location = new System.Drawing.Point(6, 93);
            this.TotalProgressBar.Name = "TotalProgressBar";
            this.TotalProgressBar.Size = new System.Drawing.Size(758, 23);
            this.TotalProgressBar.TabIndex = 0;
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.IndianRed;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.ForeColor = System.Drawing.Color.Brown;
            this.CloseButton.Location = new System.Drawing.Point(748, 10);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(76, 24);
            this.CloseButton.TabIndex = 3;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // NightModeButton
            // 
            this.NightModeButton.BackColor = System.Drawing.Color.Gray;
            this.NightModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NightModeButton.ForeColor = System.Drawing.Color.DimGray;
            this.NightModeButton.Location = new System.Drawing.Point(718, 10);
            this.NightModeButton.Name = "NightModeButton";
            this.NightModeButton.Size = new System.Drawing.Size(24, 24);
            this.NightModeButton.TabIndex = 4;
            this.NightModeButton.UseVisualStyleBackColor = false;
            this.NightModeButton.Visible = false;
            // 
            // LogPreview
            // 
            this.LogPreview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogPreview.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.LogPreview.Location = new System.Drawing.Point(6, 123);
            this.LogPreview.Multiline = true;
            this.LogPreview.Name = "LogPreview";
            this.LogPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogPreview.Size = new System.Drawing.Size(758, 59);
            this.LogPreview.TabIndex = 5;
            this.LogPreview.Text = "-- LOG PREVIEW --";
            // 
            // form_hevc_ffmpeg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(836, 441);
            this.Controls.Add(this.NightModeButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.StatusGroup);
            this.Controls.Add(this.SettingsGroup);
            this.Controls.Add(this.ModuleName);
            this.Name = "form_hevc_ffmpeg";
            this.Text = "form_hevc_ffmpeg";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.SettingsGroup.ResumeLayout(false);
            this.controlsGroup.ResumeLayout(false);
            this.controlsGroup.PerformLayout();
            this.ModuleSettingsGroup.ResumeLayout(false);
            this.QualitySettingsGroup.ResumeLayout(false);
            this.QualitySettingsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CQPSetting)).EndInit();
            this.OnFinishedGroup.ResumeLayout(false);
            this.OnFinishedGroup.PerformLayout();
            this.StatusGroup.ResumeLayout(false);
            this.StatusGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ModuleName;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.GroupBox StatusGroup;
        private System.Windows.Forms.ProgressBar TotalProgressBar;
        private System.Windows.Forms.GroupBox SettingsGroup;
        private System.Windows.Forms.GroupBox OnFinishedGroup;
        private System.Windows.Forms.RadioButton DoNothingRadio;
        private System.Windows.Forms.GroupBox ModuleSettingsGroup;
        private System.Windows.Forms.ProgressBar FileProgressBar;
        private System.Windows.Forms.Label ModuleStatus;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button NightModeButton;
        private System.Windows.Forms.GroupBox QualitySettingsGroup;
        private System.Windows.Forms.Label CQPLabel;
        private System.Windows.Forms.TrackBar CQPSetting;
        private System.Windows.Forms.GroupBox controlsGroup;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.CheckBox WaitForVideoCheck;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.RadioButton CloseProgramRadio;
        private System.Windows.Forms.TextBox LogPreview;
    }
}