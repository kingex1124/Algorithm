using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class Q023MergekSortedLists
    {
        public Q023MergekSortedLists()
        {
            //ListNode l1 = new ListNode(2) { };

            //ListNode l2 = new ListNode(0) { };

            //ListNode l3 = new ListNode(1) { next = new ListNode(4) { next = new ListNode(5) { } } };
            //ListNode l4 = new ListNode(1) { next = new ListNode(3) { next = new ListNode(4) { } } };
            //ListNode l5 = new ListNode(2) { next = new ListNode(6) { } };
            //ListNode l6 = null;
            //ListNode l7 = new ListNode(-1) { };
            //ListNode[] a = new ListNode[] { l1, l6, l7 };

            //var re = ob.MergeKLists(a);
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            //lists = lists.Where(o => o != null).ToArray();
            //if (lists.Length == 0)
            //    return null;
            //if (lists.Length == 1)
            //    return lists[0];
            //ListNode dummy = new ListNode(int.MinValue);
            ListNode first = new ListNode(int.MinValue); //dummy;

            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] == null)
                    continue;
                first = MergeTwoLists(first, lists[i]);
            }

            return first.next;//dummy.next;
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
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

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
