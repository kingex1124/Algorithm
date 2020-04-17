using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree.BinarySearchTree
{
    public class Q1008ConstructBinarySearchTreeFromPreorderTraversal
    {
        public Q1008ConstructBinarySearchTreeFromPreorderTraversal()
        {

        }


        /// <summary>
        /// 學來的
        /// 遞迴解法
        /// 分治法
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="bound"></param>
        /// <returns></returns>
        int i = 0;
        public TreeNode BstFromPreorder2(int[] preorder, int bound = int.MaxValue)
        {
            if (i == preorder.Count() || preorder[i] > bound)
                return null;

            TreeNode root = new TreeNode(preorder[i++]);
            root.left = BstFromPreorder2(preorder, root.val);
            //沒有大過root上一層的值，就直接塞在root 右邊
            root.right = BstFromPreorder2(preorder, bound);
            return root;
        }

        /// <summary>
        /// 學來的
        /// 跌代解
        /// 用stack
        /// </summary>
        /// <param name="preorder"></param>
        /// <returns></returns>
        public TreeNode BstFromPreorder1(int[] preorder)
        {
            if (preorder == null || preorder.Count() == 0)
                return null;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode result = new TreeNode(preorder[0]);
            stack.Push(result);

            for (int i = 1; i < preorder.Count(); i++)
            {
                TreeNode node = new TreeNode(preorder[i]);
                if (node.val < stack.Peek().val)
                    stack.Peek().left = node;
                else
                {
                    TreeNode parent = stack.Peek();
                    //此處往回退，退完之後項右走
                    while (stack.Count != 0 && node.val > stack.Peek().val)
                        parent = stack.Pop();
                    parent.right = node;
                }
                stack.Push(node);
            }

            return result;
        }

        /// <summary>
        /// 自己寫的
        /// 迭代解法
        /// 最多 O(n!)
        /// </summary>
        /// <param name="preorder"></param>
        /// <returns></returns>
        public TreeNode BstFromPreorder(int[] preorder)
        {
            if (preorder == null || preorder.Count() == 0)
                return null;

            int start = 0;
            int end = preorder.Count();
            TreeNode result = new TreeNode(preorder[start]);
            start++;

            while (start < end)
            {
                TreeNode tmp = result;
                TreeNode lest = null;
                while (tmp != null)
                {
                    lest = tmp;
                    if (preorder[start] < tmp.val)
                        tmp = tmp.left;
                    else
                        tmp = tmp.right;
                }
                if (lest != null)
                {
                    if (preorder[start] < lest.val)
                        lest.left = new TreeNode(preorder[start]);
                    else
                        lest.right = new TreeNode(preorder[start]);
                }

                start++;
            }
            return result;
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
