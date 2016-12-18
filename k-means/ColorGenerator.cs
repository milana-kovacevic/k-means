using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace k_means
{
    class ColorGenerator
    {
        Pixel pixel;
        private long r, g, b;
        private long counter;

        public ColorGenerator(Pixel p)
        {
            counter = 0;
            r = g = b = 0;
            this.pixel = p;
        }
        public void addPixel(Pixel p)
        {
            r += p.getR();
            g += p.getG();
            b += p.getB();
            counter++;
        }
        public Pixel getPixel()
        {
            return pixel;
        }
        public void setPixel(Pixel newPixel)
        {
            pixel = newPixel;
        }
        public Pixel getNewPixel()
        {
            if (counter != 0)
                return new Pixel((byte)(r / counter), (byte)(g / counter), (byte)(b / counter));
            else
                return new Pixel(0,0,0);
        }
        public void resetCounter()
        {
            counter = 0;
            r = g = b = 0;
        }

    }
}
