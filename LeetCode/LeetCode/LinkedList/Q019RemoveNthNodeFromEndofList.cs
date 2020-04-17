using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Q019RemoveNthNodeFromEndofList
    {
        public Q019RemoveNthNodeFromEndofList()
        {

            //ListNode a = new ListNode(1) { next = new ListNode(2) { next = new ListNode(3) { next = new ListNode(4) { next = new ListNode(5) { } } } } };
            //ListNode a = new ListNode(1) { next = new ListNode(2) };
            //ListNode a = new ListNode(1);
            //var result = ob.RemoveNthFromEnd(a, 2);
        }

        #region 自己想的方法

        /// <summary>
        /// 自己想的慢方法
        /// </summary>
        /// <param name="head">陣列</param>
        /// <param name="n">倒數要移除的位置</param>
        /// <returns></returns>
        public ListNode RemoveNthFromEnd1(ListNode head, int n)
        {
            List<int> data = new List<int>();
            int allLevel = 0;
            int target = n - 1;
            GetList1(head, 0, ref data, ref allLevel, ref target);
            int removeLevel = allLevel - (n - 1);
            GetResult1(ref head, removeLevel, data);
            return head;
        }

        /// <summary>
        /// 取得總數、移除要移除的資料、要保留的尾端資料
        /// </summary>
        /// <param name="head"></param>
        /// <param name="level"></param>
        /// <param name="data"></param>
        /// <param name="allLevel"></param>
        /// <param name="target"></param>
        private void GetList1(ListNode head, int level, ref List<int> data, ref int allLevel, ref int target)
        {
            allLevel = allLevel + 1;

            if (head.next == null)
                return;

            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                    GetList1(head.next, level + 1, ref data, ref allLevel, ref target);
                else
                {
                    if (target > 0)
                    {
                        data.Add(head.next.val);
                        head.next = null;
                        target--;
                    }
                    else
                        return;
                }
            }
        }

        /// <summary>
        /// 取得最終結果、塞入尾端的資料
        /// </summary>
        /// <param name="head"></param>
        /// <param name="removeLevel"></param>
        /// <param name="data"></param>
        private void GetResult1(ref ListNode head, int removeLevel, List<int> data)
        {
            if (removeLevel == 1)
            {
                head = null;
                AddDataToListNode1(ref head, ref data);
                return;
            }
            GetResult1(ref head.next, removeLevel - 1, data);
        }

        /// <summary>
        /// 塞入資料
        /// </summary>
        /// <param name="head"></param>
        /// <param name="data"></param>
        private void AddDataToListNode1(ref ListNode head, ref List<int> data)
        {
            if (data.Count != 0)
            {
                head = new ListNode(data[data.Count - 1]);
                data.RemoveAt(data.Count - 1);
                AddDataToListNode1(ref head.next, ref data);
            }
            else
                return;
        }

        #endregion

        #region 參考網路上的方法
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {

            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode temp = head;
            int level = 1;

            //先算總共多少層
            while (temp.next != null)
            {
                level++;
                temp = temp.next;
            }
            level -= n;
            temp = dummy;
            while (level > 0)
            {
                level--;
                temp = temp.next;
            }

            temp.next = temp.next.next;

            return dummy.next;
        }

        public ListNode RemoveNthFromEnd2(ListNode head, int n)
        {
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode first = dummy;
            ListNode second = dummy;

            for (int i = 1; i <= n + 1; i++)
                first = first.next;

            while (first != null)
            {
                first = first.next;
                second = second.next;
            }

            second.next = second.next.next;
            return dummy.next;
        }
        #endregion

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
