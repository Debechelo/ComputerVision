namespace RGBgistogram
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.Red = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.Green = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.Blue = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Red)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Green)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Blue)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(22, 41);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(221, 181);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// Red
			// 
			this.Red.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Top;
			chartArea1.Name = "ChartArea1";
			this.Red.ChartAreas.Add(chartArea1);
			this.Red.Cursor = System.Windows.Forms.Cursors.Default;
			legend1.Name = "Legend1";
			this.Red.Legends.Add(legend1);
			this.Red.Location = new System.Drawing.Point(325, 12);
			this.Red.Name = "Red";
			this.Red.RightToLeft = System.Windows.Forms.RightToLeft.No;
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.MarkerColor = System.Drawing.Color.Red;
			series1.Name = "Red";
			this.Red.Series.Add(series1);
			this.Red.Size = new System.Drawing.Size(463, 130);
			this.Red.TabIndex = 1;
			this.Red.Text = "Red";
			// 
			// Green
			// 
			chartArea2.Name = "ChartArea1";
			this.Green.ChartAreas.Add(chartArea2);
			legend2.Name = "Legend1";
			this.Green.Legends.Add(legend2);
			this.Green.Location = new System.Drawing.Point(325, 178);
			this.Green.Name = "Green";
			series2.ChartArea = "ChartArea1";
			series2.Legend = "Legend1";
			series2.Name = "Green";
			this.Green.Series.Add(series2);
			this.Green.Size = new System.Drawing.Size(463, 130);
			this.Green.TabIndex = 2;
			this.Green.Text = "chart2";
			// 
			// Blue
			// 
			chartArea3.Name = "ChartArea1";
			this.Blue.ChartAreas.Add(chartArea3);
			this.Blue.Cursor = System.Windows.Forms.Cursors.Default;
			legend3.Name = "Legend1";
			this.Blue.Legends.Add(legend3);
			this.Blue.Location = new System.Drawing.Point(325, 348);
			this.Blue.Name = "Blue";
			series3.ChartArea = "ChartArea1";
			series3.Legend = "Legend1";
			series3.Name = "Blue";
			this.Blue.Series.Add(series3);
			this.Blue.Size = new System.Drawing.Size(463, 130);
			this.Blue.TabIndex = 3;
			this.Blue.Text = "chart3";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 559);
			this.Controls.Add(this.Blue);
			this.Controls.Add(this.Green);
			this.Controls.Add(this.Red);
			this.Controls.Add(this.pictureBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Red)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Green)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Blue)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.DataVisualization.Charting.Chart Red;
		private System.Windows.Forms.DataVisualization.Charting.Chart Green;
		private System.Windows.Forms.DataVisualization.Charting.Chart Blue;
	}
}

