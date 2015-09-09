using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace Screen2WebM
{
    public partial class MainForm : Form
    {
        [StructLayout(LayoutKind.Sequential)]
        struct CURSORINFO
        {
            public Int32 cbSize;
            public Int32 flags;
            public IntPtr hCursor;
            public POINTAPI ptScreenPos;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct POINTAPI
        {
            public int x;
            public int y;
        }

        [DllImport("user32.dll")]
        static extern bool GetCursorInfo(out CURSORINFO pci);

        [DllImport("user32.dll")]
        static extern bool DrawIcon(IntPtr hDC, int X, int Y, IntPtr hIcon);

        const Int32 CURSOR_SHOWING = 0x00000001;


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
            return new Size(mainContainer.Panel2.Width, mainContainer.Panel2.Height - 2);
        }

        private Bitmap CaptureScreen(int frame, string folderName)
        {
            Size captureArea = GetRecordingAreaSize();
            Bitmap target = new Bitmap(captureArea.Width, captureArea.Height);
            Point captureAreaLocation = new Point();
            bool recordCursor = false;
            mainContainer.Panel2.Invoke((MethodInvoker) delegate
            {
                captureAreaLocation = mainContainer.Panel2.PointToScreen(Point.Empty);
            });
            checkBox2.Invoke((MethodInvoker) delegate
            {
                recordCursor = checkBox2.Checked;
            });
            using (Graphics g = Graphics.FromImage(target))
            {
                g.CopyFromScreen(captureAreaLocation, new Point(0, 0), new Size(captureArea.Width, captureArea.Height));
                if (recordCursor)
                {
                    CURSORINFO pci;
                    pci.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(typeof (CURSORINFO));
                    if (GetCursorInfo(out pci))
                    {
                        if (pci.flags == CURSOR_SHOWING)
                        {
                            int realPosX = pci.ptScreenPos.x - captureAreaLocation.X;
                            int realPosY = pci.ptScreenPos.y - captureAreaLocation.Y;
                            if (realPosX >= 0 && realPosY >= 0 && realPosX <= captureAreaLocation.X + captureArea.Width &&
                                realPosY <= captureAreaLocation.Y + captureArea.Height)
                            {
                                DrawIcon(g.GetHdc(), realPosX, realPosY, pci.hCursor);
                                g.ReleaseHdc();
                            }
                        }
                    }
                }
            }
            string tmpPath = Path.GetTempPath();
            if (!Directory.Exists(tmpPath + folderName))
            {
                Directory.CreateDirectory(tmpPath + folderName);
            }
            return target;
        }

        private void SaveImage(object imageObj, object foldername, object frame)
        {
            string tmpPath = Path.GetTempPath();
            Bitmap image = (Bitmap) imageObj;
            image.Save(String.Format("{0}{2}\\{1}.{3}", tmpPath, (int)frame, (string)foldername, radioButton1.Checked ? "jpg" : "png"), radioButton1.Checked ? System.Drawing.Imaging.ImageFormat.Jpeg : System.Drawing.Imaging.ImageFormat.Png );
        }

        private void StartRecording(object fpsobject)
        {
            int fps = (int) fpsobject;

            // outputTextBox.Text, ffmpegTextBox.Text
            string output = "";

            outputTextBox.Invoke((MethodInvoker) delegate
            {
                output = outputTextBox.Text;
            });
            radioButton1.Invoke((MethodInvoker) delegate
            {
                radioButton1.Enabled = false;
            });
            radioButton2.Invoke((MethodInvoker)delegate
            {
                radioButton2.Enabled = false;
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
            string command = String.Format("/C \"ffmpeg -framerate {1} -start_number 0 -i \"{0}\\%d.{3}\" -r {1} -c:v libvpx {2}", tmpPath + tmpFolderName, fps, output + "\"" + (checkBox1.Checked ? " && pause" : ""), (radioButton1.Checked ? "jpg" : "png"));
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
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
            }
            else if (!_recording)
            {
                _recording = true;
                playButton.Text = "Stop";
                recordingStatusLabel.Text = "Recording";
                FPSCounter.Enabled = false;
                outputTextBox.Enabled = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
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
