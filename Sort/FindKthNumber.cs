using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpLearning.Sort
{
    class FindKthNumber
    {
        public static void Test()
        {
            int[] input = { 11, 49, 53, 86, 22, 27, 98, 88, 91, 100 };

            for (int i = 1; i <= 10; i++)
            {
                int ith = Qsort(input, 0, 9, i);
                Console.WriteLine(ith);
            }
        }

        private static int Qsort(int[] input, int left, int right, int k)
        {
            if (left < right)
            {
                int i = Partition(input, left, right);//先成挖坑填数法调整
                if (k == right + 1 - i) return input[i];
                
                if (k > right + 1 - i)
                    return Qsort(input, left, i - 1, k); // 递归调用  
                else 
                    return Qsort(input, i + 1, right, k);
            }
            if (left == right)
            {
                if (1 == k)
                    return input[left];
            }

            return 0;
        }

        private static int Partition(int[] number, int left, int right)
        {
            int s = number[left];
            int i = left - 1;
            int j = right;

            while (true)
            {
                while (number[++i] < s) ;// 向右找
                while (j > 0 && number[--j] > s) ; // 向左找

                if (i >= j) break;

                int temp = number[i];
                number[i] = number[j];
                number[j] = temp;

            }

            //resort pivot
            number[left] = number[j];
            number[j] = s;

            return j;
        }
    }
}
