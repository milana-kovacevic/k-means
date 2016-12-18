using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_means
{
    class Pixel
    {
        byte R, G, B;
        public Pixel(byte R, byte G, byte B)
        {
            this.R = R;
            this.G = G;
            this.B = B;
        }
        public byte getR()
        {
            return R;
        }
        public byte getG()
        {
            return G;
        }
        public byte getB()
        {
            return B;
        }
        public void setR(byte R)
        {
            this.R = R;
        }
        public void setG(byte G)
        {
            this.B = G;
        }
        public void setB(byte B)
        {
            this.B = B;
        }
        public int distanceSqr(Pixel other)
        {
            byte r2 = other.getR();
            byte g2 = other.getG();
            byte b2 = other.getB();
            return (R - r2) * (R - r2) + (G - g2) * (G - g2) + (B - b2) * (B - b2);
        }


    }
}
