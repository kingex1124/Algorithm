using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LeetCode.LeetCode.Tree
{
    public class Q700SearchInABinarySearchTree
    {
        public Q700SearchInABinarySearchTree()
        {

        }

        /// <summary>
        /// 自己寫的
        /// 同九章
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null || root.val == val)
                return root;
            else
            {
                if (val < root.val)
                    return SearchBST(root.left, val);
                else
                    return SearchBST(root.right, val);
            }
        }

        /// <summary>
        /// 另一種寫法
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public TreeNode SearchBST1(TreeNode root, int val)
        {
            if (root == null || root.val == val)
                return root;
            else
            {
                TreeNode tmp = root;

                while (tmp != null)
                {
                    if (val < tmp.val)
                        tmp = tmp.left;
                    else if (val > tmp.val)
                        tmp = tmp.right;
                    else
                        return tmp;
                }
                return null;
            }
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}