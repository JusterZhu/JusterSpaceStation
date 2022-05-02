using MyAlgorithm.Graph;
using MyAlgorithm.Tree;
using System;

namespace MyAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //顶点个数
            int n = 5;
            string[] vertexs = { "A", "B", "C", "D", "E" };
            //创建图对象
            MyGraph graph = new MyGraph(n);
            //添加顶点
            foreach (var item in vertexs)
            {
                graph.InsertVertex(item);
            }
            //添加边 A-B A-C B-C B-D B-E
            graph.InsertEdge(0, 1, 1);//A-B
            graph.InsertEdge(0, 2, 1);
            graph.InsertEdge(1, 2, 1);
            graph.InsertEdge(1, 3, 1);
            graph.InsertEdge(1, 4, 1);

            //打印矩阵
            graph.PrintGraph();
            Console.Read();
        }
    }
}
