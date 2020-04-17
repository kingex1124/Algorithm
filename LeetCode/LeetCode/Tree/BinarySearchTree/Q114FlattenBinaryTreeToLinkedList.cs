using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree.BinaryTree
{
    public class Q114FlattenBinaryTreeToLinkedList
    {
        public Q114FlattenBinaryTreeToLinkedList()
        {
            //TreeNode tn = new TreeNode(1) { left = new TreeNode(2) { left = new TreeNode(4), right = new TreeNode(5) }, right = new TreeNode(3) { left = new TreeNode(6), right = new TreeNode(7) } };
            //ob.Flatten(tn);
        }

        /// <summary>
        /// 學來的跌代解(請參考筆記)
        /// 先把右邊子樹，放在左子樹，最右下邊
        /// 然後再把左子樹整顆放到右子樹，再把左子樹變成null
        /// 然後往右子樹走下一步
        /// </summary>
        /// <param name="root"></param>
        public void Flatten3(TreeNode root)
        {
            TreeNode cur = root;
            while (cur != null)
            {
                if (cur.left != null)
                {
                    TreeNode last = cur.left;
                    while (last.right != null)
                        last = last.right;
                    last.right = cur.right;
                    cur.right = cur.left;
                    cur.left = null;
                }
                cur = cur.right;
            }
        }

        /// <summary>
        /// 九章遞迴解
        /// 同Flatten3說明
        /// 差別只在於它是走到底從葉子搬
        /// </summary>
        /// <param name="root"></param>
        public void Flatten2(TreeNode root)
        {
            Helper(root);
        }

        private TreeNode Helper(TreeNode node)
        {
            if (node == null)
                return null;

            TreeNode left = Helper(node.left);
            TreeNode right = Helper(node.right);
            if (left != null)
            {
                left.right = node.right;
                node.right = node.left;
                node.left = null;
            }

            if (right != null)
                return right;
            if (left != null)
                return left;
            return node;
        }

        /// <summary>
        /// 跌代解2
        /// 學來的
        /// </summary>
        /// <param name="root"></param>
        public void Flatten1(TreeNode root)
        {
            if (root == null)
                return;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            TreeNode pre = null;
            while (stack.Count != 0)
            {
                TreeNode curr = stack.Pop();

                if(pre !=null)
                {
                    pre.right = curr;
                    pre.left = null;
                }
                if (curr.right != null)
                    stack.Push(curr.right);
                if (curr.left != null)
                    stack.Push(curr.left);
                pre = curr;
            }
        }


        /// <summary>
        /// 學來的
        /// 跌代解
        /// Stack
        /// </summary>
        /// <param name="root"></param>
        public void Flatten(TreeNode root)
        {
            if (root == null)
                return;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count != 0)
            {
                TreeNode node = stack.Pop();

                if (node.right != null)
                    stack.Push(node.right);
                if (node.left != null)
                    stack.Push(node.left);
                //因為有可能取出來之後，就沒有再塞東西進去(最後一個)
                //右邊節點塞下一個子樹
                if (stack.Count() != 0)
                    node.right = stack.Peek();
                node.left = null;
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
