using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Udemy
{
    public class ReduceAggregate
    {
        public ReduceAggregate()
        {

        }

        public static void test()
        {
            var list1 = new List<SuperClass>()
        {
            new SuperClass(0),    //元素0
            new SuperClass(1),    //元素1
            new SuperClass(2),    //元素2
        };

            //Select，结果为{元素0, 元素1, 元素2}，类型为List<ClassA>
            List<ClassA> list2 = list1.Select(e => e as ClassA).ToList();

            //Where，结果为{元素1, 元素2}，类型为List<ClassA>
            List<ClassA> list3 = list2.Where(e => e.Value > 0).ToList();

            //Aggregate，结果为3，类型为int
            int sum = list3.Aggregate(0, (acc, e) => acc += e.Value);
        }

        class ClassA : SuperClass
        {
            public ClassA(int value) : base(value) { }
        }

        class SuperClass
        {
            public int Value { get; set; }
            public SuperClass(int value)
            {
                this.Value = value;
            }
        }
    }
}
