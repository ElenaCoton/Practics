using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    internal class Triangle : Shape, IMove, IComparable<Triangle>
    {
        private double a, b, c;

        public Triangle(double p1, double p2, double p3)
        {
            a = p1;
            b = p2;
            c = p3;
        }

        public Triangle(double p)
        {
            a = p;
            b = p;
            c = p;
        }

        override public double CalcPerimetr()
        {
            return a + b + c;
        }

        override public double CalcSquare()
        {
            double p = CalcPerimetr() / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        override public void PrintSides()
        {
            Console.WriteLine("Стороны треугольника: {0},{1},{2}", a, b, c);
        }
        public bool IsExistsTriangle()
        {
            return (a + b > c) && (b + c > a) && (a + c > b);
        }
        public int CompareTo(Triangle other)
        {
            if (other == null) return 1;
            return CalcSquare().CompareTo(other.CalcSquare());
        }
        public void Roll()
        {
            Console.WriteLine("Треугольник со сторонами {0},{1},{2} вращается",a,b,c);
        }
    }
}
