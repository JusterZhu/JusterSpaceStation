using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using SignalrClient.MyObject;

namespace SignalrClient.MyHub;

public class UpgradeHub
{
    private HubConnection _connection;
    private string jwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpYXQiOjE3MjIwMDYyNzQ2NTUsImp0aSI6Ijc1NzEwM2YyLTRlMjMtNDRhNy1hZGU5LWFiMTcyM2UzMWY4NCIsInN1YiI6IjEiLCJuYW1lIjoianVzdGVyMiIsIm5iZiI6MTcyMjAwNjI3NCwiZXhwIjoxNzIyMDQ5NDc0LCJpc3MiOiJHZW5lcmFrU3BhY2VzdGF0aW9uIiwiYXVkIjoiR2VuZXJhbFNwYWNlc3RhdGlvbi5BZG1pbiJ9.TvEA23ram7ltE9uEzn0Kd9BA_u2rXctSDus8c209YbA";

    public UpgradeHub()
    {
        var client = new ClientDTO
        {
            AppKey = "123456789",
            Platform = 1,
            Ip = "127.0.0.1",
            Mac = "13:12:12:12:12:12",
            GroupId = Guid.NewGuid().ToString(),
            ProductId = "A0001"
        };
        
        _connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5008/UpgradeHub", options =>
            {
                options.AccessTokenProvider = () => Task.FromResult(jwtToken);
                options.Headers.Add("client", JsonConvert.SerializeObject(client));
            })
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