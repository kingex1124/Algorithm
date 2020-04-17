using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.QueueStack
{
    public class Q232ImplementQueueUsingStacks
    {
        //Stack
        //Push 從頭塞 Pop 從頭拔
        /// <summary>
        /// 解法1 效能消耗在push
        /// 解法2 效能消耗在 pop 跟 peak
        /// </summary>
        public Q232ImplementQueueUsingStacks()
        {
            //MyQueue t = new MyQueue();

            //t.Push(1);
            //t.Push(2);
            //t.Push(3);
            //t.Pop();
        }

        /// <summary>
        /// 解法1
        /// </summary>
        public class MyQueue
        {
            public Stack<int> data = new Stack<int>();
            public Stack<int> temp = new Stack<int>();

            /** Initialize your data structure here. */
            public MyQueue()
            {
            }

            /** Push element x to the back of queue. */
            public void Push(int x)
            {
                while (data.Count != 0)
                    temp.Push(data.Pop());

                temp.Push(x);

                while (temp.Count != 0)
                    data.Push(temp.Pop());
            }

            /** Removes the element from in front of queue and returns that element. */
            public int Pop()
            {
                return data.Pop();
            }

            /** Get the front element. */
            public int Peek()
            {
                return data.Peek();
            }

            /** Returns whether the queue is empty. */
            public bool Empty()
            {
                return data.Count == 0;
            }
        }

        /// <summary>
        /// 解法2
        /// </summary>
        public class MyQueue1
        {
            public Stack<int> inStack = new Stack<int>();
            public Stack<int> outStack = new Stack<int>();

            /** Initialize your data structure here. */
            public MyQueue1()
            {
            }

            /** Push element x to the back of queue. */
            public void Push(int x)
            {
                inStack.Push(x);
            }

            /** Removes the element from in front of queue and returns that element. */
            public int Pop()
            {
                if (outStack.Count == 0)
                    while (inStack.Count() != 0)
                        outStack.Push(inStack.Pop());
                return outStack.Pop();
            }

            /** Get the front element. */
            public int Peek()
            {
                if (outStack.Count == 0)
                    while (inStack.Count() != 0)
                        outStack.Push(inStack.Pop());
                return outStack.Peek();
            }

            /** Returns whether the queue is empty. */
            public bool Empty()
            {
                return inStack.Count == 0 && outStack.Count == 0;
            }
        }
    }
}
