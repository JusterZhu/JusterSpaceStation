using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Stack
{
    /// <summary>
    /// 环形队列
    /// </summary>
    public class CircleArrayQueue
    {
        //队列最大值
        private int _maxSize;
        //队列头部
        private int _front;
        //队列尾部
        private int _rear;
        //存储值的数组
        private int[] _tempArray;

        public CircleArrayQueue(int maxSize)
        {
            Console.WriteLine($"MaxSize : { maxSize }");
            _maxSize = maxSize;
            _tempArray = new int[_maxSize];
            //front指向队列第一个元素
            _front = 0;
            //rear指向队列的最后一个元素的后一个位置
            _rear = 0;
        }

        public bool IsFull()
        {
            return (_rear + 1) % _maxSize == _front;
        }

        public bool IsEmpty()
        {
            return _rear == _front;
        }

        /// <summary>
        /// 有效数据个数
        /// </summary>
        /// <returns></returns>
        public int Num()
        {
            return (_rear + _maxSize - _front) % _maxSize;
        }

        public void EnQueue(int val)
        {
            if (IsFull())
            {
                Console.WriteLine("队列已满，无法加入数据！");
                return;
            }
            //直接插入数据
            _tempArray[_rear] = val;
            //_rear后移一位，这里必须考虑取模
            _rear = (_rear + 1) % _maxSize;
        }

        public int DeQueue()
        {
            if (IsEmpty())
            {
                throw new Exception("队列是空的，无法取出数据！");
            }
            //这里需要分析出front是指向队列的第一个元素
            //1.先把front对应的值保留到一个临时变量
            //2.将front后移
            //3.将临时保存的变量返回

            var tempVal = _tempArray[_front];
            _front = (_front + 1) % _maxSize;
            return tempVal;
        }

        public void ShowAll()
        {
            if (IsEmpty())
            {
                Console.WriteLine("队列是空的!");
                return;
            }
            Console.WriteLine("显示队列所有内容：");
            for (int i = _front; i < _front + Num(); i++)
            {
                Console.Write($"{ _tempArray[i % _maxSize] }\t");
            }
            Console.WriteLine();
        }

        public void PeekFirst()
        {
            if (IsEmpty())
            {
                Console.WriteLine("队列是空的，无法取出数据！");
                return;
            }

            Console.WriteLine($"查看第一个值:{ _tempArray[_front] }");
        }
    }
}
