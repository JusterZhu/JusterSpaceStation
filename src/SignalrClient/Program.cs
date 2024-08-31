using SignalrClient.MyHub;

namespace SignalrClient;

class Program
{
    static async Task Main(string[] args)
    {
        UpgradeHub upgradeHub = new UpgradeHub();
        await upgradeHub.StartAsync();
        //await upgradeHub.SendMessageAsync("client","Hello");
        
        while (true)
        {
           var content = Console.ReadLine();
           if (content == "exit") break;
        }
    }
}