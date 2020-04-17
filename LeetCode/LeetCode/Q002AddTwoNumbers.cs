using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// 兩數相加
    /// </summary>
    public class Q002AddTwoNumbers
    {
        public Q002AddTwoNumbers()
        {
            //代入用範本
            //ListNode l1 = new ListNode(5);
            //ListNode l2 = new ListNode(5);

            //var result = ob.AddTwoNumbers(l1, l2);
        }

        /// <summary>
        /// 計算用class
        /// </summary>
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int x) { val = x; }
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if ((l1.val + l2.val) >= 10)
            {
                l1.val = (l1.val + l2.val) % 10;
                if (l1.next == null)
                    l1.next = new ListNode(0);
                l1.next.val++;
            }
            else
                l1.val = l1.val + l2.val;
            if (l1.next != null || l2.next != null)
                l1.next = AddTwoNumbers(l1.next ?? new ListNode(0), l2.next ?? new ListNode(0));
            return l1;
        }

    }
}
