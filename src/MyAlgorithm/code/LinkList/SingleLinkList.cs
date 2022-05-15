using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.LinkList
{
    //var node1 = new DataNode(1, "法外狂徒张三", "三哥");
    //var node2 = new DataNode(2, "隔壁李四", "四哥");
    //var node3 = new DataNode(3, "楼下王五", "五哥");
    //var node4 = new DataNode(4, "同学老六", "六哥");

    //var list = new SingleLinkedList();
    ///* list.Add(node1);
    // list.Add(node4);
    // list.Add(node2);
    // list.Add(node3);*/

    //list.AddNodeByOrder(node1);
    //        list.AddNodeByOrder(node4);
    //        list.AddNodeByOrder(node2);
    //        list.AddNodeByOrder(node3);

    //        list.List();
    //        Console.WriteLine();
    //        //修改节点
    //        //var newNode = new DataNode(2, "Juster", "Justerter!!!");
    //        //list.Update(newNode);

    //        //删除节点
    //        list.Delete(1);
    //        list.Delete(4);
    //        list.Delete(2);
    //        list.Delete(3);
    //        list.List();

    public class DataNode
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NikeName { get; set; }

        //指向下一个节点
        public DataNode NextNode { get; set; }

        public DataNode(int id, string name, string nikeName)
        {
            Id = id;
            Name = name;
            NikeName = nikeName;
        }

        public override string ToString()
        {
            return $"DataNode[{Id},{Name},{NikeName}]";
        }
    }

    /// <summary>
    /// 单链表
    /// </summary>
    public class SingleLinkedList
    {
        /*
         * 定义一个头节点，保证不要改动它因为被修改之后就找不到链表的最顶端。
         * 先初始化一个头节点，头节点不要动，不存放具体的数据
         */
        private DataNode head = new DataNode(0, "", "");

        /*
         * 当不考虑编号的顺序时
         * 1.找到当前链表的最后节点
         * 2.将最后这个节点的next域指向新的节点即可
         */
        public void Add(DataNode node)
        {
            //因为head节点不能改动，因此我们需要一个辅助变量辅助遍历temp
            DataNode temp = head;
            //遍历链表，找到最后
            while (true)
            {
                //找到链表的最后
                if (temp.NextNode == null)
                {
                    break;
                }

                //如果没有找到则后移
                temp = temp.NextNode;
            }
            //当推出while循环时，temp就指向了链表的最后
            //将最后这个节点的next指向新的节点
            temp.NextNode = node;
        }

        //显示链表（遍历）
        public void List()
        {
            if (head.NextNode == null)
            {
                Console.WriteLine("链表为空");
                return;
            }
            //因为头节点不能改动，因此我们需要一个辅助变量来遍历
            DataNode temp = head.NextNode;
            while (true)
            {
                //判断是否到链表最后
                if (temp == null)
                {
                    break;
                }
                //输出节点信息
                Console.WriteLine(temp);
                //将next后移，一定记住需要后移。不然就是死循环
                temp = temp.NextNode;
            }
        }

        /*
         * 第二种方式在添加节点时，根据排名将节点插入到指定位置
         * 如果有这个排名，则添加失败并提示
         */
        public void AddNodeByOrder(DataNode node)
        {
            //因为头节点不能东，因此我们仍然通过一个辅助变量来帮助找到添加的位置
            //因为单链表，因此我们找的tmep是位于添加位置的前一个节点，否则插入不了
            DataNode temp = head;
            bool flag = false;//标识添加的编号是否存在，默认为false
            while (true)
            {
                if (temp.NextNode == null)
                {
                    //说明temp已经在链表的最后
                    break;
                }

                if (temp.NextNode.Id > node.Id)
                {
                    //位置找到，就在temp的后面插入

                    break;
                }
                else if (temp.NextNode.Id == node.Id)
                {
                    //说明希望添加的datanode的编号已经存在
                    flag = true;//说明编号存在
                    break;
                }
                //后移，遍历当前的链表
                temp = temp.NextNode;
            }
            //判断flag的值
            if (flag)
            {
                //不能添加，说明编号已经存在
                Console.WriteLine($"准备插入的节点编号{node.Id}已经存在");
            }
            else
            {
                //插入到链表中，temp的后面
                node.NextNode = temp.NextNode;
                temp.NextNode = node;
            }
        }

        /*
         * 修改节点的信息，根据编号来修改，即编号不能改
         * 说明：
         * 1.根据NewDataNode的id来修改即可
         */
        public void Update(DataNode node)
        {
            //判断链表是否空
            if (head.NextNode == null)
            {
                Console.WriteLine("链表为空");
                return;
            }
            //找到需要修改的节点，根据id
            //先顶一个一个辅助变量
            DataNode temp = head.NextNode;
            bool flag = false;//表示是否找到该节点
            while (true)
            {
                if (temp == null)
                {
                    break;//已经遍历完链表
                }

                if (temp.Id == node.Id)
                {
                    //找到了
                    flag = true;
                    break;
                }
                temp = temp.NextNode;
            }

            //根据flag判断是否找到要修改的节点
            if (flag)
            {
                temp.Name = node.Name;
                temp.NikeName = node.NikeName;
            }
            else
            {
                //没有找到
                Console.WriteLine($"没有找到编号的节点，不能修改{node.Id}");
            }
        }

        /*
         *删除节点
         *思路
         *1.head不能动，因此先找到需要temp辅助节点找到待删除的节点的前一个节点
         *2.说明在比较时，时temp.next.id和需要删除的节点的id比较
         */
        public void Delete(int id)
        {
            DataNode temp = head;
            bool flag = false;//标识是否找到带删除节点
            while (true)
            {
                if (temp.NextNode == null)
                {
                    //已经到链表的最后
                    break;
                }

                if (temp.NextNode.Id == id)
                {
                    //找到了待删除系欸的那的前一个节点
                    flag = true;
                    break;
                }

                temp = temp.NextNode;//temp后移实现遍历
            }

            //判断是否找到
            if (flag)
            {
                //可删除
                temp.NextNode = temp.NextNode.NextNode;
            }
            else
            {
                Console.WriteLine($"要删除的节点没有找到{id}");
            }
        }
    }
}
