using LeetCode.Udemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Helper
{
    public class QuickBuildTree
    {
        public QuickBuildTree()
        {

        }

        //public TreeNode BuildTreeByList(List<int> list)
        //{
        //    TreeNode result=new TreeNode(list.First());

        //    for (int i = 1; i < list.Count; i++)
        //        result.Insert(list[i]);
                
        //    return result;
        //}

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}
