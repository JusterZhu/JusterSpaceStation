using Castle.DynamicProxy;

namespace CastleDemo;

class Program
{
    static void Main(string[] args)
    {
        ProxyGenerator generator = new ProxyGenerator();
        MyInterceptor interceptor = new MyInterceptor();

        IMyService proxy = generator.CreateInterfaceProxyWithTarget<IMyService>(
            new MyService(), interceptor);

        proxy.DoWork();
    }
}