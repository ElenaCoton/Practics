using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    internal class Circle: Shape
    {
        private double r;
        public Circle(double raduis)
        { 
            this.r = raduis;
        }
        override public double CalcSquare()
        {
            return Math.PI * r * r;
        }
        override public double CalcPerimetr()
        {
            return 2* Math.PI * r;
        }
        override public void PrintSides()
        {
            Console.WriteLine("Окружность с радиусом : {0}", r);
        }
    }
}
