using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.LinkedList
{
    public class Q141LinkedListCycle
    {
        public Q141LinkedListCycle()
        {

        }

        /// <summary>
        /// 九章解法
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycle2(ListNode head)
        {
            if (head == null || head.next == null)
                return false;

            ListNode slow = head;
            ListNode fast = head.next;

            while (slow != fast)
            {
                if (fast == null || fast.next == null)
                    return false;
                slow = slow.next;
                fast = fast.next.next;
            }
            return true;
        }

        /// <summary>
        ///  學來的
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycle(ListNode head)
        {
            if (head == null)
                return false;

            ListNode slow = head;
            ListNode fast = head;

            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow.val == fast.val)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 學來的1
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycle1(ListNode head)
        {
            HashSet<ListNode> nodesSeen = new HashSet<ListNode>();

            while (head != null)
            {
                if (nodesSeen.Contains(head))
                    return true;
                else
                    nodesSeen.Add(head);
                head = head.next;
            }
            return false;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
