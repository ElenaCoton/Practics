using System;
using System.Collections.Immutable;
using System.Data;

namespace Shapes
{
    internal class Program
    {
       static void Main(string[] args)
        {
            double p1, p2,p3;
            Console.WriteLine("Введите сторону произвольного треугольника:");
            p1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите вторую сторону произвольного треугольника:");
            p2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите третью сторону произвольного треугольника:");
            p3 = double.Parse(Console.ReadLine());
            Triangle t1 = new Triangle(p1, p2, p3);

            Console.WriteLine("\nВведите сторону равнозначного треугольника:");
            p1 = double.Parse(Console.ReadLine());
            Triangle t3 = new Triangle(p1);

            Console.WriteLine("\nВведите радиус окружности:");
            p1 = double.Parse(Console.ReadLine());
            Circle c1 = new Circle(p1);

            Console.WriteLine("\nВведите сторону квадрата:");
            p1 = double.Parse(Console.ReadLine());
            Square s1 = new Square(p1);

            Shape[] arr = { t1, t3, c1, s1 };
            foreach (var item in arr)
            {
                item.PrintSides();
                item.PrintCalcParams();
            }

            Console.WriteLine("Вращение фигур:");
            t1.Roll();
            t3.Roll();
            s1.Roll();
        }
    }
}
