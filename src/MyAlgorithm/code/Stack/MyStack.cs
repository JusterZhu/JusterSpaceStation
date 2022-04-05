using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Stack
{
    //MyStack myStack = new MyStack(5);
    //myStack.Push(10);
    //myStack.Push(7);
    //myStack.Push(8);
    //myStack.Push(1);
    //myStack.Push(3);
    //myStack.Print();
    //myStack.Pop();
    //myStack.Pop();
    //myStack.Print();

    internal class MyStack
    {
        private int maxSize;//栈的大小
        private int[] stackArray;//数组模拟栈
        private int top = -1;

        public MyStack(int maxSize)
        {
            this.maxSize = maxSize;
            this.stackArray = new int[maxSize];
        }

        /// <summary>
        /// 栈满
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            return top == maxSize - 1;
        }

        /// <summary>
        /// 栈空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return top == -1;
        }

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="value"></param>
        public void Push(int value)
        {
            if (IsFull())
            {
                Console.WriteLine("栈满");
            }

            top++;
            stackArray[top] = value;
        }

        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        public int Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("栈空，没有数据！");
            }
            return stackArray[top--];
        }

        /// <summary>
        /// 打印，遍历时需要从栈顶开始显示数据
        /// </summary>
        public void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("栈空，没有数据！");
                return;
            }

            for (int i = top; i >= 0; i--)
            {
                Console.WriteLine("值：" + stackArray[i]);
            }

            Console.WriteLine();
        }
    }
}
