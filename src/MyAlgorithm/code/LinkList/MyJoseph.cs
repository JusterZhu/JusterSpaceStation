using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.LinkList
{
//    MyJoseph myJoseph = new MyJoseph();
//    myJoseph.addPerson(5);
//myJoseph.Print();
//myJoseph.Kill(1,2,5);
//myJoseph.Print();

    /// <summary>
    /// 约瑟夫环
    /// </summary>
    public class PersonNode
    {
        public int Id { get; set; }

        public PersonNode(int id)
        {
            Id = id;
        }

        public PersonNode NextPerson { get; set; }
    }

    /// <summary>
    /// 创建一个环形的单向链表
    /// </summary>
    public class MyJoseph
    {
        //创建一个头节点，不包含任何意义的数据
        private PersonNode first = new PersonNode(-1);

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="num">需要创建几个节点</param>
        public void addPerson(int num)
        {
            if (num <= 0)
            {
                Console.WriteLine("num的值不正确");
                return;
            }

            //辅助指针帮助构建环形链表
            PersonNode currentNode = null;

            //使用for循环创建我们的环形链表
            for (int i = 1; i <= num; i++)
            {
                //根据编号创建节点
                PersonNode person = new PersonNode(i);

                //如果是第一个节点
                if (i == 1)
                {
                    first = person;
                    first.NextPerson = first; //构成环形
                    currentNode = first;//让currentNode指向第一个节点，因为fist节点不能动
                }
                else
                {
                    //让当前节点指向新增加的节点
                    currentNode.NextPerson = person;
                    //将新增的节点指向第一个节点完成闭环
                    person.NextPerson = first;
                    //改变当前节点的位置
                    currentNode = person;
                }
            }
        }

        public void Print()
        {
            if (first == null)
            {
                Console.WriteLine("链表为空");
                return;
            }

            PersonNode currentNode = first;
            while (true)
            {
                Console.WriteLine($"编号{ currentNode.Id }");
                if (currentNode.NextPerson == first) break;
                currentNode = currentNode.NextPerson;
            }
        }

        /// <summary>
        /// 踢出圈
        /// </summary>
        /// <param name="startId">从第几个人开始踢</param>
        /// <param name="num">数几次</param>
        /// <param name="personNum">圈内总人数</param>
        public void Kill(int startId, int num, int personNum)
        {
            if (first == null || startId < 1 || startId > personNum)
            {
                Console.WriteLine("参数有误");
                return;
            }

            PersonNode temp = first;

            //找到最后一个节点
            while (true)
            {
                //等式成立则代表遍历到最后
                if (temp.NextPerson == first) break;
                temp = temp.NextPerson;
            }

            //first 和 temp 向前移动一个节点
            for (int i = 0; i < startId - 1; i++)
            {
                first = first.NextPerson;
                temp = temp.NextPerson;
            }

            while (true)
            {
                if (temp == first) break;

                //从当前节点往后数，数出需要出圈的人
                for (int i = 0; i < num - 1; i++)
                {
                    first = first.NextPerson;
                    temp = temp.NextPerson;
                }
                Console.WriteLine($"Person出圈{ first.Id }");
                first = first.NextPerson;
                temp.NextPerson = first;
            }
            Console.WriteLine($"最后留在圈中的Person{ first.Id }");
        }
    }
}
