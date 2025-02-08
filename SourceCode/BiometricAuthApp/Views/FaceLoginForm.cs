using BiometricAuthApp.Services;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Ocl;
using Emgu.CV.Structure;
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
using static System.Net.Mime.MediaTypeNames;

namespace BiometricAuthApp.Views
{
    public partial class FaceLoginForm : Form
    {
        private System.Timers.Timer captureTimer;
        private VideoCapture videoCapture;
        public string UserName { get; private set; } = "";

        private FaceRecognitionService faceRecognitionService;

        private int Count = 0;
        private string lastName = "";

        public FaceLoginForm()
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
            try
            {
                Image<Bgr, byte> bgrFrame = videoCapture.QueryFrame().ToImage<Bgr, Byte>();


                bgrFrame = videoCapture.QueryFrame().ToImage<Bgr, Byte>();

                if (bgrFrame != null)
                {
                    try
                    {//for emgu cv bug

                        var faces = faceRecognitionService.DetectFaces(bgrFrame);
                        if (faces != null && faces.Length != 0)
                        {
                            foreach (var face in faces)
                            {
                                bgrFrame.Draw(face, new Bgr(255, 255, 0), 2);
                            }

                            string res = faceRecognitionService.Recognize(bgrFrame, faces[0]);
                            Console.WriteLine($"found res = {res} {res == ""}");
                            Invoke(new Action(() =>
                            {
                                FoundNameLabel.Text = res == "" ? "Не распознан" : res;

                            }));
                            if (res != "")
                            {
                                Console.WriteLine($"recognized {res}");
                                if (lastName == res)
                                {
                                    Count++;
                                }
                                else
                                {
                                    Count = 0;
                                    lastName = res;
                                }
                                if (Count >= Config.MinRecognitionCount)
                                {

                                    Console.WriteLine($"success admin: {res}");
                                    UserName = res;
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                            }
                        }

                    }
                    catch (Exception ex)
                    {

                        //todo log
                    }
                    CameraCapture.Image = bgrFrame.ToBitmap();

                }
            }
            catch(Exception ex)
            {
                //нужно чтобы кадры, которые были в обработке на момент нажатия кнопки не вызывали ошибки
            }
        }

        private void FaceLoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            captureTimer.Stop();
            videoCapture.Stop();
            videoCapture.Release();
        }

        private void loginByPasswordBytton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
