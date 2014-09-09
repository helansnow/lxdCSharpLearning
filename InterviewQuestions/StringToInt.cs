using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class StringToInt
    {
        public static void Test()
        {
            string[] input = new string[10];
            input[0] = int.MaxValue.ToString(); //2147483647
            input[1] = int.MinValue.ToString(); //"-2147483648"
            input[2] = "-2147483648"; //"-2147483648"
            input[3] = "2147483648"; //error
            input[4] = "+2147483647"; //"2147483647"
            input[5] = " -  1001";
            input[6] = " ++  1001";
            input[7] = " -+  1001";
            input[8] = " -  0001";
            input[9] = " +  01";
            foreach (var s in input)
            {
                int result;
                var cast = ParseStringToInt(s, out result);
                if (cast)
                {
                    Console.WriteLine("convert {0} to {1}", s,result);
                }
                else
                {
                    Console.WriteLine("Fail to convert {0}", s);
                }
            }

            Console.ReadKey();
        }

        private static bool ParseStringToInt(string input, out int result)
        {
            char[] charStr = input.ToCharArray();

            int positive = 1;
            bool hadSign = false;
            result = 0;

            for (int i = 0; i < charStr.Length; i++)
            {
                var temp = charStr[i];
                int cur = temp - '0';
                //if (temp != '-' && temp != '+' && temp != ' ' && (cur < 0 || cur > 9))
                if (!(temp == '-' || temp == '+' || temp == ' ' || (cur > 0 || cur < 9)))
                    return false;
                if (!hadSign && temp == '-')
                {
                    positive = -1;
                    hadSign = true;
                    continue;
                }
                if (!hadSign && temp == '+')
                {
                    hadSign = true;
                    continue;
                }
                if (temp == ' ')
                {
                    continue;
                }

                if (cur < 0 || cur > 9)
                    return false;
                if (positive == 1)
                {
                    if (result > int.MaxValue/10)
                    {
                        return false;
                    }
                    if (result == int.MaxValue/10 && cur > int.MaxValue%10)
                    {
                        return false;
                    }
                    result = result*10 + cur;
                }
                else if (positive == -1)
                {
                    if (result < int.MinValue/10)
                    {
                        return false;
                    }
                    if (result == int.MinValue/10 && -cur > int.MinValue%10)
                    {
                        return false;
                    }
                    result = result*10 + positive*cur;
                }
            }

            return true;
        }
    }
}
