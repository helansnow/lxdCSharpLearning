namespace Sort.CSharpLearning
{
    public class Helper
    {
        /// <summary>
        /// 交换
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static void Swap(ref int left, ref int right)
        {
            int temp = left;
            left = right;
            right = temp;
        }
    }
}