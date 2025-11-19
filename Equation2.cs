namespace QuadraticEquation2
{
    internal class Equation
    {

        private static (int, double, double) CalcEquation(int a, int b, int c)
        {
            int res = 0;
            double x1 = 0, x2 = 0;

            if (a == 0 && b == 0 && c == 0)
                res = 2;
            else
            {
                if (a == 0 && b != 0)
                {
                    x1 = -1 * c / b;
                    res = 0;
                }
                else
                {
                    double d1 = b * b - 4 * a * c;
                    if (d1 < 0) 
                        res = -1;
                    else
                    {
                        double d = Math.Sqrt(d1);
                        if (d == 0) res = 0; else res = 1;
                        x1 = (-1 * b + d) / 2 * a;
                        x2 = (-1 * b - d) / 2 * a;
                    }
                }
            }   
            return (res, x1,x2);
        }
        static void Main(string[] args)
        {
            double x1, x2;
            int r=0;
            try
            {
                Console.WriteLine("Введите параметры квадратного уравнения");
                Console.WriteLine("Введите a:");
                int a = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Введите b:");
                int b = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Введите c:");
                int c = Int32.Parse(Console.ReadLine());
                (r, x1, x2) = CalcEquation(a, b, c);

                switch (r)
                {
                    case -1:
                        Console.WriteLine("Решений нет");
                        break;
                    case 0:
                        Console.WriteLine($"Корень уравнения один и он равен {x1}");
                        break;
                    case 1:
                        Console.WriteLine($"Корни уравнения: x1 = {x1}, x2 = {x2}");
                        break;
                    case 2:
                        Console.WriteLine("х - любое число");
                        break;
                    default:
                        break;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Что-то пошло не так :(");
                Console.WriteLine(e.Message);
            }
        }
    }
}
