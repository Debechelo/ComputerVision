using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace BinarizationQuantization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
		private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				Bitmap sourceFile = new Bitmap(openFileDialog1.FileName);
				pictureBox1.Image = sourceFile;
				pictureBox2.Image = sourceFile;
			}
		}

        static Color[] colors = new Color[] { Color.Black,  Color.DarkBlue, Color.Blue,
			Color.Green, Color.DarkRed, Color.Red, Color.Yellow, Color.White };

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

		private void button2_Click(object sender, EventArgs e)
		{
			int[] intensity = new int[256];
			Bitmap image = new Bitmap(pictureBox1.Image);
			for (int x = 0; x < image.Width; ++x)
				for (int y = 0; y < image.Height; ++y)
				{
					var t = image.GetPixel(x, y);
					double c = 0.2126 * t.R + 0.7152 * t.G + 0.0722 * t.B;
					++intensity[(int)c];	
				}
			pictureBox2.Image = GlobalOtsu((image), intensity);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			pictureBox2.Image = LocalOtsu(new Bitmap(pictureBox1.Image));
		}

		private void button4_Click(object sender, EventArgs e)
		{
			int[] intensity = new int[256];
			Bitmap image = new Bitmap(pictureBox1.Image);
			for (int x = 0; x < image.Width; ++x)
				for (int y = 0; y < image.Height; ++y)
				{
					var t = image.GetPixel(x, y);
					double c = 0.2126 * t.R + 0.7152 * t.G + 0.0722 * t.B;
					++intensity[(int)c];
				}
			pictureBox2.Image = IerarhOtsu(new Bitmap(pictureBox1.Image), intensity, (int)numericUpDown1.Value);
		}

		private double[] ConvertBrightness(Bitmap bing)
        {
            double[] brightness = new double[1000];
            for (int i = 0; i < bing.Width; ++i)
            {
                for (int j = 0; j < bing.Height; ++j)
                {
                    var brigh = bing.GetPixel(i, j).GetBrightness();
                    brightness[Math.Min((int)(brigh*1000),999)]++;
                }
            }
            return brightness;
        }
		static int MethodOtsu(int cntPix, int[] intensity)
		{
			double[] disp = new double[intensity.Length];
			double[] intensityD = new double[intensity.Length];
			for (int i = 0; i < intensity.Length; ++i)
				intensityD[i] = 1.0 * intensity[i] / cntPix;

			double q = intensityD[0];
			double m1 = 0, m2 = 0;
			double nt = 0, mt = 0;
			for (int i = 0; i < intensity.Length; ++i)
			{
				nt += intensityD[i];
				mt += intensityD[i] * i;
			}
			mt /= nt;

			for (int i = 1; i < intensity.Length; ++i)
			{
				m1 = q * m1 + i * intensityD[i];
				q += intensityD[i];
				if (q == 0 || q == 1) continue;
				m1 /= q;
				m2 = (mt - q * m1) / (1 - q);
				disp[i] = Math.Sqrt(q * (1 - q) * (m1 - m2) * (m1 - m2));
			}

			var lst = disp.ToList();
			var t = lst.FindIndex(x => x == lst.Max());
			Console.WriteLine("Otsu T: " + t);
			return t;
		}

		

		public static Bitmap GlobalOtsu(Bitmap src, int[] intensity)
		{
			Bitmap dest = new Bitmap(src.Width, src.Height);
			Color b = Color.Black, w = Color.White;

			var maxT = MethodOtsu(src.Width * src.Height, intensity);
			Console.WriteLine();
			for (int x = 0; x < dest.Width; ++x)
				for (int y = 0; y < dest.Height; ++y)
				{
					var t = src.GetPixel(x, y);
					if (t.R < maxT)
						dest.SetPixel(x, y, b);
					else
						dest.SetPixel(x, y, w);
				}
			return dest;
		}

		public static Bitmap LocalOtsu(Bitmap src)
		{
			Bitmap dest = new Bitmap(src.Width, src.Height);
			Color b = Color.Black, w = Color.White;

			int[] inten1 = new int[256], inten2 = new int[256];
			for (int x = 0; x < dest.Width; ++x)
			{
				for (int y = 0; y < dest.Height / 3; ++y)
					++inten1[src.GetPixel(x, y).R];
				for (int y = dest.Height / 3; y < dest.Height; ++y)
					++inten2[src.GetPixel(x, y).R];
			}

			var maxT1 = MethodOtsu(src.Width * src.Height, inten1);
			var maxT2 = MethodOtsu(src.Width * src.Height, inten2);

			Console.WriteLine();

			for (int x = 0; x < dest.Width; ++x)
			{
				for (int y = 0; y < dest.Height / 2; ++y)
				{
					var t = src.GetPixel(x, y);
					if (t.R < maxT1)
						dest.SetPixel(x, y, b);
					else
						dest.SetPixel(x, y, w);
				}
				for (int y = dest.Height / 2; y < dest.Height; ++y)
				{
					var t = src.GetPixel(x, y);
					if (t.R < maxT2)
						dest.SetPixel(x, y, b);
					else
						dest.SetPixel(x, y, w);
				}
			}
			return dest;
		}

		public static Bitmap IerarhOtsu(Bitmap src, int[] intensity, int recCount)
		{
			Bitmap dest = new Bitmap(src.Width, src.Height);
			Color b = Color.Black, w = Color.White;

			List<int> listT = new List<int>();

			var cntPix = src.Width * src.Height;
			double[] intensityD = new double[256];
			for (int i = 0; i < intensity.Length; ++i)
				intensityD[i] = 1.0 * intensity[i] / cntPix;

			RecMethodOtsu(intensityD, listT, recCount);
			listT = listT.OrderBy(x => x).ToList();

			for (int x = 0; x < dest.Width; ++x)
				for (int y = 0; y < dest.Height; ++y)
				{
					var t = src.GetPixel(x, y);

					var first = listT.FindIndex(c => c > t.R);

					if (first  != -1)
						dest.SetPixel(x, y, colors[first]);
					else
						dest.SetPixel(x, y, colors[listT.Capacity]);
				}
			return dest;
		}

		static void RecMethodOtsu(double[] intensity, List<int> listT, int cntRec)
		{
			if (cntRec == 0 || intensity.Length < 3) return;
			double[] disp = new double[intensity.Length];


			double q = intensity[0];
			double m1 = 0, m2 = 0;
			double nt = 0, mt = 0;
			for (int i = 0; i < intensity.Length; ++i)
			{
				nt += intensity[i];
				mt += intensity[i] * i;
			}
			mt /= nt;

			for (int i = 1; i < intensity.Length; ++i)
			{
				m1 = q * m1 + i * intensity[i];
				q += intensity[i];
				if (q == 0 || q == 1) continue;
				m1 /= q;
				m2 = (mt - q * m1) / (1 - q);
				disp[i] = Math.Sqrt(q * (1 - q) * (m1 - m2) * (m1 - m2));
			}

			var lst = disp.ToList();
			var t = lst.FindIndex(x => x == lst.Max());
			listT.Add(t);

			double[] tempInten = new double[t];
			for (int i = 0; i < t; ++i)
				tempInten[i] = intensity[i];

			RecMethodOtsu(tempInten, listT, cntRec - 1);

			double[] tempInten1 = new double[intensity.Length - t + 1];
			for (int i = t; i < intensity.Length; ++i)
				tempInten1[i - t] = intensity[i];
			RecMethodOtsu(tempInten1, listT, cntRec - 1);
		}
	}
}
