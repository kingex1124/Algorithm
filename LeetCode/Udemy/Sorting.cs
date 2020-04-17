using LeetCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Udemy
{
    public  class Sorting
    {
        public Sorting()
        {
            //  var result = st.mergeSort(new List<int>() { 100, -40, 500, -124, 0, 21, 7 });
        }

        /// <summary>
        /// 把最大的換到最後面
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public List<int> bubbleSort(List<int> arr)
        {
            // 把最大的換到最後面
            // Implement bubblesort
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = 0; j < (arr.Count - i - 1); j++)
                {
                    if (arr[j] < arr[j + 1])
                        continue;
                    else
                    {
                        int lesser = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = lesser;
                    }
                }
            }
            return arr;
        }

        /// <summary>
        /// 把小的值換到前面來
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public List<int> selectionSort(List<int> arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                int indexOfMin = i;
                for (int j = i + 1; j < arr.Count; j++)
                {
                    if (arr[j] < arr[indexOfMin])
                        indexOfMin = j;
                }
                //有變才換 i 跟最小的對調
                if (i != indexOfMin)
                {
                    int lesser = arr[i];
                    arr[i] = arr[indexOfMin];
                    arr[indexOfMin] = lesser;
                }
            }
            return arr;
        }

        /// <summary>
        /// 分治法
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public List<int> mergeSort(List<int> arr)
        {
            if (arr.Count == 1)
                return arr;

            decimal count = Convert.ToInt32(arr.Count);
            int center = Convert.ToInt32(Math.Floor(count / 2));

            var left = arr.Slice(0, center);
            var right = arr.Slice(center, arr.Count);
            return merge(mergeSort(left), mergeSort(right));
        }

        public List<int> merge(List<int> left, List<int> righr)
        {
            List<int> result = new List<int>();
            while (left.Count != 0 && righr.Count != 0)
            {
                if (left[0] < righr[0])
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(righr[0]);
                    righr.RemoveAt(0);
                }
            }
            result.AddRange(left);
            result.AddRange(righr);
            return result;
        }    
    }

}
