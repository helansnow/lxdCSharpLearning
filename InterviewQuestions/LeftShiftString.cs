using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    class LeftShiftString
    {
        public static void Test()
        {
            var input1 = "fgAbcde";
            Console.WriteLine(LeftShift(input1, 2));
            Console.ReadKey();
        }

        private static void Reverse(char[] cInput, int start, int end)
        {
            if(cInput == null || start > end || start < 0|| end < 0 || end > cInput.Length)
                throw new ArgumentException("bad input");
            
            if (start==end)
            {
                return;
            }
            while (start<end)
            {
                var temp = cInput[start];
                cInput[start] = cInput[end];
                cInput[end] = temp;
                start++;
                end--;
            }
        }

        private static string LeftShift(string input, int pos)
        {
            if (input == null || pos < 1 || pos >= input.Length)
                throw new ArgumentException("bad");

            char[] cInput = input.ToCharArray();
            Reverse(cInput,0, pos -1);
            Reverse(cInput, pos, input.Length - 1);

            Reverse(cInput, 0, input.Length -1 );

            return new string(cInput);
        }
    }
}
