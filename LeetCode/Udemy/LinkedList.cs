using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Udemy
{
    public class LinkedList
    {
        public class Node
        {
            public int data;
            public Node next;
            public Node(int data, Node next = null)
            {
                this.data = data;
                this.next = next;
            }
        }

        public Node head;

        public LinkedList()
        {
            this.head = null;

            //Udemy.LinkedList t = new Udemy.LinkedList();
            //t.insertLast(1);
            //t.insertLast(2);
            //t.insertLast(3);
            //t.insertLast(4);

            //foreach (Udemy.LinkedList.Node node in t)
            //{
            //    node.data += 10;
            //}


            //t.forEach(node => { node.data += 10; });
        }

        public int size()
        {
            int counter = 0;

            Node node = this.head;

            while (node != null)
            {
                counter++;
                node = node.next;
            }

            return counter;
        }

        public void clear()
        {
            this.head = null;
        }

        public void insertFirst(int data)
        {

            #region 寫法三

            this.insertAt(data, 0);

            #endregion

            #region 寫法二

            //this.head = new Node(data, this.head);

            #endregion

            #region 寫法一

            //Node node = new Node(data, this.head);
            //this.head = node;

            #endregion

            #region 自己寫的
            //Node node = new Node(data);
            //node.next = this.head;
            //this.head = node;
            #endregion
        }

        public void insertLast(int data)
        {
            #region 寫法二 (效能比較差)

            //this.insertAt(data, this.size() - 1);

            #endregion

            #region 寫法一

            Node last = this.getLast();

            //there are some exsiting nodes in our chain
            if (last != null)
                last.next = new Node(data);
            else //The chain is empty!
                this.head = new Node(data);

            #endregion

            #region 自己寫的

            //if (this.head == null)
            //    this.head = new Node(data);
            //else
            //{
            //    Node node = this.head;
            //    while (node.next != null)
            //        node = node.next;
            //    node.next = new Node(data);
            //}

            #endregion
        }

        public Node getFirst()
        {
            #region 寫法二

            return this.getAt(0);

            #endregion

            #region 寫法一

            //return this.head;

            #endregion
        }

        public Node getLast()
        {
            #region 寫法二 (效能較差)

            //return this.getAt(this.size() - 1);

            #endregion

            #region 寫法一

            if (this.head == null)
                return null;

            Node node = this.head;

            while (node != null)
            {
                if (node.next == null)
                    return node;
                node = node.next;
            }
            return node;

            #endregion

            #region 自己寫的

            //Node node = this.head;
            //Node last = node;
            //while (node != null)
            //{
            //    node = node.next;
            //    last = node;
            //}
            //return last;

            #endregion
        }

        public void removeFirst()
        {

            #region 寫法二

            this.removeAt(0);

            #endregion

            #region 寫法一

            //Node node = this.head.next;
            //this.head = node;

            //this.head = this.head.next;

            #endregion
        }

        public void removeLast()
        {
            #region 寫法二 (效能較差)

            //this.removeAt(this.size() - 1);

            #endregion

            #region 寫法一

            if (this.head == null)
                return;

            //表示沒有下一個節點，所以刪除第一個節點即可
            if (this.head.next == null)
            {
                this.head = null;
                return;
            }

            Node previous = this.head;
            Node node = this.head.next;

            while (node.next != null)
            {
                previous = node;
                node = node.next;
            }
            //因為node 的下一個沒有東西了，所以node就是最後一個元素
            //previous的下一個就是node，所以清掉previous.next
            previous.next = null;

            #endregion
        }

        public Node getAt(int index)
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

        public void removeAt(int index)
        {
            if (this.head == null)
                return;

            if (index == 0)
            {
                this.head = this.head.next;
                return;
            }

            //取得要刪除的前一個元素
            Node previous = this.getAt(index - 1);
            //如果要刪除的index 超過2  跟 超過 1 就直接 return 
            if (previous == null || previous.next == null)
                return;
            previous = previous.next;

            #region 自己寫的

            //只有一個元素，要刪除的是第一個元素
            //if (this.head.next == null && index == 0)
            //    this.head = null;
            //else if (this.head.next != null && index == 0)//不只一個元素，要刪除第一個元素
            //    this.head = this.head.next;

            //int counter = 1;
            //Node previous = this.head;
            //Node node = this.head.next;

            //while (node != null)
            //{
            //    if (counter == index)
            //        previous.next = node.next.next;
            //    previous = node;
            //    node = node.next;
            //    counter++;
            //}

            #endregion
        }

        //考慮空的、index超出範圍、插入最後一個位置的元素
        public void insertAt(int data , int index)
        {
            //如果是插入 index 1以上 恐怕會錯誤
            if (this.head==null)
            {
                this.head = new Node(data);
                return;
            }

            if(index==0)
            {
                this.head = new Node(data, this.head);
                return;
            }

            //取得目標的前一個元素，如果沒取到的話，直接取最後一個元素
            //因為要處理的是後段的資料，前面不動，所以取index前一個
            Node previous = getAt(index - 1) ?? this.getLast();

            //插入的，跟後段的資料
            Node node = new Node(data, previous.next);
            previous.next = node;
        }

        public void forEach(Action<Node> function)
        {
            Node node = this.head;
            int counter = 0;
            while (node != null)
            {
                function(node);
                node = node.next;
                counter++;
            }
        }

        //public System.Collections.IEnumerable iterator()
        //{
        //    Node node = this.head;
        //    while (node != null)
        //    {
        //        yield return node;
        //        node = node.next;
        //    }
        //}

        public IEnumerator GetEnumerator()
        {
            Node node = this.head;
            while (node != null)
            {
                yield return node;
                node = node.next;
            }
        }
    }
}
