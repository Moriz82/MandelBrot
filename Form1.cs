using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Mandelbrot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private PictureBox pb = new PictureBox();
        private Form1 f;
        double sh =  ((Screen.PrimaryScreen.Bounds.Height*2)+200);
        double sw = Screen.PrimaryScreen.Bounds.Width*2;
        double w = 5;
        double h = (5+1) * ((double)(Screen.PrimaryScreen.Bounds.Height*2)+200) / (Screen.PrimaryScreen.Bounds.Width*2);
        private int mI = 0;
        double rS = -2.5;
        double iS = -1.5;

        public void StartSimulation(PictureBox pictureBox, Form1 form)
		{
			double width = 5;
			double height = (width+1) * ((form.Height*2)+200) / (pictureBox.Width*2);
			double rStart = -2.5;
			double iStart = -1.5;
			int maxIterations = 100;

			pb = pictureBox;
			f = form;
			w = width;
			h = height;
			mI = maxIterations;
			RunMandelbrot( pb, f, iStart, rStart, w, h, mI);
		}
        public void OnClick(object sender, MouseEventArgs e)
		{
			int zoom = 4;
			
			double wFactor = w * (double)3 / zoom;
			double hFactor = h * (double)3 / zoom;
			w -= wFactor;
			h -= hFactor;
			rS += (wFactor / 1.55);
			iS += (hFactor / 2.4);
			RunMandelbrot( pb, f, iS, rS, w, h, mI);
		}
        static void RunMandelbrot(PictureBox pictureBox, Form1 form, double iStart, double rStart, double width, double height, int maxIterations)
        {
	        Bitmap map = new Bitmap((int)form.Width*2, (int)(form.Height*2)+200);

	        for (int x = 0; x != map.Width; x++)
			{
				for (int y = 0; y != map.Height; y++)
				{
					map.SetPixel(x, y, GetColor(Mandelbrot((rStart + width * (double)x / map.Width), (iStart + height * (double)y / map.Height), maxIterations), maxIterations));
				}
			}
	        pictureBox.Image = map;
        }
        static int Mandelbrot(double x, double y, int maxIterations)
		{
			int iteration = 0;

			Complex z = new Complex(0, 0);

			for (int i = 0; i != maxIterations; i++)
			{
				z = z * z + new Complex(x, y);

				if (Complex.Abs(z) > 2)
				{
					return i;
				}
				else
				{
					iteration++;
				}
			}

			return iteration;
		}
		static Color GetColor(int value, int maxIterations)
		{
			Color CalcColor = Color.FromArgb(255, 0, 0, 0);

			if (value != maxIterations)
			{
				int colorNum = value % 16;

				switch (colorNum)
				{
					case 0:
					{
						CalcColor = Color.FromArgb(255,26 , 26 , 26 );
						break;
						}
					case 1:
						{
							CalcColor = Color.FromArgb(255,36 , 36 , 36 );
							break;
						}
					case 2:
						{
							CalcColor = Color.FromArgb(255,9 , 1 , 47 );
							break;
						}

					case 3:
						{
							CalcColor = Color.FromArgb(255,4 , 4 , 73 );
							break;
						}
					case 4:
						{
							CalcColor = Color.FromArgb(255,0 , 7 , 100 );
							break;
						}
					case 5:
						{
							CalcColor = Color.FromArgb(255,12 , 44 , 138 );
							break;
						}
					case 6:
						{
							CalcColor = Color.FromArgb(255,24 , 82 , 77 );
							break;
						}
					case 7:
						{
							CalcColor = Color.FromArgb(255,57 , 125 , 209 );
							break;
						}
					case 8:
						{
							CalcColor = Color.FromArgb(255,134 , 181 , 229 );
							break;
						}
					case 9:
						{
							CalcColor = Color.FromArgb(255,211 , 236 , 248 );
							break;
						}
					case 10:
						{
							CalcColor = Color.FromArgb(255,241 , 233 ,191 );
							break;
						}
					case 11:
						{
							CalcColor = Color.FromArgb(255,248 , 201 , 95 );
							break;
						}
					case 12:
						{
							CalcColor = Color.FromArgb(255,255, 170 , 0 );
							break;
						}
					case 13:
						{
							CalcColor = Color.FromArgb(255,204 , 128 , 0 );
							break;
						}
					case 14:
						{
							CalcColor = Color.FromArgb(255,153 , 87 , 0 );
							break;
						}
					case 15:
						{
							CalcColor = Color.FromArgb(255,136 , 52 , 3 );
							break;
						}
				}
			}
			return CalcColor;
		}
    }
}