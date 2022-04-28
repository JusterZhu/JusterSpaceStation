using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Tree
{
    /// <summary>
    /// 二叉排序树
    /// </summary>
    public class BinarySortNode 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public BinarySortNode Left { get; set; }

        public BinarySortNode Right { get; set; }

        //如果LeftType==0表示指向的是左子树，如果是1则表示指向前驱节点
        //如果RightType表示指向的是右子树，如果是1则表示指向后继节点
        public int LeftType { get; set; }

        public int RightType { get; set; }

        public BinarySortNode(int id) 
        {
            this.Id = id;
        }

        /// <summary>
        /// 递归的形式添加节点的值（满足二叉树排序树的要求）
        /// </summary>
        /// <param name="node"></param>
        public void Add(BinarySortNode node) 
        {
            if (node == null) return;

            //判断传入的节点的值，和当前子树的根节点的值关系
            if (node.Id < this.Id)
            {
                //如果当前节点左子节点为null
                if (this.Left == null)
                {
                    this.Left = node;
                }
                else
                {
                    //递归像左子树添加
                    this.Left.Add(node);
                }
            }
            else
            {
                //添加的节点的值大于当前节点的值
                if (this.Right == null)
                {
                    this.Right = node;
                }
                else
                {
                    //递归向右子树添加
                    this.Right.Add(node);
                }
            }
        }

        public void InfixOrder()
        {
            if (this.Left != null)
            {
                this.Left.InfixOrder();
            }
            Console.WriteLine(this);
            if (this.Right != null)
            {
                this.Right.InfixOrder();
            }
        }

        public override string ToString()
        {
            return $"TreeNode [id = { Id } ]";
        }

        /// <summary>
        /// 如果找到节点则返回，否则为null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public BinarySortNode Search(int id)
        {
            if (id == this.Id)
            {
                return this;
            }
            else if (id < this.Id)
            {
                //如果左子节点为空
                if (this.Left == null)
                {
                    return null;
                }
                return this.Left.Search(id);
            }
            else
            {
                //如果朝朝的值不小于当前节点，向右子树递归查找
                if (this.Right == null)
                {
                    return null;
                }
                return this.Right.Search(id);
            }
        }

        /// <summary>
        /// 查找要删除的节点的父节点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BinarySortNode SearchParent(int id)
        {
            //如果当前节点就是要删除的节点的父节点，就返回
            if (this.Left != null && this.Left.Id == id || (this.Right != null && this.Right.Id == id))
            {
                return this;
            }
            else
            {
                //如果照抄的值小于当前节点的值，并且当前节点的左子节点不为空
                if (id < this.Id && this.Left != null)
                {
                    return this.Left.SearchParent(id);
                }
                else if (id >= this.Id && this.Right != null)
                {
                    return this.Right.SearchParent(id);
                }
                else
                {
                    return null; //没有找到父节点
                }
            }
        }

    }

    public class BinarySortTree
    {
        BinarySortNode root;

        public void Add(BinarySortNode node) 
        {
            if (root == null)
            {
                root = node;
            }
            else
            {
                root.Add(node);
            }
        }

        public void InfixOrder() 
        {
            if (root != null)
            {
                root.InfixOrder();
            }
            else
            {
                Console.WriteLine("二叉排序树为空，不能遍历！");
            }
        }

        public BinarySortNode Search(int id)
        {
            if (root == null)
            {
                return null;
            }
            else
            {
                return root.Search(id);
            }
        }

        public BinarySortNode SearchParent(int id)
        {
            if (root == null)
            {
                return null;
            }
            else
            {
                return root.SearchParent(id);
            }
        }

        /// <summary>
        /// 1.node 传入的节点当作二叉树排序树的根节点
        /// 2.删除node为根节点的二叉排序树的最小节点
        /// </summary>
        /// <param name="node">以node为根节点二叉排序树的最小节点的值</param>
        /// <returns></returns>
        public int DelRightTreeMin(BinarySortNode node)
        {
            BinarySortNode target = node;
            //循环的查找左节点，就会找到最小值
            while (target.Left != null)
            {
                target = target.Left;
            }
            //这时target指向了最小节点
            DelNode(target.Id);
            return target.Id;
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="id"></param>
        public void DelNode(int id)
        {
            if (root == null)
            {
                return;
            }
            else
            {
                //先找到需要删除的节点targetnode
                BinarySortNode targetNode = Search(id);
                //如果没有找到要删除的节点
                if (targetNode == null)
                {
                    return;
                }
                //如果我们发现当前这颗二叉排序树只有一个节点
                if (root.Left == null && root.Right == null)
                {
                    root = null;
                    return;
                }

                //找到targetnode的父节点
                BinarySortNode parent = SearchParent(id);
                //如果要删除的节点是叶子节点
                if (targetNode.Left == null && targetNode.Right == null)
                {
                    //判断targetnode是父节点的左子节点，还是右子节点
                    if (parent.Left != null && parent.Left.Id == id)
                    {
                        parent.Left = null;
                    }
                    else if (parent.Right != null && parent.Right.Id == id)
                    {
                        parent.Right = null;
                    }
                }
                else if (targetNode.Left != null && targetNode.Right != null)
                {
                    //左右子树不为空的时候
                    int minVal = DelRightTreeMin(targetNode.Right);
                    targetNode.Id = minVal;
                }
                else
                {
                    //删除只有一棵树的节点
                    //如果要删除的节点有左子节点
                    if (targetNode.Left != null)
                    {
                        //如果targetnode是parent 的左子节点
                        if (parent.Left.Id == id)
                        {
                            parent.Left = targetNode.Left;
                        }
                        else
                        {
                            //targetNode是parent的右子节点
                            parent.Right = targetNode.Left;
                        }
                    }
                    else
                    {
                        //如果targetnode是parent的左子节点
                        if (parent.Left.Id == id)
                        {
                            parent.Left = targetNode.Right;
                        }
                        else
                        {
                            //targetNode是parent的右子节点
                            parent.Right = targetNode.Right;
                        }
                    }
                }
            }
        }
    }
}
