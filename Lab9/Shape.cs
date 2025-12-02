using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
      abstract class Shape
    {
        virtual public void PrintSides()
        {
            Console.WriteLine("Базовый класс");
        }
        virtual public double CalcPerimetr() { return 0; }
        virtual public double CalcSquare() { return 0; }
        virtual public void PrintCalcParams() 
        {
            Console.WriteLine("Площадь фигуры = {0}, периметр = {1}\n", this.CalcSquare(), this.CalcPerimetr());
        }
    }
}
