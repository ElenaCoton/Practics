namespace CalcNumbers
{
    internal class ProgramCalcNumbers
    {
        static void Main(string[] args)
        {
           
            int num;
            int sumResult = 0;
            do
            {
                try
                {
                    Console.WriteLine("Введите целое без знака число");
                    num = Int32.Parse(Console.ReadLine());
                    if (num < 0) throw new Exception("Введено отрицательное значение");
                        break;
                }
                catch (Exception error)
                {

                    Console.WriteLine(error.Message);
                }
            } while (true);
            
            while (num != 0)
            {
                sumResult += num % 10;
                num = num / 10;

            }
            Console.WriteLine($"Результат сложения всех цифр числа: {sumResult}");
        }
    }
}
