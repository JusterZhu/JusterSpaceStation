using System.Text.Json;

namespace JsonTest;

class Program
{
    static void Main(string[] args)
    {
        var reseponseJson = File.ReadAllText("response.json");
        var s = JsonSerializer.Deserialize<VersionRespDTO>(reseponseJson);
        Console.Read();
    }
}