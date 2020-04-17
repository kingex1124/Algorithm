using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Udemy
{
    public class Node
    {
        public string data = string.Empty;
        public List<Node> children;
       
        public Node(string data)
        {
            this.data = data;
            this.children = new List<Node>();

            //測試
            //Node node = new Node("a");
            //node.Add("b");
            //node.Remove("b");
        }

        public void Add(string data)
        {
            this.children.Add(new Node(data));
        }

        public void Remove(string data)
        {
            this.children = this.children.Where(node => node.data != data).ToList();
        }
    }
    public class Tree
    {
        public Node root; 
        public Tree()
        {
            root = null;

            //測試
            //Tree tr = new Tree();
            //tr.root = new Node("a");
            //tr.root.Add("b");
            //tr.root.Add("c");
            //tr.root.children[0].Add("d");

            //List<string> temp = new List<string>();
            //tr.TraverseBF(node => temp.Add(node.data));
        }

        public void TraverseBF(Action<Node> fn)
        {
            List<Node> arr = new List<Node>() { this.root };
           
            while (arr.Count != 0)
            {
                Node node = arr[0];
                arr.RemoveAt(0);
                fn(node);
                arr.AddRange(node.children);
            }
        }

        public void TraverseDF(Action<Node> fn)
        {
            List<Node> arr = new List<Node>() { this.root };

            while (arr.Count != 0)
            {
                Node node = arr[0];
                arr.RemoveAt(0);
                fn(node);
                arr.InsertRange(0,node.children);
            }
        }
    }
}
