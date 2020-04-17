using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Lintcode.Tree.BinaryTree
{
    public class Q597SubtreeWithMaximumAverage
    {
        public Q597SubtreeWithMaximumAverage()
        {

        }

        public class ResultType
        {
            public int sum, size;
            public ResultType(int sum, int size)
            {
                this.sum = sum;
                this.size = size;
            }
        }

        private TreeNode subtree = null;
        private ResultType subtreeResult = null;

        /// <summary>
        /// 九章
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode FindSubtree2(TreeNode root)
        {
            Helper(root);
            return subtree;
        }

        public ResultType Helper(TreeNode root)
        {
            if (root == null)
                return new ResultType(0, 0);

            // 分治法计算左右子树的平均值
            ResultType left = Helper(root.left);

            ResultType right = Helper(root.right);
            // 当前subtree的结果是左右两颗子树的和的平均值加上自身
            ResultType result = new ResultType(left.sum + right.sum + root.val,
                left.size + right.size + 1);
            // 打擂台比较得到最大平均值的子树 用乘的才不會有除不盡的問題
            if (subtree == null ||
                subtreeResult.sum * result.size < result.sum * subtreeResult.size)
            {
                subtree = root;
                subtreeResult = result;
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
