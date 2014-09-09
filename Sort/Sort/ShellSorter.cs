namespace CSharpLearning.Sort
{
    public class ShellSorter
    {
        public static void ShellSort(int[] myArray)
        {
            int i, j, increment;
            int temp;

            for (increment = myArray.Length / 2; increment > 0; increment /= 2) //选取增量，并逐次缩小
            {
                //以增量长度位置为起点，依次选取比较{以Length = 10 为例 第一次increment=5 a[5], a[6], a[7]
                //第二次 increment/2 =2 a[2] a[3]...a[10]
                //第三次 increment = 1, 就是相邻交换了
                for (i = increment; i < myArray.Length; i++) 
                {
                    temp = myArray[i]; //第一次a[i=5] 
                    for (j = i; j >= increment; j -= increment)//一个分组的长度为一个增量, i是高位，j依次按increment减小
                    {
                        //第一次increment = 5; a[i=j=5] & a[j - increment=0], a[6]& a[1] ...a[i=j=9] & a[j - increment=4]; 
                        //第二次increment = 2; a[i=j=2]&a[j - increment=0];a[i=j=3]&a[1]//a[4]&a[2];a[5]&a[3]//a[6]&a[4]...a[i=j=9]&a[j - increment=7]
                        if (temp < myArray[j - increment]) 
                            myArray[j] = myArray[j - increment]; //如果小就往低位排
                        else
                            break;
                    }
                    myArray[j] = temp;  //此时j是最低位，把最小的放入
                }
            }
        }

        //public static void ShellSort4(int[] a)  
        //{  
        //    int i, j, gap;
        //    var n = a.Length;
        //    for (gap = n / 2; gap > 0; gap /= 2)  
        //        for (i = gap; i < n; i++)  
        //            for (j = i - gap; j >= 0 && a[j] > a[j + gap]; j -= gap)  
        //               Helper.Swap(ref a[j], ref a[j + gap]);  
        //}

        //public static void ShellSort5(int[] a)
        //{
        //    int i, j, gap;
        //    var n = a.Length;
        //    for (gap = n / 2; gap > 0; gap /= 2)
        //        for (i = gap; i < n; i++)
        //            for (j = i - gap; j >= 0 ; j -= gap)
        //                if(a[j] > a[j + gap])
        //                    Helper.Swap(ref a[j], ref a[j + gap]);
        //}  

        ///// <summary>
        ///// Shell Sort
        ///// </summary>
        //public static void ShellSort2(int[] myArray)
        //{
        //    int length = myArray.Length;
        //    for (int h = length / 2; h > 0; h = h / 2)
        //    {
        //        //here is insert sort
        //        for (int i = h; i < length; i++)
        //        {
        //            var temp = myArray[i];
        //            if (temp < myArray[i - h])
        //            {
        //                for (int j = 0; j < i; j += h)
        //                {
        //                    if (temp <myArray[j])
        //                    {
        //                        temp = myArray[j];
        //                        myArray[j] = myArray[i];
        //                        myArray[i] = temp;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        //public static void ShellSort3(int[] myArray)
        //{
        //    int gap = myArray.Length / 2;

        //    while (gap > 0)
        //    {
        //        for (int k = 0; k < gap; k++)
        //        {
        //            for (int i = k + gap; i < myArray.Length; i += gap)
        //            {
        //                for (int j = i - gap; j >= k; j -= gap)
        //                {
        //                    if (myArray[j] > myArray[j + gap])
        //                    {
        //                        var temp = myArray[j];
        //                        myArray[j] = myArray[j + gap];
        //                        myArray[j + gap] = temp;
        //                    }
        //                    else
        //                        break;
        //                }
        //            }
        //        }

        //        gap /= 2;
        //    }
        //}

        public static void ShellSort6(int[] myArray)
        {
            int length = myArray.Length;
            for (int h = length / 2; h > 0; h = h / 2)
            {
                //here is insert sort
                //每个分组的第一个元素已经有序，从h开始依次比较, 
                for (int i = h; i < myArray.Length; i += h)
                {
                    for (int j = i; j > 0; j -= h)
                    {
                        if (myArray[j] < myArray[j - h])
                        {
                            var temp = myArray[j];
                            myArray[j] = myArray[j - h];
                            myArray[j - h] = temp;
                        }
                    }
                }
            }
        }

        public static void Run()
        {
            int[] a = new int[] { 4, 2, 1, 6, 3, 6, 0, -5, 1, 1,-4 , 8 };

            //ShellSort2(a);
            //ShellSort3(a);
            ShellSort6(a);
            for (int i = 0; i < a.Length; i++)
            {
                System.Console.WriteLine(a[i]);
            }
        }
    }
 
}
