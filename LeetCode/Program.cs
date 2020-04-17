using LeetCode.AlgorithmHelp;
using LeetCode.Helper;
using LeetCode.LeetCode.Tree.BinarySearchTree.BreadthFirstSearch;
using LeetCode.Lintcode.Tree.Graph;
using LeetCode.Solution;
using LeetCode.Udemy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {

            Program ob = new Program() { };

            Stopwatch sw = new Stopwatch();
            sw.Reset();
            sw = Stopwatch.StartNew();

            #region 建構樹

            var problemTree = ob.BuildBFTTree(new List<int?>() { 3, 9, 20, null, null, 15, 7 });
            var problemTree2 = ob.BuildBFTTree2("1,2,3,#,#,4,5,#,#");
            int[] a1 = { 3, 9, 20, 15, 7 };
            int[] a2 = { 9, 3, 15, 20, 7 };

            #endregion


            //Console.WriteLine(head.val);
            //Console.WriteLine(head.next.val);
            //Console.WriteLine(head.next.next.val);
            //Console.WriteLine(head.next.next.next.val);
            //Console.WriteLine(head.next.next.next.next.val);
            ListNode node1 = new ListNode(-10);
            ListNode node2 = new ListNode(-3);
            ListNode node3 = new ListNode(0);
            ListNode node4 = new ListNode(5);
            ListNode node5 = new ListNode(9);
            //ListNode node6 = new ListNode(6);

           

            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            //node5.next = node6;

            //ob.ReorderList(node1);

          
             // var result = ob.FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 3 ,4});

             //var result = ob.RotateRight(node1, 2);
             Sorting st = new Sorting();

            //var result = ob.ReverseKGroup(node1, 2);

            #region 先收起來

            ListNode tmp = node1.next;
            node1.next = null;


            ListNode head = node1;

            ob.print(head);
            //把 node1 指向2
            //但不代表 head 也指向2的位置 head 還是指著1的位置
            node1 = node2;
            ob.print(head);

            #endregion

            sw.Stop();
            long ms = sw.ElapsedMilliseconds;
            Console.WriteLine("花費 {0} 毫秒", ms);
        }

        
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (nums.Length < 4)
                return result;
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;
                for (int j = i+1; j < nums.Length - 2; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1])
                        continue;
                    int low = j + 1;
                    int high = nums.Length - 1;
                    while (low < high)
                    {
                        int sum = nums[i] + nums[j] + nums[low] + nums[high];
                        if (sum == target)
                        {
                            result.Add(new List<int>() { nums[i], nums[j], nums[low], nums[high] });
                            while (low < high && nums[low] == nums[low + 1])
                                low++;
                            while (low < high && nums[high] == nums[high - 1])
                                high--;
                            low++;
                            high--;
                        }
                        else if (sum < target)
                            low++;
                        else
                            high--;
                    }
                }  
            }
            return result;
        }

        public void print(ListNode node)
        {
            while (node != null)
            {
                Console.Write(node.val);
                Console.Write("->");
                node = node.next;
            }
            Console.WriteLine("null");
        }

        #region 建構樹方法

        /// <summary>
        /// 學來的
        /// BFS 建構樹方法
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public TreeNode BuildBFTTree2(string data)
        {
            if (data.Length == 0)
                return null;
            string[] node = data.Split(',');
            Queue<TreeNode> que = new Queue<TreeNode>();
            TreeNode root = new TreeNode(Convert.ToInt32(node[0]));
            que.Enqueue(root);

            int i = 1;
            while (que.Count != 0)
            {
                Queue<TreeNode> nextQue = new Queue<TreeNode>();
                while (que.Count != 0 && i < node.Length)
                {
                    TreeNode curr = que.Dequeue();
                    if (node[i] == "#")
                        curr.left = null;
                    else
                    {
                        curr.left = new TreeNode(Convert.ToInt32(node[i]));
                        nextQue.Enqueue(curr.left);
                    }
                    i++;
                    if (node[i] == "#")
                        curr.right = null;
                    else
                    {
                        curr.right = new TreeNode(Convert.ToInt32(node[i]));
                        nextQue.Enqueue(curr.right);
                    }
                    i++;
                }
                que = nextQue;
            }
            return root;
        }

        /// <summary>
        /// 自己寫的建構樹方法
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>

        public TreeNode BuildBFTTree(List<int?> list)
        {
            if (list.Count == 0)
                return null;

            TreeNode result = new TreeNode((int)list[0]);
            list.RemoveAt(0);

            int level = 1;
            double count = 0;
            TreeNode curr = result;

            Queue<TreeNode> upTree = new Queue<TreeNode>();
            upTree.Enqueue(curr);

            while (list.Count != 0)
            {
                if (count == 0)
                {
                    level++;
                    count = Math.Pow(2, level);
                }
                TreeNode tmp = upTree.Dequeue();
                if (list.Count != 0 && tmp != null)
                {
                    if (list.Count == 0 || count == 0)
                        break;
                    tmp.left = list[0] == null ? null : new TreeNode((int)list[0]);
                    list.RemoveAt(0);
                    count--;
                    upTree.Enqueue(tmp.left);
                }
                if (list.Count != 0 && tmp != null)
                {
                    if (list.Count == 0 || count == 0)
                        break;
                    tmp.right = list[0] == null ? null : new TreeNode((int)list[0]);
                    list.RemoveAt(0);
                    count--;
                    upTree.Enqueue(tmp.right);
                }
            }

            return result;
        }

        #endregion

        #region 樹 Model

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        //public class Node
        //{
        //    public int val;
        //    public IList<Node> children;

        //    public Node() { }
        //    public Node(int _val, IList<Node> _children)
        //    {
        //        val = _val;
        //        children = _children;
        //    }
        //}

        #endregion

        #region LinkList Model

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node() { }
            public Node(int _val, Node _next, Node _random)
            {
                val = _val;
                next = _next;
                random = _random;
            }
        }
        #endregion

        #region 跳過的題目 769

        /// <summary>
        /// 這題先跳過
        /// 769
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int MaxChunksToSorted(int[] arr)
        {
            List<List<int>> chunk = new List<List<int>>();

            for (int i = 0; i < arr.Length; i++)
            {
                List<int> last = chunk.Any() ? chunk.Last() : null;
                if (last != null && (last.Last() > arr[i]))
                {
                    last.Add(arr[i]);
                }
                else
                {
                    chunk.Add(new List<int>() { arr[i] });
                }
            }

            return chunk.Count;
        }

        #endregion

    }
}
