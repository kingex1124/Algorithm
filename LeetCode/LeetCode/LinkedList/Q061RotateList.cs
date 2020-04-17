using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.LinkedList
{
    public class Q061RotateList
    {
        public Q061RotateList()
        {
            //ListNode node1 = new ListNode(1);
            //ListNode node2 = new ListNode(2);
            //ListNode node3 = new ListNode(3);
            //ListNode node4 = new ListNode(4);
            //ListNode node5 = new ListNode(5);
            //ListNode node6 = new ListNode(6);

            //node1.next = node2;
            //node2.next = node3;
            //node3.next = node4;
            //node4.next = node5;
            //node5.next = node6;

            //var result = ob.RotateRight(node1, 2);
        }

        /// <summary>
        /// 九章的寫法
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode RotateRight3(ListNode head, int k)
        {
            if (head == null || head.next == null || k == 0)
                return head;

            int length = GetLength(head);
            k = k % length;

            ListNode dummy = new ListNode(0);
            dummy.next = head;
            head = dummy;

            ListNode tail = dummy;
            //此處是拿head 當 fast 所以先走K步
            for (int i = 0; i < k; i++)
                head = head.next;

            //tail 是slow
            while (head.next != null)
            {
                tail = tail.next;
                head = head.next;
            }

            // 把尾跟頭相接
            head.next = dummy.next;
            // 把頭接到 slow 的下一個
            dummy.next = tail.next;
            //斷開相連處
            tail.next = null;
            return dummy.next;
        }

        //計算列表長度
        private int GetLength(ListNode head)
        {
            int length = 0;
            while (head != null)
            {
                length++;
                head = head.next;
            }
            return length;
        }

        /// <summary>
        /// 學來的 跟下面的差不多
        /// 這邊有用dummy
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode RotateRight2(ListNode head, int k)
        {
            if (head == null || head.next == null || k == 0)
                return head;

            ListNode dummy = new ListNode(0);
            dummy.next = head;

            ListNode fast = dummy;
            ListNode slow = dummy;

            int size = 1;
            for (size = 0; fast.next != null; size++)//Get the total length 
                fast = fast.next;

            for (int i = size - k % size; i > 0; i--)
                slow = slow.next;

            fast.next = dummy.next;
            dummy.next = slow.next;
            slow.next = null;

            return dummy.next;
        }

        /// <summary>
        /// 學來的
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode RotateRight1(ListNode head, int k)
        {
            if (head == null || head.next == null || k == 0)
                return head;

            ListNode fast = head;
            ListNode slow = head;

            int size = 1;
            while (fast.next != null)
            {
                size++;
                fast = fast.next;
            }
            // slow 跟 fast 距離2
            for (int i = size - k % size; i > 1; i--)
                slow = slow.next;

            // fast 肯定指的是列表的最後一個元素
            // slow 指的是新列表的最後一個元素
            // slow 的 next 就是新列表的列表頭

            //把fast 接到頭 ex: 1->2->3->4->5->null
            fast.next = head;
            // 把頭移到 slow 的下一個 ex: 1->2->3->4->5 的4
            head = slow.next;
            // 把 slow 3->4 斷開
            slow.next = null;
            //dummy.next = hesad;
            // 回傳頭即可
            return head;
        }

        /// <summary>
        /// 自己亂寫的
        /// 三步驟翻轉法XD
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null || k == 0)
                return head;
            ListNode tmp = head;
            int count = 0;
            while (tmp != null)
            {
                tmp = tmp.next;
                count++;
            }

            while (k > count)
                k = k - count;

            if (k == count)
                return head;

            ListNode res = ReverseBetween(head, 1, count);
            res = ReverseBetween(res, 1, k);
            res = ReverseBetween(res, k + 1, count);
            return res;
        }

        public ListNode ReverseBetween(ListNode head, int m, int n)
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

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
