using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class ReverseSentence
    {
        public static void Reverse(char[] input, int iStart, int iEnd)
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
            Reverse(cInput,0,cInput.Length-1);

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
                else if (end == cInput.Length -1)
                {
                    Reverse(cInput, start, end);
                    break;
                }
                else if ( cInput[end] == ' ') 
                {
                    Reverse(cInput, start, end-1);
                    start = end;
                }          
                else
                {
                    end++;
                }
            }

            Console.WriteLine(cInput);
        }

        public static void ReverseRemoveExtraSpace(string input)
        {
            var cInput = input.ToCharArray();
            Reverse(cInput, 0, cInput.Length - 1);

            Console.WriteLine(cInput);
            int start = 0;
            int end = 0;
            int space = 0;
            int words = 0;
            int shift = 0;
            while (start < cInput.Length - 1)
            {
                if (cInput[start] == ' ')
                {
                    start++;
                    end++;
                    space++;
                }
                else if (end == cInput.Length - 1)
                {
                    Reverse(cInput, start - shift, end);
                    break;
                }
                else if (cInput[end] == ' ')
                {
                    if (words == 0)
                        shift = space;
                    else
                    {
                        shift = space - words;
                    }
                    Reverse(cInput, start - shift, end - 1);
                    words++;
                    start = end;
                    if (end + shift >= cInput.Length)
                    {
                        cInput[end - shift] = '\0';
                        break;
                    }
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
            //var test = " this is an test! string ** stentence!";
            //var test = "hello  world";
            //var test = "  hello  world  world  ";
            var test = "stentence! test";
            Console.WriteLine(test);
           // Reverse(test);
            ReverseRemoveExtraSpace(test);
            Console.ReadKey();

            //var reversed = string.Concat(test.Reverse());
            //var strArray = reversed.Split(' ');
            //string[] revStrArray = new string[reversed.Length];
            //for (int i = 0; i < strArray.Length; i++)
            //{
            //    revStrArray[i] = string.Concat(strArray[i].Reverse()) + " ";
            //}

            //Console.WriteLine(string.Concat(revStrArray));
            //Console.ReadKey();
        }
    }
}
