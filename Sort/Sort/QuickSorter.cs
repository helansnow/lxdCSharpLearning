using System;
using System.Collections.Generic;
using System.Text;
using CSharpLearning.Sort;

namespace CSharpLearning.Sort
{
    public class QuickSorter
    {
        //快速排序  
        private static void Quick_sort(int[] s, int l, int r) 
        {  
            if (l < r)  
            {  
                //Swap(s[l], s[(l + r) / 2]); //将中间的这个数和第一个数交换 参见注1  
                int i = l, j = r, x = s[l];  
                while (i < j)  
                {  
                    while(i < j && s[j] >= x) // 从右向左找第一个小于x的数  
                        j--;    
                    if(i < j)   
                        s[i++] = s[j];  
              
                    while(i < j && s[i] < x) // 从左向右找第一个大于等于x的数  
                        i++;    
                    if(i < j)   
                        s[j--] = s[i];  
                }  
                s[i] = x;
                Quick_sort(s, l, i - 1); // 递归调用   
                Quick_sort(s, i + 1, r);  
            }  
        }

        private static int PartitionLeftAsPivot(int[] s, int l, int r)
        {
            int i = l, j = r, x = s[l]; 
            Console.WriteLine("pivot index {0} :  value {1}", l, x);
            while (i < j)
            {
                while (i < j && s[j] >= x) // 从右向左找第一个小于x的数  
                    j--;
                if (i < j)
                {
                    s[i++] = s[j];
                    Console.WriteLine("         " + string.Join(" ", s));
                } 
                while (i < j && s[i] < x) // 从左向右找第一个大于等于x的数  
                    i++;
                if (i < j)
                {
                    s[j--] = s[i];
                    Console.WriteLine("         " + string.Join(" ", s));
                }
            }
            s[i] = x;
            Console.WriteLine("         " + string.Join(" ", s));
            return i;
        }

        private static int PartitionMiddleAsPivot(int[] s, int l, int r)
        {
            Helper.Swap(ref s[l], ref s[(l + r) / 2]); //将中间的这个数和第一个数交换   
            int i = l, j = r, x = s[l]; 
            Console.WriteLine("pivot index {0} :  value {1}", l, x);
            while (i < j)
            {
                while (i < j && s[j] >= x) // 从右向左找第一个小于x的数  
                    j--;
                if (i < j)
                {
                    s[i++] = s[j];
                    Console.WriteLine("         " + string.Join(" ", s));
                }
                while (i < j && s[i] < x) // 从左向右找第一个大于等于x的数  
                    i++;
                if (i < j)
                {
                    s[j--] = s[i];
                    Console.WriteLine("         " + string.Join(" ", s));
                }
            }
            s[i] = x;
            Console.WriteLine("         " + string.Join(" ", s));
            return i;
        }

        private static void Qsort_LeftAsPivot(int[] input, int left, int right)
        {
            if (left < right)
            {
                int i = PartitionLeftAsPivot(input, left, right);//先成挖坑填数法调整 
                Qsort_LeftAsPivot(input, left, i - 1); // 递归调用  
                Qsort_LeftAsPivot(input, i + 1, right);
            }
        }

        private static void Qsort_MiddleAsPivot(int[] input, int left, int right)
        {
            if (left < right)
            {
                int i = PartitionMiddleAsPivot(input, left, right);
                Qsort_MiddleAsPivot(input, left, i - 1);
                Qsort_MiddleAsPivot(input, i + 1, right);
            }
        }

        private static void QuickSort_RightAsPivot(int[] input, int left, int right)
        {
            if (left < right)
            {
                int i = PartitionRightAsPivot(input, left, right);
                QuickSort_RightAsPivot(input, left, i - 1);
                QuickSort_RightAsPivot(input, i + 1, right);
            }
        }
    

        private static void quickSort(int[] number, int left, int right) 
        { 
            if(left < right) 
            { 
                int iPivot = number[(left+right)/2];
                Console.WriteLine("pivot index {0} :  value {1}", (left+right)/2, iPivot);
                int i = left - 1; 
                int j = right + 1; 

                while(true) 
                {
                    while (number[++i] < iPivot) ;  // 向右找 //遇到iPivot也跳出，把iPivot交换到j
                    while (number[--j] > iPivot) ;  // 向左找 
                    if(i >= j) 
                        break;
                    Helper.Swap(ref number[i], ref number[j]); 
                    Console.WriteLine("         " + string.Join(" ",number));
                } 

                //pivot 参与交换，写不成 partition 函数
                quickSort(number, left, i-1);   // 對左邊進行遞迴 
                quickSort(number, j+1, right);  // 對右邊進行遞迴 
            } 
         }

        private static int PartitionRightAsPivot(int[] number, int left, int right)
        {
            int iPivot = number[right];
            Console.WriteLine("pivot index {0} :  value {1}", right, iPivot);
            int i = left-1;

            for (int j = left; j < right ; j++)
            {
                if (number[j] <= iPivot)
                {
                    i++;
                    if (i != j)
                    {
                        Helper.Swap(ref number[i], ref number[j]);
                        Console.WriteLine("         " + string.Join(" ", number));
                    }
                   
                }
            }
            Helper.Swap(ref number[i+1], ref number[right]);
            return i+1; 
        }


        public static void Quick_sort(int[] array)
        {
            //Quick_sort(array, 0, array.Length - 1);
            //quickSort(array, 0, array.Length - 1);
            //Qsort_LeftAsPivot(array, 0, array.Length - 1);
           // Qsort_MiddleAsPivot(array, 0, array.Length - 1);
            QuickSort_RightAsPivot(array, 0, array.Length - 1);
        }

        public static void Run()
        {
            int[] a = { 11, 49, 53, 86, 22, 27, 98, 88, 91, 100 };
            //int[] a = { 10,9,8,7,6,5,4,3,2,1};
            //int[] a = { 1,2,3,4,5,6,7,8,9,10 };
            //int[] a = new int[] {4, 2, 1, 6, 3, 6, 0, -5, 1, 1};
            //int[]  a = { 2, 9, 5, 1, 8, 3, 6, 4, 7, 0 };
            Console.WriteLine(string.Join(" ", a));
            Quick_sort(a);
           
            Console.WriteLine(string.Join(" ", a));

            Console.ReadKey();
        }
    }
}
