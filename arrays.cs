using System.Runtime.ExceptionServices;

namespace ConsoleApp1
{
    internal class arrays
    {
        /// <summary>
        /// определение суммы всех элементов массива.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        static int CalcSumArray(int[] array)
        {
            int sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        /// <summary>
        /// определение среднего значения массива
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        static double CalcAverageArray(int[] array) 
        {
            int sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum/ array.Length;
        }

        /// <summary>
        /// расчет суммы отрицательных и положительных элементов
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        static (int, int) CalcMinusPlusSum(int[] array)
        { 
            int sumPlus = 0, sumMinus = 0;
            foreach (var item in array)
            { 
                if (item >0 )
                    sumPlus += item; 
                else
                    sumMinus += item;
            }
            return (sumPlus, sumMinus);
        }

        /// <summary>
        /// расчет суммы элементов с нечетными и четными номерами
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static (int, int) CalcEvenOddSum(int[] array) 
        {
            int sumOdd = 0, sumEven = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 0 )
                    sumEven += array[i];
                else
                    sumOdd += array[i];
            }
            return (sumOdd, sumEven);
        }

        /// <summary>
        /// поиск максимального и минимального элементов массива и их индексов
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        static (int, int, int, int) CalcMinMax(int[] array)
        {
            int minArr = array[0], maxArr = array[0], minIndx=0, maxIndx=0;
            for (int i = 1; i < array.Length; i++)
            {
                if (minArr > array[i])
                {
                    minArr = array[i];
                    minIndx = i;
                }
                if (maxArr < array[i])
                { 
                    maxArr = array[i]; 
                    maxIndx = i;
                }
            }
            return (minArr, maxArr, minIndx, maxIndx);
        }

        /// <summary>
        /// рассчитать произведение элементов массива, расположенных между макс и мин элементами
        /// </summary>
        /// <param name="array"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        static double MultiplyBetweenMinMax(int[] array, int min, int max) 
        { 
            int begIndx, endIndx, mult;
            if (min < max)
            {
                begIndx = min;
                endIndx = max;
            }
            else
            {
                begIndx = max;
                endIndx = min;
            }
            mult = array[begIndx];
            for (int i = begIndx + 1; i <= endIndx; i++)
            {
                mult = mult * array[i];
            }
            return mult;
        }

        static void Main(string[] args)
        {
            var rand = new Random();
            int[] myArray = new int[10];
            for (int i = 0; i < 10; i++)
            {
                if (rand.Next(10) >5)
                    myArray[i] = rand.Next(-100,0);
                else
                    myArray[i] = rand.Next(100);
                Console.Write(myArray[i] + " ");
            }
            var sumArray = CalcSumArray(myArray);
            Console.WriteLine($"\nCумма всех элементов массива = {sumArray}");
            
            var averigeArray = CalcAverageArray(myArray);
            Console.WriteLine($"Среднее значения массива {averigeArray}");

            int sumPlusArray=0, sumMinusArray=0;
            (sumPlusArray,sumMinusArray) = CalcMinusPlusSum(myArray);
            Console.WriteLine($"Cумма отрицательных элементов = {sumMinusArray} . Сумма положительных элементов = {sumPlusArray}");

            int sumOddArray = 0, sumEvenArray = 0;
            (sumOddArray,sumEvenArray) = CalcEvenOddSum(myArray);
            Console.WriteLine($"Cумма нечетных элементов = {sumOddArray} . Сумма четных элементов = {sumEvenArray}");

            int minArray, minIndxArray, maxArray, maxIndxArray;
            (minArray, maxArray, minIndxArray, maxIndxArray) = CalcMinMax(myArray);
            Console.WriteLine($"Минимальный элемент стоит на позиции {minIndxArray} и имеет значение {minArray}. \nМаксимальный элемент массива стоит на позиции {maxIndxArray} и имеет значение {maxArray}.");

            var multArray = MultiplyBetweenMinMax(myArray, minIndxArray, maxIndxArray);
            Console.WriteLine($"Произведение элементов массива, расположенных между максимальным и минимальным элементами ={multArray}");
        }
    }
}
