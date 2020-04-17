using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Udemy
{
    public class Queue
    {
        public List<string> data;
        public Queue()
        {
            this.data = new List<string>();
        }

        public void add(string record)
        {
            this.data.Insert(0, record);
        }

        public string remove()
        {
            var removeData = this.data.Last();
            this.data.RemoveAt(this.data.Count - 1);
            return removeData;
        }

        public string peek()
        {
            return this.data.Any() ? this.data.Last() : null;
        }


    }
}
