using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.LinkedList
{
    public class Q876MiddleoftheLinkedList
    {
        public Q876MiddleoftheLinkedList()
        {

        }

        /// <summary>
        /// 學來的
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode MiddleNode1(ListNode head)
        {
            List<ListNode> linkArr = new List<ListNode>();
            int counter = 0;
         
            while (head != null)
            {
                linkArr.Add(head);
                head = head.next;
                counter++;
            }
            return linkArr[counter / 2];
        }

        /// <summary>
        /// 學來的
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode MiddleNode(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            if (fast.next != null && fast.next.next == null)
                return slow.next;
            return slow;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
