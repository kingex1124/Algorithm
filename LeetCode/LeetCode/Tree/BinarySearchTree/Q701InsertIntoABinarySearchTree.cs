using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree
{
    public class Q701InsertIntoABinarySearchTree
    {
        public Q701InsertIntoABinarySearchTree()
        {

        }

        /// <summary>
        /// 學來的
        /// 同九章解法2
        /// 遞迴 分治法
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public TreeNode InsertIntoBST1(TreeNode root, int val)
        {
            if (root == null)
                return new TreeNode(val);
            else
            {
                if (val < root.val)
                    root.left = InsertIntoBST(root.left, val);
                else if (val > root.val)
                    root.right = InsertIntoBST(root.right, val);
                return root;
            }
        }

        /// <summary>
        /// 九章解法1
        /// 跌代
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public TreeNode InsertIntoBST2(TreeNode root, int val)
        {
            if (root == null)
                return new TreeNode(val);
            else
            {
                TreeNode tmp = root;
                TreeNode lest = null;
                while (tmp != null)
                {
                    lest = tmp;
                    if (val < tmp.val)
                        tmp = tmp.left;
                    else
                        tmp = tmp.right;
                }
                if (lest != null)
                {
                    if (val < lest.val)
                        lest.left = new TreeNode(val);
                    else
                        lest.right = new TreeNode(val);
                }
                return root;
            }
        }

        /// <summary>
        /// 自己寫的
        /// 遞迴
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null)
                return new TreeNode(val);
            else
            {
                if (val < root.val && root.left != null)
                    InsertIntoBST(root.left, val);
                else if (val < root.val)
                    root.left = new TreeNode(val);
                else if (val > root.val && root.right != null)
                    InsertIntoBST(root.right, val);
                else if (val > root.val)
                    root.right = new TreeNode(val);
                return root;
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
