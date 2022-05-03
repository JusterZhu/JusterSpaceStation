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
            int n = 8;
            //string[] vertexs = { "A", "B", "C", "D", "E" };
            string[] vertexs = { "1", "2", "3", "4", "5", "6", "7", "8" };
            //创建图对象
            MyGraph graph = new MyGraph(n);
            //添加顶点
            foreach (var item in vertexs)
            {
                graph.InsertVertex(item);
            }
            //添加边 A-B A-C B-C B-D B-E
            //graph.InsertEdge(0, 1, 1);//A-B
            //graph.InsertEdge(0, 2, 1);
            //graph.InsertEdge(1, 2, 1);
            //graph.InsertEdge(1, 3, 1);
            //graph.InsertEdge(1, 4, 1);

            graph.InsertEdge(0, 1, 1);
            graph.InsertEdge(0, 2, 1);
            graph.InsertEdge(1, 3, 1);
            graph.InsertEdge(1, 4, 1);
            graph.InsertEdge(3, 7, 1);
            graph.InsertEdge(4, 7, 1);
            graph.InsertEdge(2, 5, 1);
            graph.InsertEdge(2, 6, 1);
            graph.InsertEdge(5, 6, 1);

            //打印矩阵
            graph.PrintGraph();

            //DFS遍历
            //Console.WriteLine("深度遍历");
            //graph.DFS();

            //BFS遍历
            Console.WriteLine("广度遍历");
            graph.BFS();

            Console.Read();
        }
    }
}
