using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//http://stackoverflow.com/questions/5618989/binary-tree-from-preorder-and-inorder-traversal

namespace BiTreeTravers
{
    public class BinaryTreeConstruct
    {
        #region 构造一棵已知的二叉树

        public static BinaryTreeNode<string> BinTree()
        {
            BinaryTreeNode<string>[] binTree = new BinaryTreeNode<string>[8];
            //创建结点
            binTree[0] = new BinaryTreeNode<string>("A");
            binTree[1] = new BinaryTreeNode<string>("B");
            binTree[2] = new BinaryTreeNode<string>("C");
            binTree[3] = new BinaryTreeNode<string>("D");
            binTree[4] = new BinaryTreeNode<string>("E");
            binTree[5] = new BinaryTreeNode<string>("F");
            binTree[6] = new BinaryTreeNode<string>("G");
            binTree[7] = new BinaryTreeNode<string>("H");

            //使用层次遍历二叉树的思想，构造一个已知的二叉树               
            binTree[0].LNode = binTree[1];
            binTree[0].RNode = binTree[2];
            binTree[1].RNode = binTree[3];
            binTree[2].LNode = binTree[4];
            binTree[2].RNode = binTree[5];
            binTree[3].LNode = binTree[6];
            binTree[3].RNode = binTree[7];

             //      A 0
             //  /       \
             // B1          C2
             //  \       /    \
             //   D3     E4      F5
             //  / \
             // G6   H7

            //set parent node
            binTree[0].PNode = null;
            binTree[1].PNode = binTree[0];
            binTree[2].PNode = binTree[0];
            binTree[3].PNode = binTree[1];
            binTree[4].PNode = binTree[2];
            binTree[5].PNode = binTree[2];
            binTree[6].PNode = binTree[3];
            binTree[7].PNode = binTree[3];


            //返回二叉树的根结点              
            return binTree[0];
        }

        #endregion

        public static BinaryTreeNode<T> FromTraversals<T>(T[] preorder, T[] inorder)
        {
            if (preorder == null) throw new ArgumentNullException("preorder");
            if (inorder == null) throw new ArgumentNullException("inorder");
            if (preorder.Length != inorder.Length) throw new ArgumentException("inorder and preorder have different lengths");

            int n = preorder.Length;

            return new BinaryTreeNode<T>(FromTraversals(preorder, 0, n - 1, inorder, 0, n - 1));
        }

        public static BinaryTreeNode<T> FromTraversals<T>(T[] preorder, int pstart, int pend, T[] inorder, int istart, int iend)
        {
            if (pstart > pend) return null;

            T rootVal = preorder[pstart];
            int rootInPos;
            for (rootInPos = istart; rootInPos <= iend; rootInPos++) //find rootVal in inorder
                if (Comparer<T>.Default.Compare(inorder[rootInPos], rootVal) == 0) break;

            if (rootInPos > iend)
                throw new ArgumentException("invalid inorder and preorder inputs");

            int offset = rootInPos - istart;

            return new BinaryTreeNode<T>(rootVal)
            {
                LNode = FromTraversals(preorder, pstart + 1, pstart + offset, inorder, istart, istart + offset - 1),
                RNode = FromTraversals(preorder, pstart + offset + 1, pend, inorder, istart + offset + 1, iend),
            };
        }


        public void TestGenerationFromTraversals()
        {
            var preorder = new[] { 1, 2, 4, 5, 3 };
            var inorder = new[] { 4, 2, 5, 1, 3 };
            AssertGenerationFromTraversal(preorder, inorder);

            var preorder2 = new[] { 'A', 'B', 'D', 'E', 'C', 'F' };
            var inorder2 = new[] { 'D', 'B', 'E', 'A', 'F', 'C' };
            AssertGenerationFromTraversal(preorder2, inorder2);

         //      A
         //     / \
         //    B   C
         //   /     \
         //  D       F
         // /       / \
         //E       G   H
        }

        private static void AssertGenerationFromTraversal<T>(T[] preorder, T[] inorder)
        {
            var tree = FromTraversals(preorder, inorder);

            //var treeInorder = new List<T>();
            BinaryTraverse.PreOrder(tree);//TraverseInOrder(treeInorder.Add);
            Console.WriteLine();
            BinaryTraverse.inOrderIter(tree);
            Console.WriteLine();
            //var treePre = new List<T>();
            //tree.TraversePreOrder(treePre.Add);

            //Assert.IsTrue(preorder.SequenceEqual(treePre));
            //Assert.IsTrue(inorder.SequenceEqual(treeInorder));
        }
    }
}
