using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpLearning.Sort
{
    public class MergeSorter
    {
        /// <summary>
        /// 利用归并的方法排序数组，首先将序列分割
        /// 然后将数列归并
        /// 时间是O(nlog n)
        /// </summary>
        /// <param name="myArray"></param>
        public static void MergeSort(int[] myArray)
        {
            var arraySize = myArray.Length;
            int[] temp = new int[arraySize];
            Msort(myArray,temp, 0, arraySize - 1);
        }
        private static void Msort(int[] myArray,int[] temp, int left, int right)
        {
            int mid;
            if (right > left)
            {
                mid = (right + left) / 2;
                Msort(myArray, temp, left, mid);//分割左边的序列
                Msort(myArray,temp, mid + 1, right);//分割右边的序列
                Merge(myArray,temp, left, mid + 1, right);//归并序列
            }
        }

        private static void Merge(int[] myArray, int[] temp, int left, int mid, int right)
        {
            int i, left_end, num_elements, tmp_pos;
            int orgLeft = left;
            left_end = mid - 1;
            tmp_pos = left;
            num_elements = right - left + 1;
            while ((left <= left_end) && (mid <= right))
            {
                if (myArray[left] <= myArray[mid])//将左端序列归并到temp数组中
                {
                    temp[tmp_pos++] = myArray[left++];
                }
                else
                {
                    temp[tmp_pos++] = myArray[mid++];
                }
            }
            while (left <= left_end)//复制左边剩余的数据到temp数组中
            {
                temp[tmp_pos++] = myArray[left++];
            }
            while (mid <= right)//复制右边剩余的数据到temp数组中
            {
                temp[tmp_pos++] = myArray[mid++];
            }

            //for (i = 0; i < num_elements; i++)
            //{
            //    var t = right - i;
            //    myArray[t] = temp[t];
            //}

            for (i = 0; i < num_elements; i++)
            {
                myArray[orgLeft + i] = temp[orgLeft + i];
            }
        }


        public static void Run()
        {
            int[] a = new int[] { 4, 2, 1, 6, 3, 6, 0, -5, 1, 1 };
            MergeSort(a);

            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
        }
    }
}
