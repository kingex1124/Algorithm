using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Udemy
{
    public class Chunk
    {
        public Chunk()
        {
            //var result = ob.chunk(new int[] { 1, 2, 3, 4, 5 }, 3);
        }

        /// <summary>
        /// 學來的
        /// </summary>
        /// <param name="array"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public List<List<int>> chunk(int[] array, int size)
        {
            //回傳的結果集合
            List<List<int>> chunked = new List<List<int>>();
            foreach (var element in array)
            {
                //每次回圈，都取一次chunked中的最後一筆資料
                List<int> last = chunked.Any() ? chunked.Last() : null;
                //如果last 是空的，或是數量達size，表示要在塞下一個新的陣列，
                //並且把元素也裝進去；否則就是把之前未塞滿的繼續塞滿else的部分
                if (last == null || last.Count == size)
                    chunked.Add(new List<int>() { element });
                else
                    last.Add(element);
            }
            return chunked;
        }

        /// <summary>
        /// 學來的2
        /// </summary>
        /// <param name="array"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public List<List<int>> chunk2(int[] array, int size)
        {
            //回傳的結果集合
            List<List<int>> chunked = new List<List<int>>();

            int index = 0;
            while (index < array.Length)
            {
                chunked.Add(slice(array, index, index + size));
                index += size;
            }

            return chunked;
        }

        public List<int> slice(int[] array, int start, int end)
        {
            List<int> result = new List<int>();
            for (int i = start; i < array.Length && i < end; i++)
                result.Add(array[i]);
            return result;
        }


        /// <summary>
        /// 自己寫的
        /// </summary>
        /// <param name="array"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public List<List<int>> chunk1(int[] array, int size)
        {
            //回傳的結果集合
            List<List<int>> chunked = new List<List<int>>();
            List<int> tmp = new List<int>();
            for (int i = 1; i <= array.Length; i++)
            {
                tmp.Add(array[i - 1]);
                if (i % size == 0)//加符合條件的
                {
                    chunked.Add(tmp);
                    tmp.Clear();
                }
                else if (i == array.Length && tmp.Count != 0)//加剩下的
                    chunked.Add(tmp);
            }
            return chunked;
        }
    }
}
