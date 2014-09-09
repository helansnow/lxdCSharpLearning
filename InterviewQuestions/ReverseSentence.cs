using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class ReverseSentence
    {
        public static void Reverse(ref char[] input, int iStart, int iEnd)
        {
            if(iStart > iEnd || iEnd <0 || iStart <0 || iStart >= input.Length|| iEnd >=input.Length)
                throw new ArgumentException("bad input");
            if(iStart == iEnd)
                return;
            while (iStart < iEnd)
            {
                char temp = input[iStart];
                input[iStart] = input[iEnd];
                input[iEnd] = temp;
                iStart++;
                iEnd--;
            }
        }

        public static void Reverse(string input)
        {
            var cInput = input.ToCharArray();
            Reverse(ref cInput,0,cInput.Length-1);
            Console.WriteLine(cInput);
            int start = 0;
            int end = 0;
            while (start < cInput.Length -1)
            {
                if (cInput[start] == ' ')
                {
                    start++;
                    end++;
                }
                else if (end == cInput.Length || cInput[end] == ' ') // end == cInput.Length must before cInput[end] == ' '
                {
                    Reverse(ref cInput, start, end-1);
                    start = end;
                }
                else
                {
                    end++;
                }
            }

            Console.WriteLine(cInput);
        }

        public static void Test()
        {
            var test = " this is an test! string ** stentence! ";
            //var test = "stentence! test";
            Console.WriteLine(test);
            Reverse(test);
            Console.ReadKey();
        }
    }
}
