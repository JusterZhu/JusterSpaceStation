using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Tree
{
    public class HuffmanNode : Comparer<HuffmanNode>
    {
        public HuffmanNode Left { get; set; }
        public HuffmanNode Right { get; set; }
        public int Value { get; set; }
        
        public HuffmanNode(int value)
        {
            Value = value;
        }

        public override int Compare(HuffmanNode x, HuffmanNode y)
        {
            //从小到大排
            return x.Value - y.Value;
        }

        //前序遍历
        public void PreOrder() 
        {
            Console.WriteLine(this);
            if (this.Left != null)
            {
                this.Left.PreOrder();
            }

            if (this.Right != null)
            {
                this.Right.PreOrder();
            }
        }

        public override string ToString()
        {
            return $"Node[ value = { Value } ]";
        }
    }

    public class HuffmanTree
    {
        public static HuffmanNode Create(int[] arr) 
        {
            //为了操作方便
            //1.便利arr数组
            //2.将arr的每个元素构成一个node
            //3.将node放入到arrylist中
            List<HuffmanNode> nodes = new List<HuffmanNode>();
            foreach (var val in arr)
            {
                nodes.Add(new HuffmanNode(val));
            }

            while (nodes.Count > 1)
            {
                //排序从小到大
                nodes.Sort((x, y) => x.Compare(x, y));
                //Console.WriteLine(string.Join(" ", nodes));

                //取出权值最小的节点
                HuffmanNode leftNode = nodes[0];
                //取出权值第二小的节点
                HuffmanNode rightNode = nodes[1];
                //构建一颗新的二叉树
                HuffmanNode parent = new HuffmanNode(leftNode.Value + rightNode.Value);
                parent.Left = leftNode;
                parent.Right = rightNode;

                //从arraylist 删除处理过的二叉树
                nodes.Remove(leftNode);
                nodes.Remove(rightNode);
                //将parent加入nodes
                nodes.Add(parent);
               // Console.WriteLine(string.Join(" ", nodes));
            }
            //返回赫夫曼树root节点
            return nodes[0];
        }
        
        public static void PreOrder(HuffmanNode root)
        {
            if (root != null) 
            {
                root.PreOrder();
            }
            else
            {
                Console.WriteLine( "是空树！");
            }
        }
    }
}
