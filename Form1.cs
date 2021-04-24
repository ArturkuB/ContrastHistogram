using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContrastHistogram
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        int width;
        int height;
        int[] histr = new int[256];
        int[] histg = new int[256];
        int[] histb = new int[256];
        bool readed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                bitmap = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = bitmap;
                pictureBox2.Image = bitmap;

                width = pictureBox1.Image.Width;
                height = pictureBox1.Image.Height;
                Array.Clear(histr, 0, histr.Length);
                Array.Clear(histg, 0, histg.Length);
                Array.Clear(histb, 0, histb.Length);
                histogram();
                readed = true;
                panel1.Invalidate();
                panel2.Invalidate();
                panel3.Invalidate();

            }
        }
        private void histogram()
        {
            int i = 0, j = 0, k = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color p = bitmap.GetPixel(x, y);

                    int r = p.R;
                    int g = p.G;
                    int b = p.B;
                    histr[r]++;
                    histg[g]++;
                    histb[b]++;
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if(readed == true)
            {
                int x = 0;
                Graphics g = e.Graphics;
                for (int i = 0; i < 256; i++)
                {
                    double r = histr[i];
                    r = r / (bitmap.Width * bitmap.Height);
                    r = r * 5000;
                    g.DrawLine(new Pen(Color.Red), x, panel1.Height, x, panel1.Height - (int)r);
                        x++;
                }

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (readed == true)
            {
                int x = 0;
                Graphics g = e.Graphics;
                for (int i = 0; i < 256; i++)
                {
                    double g1 = histg[i];
                    g1 = g1 / (bitmap.Width * bitmap.Height);
                    g1 = g1 * 5000;
                    g.DrawLine(new Pen(Color.Green), x, panel2.Height, x, panel2.Height - (int)g1);
                    x++;
                }

            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            if (readed == true)
            { 
                int x = 0;
                Graphics g = e.Graphics;
                for (int i = 0; i < 256; i++)
                {
                    double b = histb[i];
                    b = b / (bitmap.Width * bitmap.Height);
                    b = b * 5000;
                    g.DrawLine(new Pen(Color.Blue), x, panel3.Height, x, panel3.Height - (int)b);
                    x++;
                }

            }
        }
        //zwiększanie kontrastu
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Bitmap bitmap2;
            try
            {
                bitmap2 = (Bitmap)bitmap.Clone();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {

                        Color p = bitmap2.GetPixel(x, y);

                        int r = p.R;
                        int g = p.G;
                        int b = p.B;


                        r = (127 / (127 - trackBar1.Value)) * (r - trackBar1.Value);
                        g = (127 / (127 - trackBar1.Value)) * (g - trackBar1.Value);
                        b = (127 / (127 - trackBar1.Value)) * (b - trackBar1.Value);

                        if (r < 0)
                        {
                            r = 0;
                        }
                        if (g < 0)
                        {
                            g = 0;
                        }
                        if (b < 0)
                        {
                            b = 0;
                        }
                        if (r > 255)
                        {
                            r = 255;
                        }
                        if (g > 255)
                        {
                            g = 255;
                        }
                        if (b > 255)
                        {
                            b = 255;
                        }

                        bitmap2.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }

                pictureBox2.Image = bitmap2;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Image not loaded!");
            }
        }
        //zmniejszanie kontrastu
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Bitmap bitmap3;
            try
            {
                bitmap3 = (Bitmap)bitmap.Clone();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {

                        Color p = bitmap3.GetPixel(x, y);

                        double r = (double)p.R;
                        double g = (double)p.G;
                        double b = (double)p.B;

                        double r1, g1, b1;
                        r1 = (127 + trackBar2.Value) * r;
                        r1 = r1 / 127;

                        r1 = r1 - trackBar2.Value;

                        g1 = (127 + trackBar2.Value) * g;
                        g1 = g1 / 127;

                        g1 = g1 - trackBar2.Value;

                        b1 = (127 + trackBar2.Value) * b;
                        b1 = b1 / 127;

                        b1 = b1 - trackBar2.Value;



                        bitmap3.SetPixel(x, y, Color.FromArgb((int)r1, (int)g1, (int)b1));
                    }
                }

                pictureBox2.Image = bitmap3;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Image not loaded!");
            }
        }
        //wariant dwa A)
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            Bitmap bitmap3;
            try
            {
                bitmap3 = (Bitmap)bitmap.Clone();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {

                        Color p = bitmap3.GetPixel(x, y);

                        double r = (double)p.R;
                        double g = (double)p.G;
                        double b = (double)p.B;

                       double r1 = 0, g1 = 0, b1 = 0;
                       if(r < 127)
                        {
                            r1 = (127 - trackBar3.Value) * r;
                            r1 = r1 / 127;
                        }
                       else if(r >= 127)
                        {
                            r1 = (127 - trackBar3.Value) * r;
                            r1 = r1 / 127;
                            r1 = r1 + (2 * trackBar3.Value);
                        }

                        if (g < 127)
                        {
                            g1 = (127 - trackBar3.Value) * g;
                            g1 = g1 / 127;
                        }
                        else if (g >= 127)
                        {
                            g1 = (127 - trackBar3.Value) * g;
                            g1 = g1 / 127;
                            g1 = g1 + (2 * trackBar3.Value);
                        }

                        if (b < 127)
                        {
                            b1 = (127 - trackBar3.Value) * b;
                            b1 = b1 / 127;
                        }
                        else if (b >= 127)
                        {
                            b1 = (127 - trackBar3.Value) * r;
                            b1 = b1 / 127;
                            b1 = b1 + (2 * trackBar3.Value);
                        }



                        bitmap3.SetPixel(x, y, Color.FromArgb((int)r1, (int)g1, (int)b1));
                    }
                }

                pictureBox2.Image = bitmap3;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Image not loaded!");
            }
        }



        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            Bitmap bitmap3;

                bitmap3 = (Bitmap)bitmap.Clone();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {

                    Color p = bitmap3.GetPixel(x, y);

                    double r = (double)p.R;
                    double g = (double)p.G;
                    double b = (double)p.B;

                    double r1, g1, b1;
                    if( r < 127 + trackBar4.Value)
                    {
                        r1 = (127 / (127 + trackBar4.Value)) * r;
                    }
                    else if(r > 127 - trackBar4.Value)
                    {
                        r1 = ((127 * r) + (255 * trackBar4.Value)) / (127 + trackBar4.Value);
                    }
                    else
                    {
                        r1 = 127;
                    }

                    if (g < 127 + trackBar4.Value)
                    {
                        g1 = (127 / (127 + trackBar4.Value)) * g;
                    }
                    else if (g > 127 - trackBar4.Value)
                    {
                        g1 = ((127 * g) + (255 * trackBar4.Value)) / (127 + trackBar4.Value);
                    }
                    else
                    {
                        g1 = 127;
                    }

                    if (b < 127 + trackBar4.Value)
                    {
                        b1 = (127 / (127 + trackBar4.Value)) * b;
                    }
                    else if (b > 127 - trackBar4.Value)
                    {
                        b1 = ((127 * b) + (255 * trackBar4.Value)) / (127 + trackBar4.Value);
                    }
                    else
                    {
                        b1 = 127;
                    }

                    bitmap3.SetPixel(x, y, Color.FromArgb((int)r1, (int)g1, (int)b1));
                    }
                }

                pictureBox2.Image = bitmap3;
            }
        }
    }

