using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FighterAttack
{
    static void Main()
    {
        // принципно се решава и с намиране координатите на ударите и събиране на всеки един > http://bgcoder.com/Contest/Practice/11 )
        int Px1 = int.Parse(Console.ReadLine());
        int Py1 = int.Parse(Console.ReadLine());
        int Px2 = int.Parse(Console.ReadLine());
        int Py2 = int.Parse(Console.ReadLine());
        int Fx = int.Parse(Console.ReadLine());
        int Fy = int.Parse(Console.ReadLine());
        int D = int.Parse(Console.ReadLine());
        int damage;
        int PxMin = Math.Min(Px1, Px2);
        int PxMax = Math.Max(Px1, Px2);
        int PyMin = Math.Min(Py1, Py2);
        int PyMax = Math.Max(Py1, Py2);            
        if (((Fx + D) >= PxMin) & ((Fx + D) < PxMax) & (Fy > PyMin) & (Fy < PyMax))
        {
            damage = 275;
            Console.WriteLine(damage + "%");
        }
        if (((Fx + D) >= PxMin) & ((Fx + D) < PxMax) & ((Fy == PyMin) || (Fy == PyMax)))
        {
            damage = 225;
            Console.WriteLine(damage + "%");
        }
        if (((Fx + D) == PxMax) & (Fy < PyMax) & (Fy > PyMin))
        {
            damage = 200;
            Console.WriteLine(damage + "%");
        }
        if (((Fx + D) == PxMax) & ((Fy == PyMax) || (Fy == PyMin)))
        {
            damage = 150;
            Console.WriteLine(damage + "%");
        }
        if (((Fx + D) == (PxMin - 1)) & ((Fy <= PyMax) || (Fy >= PyMin)))
        {
            damage = 75;
            Console.WriteLine(damage + "%");
        }
        if (((Fx + D) >= PxMin) & ((Fx + D) <= PxMax) & ((Fy == (PyMax + 1)) || (Fy == (PyMin-1))))
        {
            damage = 50;
            Console.WriteLine(damage + "%");
        }
        if (((Fx + D) < (PxMin - 1)) || ((Fx + D) > PxMax) || (Fy > (PyMax + 1)) || (Fy < (PyMin - 1)))
        {
            damage = 0;
            Console.WriteLine(damage + "%");
        }
        if (((Fx + D) < PxMin) & ((Fy > PyMax) || (Fy < PyMin)))
        {
            damage = 0;
            Console.WriteLine(damage + "%");
        }
    }
}
