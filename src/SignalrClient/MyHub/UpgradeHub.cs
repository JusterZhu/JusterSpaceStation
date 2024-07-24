using Microsoft.AspNetCore.SignalR.Client;

namespace SignalrClient.MyHub;

public class UpgradeHub
{
    private HubConnection _connection;

    public UpgradeHub()
    {
        _connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5000/chatHub")
            .Build();

        _connection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            Console.WriteLine($"{user}: {message}");
        });
    }

    public async Task StartAsync()
    {
        await _connection.StartAsync();
        Console.WriteLine("Connection started");
    }

    public async Task SendMessageAsync(string user, string message)
    {
        await _connection.InvokeAsync("SendMessage", user, message);
    }
}