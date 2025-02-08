using BiometricAuthApp.Data;
using BiometricAuthApp.Dto;
using BiometricAuthApp.Models;
using BiometricAuthApp.Repositories;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BiometricAuthApp.Services
{
    public class FaceRecognitionService
    {
        private static FaceRecognitionService faceRecognitionService = null;

        private readonly FaceRepository faceRepository = new();
        //private readonly UserRe faceRepository = new();
        private bool IsInited = false;
        private CascadeClassifier haarCascade;
        private List<FaceDto> faceList = new();

        private VectorOfMat imageList = new();
        private List<string> nameList = new();
        private VectorOfInt labelList = new();
        private EigenFaceRecognizer recognizer;



        public async static Task<FaceRecognitionService> GetInstance()
        {
            if (faceRecognitionService == null)
            {
                faceRecognitionService = new FaceRecognitionService();
                await faceRecognitionService.Init();
            }
            return faceRecognitionService;
        }

        private FaceRecognitionService() { }

        public async Task Init()
        {
            await Reinit();
        }

        private async Task Reinit()
        {
            IsInited = false;

            if (!File.Exists(Config.HaarCascadePath))
            {
                string text = "Cannot find Haar cascade data file:\n\n";
                text += Config.HaarCascadePath;
                MessageBox.Show(text, "Error"); // подозрительно
                return;
            }
            haarCascade = new CascadeClassifier(Config.HaarCascadePath);

            faceList.Clear();

            // Create empty directory / file for face data if it doesn't exist
            if (!Directory.Exists(Config.FacePhotosPath))
            {
                Directory.CreateDirectory(Config.FacePhotosPath);

            }

            if (!File.Exists(Config.FaceListTextFile)) //создаем пути хранения, если их нет
            {
                Directory.CreateDirectory(Path.GetDirectoryName(Config.FaceListTextFile));//создаем файлик хранения имен, если его нет
                File.Create(Config.FaceListTextFile).Close();
            }

            var faces = await Task.Run(() => faceRepository.GetAll());
            Console.WriteLine($"faces count = {faces.Count}");
            List<string> fileLines = new();

            for (int j = 0; j < faces.Count; j++)
            {
                Console.WriteLine(faces[j].Name);
                fileLines.Add($"face{j + 1}:{faces[j].Name}");
                File.WriteAllBytes(Config.FacePhotosPath + "face" + (j + 1) + Config.ImageFileExtension, faces[j].data);
            }
            File.WriteAllLines(Config.FaceListTextFile, fileLines);





            foreach (var fileStr in File.ReadAllLines(Config.FaceListTextFile))
            {
                string[] lineParts = fileStr.Split(':');
                faceList.Add(new FaceDto()
                {
                    FaceImage = new Image<Gray, byte>(Config.FacePhotosPath + lineParts[0] + Config.ImageFileExtension),
                    PersonName = lineParts[1]
                });
            }
            int i = 0;
            foreach (var face in faceList)
            {
                imageList.Push(face.FaceImage.Mat);
                nameList.Add(face.PersonName);
                labelList.Push(new[] { i++ });
            }


            if (imageList.Size > 0)
            {
                recognizer = new EigenFaceRecognizer(imageList.Size);
                recognizer.Train(imageList, labelList);
            }

            //Directory.Delete(Config.FacePhotosPath, true);
            //File.Delete(Config.FaceListTextFile);
            IsInited = true;

        }
        
        public Rectangle[] DetectFaces(Image<Bgr, byte> bgrFrame)
        {
            Image<Gray, byte> grayframe = bgrFrame.Convert<Gray, byte>();

            return haarCascade.DetectMultiScale(grayframe, 1.2, 15, new System.Drawing.Size(50, 50), new System.Drawing.Size(200, 200));
        }

        public string Recognize(Image<Bgr, byte> bgrFrame, Rectangle frame)
        {
            return FaceRecognition(bgrFrame.Copy(frame).Convert<Gray, byte>());
        }

        private string FaceRecognition(Image<Gray, Byte> detectedFace)
        {
            if (imageList.Size != 0)
            {
                //Eigen Face Algorithm
                FaceRecognizer.PredictionResult result = recognizer.Predict(detectedFace.Resize(100, 100, Inter.Cubic));
                Console.WriteLine($"Treshold = {result.Distance}, {nameList[result.Label]}");
                if (result.Distance <= Config.Threshold)
                {
                    return nameList[result.Label];
                }

            }
            return "";

        }

        public async Task<AddStatusCode> AddImage(Image<Bgr, byte> bgrFrame, string name)
        {
            var detectedFaces = DetectFaces(bgrFrame);
            if (detectedFaces == null || detectedFaces.Length > 1 || detectedFaces.Length == 0)
            {
                return detectedFaces == null || detectedFaces.Length == 0 ? AddStatusCode.NO_FACES_FOUND : AddStatusCode.TOO_MANY_FACES;
            }

            await using var context = new AppDbContext();
            List<string> users = await Task.Run(() => context.Users.Select(a => a.Username).ToList());

            if (!users.Contains(name))
            {
                return AddStatusCode.NO_SUCH_NAME;
            }

            Image<Gray, Byte> detectedFace;
            var face = detectedFaces[0];
            detectedFace = bgrFrame.Copy(face).Convert<Gray, byte>();

            //Save detected face
            detectedFace = detectedFace.Resize(100, 100, Inter.Cubic);
            var path = Config.FacePhotosPath + "face" + (faceList.Count + 1) + Config.ImageFileExtension;

            if (!Directory.Exists(Config.FacePhotosPath))
            {
                Directory.CreateDirectory(Config.FacePhotosPath);

            }

            detectedFace.Save(path);
            byte[] file = File.ReadAllBytes(path);
            var savedPicturesOwners = await Task.Run(() => context.Faces.Select(a => a.Name).ToList());
            {
                await Task.Run(() =>
                {
                    var newFace = new Face()
                    {
                        Name = name,
                        data = file
                    };
                    context.Faces.Add(newFace);
                    context.SaveChanges();
                });
            }

          //  File.Delete(path);
          //  Directory.Delete(Config.FacePhotosPath, true );
            await Reinit();
            Console.WriteLine("reinit finished");
            return AddStatusCode.OK;
        }

        public enum AddStatusCode
        {
            OK,
            NO_SUCH_NAME,
            NO_FACES_FOUND,
            TOO_MANY_FACES
        }

    }
}
