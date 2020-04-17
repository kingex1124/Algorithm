using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.LinkedList
{
    public class Q160IntersectionOfTwoLinkedLists
    {
        /// <summary>
        /// 這題在VS上寫跑出來會有問題，只有在leetCode上跑才是正常的
        /// 因為在VS上跑，兩者走到相同數字時，並不會把後面整條鏈視為相同的鏈，
        /// 所以會變成不相等的兩個鏈，一路走到變成null值回傳
        /// </summary>
        public Q160IntersectionOfTwoLinkedLists()
        {
            //ListNode n1 = new ListNode(4) { next = new ListNode(1) { next = new ListNode(8) { next = new ListNode(4) { next = new ListNode(5) } } } };
            //ListNode n2 = new ListNode(5) { next = new ListNode(0) { next = new ListNode(1) { next = new ListNode(8) { next = new ListNode(4) { next = new ListNode(5) } } } } };

            //ListNode tmp = n2;
            //while (tmp.next!=null)
            //{
            //    tmp = tmp.next;
            //}
            //tmp.next = n2;

            //var result = ob.GetIntersectionNode(n1, n2);

            //var result1 = ob.GetIntersectionNode1(n1, n2);
        }

        /// <summary>
        /// 參考網路上的
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public ListNode GetIntersectionNode1(ListNode headA, ListNode headB)
        {
            ListNode n1 = headA;
            ListNode n2 = headB;

            while (n1 != n2)
            {
                n1 = (n1 == null) ? headB : n1.next;

                n2 = (n2 == null) ? headA : n2.next;
            }

            return n1;
        }

        /// <summary>
        /// 九章寫法
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            while (headB.next != null)
                headB = headB.next;
            

            if (headA == null || headB == null)
                return null;

            // get the tail of list A.
            ListNode node = headA;

            while (node.next != null)
                node = node.next;
            node.next = headB;
            ListNode result = DetectCycle(headA);
            node.next = null;

            return result;
        }

        public ListNode DetectCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head.next;

            //找到相遇的點
            while (slow != fast)
            {
                if (fast == null || fast.next == null)
                    return null;
                slow = slow.next;
                fast = fast.next.next;
            }

            slow = head;
            fast = fast.next;
            while (slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            }

            return slow;

            ////推到循環的頭
            //while (head != slow.next)
            //{
            //    head = head.next;
            //    slow = slow.next;
            //}
            //return head;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

    }
}
