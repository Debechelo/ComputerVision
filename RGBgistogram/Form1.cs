using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGBgistogram
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			int[] R = new int[256];
			int[] G = new int[256];
			int[] B = new int[256];
			if (pictureBox1.Image != null) {
				Bitmap image = new Bitmap(pictureBox1.Image);
				Color color;
				for (int i = 0; i < image.Width; ++i) {
					for (int j = 0; j < image.Height; ++j){
						color = image.GetPixel(i, j);
						++R[color.R];
						++G[color.G];
						++B[color.B];
						
					}
				}
				for (int i = 0; i < 256; ++i)
				{
					this.Red.Series["Red"].Points.AddXY(i, R[i]);
					this.Green.Series["Green"].Points.AddXY(i, G[i]);
					this.Blue.Series["Blue"].Points.AddXY(i, B[i]);

				}
				this.Red.Series["Red"].Color = Color.Red;
				this.Green.Series["Green"].Color = Color.Green;
				this.Blue.Series["Blue"].Color = Color.Blue;

			}
		}









	}
}
