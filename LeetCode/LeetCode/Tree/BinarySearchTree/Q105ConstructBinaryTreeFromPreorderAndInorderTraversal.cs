using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree.BinarySearchTree
{
    public class Q105ConstructBinaryTreeFromPreorderAndInorderTraversal
    {
        public Q105ConstructBinaryTreeFromPreorderAndInorderTraversal()
        {

        }

        /// <summary>
        /// 學來的
        /// 跌代解
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        /// <returns></returns>
        public TreeNode BuildTree2(int[] preorder, int[] inorder)
        {
            if (preorder.Length == 0)
                return null;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode root = new TreeNode(preorder[0]);
            TreeNode curr = root;

            for (int i = 1, j = 0; i < preorder.Length; i++)
            {
                if (curr.val != inorder[j])
                {
                    curr.left = new TreeNode(preorder[i]);
                    stack.Push(curr);
                    curr = curr.left;
                }
                else
                {
                    j++;
                    while (stack.Count != 0 && stack.Peek().val == inorder[j])
                    {
                        curr = stack.Pop();
                        j++;
                    }
                    curr = curr.right = new TreeNode(preorder[i]);
                }
            }
            return root;
        }

        /// <summary>
        /// 九章解法
        /// 遞迴
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        /// <returns></returns>
        public TreeNode BuildTree1(int[] preorder, int[] inorder)
        {
            if (preorder.Length != inorder.Length)
                return null;
            return MyBuildTree(inorder, 0, inorder.Length - 1, preorder, 0, preorder.Length - 1);
        }

        private TreeNode MyBuildTree(int[] inorder, int inStart, int inEnd, int[] preorder, int preStart, int preEnd)
        {
            if (inStart > inEnd || preStart > preEnd)
                return null;

            TreeNode root = new TreeNode(preorder[preStart]);

            int position = FindPosition(inorder, inStart, inEnd, preorder[preStart]);

            root.left = MyBuildTree(inorder, inStart, position - 1, preorder, preStart + 1, preStart + position - inStart);
            root.right = MyBuildTree(inorder, position + 1, inEnd, preorder, position - inStart + preStart + 1, preEnd);
            return root;
        }

        private int FindPosition(int[] inorder, int inStart, int inEnd, int preStartVal)
        {
            for (int i = inStart; i <= inEnd; i++)
            {
                if (inorder[i] == preStartVal)
                    return i;
            }
            return -1;
        }


        /// <summary>
        /// 學來的
        /// 遞迴解法
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        /// <returns></returns>
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            return Helper(0, 0, inorder.Length - 1, preorder, inorder);
        }

        public TreeNode Helper(int preStart, int inStart, int inEnd, int[] preorder, int[] inorder)
        {
            //兩個陣列頭不能超過長度 超過就回傳null
            if (preStart > preorder.Length - 1 || inStart > inEnd)
                return null;

            TreeNode root = new TreeNode(preorder[preStart]);
            int inIndex = 0;
            for (int i = inStart; i <= inEnd; i++)
            {
                if (inorder[i] == root.val)
                    inIndex = i;
            }
            //inIndex - 1 與前序相同值，為中序根，小於根為左半邊的所有值
            //意思是 下一個前序的值 一定小於中序的前一個值(index)
            root.left = Helper(preStart + 1, inStart, inIndex - 1, preorder, inorder);
            //前序的右邊為 前一個值的中序+1(右半邊)扣去以走的位置+1
            //中序的右半邊+1 必能找到對應 前序的右邊的值
            root.right = Helper(preStart + inIndex - inStart + 1, inIndex + 1, inEnd, preorder, inorder);
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
