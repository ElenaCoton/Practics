namespace ArithProgression
{
    internal class AP
    {
        public class ArithProgr
        {
            private long firstNum;
            private long step;

            public void Create(long firstNum, long step)
            {
                this.firstNum = firstNum;
                this.step = step;
            }
            public long GetNNumber(long n)
            {
                return firstNum + (n - 1) * step;
            }
        }

        static void Main(string[] args)
        {
            long a, d,n;
            Console.WriteLine("Введите первый член арифметической прогрессии:");
            a = long.Parse(Console.ReadLine());
            Console.WriteLine("Введите разность арифметической прогрессии:");
            d = long.Parse(Console.ReadLine());
            ArithProgr ap = new ArithProgr();
            ap.Create(a, d);
            Console.WriteLine("Укажите какой-нибудь номер члена арифметической прогрессии:");
            n = long.Parse(Console.ReadLine());
            Console.WriteLine($"Значение {n}-го члена арифметической прогрессии = {ap.GetNNumber(n)}");
        }
    }
}
