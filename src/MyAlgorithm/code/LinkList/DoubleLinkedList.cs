﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.LinkList
{
//    MyDoubleLinkedList list = new MyDoubleLinkedList();
//    list.AddOrderById(new DataNode(8, "haha"));
//list.AddOrderById(new DataNode(1,"zhangsan"));
//list.AddOrderById(new DataNode(7, "haha"));
//list.AddOrderById(new DataNode(4, "zhaoliu"));
//list.AddOrderById(new DataNode(2, "lisi"));
//list.AddOrderById(new DataNode(3, "wangwu"));

//list.List();

    /// <summary>
    /// 双向链表
    /// </summary>
    internal class MyDoubleLinkedList
    {
        internal class DataNode
        {
            public int Id { get; set; }

            public string Name { get; set; }

            /// <summary>
            /// 指向下一个节点，默认为null
            /// </summary>
            public DataNode NextNode { get; set; }

            /// <summary>
            /// 指向上一个节点，默认为null
            /// </summary>
            public DataNode PreNode { get; set; }

            internal DataNode(int id, string name)
            {
                this.Id = id;
                this.Name = name;
            }

            public override string ToString()
            {
                return $"DataNode[no={Id}]，name={Name}, PreNodeId={ PreNode.Id }";
            }
        }

        //初始化一个头节点，头节点不要动，不存放具体的数据
        private DataNode head = new DataNode(0, "");

        /// <summary>
        /// 返回头节点
        /// </summary>
        /// <returns></returns>
        public DataNode GetHead()
        {
            return head;
        }

        /// <summary>
        /// 遍历双向链表
        /// </summary>
        public void List()
        {
            if (head.NextNode == null)
            {
                Console.WriteLine("链表为空");
                return;
            }
            //因为头节点，不能动，因此我们需要一个辅助变量来遍历
            DataNode temp = head.NextNode;
            while (true)
            {
                //判断是否到链表最后
                if (temp == null) break;
                Console.WriteLine(temp);
                //将temp后移
                temp = temp.NextNode;
            }

            Console.WriteLine();
        }

        /// <summary>
        /// 添加一个节点到双向链表的最后
        /// </summary>
        /// <param name="node"></param>
        public void Add(DataNode node)
        {
            //因为head节点不能动，因此我们需要一个辅助遍历的temp
            DataNode temp = head;
            //遍历链表，找到最后
            while (true)
            {
                //找到链表的最后
                if (temp.NextNode == null) break;
                //如果没有找到最后，将temp后移
                temp = temp.NextNode;
            }
            //当推出while循环时，temp就指向了链表的最后
            //形成一个双向链表
            temp.NextNode = node;
            node.PreNode = temp;
        }

        /// <summary>
        /// 修改一个节点的内容
        /// </summary>
        /// <param name="node"></param>
        public void Update(DataNode node)
        {
            if (head.NextNode == null)
            {
                Console.WriteLine("链表为空");
                return;
            }

            DataNode temp = head.NextNode;
            bool flag = false;
            while (true)
            {
                //判断是否到链表最后
                if (temp == null) break;

                if (temp.Id == node.Id)
                {
                    flag = true;
                    break;
                }
                //将temp后移
                temp = temp.NextNode;
            }

            if (flag)
            {
                temp.Name = node.Name;
            }
            else
            {
                Console.WriteLine($"没有找到编号{node.Id}的节点，不能修改！");
            }
        }

        /// <summary>
        /// 删除一个节点
        /// 1.对于双向链表，我们可以直接找到要删除的这个节点
        /// 2.找到后，自我删除即可
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            //判断当前链表是否为空
            if (head.NextNode == null)
            {
                Console.WriteLine("链表为空，无法删除");
                return;
            }

            DataNode temp = head.NextNode;
            bool flag = false;
            while (true)
            {
                if (temp == null) break;

                if (temp.Id == id)
                {
                    flag = true;
                    break;
                }
                temp = temp.NextNode;
            }

            if (flag)
            {
                temp.PreNode.NextNode = temp.NextNode;
                //如果时最后一个节点，就不需要指向下面这句话，否则会出现空指针
                if (temp.NextNode != null)
                {
                    temp.NextNode.PreNode = temp.PreNode;
                }
            }
            else
            {
                Console.WriteLine($"要删除{id}，节点不存在。");
            }
        }

        /// <summary>
        /// 根据id号有序添加数据
        /// </summary>
        /// <param name="node"></param>
        public void AddOrderById(DataNode node)
        {
            //因为head节点不能动，因此我们需要一个辅助遍历的temp
            DataNode temp = head;
            bool flag = false;
            //遍历链表，找到最后
            while (true)
            {
                //找到链表的最后
                if (temp.NextNode == null) break;

                //当前的节点id小于需要插入的节点id，并且需要插入的节点id小于当前节点的下一个节点的id
                if (temp.Id < node.Id && node.Id < temp.NextNode.Id)
                {
                    flag = true;
                    break;
                }
                //后移
                temp = temp.NextNode;
            }

            if (flag)
            {
                //保存当前节点的下一个节点
                var tempNext = temp.NextNode;
                //将当前节点的下一个节点赋值为需要新增的节点
                temp.NextNode = node;
                node.PreNode = temp;

                temp.NextNode.NextNode = tempNext;
                tempNext.PreNode = temp.NextNode;
            }
            else
            {
                temp.NextNode = node;
                node.PreNode = temp;
            }
        }
    }
}
