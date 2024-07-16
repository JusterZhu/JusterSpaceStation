using StackExchange.Redis;

namespace RedisTest;

public class RedisProvider
{
    private static string connectionString = "192.168.50.167:6379";
    
    /// <summary>
    /// 创建一个Lazy<ConnectionMultiplexer>，用于线程安全的创建和初始化ConnectionMultiplexer
    /// </summary>
    private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(connectionString));
    
    private RedisProvider() { }

    /// <summary>
    /// 通过Connection属性获取ConnectionMultiplexer实例
    /// </summary>
    public static ConnectionMultiplexer Connection
    {
        get
        {
            return lazyConnection.Value;
        }
    }

    /// <summary>
    /// 获取指定数据库
    /// </summary>
    /// <param name="db"></param>
    /// <returns></returns>
    public static IDatabase GetDatabase(int db = -1)
    {
        return Connection.GetDatabase(db);
    }

    /// <summary>
    /// 设置键值对
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="db"></param>
    public static async Task StringSetAsync(string key, string value, int db = -1)
    {
        await GetDatabase(db).StringSetAsync(key, value);
    }

    /// <summary>
    /// 获取键对应的值
    /// </summary>
    /// <param name="key"></param>
    /// <param name="db"></param>
    /// <returns></returns>
    public static async Task<string> StringGetAsync(string key, int db = -1)
    {
        return await GetDatabase(db).StringGetAsync(key);
    }
    
    /// <summary>
    /// 删除键对应的值
    /// </summary>
    /// <param name="key"></param>
    /// <param name="db"></param>
    /// <returns></returns>
    public static async Task<bool> KeyDeleteAsync(string key, int db = -1)
    {
        return await GetDatabase(db).KeyDeleteAsync(key);
    }

    public static bool HashSetAsync(string key, string hashfield,object value, int db = -1)
    {
        return GetDatabase(db).HashSet(key, hashfield, value.ToString());
    }
    
    public static async Task<string> HashGetAsync(string key, string hashfield, int db = -1)
    {
        return await GetDatabase(db).HashGetAsync(key, hashfield);
    }

    public static bool HashDeleteAsync(string key, string hashfield, int db = -1)
    {
        return GetDatabase(db).HashDelete(key, hashfield);
    }
    
    public static async Task<int> GetDBSize(int db = -1)
    {
       return (int) await GetDatabase(db).ExecuteAsync("DBSIZE",db);
    }

    /// <summary>
    /// 清空指定数据库中的所有键值对
    /// </summary>
    /// <param name="db"></param>
    public static void FlushDatabase(int db = -1)
    {
        foreach (var endPoint in Connection.GetEndPoints())
        {
            GetServer(endPoint.ToString().Split(':')[0], int.Parse(endPoint.ToString().Split(':')[1])).FlushDatabase(db);
        }
    }
    
    public static IServer GetServer(string host, int port)
    {
        return Connection.GetServer(host, port);
    }
}