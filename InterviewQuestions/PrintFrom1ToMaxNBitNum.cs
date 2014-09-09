using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    class PrintFrom1ToMaxNBitNum
    {
        //if n=3, 1,2,3~999
        public static void Print1ToMaxOfNBits(int n)
        {
            if (n <= 0) return;
            var number = new int[n];
            for (int i = 0; i < 10; ++i)
            {
                number[0] = i + '0'; //初始化设置number[0]是显示数字的最高位n。数字前的0 不显示
                Print1ToMaxOfNBitsRecursively(number, 0); //依次递归设置number[1] ~ number[n-1],是显示数字的从高到低的(n-1) ~1位；
            }
        }

        private static void Print1ToMaxOfNBitsRecursively(int[] number,  int bitChanging)
        {
            //约束条件，数组最右一位number[n-1]设置好了，即数字的最低一位
            if (bitChanging == number.Length -1)
            {
                PrintNumbers(number);
                Console.Write(" ");
                return;
            }
            for (int i = 0; i < 10; i++)
            {
                number[bitChanging + 1] = i + '0';//设置下一位，依次设置每一位 为 0~9，实际上以0开始的不打印
                Print1ToMaxOfNBitsRecursively(number,bitChanging+1);
            }
        }

        private static void PrintNumbers(int[] number)
        {
            bool isBegin0 = true;
            int nLength = number.Length;
            for (int i = 0; i < nLength; ++i)
            {
                if (isBegin0 && number[i] != '0')
                    isBegin0 = false;
                if(!isBegin0)
                {
                    Console.Write((char) number[i]);
                }
            }
        }

        public static void Run()
        {
            Print1ToMaxOfNBits(3);
        }
    }
}
