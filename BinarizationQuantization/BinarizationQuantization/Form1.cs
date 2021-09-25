using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinarizationQuantization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Квантование по яркости")
            {
                pictureBox1.BringToFront();
                pictureBox2.BringToFront();
            }
            //else
            //{
            //    if (comboBox1.Text == "Бинаризация методом Оцу глобальная")
            //    {
            //        pictureBox3.BringToFront();
            //        pictureBox8.BringToFront();
            //    }
            //    else
            //    {
            //        if (comboBox1.Text == "Бинаризация методом Оцу локальная")
            //        {
            //            pictureBox4.BringToFront();
            //            pictureBox9.BringToFront();
            //        }
            //        else
            //        {
            //            if (comboBox1.Text == "Бинаризация методом Оцу иерархическая")
            //            {
            //                pictureBox5.BringToFront();
            //                pictureBox6.BringToFront();
            //                chart1.BringToFront();
            //                chart2.BringToFront();
            //            }
            //        }
            //    }
            //}
        }

        static Color[] colors = new Color[] { Color.Black, Color.Blue, Color.Green,
            Color.Red, Color.Yellow, Color.DarkRed, Color.DarkBlue, Color.White };

        private void button1_Click(object sender, EventArgs e)
        {
            int indexMin = 0;
            int indexMax = 999;
            var image = new Bitmap(pictureBox1.Image);
            var gray = ConvertBrightness(image);
            while (gray[indexMax] == 0) indexMax--;
            while (gray[indexMin] == 0) indexMin++;
            Bitmap image2 = new Bitmap(image.Width, image.Height);
            var layers = (int)numericUpDown1.Value;
            int part = (indexMax - indexMin) / layers;
            for (int i = 0; i < image.Width; ++i)
                for (int j = 0; j < image2.Height; ++j) {
                    var color = image.GetPixel(i, j);
                    int brigh = (int)(color.GetBrightness() * 1000);
                    int k=0;
                    for (int g = 1; g <= layers; ++g){
                        if ((brigh - indexMin - part * g) < 0) { k = g-1; break; }
                    }
                        image2.SetPixel(i, j, colors[k]);
                }
            pictureBox2.Image = (Image)image2;
        }
        private double[] ConvertBrightness(Bitmap bing)
        {
            double[] brightness = new double[1000];
            for (int i = 0; i < bing.Width; ++i)
            {
                for (int j = 0; j < bing.Height; ++j)
                {
                    var brigh = bing.GetPixel(i, j).GetBrightness();
                    brightness[(int)(brigh*1000)]++;
                }
            }
            return brightness;
        }
    }
}
