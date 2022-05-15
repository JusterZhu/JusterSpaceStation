﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.SparseArray
{
    /// <summary>
    /// 稀疏数组
    /// </summary>
    public class MySparseArray
    {
        private int[,] SparseArray = new int[12, 12];

        public MySparseArray()
        {
            /*
             * exsmple： 5 row, 7 cloum
             * 1 white 2 black
             */
            SparseArray[5, 7] = 1;
            SparseArray[7, 5] = 1;
            SparseArray[7, 9] = 1;
            SparseArray[7, 11] = 1;
            SparseArray[8, 10] = 2;
            SparseArray[10, 9] = 2;
        }

        public void Print()
        {
            Console.WriteLine("1.原始棋盘内容。");
            for (int i = 0; i < SparseArray.GetLength(0); i++)
            {
                for (int j = 0; j < SparseArray.GetLength(1); j++)
                {
                    var chess = SparseArray[i, j];
                    Console.Write($"{ chess }\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("2.遍历二维数组，得到非0数据的个数");
            int sum = 0;
            for (int i = 0; i < SparseArray.GetLength(0); i++)
            {
                for (int j = 0; j < SparseArray.GetLength(1); j++)
                {
                    var chess = SparseArray[i, j];
                    if (chess != 0)
                    {
                        sum++;
                    }
                }
            }
            Console.WriteLine(sum);

            Console.WriteLine("3.创建稀疏数组");
            //稀疏数组记录有多少行、有多少列、有多少非0的值
            int[,] tempSparseArray = new int[sum + 1, 3];
            //第一行第一列，记录有多少行
            tempSparseArray[0, 0] = SparseArray.GetLength(0);
            //第一行第二列，记录有多少列
            tempSparseArray[0, 1] = SparseArray.GetLength(1);
            //第一行第三列，记录有多少非0的值
            tempSparseArray[0, 2] = sum;
            //遍历棋盘二维数组，将非0的值存放到稀疏数组中
            int count = 0;
            for (int i = 0; i < SparseArray.GetLength(0); i++)
            {
                for (int j = 0; j < SparseArray.GetLength(1); j++)
                {
                    var chess = SparseArray[i, j];
                    if (chess != 0)
                    {
                        count++;
                        //取出值不为0的行号
                        tempSparseArray[count, 0] = i;
                        //取出值不为0的列号
                        tempSparseArray[count, 1] = j;
                        //所在该行该列的值
                        tempSparseArray[count, 2] = SparseArray[i, j];
                    }
                }
            }

            Console.WriteLine("4.输出得到的稀疏数组");
            Console.WriteLine($"行\t列\t值");
            for (int i = 0; i < tempSparseArray.GetLength(0); i++)
            {
                Console.WriteLine($"{ tempSparseArray[i, 0] }\t{ tempSparseArray[i, 1] }\t{ tempSparseArray[i, 2] }");
            }

            Console.WriteLine("5.稀疏数组还原二维数组");
            //首先还原二维数组的大小
            int[,] tempSparseArray2 = new int[tempSparseArray[0, 0], tempSparseArray[0, 1]];
            //还原值,跳过第一行因为是存储二维数组的大小的
            for (int i = 1; i < tempSparseArray.GetLength(0); i++)
            {
                //根据稀疏数组提供的行和列找到对应的位置，将值插入即可。
                tempSparseArray2[tempSparseArray[i, 0], tempSparseArray[i, 1]] = tempSparseArray[i, 2];
            }

            //输出还原的稀疏数组
            for (int i = 0; i < tempSparseArray2.GetLength(0); i++)
            {
                for (int j = 0; j < tempSparseArray2.GetLength(1); j++)
                {
                    var chess = tempSparseArray2[i, j];
                    Console.Write($"{ chess }\t");
                }
                Console.WriteLine();
            }
        }
    }
}
