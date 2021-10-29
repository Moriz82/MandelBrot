using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Threading;
using System.Windows.Forms.VisualStyles;

namespace Mandelbrot
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form = new Form1();

            PictureBox pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            form.Controls.Add(pictureBox);
            form.StartPosition = FormStartPosition.CenterScreen;
            Thread thread = new Thread(()=>form.StartSimulation(pictureBox ,form));
            thread.Priority = ThreadPriority.Highest;
            
            form.WindowState = FormWindowState.Maximized;
            form.FormBorderStyle = FormBorderStyle.None;
            pictureBox.Height = form.Height;
            pictureBox.Width = form.Width;

           pictureBox.MouseClick += form.OnClick;
           thread.Start();

           Application.Run(form);
        }
    }
}