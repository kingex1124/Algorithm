using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.LinkedList
{
    public class Q142LinkedListCycleII
    {
        public Q142LinkedListCycleII()
        {

        }

        public ListNode DetectCycle(ListNode head)
        {
            if (head == null || head.next == null)
                return null;
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

            //推到循環的頭
            while (head != slow.next)
            {
                head = head.next;
                slow = slow.next;
            }
            return head;
        }

        /// <summary>
        /// 自己寫的
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DetectCycle1(ListNode head)
        {
            HashSet<ListNode> nodeScreen = new HashSet<ListNode>();
            ListNode tmp = head;
            while (tmp != null)
            {
                if (nodeScreen.Contains(tmp))
                    return tmp;
                else
                    nodeScreen.Add(tmp);
                tmp = tmp.next;
            }
            return null;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
