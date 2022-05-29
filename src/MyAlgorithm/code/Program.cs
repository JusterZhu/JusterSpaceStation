using MyAlgorithm.Graph;
using MyAlgorithm.Recursion;
using MyAlgorithm.Search;
using MyAlgorithm.Tree;
using System;

namespace MyAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //地图
            int[,] map = new int[8, 7];

            //初始化墙壁
            //上下全部为1，不可走
            for (int i = 0; i < 7; i++)
            {
                map[0, i] = 1;
                map[7, i] = 1;
            }
            //左右两个边为1，不可走
            for (int i = 0; i < 8; i++)
            {
                map[i, 0] = 1;
                map[i, 6] = 1;
            }

            //设置挡板
            map[3, 1] = 1;
            map[3, 2] = 1;

            Maze maze = new Maze();
            maze.Print(map);
            maze.SetWay(map,1,1);
            maze.Print(map);
            Console.Read();
        }
    }
}
