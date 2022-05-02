using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Graph
{
    internal class MyGraph
    {
        /// <summary>
        /// 顶点集合
        /// </summary>
        private List<string> Vertexs { get; set; }

        /// <summary>
        /// 邻结矩阵
        /// </summary>
        private int[,] Edges { get; set; }

        /// <summary>
        /// 边数
        /// </summary>
        private int NumOfEdges { get; set; }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="n"></param>
        public MyGraph(int n) 
        {
            //初始化Edges和Vertexs
            Edges = new int[n,n];
            Vertexs = new List<string>(n);
            NumOfEdges = 0;
        }

        /// <summary>
        /// 插入顶点
        /// </summary>
        /// <param name="vertex"></param>
        public void InsertVertex(string vertex) 
        {
            Vertexs.Add(vertex);
        }

        /// <summary>
        /// 添加边
        /// </summary>
        /// <param name="v1">表示点的下标即第几个顶点描述。例如：A-B之间关系</param>
        /// <param name="v2">第二个顶点对应的下标</param>
        /// <param name="weight">权值，表示值如果为1表示关联 0表示为关联</param>
        public void InsertEdge(int v1, int v2, int weight) 
        {
            Edges[v1,v2] = weight;
            Edges[v2, v1] = weight;
            NumOfEdges++;
        }

        /// <summary>
        /// 返回顶点个数
        /// </summary>
        /// <returns></returns>
        public int GetNumIfVertex() 
        {
            return Vertexs.Count;
        }

        /// <summary>
        /// 返回边数
        /// </summary>
        /// <returns></returns>
        public int GetNumOfEdges() 
        {
            return NumOfEdges;
        }

        /// <summary>
        /// 返回节点i（下标）对应数据0->"A"  1->"B" 2->"C"
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public string GetValueByIndex(int i) 
        {
            return Vertexs[i];
        }

        /// <summary>
        /// 返回V1和V2的权值
        /// </summary>
        /// <returns></returns>
        public int GetWeight(int v1 ,int v2) 
        {
            return Edges[v1, v2];
        }

        /// <summary>
        /// 打印矩阵
        /// </summary>
        public void PrintGraph() 
        {
            int row = Edges.GetLength(0);
            int colnum = Edges.GetLength(1);
            for (int i = 0; i < row; i++)
            {
                string rowContent = string.Empty;
                for (int j = 0; j < colnum; j++)
                {
                    rowContent += Edges[i, j] + "\t";
                }
                Console.WriteLine(rowContent);
                Console.WriteLine();
            }
        }
    }
}
