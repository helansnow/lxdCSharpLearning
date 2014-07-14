using System;
using System.Collections.Generic;
using System.Text;

namespace Sort.CSharpLearning
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

        private static void quickSort(int[] number, int left, int right) 
        { 
            if(left < right) 
            { 
                int s = number[(left+right)/2]; 
                int i = left - 1; 
                int j = right + 1; 

                while(true) { 
                    while(number[++i] < s) ;  // 向右找 
                    while(number[--j] > s) ;  // 向左找 
                    if(i >= j) 
                        break;
                    Helper.Swap(number, i,j); 
                } 

                quickSort(number, left, i-1);   // 對左邊進行遞迴 
                quickSort(number, j+1, right);  // 對右邊進行遞迴 
            } 
         }

        public static void Quick_sort(int[] array)
        {
            Quick_sort(array, 0, array.Length - 1);
            //quickSort(array, 0, array.Length - 1);
        }

        public static void Run()
        {
            int[] a = new int[] {4, 2, 1, 6, 3, 6, 0, -5, 1, 1};
            //int[]  a = { 2, 9, 5, 1, 8, 3, 6, 4, 7, 0 };
            Quick_sort(a);
           
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }

            Console.ReadKey();
        }
    }
}
