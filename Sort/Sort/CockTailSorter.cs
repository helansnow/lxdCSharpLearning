//鸡尾酒排序（双冒泡排序、搅拌排序或涟漪排序） 
namespace Sort.CSharpLearning
{
    public class CockTailSorter
    {
        public static void CockTailSort(int[] myArray)
        {
            int low, up, index, i;
            low = 0;
            up = myArray.Length - 1;
            index = low;
 
            while (up > low)
            {
                for (i = low; i < up; i++)//从上向下扫描
                {
                    if (myArray[i] > myArray[i + 1])
                    {
                        Helper.Swap(ref myArray[i], ref myArray[i + 1]);
                        index = i;
                    }
                }
 
                up = index;//记录最后一个交换的位置
                for (i = up; i > low; i--)//从最后一个交换位置从下往上扫描
                {
                    if (myArray[i] < myArray[i - 1])
                    {
                        Helper.Swap(ref myArray[i], ref myArray[i - 1]);
                        index = i;
                    }
                }
 
                low = index;//记录最后一个交换的位置
            }
        }

        public static void Run()
        {
            var a = new int[] { 4, 2, 1, 6, 3, 6, 0, -5, 1, 1 };
            CockTailSort(a);
 
            foreach (var t in a)
            {
                System.Console.WriteLine(t);
            }
        }
    }
}
 