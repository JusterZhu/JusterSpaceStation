﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.MyTree
{
    public class FileNode
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public string MD5 { get; set; }

        public FileNode Left { get; set; }

        public FileNode Right { get; set; }

        public int LeftType { get; set; }

        public int RightType { get; set; }

        public FileNode() { }

        public FileNode(int id)
        {
            Id = id;
        }

        /// <summary>
        /// 递归的形式添加节点的值（满足二叉树排序树的要求）
        /// </summary>
        /// <param name="node"></param>
        public void Add(FileNode node)
        {
            if (node == null) return;

            //判断传入的节点的值，和当前子树的根节点的值关系
            if (node.Id < Id)
            {
                //如果当前节点左子节点为null
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    //递归像左子树添加
                    Left.Add(node);
                }
            }
            else
            {
                //添加的节点的值大于当前节点的值
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    //递归向右子树添加
                    Right.Add(node);
                }
            }
        }

        public void InfixOrder()
        {
            if (Left != null)
            {
                Left.InfixOrder();
            }
            Console.WriteLine(this);
            if (Right != null)
            {
                Right.InfixOrder();
            }
        }

        /// <summary>
        /// 如果找到节点则返回，否则为null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public FileNode Search(long id)
        {
            if (id == Id)
            {
                return this;
            }
            else if (id < Id)
            {
                //如果左子节点为空
                if (Left == null)
                {
                    return null;
                }
                return Left.Search(id);
            }
            else
            {
                //如果朝朝的值不小于当前节点，向右子树递归查找
                if (Right == null)
                {
                    return null;
                }
                return Right.Search(id);
            }
        }

        /// <summary>
        /// 查找要删除的节点的父节点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FileNode SearchParent(long id)
        {
            //如果当前节点就是要删除的节点的父节点，就返回
            if (Left != null && Left.Id == id || Right != null && Right.Id == id)
            {
                return this;
            }
            else
            {
                //如果照抄的值小于当前节点的值，并且当前节点的左子节点不为空
                if (id < Id && Left != null)
                {
                    return Left.SearchParent(id);
                }
                else if (id >= Id && Right != null)
                {
                    return Right.SearchParent(id);
                }
                else
                {
                    return null; //没有找到父节点
                }
            }
        }

        public override bool Equals(object obj)
        {
            var other = obj as FileNode;
            return MD5.ToUpper().Equals(other.MD5.ToUpper()) && Name.Equals(other.Name);
        }
    }
}
