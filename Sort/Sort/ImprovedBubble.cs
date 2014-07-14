using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sort.CSharpLearning
{
    //Shaker排序就在於氣泡排序的雙向進行，先讓氣泡排序由左向右進行，再來讓氣泡排序由右往左進行，
    //如此完成一次排序的動作，而您必須使用left與right兩個旗標來記錄左右兩端已排序的元素位置。
    //一個排序的例子如下所示：
    //排序前：45 19 77 81 13 28 18 19 77 11
    //往右排序：19 45 77 13 28 18 19 77 11 [81]
    //向左排序：[11] 19 45 77 13 28 18 19 77 [81]
    //往右排序：[11] 19 45 13 28 18 19 [77 77 81]
    //向左排序：[11 13] 19 45 18 28 19 [77 77 81]
    //往右排序：[11 13] 19 18 28 19 [45 77 77 81]
    //向左排序：[11 13 18] 19 19 28 [45 77 77 81]
    //往右排序：[11 13 18] 19 19 [28 45 77 77 81]
    //向左排序：[11 13 18 19 19] [28 45 77 77 81]
    //如上所示，括號中表示左右兩邊已排序完成的部份，當left > right時，則排序完成。

    public class ImprovedBubble
    {
        private static void Shaker(int[] number)
        {
            int left = 0;
            int right = number.Length - 1;
            int shift = 0;

            while (left < right)
            {
                // 向右進行氣泡排序 
                for (int i = left; i < right; i++)
                {
                    if (number[i] > number[i + 1])
                    {
                        swap(number, i, i + 1);
                        shift = i;
                    }
                }
                right = shift;

                // 向左進行氣泡排序 
                for (int i = right; i > left; i--)
                {
                    if (number[i] < number[i - 1])
                    {
                        swap(number, i, i - 1);
                        shift = i;
                    }
                }
                left = shift;
            }
        }

        private static void swap(int[] number, int i, int j)
        {
            int t = number[i];
            number[i] = number[j];
            number[j] = t;
        }


        public static void Run()
        {
            var a = new int[] { 4, 2, 1, 6, 3, 6, 0, -5, 1, 1, -4, 8 };
            Shaker(a);
            foreach (var t in a)
            {
                Console.WriteLine(t);
            }
        }
    }
}
