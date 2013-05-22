using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telerik_Academy_Exam_dec._2011
{
    class ShipDamage
    {
        static void Main(string[] args)
        {
            int Sx1 = Int32.Parse(Console.ReadLine());
            int Sy1 = Int32.Parse(Console.ReadLine());
            int Sx2 = Int32.Parse(Console.ReadLine());
            int Sy2 = Int32.Parse(Console.ReadLine());
            int H = Int32.Parse(Console.ReadLine());
            int Cx1 = Int32.Parse(Console.ReadLine());
            int Cy1 = Int32.Parse(Console.ReadLine());
            int Cx2 = Int32.Parse(Console.ReadLine());
            int Cy2 = Int32.Parse(Console.ReadLine());
            int Cx3 = Int32.Parse(Console.ReadLine());
            int Cy3 = Int32.Parse(Console.ReadLine());
            int SxMin = Math.Min(Sx1, Sx2);
            int SyMax = Math.Max(Sy1, Sy2);
            int SxMax = Math.Max(Sx1, Sx2);
            int SyMin = Math.Min(Sy1, Sy2);
            int hitY1 = H + (H - Cy1);
            int hitY2 = H + (H - Cy2);
            int hitY3 = H + (H - Cy3);
            int sum = 0;
            if ((Cx1 > SxMin) & (Cx1 < SxMax) & (hitY1 > SyMin) & (hitY1 < SyMax))
            {
                sum = sum + 100;
            }
            if ((Cx2 > SxMin) & (Cx2 < SxMax) & (hitY2 > SyMin) & (hitY2 < SyMax))
            {
                sum = sum + 100;
            }
            if ((Cx3 > SxMin) & (Cx3 < SxMax) & (hitY3 > SyMin) & (hitY3 < SyMax))
            {
                sum = sum + 100;
            }
            if ((Cx1 == SxMax))
            {
                if ((hitY1 == SyMin) || (hitY1 == SyMax))
                {
                    sum = sum + 25;
                }
                if ((hitY1 > SyMin) & (hitY1 < SyMax))
                {
                    sum = sum + 50;
                }
            }
            if ((Cx1 == SxMin))
            {
                if ((hitY1 == SyMin) || (hitY1 == SyMax))
                {
                    sum = sum + 25;
                }
                if ((hitY1 > SyMin) & (hitY1 < SyMax))
                {
                    sum = sum + 50;
                }
            }
            if ((Cx2 == SxMax))
            {
                if ((hitY2 == SyMin) || (hitY2 == SyMax))
                {
                    sum = sum + 25;
                }
                if ((hitY2 > SyMin) & (hitY2 < SyMax))
                {
                    sum = sum + 50;
                }
            }
            if ((Cx2 == SxMin))
            {
                if ((hitY2 == SyMin) || (hitY2 == SyMax))
                {
                    sum = sum + 25;
                }
                if ((hitY2 > SyMin) & (hitY2 < SyMax))
                {
                    sum = sum + 50;
                }
            }
            if ((Cx3 == SxMax))
            {
                if ((hitY3 == SyMin) || (hitY3 == SyMax))
                {
                    sum = sum + 25;
                }
                if ((hitY3 > SyMin) & (hitY3 < SyMax))
                {
                    sum = sum + 50;
                }
            }
            if ((Cx3 == SxMin))
            {
                if ((hitY3 == SyMin) || (hitY3 == SyMax))
                {
                    sum = sum + 25;
                }
                if ((hitY3 > SyMin) & (hitY3 < SyMax))
                {
                    sum = sum + 50;
                }
            }
            if ((Cx1 > SxMin) & (Cx1 < SxMax))
            {
                if ((hitY1 == SyMax) || (hitY1 == SyMin))
                {
                    sum = sum + 50;
                }
            }
            if ((Cx2 > SxMin) & (Cx2 < SxMax))
            {
                if ((hitY2 == SyMax) || (hitY2 == SyMin))
                {
                    sum = sum + 50;
                }
            }
            if ((Cx3 > SxMin) & (Cx3 < SxMax))
            {
                if ((hitY3 == SyMax) || (hitY3 == SyMin))
                {
                    sum = sum + 50;
                }
            }
            
            Console.WriteLine(sum + "%");
        }
    }
}
