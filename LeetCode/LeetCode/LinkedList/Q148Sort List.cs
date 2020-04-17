using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.LinkedList
{
    public class Q148Sort_List
    {
        public Q148Sort_List()
        {

        }

        /// <summary>
        /// Quick Sort
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SortList1(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode mid = FindMiddle(head);
            ListNode right = SortList1(mid.next);
            mid.next = null;
            ListNode left = SortList1(head);

            return MergeTwoLists(left, right);
        }

        private ListNode FindMiddle(ListNode head)
        {
            ListNode slow = head, fast = head.next;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }

        /// <summary>
        /// Merge Sort
        /// O(nlogn)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode prev = null;
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }
            prev.next = null;

            ListNode l1 = SortList(head);
            ListNode l2 = SortList(slow);

            return MergeTwoLists(l1, l2);
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;
            ListNode dummy = new ListNode(0);
            ListNode first = dummy;

            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    first.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    first.next = l2;
                    l2 = l2.next;
                }
                first = first.next;
            }
            first.next = (l1 == null) ? l2 : l1;
            return dummy.next;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
