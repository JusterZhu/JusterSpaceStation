namespace CastleDemo;

public interface IMyService
{
    void DoWork();
}

public class MyService : IMyService
{
    public void DoWork()
    {
        Console.WriteLine("Doing work...");
    }
}