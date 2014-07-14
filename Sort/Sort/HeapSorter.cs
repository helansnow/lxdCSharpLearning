namespace Sort.CSharpLearning
{
    public class HeapSorter
    {
        private static int[] myArray;
        private static int arraySize;

        public static void Sort(int[] a)
        {
            myArray = a;
            arraySize = myArray.Length;
            HeapSort();
        }

        public static void HeapSort()
        {
            BuildHeap();//将原始序列建成一个堆
            while (arraySize > 1)
            {
                arraySize--;
                Helper.Swap(myArray,0, arraySize);//将最大值放在数组最后
                TraversingHeap(0);//将序列从0到n-1看成一个新的序列，重新建立堆
            }
        }

        private static void BuildHeap()
        {
            for (int vNode = arraySize / 2 - 1; vNode >= 0; vNode--)
            {
                TraversingHeap(vNode);
            }
        }

        //利用向下遍历子节点建立队
        private static void TraversingHeap(int vNode)
        {
            int wNode = 2 * vNode + 1;//结点wNode是节点vNode的第一个(即左)子结点
            while (wNode < arraySize)
            {
                if (wNode + 1 < arraySize)//如果结点vNode下面有第二个(即右)子结点
                    if (myArray[wNode + 1] > myArray[wNode])
                        wNode++;//将子结点wNode设置成节点vNode下面值最大的子结点
                if (myArray[vNode] >= myArray[wNode])
                    return;
                Helper.Swap(myArray,vNode, wNode);//如果不是，就交换节点vNode和结点wNode的值
                vNode = wNode;
                wNode = 2 * vNode + 1;//继续向下找子结点
            }
        }

/*  ==============================================================================  */
        private static void HeapAdjust(int[] a, int i, int size)  //调整堆 
        {
            //一般用数组来表示堆，若根结点存在序号0处， i结点的父结点下标就为(i-1)/2。
            //i结点的左右子结点下标分别为2*i+1和2*i+2。
            int lchild = 2 * i + 1;     //i的左孩子节点序号 
            int rchild = 2 * i + 2;     //i的右孩子节点序号 
            int max = i;                //临时变量 
            if (i <= size / 2)          //如果i是叶节点就不用进行调整 
            {
                if (lchild <= size && a[lchild] > a[max])
                {
                    max = lchild;
                }
                if (rchild <= size && a[rchild] > a[max])
                {
                    max = rchild;
                }
                if (max != i)
                {
                    Helper.Swap(ref a[i],ref a[max]);
                    HeapAdjust(a, max, size);    //避免调整之后以max为父节点的子树不是堆 
                }
            }
        }

        private static void BuildMaxTopHeap(int[] a, int size)    //建立堆 
        {
            int i;
            for (i = (size-1) / 2; i >= 0; i--)    //非叶节点最大序号值为(size-1)/2 
            {
                HeapAdjust(a, i, size);
            }
        }

        private static void HeapSort(int[] a)    //堆排序 
        {
            int i;
            int size = a.Length;
            BuildMaxTopHeap(a, size-1);
            for (i = size-1; i >= 0; i--)
            {
                Helper.Swap(ref a[0], ref a[i]);    //交换堆顶和最后一个元素，即每次将剩余元素中的最大者放到最后面 
                HeapAdjust(a, 0, i - 1);            //重新调整堆顶节点成为大顶堆
            }
        }

        public static void Run()
        {
            var a = new[] { 4, 2, 1, 6, 3, 6, 0, -5, 1, 1 };
            //var a = new[] {70,60,12,40,30,8,10}; //已经成堆

            Sort(a);
            //HeapSort(a);
            for (int i = 0; i < a.Length; i++)
            {
                System.Console.WriteLine(a[i]);
            }
        }
    }
}
