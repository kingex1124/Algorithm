using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Q011ContainerWithMostWater
    {
        public Q011ContainerWithMostWater()
        {
            //代入範本
            //  int result = ob.MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 });
        }

        /// <summary>
        /// 計算最大面積
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxArea(int[] height)
        {
            int i = 0, j = height.Count() - 1;
            int area = 0;
            int areaTemp = 0;
            for (i = 0; i <= j;)
            {
                int w = j - i;
                if (height[i] < height[j])
                {
                    areaTemp = height[i] * w;
                    i++;
                }
                else
                {
                    areaTemp = height[j] * w;
                    j--;
                }
                area = areaTemp > area ? areaTemp : area;
            }
            return area;
        }
    }
}
