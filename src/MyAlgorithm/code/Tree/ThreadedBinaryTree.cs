using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Tree
{
    /// <summary>
    /// 线索化二叉树
    /// </summary>
    public class ThreadedBinaryNode 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ThreadedBinaryNode Left { get; set; }

        public ThreadedBinaryNode Right { get; set; }

        //如果LeftType==0表示指向的是左子树，如果是1则表示指向前驱节点
        //如果RightType表示指向的是右子树，如果是1则表示指向后继节点
        public int LeftType { get; set; }

        public int RightType { get; set; }

        public ThreadedBinaryNode(int id, string name)
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
        public ThreadedBinaryNode PreOrderSearch(int id)
        {
            Console.WriteLine("前序遍历查找" + DateTime.Now);
            //比较当前节点是不是
            if (this.Id == id)
            {
                return this;
            }
            //1.则判断当前节点的左子节点是否为空，如果不为空，则递归前序查找
            //2.如果左递归前序查找，找到节点，则返回
            ThreadedBinaryNode resNode = null;
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
        public ThreadedBinaryNode InfixOrderSearch(int id)
        {
            ThreadedBinaryNode resNode = null;
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
        public ThreadedBinaryNode PostOrderSearch(int id)
        {
            ThreadedBinaryNode resNode = null;
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


    //定义ThreadedBinaryTree实现了线索化功能的二叉树
    public class ThreadedBinaryTree
    {
        private ThreadedBinaryNode root;
        //为了线索化，需要创建给指向当前节点的前驱节点的指针
        //在递归进行线索化时，pre总是保留前一个节点
        private ThreadedBinaryNode preNode;

        public void SetRoot(ThreadedBinaryNode root)
        {
            this.root = root;
        }

        public void SetThreadedBinaryNode() 
        {
            SetThreadedBinaryNode(root);
        }

        //遍历线索化二叉树的方法
        public void ThreadedList() 
        {
            //定义一个变量，存储当前遍历的节点，从root开始
            ThreadedBinaryNode tempNode = root;
            while (tempNode != null)
            {
                //循环找到lefttype == 1 的节点，第一个找到就是8节点
                //后面随着遍历而变化，因为lefttype==1时，说明该节点时按照线索化
                while (tempNode.LeftType == 0)
                {
                    tempNode = tempNode.Left;
                }
                //打印当前节点
                Console.WriteLine(tempNode);
                //如果当前节点的右指针指向的时后续节点，就一直输出
                while (tempNode.RightType == 1)
                {
                    //获取到当前节点的后继节点
                    tempNode = tempNode.Right;
                    Console.WriteLine(tempNode);
                }
                //替换这个遍历的节点
                tempNode = tempNode.Right;
            }
        }

        /// <summary>
        /// 线索化方法（中序）
        /// </summary>
        /// <param name="node">当前需要线索化的节点</param>
        public void SetThreadedBinaryNode(ThreadedBinaryNode node)
        {
            if (node == null) return;

            //1.先线索化左子树
            SetThreadedBinaryNode(node.Left);

            //2.线索化当前节点
            //处理当前节点的前驱节点
            if (node.Left == null) 
            {
                //让当前节点的左指针，指向前驱节点
                node.Left = preNode;
                //修改当前节点的左指针类型，指向的前驱节点
                node.LeftType = 1;
            }

            //处理后继节点
            if (preNode != null && preNode.Right == null) 
            {
                //让前驱节点的右指针指向当前节点
                preNode.Right = node;
                //修改前驱节点的右指针类型
                preNode.RightType = 1;
            }

            //每处理一个节点后，让当前节点是下一个节点的前驱节点
            preNode = node;

            //3.再线索化右子树
            SetThreadedBinaryNode(node.Right);
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
        public ThreadedBinaryNode PreOrderSearch(int id)
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
        public ThreadedBinaryNode InfixOrderSearch(int id)
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
        public ThreadedBinaryNode PostOrderSearch(int id)
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
