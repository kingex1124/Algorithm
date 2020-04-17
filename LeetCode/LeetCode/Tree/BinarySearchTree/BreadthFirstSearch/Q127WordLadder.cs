using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree.BinarySearchTree.BreadthFirstSearch
{
    public class Q127WordLadder
    {
        public Q127WordLadder()
        {
            // var result = ob.LadderLength("hot", "dog", new List<string>() { "hot", "dog", "dot" });
        }

        /// <summary>
        /// 參考花花的
        /// 單向 BFS
        /// </summary>
        /// <param name="beginWord"></param>
        /// <param name="endWord"></param>
        /// <param name="wordList"></param>
        /// <returns></returns>
        public int LadderLength2(string beginWord, string endWord, IList<string> wordList)
        {
            HashSet<string> dict = new HashSet<string>(wordList);

            if (!dict.Contains(endWord))
                return 0;

            Queue<string> queue = new Queue<string>();
            queue.Enqueue(beginWord);

            int l = beginWord.Length;
            int steps = 0;

            while (queue.Count != 0)
            {
                steps++;

                //記好此作法 重要 BFS可以用
                //讓Queue 走完一輪 才會做 steps++的動作 
                //同一層 Level走完 才換下一層 level
                for (int s = queue.Count; s > 0; s--)
                {
                    string word = queue.Dequeue();
                    char[] chs = word.ToCharArray();

                    for (int i = 0; i < l; i++)
                    {
                        char ch = chs[i];
                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            chs[i] = c;
                            string t = new string(chs);
                            if (t == endWord)
                                return steps + 1;
                            if (!dict.Contains(t))
                                continue;
                            dict.Remove(t);
                            queue.Enqueue(t);
                        }
                        chs[i] = ch;
                    }
                }
            }

            return 0;
        }

        /// <summary>
        /// 參考花花的解法
        /// 雙向BFS
        /// GOOD
        /// </summary>
        /// <param name="beginWord"></param>
        /// <param name="endWord"></param>
        /// <param name="wordList"></param>
        /// <returns></returns>
        public int LadderLength1(string beginWord, string endWord, IList<string> wordList)
        {
            HashSet<string> dict = new HashSet<string>(wordList);

            if (!dict.Contains(endWord))
                return 0;

            HashSet<string> q1StartSet = new HashSet<string>();
            HashSet<string> q2EndSet = new HashSet<string>();
            q1StartSet.Add(beginWord);
            q2EndSet.Add(endWord);

            int l = beginWord.Length;
            int steps = 0;

            while (q1StartSet.Count != 0 && q2EndSet.Count != 0)
            {
                steps++;
                if (q1StartSet.Count > q2EndSet.Count)
                {
                    HashSet<string> tmp = q1StartSet;
                    q1StartSet = q2EndSet;
                    q2EndSet = tmp;
                }

                HashSet<string> qSet = new HashSet<string>();

                foreach (var word in q1StartSet)
                {
                    char[] chs = word.ToCharArray();

                    for (int i = 0; i < chs.Length; i++)
                    {
                        char ch = chs[i];
                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            chs[i] = c;
                            string t = new string(chs);

                            if (q2EndSet.Contains(t))
                                return steps + 1;
                            if (!dict.Contains(t))
                                continue;
                            dict.Remove(t);
                            qSet.Add(t);
                        }
                        chs[i] = ch;
                    }
                }
                q1StartSet = qSet;
            }
            return 0;
        }

        /// <summary>
        /// 學來的
        /// 雙向BFS
        /// 有改良過一點
        /// </summary>
        /// <param name="beginWord"></param>
        /// <param name="endWord"></param>
        /// <param name="wordList"></param>
        /// <returns></returns>
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if (!wordList.Contains(endWord))
                return 0;

            HashSet<string> dict = new HashSet<string>(wordList);
            HashSet<string> beginSet = new HashSet<string>();
            HashSet<string> endSet = new HashSet<string>();

            beginSet.Add(beginWord);
            endSet.Add(endWord);

            int step = 1;
            while (beginSet.Count != 0 && endSet.Count != 0)
            {
                if (beginSet.Count > endSet.Count)
                {
                    HashSet<string> set = beginSet;
                    beginSet = endSet;
                    endSet = set;
                }

                HashSet<string> tempSet = new HashSet<string>();
                foreach (string word in beginSet)
                {
                    char[] chs = word.ToCharArray();
                    for (int i = 0; i < chs.Length; i++)
                    {
                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            char old = chs[i];
                            chs[i] = c;
                            string target = new string(chs);
                            if (endSet.Contains(target))
                                return step + 1;
                            if (dict.Contains(target))
                            {
                                dict.Remove(target);
                                tempSet.Add(target);
                            }
                            chs[i] = old;
                        }
                    }
                }
                beginSet = tempSet;
                step++;
            }

            return 0;
        }
    }
}
