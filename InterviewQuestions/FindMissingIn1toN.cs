using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    class FindMissingIn1ToN
    {
        /*一个整型数组里除了1个数字只出现一次之外，其他的数字都出现了两次。
         * 请写出程序找出这个只出现1次的数字。要求时间复杂度是O(n)，空间复杂度是O(1)。
         * 这个很简单，通过异或就可以除掉相同的数字，到最后只剩下一个只出现一次的数字。
         */
        public static int FindMissingBySum(int[] input, int n)
        {
            int sum = 0;
            for (var i = 1; i <= n; i++)
            {
                sum += i;
            }

            for (int i = 0; i < n -1; i++)
            {
                sum -= input[i];
            }

            return sum;
        }

        public static int FindMissingByXor(int[] input, int n)
        {
            int sum = 0;
            for (var i = 1; i <= n; i++)
            {
                sum ^= i;
            }

            for (int i = 0; i < n - 1; i++)
            {
                sum ^= input[i];
            }

            return sum;
        }

        /*题目二：
         * 一个整型数组里除了2个数字只出现一次之外，其他的数字都出现了两次。
         * 请写出程序找出这个2个只出现一次的数字。要求时间复杂度是O(n)，空间复杂度是O(1)。
         * 这个也是使用异或的思想。
         * 既然有两个不同的数字num1、num2，那么这两个数字至少有一位不同，
         * 异或结果肯定至少有一位是1（其他数字成对出现不影响异或结果），
         * 也就是异或结果为1的地方就是这两个数字对应的位不同的地方。
         * 假如异或结果第k为是1，那么num1和num2的第k位一个为0，一个为1。
         * 我们根据第k为是否为0把它们异或到不同的结果xor1和xor2中。
         * 到最后xor1中和xor2中就保存的是num1和num2（或num2和num1）。*/
        public static bool Find2NumsAppearOnce(int[] data, ref int num1, ref int num2)
        {
            var length = data.Length;
            if(length < 2)  
                return false;  
  
            int xorAll = 0;  
            for(int i = 0; i < length; i++)  
                xorAll ^= data[i];

            int indexOf1 = 0;
            while ((xorAll & (1 << indexOf1)) == 0) indexOf1++;

            //int indexOf1 = FindFirstBitIs1(xorAll);
  
            int xor1 = 0, xor2 = 0;  
            for(int j = 0; j < length; j++)
                if (IsBit1(data[j], indexOf1))
                    xor1 ^= data[j];
                else 
                    xor2 ^= data[j];  
  
            num1 = xor1;  
            num2 = xor2;

            return true;
        }  

         // Find the index of first bit which is 1 in num (assuming not 0)
        static int FindFirstBitIs1(int num)
        {
              int indexBit = 0;
              while (((num & 1) == 0) && (indexBit < 32))
              {
                    num = num >> 1;
                    ++ indexBit;
              }
 
              return indexBit;
        }
 
        // Is the indexBit bit of num 1?
        static bool IsBit1(int num, int indexBit)
        {
              num = num >> indexBit;
 
              return ((num & 1) == 1);
        }

        public static void Run()
        {
            int[] input = {1, 2, 6, 7, 3, 5, 8, 10, 9}; //4
            Console.WriteLine("FindMissingBySum {0}",FindMissingBySum(input,10));
            Console.WriteLine("FindMissingByXor {0}", FindMissingByXor(input, 10));

            int[] input2 = { 1, 1, 6, 3,3, 5,5, 8, 10,10,9, 9 }; // 6,8
            int n1 = 0, n2 = 0;
            if (Find2NumsAppearOnce(input2, ref n1, ref n2))
            {
                Console.WriteLine("Find2NumsAppearOnce {0}, {1}", n1, n2);
            }

            Console.ReadLine();
        }
    }
}
