using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Q021MergeTwoSortedLists
    {
        public Q021MergeTwoSortedLists()
        {

            //ListNode l1 = new ListNode(1) { next = new ListNode(2) { next = new ListNode(4) } };

            //ListNode l2 = new ListNode(1) { next = new ListNode(3) { next = new ListNode(4) } };
            //ListNode l1 = new ListNode(2) { };

            //ListNode l2 = new ListNode(0) { };
            //  var result = ob.MergeTwoLists2(l1, l2);
        }

        /// <summary>
        /// 自己想的
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode(0);
            ListNode first = dummy;

            while (l1 != null || l2 != null)
            {
                if (l1 != null && l2 != null)
                {
                    if (l1.val <= l2.val)
                    {

                        first.next = l1;
                        l1 = l1.next;
                        first = first.next;
                    }
                    else
                    {
                        first.next = l2;
                        l2 = l2.next;
                        first = first.next;
                    }
                }
                else
                {
                    if (l1 != null)
                    {
                        first.next = l1;
                        l1 = l1.next;
                        first = first.next;
                    }
                    else
                    {
                        first.next = l2;
                        l2 = l2.next;
                        first = first.next;
                    }
                }
            }
            return dummy.next;
        }

        /// <summary>
        /// 自己的方式加強版
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists1(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            ListNode dummy = new ListNode(0);
            ListNode first = dummy;

            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
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
            first.next = (l1 != null) ? l1 : l2;

            return dummy.next;
        }

        /// <summary>
        /// 網路上的遞迴寫法
        /// 保留最小的val 把next 接上下一個最小的數字
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists2(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            if (l1.val < l2.val)
            {
                l1.next = MergeTwoLists2(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoLists2(l1, l2.next);
                return l2;
            }
        }

        /// <summary>
        /// 網路上的遞迴寫法2
        /// 去掉if 思路同上
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists3(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            ListNode head = (l1.val < l2.val) ? l1 : l2;
            ListNode nonhead = (l1.val < l2.val) ? l2 : l1;
            head.next = MergeTwoLists3(head.next, nonhead);
            return head;
        }

        /// <summary>
        /// 網路上參考 遞迴3
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists4(ListNode l1, ListNode l2)
        {
            if (l1 == null || (l2 != null && l1.val > l2.val))
            {
                ListNode t = l1;
                l1 = l2;
                l2 = t;
            }
            if (l1 != null)
                l1.next = MergeTwoLists4(l1.next, l2);
            return l1;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
