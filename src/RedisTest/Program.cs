namespace RedisTest;

class Program
{
    static void Main(string[] args)
    {
        Init();
        Console.Read();
    }

    private static void Init()
    {
        RedisProvider.HashSetAsync("appkey", "1", "123", 0);
        RedisProvider.HashSetAsync("appkey", "2", "456", 0);
        RedisProvider.HashSetAsync("appkey", "3", "789", 0);
        //await RedisProvider.HashSetAsync("appkey", "1", "456", 0);
        RedisProvider.HashDeleteAsync("appkey", "1",0);
    }
}