namespace Shooting_Target
{
    internal class ShootTarget
    {
        static void Main(string[] args)
        {
            double x, y;
            int z = 0;
            int result = 0;
            bool isShoot = true;
            do
            {
                Console.WriteLine("Выстрел номер {0}", z + 1);
                Console.WriteLine("Ваш выстрел (x):");
                x = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Ваш выстрел  (y):");
                y = Convert.ToDouble(Console.ReadLine());

                if (x * x + y * y <= 1)
                    result = result + 10;
                else if (x * x + y * y > 1 && x * x + y * y <= 4)
                    result = result + 5;
                else if (x * x + y * y > 4 && x * x + y * y <= 9)
                    result = result + 3;
                z++;

                Console.WriteLine("Стреляем еще (0 - нет/1 - да)?");
                if (Console.ReadLine() == "0")
                    isShoot = false;
            }
            while (isShoot);
            Console.WriteLine($"Произведено выстрелов: {z} , результат: {result}");
            
        }
    }
}
