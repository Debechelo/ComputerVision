﻿using System;
using OpenCvSharp;

namespace gears
{
    class Program
    {
        static void Main(string[] args)
        {


            Mat gray = new Mat("C:\\Users\\Павел\\source\\repos\\gears\\gears.png", ImreadModes.Grayscale);
            Mat B = new Mat();

            Mat B1 = new Mat();
            //byte[] kernelValues = MakeKernelValues(60); // cross (+)
            //for (int i = 0; i < 50 * 2; i++) {
                //for (int j = 0; j < 50 * 2; j++)
                {
                //    Console.Write(kernelValues[i * 50 * 2 + j]);
                }
            //Console.WriteLine(); }

            Mat ellipse1 = Cv2.GetStructuringElement(MorphShapes.Ellipse, new Size(100, 100));
            Mat kernel = Cv2.GetStructuringElement(MorphShapes.Ellipse, new Size(4, 4));
            //Mat ellipse2 = Cv2.GetStructuringElement(MorphShapes.Ellipse, new Size(40, 40));
            Mat ellipse2 = new Mat(); ;
            Mat holeRing = new Mat();
            Cv2.Erode(ellipse1, ellipse2, kernel);
            Cv2.Subtract(ellipse1, ellipse2, holeRing);

            //4 точки
            Cv2.Threshold(gray, B, 0, 255, ThresholdTypes.Otsu);
            Cv2.Erode(B, B1, holeRing);
            Cv2.ImShow("binary1", B);
            Cv2.ImShow("binary2", B1);


            //4 круга
            Mat B2 = new Mat();
            var holeMask = Cv2.GetStructuringElement(MorphShapes.Ellipse, new Size(84, 84));
            Cv2.Dilate(B1, B2, holeMask);
            Cv2.ImShow("binary3", B2);

            // складываю шестеренки 
            Mat B3 = new Mat();
            Cv2.BitwiseOr(B, B2, B3);
            Cv2.ImShow("binary4", B3);

            // размыкание кольца
            Mat gearBody = Cv2.GetStructuringElement(MorphShapes.Ellipse, new Size(40, 40));
            Mat samplingRingSpacer = Cv2.GetStructuringElement(MorphShapes.Ellipse, new Size(5, 5));
            Mat samplingRingWidth = Cv2.GetStructuringElement(MorphShapes.Ellipse, new Size(20, 20));
            Mat B4 = new Mat();
            Mat B5 = new Mat();
            Mat B6 = new Mat();
            Mat B7 = new Mat();
            Cv2.Erode(B3, B4, gearBody);
            Cv2.Dilate(B4, B3, gearBody);
            Cv2.Dilate(B3, B5, samplingRingSpacer);
            Cv2.Dilate(B5, B6, samplingRingWidth);
            Cv2.Subtract(B6, B5, B7);
            Cv2.ImShow("binary5", B7);


            // Отдельные шестеренки
            Mat B8 = new Mat();
            Cv2.BitwiseAnd(B, B7, B8);
            Cv2.ImShow("binary6", B8);

            // Отдельные шестеренки
            var tip_spacing = Cv2.GetStructuringElement(MorphShapes.Ellipse, new Size(20, 20));
            Mat B9 = new Mat();
            Cv2.Dilate(B8, B9, tip_spacing);
            Cv2.ImShow("binary7", B9);

            // Отдельные шестеренки
            var defect_cue = Cv2.GetStructuringElement(MorphShapes.Ellipse, new Size(30, 30));
            Mat B10 = new Mat();
            Mat B11 = new Mat();
            Mat result = new Mat();
            Cv2.Subtract(B7, B9, B10);
            Cv2.Dilate(B10, B11, defect_cue);
            Cv2.BitwiseOr(B11, B9, result);
            Cv2.ImShow("binary8", result);

            //Cv2.ImShow("binary", binary);
            //Cv2.ImShow("dilate (kernel = null)", dilate1);
            //Cv2.ImShow("dilate (kernel = +)", dilate2);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }



    }
}