using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
namespace Screen2WebM
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            mainContainer.Panel2.BackColor = Color.LimeGreen;
            TransparencyKey = Color.LimeGreen;
            mainContainer.FixedPanel = FixedPanel.Panel1;
            TopMost = TopmostCheckbox.Checked;
            Size screenSize = GetRecordingAreaSize();
            sizeLabel.Text = String.Format("{0}x{1}", screenSize.Width, screenSize.Height);
        }

        private bool _recording = false;

        private Size GetRecordingAreaSize()
        {
            return new Size(mainContainer.Panel2.Width, mainContainer.Panel2.Height);
        }

        private Bitmap CaptureScreen(int frame, string folderName)
        {
            Size captureArea = GetRecordingAreaSize();
            Bitmap target = new Bitmap(captureArea.Width, captureArea.Height);
            Point captureAreaLocation = new Point();
            mainContainer.Panel2.Invoke((MethodInvoker) delegate
            {
                captureAreaLocation = mainContainer.Panel2.PointToScreen(Point.Empty);
            });
            using (Graphics g = Graphics.FromImage(target))
            {
                g.CopyFromScreen(captureAreaLocation, new Point(0, 0), new Size(captureArea.Width, captureArea.Height));
            }
            string tmpPath = Path.GetTempPath();
            if (!Directory.Exists(tmpPath + folderName))
            {
                Directory.CreateDirectory(tmpPath + folderName);
            }
            //target.Save(String.Format("{0}{2}\\{1}.jpg", tmpPath, frame, folderName), System.Drawing.Imaging.ImageFormat.Jpeg);
            return target;
        }

        private void SaveImage(object imageObj, object foldername, object frame)
        {
            string tmpPath = Path.GetTempPath();
            Bitmap image = (Bitmap) imageObj;
            image.Save(String.Format("{0}{2}\\{1}.jpg", tmpPath, (int)frame, (string)foldername), System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private void StartRecording(object fpsobject)
        {
            int fps = (int) fpsobject;

            // outputTextBox.Text, ffmpegTextBox.Text
            string output = "";
            string customffMpeg = "";

            outputTextBox.Invoke((MethodInvoker) delegate
            {
                output = outputTextBox.Text;
            });
            ffmpegTextBox.Invoke((MethodInvoker) delegate
            {
                customffMpeg = ffmpegTextBox.Text;
            });

            int timeToSleep = Convert.ToInt32(1000D/fps);
            int currentTime = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            int frame = 0;
            string tmpFolderName = "Screen2WebmFrames" + currentTime;
            DateTime recordingStart = DateTime.Now;

            int extraTicks = 0;
            while (_recording)
            {
                Bitmap tmpbitmap = new Bitmap(CaptureScreen(frame, tmpFolderName));
                var frame1 = frame;
                ThreadStart saveParams = delegate
                {
                    SaveImage(tmpbitmap, tmpFolderName, frame1);
                };
                Thread tmpSaveThread = new Thread(saveParams);
                tmpSaveThread.Start();
                frame++;
                mainStatus.Invoke((MethodInvoker)delegate
                {
                    TimeSpan offset = DateTime.Now.Subtract(recordingStart);
                    int totalSeconds = Convert.ToInt32(offset.TotalSeconds);
                    int seconds = totalSeconds%60;
                    int minutes = Convert.ToInt32(Math.Floor(totalSeconds/60D));
                    timeLabel.Text = String.Format("{0}:{1}", minutes.ToString("00"), seconds.ToString("00"));
                });

                extraTicks += timeToSleep;
                int sleepTime = extraTicks - Convert.ToInt32(DateTime.Now.Subtract(recordingStart).TotalMilliseconds);
                if (sleepTime >= 0)
                    Thread.Sleep(sleepTime);
            }
            string tmpPath = Path.GetTempPath();
            string command = String.Format(customffMpeg, tmpPath + tmpFolderName, fps, output);
            Process ffmpeg = new Process();
            ProcessStartInfo ffmpegOptions = new ProcessStartInfo("cmd.exe", command);
            ffmpeg.StartInfo = ffmpegOptions;
            ffmpeg.Start();
            ffmpeg.WaitForExit();
            Directory.Delete(String.Format("{0}{1}", tmpPath, tmpFolderName), true);
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (_recording)
            {
                _recording = false;
                playButton.Text = "Record";
                recordingStatusLabel.Text = "On Stand By";
                timeLabel.Text = "00:00";
                FPSCounter.Enabled = true;
                outputTextBox.Enabled = true;
                ffmpegTextBox.Enabled = true;
            }
            else if (!_recording)
            {
                _recording = true;
                playButton.Text = "Stop";
                recordingStatusLabel.Text = "Recording";
                FPSCounter.Enabled = false;
                outputTextBox.Enabled = false;
                ffmpegTextBox.Enabled = false;
                Thread captureThread = new Thread(new ParameterizedThreadStart(StartRecording));
                captureThread.Start(Convert.ToInt32(FPSCounter.Value));
            }
        }
        
        private void TopmostCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = TopmostCheckbox.Checked;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Size screenSize = GetRecordingAreaSize();
            sizeLabel.Text = String.Format("{0}x{1}", screenSize.Width, screenSize.Height);
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
