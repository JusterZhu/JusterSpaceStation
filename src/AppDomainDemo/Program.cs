using System.Reflection;
using System.Runtime.Loader;

namespace AppDomainDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Init();
            Console.Read();
        }

        private static void Init() 
        {
            string path = Path.Combine(AppContext.BaseDirectory, "HelloLib.dll");
            var alc = new AssemblyLoadContext(null, isCollectible: true);
            Assembly assembly = alc.LoadFromAssemblyPath(path);

            // 使用反射调用方法或者创建实例
            Type type = assembly.GetType("HelloLib.MyHello");
            object instance = Activator.CreateInstance(type);

            MethodInfo methodInfo = type.GetMethod("Do");
            methodInfo.Invoke(instance, null);
        }
    }
}
