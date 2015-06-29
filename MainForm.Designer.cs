namespace Screen2WebM
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainContainer = new System.Windows.Forms.SplitContainer();
            this.playButton = new System.Windows.Forms.Button();
            this.TopmostCheckbox = new System.Windows.Forms.CheckBox();
            this.FPSCounter = new System.Windows.Forms.NumericUpDown();
            this.fpsLabel = new System.Windows.Forms.Label();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.filenameLabel = new System.Windows.Forms.Label();
            this.ffmpegLabel = new System.Windows.Forms.Label();
            this.ffmpegTextBox = new System.Windows.Forms.TextBox();
            this.mainStatus = new System.Windows.Forms.StatusStrip();
            this.sizeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.recordingStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
            this.mainContainer.Panel1.SuspendLayout();
            this.mainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FPSCounter)).BeginInit();
            this.mainStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainContainer.Location = new System.Drawing.Point(0, 0);
            this.mainContainer.Name = "mainContainer";
            // 
            // mainContainer.Panel1
            // 
            this.mainContainer.Panel1.Controls.Add(this.ffmpegTextBox);
            this.mainContainer.Panel1.Controls.Add(this.ffmpegLabel);
            this.mainContainer.Panel1.Controls.Add(this.filenameLabel);
            this.mainContainer.Panel1.Controls.Add(this.outputTextBox);
            this.mainContainer.Panel1.Controls.Add(this.fpsLabel);
            this.mainContainer.Panel1.Controls.Add(this.FPSCounter);
            this.mainContainer.Panel1.Controls.Add(this.TopmostCheckbox);
            this.mainContainer.Panel1.Controls.Add(this.playButton);
            this.mainContainer.Size = new System.Drawing.Size(693, 506);
            this.mainContainer.SplitterDistance = 132;
            this.mainContainer.TabIndex = 1;
            // 
            // playButton
            // 
            this.playButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.playButton.AutoSize = true;
            this.playButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.playButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.Location = new System.Drawing.Point(12, 12);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(102, 39);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "Record";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // TopmostCheckbox
            // 
            this.TopmostCheckbox.AutoSize = true;
            this.TopmostCheckbox.Checked = true;
            this.TopmostCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TopmostCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopmostCheckbox.Location = new System.Drawing.Point(10, 69);
            this.TopmostCheckbox.Name = "TopmostCheckbox";
            this.TopmostCheckbox.Size = new System.Drawing.Size(96, 17);
            this.TopmostCheckbox.TabIndex = 1;
            this.TopmostCheckbox.Text = "Always on Top";
            this.TopmostCheckbox.UseVisualStyleBackColor = true;
            this.TopmostCheckbox.CheckedChanged += new System.EventHandler(this.TopmostCheckbox_CheckedChanged);
            // 
            // FPSCounter
            // 
            this.FPSCounter.Location = new System.Drawing.Point(49, 92);
            this.FPSCounter.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.FPSCounter.Name = "FPSCounter";
            this.FPSCounter.Size = new System.Drawing.Size(45, 20);
            this.FPSCounter.TabIndex = 2;
            this.FPSCounter.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // fpsLabel
            // 
            this.fpsLabel.AutoSize = true;
            this.fpsLabel.Location = new System.Drawing.Point(9, 94);
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(27, 13);
            this.fpsLabel.TabIndex = 3;
            this.fpsLabel.Text = "FPS";
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(10, 140);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(108, 20);
            this.outputTextBox.TabIndex = 4;
            this.outputTextBox.Text = "output.webm";
            // 
            // filenameLabel
            // 
            this.filenameLabel.AutoSize = true;
            this.filenameLabel.Location = new System.Drawing.Point(9, 124);
            this.filenameLabel.Name = "filenameLabel";
            this.filenameLabel.Size = new System.Drawing.Size(111, 13);
            this.filenameLabel.TabIndex = 5;
            this.filenameLabel.Text = "Output Filename/Path";
            // 
            // ffmpegLabel
            // 
            this.ffmpegLabel.AutoSize = true;
            this.ffmpegLabel.Location = new System.Drawing.Point(7, 173);
            this.ffmpegLabel.Name = "ffmpegLabel";
            this.ffmpegLabel.Size = new System.Drawing.Size(116, 13);
            this.ffmpegLabel.TabIndex = 6;
            this.ffmpegLabel.Text = "Custom ffmpeg Options";
            // 
            // ffmpegTextBox
            // 
            this.ffmpegTextBox.Location = new System.Drawing.Point(10, 189);
            this.ffmpegTextBox.Name = "ffmpegTextBox";
            this.ffmpegTextBox.Size = new System.Drawing.Size(110, 20);
            this.ffmpegTextBox.TabIndex = 7;
            this.ffmpegTextBox.Text = "/C ffmpeg -framerate {1} -start_number 0 -i \"{0}\\%d.jpg\" -r {1} -c:v libvpx {2}";
            // 
            // mainStatus
            // 
            this.mainStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recordingStatusLabel,
            this.sizeLabel,
            this.timeLabel});
            this.mainStatus.Location = new System.Drawing.Point(0, 504);
            this.mainStatus.Name = "mainStatus";
            this.mainStatus.Size = new System.Drawing.Size(693, 22);
            this.mainStatus.TabIndex = 2;
            this.mainStatus.Text = "statusStrip1";
            // 
            // sizeLabel
            // 
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(24, 17);
            this.sizeLabel.Text = "1s1";
            // 
            // recordingStatusLabel
            // 
            this.recordingStatusLabel.Name = "recordingStatusLabel";
            this.recordingStatusLabel.Size = new System.Drawing.Size(72, 17);
            this.recordingStatusLabel.Text = "On Stand By";
            // 
            // timeLabel
            // 
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 526);
            this.Controls.Add(this.mainStatus);
            this.Controls.Add(this.mainContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Screen2Webm";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.mainContainer.Panel1.ResumeLayout(false);
            this.mainContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
            this.mainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FPSCounter)).EndInit();
            this.mainStatus.ResumeLayout(false);
            this.mainStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainContainer;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.CheckBox TopmostCheckbox;
        private System.Windows.Forms.Label fpsLabel;
        private System.Windows.Forms.NumericUpDown FPSCounter;
        private System.Windows.Forms.TextBox ffmpegTextBox;
        private System.Windows.Forms.Label ffmpegLabel;
        private System.Windows.Forms.Label filenameLabel;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.StatusStrip mainStatus;
        private System.Windows.Forms.ToolStripStatusLabel sizeLabel;
        private System.Windows.Forms.ToolStripStatusLabel recordingStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel timeLabel;

    }
}

