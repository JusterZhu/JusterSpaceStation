﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Tree
{
    public class TreeNode 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TreeNode Left { get; set; }

        public TreeNode Right { get; set; }

        public TreeNode(int id,string name) 
        {
            this.Id = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return $"TreeNode [id = { Id } , name ={ Name }]";
        }

        /// <summary>
        /// 前序遍历
        /// </summary>
        public void PreOrder()
        {
            Console.WriteLine(this);
            //递归向左子树前序遍历
            if (this.Left != null) 
            {
                this.Left.PreOrder();
            }
            //递归向右子树前序遍历
            if (this.Right != null)
            {
                this.Right.PreOrder();
            }
        }

        /// <summary>
        /// 中序遍历
        /// </summary>
        public void InfixOrder() 
        {
            //递归向左子树中序遍历
            if (this.Left != null)
            {
                this.Left.InfixOrder();
            }

            //输出父节点
            Console.WriteLine(this);

            //递归向右子树中序遍历

            if (this.Right != null)
            {
                this.Right.InfixOrder();
            }
        }

        /// <summary>
        /// 后续遍历
        /// </summary>
        public void PostOrder() 
        {
            if (this.Left != null)
            {
                this.Left.PreOrder();
            }

            if (this.Right != null)
            {
                this.Right.PreOrder();
            }

            Console.WriteLine(this);
        }

        /// <summary>
        /// 前序遍历查找
        /// </summary>
        /// <param name="id">根据id查找节点</param>
        /// <returns></returns>
        public TreeNode PreOrderSearch(int id)
        {
            Console.WriteLine("前序遍历查找" + DateTime.Now);
            //比较当前节点是不是
            if (this.Id == id)
            {
                return this;
            }
            //1.则判断当前节点的左子节点是否为空，如果不为空，则递归前序查找
            //2.如果左递归前序查找，找到节点，则返回
            TreeNode resNode = null;
            if (this.Left != null)
            {
                resNode = this.Left.PreOrderSearch(id);
            }

            //说明我们左子树找到
            if (resNode != null)
            {
                return resNode;
            }
            //左递归前序查找，找到站点，则返回，否则继续判断
            //当前的节点的右子节点是否为空，如果不为空，则继续向右递归前序查找。
            if (this.Right != null)
            {
                resNode = this.Right.PreOrderSearch(id);
            }
            return resNode;
        }

        //中序遍历查找
        public TreeNode InfixOrderSearch(int id) 
        {
            TreeNode resNode = null;
            if (this.Left != null)
            {
                resNode = this.Left.InfixOrderSearch(id);
            }

            if (resNode != null)
            {
                return resNode;
            }
            Console.WriteLine("中序遍历查找" + DateTime.Now);
            if (this.Id == id) 
            {
                return this;
            }

            if (this.Right != null)
            {
                resNode = this.Right.InfixOrderSearch(id);
            }

            return resNode;
        }

        //后序遍历查找
        public TreeNode PostOrderSearch(int id) 
        {
            TreeNode resNode = null;
            if (this.Left != null)
            {
                resNode = this.Left.PostOrderSearch(id);
            }

            if (resNode != null)
            {
                return resNode;
            }

            if (this.Right != null)
            {
                resNode = this.Right.PostOrderSearch(id);
            }

            if (resNode != null)
            {
                return resNode;
            }
            Console.WriteLine("后序遍历查找" + DateTime.Now);
            if (this.Id == id)
            {
                return this;
            }
            return resNode;
        }

        /// <summary>
        /// 根据id删除指定节点
        /// </summary>
        /// <param name="id"></param>
        public void DeleteNode(int id) 
        {
            if (this.Left != null && this.Left.Id == id) 
            {
                this.Left = null;
                return;
            }

            if (this.Right != null && this.Right.Id == id)
            {
                this.Right = null;
                return;
            }

            if (this.Left != null)
            {
                this.Left.DeleteNode(id);
            }

            if (this.Right != null)
            {
                this.Right.DeleteNode(id);
            }
        }
    }

    public class BinaryTree
    {
        private TreeNode root;

        public void SetRoot(TreeNode root) 
        {
            this.root = root;
        }

        //前序遍历
        public void PreOrder() 
        {
            if (this.root != null)
            {
                this.root.PreOrder();
            }
            else 
            {
                Console.WriteLine("二叉树为空，无法遍历！");
            }
        }

        //中序遍历
        public void InfixOrder() 
        {
            if (this.root != null)
            {
                this.root.InfixOrder();
            }
            else
            {
                Console.WriteLine("二叉树为空，无法遍历！");
            }
        }

        //后续遍历
        public void PostOrder() 
        {
            if (this.root != null)
            {
                this.root.PostOrder();
            }
            else
            {
                Console.WriteLine("二叉树为空，无法遍历！");
            }
        }

        /// <summary>
        /// 前序遍历查找
        /// </summary>
        /// <param name="id">根据id查找节点</param>
        /// <returns></returns>
        public TreeNode PreOrderSearch(int id)
        {
            if (root != null) 
            {
                return root.PreOrderSearch(id);
            }
            else
            {
                return null;
            }
        }

        //中序遍历查找
        public TreeNode InfixOrderSearch(int id)
        {
            if (root != null)
            {
                return root.InfixOrderSearch(id);
            }
            else
            {
                return null;
            }
        }

        //后序遍历查找
        public TreeNode PostOrderSearch(int id)
        {
            if (root != null)
            {
                return root.PostOrderSearch(id);
            }
            else
            {
                return null;
            }
        }

        public void DeleteNode(int id) 
        {
            if (root != null)
            {
                if (root.Id == id)
                {
                    root = null;
                }
                else
                {
                    root.DeleteNode(id);
                }
            }
            else
            {
                Console.WriteLine("空树无法删除！");
            }
        }
    }
}
