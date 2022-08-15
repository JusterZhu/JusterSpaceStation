using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.LinkList
{
    /// <summary>
    /// 表示一个雇员
    /// </summary>
    public class Emp 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        /// <summary>
        /// 默认为null
        /// </summary>
        public Emp Next { get; set; }
        public Emp(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
    }

    /// <summary>
    /// 创建EmpLinkedList链表
    /// </summary>
    public class EmpLinkedList 
    {
        /// <summary>
        /// 头指针，执行第一个Emp，因此我们这个链表的head时直接只想第一个emp
        /// </summary>
        public Emp Head { get; set; }
        public EmpLinkedList()
        {
            Head = null;
        }

        /// <summary>
        /// 添加雇员到链表
        /// 1.假定当添加雇员时id时自增长的，即id的分配总是从小到大。因此我们将该雇员直接加入到本地链表的最后即可
        /// </summary>
        /// <param name="emp"></param>
        public void Add(Emp emp)
        {
            if (Head == null)
            {
                Head = emp;
            }
            else
            {
                //如果不是第一个雇员，则使用一个辅助的指针，帮助定位到最后
                Emp temp = Head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = emp;
            }
        }

        /// <summary>
        ///  根据id查找雇员
        ///  如果查找到就返回，没有返回null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Emp FindEmpById(int id)
        {
            //判断链表当前是否为空
            if (Head == null)
            {
                Console.WriteLine("链表为空！");
                return null;
            }
            Emp currentEmp = Head;
            while (true)
            {
                if (currentEmp.Id == id)
                {
                    //设置时候currentemp就指向要查找到的雇员
                    break;
                }

                //退出
                if (currentEmp.Next == null)
                {
                    //说明便利当前链表没有查找到该雇员
                    currentEmp = null;
                    break;
                }
                currentEmp = currentEmp.Next;
            }
            return currentEmp;
        }

        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
            Emp temp = Head;
            while (temp != null)
            {
                Console.WriteLine(temp.Id + " " + temp.Name + " " + temp.Age);
                temp = temp.Next;
            }
        }
    }

    public class HashTable
    {
        private EmpLinkedList[] arr;
        private int _size;

        public HashTable(int size) 
        {
            arr = new EmpLinkedList[size];
            _size = size;
            //分别初始化每个链表
            for (int i = 0; i < size; i++)
            {
                arr[i] = new EmpLinkedList();
            }
        }

        /// <summary>
        /// 添加雇员
        /// </summary>
        /// <param name="emp"></param>
        public void Add(Emp emp) 
        {
            //根据员工的id，得到该员工的哈希值
            int hashCode = GetHashCode(emp.Id);
            //将emp添加到对应的链表中
            arr[hashCode].Add(emp);
        }

        public void FindEmpById(int id) 
        {
            //使用散列函数确定到那条链表查找
            int hashcode = GetHashCode(id);
            Emp emp = arr[hashcode].FindEmpById(id);
            if (emp != null)
            {
                //找到了
                Console.WriteLine($"在第{hashcode + 1}条链表中找到雇员id = { id }");
            }
            else
            {
                Console.WriteLine("在哈希表中，没有找到该雇员~");
            }
        }

        //遍历所有的链表，打印所有的雇员
        public void Print()
        {
            for (int i = 0; i < _size; i++)
            {
                arr[i].Print();
            }
        }

        //编写一个散列函数，使用一个简单的取模法
        public int GetHashCode(int id)
        {
            return id % arr.Length;
        }
    }
}
