using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode.Tree.BinarySearchTree.BreadthFirstSearch
{
    public class Q297SerializeandDeserializeBinaryTree
    {
        public Q297SerializeandDeserializeBinaryTree()
        {
            //var result = ob.deserialize(ob.serialize(null));
        }

        /// <summary>
        /// 學來的
        /// 迭代解法
        /// BFS
        /// </summary>
        public class Codec2
        {
            public string split = ",";
            public string non = "#";

            // Encodes a tree to a single string.
            public string serialize(TreeNode root)
            {
                if (root == null)
                    return string.Empty;
                StringBuilder sb = new StringBuilder();
                Queue<TreeNode> que = new Queue<TreeNode>();
                que.Enqueue(root);
                sb.Append(root.val).Append(split);

                while (que.Count != 0)
                {
                    TreeNode node = que.Dequeue();
                    if (node.left == null)
                        sb.Append(non).Append(split);
                    else
                    {
                        que.Enqueue(node.left);
                        sb.Append(node.left.val).Append(split);
                    }
                    if (node.right == null)
                        sb.Append(non).Append(split);
                    else
                    {
                        que.Enqueue(node.right);
                        sb.Append(node.right.val).Append(split);
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
                Queue<TreeNode> que = new Queue<TreeNode>();
                TreeNode root = new TreeNode(Convert.ToInt32(node[0]));
                que.Enqueue(root);

                int i = 1;
                while (que.Count != 0)
                {
                    Queue<TreeNode> nextQue = new Queue<TreeNode>();
                    while (que.Count != 0 && i < node.Length)
                    {
                        TreeNode curr = que.Dequeue();
                        if (node[i] == "#")
                            curr.left = null;
                        else
                        {
                            curr.left = new TreeNode(Convert.ToInt32(node[i]));
                            nextQue.Enqueue(curr.left);
                        }
                        i++;
                        if (node[i] == "#")
                            curr.right = null;
                        else
                        {
                            curr.right = new TreeNode(Convert.ToInt32(node[i]));
                            nextQue.Enqueue(curr.right);
                        }
                        i++;
                    }
                    que = nextQue;
                }
                return root;
            }
        }

        /// <summary>
        /// 學來的
        /// 迭代解法
        /// DFS
        /// </summary>
        public class Codec1
        {
            public string split = ",";
            public string non = "#";

            // Encodes a tree to a single string.
            public string serialize(TreeNode root)
            {
                if (root == null)
                    return string.Empty;
                StringBuilder sb = new StringBuilder();
                
                Stack<TreeNode> stack = new Stack<TreeNode>();
                while (root != null || stack.Count != 0)
                {
                    if (root != null)
                    {
                        sb.Append(root.val).Append(split);
                        stack.Push(root);
                        root = root.left;
                    }
                    else
                    {
                        sb.Append(non).Append(split);
                        root = stack.Pop();
                        root = root.right;
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
                int ln = node.Length;
                Stack<TreeNode> stack = new Stack<TreeNode>();
                TreeNode root = new TreeNode(Convert.ToInt32(node[0]));
                TreeNode curr = root;
                stack.Push(curr);

                int i = 1;
                while (i < ln)
                {
                    while (i < ln && node[i] != "#")
                    {
                        curr.left = new TreeNode(Convert.ToInt32(node[i++]));
                        curr = curr.left;
                        stack.Push(curr);
                    }
                    while (i < ln && node[i] == "#")
                    {
                        curr = stack.Pop();
                        i++;
                    }
                    if(i < ln)
                    {
                        curr.right = new TreeNode(Convert.ToInt32(node[i++]));
                        curr = curr.right;
                        stack.Push(curr);
                    }
                }
                return root;
            }
        }

        /// <summary>
        /// 學來的解法1
        /// 遞迴解 DFS
        /// </summary>
        public class Codec
        {
            public string split = ",";
            public string non = "#";

            // Encodes a tree to a single string.
            public string serialize(TreeNode root)
            {
                StringBuilder sb = new StringBuilder();
                BuildString(root, sb);
                sb.Remove(sb.Length - 1, 1);
                return sb.ToString();
            }

            public void BuildString(TreeNode node, StringBuilder sb)
            {
                if (node == null)
                    sb.Append(non).Append(split);
                else
                {
                    sb.Append(node.val).Append(split);
                    BuildString(node.left, sb);
                    BuildString(node.right, sb);
                }
            }

            // Decodes your encoded data to tree.
            public TreeNode deserialize(string data)
            {
                List<string> node = new List<string>();
                node.AddRange(data.Split(','));
                return BuildTree(node);
            }

            public TreeNode BuildTree(List<string> nodes)
            {
                string val = nodes[0];
                nodes.RemoveAt(0);

                if (val == non)
                    return null;
                else
                {
                    TreeNode node = new TreeNode(Convert.ToInt32(val));
                    node.left = BuildTree(nodes);
                    node.right = BuildTree(nodes);
                    return node;
                }
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
