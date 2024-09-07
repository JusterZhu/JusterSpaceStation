using System.Diagnostics;
using System.Reflection;

namespace AssemblyDemo;

class Program
{
    static void Main(string[] args)
    {
        // 创建测试对象
        var testObject = new TestClass();

        // 测试直接调用
        Stopwatch directStopwatch = Stopwatch.StartNew();
        for (int i = 0; i < 1000000; i++)
        {
            testObject.SimpleMethod();
        }
        directStopwatch.Stop();
        Console.WriteLine($"直接调用时间: {directStopwatch.ElapsedMilliseconds} ms");

        // 获取方法信息
        MethodInfo methodInfo = typeof(TestClass).GetMethod("SimpleMethod");

        // 测试反射调用
        Stopwatch reflectionStopwatch = Stopwatch.StartNew();
        for (int i = 0; i < 1000000; i++)
        {
            methodInfo.Invoke(testObject, null);
        }
        reflectionStopwatch.Stop();
        Console.WriteLine($"反射调用时间: {reflectionStopwatch.ElapsedMilliseconds} ms");
    }
}

class TestClass
{
    private int _counter = 0;

    public void SimpleMethod()
    {
        // 增加计数器
        _counter++;
    }
}