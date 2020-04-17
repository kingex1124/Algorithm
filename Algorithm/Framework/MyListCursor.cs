using Algorithm.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Framework
{
    public class MyListCursor
    {
        public MyListCursor()
        {

        }

        public MyListCursor(int maxSize)
        {
            _maxSize = maxSize;
            _myArr = new CursorData[_maxSize];
            InitList();
        }

        /// <summary>
        /// 物件陣列
        /// </summary>
        private CursorData[] _myArr;

        /// <summary>
        /// 指定陣列數值
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>value[index]</returns>
        public CursorData this[int index]
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
        /// 初始化陣列
        /// </summary>
        public void InitList()
        {

            for (int i = 0; i < MaxSize - 1; i++)
                _myArr[i] = new CursorData() { cur = i + 1, last = i - 1 };

            //目前靜態鏈結串列為空，最後一個元素的Cur為0
            _myArr[MaxSize - 1] = new CursorData() { cur = 1 };
            _myArr[0].data = "$";
        }

        /// <summary>
        /// 若備用空間鏈結串列非為空，則傳回分配的節點編號，否則傳回0
        /// </summary>
        /// <returns></returns>
        public int Malloc_SLL()
        {
            int i = _myArr[0].cur;

            _myArr[0].cur = _myArr[i].cur;

            return i;
        }

        /// <summary>
        /// 插入o在陣列i的位置
        /// </summary>
        /// <param name="i"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public bool ListInsert(int i, object o)
        {
            int j, k;
            //最後一個位置
            k = MaxSize - 1;
            //驗證插入位置是否超過範圍
            if (i < 1 || i > _myArr.Length)
                return false;
            //取得最後一個空值位置
            j = Malloc_SLL();
            if (j != 0)
            {
                _myArr[j].data = o;
                //選定cus要插入的下一個位置在哪邊
                for (int l = 1; l <= i - 1; l++)
                    k = _myArr[k].cur;
                //原本的下一個，給插入的元素
                _myArr[j].cur = _myArr[k].cur;

                _myArr[j].last = k;
                //新插入的位置給原本的下一個元素
                _myArr[k].cur = j;

                _myArr[_myArr[j].cur].last = j;
                //原本最後一個元素要指向下下一個位置
                //_myArr[j - 1].cur = j + 1;

                return true;
            }
            return false;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public bool ListAdd(object o)
        {
            if (o == null)
                return false;
            int j = _myArr[0].cur;
            _myArr[j].data = o;
          
            Malloc_SLL();
            _myArr[j].cur = 0;

            if (_myArr[j].last == 0)
                return true;
            _myArr[_myArr[j].last].cur = j;
            return true;
        }

        /// <summary>
        /// 尋找第i個位置的元素值(不含0)
        /// </summary>
        /// <param name="i"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public bool GetElem(int i,ref object o)
        {         
            if (i < 1 || i > _myArr.Length)
                return false;
            int k = MaxSize - 1;
            for (int j = i; j > 0; j--)
                k = _myArr[k].cur;

            o = _myArr[k].data;
            return true;
        }

        /// <summary>
        /// 修改第i個位置元素的值
        /// </summary>
        /// <param name="i"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public bool Updata(int i, object o)
        {
            bool result = false;

            if (i < 1 || i > _myArr.Length)
                return false;
            int k = MaxSize - 1;
            for (int j = i; j > 0; j--)
                k = _myArr[k].cur;

            _myArr[k].data = o;
            return result;
        }

        public bool ListDelete(int i)
        {
            int j, k;
            if (i < 1 || i > _myArr.Length)
                return false;

            k = MaxSize - 1;
            for (j = 1; j <= i - 1; j++)
                k = _myArr[k].cur;
            j = _myArr[k].cur;
            _myArr[k].cur = _myArr[j].cur;
            
            Free_SSL(j);
            return true ;
        }

        public void Free_SSL(int j)
        {
            _myArr[j].cur = _myArr[0].cur;
            _myArr[0].cur = j;
           
        }
    }
}
