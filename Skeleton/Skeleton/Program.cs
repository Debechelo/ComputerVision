using System;
using OpenCvSharp;

namespace Skeleton
{
    class Program
    {
        static void Main(string[] args)
        {

            Mat B = new Mat("C:\\Users\\Павел\\source\\repos\\skeleton\\skelet.jpg");
            Mat skelet = new Mat();
            Cv2.CvtColor(B, skelet, ColorConversionCodes.BGR2GRAY);
            Cv2.ImShow("1.png", skelet);

            // лапласиан
            Mat laplac = new Mat();
            Cv2.Laplacian(skelet, laplac, 16, 3);
            Cv2.ImShow("2.png", laplac);

            Mat laplacian = new Mat();//skelet + laplac;
            Cv2.Add(skelet, laplac, laplacian, null, MatType.CV_8U);
            //Cv2.BitwiseOr(skelet,laplac,laplacian,MatType.CV_16S);
            Cv2.ImShow("3.png", laplacian);


            Mat sobelX = new Mat();
            Cv2.Sobel(skelet, sobelX, 0, 1, 0);
            Mat sobelY = new Mat();
            Cv2.Sobel(skelet, sobelY, 0, 0, 1);
            Mat sobel = Cv2.Abs(sobelX) + Cv2.Abs(sobelY);
            Cv2.ImShow("4.png", sobel);



            //усредняющий фильтр
            Mat BlurSobel = new Mat();
            Cv2.Blur(sobel, BlurSobel, new Size(5, 5));
            Cv2.ImShow("5.png", BlurSobel);


            // перемножение лапласиана и усредняющего фильтра
            Mat mask = new Mat();
            Cv2.Multiply(laplacian / 90, BlurSobel, mask);
            Cv2.ImShow("6.png", mask);



            Mat sharpness = new Mat();
            Cv2.Add(skelet, mask, sharpness, null, MatType.CV_32F);
            Mat additionImg = skelet + mask;
            Cv2.ImShow("7.png", additionImg);


            Mat gammaCorection = new Mat();
            Cv2.Pow(sharpness, 0.5, gammaCorection);
            Cv2.ImShow("8.png", gammaCorection / 16);

            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}
