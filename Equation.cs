namespace QuadraticEquation
{
    internal class Equation
    {
        private static char CheckParam(int a, int b, int c)
        {
            if (a == 0 && b != 0) return 'L';
            else if (a == 0 && b == 0 && c == 0) return 'A';
            else if (a == 0 && b == 0 && c != 0) return 'E';
            else return 'Q';

        }
        private static int CalcEquation(int a, int b, int c, out double x1, out double x2)
        {
            int res = 0;
            x1 = 0; x2 = 0;
            switch (CheckParam(a,b,c))
            {
                case 'L':
                    x1 = -1 * c / b;
                    res = 0;
                    break;
                case 'A':
                    res = 2;
                    break;
                case 'E':
                    res = -1;
                    break;
                case 'Q':
                    double d1 = b * b - 4 * a * c;
                    if (d1 < 0) res = -1;
                    else
                    {
                        double d = Math.Sqrt(d1);
                        if (d ==0) res = 0; else res = 1;
                        x1 = (-1 * b + d) / 2 * a;
                        x2 = (-1 * b - d) / 2 * a;
                    }
                    break;
                default:
                    break;
            }
            return res;
        }
        static void Main(string[] args)
        {
            double x1, x2;
            try
            {
                Console.WriteLine("Введите параметры квадратного уравнения");
                Console.WriteLine("Введите a:");
                int a = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Введите b:");
                int b = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Введите c:");
                int c = Int32.Parse(Console.ReadLine());
                switch (CalcEquation(a, b, c, out x1, out x2))
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
                Console.WriteLine("Что-то пошло не так :(" );
                Console.WriteLine(e.Message);
            }
        }
    }
}
