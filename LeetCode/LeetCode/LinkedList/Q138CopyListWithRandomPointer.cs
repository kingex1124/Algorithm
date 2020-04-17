using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.LinkedList
{
    public class Q138CopyListWithRandomPointer
    {
        public Q138CopyListWithRandomPointer()
        {
            //Node rnode1 = new Node() { val = 1 };
            //Node rnode2 = new Node() { val = 2 };
            //Node rnode3 = new Node() { val = 3 };
            //Node rnode4 = new Node() { val = 4 };
            //Node rnode5 = new Node() { val = 5 };
            //Node rnode6 = new Node() { val = 6 };
            //rnode1.random = rnode3;
            //rnode2.random = rnode1;
            //rnode3.random = rnode6;
            //rnode4.random = rnode2;
            //rnode5.random = rnode6;
            //rnode6.random = rnode5;

            //rnode1.next = rnode2;
            //rnode2.next = rnode3;
            //rnode3.next = rnode4;
            //rnode4.next = rnode5;
            //rnode5.next = rnode6;

            //var result = ob.CopyRandomList(rnode1);
        }

        /// <summary>
        /// 九章解法
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node CopyRandomList4(Node head)
        {
            if (head == null)
            {
                return null;
            }
            CopyNext(head);
            CopyRandom(head);
            return SplitList(head);
        }
        private void CopyNext(Node head)
        {
            while (head != null)
            {
                Node newNode = new Node() { val = head.val };
                newNode.random = head.random;
                newNode.next = head.next;
                head.next = newNode;
                head = head.next.next;
            }
        }

        private void CopyRandom(Node head)
        {
            while (head != null)
            {
                if (head.next.random != null)
                {
                    head.next.random = head.random.next;
                }
                head = head.next.next;
            }
        }

        private Node SplitList(Node head)
        {
            Node newHead = head.next;
            while (head != null)
            {
                Node temp = head.next;
                head.next = temp.next;
                head = head.next;
                if (temp.next != null)
                {
                    temp.next = temp.next.next;
                }
            }
            return newHead;
        }

        /// <summary>
        /// 網路上影片學的
        /// 有用dummy
        /// Time O(N)
        /// Space O(1)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node CopyRandomList3(Node head)
        {
            if (head == null)
                return head;

            Node cur = head;
            while (cur != null)
            {
                Node copy = new Node() { val = cur.val };
                copy.next = cur.next;
                cur.next = copy;
                cur = cur.next.next;
            }

            cur = head;
            while (cur != null)
            {
                if (cur.random != null)
                    cur.next.random = cur.random.next;
                cur = cur.next.next;
            }

            cur = head;
            Node dummy = new Node() { val = 0 };
            Node copyPre = dummy;
            while (cur != null)
            {
                copyPre.next = cur.next;
                cur.next = cur.next.next;
                copyPre = copyPre.next;
                cur = cur.next;
            }
            return dummy.next;
        }

        /// <summary>
        /// 九章解法
        /// map解法
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node CopyRandomList2(Node head)
        {
            if (head == null)
                return head;

            Dictionary<Node, Node> map = new Dictionary<Node, Node>();
            Node dummy = new Node() { val = 0 };
            Node pre = dummy;
            Node newNode;

            while (head != null)
            {
                if (map.ContainsKey(head))
                    newNode = map[head];
                else
                {
                    newNode = new Node() { val = head.val };
                    map.Add(head, newNode);
                }
                pre.next = newNode;

                if (head.random != null)
                {
                    if (map.ContainsKey(head.random))
                        newNode.random = map[head.random];
                    else
                    {
                        newNode.random = new Node() { val = head.random.val };
                        map.Add(head.random, newNode.random);
                    }
                }
                //往後推進pre
                pre = newNode;
                head = head.next;
            }
            return dummy.next;
        }

        /// <summary>
        /// 網路影片學的
        /// map解法
        /// 有用dummy
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node CopyRandomList1(Node head)
        {
            if (head == null)
                return head;

            Dictionary<Node, Node> map = new Dictionary<Node, Node>();
            Node dummy = new Node() { val = 0 };
            Node pre = dummy;

            while (head != null)
            {
                if (!map.ContainsKey(head))
                    map.Add(head, new Node() { val = head.val });

                pre.next = map[head];

                if (head.random != null)
                {
                    if (!map.ContainsKey(head.random))
                        map.Add(head.random, new Node() { val = head.random.val });

                    pre.next.random = map[head.random];

                }
                head = head.next;
                pre = pre.next;
            }
            return dummy.next;
        }

        /// <summary>
        /// leet code 討論區學來的
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node CopyRandomList(Node head)
        {
            if (head == null)
                return head;

            Node curr = head;
            //把同樣的值個多一筆放入在原本的後面
            // 1->1->2->2->3->3->4->4->5->5
            while (curr != null)
            {
                Node next = curr.next;
                curr.next = new Node() { val = curr.val };
                curr.next.next = next;
                curr = next;
            }

            curr = head;

            //把每個 random 的值給新的值
            while (curr != null)
            {
                if (curr.random != null)
                    curr.next.random = curr.random.next;
                curr = curr.next.next;
            }

            curr = head;

            //複製的頭 為原本的頭的下一個值
            Node copyHead = head.next;
            //copy current
            Node copy = copyHead;
            while (copy.next != null)
            {
                curr.next = curr.next.next;
                curr = curr.next;

                copy.next = copy.next.next;
                copy = copy.next;
            }
            //把最後一個 current 接回Null
            curr.next = curr.next.next;

            //回傳複製的頭
            return copyHead;
        }

        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node() { }
            public Node(int _val, Node _next, Node _random)
            {
                val = _val;
                next = _next;
                random = _random;
            }
        }
    }
}
