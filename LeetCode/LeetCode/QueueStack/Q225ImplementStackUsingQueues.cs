using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.QueueStack
{
    public class Q225ImplementStackUsingQueues
    {
        /// <summary>
        /// Queue
        /// Dequeue 從頭拔
        /// Enqueue 從尾巴塞
        /// </summary>
        public Q225ImplementStackUsingQueues()
        {
            //MyStack m = new MyStack();
            //m.Push(1);
            //m.Push(2);
            //m.Push(3);
        }

        /// <summary>
        /// 解法一 參考網路上的
        /// </summary>
        public class MyStack
        {
            Queue<int> data = new Queue<int>();

            /** Initialize your data structure here. */
            public MyStack()
            {

            }

            /** Push element x onto stack. */
            public void Push(int x)
            {
                Queue<int> temp = new Queue<int>();
                temp.Enqueue(x);

                //如果是空的，就直接取新的
                //如果有原始資料，就通通塞到暫存 在取代成data
                while (data.Any())
                    temp.Enqueue(data.Dequeue());
                data = temp;
            }

            /** Removes the element on top of the stack and returns that element. */
            public int Pop()
            {
                return data.Dequeue();
            }

            /** Get the top element. */
            public int Top()
            {
                return data.Peek();
            }

            /** Returns whether the stack is empty. */
            public bool Empty()
            {
                return data.Count == 0;
            }
        }

        /// <summary>
        /// 解法二 參考網路上的
        /// </summary>
        public class MyStack1
        {
            Queue<int> data = new Queue<int>();

            /** Initialize your data structure here. */
            public MyStack1()
            {

            }

            /** Push element x onto stack. */
            public void Push(int x)
            {
                data.Enqueue(x);
                //少走一個loop 排除掉新加入的
                for (int i = 0; i < data.Count - 1; i++)
                    data.Enqueue(data.Dequeue());
            }

            /** Removes the element on top of the stack and returns that element. */
            public int Pop()
            {
                return data.Dequeue();
            }

            /** Get the top element. */
            public int Top()
            {
                return data.Peek();
            }

            /** Returns whether the stack is empty. */
            public bool Empty()
            {
                return data.Count == 0;
            }
        }
    }
}
