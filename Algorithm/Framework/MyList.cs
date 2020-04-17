using Algorithm.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Framework
{
    public class MyList
    {
        public MyList()
        {
            
        }

        public MyList(int maxSize)
        {
            _maxSize = maxSize;
            _myArr = new Object[_maxSize];
        }

        /// <summary>
        /// 物件陣列
        /// </summary>
        private object[] _myArr;

        /// <summary>
        /// 指定陣列數值
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>value[index]</returns>
        public object this[int index]
        {
            get
            {
                return _myArr[index];
            }
            set
            {
                try
                {
                    _myArr[index] = value;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString()); 
                }
            }
        }

        /// <summary>
        /// 陣列最大長度私有變數
        /// </summary>
        private int _maxSize;

        /// <summary>
        /// 陣列最大長度
        /// </summary>
        public int MaxSize
        {
            get
            {
                return _maxSize;
            }
            set
            {
                _maxSize = value;
            }
        }

        /// <summary>
        /// 陣列目前長度
        /// </summary>
        public int Length
        {
            get
            {
                return _myArr.Length;
            }
        }

        /// <summary>
        /// 新增元素到陣列中
        /// </summary>
        /// <param name="ob"></param>
        public bool Add(object ob)
        {
            if (_myArr.Length + 1 > _maxSize)
                return false;
            _myArr[_myArr.Length] = ob;
            return true;
        }

        /// <summary>
        /// 把陣列中位置i的資料存入e元素中
        /// </summary>
        /// <param name="i">index</param>
        /// <param name="o">元素</param>
        /// <returns>成功或失敗</returns>
        public bool GetElem(int i ,ref object o)
        {
            if (_myArr.Length == 0 || i < 0 || i > _myArr.Length)
                return false;
            o = _myArr[i];
            return true;
        }

        /// <summary>
        /// 陣列位置i插入o元素
        /// </summary>
        /// <param name="l"></param>
        /// <param name="i"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public bool Insert(int i, object o)
        {
            int k;
            if (_myArr.Length == _maxSize)
                return false;

            if (i < 0 || i > _myArr.Length-1)
                return false;

            if (i <= _myArr.Length)
            {
                for (k = _myArr.Length - 1; k > i; k--)
                    _myArr[k + 1] = _myArr[k];
            }
            _myArr[i] = o;
            return true;
        }

        /// <summary>
        /// 把index位置的元素刪除，並回傳該元素
        /// </summary>
        /// <param name="l"></param>
        /// <param name="i"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public bool DeleteByIndex(int i, ref object o)
        {
            int k;
            if (_myArr.Length == 0)
                return false;
            if (i < 0 || i > _myArr.Length - 1)
                return false;
            o = _myArr[i];
            if (i < _myArr.Length - 1)
            {
                for (k = i; k <= _myArr.Length - 1; k++)
                    _myArr[k] = _myArr[k + 1];
            }
            _myArr[_myArr.Length - 1] = null;
            return true;
        }
    }
}
