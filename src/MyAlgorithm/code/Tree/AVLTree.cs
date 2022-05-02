using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Tree
{
    public class AVLNode 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public AVLNode Left { get; set; }

        public AVLNode Right { get; set; }

        public AVLNode(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return $"TreeNode [id = { Id } , name ={ Name }]";
        }

        /// <summary>
        /// 左旋转
        /// </summary>
        private void LeftRotate()
        {
            //创建新的节点，以当前根节点的值
            AVLNode newNode = new AVLNode(Id,"");
            //把新的节点的左子树设置成当前节点的左子树
            newNode.Left = Left;
            //把新的节点的右子树设置成当前节点的右子树的左子树
            newNode.Right = Right.Left;
            //把当前节点的值替换成右子节点的值
            Id = Right.Id;
            //把当前节点的右子树设置成右子树的右子树
            Right = Right.Right;
            //把当前节点的左子树（左子节点）设置成新的节点
            Left = newNode;
        }

        /// <summary>
        /// 右旋转
        /// </summary>
        private void RightRotate()
        {
            AVLNode newNode = new AVLNode(Id, "");
            newNode.Right = Right;
            newNode.Left = Left.Right;
            Id = Left.Id;
            Left = Left.Left;
            Right = newNode;
        }

        //返回左子树的高度
        public int LeftHeight() 
        {
            if (Left == null)
            {
                return 0;
            }
            return Left.Height();
        }

        //返回右子树的高度
        public int RightHeight()
        {
            if (Right == null)
            {
                return 0;
            }
            return Right.Height();
        }

        /// <summary>
        /// 返回以该节点为根节点的树的高度
        /// </summary>
        /// <returns></returns>
        public int Height() 
        {
            // 这里是为了统计出左子树和右子树的最大层，+1的目的是因为本身也算一层。
            return Math.Max(Left == null ? 0 : Left.Height(), Right == null ? 0 : Right.Height()) + 1;
        }

        public void Add(AVLNode node)
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

            //当添加完一个节点后，如果右子树的高度 - 左子树的高度 > 1则左旋转
            if (RightHeight() - LeftHeight() > 1)
            {
                //如果它的右子树的左子树高度大于它的右子树的高度
                if (Right != null && Right.LeftHeight() > Right.RightHeight())
                {
                    //先对又子节点进行右旋转
                    Right.RightRotate();
                    LeftRotate();
                }
                else
                {
                    //然后在对当前节点进行左旋转
                    LeftRotate();
                }
                //必须要添加，如果RightHeight() - LeftHeight() > 1条件成立，处理完成之后已经达到平衡。
                //后续的代码就不需要再次处理了。
                return;
            }

            if (LeftHeight() - RightHeight()  > 1)
            {
                //如果它的左子树的右子树高度大于它的左子树的高度
                if (Left != null && Left.RightHeight() > Left.LeftHeight())
                {
                    //先对当前这个节点的左节点进行向左旋转
                    Left.LeftRotate();
                    //再对当前节点进行右旋转
                    RightRotate();
                }
                else
                {
                    //直接右旋转即可
                    RightRotate();
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


        /// <summary>
        /// 如果找到节点则返回，否则为null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public AVLNode Search(int id)
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
        public AVLNode SearchParent(int id)
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

    public class AVLTree
    {
        AVLNode root;

        public AVLNode GetRoot() 
        {
            return root;
        }

        public void Add(AVLNode node)
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

        public AVLNode Search(int id)
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

        public AVLNode SearchParent(int id)
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
        public int DelRightTreeMin(AVLNode node)
        {
            AVLNode target = node;
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
                AVLNode targetNode = Search(id);
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
                AVLNode parent = SearchParent(id);
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
