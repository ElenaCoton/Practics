using System.Data;

namespace Lab6
{
    internal class Program
    {
        public class Triangle : IComparable<Triangle>
        {
            private double a, b, c;

            public void NewTriangle(double p1, double p2, double p3)
            {
                a = p1;
                b = p2;
                c = p3;
            }

            public double CalcPerimetr()
            { 
                return a + b + c; 
            }

            public double CalcSquare()
            { 
                double p = CalcPerimetr() / 2;
                return Math.Sqrt(p* (p-a) *(p-b)*(p-c));
            }
            public void PrintSides()
            {
                Console.WriteLine("Стороны треугольника: {0},{1},{2}", a, b, c);
            }
            public bool IsExistsTriangle()
            { 
                return (a+b >c) && (b+c >a) && (a+c >b) ;
            }
            public int CompareTo(Triangle other)
            {
                if (other == null) return 1;
                return CalcSquare().CompareTo(other.CalcSquare());
            }
        }

        static void Main(string[] args)
        {
            double p1, p2, p3;
            Console.WriteLine("Введите стороны треугольника номер 1:");
            Console.WriteLine("Сторона a:");
            p1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Сторона b:");
            p2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Сторона c:");
            p3 = double.Parse(Console.ReadLine());

            Triangle t1 = new Triangle();
            t1.NewTriangle(p1,p2, p3);
            if (t1.IsExistsTriangle()) 
            { 
                Console.WriteLine("Периметр треугольника = {0}",t1.CalcPerimetr());
                Console.WriteLine("Площадь треугольника = {0}", t1.CalcSquare());
                t1.PrintSides();
            }
            else
                Console.WriteLine("Треугольник с такими сторонами не существует");

            Console.WriteLine("\nВведите стороны треугольника номер 2:");
            Console.WriteLine("Сторона a:");
            p1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Сторона b:");
            p2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Сторона c:");
            p3 = double.Parse(Console.ReadLine());

            Triangle t2 = new Triangle();
            t2.NewTriangle(p1,p2,p3);

            Console.WriteLine("Сортировка двух треугольников по их площади");
            List<Triangle> list = new List<Triangle>();
            list.Add(t1);
            list.Add(t2);
            list.Sort();
            foreach (var item in list)
            {
                item.PrintSides();
            }
        }
    }
}
