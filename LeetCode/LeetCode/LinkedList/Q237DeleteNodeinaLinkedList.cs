using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.LinkedList
{
    public class Q237DeleteNodeinaLinkedList
    {
        public Q237DeleteNodeinaLinkedList()
        {

        }

        /// <summary>
        /// 學來的
        /// 傳進來的值是當下要刪掉的位置
        /// </summary>
        /// <param name="node"></param>
        public void DeleteNode(ListNode node)
        {
            Console.WriteLine(node.val);
            node.val = node.next.val;
            node.next = node.next.next;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
