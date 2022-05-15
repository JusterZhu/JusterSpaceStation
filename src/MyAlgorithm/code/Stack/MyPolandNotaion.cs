using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyAlgorithm.Stack
{
    /// <summary>
    /// 逆波兰表达式
    /// </summary>
    internal class MyPolandNotaion
    {
        //先定义一个逆波兰表达式
        //（3+4）* 5 - 6对应3 4 + 5 * 6 -
        //为了方便，逆波兰表达式的数字和符号使用空格隔开
        public static string suffixExpression = "3 4 + 5 * 6 -";
        //思路
        //1.先将"3 4 + 5 * 6 -"存入一个List中
        //2.将AarryList传递一个方法，遍历List配合栈完成计算

        //将一个逆波兰表达式，一次将数据和运算符放入到List中
        public static List<string> GetListString(string suffixExpression)
        {
            //将suffixExpression分割
            string[] split = suffixExpression.Split(' ');
            List<string> list = new List<string>();
            foreach (var item in split)
            {
                list.Add(item);
            }
            return list;
        }

        //完成逆波兰表达式的运算
        public static int Calculate(List<string> lst)
        {
            //创建栈，只需要一个栈即可
            Stack<string> stack = new Stack<string>();
            //遍历list
            foreach (var item in lst)
            {
                //判断是否是数字
                if (IsNumber(item))
                {
                    stack.Push(item);
                }
                else
                {
                    //POP出两个数并运算，再入栈
                    int num2 = Convert.ToInt32(stack.Pop());
                    int num1 = Convert.ToInt32(stack.Pop());
                    int result = 0;
                    if (item.Equals("+"))
                    {
                        result = num1 + num2;
                    }
                    else if (item.Equals("-"))
                    {
                        result = num1 - num2;
                    }
                    else if (item.Equals("*"))
                    {
                        result = num1 * num2;
                    }
                    else if (item.Equals("/"))
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        throw new Exception("nothing to do !");
                    }
                    stack.Push(result.ToString());
                }
            }
            //最后留在stack中的数据就是计算结果
            return Convert.ToInt32(stack.Pop());
        }

        /// <summary>
        /// 判断字符串是否是数字
        /// </summary>
        public static bool IsNumber(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            const string pattern = "^[0-9]*$";
            Regex rx = new Regex(pattern);
            return rx.IsMatch(s);
        }
    }
}
