using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class InvertInteger
    {
        static public int Invert(int number)
        {
            int result = 0;
            while (number > 0)
            {
                result = result*10 + number%10;
                number /= 10;
            }

            return result;
        }

        public static void Test()
        {
            var int1 = 1324;
            var int2 = 1234000;
            var int3 = 103401;
            Console.WriteLine("{0} inverted as {1}", int1, Invert(int1));
            Console.WriteLine("{0} inverted as {1}", int2, Invert(int2));
            Console.WriteLine("{0} inverted as {1}", int3, Invert(int3));
        }
    }
}
