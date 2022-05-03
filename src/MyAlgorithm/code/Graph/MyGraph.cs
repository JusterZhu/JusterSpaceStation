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
        /// 记录某个节点是否被访问
        /// </summary>
        private bool[] IsVisited;

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
            IsVisited = new bool[n];
        }

        /// <summary>
        /// 得到第一个邻接节点下标w
        /// </summary>
        /// <param name="index"></param>
        /// <returns>如果存在就返回对应的下标，否则返回-1</returns>
        public int GetFirstNeighbor(int index) 
        {
            for (int i = 0; i < Vertexs.Count; i++)
            {
                if (Edges[index,i] > 0)
                {
                    return i;
                }
            }
            return -1;
        }

        //根据前一个邻接节点的下标来获取下一个邻接节点
        public int GetNextNeighbor(int v1, int v2) 
        {
            for (int i = v2 + 1; i < Vertexs.Count; i++)
            {
                if (Edges[v1,i] > 0)
                {
                    return i;
                }
            }
            return -1;
        }

        //深度优先遍历算法
        public void DFS(bool[] isVisited,int i) 
        {
            //首先我们访问该节点
            Console.Write(GetValueByIndex(i) + "->");
            //将节点设置为已访问
            IsVisited[i] = true;
            //查找节点i的第一个邻接节点
            int w = GetFirstNeighbor(i);
            //说明有
            while (w != -1)
            {
                //那么就判断是否被访问过
                if (!isVisited[w])
                {
                    DFS(isVisited,w);
                }
                //如果已经被访问过
                w = GetNextNeighbor(i,w);
            }
        }

        /// <summary>
        /// 对DFS进行一个重载，遍历我们所有的节点，并进行DFS
        /// </summary>
        public void DFS()
        {
            IsVisited = new bool[Vertexs.Count];
            //遍历所有的节点，进行DFS回溯
            for (int i = 0; i < GetNumIfVertex(); i++)
            {
                if (!IsVisited[i])
                {
                    DFS(IsVisited,i);
                }
            }
        }

        //对一个节点进行广度优先遍历的方法
        private void BFS(bool[] isVisited ,int i) 
        {
            int u;//表示队列的头节点对应下标
            int w;//邻接节点
            //队列，记录节点访问顺序
            LinkedList<int> queue = new LinkedList<int>();
            Console.Write(GetValueByIndex(i) + "->");
            //标记为已访问
            IsVisited[i] = true;
            //将节点加入队列
            queue.AddLast(i);
            while (queue.Count != 0)
            {
                //取出队列的头节点下标
                u = queue.First(); 
                queue.RemoveFirst();
                //得到第一个邻节点下标
                w = GetFirstNeighbor(u);
                while (w != -1)
                {
                    //是否访问过
                    if (!isVisited[w])
                    {
                        Console.Write(GetValueByIndex(w) + "->");
                        //标记已访问
                        isVisited[w] = true;
                        //入队
                        queue.AddLast(w);
                    }
                    //以u为前驱节点，找w后面的下一个邻接点
                    w = GetNextNeighbor(u,w);//体现出广度优先
                }
            }
        }

        //遍历所有的节点，都进行广度优先搜索
        public void BFS() 
        {
            IsVisited = new bool[Vertexs.Count];
            for (int i = 0; i < GetNumIfVertex(); i++)
            {
                if (!IsVisited[i])
                {
                    BFS(IsVisited, i);
                }
            }
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
