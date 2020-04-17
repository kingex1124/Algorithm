using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree.BinaryTree
{
    public class Q173BinarySearchTreeIterator
    {
        public Q173BinarySearchTreeIterator()
        {
            //TreeNode tbs = new TreeNode(7) { left = new TreeNode(3), right = new TreeNode(15) { left = new TreeNode(9), right = new TreeNode(20) } };
            ////TreeNode test = ob.BuildTreeByList(new List<int?>() { 3, 9, 20, null, null, 15, 7 });
            //BSTIterator iterator = new BSTIterator(tbs);
            //iterator.Next();    // return 3
            //iterator.Next();    // return 7
            //iterator.HasNext(); // return true
            //iterator.Next();    // return 9
            //iterator.HasNext(); // return true
            //iterator.Next();    // return 15
            //iterator.HasNext(); // return true
            //iterator.Next();    // return 20
            //iterator.HasNext(); // return false
        }

        /// <summary>
        /// 學來的
        /// </summary>
        public class BSTIterator1
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            public BSTIterator1(TreeNode root)
            {
                PushAll(root);
            }

            public void PushAll(TreeNode node)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }
            }

            /** @return the next smallest number */
            public int Next()
            {
                TreeNode node = stack.Pop();
                PushAll(node.right);
                return node.val;
            }

            /** @return whether we have a next smallest number */
            public bool HasNext()
            {
                return stack.Count != 0;
            }
        }


        /// <summary>
        /// 參考九章的解法改良的
        /// </summary>
        public class BSTIterator
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            public BSTIterator(TreeNode root)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
            }

            /** @return the next smallest number */
            public int Next()
            {
                TreeNode cur = stack.Pop();
                TreeNode node = cur;

                if (node.right != null)
                {
                    node = node.right;
                    while (node != null)
                    {
                        stack.Push(node);
                        node = node.left;
                    }
                }
                return cur.val;
            }

            /** @return whether we have a next smallest number */
            public bool HasNext()
            {
                return stack.Count != 0;
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
