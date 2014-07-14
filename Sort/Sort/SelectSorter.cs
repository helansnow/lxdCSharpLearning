namespace Sort.CSharpLearning
{
    public class SelectSorter
    {
        private static int[] myArray;
        //private static int arraySize;

        public static void Sort(int[] a)
        {
            myArray = a;
            //arraySize = myArray.Length;
            SelectSort(myArray);
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="myArray"></param>
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

                Swap(ref myArray[i], ref myArray[smallest]);//将最小数据和未排序的第一个数据交换
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
            int[] a = new int[] { 4, 2, 1, 6, 3, 6, 0, -5, 1, 1 };
            SelectSorter.Sort(a);

            for (int i = 0; i < a.Length; i++)
            {
                System.Console.WriteLine(a[i]);
            }
        }
    }
 
}
