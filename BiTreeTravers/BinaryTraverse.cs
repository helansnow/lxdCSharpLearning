//  http://developer.51cto.com/art/200908/143290.htm
//  http://blog.csdn.net/sgbfblog/article/details/7773103
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace BiTreeTravers
{
    public class BinaryTraverse
    {
 
        #region 先序编历二叉树
        public static void PreOrder<T>(BinaryTreeNode<T> rootNode)
        {
            if (rootNode != null)
            {
                Console.Write("{0}, ", rootNode.Data);
                PreOrder<T>(rootNode.LNode);
                PreOrder<T>(rootNode.RNode);
            }
        }

        public static void preOrderIter<T>(BinaryTreeNode<T> root)  
        {  
            if (root == null) return;  
            var s = new Stack<BinaryTreeNode<T>>();  
            s.Push(root);  
            while (s.Count !=0) 
            {  
                BinaryTreeNode<T> nd = s.Peek();
                Console.Write("{0}, ", nd.Data);
                s.Pop();  
                if (nd.RNode != null)  
                    s.Push(nd.RNode);  
                if (nd.LNode != null)  
                    s.Push(nd.LNode);  
            }
             
            Console.WriteLine();
        }

        public static void preOrderIter2<T>(BinaryTreeNode<T> root)
        {
            var s = new Stack<BinaryTreeNode<T>>();
            while (root != null || s.Count != 0)
            {
                if (root != null) //Or using while here
                {
                    Console.Write("{0}, ", root.Data);  //访问结点并入栈  
                    s.Push(root);
                    root = root.LNode;         //访问左子树  
                }
                else //root == null => leaf node 
                {
                    root = s.Peek();            //回溯至父亲结点  
                    s.Pop();
                    root = root.RNode;        //访问右子树  
                }
            }

            Console.WriteLine();
        }  
        #endregion

        #region 中序遍历二叉树
        public static void MidOrder<T>(BinaryTreeNode<T> rootNode)
        {
            if (rootNode != null)
            {
                MidOrder<T>(rootNode.LNode);
                Console.Write("{0}, ", rootNode.Data);
                MidOrder<T>(rootNode.RNode);
            }
        }

        public static void inOrderIter<T>(BinaryTreeNode<T> root)
        {
            var s = new Stack<BinaryTreeNode<T>>();
            while (root != null || s.Count != 0)
            {
                if (root != null)
                {
                    s.Push(root);
                    root = root.LNode;
                }
                else
                {
                    root = s.Peek();
                    Console.Write("{0}, ", root.Data); //访问完左子树后才访问根结点  
                    s.Pop();
                    root = root.RNode;          //访问右子树  
                }
            }
            Console.WriteLine();
        }  
        #endregion 

        #region 后序遍历二叉树
        public static void AfterOrder<T>(BinaryTreeNode<T> rootNode)
        {
            if (rootNode != null)
            {
                AfterOrder<T>(rootNode.LNode);
                AfterOrder<T>(rootNode.RNode);
                Console.Write("{0}, ", rootNode.Data);
            }
        }

        /*
         * Push根结点到第一个栈s中。
         * 从第一个栈s中Pop出一个结点，并将其Push到第二个栈output中。
         * 然后Push结点的左孩子和右孩子到第一个栈s中。
         * 重复过程2和3直到栈s为空。
         * 完成后，所有结点已经Push到栈output中，
         * 且按照后序遍历的顺序存放，直接全部Pop出来即是二叉树后序遍历结果。
         */
        public static void postOrderIter<T>(BinaryTreeNode<T> root)  
        {  
            if (root == null) return;  
            var s = new Stack<BinaryTreeNode<T>>();  
            var output = new Stack<BinaryTreeNode<T>>();  
            s.Push(root);  
            while (s.Count != 0) 
            {  
               BinaryTreeNode<T> curr = s.Peek();  
                output.Push(curr);  
                s.Pop();  
                if (curr.LNode !=null)  
                    s.Push(curr.LNode);  
                if (curr.RNode !=null)  
                    s.Push(curr.RNode);  
            }  
      
            while (output.Count != 0) 
            {  
                var nd = output.Peek();
                Console.Write("{0}, ", nd.Data);
                output.Pop();  
            }

            Console.WriteLine();
        }

        /*
         * We use a prev variable to keep track of the previously-traversed node. 
         * 
         * Let’s assume curr is the current node that’s on top of the stack. When prev is curr‘s parent, we are traversing down the tree. 
         * In this case, we try to traverse to curr‘s left child if available (ie, push left child to the stack). 
         * If it is not available, we look at curr‘s right child. 
         * If both left and right child do not exist (ie, curr is a leaf node), 
         * we print curr‘s value and pop it off the stack.
         * 
         * If prev is curr‘s left child, we are traversing up the tree from the left. We look at curr‘s right child. 
         * If it is available, then traverse down the right child (ie, push right child to the stack), 
         * otherwise print curr‘s value and pop it off the stack.
         * 
         * If prev is curr‘s right child, we are traversing up the tree from the right. 
         * In this case, we print curr‘s value and pop it off the stack.
         */
        public static void postOrderTraversalIterative<T>(BinaryTreeNode<T> root)
        {
            if (root == null) return;
            var s = new Stack<BinaryTreeNode<T>>();  
            s.Push(root);
            BinaryTreeNode<T> prev = null;
            while (0 !=s.Count)
            {
                BinaryTreeNode<T> curr = s.Peek();
                // we are traversing down the tree
                if (null == prev ||  (prev.LNode == curr) || (prev.RNode == curr))
                {
                    if (curr.LNode != null)
                    {
                        s.Push(curr.LNode);
                    }
                    else if (curr.RNode !=null)
                    {
                        s.Push(curr.RNode);
                    }
                    else
                    {
                        Console.Write("{0}, ", curr.Data);
                        s.Pop();
                    }
                }
                // we are traversing up the tree from the left
                else if (curr.LNode == prev)
                {
                    if (curr.RNode != null)
                    {
                        s.Push(curr.RNode);
                    }
                    else
                    {
                        Console.Write("{0}, ", curr.Data);
                        s.Pop();
                    }
                }
                // we are traversing up the tree from the right
                else if (curr.RNode == prev)
                {
                    Console.Write("{0}, ", curr.Data);
                    s.Pop();
                }
                prev = curr;  // record previously traversed node
            }
        }

        /*
         * The above method is easy to follow, but has some redundant code. 
         * We could refactor out the redundant code, and now it appears to be more concise. 
         * Note how the code section for printing curr‘s value get refactored into one single else block. 
         * Don’t worry about in an iteration where its value won’t get printed, 
         * as it is guaranteed to enter the else section in the next iteration.
         */
        public static void postOrderTraversalIterative2<T>(BinaryTreeNode<T> root)
        {
            if (root == null) return;
            var s = new Stack<BinaryTreeNode<T>>();
            s.Push(root);
            BinaryTreeNode<T> prev = null;
            while (0 != s.Count)
            {
                BinaryTreeNode<T> curr = s.Peek();
                // we are traversing down the tree
                if (null == prev || (prev.LNode == curr) || (prev.RNode == curr))
                {
                    if (curr.LNode != null)
                    {
                        s.Push(curr.LNode);
                    }
                    else if (curr.RNode != null)
                    {
                        s.Push(curr.RNode);
                    }              
                }
                // we are traversing up the tree from the left
                else if (curr.LNode == prev)
                {
                    if (curr.RNode != null)
                    {
                        s.Push(curr.RNode);
                    }
                    else
                    {
                        Console.Write("{0}, ", curr.Data);
                        s.Pop();
                    }
                }
               
                prev = curr;  // record previously traversed node
            }
        }
        #endregion

        #region 层次遍历二叉树
        public static void LayerOrder<T>(BinaryTreeNode<T> rootNode)
        {
            BinaryTreeNode<T>[] Nodes = new BinaryTreeNode<T>[20];
            int front = -1;
            int rear = -1;
            if (rootNode != null)
            {
                rear++;
                Nodes[rear] = rootNode;
            }
            while (front != rear)
            {
                front++;
                rootNode = Nodes[front];
                Console.Write("{0}, ", rootNode.Data);
                if (rootNode.LNode != null)
                {
                    rear++;
                    Nodes[rear] = rootNode.LNode;
                }
                if (rootNode.RNode != null)
                {
                    rear++;
                    Nodes[rear] = rootNode.RNode;
                }
            }
        }

        /*
         * 方法一：使用两个队列
         * 第一个队列currentLevel用于存储当前层的结点，第二个队列nextLevel用于存储下一层的结点。
         * 当前层currentLevel为空时，表示这一层已经遍历完成，可以打印换行符了。
         * 然后将第一个空的队列currentLevel与队列nextLevel交换，然后重复该过程直到结束。
         */
        public static void LevelOrderIterBy2Queue<T>(BinaryTreeNode<T> root) 
        {  
            if (root==null) return;  
            var currentLevel = new Queue<BinaryTreeNode<T>>();
            var nextLevel = new Queue<BinaryTreeNode<T>>();
 
            currentLevel.Enqueue(root);  
            while (currentLevel.Count !=0) 
            {  
                var currNode = currentLevel.Peek();  
                currentLevel.Dequeue();  
        
                if (currNode!=null) 
                {
                    Console.Write("{0}, ", currNode.Data );  
                    nextLevel.Enqueue(currNode.LNode);  
                    nextLevel.Enqueue(currNode.RNode);  
                }  
                if (currentLevel.Count ==0) 
                {
                    Console.WriteLine();//此次结束，换行打印下一层
                    //var qTemp = currentLevel;
                    //currentLevel = nextLevel;
                    //nextLevel = qTemp;
                    swap( currentLevel,  nextLevel);  
                }  
            }
            Console.WriteLine();
        }

        static void swap<T>( Queue<BinaryTreeNode<T>> curr,  Queue<BinaryTreeNode<T>> next)  
        {
            while (next.Count != 0)
            {  
                BinaryTreeNode<T> nd = next.Peek();  
                next.Dequeue();  
                curr.Enqueue(nd);  
            }  
        }

        /*
         * 方法二：使用一个队列
         * 只使用一个队列的话，需要额外的两个变量来保存当前层结点数目以及下一层的结点数目。
         */
        public static void LevelOrderIterBy1Queue<T>(BinaryTreeNode<T> root)
        {
            if (root == null) return;

            var nodesQueue = new Queue<BinaryTreeNode<T>>();
            int nodesInCurrentLevel = 1;
            int nodesInNextLevel = 0;

            nodesQueue.Enqueue(root);
            while (nodesQueue.Count != 0)
            {
                BinaryTreeNode<T> currNode = nodesQueue.Peek();
                nodesQueue.Dequeue();
                nodesInCurrentLevel--;
                if (currNode != null)
                {
                    Console.Write("{0}, ", currNode.Data);
                    nodesQueue.Enqueue(currNode.LNode);
                    nodesQueue.Enqueue(currNode.RNode);
                    nodesInNextLevel += 2;
                }
                if (nodesInCurrentLevel == 0)
                {
                    Console.WriteLine();
                    nodesInCurrentLevel = nodesInNextLevel;
                    nodesInNextLevel = 0;
                }
            }
        }

        public static void LevelOrderIterSequence<T>(BinaryTreeNode<T> root)
        {
            if (root == null) return;

            var nodesQueue = new Queue<BinaryTreeNode<T>>();

            nodesQueue.Enqueue(root);
            while (nodesQueue.Count != 0)
            {
                BinaryTreeNode<T> currNode = nodesQueue.Peek();
                Console.Write("{0}, ",currNode.Data);
                nodesQueue.Dequeue();

                if (currNode.LNode != null)
                    nodesQueue.Enqueue(currNode.LNode);
                if (currNode.RNode != null)
                    nodesQueue.Enqueue(currNode.RNode);
            }
        }

        #endregion
    }
}