using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree.BinarySearchTree.BreadthFirstSearch
{
    public class Q102BinaryTreeLevelOrderTraversal
    {
        public Q102BinaryTreeLevelOrderTraversal()
        {
            //TreeNode sen = new TreeNode(1) { left = new TreeNode(2) { left = new TreeNode(3) { left = new TreeNode(4) { left = new TreeNode(5) } } } };

            //var result = ob.LevelOrder(tbs);
        }

        /// <summary>
        /// 學來的
        /// 迭代解法
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder3(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null)
                return result;

            Queue<TreeNode> que = new Queue<TreeNode>();

            que.Enqueue(root);
            while (que.Count != 0)
            {
                int levelCount = que.Count;
                List<int> level = new List<int>();


                for (int i = 0; i < levelCount; i++)
                {
                    TreeNode node = que.Dequeue();
                    if (node != null)
                    {
                        level.Add(node.val);
                        que.Enqueue(node.left);
                        que.Enqueue(node.right);
                    }
                }
                if (level.Any())
                    result.Add(level);
            }

            return result;
        }

        /// <summary>
        /// 學來的
        /// 遞迴解法
        /// DFT
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder2(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>() { };

            helper(root, 0, result);

            return result;
        }

        public void helper(TreeNode node, int level, List<IList<int>> result)
        {
            if (node == null)
                return;

            if (level >= result.Count)
                result.Add(new List<int>());

            result[level].Add(node.val);
            if (node.left != null)
                helper(node.left, level + 1, result);
            if (node.right != null)
                helper(node.right, level + 1, result);
        }

        /// <summary>
        /// 學來的
        /// 跌代法
        /// 用迴圈來跑每層
        /// BFT
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder1(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>() { };

            if (root == null)
                return result;

            Queue<TreeNode> stack = new Queue<TreeNode>();

            stack.Enqueue(root);

            while (stack.Count != 0)
            {
                int levelNum = stack.Count;
                List<int> subList = new List<int>();

                for (int i = 0; i < levelNum; i++)
                {
                    TreeNode node = stack.Peek();
                    if (stack.Peek().left != null)
                        stack.Enqueue(stack.Peek().left);
                    if (stack.Peek().right != null)
                        stack.Enqueue(stack.Peek().right);
                    subList.Add(stack.Dequeue().val);
                }
                result.Add(subList);
            }

            return result;
        }

        /// <summary>
        /// 自己寫的
        /// 迭代解法
        /// BFT
        /// O(n)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>() { };

            if (root == null)
                return result;

            Queue<TreeNode> stack = new Queue<TreeNode>();
            Queue<int> level = new Queue<int>();

            level.Enqueue(0);
            stack.Enqueue(root);

            while (stack.Count != 0)
            {
                TreeNode node = stack.Dequeue();
                int lv = level.Dequeue();

                if (result.Count <= lv)
                    result.Add(new List<int>());
                if (node != null)
                {
                    result.Last().Add(node.val);

                    lv++;

                    if (node.left != null)
                    {
                        stack.Enqueue(node.left);
                        level.Enqueue(lv);
                    }
                    if (node.right != null)
                    {
                        stack.Enqueue(node.right);
                        level.Enqueue(lv);
                    }
                }
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
