using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reference_color
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        int red_dst;
        int green_dst;
        int blue_dst;

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            using (var image = new Bitmap(pictureBox1.Image))
            {

                base.OnMouseClick(e);
                var color = image.GetPixel(e.X, e.Y);
                int red_src = color.R;
                int green_src = color.G;
                int blue_src = color.B;
                Bitmap image2 = new Bitmap(image.Width, image.Height);
                for (int i = 0; i < image2.Width; ++i)
                    for (int j = 0; j < image2.Height; ++j)
                    {
                        color = image.GetPixel(i, j);
                        image2.SetPixel(i, j,
                            Color.FromArgb((int)(Math.Min(color.R * red_dst / Math.Max(red_src, 0.01), 255)),
                            (int)(Math.Min(color.G * green_dst / Math.Max(green_src, 0.01), 255)),
                            (int)(Math.Min(color.B * blue_dst / Math.Max(blue_src, 0.01), 255))));
                    }
                pictureBox1.Image = (Image)image2;
            }
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {

            using (var image = new Bitmap(pictureBox2.Image))
            {
                base.OnMouseClick(e);
                var color = image.GetPixel(e.X, e.Y);
                red_dst = color.R;
                green_dst = color.G;
                blue_dst = color.B;

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Опорный цвет")
            { pictureBox1.BringToFront();
                pictureBox2.BringToFront();
            }
            else
            {
                if (comboBox1.Text == "Серый мир")
                { pictureBox3.BringToFront();
                    pictureBox8.BringToFront();
                }
                else
                {
                    if (comboBox1.Text == "Функции")
                    { pictureBox4.BringToFront();
                        pictureBox9.BringToFront();
                    }
                    else
                    {
                        if (comboBox1.Text == "Нормализация")
                        {
                            pictureBox5.BringToFront();
                            pictureBox6.BringToFront();
                            chart1.BringToFront();
                            chart2.BringToFront();
                        }
                        else
                        {
                            if (comboBox1.Text == "Эквализация")
                            {
                                pictureBox6.BringToFront();
                                pictureBox7.BringToFront();
                                chart4.BringToFront();
                                chart3.BringToFront();
                            }
                        }
                    }
                } 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] R = new int[256];
            int[] G = new int[256];
            int[] B = new int[256];
            double RAvr = 0;
            double GAvr = 0;
            double BAvr = 0;
            if (pictureBox3.Image != null)
            {
                Bitmap image = new Bitmap(pictureBox3.Image);
                Color color;
                for (int i = 0; i < image.Width; ++i)
                    for (int j = 0; j < image.Height; ++j)
                    {
                        color = image.GetPixel(i, j);
                        RAvr += color.R;
                        GAvr += color.G;
                        BAvr += color.B;
                    }
                int N = image.Width * image.Height;
                RAvr /= N;
                GAvr /= N;
                BAvr /= N;
                double avr;
                avr = (RAvr + GAvr + BAvr) / 3;
                if (pictureBox3.Image != null)
                {
                    Bitmap image2 = new Bitmap(image.Width, image.Height);
                    for (int i = 0; i < image2.Width; ++i)
                        for (int j = 0; j < image2.Height; ++j)
                        {
                            color = image.GetPixel(i, j);
                            image2.SetPixel(i, j, Color.FromArgb((int)(Math.Min(color.R * avr / Math.Max(RAvr, 0.01), 255)),
                                (int)(Math.Min(color.G * avr / Math.Max(GAvr, 0.01), 255)),
                                (int)(Math.Min(color.B * avr / Math.Max(BAvr, 0.01), 255))));
                        }
                    pictureBox3.Image = (Image)image2;

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double R;
            double G;
            double B;
            using (var image = new Bitmap(pictureBox4.Image))
            {
                Color color;
                Bitmap image2 = new Bitmap(image.Width, image.Height);
                for (int i = 0; i < image2.Width; ++i)
                    for (int j = 0; j < image2.Height; ++j)
                    {
                        color = image.GetPixel(i, j);
                        R = color.R;
                        B = color.B;
                        G = color.G;
                        image2.SetPixel(i, j,
                            Color.FromArgb((int)(Math.Min(Math.Pow(R, 1.1), 255)),
                            (int)(Math.Min(Math.Pow(G, 1.1), 255)),
                            (int)(Math.Min(Math.Pow(B, 1.1), 255))));
                    }
                pictureBox4.Image = (Image)image2;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double R;
            double G;
            double B;
            using (var image = new Bitmap(pictureBox4.Image))
            {
                Color color;
                Bitmap image2 = new Bitmap(image.Width, image.Height);
                for (int i = 0; i < image2.Width; ++i)
                    for (int j = 0; j < image2.Height; ++j)
                    {
                        color = image.GetPixel(i, j);
                        R = color.R;
                        B = color.B;
                        G = color.G;
                        image2.SetPixel(i, j,
                            Color.FromArgb((int)(Math.Min(Math.Pow(R, 0.9), 255)),
                            (int)(Math.Min(Math.Pow(G, 0.9), 255)),
                            (int)(Math.Min(Math.Pow(B, 0.9), 255))));
                    }
                pictureBox4.Image = (Image)image2;
            }
        }
        private double[] ConvertGraysale(Bitmap bing)
        {
            double [] gray = new double[256];
            for (int i = 0; i < bing.Width; ++i) {
                for (int j = 0; j < bing.Height; ++j)
                {
                    var color = bing.GetPixel(i, j);
                    gray[color.R]++;
                    gray[color.B]++;
                    gray[color.G]++;
                } 
            }
            return gray;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int indexMin = 0;
            int indexMax = 249;
            var image = new Bitmap(pictureBox6.Image);
            var gray = ConvertGraysale(image);
            while (gray[indexMax] == 0) indexMax--;
            while (gray[indexMin] == 0) indexMin++;
            Bitmap image2 = new Bitmap(image.Width, image.Height);
            for (int i = 0; i < image2.Width; ++i)
                for (int j = 0; j < image2.Height; ++j)
                {
                    var color = image.GetPixel(i, j);
                    var RGB = color.R - indexMin;
                    image2.SetPixel(i, j,
                        Color.FromArgb(RGB, RGB, RGB));
                }
            indexMax -= indexMin;
            for (int i = 0; i < image.Width; ++i)
                for (int j = 0; j < image2.Height; ++j)
                {
                    var color = image2.GetPixel(i, j);
                    var RGB = (int)(color.R * (255.0 / indexMax));
                    image2.SetPixel(i, j,
                        Color.FromArgb(RGB, RGB, RGB));
                }
            pictureBox5.Image = (Image)image2;
            for (int i = 0; i < 256; ++i)
                chart1.Series[0].Points.AddXY(i, gray[i]);

            var gray2 = ConvertGraysale(image2);
            for (int i = 0; i < 256; ++i)
                chart2.Series[0].Points.AddXY(i, gray2[i]);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var image = new Bitmap(pictureBox7.Image);
            var bins = ConvertGraysale(image);
            for (int i = 0; i < 256; ++i)
                chart4.Series[0].Points.AddXY(i, bins[i]);
            for (int i = 0; i < 256; ++i)
                bins[i] /= (image.Width * image.Height);
            for (int i = 1; i < 256; ++i)
                bins[i] += bins[i - 1];
            double max = 0;
            for (int i = 0; i < 256; ++i)
                if (max < bins[i]) max = bins[i];

            for (int i = 0; i < 256; ++i)
                bins[i] /= max;
             
            Bitmap image2 = new Bitmap(image.Width, image.Height);
            for (int i = 0; i < image2.Width; ++i)
                for (int j = 0; j < image2.Height; ++j)
                {
                    var color = image.GetPixel(i, j);
                    var R = (int)(bins[color.R]*255);
                    var G = (int)(bins[color.G]*255);
                    var B = (int)(bins[color.B]*255);
                    image2.SetPixel(i, j,
                        Color.FromArgb(R, G, B));
                }
            pictureBox7.Image = (Image)image2;
            var bins2 = ConvertGraysale(image2);
            for (int i = 0; i < 256; ++i)
                chart3.Series[0].Points.AddXY(i, bins2[i]);
        }

        private void chart4_Click(object sender, EventArgs e)
        {

        }
    }
}
