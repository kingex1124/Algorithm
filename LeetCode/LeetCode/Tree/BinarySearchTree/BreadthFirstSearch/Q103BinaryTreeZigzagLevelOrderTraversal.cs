using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree.BinarySearchTree.BreadthFirstSearch
{
    public class Q103BinaryTreeZigzagLevelOrderTraversal
    {
        public Q103BinaryTreeZigzagLevelOrderTraversal()
        {

        }

        /// <summary>
        /// 學來的
        /// 遞迴解
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> ZigzagLevelOrder2(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>() { };

            helper(root, 0, result);

            return result;
        }

        private void helper(TreeNode node, int level, List<IList<int>> result)
        {
            if (node == null)
                return;

            if (level >= result.Count)
                result.Add(new List<int>());

            if (level % 2 == 0)
                result[level].Add(node.val);
            else
                result[level].Insert(0, node.val);
            helper(node.left, level + 1, result);
            helper(node.right, level + 1, result);
        }

        /// <summary>
        /// 原本做法沒寫出來，後來看網路上的改良的
        /// 迭代解法
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> ZigzagLevelOrder1(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null)
                return result;

            Queue<TreeNode> que = new Queue<TreeNode>();

            que.Enqueue(root);
            int dir = 0;
            while (que.Count != 0)
            {
                int levelCount = que.Count;
                List<int> level = new List<int>();

                for (int i = 0; i < levelCount; i++)
                {
                    TreeNode node = que.Dequeue();

                    if (dir % 2 == 0)
                        level.Add(node.val);
                    else
                        level.Insert(0, node.val);
                    if (node.left != null)
                        que.Enqueue(node.left);
                    if (node.right != null)
                        que.Enqueue(node.right);
                }
                result.Add(level);
                dir++;
            }

            return result;
        }

        /// <summary>
        /// 學來的
        /// 迭代解法
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null)
                return result;

            Queue<TreeNode> que = new Queue<TreeNode>();
            que.Enqueue(root);

            int dir = 0;

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
                if(level.Any())
                {
                    if (dir % 2 == 1)
                    {
                        // level.Reverse();
                        int start = 0;
                        int end = level.Count - 1;
                        while (start < end)
                        {
                            var tmp = level[start];
                            level[start++] = level[end];
                            level[end--] = tmp;
                        }
                    }
                    result.Add(level);
                }
                dir++;
            }
            return result;
        }

        /// <summary>
        /// 學來的
        /// 用keyValue 的方式
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> ZigzagLevelOrder3(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>() { };

            Queue<KeyValuePair<TreeNode, int>> que = new Queue<KeyValuePair<TreeNode, int>>();
            que.Enqueue(new KeyValuePair<TreeNode, int>(root, 0));

            while (que.Count != 0)
            {
                KeyValuePair<TreeNode, int> pair = que.Dequeue();
                TreeNode node = pair.Key;
                int level = pair.Value;
                if (node != null)
                {
                    if (level == result.Count)
                        result.Add(new List<int>());
                    if (level % 2 == 0)
                        result[level].Add(node.val);
                    else
                        result[level].Insert(0, node.val);
                    que.Enqueue(new KeyValuePair<TreeNode, int>(node.left, level + 1));
                    que.Enqueue(new KeyValuePair<TreeNode, int>(node.right, level + 1));
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
