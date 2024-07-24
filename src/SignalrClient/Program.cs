using SignalrClient.MyHub;

namespace SignalrClient;

class Program
{
    static async Task Main(string[] args)
    {

        UpgradeHub upgradeHub = new UpgradeHub();
        await upgradeHub.StartAsync();
        
        while (true)
        {
           var content = Console.ReadLine();
           if (content == "exit") break;
        }
    }
}