using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Recursion
{
    internal class Maze
    {
        public void Print(int[,] map) 
        {
            Console.WriteLine("迷宫地图：");
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(map[i, j] + "   ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 使用递归回溯来给小球找路
        /// 1.map表示地图
        /// 2.i,j表示从地图的那个位置开始出发（1，1）
        /// 3.如果小球能到map[6,5]位置（迷宫出口），则说明通路找到
        /// 4.约定：当map[i,j]为0表示该点没有走过当为1表示墙；2表示通路可以走；3表示该点以及走过，但是走不通
        /// 5.在走迷宫时，需要确定一个策略（方法）下->右->上->左，如果该点走不通，再回溯
        /// </summary>
        /// <param name="map"></param>
        /// <param name="i">从哪个位置开始找</param>
        /// <param name="j">从哪个位置开始找</param>
        /// <returns>找到通路true，否则false</returns>
        public bool SetWay(int[,] map,int i ,int j) 
        {
            if (map[6,5] == 2)
            {
                return true;
            }
            else
            {
                //0可以走还没有走
                if (map[i,j] == 0)
                {
                    //递归回溯
                    map[i,j] = 2;
                    //下
                    if (SetWay(map, i + 1, j))
                    {
                        return true;
                    }
                    //右
                    else if (SetWay(map, i, j + 1))
                    {
                        return true;
                    }
                    //上
                    else if (SetWay(map, i - 1, j))
                    {
                        return true;
                    }
                    //左
                    else if (SetWay(map, i, j - 1))
                    {
                        return true;
                    }
                    //走不通
                    else
                    {
                        map[i,j] = 3;
                        return false;
                    }
                }
                else 
                {
                    //如果[i][j] != 0
                    //则值为 1，2，3
                    return false;
                }
            }
        }
    }
}
