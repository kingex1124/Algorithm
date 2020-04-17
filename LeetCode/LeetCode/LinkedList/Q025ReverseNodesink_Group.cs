using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.LinkedList
{
    public class Q025ReverseNodesink_Group
    {
        public Q025ReverseNodesink_Group()
        {

        }

        /// <summary>
        /// 學來的
        /// 遞迴解法
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null || head.next == null)
                return head;
            int count = 0;
            ListNode curr = head;
            while (curr != null && count != k)
            {
                curr = curr.next;
                count++;
            }
            if (count == k)
            {
                curr = ReverseKGroup(curr, k);
                while (count-- > 0)
                {
                    ListNode temp = head.next;
                    head.next = curr;
                    curr = head;
                    head = temp;
                }
                head = curr;
            }
            return head;
        }

        /// <summary>
        /// 學來的
        /// 迭代解法
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode ReverseKGroup1(ListNode head, int k)
        {
            ListNode begin;

            if (head == null || head.next == null || k == 1)
                return head;

            ListNode dmy = new ListNode(-1);

            dmy.next = head;

            begin = dmy;

            int i = 0;

            while (head != null)
            {
                i++;
                if (i % k == 0)
                {
                    begin = Reverse(begin, head.next);
                    head = begin.next;
                }
                else
                    head = head.next;
            }
            return dmy.next;
        }

        private ListNode Reverse(ListNode begin, ListNode end)
        {
            ListNode curr = begin.next;
            ListNode next, first;
            ListNode prev = begin;
            first = curr;
            while (curr != end)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            begin.next = prev;
            first.next = curr;
            return first;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
