using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LeetCode.LeetCode.Tree.BinarySearchTree.BreadthFirstSearch
{
    public class Q449SerializeAndDeserializeBST
    {
        public Q449SerializeAndDeserializeBST()
        {
            TreeNode pr = new TreeNode(2) { left = new TreeNode(1), right = new TreeNode(3) };
            Codec c = new Codec();
            string st = c.serialize(pr);
            var result = c.deserialize(st);
        }
        /// <summary>
        /// 序列化是參考九章 反序列化是自己寫的
        /// </summary>
        public class Codec
        {
            public string split = ",";
            public string non = "#";

            // Encodes a tree to a single string.
            public string serialize(TreeNode root)
            {
                if (root == null)
                    return non;

                StringBuilder sb = new StringBuilder();
                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(root);

                while (queue.Count != 0)
                {
                    TreeNode node = queue.Dequeue();

                    if (node == null)
                        sb.Append(non).Append(split);
                    else
                    {
                        sb.Append(node.val).Append(split);
                        queue.Enqueue(node.left);
                        queue.Enqueue(node.right);
                    }
                }
                sb.Remove(sb.Length - 1, 1);
                return sb.ToString();
            }

            // Decodes your encoded data to tree.
            public TreeNode deserialize(string data)
            {
                if (data.Length == 0)
                    return null;
                string[] node = data.Split(',');

                TreeNode result = null;
               
                foreach (var item in node)
                {
                    if (item != "#")
                    {
                        int nodeVal = Convert.ToInt32(item);
                        if (result == null)
                            result = new TreeNode(nodeVal);
                        else
                        {
                            Stack<TreeNode> stack = new Stack<TreeNode>();
                            stack.Push(result);
                            while (stack.Count != 0)
                            {
                                TreeNode nodeTmp = stack.Pop();
                                if (nodeVal < nodeTmp.val && nodeTmp.left != null)
                                    nodeTmp = nodeTmp.left;
                                else if (nodeVal >= nodeTmp.val && nodeTmp.right != null)
                                    nodeTmp = nodeTmp.right;
                                else if (nodeVal < nodeTmp.val && nodeTmp.left == null)
                                {
                                    nodeTmp.left = new TreeNode(nodeVal);
                                    break;
                                }
                                else if (nodeVal >= nodeTmp.val && nodeTmp.right == null)
                                {
                                    nodeTmp.right = new TreeNode(nodeVal);
                                    break;
                                }
                                stack.Push(nodeTmp);
                            }
                        }
                    }
                }

                return result;
            }
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}