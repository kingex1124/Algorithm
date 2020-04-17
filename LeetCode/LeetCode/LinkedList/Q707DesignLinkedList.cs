using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.LinkedList
{
    public class Q707DesignLinkedList
    {
        public Q707DesignLinkedList()
        {
            var t = new MyLinkedList();

            //t.AddAtHead(3);
            //t.AddAtHead(2);
            //t.AddAtHead(1);

            //t.Get(3);

            //t.AddAtHead(1);
            //t.Get(1);
            //t.AddAtTail(4);
            //t.AddAtTail(7);
            //t.AddAtHead(2);
            //t.AddAtTail(3);
            //t.Get(2);
            //t.AddAtHead(4);
            //t.AddAtIndex(2, 9);
            //t.AddAtIndex(7, 4);
            //t.DeleteAtIndex(6);

            //t.AddAtHead(7);
            //t.AddAtHead(2);
            //t.AddAtHead(1);
            //t.AddAtIndex(3, 0);
            //t.DeleteAtIndex(2);
            //t.AddAtHead(6);
            //t.AddAtTail(4);
            //t.Get(4);
            //t.AddAtHead(4);
            //t.AddAtIndex(5, 0);
            //t.AddAtHead(6);

            t.AddAtIndex(1, 2);

            t.AddAtHead(1);
            t.AddAtTail(3);
            t.AddAtIndex(1, 2);
            t.Get(-1);
            t.DeleteAtIndex(1);
            t.Get(-3);
        }

        public class MyLinkedList
        {
            public class Node
            {
                public Node()
                {

                }
                public Node(int val, Node next = null)
                {
                    this.val = val;
                    this.next = next;
                }
                public int val;
                public Node next;
            }

            public Node head;
            /** Initialize your data structure here. */
            public MyLinkedList()
            {
                head = null;
            }

            /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
            public int Get(int index)
            {
                int counter = 0;
                Node node = this.head;

                while (node != null)
                {
                    if (counter == index)
                        return node.val;

                    counter++;
                    node = node.next;
                }
                return -1;
            }

            public Node GetAt(int index)
            {
                int counter = 0;
                Node node = this.head;

                while (node != null)
                {
                    if (counter == index)
                        return node;

                    counter++;
                    node = node.next;
                }
                return null;
            }

            /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
            public void AddAtHead(int val)
            {
                this.head = new Node(val, this.head);
            }

            /** Append a node of value val to the last element of the linked list. */
            public void AddAtTail(int val)
            {
                if (this.head == null)
                    this.head = new Node(val);
                else
                {
                    var node = this.head;
                    while (node.next != null)
                        node = node.next;
                    node.next = new Node(val);
                }

                //另一種寫法
                //var dum = this.head;
                //var node = dum;
                //while (node != null)
                //{
                //    if (node.next == null)
                //        break;
                //    dum = node;
                //    node = node.next;
                //}
                //dum.next = new Node(val);
            }

            public Node getLast()
            {
                if (this.head == null)
                    return null;

                Node node = this.head;
                while (node != null)
                {
                    if (node.next == null)
                        return node;
                    node = node.next;
                }
                return null;
            }

            /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
            public void AddAtIndex(int index, int val)
            {
                if (this.head == null && (index == 0 || index == -1))
                {
                    this.head = new Node(val);
                    return;
                }

                if (index == 0)
                {
                    this.head = new Node(val, this.head);
                    return;
                }

                Node previous = this.GetAt(index - 1) ?? this.getLast();
                if (previous == null)
                    return;
                Node node = new Node(val, previous.next);
                previous.next = node;
            }

            /** Delete the index-th node in the linked list, if the index is valid. */
            public void DeleteAtIndex(int index)
            {
                if (this.head == null)
                    return;
                if (index == 0)
                {
                    this.head = this.head.next;
                    return;
                }

                Node previous = GetAt(index - 1);
                if (previous == null || previous.next == null)
                    return;
                previous.next = previous.next.next;
            }
        }
    }
}
