using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Udemy
{
    public class LevelWidth
    {
        public LevelWidth()
        {
            LevelWidth lw = new LevelWidth();
            Node node = new Node("a");
            node.children.AddRange(new List<Node>() { new Node("b"), new Node("c"), new Node("d") });
            node.children[0].children.AddRange(new List<Node>() { new Node("e"), new Node("f") });
            var result = lw.levelWidth(node);
        }

        public List<int> levelWidth(Node root)
        {
            ArrayList arr = new ArrayList() { root, "s" };
            List<int> counter = new List<int>() { 0 };

            while (arr.Count > 1)
            {
                object node = arr[0];
                arr.RemoveAt(0);
                if(node.ToString()=="s")
                {
                    counter.Add(0);
                    arr.Add("s");
                }
                else
                {
                    arr.AddRange(((Node)node).children);
                    counter[counter.Count - 1]++;
                }
            }
            return counter;
        }
    }
}
