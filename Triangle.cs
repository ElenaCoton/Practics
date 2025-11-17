using System.Drawing;

namespace ConsoleApp1
{
    static class Operation
    {
        /// <summary>
        /// Метод вычисления площади произвольного треугольника
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        internal static double? CalcSquareTriangle(double? a, double? b, double? c)
        {
            if (IsExistsTriangle(a, b, c, false))
            {
                double p = ((double)a + (double)b + (double)c) / 2;
                return Math.Sqrt(p * (p - (double)a) * (p - (double)b) * (p - (double)c));
            }
            return null;
              
        }
        /// <summary>
        /// Метод вычисления площади равностороннего треугольника
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        internal static double? CalcSquareTriangle(double? a)
        {
            if (IsExistsTriangle(a, null, null, true))
            {
                double p = (3 * (double)a / 2);
                return Math.Sqrt(p * Math.Pow((p - (double)a), 3));
            }
            return null;
        }
        /// <summary>
        /// Метод проверки ввода величин сторон треугольника
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="isFlag"></param>
        /// <returns></returns>
        private static bool IsExistsTriangle(double? a, double? b, double? c, bool isFlag)
        {
            if (((a == null || b == null || c == null) && ! isFlag) || (a == null && isFlag) || (a <= 0 && isFlag) || ((a <= 0 || b <= 0 || c <= 0) && !isFlag))
            {
                Console.WriteLine("Треугольник задан некорректно!"); 
                return false;
            }
            return true;
        }

    }

    internal class Triangle
    {
      

        static void Main(string[] args)
        {
            Console.WriteLine("Треугольник равносторонний? Введите Да/Нет (Yes/No):");
            string input, strRL = Console.ReadLine();
            double? sq = 0;
            try
            {
                switch (strRL.ToUpper())
                {
                    case "ДA" or "YES":
                        {
                            Console.WriteLine("Введите сторону равностороннего треугольника:");
                            input = Console.ReadLine();
                            double? side = null;
                            if (input != "")
                                side = Double.Parse(input);
                            sq = Operation.CalcSquareTriangle(side);
                            if (sq != null)
                                Console.WriteLine($"Прощадь  равностороннего треугольника = {sq}");
                            break;
                        }
                    case "НET" or "NO":
                        {
                            Console.WriteLine("Введите первую сторону треугольника:");
                            input = Console.ReadLine();
                            double? side1 = null;
                            if (input != "")
                                side1 = Double.Parse(input);

                            Console.WriteLine("Введите вторую сторону треугольника:");
                            input = Console.ReadLine();
                            double? side2 = null;
                            if (input != "")
                                side2 = Double.Parse(input);

                            Console.WriteLine("Введите третью сторону треугольника:");
                            input = Console.ReadLine();
                            double? side3 = null;
                            if (input != "")
                                side3 = Double.Parse(input);

                            sq = Operation.CalcSquareTriangle(side1, side2, side3);
                            if (sq != null)
                                Console.WriteLine($"Площадь  треугольника = {sq}");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Вы ввели ерунду");
                            break;
                        }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ввели неверный тип данных");
            }
}
    }
}
