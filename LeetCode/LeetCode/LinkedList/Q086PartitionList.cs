using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.LinkedList
{
    public class Q086PartitionList
    {
        public Q086PartitionList()
        {
            //ListNode node1 = new ListNode(1);
            //ListNode node2 = new ListNode(4);
            //ListNode node3 = new ListNode(3);
            //ListNode node4 = new ListNode(2);
            //ListNode node5 = new ListNode(5);
            //ListNode node6 = new ListNode(2);

            //node1.next = node2;
            //node2.next = node3;
            //node3.next = node4;
            //node4.next = node5;
            //node5.next = node6;

            //var result = ob.Partition1(node1, 3);
        }

        /// <summary>
        /// 學來的
        /// </summary>
        /// <param name="head"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public ListNode Partition(ListNode head, int x)
        {
            ListNode smallerHead = new ListNode(0);
            ListNode biggerHead = new ListNode(0);
            ListNode smaller = smallerHead;
            ListNode bigger = biggerHead;
            while (head != null)
            {
                if (head.val < x)
                {
                    smaller.next = head;
                    smaller = smaller.next;
                }// smaller = (smaller.next = head)   a = (b = c)
                else
                {
                    bigger.next = head;
                    bigger = bigger.next;
                }
                head = head.next;
            }

            smaller.next = biggerHead.next;
            bigger.next = null;// 把尾巴後面切斷
            return smallerHead.next;
        }

        /// <summary>
        /// 九章寫法
        /// 跟學來的一樣
        /// </summary>
        /// <param name="head"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public ListNode Partition1(ListNode head, int x)
        {
            if (head == null)
                return head;

            ListNode leftDummy = new ListNode(0);
            ListNode rightDummy = new ListNode(0);
            ListNode left = leftDummy;
            ListNode right = rightDummy;

            while (head != null)
            {
                if (head.val < x)
                {
                    left.next = head;
                    left = head;
                }
                else
                {
                    right.next = head;
                    right = head;
                }
                head = head.next;
            }

            right.next = null;
            left.next = rightDummy;
            return leftDummy.next;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
