using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree.BinaryTree
{
    public class Q235LowestCommonAncestorOfABinarySearchTree
    {
        public Q235LowestCommonAncestorOfABinarySearchTree()
        {

        }

        /// <summary>
        /// 遞迴解法
        /// 參考九章
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor2(TreeNode root, TreeNode p, TreeNode q)
        {
            int parentVal = root.val;

            int pVal = p.val;

            int qVal = q.val;

            //從側往下走，異側自身為父
            if (pVal > parentVal && qVal > parentVal)
                return LowestCommonAncestor2(root.right, p, q);
            else if (pVal < parentVal && qVal < parentVal)
                return LowestCommonAncestor2(root.left, p, q);
            else
                return root;
        }

        /// <summary>
        /// 遞迴解法
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor1(TreeNode root, TreeNode p, TreeNode q)
        {
            //++時 root 大於 p q --時 root 小於 p q (p q同側)
            //+-時 表示 p q分散於左右兩側的tree 所以 root 為父 ( p q 異側)
            return (root.val - p.val) * (root.val - q.val) > 0 ?
                LowestCommonAncestor1(p.val < root.val ? root.left : root.right, p, q) : root;
        }

        /// <summary>
        /// 跌代解法
        /// 學來的
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            //++時 root 大於 p q --時 root 小於 p q (p q同側)
            //+-時 表示 p q分散於左右兩側的tree 所以 root 為父 ( p q 異側)
            while ((root.val - p.val) * (root.val - q.val) > 0)
                root = p.val < root.val ? root.left : root.right;
            return root;
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
