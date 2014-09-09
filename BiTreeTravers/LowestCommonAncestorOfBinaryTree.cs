using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiTreeTravers
{
    class LowestCommonAncestorOfBinaryTree
    {
        static public BinaryTreeNode<string> LowestCommonAncestor(BinaryTreeNode<string> bFirst, BinaryTreeNode<string> bSecond)
        {
            int first = 0;
            int second = 0;
            BinaryTreeNode<string> tFirst = bFirst;
            BinaryTreeNode<string> tSecond = bSecond;

            while (tFirst.PNode != null)
            {
                tFirst = tFirst.PNode;
                first++;
            }
            while (tSecond.PNode != null)
            {
                tSecond = tSecond.PNode;
                second++;
            }

            if (first > second)
            {
                tFirst = bFirst;
                tSecond = bSecond;
            }
            else
            {
                tFirst = bSecond;
                tSecond = bFirst;
                int temp = first;
                first = second;
                second = temp;
            }

            var diff = first - second;
            while (diff > 0 )
            {
                tFirst = tFirst.PNode;
                diff--;
                if(tFirst==null)
                    break;
            }

            while (tFirst != null && tSecond != null)
            {
                if (tFirst == tSecond)
                {
                    return tFirst;
                }

                tFirst = tFirst.PNode;
                tSecond = tSecond.PNode;
            }
            return null;
        }
    }
}
