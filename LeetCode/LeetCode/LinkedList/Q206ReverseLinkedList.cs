using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.LinkedList
{
    public class Q206ReverseLinkedList
    {
        public Q206ReverseLinkedList()
        {
            // var ret = ob.ReverseList(node1);
        }

        /// <summary>
        /// 學來的
        /// 遞迴解法
        /// this
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList1(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode next = head.next;
            ListNode newHead = ReverseList1(next);
            next.next = head;
            // 因為next = head.next 跟 next.next = head 互相指 造成死循環，所以要把 head.next 設成null段開
            head.next = null;
            return newHead;
        }

        /// <summary>
        /// 學來的
        /// 跌代寫法
        /// 推移的做法
        /// 跟下面差不多 但有一點不一樣 推進的模式有差別
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList3(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode prev = null;
            while (head != null)
            {
                ListNode curr = head;
                head = head.next;
                curr.next = prev;
                prev = curr;
            }

            return prev;
        }

        /// <summary>
        /// 學來的
        /// 迭代解法
        /// this
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
                return head;

            ListNode prev = null;//最後的位置
            ListNode curr = head;
            while (curr != null)
            {
                ListNode next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            return prev;
        }

        /// <summary>
        /// 九章這樣寫
        /// 基本上寫法差不多
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList2(ListNode head)
        {
            ListNode pre = null;

            while (head != null)
            {
                ListNode next = head.next;
                head.next = pre;
                pre = head;
                head = next;
            }
            return pre;
        }


        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

    }
}
