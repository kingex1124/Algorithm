using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree.Graph
{
    public class Q207CourseSchedule
    {
        public Q207CourseSchedule()
        {
            //int[][] pr = new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 1, 2 } };
            //int[][] pr1 = new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 3, 4 } };
            ////2=>1>=0  2=>0 2=>1 1+2=>0
            //var resutl = ob.CanFinish(5, pr1);
        }

        /// <summary>
        /// Topological Sort
        /// DFS 花花
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public bool CanFinish2(int numCourses, int[][] prerequisites)
        {
            List<List<int>> graph = new List<List<int>>();
            for (int i = 0; i < numCourses; i++)
                graph.Add(new List<int>());

            // states: 0 = unkonwn, 1 == visiting, 2 = visited
            int[] visite = new int[numCourses];
            for (int i = 0; i < prerequisites.Length; i++)
                graph[prerequisites[i][0]].Add(prerequisites[i][1]);

            for (int i = 0; i < numCourses; i++)
                if (DFS1(graph, visite, i))
                    return false;
            return true;
        }

        private bool DFS1(List<List<int>> graph, int[] visite, int course)
        {
            if (visite[course] == 1)
                return true;
            if (visite[course] == 2)
                return false;

            visite[course] = 1;
            for (int i = 0; i < graph[course].Count; i++)
                if (DFS1(graph, visite, graph[course][i]))
                    return true;

            visite[course] = 2;

            //沒有發現環
            return false;
        }

        /// <summary>
        /// DFS解法
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public bool CanFinish1(int numCourses, int[][] prerequisites)
        {
            List<List<int>> graph = new List<List<int>>();
            for (int i = 0; i < numCourses; i++)
                graph.Add(new List<int>());

            //false 沒訪問過 true 表示訪問過 或正在訪問
            bool[] visited = new bool[numCourses];
            for (int i = 0; i < prerequisites.Length; i++)
                graph[prerequisites[i][0]].Add(prerequisites[i][1]);

            for (int i = 0; i < numCourses; i++)
                if (!DFS(graph, visited, i))
                    return false;
            return true;
        }

        private bool DFS(List<List<int>> graph, bool[] visited, int course)
        {
            if (visited[course])
                return false;
            else
                visited[course] = true;

            for (int i = 0; i < graph[course].Count; i++)
                if (!DFS(graph, visited, graph[course][i]))
                    return false;
            visited[course] = false;

            //沒有發現環
            return true;
        }

        /// <summary>
        /// BFS
        /// O(n)
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            //邊
            //用來存每門課要先修的課程有哪些 [要修的課][先修的課]
            List<List<int>> graph = new List<List<int>>();
            //用來存要先修的課總共被使用的次數
            int[] degree = new int[numCourses];
            Queue<int> queue = new Queue<int>();
            int count = 0;
            for (int i = 0; i < numCourses; i++)
                graph.Add(new List<int>());

            for (int i = 0; i < prerequisites.Length; i++)
            {
                degree[prerequisites[i][1]]++;
                graph[prerequisites[i][0]].Add(prerequisites[i][1]);
            }

            for (int i = 0; i < degree.Length; i++)
            {
                //沒有被列為先修課的課程先放入Q、或已經先修完的課放入Q(不再被當成先修課的課)
                //先取不需要先被修的課程
                //如果都沒有，就表示循環 最後會回傳false
                if (degree[i] == 0)
                {
                    queue.Enqueue(i);
                    count++;
                }
            }

            while (queue.Count != 0)
            {
                //取出要修的課
                int course = queue.Dequeue();
                //迴圈跑的是這門要修的課，所有的先修課程
                for (int i = 0; i < graph[course].Count; i++)
                {
                    //取出先修課程
                    int pointer = graph[course][i];
                    //扣掉該門課被需要的次數
                    degree[pointer]--;
                    //不再被需要的時候就放入Q
                    if (degree[pointer] == 0)
                    {
                        queue.Enqueue(pointer);
                        //不再被需要表示該門課已經修完了，所以+1(已修)
                        count++;
                    }
                }
            }
            //已修的課==所有課表示能修完
            if (count == numCourses)
                return true;
            else
                return false;
        }
    }
}
