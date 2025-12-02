using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    internal class Square: Shape, IMove
    {
        private double a;
        public Square(double side) 
        {
            a = side;
        }

        override public double CalcSquare()
        {
            return a * a;
        }
        override public double CalcPerimetr()
        {
            return 4 * a;
        }
        override public void PrintSides()
        {
            Console.WriteLine("Квадрат со стороной : {0}", a);
        }
        public void Roll()
        {
            Console.WriteLine("Квадрат вращается");
        }
    }
}
