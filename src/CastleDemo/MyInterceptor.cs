namespace CastleDemo;

using Castle.DynamicProxy;

public class MyInterceptor : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        Console.WriteLine("Before method execution");
        invocation.Proceed(); // 执行原始方法
        Console.WriteLine("After method execution");
    }
}