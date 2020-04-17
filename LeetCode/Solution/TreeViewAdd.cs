using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solution
{
    public class TreeViewAdd
    {
        public TreeViewAdd()
        {
            List<DBTable> data = new List<DBTable>();
            for (int i = 1; i < 14; i++)
            {
               var dataTmp = new DBTable() { ID = i , Data = "A"+ i };
                data.Add(dataTmp);
            }

            for (int i = 1; i < 5; i++)
                data[i].Paraent = 1;

            for (int i = 5; i < 7; i++)
                data[i].Paraent = 2;

            for (int i = 7; i < 9; i++)
                data[i].Paraent = 3;

            for (int i = 9; i < 11; i++)
                data[i].Paraent = 4;

            for (int i = 11; i < 13; i++)
                data[i].Paraent = 5;
            data=data.OrderBy(o => o.Paraent).ToList();
            Node result = AddTree(data);
        }

        private Node AddTree(List<DBTable> data)
        {
            Node result = null;
            result = new Node(data.Find(o => o.Paraent == null).ID, new List<Node>());
            data.Remove(data.Find(o => o.Paraent == null));
            Helper(data, result,0);
            return result;
        }
        int c = 0;
        private void Helper(List<DBTable> data, Node result, int index)
        {
            if (result == null)
                return;

            while (data.Count != 0 && index < data.Count)
            {
                if (data[index].Paraent == result.val)
                {
                    result.children.Add(new Node(data[index].ID, new List<Node>()));
                    data.Remove(data[index]);

                    Helper(data, result.children.Last(), 0);
                    index = -1;
                }
                index++;
                c++;
            }

            //for (int i = 0; i < data.Count; i++)
            //{
            //    DBTable tmp = data[i];
            //    if (tmp.Paraent == result.val)
            //    {
            //        result.children.Add(new Node(tmp.ID, new List<Node>()));
            //        data.Remove(tmp);

            //        Helper(data, result.children.Last());

            //        data.Insert(i, tmp);
            //    }
            //    c++;
            //}
        }

        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }
            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }

        public class DBTable
        {
            public int ID { get; set; }
            public int? Paraent { get; set; }
            public string Data { get; set; }
        }
    }
}
