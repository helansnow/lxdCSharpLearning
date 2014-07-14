using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiTreeTravers
{
    #region 二叉树结点数据结构的定义
    //二叉树结点数据结构包括数据域，左右结点以及父结点成员；        
    public class BinaryTreeNode<T>
    {
        public T Data { get; set; }

        public BinaryTreeNode<T> LNode { get; set; }
        public BinaryTreeNode<T> RNode { get; set; }
        public BinaryTreeNode<T> PNode { get; set; }

        public BinaryTreeNode(BinaryTreeNode<T> node)
        {
            Data = node.Data;
            LNode = node.LNode;
            RNode = node.RNode;
            PNode = node.PNode;
        }

        public BinaryTreeNode(T data)
        {
            Data = data;
        }
    }

    #endregion
}
