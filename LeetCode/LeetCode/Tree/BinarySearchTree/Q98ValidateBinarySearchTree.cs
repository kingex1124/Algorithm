using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree
{
    public class Q98ValidateBinarySearchTree
    {
        public Q98ValidateBinarySearchTree()
        {
            //TreeNode tn = new TreeNode(10)
            //{
            //    left = new TreeNode(0)
            //    {
            //        left = new TreeNode(-1) { right = new TreeNode(15) },
            //        right = new TreeNode(4)
            //    },
            //    right = new TreeNode(12)
            //    {
            //        left = new TreeNode(11),
            //        right = new TreeNode(20)
            //        {
            //            left = new TreeNode(17),
            //            right = new TreeNode(99)
            //        }
            //    }
            //};

            //var result = ob.IsValidBST(tn);
        }

        public class ResultType1
        {
            public bool is_bst;
            public int? maxValue, minValue;

            public ResultType1(bool is_bst, int? minValue = null, int? maxValue = null)
            {
                this.is_bst = is_bst;
                this.maxValue = maxValue;
                this.minValue = minValue;
            }
        }

        /// <summary>
        /// 參考九章解法2改良的
        /// 分治法
        /// Time O(N)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST4(TreeNode root)
        {
            return validateHelper1(root).is_bst;
        }

        private ResultType1 validateHelper1(TreeNode root)
        {
            if (root == null)
                return new ResultType1(true);

            //取左邊、右邊最大、最小值
            ResultType1 left = validateHelper1(root.left);
            ResultType1 right = validateHelper1(root.right);

            // if is_bst is false then minValue and maxValue are useless
            if (!left.is_bst || !right.is_bst)
                return new ResultType1(false);

            //查看左邊最大值是否超過當下、右邊最小值是否小於當下
            if (root.left != null && left.maxValue >= root.val ||
                root.right != null && right.minValue <= root.val)
                return new ResultType1(false);

            //左邊取最小的值來比較，右邊取最大的值來比較
            return new ResultType1(true,
                left.minValue == null ? root.val : Math.Min(root.val, (int)left.minValue),
               right.maxValue == null ? root.val : Math.Max(root.val, (int)right.maxValue));
        }

        /// <summary>
        /// 九章解法3
        /// 跟自己寫的差不多
        /// 分治法
        /// Time O(N)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST3(TreeNode root)
        {
            return divConq(root);
        }

        private bool divConq(TreeNode root, int? min = null, int? max = null)
        {
            if (root == null)
                return true;
            if (root.val <= min || root.val >= max)
                return false;
            return divConq(root.left, min, root.val) &&
                divConq(root.right, root.val, max);
        }

        public class ResultType
        {
            public bool is_bst;
            public int maxValue, minValue;

            public ResultType(bool is_bst, int minValue, int maxValue)
            {
                this.is_bst = is_bst;
                this.maxValue = maxValue;
                this.minValue = minValue;
            }
        }

        /// <summary>
        /// 九章解法2
        /// 分治法
        /// Time O(N)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST2(TreeNode root)
        {
            return validateHelper(root).is_bst;
        }

        /// <summary>
        /// 此作法為，每個節點，都去取一個最大最小的範圍，然後往上比較
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private ResultType validateHelper(TreeNode root)
        {
            if (root == null)
                return new ResultType(true, int.MaxValue, int.MinValue);

            //取左邊、右邊最大、最小值
            ResultType left = validateHelper(root.left);
            ResultType right = validateHelper(root.right);

            // if is_bst is false then minValue and maxValue are useless
            if (!left.is_bst || !right.is_bst)
                return new ResultType(false, 0, 0);

            //查看左邊最大值是否超過當下、右邊最小值是否小於當下
            if (root.left != null && left.maxValue >= root.val ||
                root.right != null && right.minValue <= root.val)
                return new ResultType(false, 0, 0);

            //左邊取最小的值來比較，右邊取最大的值來比較
            //但是右邊會取max拿來跟頭比
            //左邊會取min拿來跟頭比
            return new ResultType(true, Math.Min(root.val, left.minValue),
                Math.Max(root.val, right.maxValue));
        }

        int lastVal = int.MinValue;
        bool firstNode = true;
        /// <summary>
        /// 九章解法1
        /// 先走到最左下方，取得最後一個值
        /// 最後一個值必定小於所有其他的值
        /// 應該說，後一個值必小於前一個值的root值
        /// DFS解法
        /// Time O(N)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST1(TreeNode root)
        {
            if (root == null)
                return true;
            if (!IsValidBST1(root.left))
                return false;
            if (!firstNode && lastVal >= root.val)
                return false;
            firstNode = false;
            lastVal = root.val;
            if (!IsValidBST1(root.right))
                return false;
            return true;
        }

        /// <summary>
        /// 改良學來的
        /// </summary>
        /// <param name="root"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public bool IsValidBST4(TreeNode root, int? min = null, int? max = null)
        {
            if (root == null)
                return true;

            if (root.val >= max ||
                root.val <= min)
                return false;

            if (!IsValidBST(root.left, min, root.val) ||
                !IsValidBST(root.right, root.val, max))
                return false;

            return true;
        }

        /// <summary>
        /// 課程上學來的解法
        /// 跟九章解法3差不多 
        /// 九章解法3只是把多個判斷是寫在同一個if裡用||分隔
        /// </summary>
        /// <param name="root"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public bool IsValidBST(TreeNode root, int? min = null, int? max = null)
        {
            if (root == null)
                return true;
            if (max != null && root.val >= max)
                return false;
            if (min != null && root.val <= min)
                return false;

            if (root.left != null && !IsValidBST(root.left, min, root.val))
                return false;
            if (root.right != null && !IsValidBST(root.right, root.val, max))
                return false;
            return true;
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
