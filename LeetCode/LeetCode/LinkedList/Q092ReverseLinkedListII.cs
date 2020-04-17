using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.LinkedList
{
    public class Q092ReverseLinkedListII
    {
        public Q092ReverseLinkedListII()
        {
            //var result = ob.ReverseBetween(node1, 2, 4);
        }

        /// <summary>
        /// 學來的
        /// 迭代解法
        /// </summary>
        /// <param name="head"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ListNode ReverseBetween1(ListNode head, int m, int n)
        {
            ListNode dummy = new ListNode(0);
            dummy.next = head;

            ListNode cur1 = dummy;
            ListNode pre1 = null;

            for (int i = 0; i < m; i++)
            {
                pre1 = cur1;
                cur1 = cur1.next;
            }

            ListNode cur2 = cur1;
            ListNode pre2 = pre1;
            ListNode q2;

            for (int i = m; i <= n; i++)
            {
                q2 = cur2.next;
                cur2.next = pre2;
                pre2 = cur2;
                cur2 = q2;
            }

            pre1.next = pre2;
            cur1.next = cur2;

            return dummy.next;
        }

        /// <summary>
        /// 自己寫的
        /// 迭代寫法
        /// </summary>
        /// <param name="head"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ListNode ReverseBetween(ListNode head, int m, int n)
        {
            if (head == null || head.next == null)
                return head;
            int count = n - m + 1;
            int mTemp = m;

            ListNode dmy = new ListNode(0);
            dmy.next = head;

            ListNode prev = null;
            prev = head;
            while (head != null && n > 0)
            {
                if (m - 1 > 0)
                    head = head.next;

                prev = prev.next;
                n--;
                m--;
            }

            while (count-- > 0)
            {
                ListNode curr = head;
                head = head.next;
                curr.next = prev;
                prev = curr;
            }

            ListNode cur2 = dmy;
            ListNode pr2 = null;


            for (int i = 0; i < mTemp; i++)
            {
                pr2 = cur2;
                cur2 = cur2.next;
            }

            pr2.next = prev;
            cur2.next = head;

            return dmy.next;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
