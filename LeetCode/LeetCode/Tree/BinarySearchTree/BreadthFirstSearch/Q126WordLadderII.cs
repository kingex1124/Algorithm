using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree.BinarySearchTree.BreadthFirstSearch
{
    public class Q126WordLadderII
    {
        public Q126WordLadderII()
        {

            //var result1 = ob.FindLadders("a", "c", new List<string>() { "a", "b", "c" });

            //var result = ob.FindLadders("hit", "cog", new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" });
        }

        #region BFS 單向解法1

        public class FindLaddersSol
        {
            /// <summary>
            /// 學來的
            /// </summary>
            /// <param name="beginWord"></param>
            /// <param name="endWord"></param>
            /// <param name="wordList"></param>
            /// <returns></returns>
            public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
            {
                HashSet<string> dict = new HashSet<string>(wordList);
                List<IList<string>> result = new List<IList<string>>();
                Dictionary<string, List<string>> nodeNeighbors = new Dictionary<string, List<string>>();
                Dictionary<string, int> distance = new Dictionary<string, int>();
                List<string> solution = new List<string>();

                dict.Add(beginWord);

                BFS(beginWord, endWord, dict, nodeNeighbors, distance);
                DFS(beginWord, endWord, dict, nodeNeighbors, distance, solution, result);
                return result;
            }

            private void BFS(string beginWord, string endWord, HashSet<string> dict, Dictionary<string, List<string>> nodeNeighbors, Dictionary<string, int> distance)
            {
                foreach (var str in dict)
                    nodeNeighbors.Add(str, new List<string>());

                Queue<string> quene = new Queue<string>();
                quene.Enqueue(beginWord);
                distance.Add(beginWord, 0);

                while (quene.Count != 0)
                {
                    int count = quene.Count;
                    bool foundEnd = false;

                    //同一層的BFS走完才換下一層
                    for (int i = 0; i < count; i++)
                    {
                        //cur 為 paraent
                        string cur = quene.Dequeue();
                        int curDistance = distance[cur];
                        //找回所有的孩子
                        List<string> neighbors = GetNeighbors(cur, dict);

                        //把所有孩子加到 map裡面
                        foreach (var neighbor in neighbors)
                        {
                            nodeNeighbors[cur].Add(neighbor);
                            //如果沒有該筆的距離資料 就加一筆進去
                            if (!distance.ContainsKey(neighbor))
                            {// Check if visited
                                distance.Add(neighbor, curDistance + 1);//相差一層 所以 + 1
                                //如果找到目標了，就直接標記離開
                                if (endWord == neighbor)// Found the shortest path
                                    foundEnd = true;
                                else
                                    quene.Enqueue(neighbor);
                            }
                        }
                    }
                    if (foundEnd)
                        break;
                }
            }

            private List<string> GetNeighbors(string node, HashSet<string> dict)
            {
                List<string> res = new List<string>();
                char[] chs = node.ToCharArray();

                for (char ch = 'a'; ch <= 'z'; ch++)
                {
                    for (int i = 0; i < chs.Length; i++)
                    {
                        if (chs[i] == ch) continue;
                        char old_ch = chs[i];
                        chs[i] = ch;
                        if (dict.Contains(new string(chs)))
                        {
                            res.Add(new string(chs));
                        }
                        chs[i] = old_ch;
                    }
                }
                return res;
            }

            private void DFS(string beginWord, string endWord, HashSet<string> dict, Dictionary<string, List<string>> nodeNeighbors, Dictionary<string, int> distance, List<string> solution, List<IList<string>> result)
            {
                solution.Add(beginWord);
                if (endWord == beginWord)
                    result.Add(new List<string>(solution));
                else
                {
                    foreach (var next in nodeNeighbors[beginWord])
                    {
                        if (distance[next] == distance[beginWord] + 1)
                            DFS(next, endWord, dict, nodeNeighbors, distance, solution, result);

                    }
                }
                solution.RemoveAt(solution.Count - 1);
            }
        }
        #endregion

        #region BFS 雙向解法1
        public class FindLaddersSol1
        {
            /// <summary>
            /// 學來的
            /// BFS 雙向解法
            /// </summary>
            /// <param name="beginWord"></param>
            /// <param name="endWord"></param>
            /// <param name="wordList"></param>
            /// <returns></returns>
            public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
            {
                List<IList<string>> result = new List<IList<string>>();

                if (!wordList.Contains(endWord))
                    return result;

                Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

                BFS(beginWord, endWord, wordList, map);
                List<string> temp = new List<string>();
                // temp用來保存當前的路徑
                temp.Add(beginWord);
                FindLaddersDFS(beginWord, endWord, map, temp, result);

                return result;
            }

            private void FindLaddersDFS(string beginWord, string endWord, Dictionary<string, List<string>> map, List<string> temp, List<IList<string>> result)
            {
                if (beginWord == endWord)
                {
                    result.Add(new List<string>(temp));
                    return;
                }

                //得到所有的下一個節點
                List<string> neighbors = map.ContainsKey(beginWord) ? map[beginWord] : new List<string>();
                foreach (var neighbor in neighbors)
                {
                    temp.Add(neighbor);
                    FindLaddersDFS(neighbor, endWord, map, temp, result);
                    temp.RemoveAt(temp.Count - 1);
                }
            }

            /// <summary>
            /// 利用遞迴實踐雙向搜索
            /// </summary>
            /// <param name="beginWord"></param>
            /// <param name="endWord"></param>
            /// <param name="wordList"></param>
            /// <param name="map"></param>
            private void BFS(string beginWord, string endWord, IList<string> wordList, Dictionary<string, List<string>> map)
            {
                HashSet<string> q1Set = new HashSet<string>();
                q1Set.Add(beginWord);
                HashSet<string> q2Set = new HashSet<string>();
                q2Set.Add(endWord);
                HashSet<string> wordSet = new HashSet<string>(wordList);
                BFSHelper(q1Set, q2Set, wordSet, true, map);
            }

            private bool BFSHelper(HashSet<string> q1Set, HashSet<string> q2Set, HashSet<string> wordSet, bool direction, Dictionary<string, List<string>> map)
            {
                //q1Set 為空了，就直接結束
                //筆如下邊的例子就會造成 q1Set為空
                /*  "hot"
                    "dog"
                ["hot","dog"]*/
                if (q1Set.Count == 0)
                    return false;

                // q1Set 的數量多，就反向擴展
                if (q1Set.Count > q2Set.Count)
                    return BFSHelper(q2Set, q1Set, wordSet, !direction, map);

                //將已經訪問過單詞刪除
                foreach (var q1 in q1Set)
                    wordSet.Remove(q1);
                foreach (var q2 in q2Set)
                    wordSet.Remove(q2);

                bool done = false;

                //保存新擴展得到的節點
                HashSet<string> set = new HashSet<string>();

                foreach (var str in q1Set)
                {
                    //遍歷每一位
                    for (int i = 0; i < str.Length; i++)
                    {
                        char[] chars = str.ToCharArray();

                        // 嘗試所有字母
                        for (char ch = 'a'; ch < 'z'; ch++)
                        {
                            if (chars[i] == ch)
                                continue;
                            chars[i] = ch;

                            string word = new string(chars);

                            //根據方向得到 map 的 key 和 val
                            string key = direction ? str : word;
                            string val = direction ? word : str;

                            List<string> list = map.ContainsKey(key) ? map[key] : new List<string>();

                            //如果相遇了就保存結果
                            if (q2Set.Contains(word))
                            {
                                done = true;
                                list.Add(val);
                                if (map.ContainsKey(key))
                                    map[key] = list;
                                else
                                    map.Add(key, list);
                            }

                            //還沒有相遇，並且新的單詞在 word中，那麼就加到 Set 中
                            if (!done && wordSet.Contains(word))
                            {
                                set.Add(word);
                                list.Add(val);
                                if (map.ContainsKey(key))
                                    map[key] = list;
                                else
                                    map.Add(key, list);
                            }
                        }
                    }
                }

                //一般情況下新擴展的元素會多一些，所以我們下次反方向擴展 q2Set
                return done || BFSHelper(q2Set, set, wordSet, !direction, map);
            }

        }
        #endregion

        #region BFS單向 九章解法 會timeout

        public class FindLaddersSol3
        {
            /// <summary>
            /// BFS單向
            /// 九章解法
            /// </summary>
            /// <param name="beginWord"></param>
            /// <param name="endWord"></param>
            /// <param name="wordList"></param>
            /// <returns></returns>
            public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
            {
                List<IList<string>> result = new List<IList<string>>();

                if (!wordList.Contains(endWord))
                    return result;

                Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
                Dictionary<string, int> distance = new Dictionary<string, int>();

                wordList.Add(beginWord);
                wordList.Add(endWord);

                BFS(map, distance, endWord, beginWord, wordList);

                List<string> path = new List<string>();

                DFS(result, path, beginWord, endWord, distance, map);

                return result;
            }

            private void BFS(Dictionary<string, List<string>> map, Dictionary<string, int> distance, string beginWord, string endWord, IList<string> wordList)
            {
                Queue<string> queue = new Queue<string>();
                queue.Enqueue(beginWord);
                distance.Add(beginWord, 0);

                foreach (var s in wordList)
                    if (!map.ContainsKey(s))
                        map.Add(s, new List<string>());

                while (queue.Count != 0)
                {
                    string cur = queue.Dequeue();

                    List<string> nextList = Expand(cur, wordList);

                    foreach (var next in nextList)
                    {
                        map[next].Add(cur);
                        if (!distance.ContainsKey(next))
                        {
                            distance.Add(next, distance[cur] + 1);
                            queue.Enqueue(next);
                        }
                    }
                }
            }

            private void DFS(List<IList<string>> result, List<string> path, string cur, string endWord, Dictionary<string, int> distance, Dictionary<string, List<string>> map)
            {
                path.Add(cur);
                if (cur == endWord)
                    result.Add(new List<string>(path));
                else
                {
                    foreach (var next in map[cur])
                        if (distance.ContainsKey(next) && distance[cur] == distance[next] + 1)
                            DFS(result, path, next, endWord, distance, map);
                }
                path.RemoveAt(path.Count - 1);
            }



            private List<string> Expand(string node, IList<string> dict)
            {
                List<string> res = new List<string>();
                char[] chs = node.ToCharArray();

                for (char ch = 'a'; ch <= 'z'; ch++)
                {
                    for (int i = 0; i < chs.Length; i++)
                    {
                        if (chs[i] == ch) continue;
                        char old_ch = chs[i];
                        chs[i] = ch;
                        if (dict.Contains(new string(chs)))
                            res.Add(new string(chs));

                        chs[i] = old_ch;
                    }
                }
                return res;
            }
        }

        #endregion

        #region 只用BFS單向解法 但會 timeout

        public class FindLaddersSol2
        {
            /// <summary>
            /// BFS單向解法 會跑到 timeout
            /// </summary>
            /// <param name="beginWord"></param>
            /// <param name="endWord"></param>
            /// <param name="wordList"></param>
            /// <returns></returns>
            public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
            {
                List<IList<string>> result = new List<IList<string>>();

                if (!wordList.Contains(endWord))
                    return result;

                BFS(beginWord, endWord, wordList, result);

                return result;
            }

            private void BFS(string beginWord, string endWord, IList<string> wordList, List<IList<string>> result)
            {
                Queue<List<string>> queue = new Queue<List<string>>();
                List<string> path = new List<string>();

                path.Add(beginWord);
                queue.Enqueue(path);
                bool isFound = false;
                HashSet<string> dict = new HashSet<string>(wordList);
                HashSet<string> visited = new HashSet<string>();
                visited.Add(beginWord);

                while (queue.Count != 0)
                {
                    int size = queue.Count;
                    HashSet<string> subVisited = new HashSet<string>();
                    for (int i = 0; i < size; i++)
                    {
                        List<string> p = queue.Dequeue();
                        // 得到當前路徑的末尾單詞
                        string temp = p[p.Count - 1];
                        // 一次性得到所有的下一個的節點
                        List<string> neighbors = GetNeighbors(temp, dict);
                        foreach (var neighbor in neighbors)
                        {
                            //只考慮之前沒有出現過的單詞
                            if (!visited.Contains(neighbor))
                            {
                                // 到達結束單詞
                                if (neighbor == endWord)
                                {
                                    isFound = true;
                                    p.Add(neighbor);
                                    result.Add(new List<string>(p));
                                    p.RemoveAt(p.Count - 1);
                                }
                                //加入當前單詞
                                p.Add(neighbor);
                                queue.Enqueue(new List<string>(p));
                                p.RemoveAt(p.Count - 1);
                                subVisited.Add(neighbor);
                            }
                        }
                    }
                    foreach (var item in subVisited)
                        visited.Add(item);
                    if (isFound)
                        break;

                }
            }

            private List<string> GetNeighbors(string node, HashSet<string> dict)
            {
                List<string> res = new List<string>();
                char[] chs = node.ToCharArray();

                for (char ch = 'a'; ch <= 'z'; ch++)
                {
                    for (int i = 0; i < chs.Length; i++)
                    {
                        if (chs[i] == ch) continue;
                        char old_ch = chs[i];
                        chs[i] = ch;
                        if (dict.Contains(new string(chs)))
                            res.Add(new string(chs));

                        chs[i] = old_ch;
                    }
                }
                return res;
            }
        }

        #endregion
    }
}
