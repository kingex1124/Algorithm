using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.LinkedList
{
    public class Q109ConvertSortedListtoBinarySearchTree
    {
        public Q109ConvertSortedListtoBinarySearchTree()
        {
            //ListNode node1 = new ListNode(-10);
            //ListNode node2 = new ListNode(-3);
            //ListNode node3 = new ListNode(0);
            //ListNode node4 = new ListNode(5);
            //ListNode node5 = new ListNode(9);
            ////ListNode node6 = new ListNode(6);

            //node1.next = node2;
            //node2.next = node3;
            //node3.next = node4;
            //node4.next = node5;
            ////node5.next = node6;

            //var result = ob.SortedListToBST(node1);
        }

        /// <summary>
        /// 學來的
        /// 遞迴解法
        /// 跟下面那個差不多
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public TreeNode SortedListToBST2(ListNode head)
        {
            if (head == null) return null;
            return ToBST(head, null);
        }
        public TreeNode ToBST(ListNode head, ListNode tail)
        {
            ListNode slow = head;
            ListNode fast = head;
            if (head == tail) return null;

            while (fast != tail && fast.next != tail)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            TreeNode thead = new TreeNode(slow.val);
            thead.left = ToBST(head, slow);
            thead.right = ToBST(slow.next, tail);
            return thead;
        }

        /// <summary>
        /// 遞迴解法
        /// O(nlogn)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public TreeNode SortedListToBST1(ListNode head)
        {
            if (head == null) return null;
            if (head.next == null)
                return new TreeNode(head.val);

            ListNode slow = head;
            ListNode fast = head;
            ListNode prev = null;
            // find the median node in the linked list, after executing this loop
            // fast will pointing to the last node, while slow is the median node.
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                prev = slow;
                slow = slow.next;
            }

            prev.next = null;

            // 頭放中間的值
            TreeNode root = new TreeNode(slow.val);
            //小的放左邊 大的放右邊
            root.left = SortedListToBST1(head);
            root.right = SortedListToBST1(slow.next);

            return root;
        }

        /// <summary>
        /// 學來的
        /// DFS中序二分法解法
        /// O(nLogN)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public TreeNode SortedListToBST(ListNode head)
        {
            if (head == null)
                return null;

            int size = 0;
            ListNode runner = head;
            node = head;

            while (runner != null)
            {
                runner = runner.next;
                size++;
            }

            return InorderHelper(0, size - 1);
        }

        private ListNode node;
        public TreeNode InorderHelper(int start, int end)
        {
            if (start > end)
                return null;

            int mid = start + (end - start) / 2;
            //先走左邊走到底
            TreeNode left = InorderHelper(start, mid - 1);

            //建立中序的頭
            TreeNode treenode = new TreeNode(node.val);
            //放置左邊
            treenode.left = left;
            node = node.next;

            //走右邊
            TreeNode right = InorderHelper(mid + 1, end);
            //放置右邊
            treenode.right = right;

            return treenode;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

    }
}
