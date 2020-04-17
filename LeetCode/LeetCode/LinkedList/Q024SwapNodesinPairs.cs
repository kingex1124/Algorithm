using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Q024SwapNodesinPairs
    {
        public Q024SwapNodesinPairs()
        {
            //ListNode a = new ListNode(1) { next = new ListNode(2) { next = new ListNode(3) { next = new ListNode(4) { next = new ListNode(5) { next = new ListNode(6) { } } } } } };
            //var result = ob.SwapPairs(a);
        }

        /// <summary>
        /// 參考網路上的
        /// 先處理 前兩個節點，在處理後兩個節點...每次兩個往後處理
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SwapPairs(ListNode head)
        {
            ListNode pre = new ListNode(0);
            ListNode result = pre;
            pre.next = head;
            while (head != null)
            {
                ListNode nxt = head.next;
                if (nxt != null)
                {
                    head.next = nxt.next;
                    nxt.next = head;
                    pre.next = nxt;
                    //刷新下一階段
                    pre = head;
                    //往後指標處理後面的
                    head = head.next;
                }
                else
                    break;
            }
            return result.next;
        }

        public ListNode SwapPairs1(ListNode head)
        {
            ListNode dummy = new ListNode(0);
            ListNode pre = dummy;
            dummy.next = head;
            while (pre != null)
            {
                if (pre.next != null)
                {
                    if (pre.next.next != null)
                    {
                        ListNode t = pre.next.next;
                        pre.next.next = t.next;
                        t.next = pre.next;
                        pre.next = t;
                        pre = t.next;
                    }
                    else
                        break;
                }
                else
                    break;
            }
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
