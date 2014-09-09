using CSharpLearning.Sort;

namespace CSharpLearning.Sort
{
    public class SelectSorter
    {
        public static void SelectSort(int[] myArray)
        {
            int i, j, smallest;
            for (i = 0; i < myArray.Length - 1; i++)//数据起始位置，从0到倒数第二个数据
            {
                smallest = i;//记录最小数据的下标
                for (j = i + 1; j < myArray.Length; j++)
                {
                    if (myArray[j] < myArray[smallest])//在剩下的数据中寻找最小数据
                    {
                        smallest = j;//如果有比它更小的，记录下标
                    }
                }

                Helper.Swap(ref myArray[i], ref myArray[smallest]);//将最小数据和未排序的第一个数据交换
            }
        }

        public static void Run()
        {
            int[] a = new int[] { 4, 2, 1, 6, 3, 6, 0, -5, 1, 1 };
            SelectSort(a);

            for (int i = 0; i < a.Length; i++)
            {
                System.Console.WriteLine(a[i]);
            }
        }
    }
 
}
