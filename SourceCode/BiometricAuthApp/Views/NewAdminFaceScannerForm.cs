using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using BiometricAuthApp.Services;

namespace BiometricAuthApp.Views
{
    public partial class NewAdminFaceScannerForm : Form
    {

        private System.Timers.Timer captureTimer;
        private VideoCapture videoCapture;
        private FaceRecognitionService faceRecognitionService;

        public NewAdminFaceScannerForm()
        {
            InitializeComponent();
            captureTimer = new System.Timers.Timer()
            {
                Interval = Config.TimerResponseValue

            };
            captureTimer.Elapsed += CaptureTimer_Elapsed;
            videoCapture = new VideoCapture(Config.ActiveCameraIndex);
            captureTimer.Start();
        }





        private async void CaptureTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (faceRecognitionService == null)
            {
                faceRecognitionService = await FaceRecognitionService.GetInstance();
            }

            ProcessFrame();
        }

        private void ProcessFrame()
        {
            Image<Bgr, byte> bgrFrame = videoCapture.QueryFrame().ToImage<Bgr, Byte>();


            bgrFrame = videoCapture.QueryFrame().ToImage<Bgr, Byte>();

            if (bgrFrame != null)
            {
                try
                {//for emgu cv bug

                    var faces = faceRecognitionService.DetectFaces(bgrFrame);
                    foreach (var face in faces)
                    {
                        bgrFrame.Draw(face, new Bgr(255, 255, 0), 2);
                        break;
                    }
                }
                catch (Exception ex)
                {

                    //todo log
                }
                CameraCapture.Image = bgrFrame.ToBitmap();

            }
        }

        private async void loginByPasswordBytton_Click(object sender, EventArgs e)
        {
            Image<Bgr, byte> bgrFrame = videoCapture.QueryFrame().ToImage<Bgr, Byte>();
            var name = NameTextbox.Text;
            var status = await faceRecognitionService.AddImage(bgrFrame,name);

            switch (status)
            {
                case FaceRecognitionService.AddStatusCode.OK:
                    {
                        MessageBox.Show(@$"Изображение для {name} добавлено или обновлено!", @"Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case FaceRecognitionService.AddStatusCode.NO_SUCH_NAME:
                    MessageBox.Show(@$"Пользователь {name} не найден", @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case FaceRecognitionService.AddStatusCode.TOO_MANY_FACES:
                    MessageBox.Show(@$"Обнаружено слишком много лиц, нужно 1!", @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case FaceRecognitionService.AddStatusCode.NO_FACES_FOUND:
                    MessageBox.Show(@$"Лиц не обнаружено, нужно 1!", @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void FaceLoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            captureTimer.Stop();
            videoCapture.Stop();
            videoCapture.Release();
        }

        
    }
}
