using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiometricAuthApp
{
    public class Config
    {
        public static string FacePhotosPath = "Source\\Faces\\";
        public static string FaceListTextFile = "Source\\FaceList.txt";
        public static string HaarCascadePath = "Resources\\haarcascade_frontalface_default.xml";
        public static int TimerResponseValue = 500;
        public static float Threshold = 1500;
        public static string ImageFileExtension = ".bmp";
        public static int ActiveCameraIndex = 0;//0: Default active camera device
        public const int MinRecognitionCount = 5;
        public const string DEC_KEY = "Ans;ldfa";
        public const string DEC_VI = "75315982";
    }
}
