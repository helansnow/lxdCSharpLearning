namespace Sort.CSharpLearning
{
    public class InsertSorter
    {
        private static int[] myArray;
        private static int arraySize;

        public static void Sort(int[] a)
        {
            myArray = a;
            arraySize = myArray.Length;
            InsertSort(myArray);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="myArray"></param>
        public static void InsertSort(int[] myArray)
        {
            int i, j, temp;

            for (i = 1; i < myArray.Length; i++)
            {
                temp = myArray[i]; //保存当前数据
                j = i - 1; //从当前数据前一位一次向前比较

                //将数据插入有序表中，如果表中的数据比该数据大
                //那么就依次向后移动有序表中的数据，直到找到第一个比它小的数据
                //将它放在那个数据后面

                while (j >= 0 && myArray[j] > temp) //找到大于当期值的往后移动
                {
                    myArray[j + 1] = myArray[j];
                    j--;
                }
                myArray[j + 1] = temp;
            }
        }

        public static void InsertSort2(int[] a)  
        {  
            int i, j;
            var n = a.Length;
            for (i = 1; i < n; i++)  
                for (j = i - 1; j >= 0 && a[j] > a[j + 1]; j--)  
                    Helper.Swap(ref a[j], ref a[j + 1]);  
        }

        public static void InsertSort3(int[] arr)
        {
            var length = arr.Length;
            //a[0]已经有序，从a[1]起依次比较，增加有序区
            for (int i = 1; i < length; i++)
            { 
                //a[0]~a[i-1]有序，从j=i开始往前比较，
                for (int j = i; j > 0; j--)          
                { 
                    if (arr[j] < arr[j - 1])
                    {
                        Helper.Swap(ref arr[j], ref arr[j - 1]);  
                        //var temp = arr[j]; 
                        //arr[j] = arr[j - 1]; 
                        //arr[j - 1] = temp;
                    } 
                }
            }
        }  


        public static void Run()
        {
            int[] a = new int[] {4, 2, 1, 6, 3, 6, 0, -5, 1, 1};
            //Sort(a);
            InsertSort3(a);
            for (int i = 0; i < a.Length; i++)
            {
                System.Console.WriteLine(a[i]);
            }
        }
    }
}
