using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree.Graph
{
    public class Q210CourseScheduleII
    {
        public Q210CourseScheduleII()
        {
            //int[][] pr = new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 1, 2 } };

            //var result = ob.FindOrder(3, pr);
        }

        /// <summary>
        /// Topological Sort
        /// DFS 花花
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public int[] FindOrder1(int numCourses, int[][] prerequisites)
        {
            List<List<int>> graph = new List<List<int>>();

            for (int i = 0; i < numCourses; i++)
                graph.Add(new List<int>());

            for (int i = 0; i < prerequisites.Length; i++)
                graph[prerequisites[i][0]].Add(prerequisites[i][1]);

            // states: 0 = unkonwn, 1 == visiting, 2 = visited
            int[] visite = new int[numCourses];

            int[] result = new int[numCourses];

            for (int i = 0; i < numCourses; i++)
                if (DFS(graph, visite, result, i))
                    return new int[0];
            return result;
        }

        int index = 0;
        private bool DFS(List<List<int>> graph, int[] visite, int[] result, int course)
        {
            //表示有環 沒有解
            if (visite[course] == 1)
                return true;
            //訪問過了 reture false 沒有必要再繼續訪問了
            if (visite[course] == 2)
                return false;

            //表示正在訪問
            visite[course] = 1;

            //嘗試所有的相鄰點
            for (int i = 0; i < graph[course].Count; i++)
            {
                //有環就會返為 true
                if (DFS(graph, visite, result, graph[course][i]))
                    return true;
            }

            visite[course] = 2;

            result[index++] = course;

            //表示節點沒有環
            return false;
        }

        /// <summary>
        /// 拿學來的改良的
        /// BFS
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            List<List<int>> graph = new List<List<int>>();
            int[] degree = new int[numCourses];

            for (int i = 0; i < numCourses; i++)
                graph.Add(new List<int>());

            for (int i = 0; i < prerequisites.Length; i++)
            {
                degree[prerequisites[i][1]]++;
                graph[prerequisites[i][0]].Add(prerequisites[i][1]);
            }

            Queue<int> queue = new Queue<int>();

            int count = 0;

            List<int> result = new List<int>();

            for (int i = 0; i < degree.Length; i++)
            {
                if (degree[i] == 0)
                {
                    queue.Enqueue(i);
                    count++;
                    result.Insert(0, i);
                }
            }

            while (queue.Count != 0)
            {
                int course = queue.Dequeue();

                for (int i = 0; i < graph[course].Count; i++)
                {
                    int pointer = graph[course][i];
                    degree[pointer]--;
                    if (degree[pointer] == 0)
                    {
                        queue.Enqueue(pointer);
                        count++;
                        result.Insert(0, pointer);
                    }
                }
            }

            if (count == numCourses)
                return result.ToArray();
            else
                return new int[0];
        }
    }
}
