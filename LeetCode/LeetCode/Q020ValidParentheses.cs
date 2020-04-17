using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class Q020ValidParentheses
    {
        public Q020ValidParentheses()
        {
            //   var result = ob.IsValid("()[]{}");
        }

        /// <summary>
        /// 網路上查的
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid(string s)
        {
            if (s.Count() % 2 == 1)
                return false;
            List<char> stock = new List<char>();
            int count = 0;
            foreach (var item in s)
            {
                if (item == '(' || item == '[' || item == '{')
                {
                    stock.Add(item);
                    count++;
                }
                else
                {
                    if (count == 0) return false;
                    if (item == ')' && stock[count - 1] != '(') return false;
                    if (item == ']' && stock[count - 1] != '[') return false;
                    if (item == '}' && stock[count - 1] != '{') return false;
                    stock.RemoveAt(stock.Count - 1);
                    count--;
                }
            }
            return !stock.Any();
        }

        /// <summary>
        /// 自己想的方法
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid1(string s)
        {
            if (s.Count() % 2 == 1)
                return false;
            List<char> stock = new List<char>();

            foreach (var item in s)
            {
                switch (item)
                {
                    case '(':
                    case '[':
                    case '{':
                        stock.Add(item);
                        break;
                    case ')':
                        for (int i = stock.Count - 1; i >= 0; i--)
                        {
                            if (stock[i] == '(')
                            {
                                stock.RemoveAt(i);
                                break;
                            }
                            else
                                return false;
                        }
                        break;
                    case ']':
                        for (int i = stock.Count - 1; i >= 0; i--)
                        {
                            if (stock[i] == '[')
                            {
                                stock.RemoveAt(i);
                                break;
                            }
                            else
                                return false;
                        }
                        break;
                    case '}':
                        for (int i = stock.Count - 1; i >= 0; i--)
                        {
                            if (stock[i] == '{')
                            {
                                stock.RemoveAt(i);
                                break;
                            }
                            else
                                return false;
                        }
                        break;
                }
            }
            return !stock.Any();
        }

        /// <summary>
        /// 自己寫的改良版
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid2(string s)
        {
            if (s.Count() % 2 == 1)
                return false;
            List<char> stock = new List<char>();
            int count = 0;
            foreach (var item in s)
            {
                switch (item)
                {
                    case '(':
                    case '[':
                    case '{':
                        stock.Add(item);
                        count++;
                        break;
                    case ')':
                        if (count == 0) return false;
                        if (stock[count - 1] == '(')
                        {
                            stock.RemoveAt(count - 1);
                            count--;
                            break;
                        }
                        else
                            return false;
                    case ']':
                        if (count == 0) return false;
                        if (stock[count - 1] == '[')
                        {
                            stock.RemoveAt(count - 1);
                            count--;
                            break;
                        }
                        else
                            return false;
                    case '}':
                        if (count == 0) return false;
                        if (stock[count - 1] == '{')
                        {
                            stock.RemoveAt(count - 1);
                            count--;
                            break;
                        }
                        else
                            return false;
                }
            }
            return !stock.Any();
        }
    }
}
