using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Udemy
{
    public class Weave
    {
        public Weave()
        {
            //Weave w = new Weave();
            //Udemy.Queue s1 = new Udemy.Queue();
            //Udemy.Queue s2 = new Udemy.Queue();
            //s1.add("There");
            //s1.add("Hi");

            //s2.add("2");
            //s2.add("1");
            //var re = w.weave(s1, s2);
        }

        public Queue weave(Queue sourceOne, Queue sourceTwo)
        {
            Queue q = new Queue();
            while (sourceOne.peek() != null || sourceTwo.peek() != null)
            {
                if (sourceOne.peek() != null)
                    q.add(sourceOne.remove());
                if (sourceTwo.peek() != null)
                    q.add(sourceTwo.remove());
            }
            return q;
        }
    }
}
