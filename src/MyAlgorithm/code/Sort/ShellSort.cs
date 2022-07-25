using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Sort
{
    public class ShellSort
    {
        public static void Sort(int[] arr)
        {
            int gap = arr.Length / 2;
            while (gap > 0)
            {
                for (int i = gap; i < arr.Length; i++)
                {
                    int insertVal = arr[i];
                    int insertIndex = i - gap;
                    while (insertIndex >= 0 && insertVal < arr[insertIndex])
                    {
                        arr[insertIndex + gap] = arr[insertIndex];
                        insertIndex -= gap;
                    }
                    arr[insertIndex + gap] = insertVal;
                }
                gap /= 2;
            }
            Console.WriteLine(string.Join(' ', arr));
        }
    }
}
