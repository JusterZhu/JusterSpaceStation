namespace IteratorPatternDemo
{
    using System;
    using System.Collections;

    // 定义一个集合类
    class MyCollection : IEnumerable
    {
        private object[] items = new object[5];

        public MyCollection()
        {
            // 初始化集合元素
            for (int i = 0; i < 5; i++)
            {
                items[i] = i;
            }
        }

        // 实现IEnumerable接口的方法，返回一个迭代器对象
        public IEnumerator GetEnumerator()
        {
            return new MyIterator(items);
        }
    }

    // 定义一个迭代器类
    class MyIterator : IEnumerator
    {
        private object[] items;
        private int position = -1;

        public MyIterator(object[] items)
        {
            this.items = items;
        }

        // 实现IEnumerator接口的属性和方法
        public object Current
        {
            get { return items[position]; }
        }

        public bool MoveNext()
        {
            position++;
            return position < items.Length;
        }

        public void Reset()
        {
            position = -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyCollection collection = new MyCollection();
            foreach (int item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }

}
