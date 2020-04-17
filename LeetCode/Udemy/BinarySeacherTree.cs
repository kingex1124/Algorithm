using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Udemy
{
    public class BinarySeacherTree
    {
        public BinarySeacherTree()
        {

        }

        public class Node
        {
            public int data;
            public Node left;
            public Node right;
            public Node(int data)
            {
                this.data = data;
                this.left = null;
                this.right = null;
            }

            public void Insert(int data)
            {
                if (data < this.data && this.left != null)
                    this.left.Insert(data);
                else if (data < this.data)
                    this.left = new Node(data);
                else if (data > this.data && this.right != null)
                    this.right.Insert(data);
                else if (data > this.data)
                    this.right = new Node(data);
            }

            public Node Contains(int data)
            {
                if (this.data == data)
                    return this;
                if (data < this.data && this.left != null)
                    this.left.Contains(data);
                else if (data > this.data && this.right != null)
                    this.right.Contains(data);
                return null;
            }
        }
    }
}
