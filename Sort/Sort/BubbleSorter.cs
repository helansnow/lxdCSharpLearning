using System;
using System.Collections.Generic;
using System.Text;

namespace Sort.CSharpLearning
{
    /// <summary>
    /// 一、冒泡排序 
    /// 已知一组无序数据a[1]、a[2]、……a[n]，需将其按升序排列。首先比较a[1]与a[2]的值，
    /// 若a[1]大于a[2]则交换两者的值，否则不变。再比较a[2]与a[3]的值，若a[2]大于a[3]则交换两者的值，否则不变。
    /// 再比较a[3]与a[4]，依此类推，最后比较a[n-1]与a[n]的值。
    /// 这样处理一轮后，a[n]的值一定是这组数据中最大的。
    /// 再对a[1]~a[n-1]以相同方法处理一轮，则a[n-1]的值一定是a[1]~a[n-1]中最大的。
    /// 再对a[1]~a[n-2]以相同方法处理一轮，依此类推。共处理n-1轮后a[1]、a[2]、……a[n]就以升序排列了。 
    /// 优点：稳定，比较次数已知； 
    /// 缺点：慢，每次只能移动相邻两个数据，移动数据的次数多。
    /// </summary>
    public class BubbleSorter
    {
        private static int[] myArray;

        public static void Sort(int[] a)
        {
            myArray = a;
            BubbleSort(myArray);
        }

        /// <summary>
        /// 冒泡算法
        /// </summary>
        /// <param name="myArray"></param>
        public static void BubbleSort(int[] myArray)
        {
            for (int i = 0; i < myArray.Length; i++) //循环的趟数
            {
                for (int j = 0; j < myArray.Length - 1 - i; j++) //每次循环的次数
                {
                    if (myArray[j] > myArray[j + 1])
                    {
                       Helper.Swap(ref myArray[j], ref myArray[j + 1]);
                    }
                }
            }
        }

        public static void BubbleSort2(int[] number)
        {
            var flag = true;
            var MAX = number.Length - 1;
            for (var i = 0; i < MAX && flag; i++)
            {
                flag = false;
                for (var j = 0; j < MAX - i; j++)
                {
                    if (number[j + 1] < number[j])
                    {
                        Swap(ref number[j + 1], ref number[j]);
                        flag = true;
                    }
                }
            }
        }

        //冒泡排序3  
        public static void BubbleSort3(int[] a)  
        {  
            int j, k;  
            int flag;  
      
            flag = a.Length;  
            while (flag > 0)  
            {  
                k = flag;  
                flag = 0;  
                for (j = 1; j < k; j++)  
                    if (a[j - 1] > a[j])  
                    {
                        Helper.Swap(ref a[j - 1], ref a[j]);  
                        flag = j;  
                    }  
            }  
        }  

        /// <summary>
        /// 交换
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        private static void Swap(ref int left, ref int right)
        {
            int temp;
            temp = left;
            left = right;
            right = temp;
        }

        public static void Run()
        {
            int[] a = new int[] {4, 2, 1, 6, 3, 6, 0, -5, 1, 1};
            //BubbleSorter.Sort(a);
            BubbleSort3(a);
            for (int i = 0; i < a.Length; i++)
            {
                System.Console.WriteLine(a[i]);
            }
        }
    }
}