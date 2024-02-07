using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
namespace WindowsFormsApp17
{
    public partial class MainForm : Form
    {
        private FilterInfoCollection videoDevices; // Danh sách thiết bị video
        private VideoCaptureDevice videoSource; // Đối tượng chứa video
        public MainForm()
        {
            InitializeComponent();
        }

        

        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox.Image = (System.Drawing.Image)eventArgs.Frame.Clone(); // Hiển thị frame mới lên PictureBox
        }

        

        private void MainForm_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice); // Lấy danh sách thiết bị video

            if (videoDevices.Count == 0) // Kiểm tra xem có thiết bị video nào không
            {
                MessageBox.Show("Không tìm thấy thiết bị video.");
                return;
            }

            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString); // Sử dụng thiết bị video đầu tiên
            videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame); // Đăng ký sự kiện khi có frame mới
            videoSource.Start(); // Bắt đầu khởi động camera
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void MainForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning) // Kiểm tra và dừng camera nếu đang chạy
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
                videoSource = null;
            }
        }
    }
}
