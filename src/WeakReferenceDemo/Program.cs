namespace WeakReferenceDemo
{
    public class TestClass
    {
        ~TestClass()
        {
            // 这是一个终结器
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //object strongRef = new object(); // 创建强引用对象
            //WeakReference weakRef = new WeakReference(strongRef); // 对强引用对象进行弱引用
            //strongRef = null; // 释放强引用
            //GC.Collect(); // 强制执行垃圾回收
            //Console.WriteLine(weakRef.IsAlive ? "Object has not been collected." : "Object has been collected.");


            // 创建一个强引用对象
            TestClass strongRef = new TestClass();

            // 对强引用对象进行弱引用
            WeakReference weakRef = new WeakReference(strongRef);

            // 释放强引用
            strongRef = null;

            // 调用垃圾回收器
            GC.Collect();
            GC.WaitForPendingFinalizers(); // 等待终结器完成

            // 检查弱引用的状态
            Console.WriteLine(weakRef.IsAlive ? "Object has not been collected." : "Object has been collected.");

            Console.Read();
        }
    }
}
