using System;
using System.Numerics;
using System.Runtime.Serialization;

namespace DistanceNameSpace
{
    public class  Distance
    {
        private long pound;
        private long inch;
        private bool sign;

        public Distance()
        {
            pound = 0;
            inch = 0;
            sign = false;
        }
        public Distance(long value1, long value2)
        { 
            this.pound = value1;
            this.inch = value2;
            this.sign = false;
        }
        public static Distance operator +(Distance left, Distance right)
        { 
            Distance res = new Distance();
            res.inch = (left.inch + right.inch)%12;
            res.pound = left.pound + right.pound + (long)(left.inch + right.inch)/12;
            return res;
        }
        public static Distance operator -(Distance left, Distance right)
        {
            Distance res = new Distance(), d1 = new Distance(),d2 = new Distance();
           // bool isSign = false;
            if ((left.pound <= right.pound) && (left.inch < right.inch))
            {
                res.sign = true;
                d1 = right;
                d2 = left;
            }
            else
            {
                d2 = right;
                d1 = left;
            }
            res.pound = d1.pound - d2.pound;
            if (d1.inch < d2.inch)
            {
                res.pound = res.pound - 1;
                res.inch = d1.inch +12 - d2.inch;
            }
            else
            { 
                res.inch = d1.inch - d2.inch; 
            }
            return res;
        }
        public static bool operator >(Distance left, Distance right)
        {
            return ((left.pound >= right.pound) && (left.inch > right.inch));
        }
        public static bool operator <(Distance left, Distance right)
        {
            return ((left.pound <= right.pound) && (left.inch < right.inch));
        }
        public static bool operator ==(Distance left, Distance right)
        {
            return ((left.pound == right.pound) && (left.inch == right.inch));
        }
        public static bool operator !=(Distance left, Distance right)
        {
            return !(left==right);
        }
        public override string ToString()
        {
            string retVal = this.pound + "'-" + this.inch + "''";
            if (!((this.pound == 0) && (this.inch == 0)))
            {
                if (this.sign)
                {
                    retVal = "-" + retVal;
                }
            }
            return retVal;
        }
    };
    internal class Distances
    {
        static void Main(string[] args)
        {
            long p, i;
            Distance firstDistance, secondDistance, resultDistance, diffDistance;
            Console.WriteLine("Enter pounds for the first distance:");
            p = long.Parse( Console.ReadLine()) ;
            Console.WriteLine("Enter inches for then first distance:");
            i= long.Parse( Console.ReadLine()) ;
            firstDistance = new Distance(p, i);

            Console.WriteLine("Enter pounds for the second distance:");
            p = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter inches for then second distance:");
            i= long.Parse(Console.ReadLine());
            secondDistance = new Distance(p, i);

            resultDistance = firstDistance + secondDistance;
            Console.WriteLine($"\nThe sum of two distanse is {resultDistance}");
            if (firstDistance == secondDistance)
                Console.WriteLine("First distance is equal second distance");
            else if (firstDistance < secondDistance)
                 Console.WriteLine("\nAttention! The result of the subtraction is negative"); 
            diffDistance = firstDistance - secondDistance;
            Console.WriteLine($"The difference of two distanse is {diffDistance}");
        }
    }
}
