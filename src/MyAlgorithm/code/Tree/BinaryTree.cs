using System;
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
    }
}
