using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiTreeTravers.CSharpLearning
{
    class Test
    {
        #region 测试的主方法
        static void Main(string[] args)
        {
            //var biTree = new BinaryTreeConstruct();
            //biTree.TestGenerationFromTraversals();

            BinaryTreeNode<string> rootNode = BinaryTreeConstruct.BinTree();
            Console.WriteLine("Recursive Binary Tree Pre Order Traversal：");
            BinaryTraverse.PreOrder<string>(rootNode);
            Console.WriteLine();
            Console.WriteLine("Iterative Binary Tree Pre Order Traversal：");
            BinaryTraverse.preOrderIter<string>(rootNode);
            Console.WriteLine("Iterative Binary Tree Pre Order Traversal2：");
            BinaryTraverse.preOrderIter2<string>(rootNode);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Recursive Binary Tree In Order Traversal：");
            BinaryTraverse.MidOrder<string>(rootNode);
            Console.WriteLine();
            Console.WriteLine("Iterative Binary Tree In Order Traversal：");
            BinaryTraverse.inOrderIter<string>(rootNode);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Recursive Binary Tree Post Order Traversal：");
            BinaryTraverse.AfterOrder<string>(rootNode);
            Console.WriteLine();
            Console.WriteLine("Iterative Binary Tree Post Order Traversal：");
            BinaryTraverse.postOrderIter<string>(rootNode);
            Console.WriteLine("Iterative Binary Tree Post Order Traversal Iterative：");
            BinaryTraverse.postOrderTraversalIterative<string>(rootNode);
            Console.WriteLine("Iterative Binary Tree Post Order Traversal Iterative2：");
            BinaryTraverse.postOrderTraversalIterative2<string>(rootNode);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Binary Tree Level Order Traversal");
            BinaryTraverse.LayerOrder<string>(rootNode);
            Console.WriteLine();
            Console.WriteLine("Binary Tree Level Order Traversal using 2 Queue");
            BinaryTraverse.LevelOrderIterBy2Queue<string>(rootNode);
            Console.WriteLine();
            Console.WriteLine("Binary Tree Level Order Traversal using 1 Queue");
            BinaryTraverse.LevelOrderIterBy1Queue<string>(rootNode);
            Console.WriteLine();
            Console.WriteLine("Binary Tree Level Order Traversal using 1 Queue as output squence");
            BinaryTraverse.LevelOrderIterSequence<string>(rootNode);
            Console.Read();
        }
        #endregion
    }
}
