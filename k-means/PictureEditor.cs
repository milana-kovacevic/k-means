using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace k_means
{
    public partial class PictureEditor : Form
    {
        public PictureEditor()
        {
            InitializeComponent();
            pictureBoxBeginWidth = pictureBox.Width;
            pictureBoxBeginHeight = pictureBox.Height;
            formBeginHeight = this.Height;
        }

        Bitmap picture;
        int width, height;
        bool imageSelected = false;
        Pixel[,] pixels;
        int pictureBoxBeginWidth;
        int pictureBoxBeginHeight;
        int formBeginHeight;
        volatile bool firstThreadFinished = false;
        volatile bool secondThreadFinished = false;
        ColorGenerator[] possible;
        Pixel[,] currentPixels;
        int k;


        private void editPicture(object sender, EventArgs e)
        {
            if (!imageSelected)
            {
                MessageBox.Show("First choose the picture!");
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            Color c;
            pixels = new Pixel[width, height];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    c = picture.GetPixel(i, j);
                    pixels[i, j] = new Pixel(c.R, c.G, c.B);
                }
            //twoMeans();
            k = kChooser.Value;
            kmeans(kChooser.Value, PrecisionSlider.Value);
            //pixelsToPicture(pixels);
            //pictureBox.Refresh(); // which is faster?
            pictureBox.Image = picture;
            this.Cursor = Cursors.Arrow;
        }
        
        private void kmeans(int k, int precision)
        {
            progressBar.Visible = true;
            progressBar.Value = 1;
            possible = new ColorGenerator[k];
            Random rnd = new Random();
            int i;
            // randomizing k starting colors
            for (i = 0; i < k; i++)
                possible[i] = new ColorGenerator(new Pixel((byte)rnd.Next(), (byte)rnd.Next(), (byte)rnd.Next()));
            currentPixels = new Pixel[width, height];
            int step = 100 / precision - 1;
            for (int h = 0; h < precision; h++)
            {
                progressBar.Value += step;
                for (i = 0; i < k; i++)
                    possible[i].resetCounter();
                
                /* creating threads to optimize the execution time FIXME - it's not much of a progress */
                Thread firstThread = new Thread(new ThreadStart(firstStartingMethod));
                firstThreadFinished = false;
                firstThread.Start();
                Thread secondThread = new Thread(new ThreadStart(secondStartingMethod));
                secondThreadFinished = false;
                secondThread.Start();
                // a loop that will end when both threads are finished
                while(!firstThreadFinished && !secondThreadFinished);
                
                /* this part is now done in threads
                for (i = 0; i < width; i++)
                {
                    for (j = 0; j < height; j++)
                    {
                        int closest = indexOfClosestColor(pixels[i, j], possible, k);
                        currentPixels[i, j] = possible[closest].getPixel();
                        possible[closest].addPixel(pixels[i, j]);
                    }
                }
                */

                //setting new possible colors as an average
                for (i = 0; i < k; i++)
                {
                    possible[i].setPixel(possible[i].getNewPixel());
                    possible[i].resetCounter();
                }
                pixelsToPicture(currentPixels);
                pictureBox.Refresh();
            }
            /*
            // applying new colors
            for (i = 0; i < width; i++)
                for (j = 0; j < height; j++)
                {
                    int closest = indexOfClosestColor(pixels[i, j], possible, k);
                    //pixels[i, j] = Color.Yellow;
                    pixels[i,j] = possible[closest].getPixel();
                }
            */

            progressBar.Visible = false;
        }

        private void firstStartingMethod()
        {
            Console.WriteLine("First thread starting...");
            int i, j;
            for (i = 0; i < width; i += 2)
            {
                for (j = 0; j < height; j++)
                {
                    int closest = indexOfClosestColor(pixels[i, j], possible, k);
                    currentPixels[i, j] = possible[closest].getPixel();
                    possible[closest].addPixel(pixels[i, j]);
                }
            }
            firstThreadFinished = true;
            //Console.WriteLine("First thread finished!");
        }
        private void secondStartingMethod()
        {
            Console.WriteLine("Second thread starting...");
            int i, j;
            for (i = 1; i < width; i += 2)
            {
                for (j = 0; j < height; j++)
                {
                    int closest = indexOfClosestColor(pixels[i, j], possible, k);
                    currentPixels[i, j] = possible[closest].getPixel();
                    possible[closest].addPixel(pixels[i, j]);
                }
            }
            secondThreadFinished = true;
            //Console.WriteLine("Second thread finished!");
        }
        private int indexOfClosestColor(Pixel x, ColorGenerator[] possible, int k)
        {
            int min = x.distanceSqr(possible[0].getPixel());
            int minIndex = 0;
            int maybe;
            for (int i = 1; i < k; i++)
            {
                maybe = x.distanceSqr(possible[i].getPixel());
                if (maybe < min)
                {
                    min = maybe;
                    minIndex = i;
                }
            }
            return minIndex;
        }

        private void twoMeans()
        {
            Random rnd = new Random();
            Pixel a = new Pixel((byte)rnd.Next(), (byte)rnd.Next(), (byte)rnd.Next());
            Pixel b = new Pixel((byte)rnd.Next(), (byte)rnd.Next(), (byte)rnd.Next());
            int i, j;
            for (int k = 0; k < 10; k++)
            {
                int first = 0, second = 0;
                long r1 = 0, g1 = 0, b1 = 0;
                long r2 = 0, g2 = 0, b2 = 0;
                for (i = 0; i < width; i++)
                {
                    for (j = 0; j < height; j++)
                    {
                        if (pixels[i, j].distanceSqr(a) < pixels[i, j].distanceSqr(b))
                        {
                            first++;
                            r1 += pixels[i, j].getR();
                            g1 += pixels[i, j].getG();
                            b1 += pixels[i, j].getB();
                        }
                        else
                        {
                            second++;
                            r2 += pixels[i, j].getR();
                            g2 += pixels[i, j].getG();
                            b2 += pixels[i, j].getB();
                        }
                    }
                }
                if (first != 0)
                    a = new Pixel((byte)(r1 / first), (byte)(g1 / first), (byte)(b1 / first));
                if (second != 0)
                    b = new Pixel((byte)(r2 / first), (byte)(g2 / first), (byte)(b2 / first));
            }

            for (i = 0; i < width; i++)
            {
                for (j = 0; j < height; j++)
                {
                    if (pixels[i, j].distanceSqr(a) < pixels[i, j].distanceSqr(b))
                        pixels[i, j] = a;
                    else
                        pixels[i, j] = b;
                }
            }

        }

        private void pixelsToPicture(Pixel[,] pixels)
        {
            // TODO threads maybe
            /*
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    picture.SetPixel(i, j, Color.FromArgb(pixels[i, j].getR(), pixels[i, j].getG(), pixels[i, j].getB()));
            */

            //unsafe but faster way
            BitmapData data = picture.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = data.Stride;
            unsafe
            {
                byte* ptr = (byte*)data.Scan0;
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        ptr[i * 3 + j * stride] = pixels[i, j].getB();
                        ptr[i * 3 + j * stride + 1] = pixels[i, j].getG();
                        ptr[i * 3 + j * stride + 2] = pixels[i, j].getR();

                    }
                }
            }
            picture.UnlockBits(data);
        }

        private void OpenImage(object sender, EventArgs e)
        {
            OpenFileDialog choice = new OpenFileDialog();
            //choice.InitialDirectory = "c:\\";
            choice.RestoreDirectory = true;
            choice.Filter = "Image Files (*.jpg, *.jpeg, *.bmp, *.png)|*.jpg;*.bmp;*.png|JPEG File (*.jpeg, *.jpg)|*.jpeg;*.jpg|BMP File (*.bmp)|*.bmp|PNG File (*.png)|*.png";
            if (choice.ShowDialog() == DialogResult.OK)
                loadPicture(choice.FileName);
        }
        private void DropingFile(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (!(files[0].EndsWith(".bmp") || files[0].EndsWith(".jpg") || files[0].EndsWith(".jpeg") || files[0].EndsWith(".png") || files[0].EndsWith(".BMP") || files[0].EndsWith(".JPG") || files[0].EndsWith(".PNG") || files[0].EndsWith(".JPEG")))
            {
                MessageBox.Show("Invalid type of data!", "Error");
                return;
            }
            else
                loadPicture(files[0]);
        }
        private void loadPicture(string FileName)
        {
            picture = new Bitmap(FileName);
            pictureBox.Image = picture;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // TODO
            imageSelected = true;
            width = picture.Width;
            height = picture.Height;
            /*
            Color c;
            pixels = new Pixel[width, height];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    c = picture.GetPixel(i, j);
                    pixels[i, j] = new Pixel(c.R, c.G, c.B);
                }
             * */
            pictureBox.Height = pictureBoxBeginHeight;
            pictureBox.Width = pictureBoxBeginWidth;
            this.Height = formBeginHeight;
            //adjusting the size of picturebox to image size
            if (height > width)
            {
                pictureBox.Height += 150;
                this.Height += 150;
                double relation = (double)pictureBox.Height / height;
                pictureBox.Width = (int)(width * relation);
                //moving PB to the center TODO maybe
            }
            else
            {
                double relation = (double)pictureBox.Width / width;
                pictureBox.Height = (int)(height * relation);
                this.Height = 150 + pictureBox.Height;
            }

            progressBar.Width = pictureBox.Width;
        }

        private void savePicture(object sender, EventArgs e)
        {
            if (!imageSelected)
            {
                MessageBox.Show("First choose the picture!");
                return;
            }
            SaveFileDialog choice = new SaveFileDialog();
            choice.RestoreDirectory = true;
            choice.Filter = "JPEG File (*.jpeg, *.jpg)|*.jpeg;*.jpg|BMP File (*.bmp)|*.bmp|PNG File (*.png)|*.png";
            if (choice.ShowDialog() == DialogResult.OK)
                picture.Save(choice.FileName);
        }

        private void exitAppliction(object sender, EventArgs e)
        {
            this.Close();
        }
        private void About(object sender, EventArgs e)
        {
            MessageBox.Show("Version 1\n2016 MKov.\nPlease report all errors to the publisher.\ngithub.com/milana-kovacevic\nThank you!", "About", MessageBoxButtons.OK);
        }

        private void EnteringDrag(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) 
                e.Effect = DragDropEffects.Copy;
        }



    }
}
