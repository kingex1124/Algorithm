using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.LinkedList
{
    public class Q143ReorderList
    {
        public Q143ReorderList()
        {

        }
        /// <summary>
        /// 九章
        /// 最好懂得
        /// </summary>
        /// <param name="head"></param>
        public void ReorderList2(ListNode head)
        {
            if (head == null || head.next == null)
                return;

            ListNode mid = FindMiddle(head);
            ListNode tail = Reverse(mid.next);
            mid.next = null;

            Merge(head, tail);
        }
        private ListNode FindMiddle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head.next;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }

        private ListNode Reverse(ListNode curr)
        {
            ListNode prev = null;
            while (curr != null)
            {
                ListNode Next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = Next;
            }
            return prev;
        }

        private void Merge(ListNode head1, ListNode head2)
        {
            int index = 0;
            ListNode dummy = new ListNode(0);
            while (head1 != null && head2 != null)
            {
                if (index % 2 == 0)
                {
                    dummy.next = head1;
                    head1 = head1.next;
                }
                else
                {
                    dummy.next = head2;
                    head2 = head2.next;
                }
                dummy = dummy.next;
                index++;
            }
            if (head1 != null)
                dummy.next = head1;
            else
                dummy.next = head2;
        }

        /// <summary>
        /// 拿學來的改良的
        /// </summary>
        /// <param name="head"></param>
        public void ReorderList1(ListNode head)
        {
            if (head == null || head.next == null)
                return;

            //Find the middle of list. middle is p1;
            ListNode p1 = head;
            ListNode p2 = head;
            while (p2.next != null && p2.next.next != null)
            {
                p1 = p1.next;
                p2 = p2.next.next;
            }

            // Reverse the half after middle 
           
            ListNode curr = p1.next;
            ListNode pre = p1;
            ListNode first = curr;
            while (curr != null)
            {
                ListNode Next = curr.next;
                curr.next = pre;
                pre = curr;
                curr = Next;
            }
            p1.next = pre;
            first.next = curr;//切斷尾巴

            //Start reoder one  by one
            ListNode preMiddle = p1;

            p1 = head;
            p2 = preMiddle.next;
            while (p1 != preMiddle)
            {
                preMiddle.next = p2.next;
                p2.next = p1.next;
                p1.next = p2;
                p1 = p2.next;
                p2 = preMiddle.next;
            }
        }

        /// <summary>
        /// 學來的
        /// 跌代法
        /// </summary>
        /// <param name="head"></param>
        public void ReorderList(ListNode head)
        {
            if (head == null || head.next == null)
                return;

            //Find the middle of list. middle is p1;
            ListNode p1 = head;
            ListNode p2 = head;
            while (p2.next != null && p2.next.next != null)
            {
                p1 = p1.next;
                p2 = p2.next.next;
            }

            // Reverse the half after middle 
            ListNode preMiddle = p1;
            ListNode preCurrent = p1.next;
            while (preCurrent.next != null)
            {
                ListNode current = preCurrent.next;
                preCurrent.next = current.next;
                current.next = preMiddle.next;
                preMiddle.next = current;
            }

            //Start reoder one  by one

            p1 = head;
            p2 = preMiddle.next;
            while (p1 != preMiddle)
            {
                preMiddle.next = p2.next;
                p2.next = p1.next;
                p1.next = p2;
                p1 = p2.next;
                p2 = preMiddle.next;
            }
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
