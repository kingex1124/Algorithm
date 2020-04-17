using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree.BinarySearchTree.BreadthFirstSearch
{
    public class Q107BinaryTreeLevelOrderTraversalII
    {
        public Q107BinaryTreeLevelOrderTraversalII()
        {

        }

        /// <summary>
        /// 學來的
        /// 遞迴解法
        /// DFT
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrderBottom2(TreeNode root)
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
                result.Insert(0, new List<int>());

            result[result.Count - 1 - level].Add(node.val);
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
        public IList<IList<int>> LevelOrderBottom1(TreeNode root)
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
                result.Insert(0, subList);
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
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();

            if (root == null)
                return result;

            Queue<TreeNode> que = new Queue<TreeNode>();
            Queue<int> level = new Queue<int>();

            que.Enqueue(root);
            level.Enqueue(0);

            while (que.Count != 0)
            {
                TreeNode node = que.Dequeue();
                int lev = level.Dequeue();

                if (lev >= result.Count)
                    result.Insert(0, new List<int>());
                if (node != null)
                {
                    result[0].Add(node.val);
                    lev++;
                    if (node.left != null)
                    {
                        que.Enqueue(node.left);
                        level.Enqueue(lev);
                    }
                    if (node.right != null)
                    {
                        que.Enqueue(node.right);
                        level.Enqueue(lev);
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
