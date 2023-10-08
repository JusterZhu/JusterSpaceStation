using System.Runtime.CompilerServices;

namespace InlineArrayDemo
{


    // 定义一个内联数组，长度为N
    [InlineArray(10)]
    public struct InlineArrayExample
    {
         string Element;
    }

}
