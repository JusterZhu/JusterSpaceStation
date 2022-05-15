using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Stack
{
    /// <summary>
    /// 队列
    /// </summary>
    public class MyQueue1
    {
        //队列最大值
        private int _maxSize;
        //队列头部
        private int _front;
        //队列尾部
        private int _rear;
        //存储值的数组
        private int[] _tempArray;

        public MyQueue1(int maxSize)
        {
            _maxSize = maxSize;
            _tempArray = new int[_maxSize];
            _front = -1;//指向队列头的前一个位置
            _rear = -1;//指向队列尾，指向队列最后一个数据
        }

        public bool IsFull()
        {
            return _rear == _maxSize - 1;
        }

        public bool IsEmpty()
        {
            return _rear == _front;
        }

        public void EnQueue(int val)
        {
            if (IsFull())
            {
                Console.WriteLine("队列已满，无法加入数据！");
                return;
            }
            _rear++;
            _tempArray[_rear] = val;
        }

        public int DeQueue()
        {
            if (IsEmpty())
            {
                throw new Exception("队列是空的，无法取出数据！");
            }
            _front++;
            return _tempArray[_front];
        }

        public void ShowAll()
        {
            if (IsEmpty())
            {
                Console.WriteLine("队列是空的!");
                return;
            }
            Console.WriteLine("显示队列所有内容：");
            foreach (var item in _tempArray)
            {
                Console.Write($"{ item }\t");
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

            Console.WriteLine($"查看第一个值:{ _tempArray[_front + 1] }");
        }
    }
}
