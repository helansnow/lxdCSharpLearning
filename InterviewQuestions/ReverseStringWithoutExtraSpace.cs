using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    class ReverseStringWithoutExtraSpace
    {
        private static void ReverseString(char[] input)
        {
            var n = input.Length;
            for (int i = 0, j = n-1; i < j; i++, j--)
            {
                // a = a + b;
                //b = a - b;  //此时 b = a
                //a = a - b ; //此时 a = b         
                //两个数异或，比如1101和1001，相同位为0，不同位为1，则结果为0100，
                //所以任何数和0异或的结果都是其本身，一个数和自身异或的结果就是0.
               
                input[j] ^= input[i];
                input[i] ^= input[j];
                input[j] ^= input[i];

            }
        }

        public static void Run()
        {
            var str = new char[] { 'a', 'b', 'c', 'E', 'f', 'G' };
            Console.WriteLine(str);
            ReverseString(str);
            Console.WriteLine(str);
        }
    }
}
