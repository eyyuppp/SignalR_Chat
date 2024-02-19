using Microsoft.AspNetCore.SignalR.Client;

class SignalR_Console_Client
{
    static async Task Main(string[] args)
    {
        //hub ile bağlantı işlemi yapılıyor
        HubConnection connection = new HubConnectionBuilder()
       .WithUrl("https://localhost:7178/myhub")
       .Build();

        await connection.StartAsync();

        await Console.Out.WriteLineAsync($"ConnectionID:{connection.ConnectionId}");

        //serverdan gelen mesaşları karşılama
        connection.On<string>("receiveMessage", message =>
        {
             Console.WriteLine($"Message:{message}");
        });

        while (true)
        {
            if (Console.ReadKey().Key == ConsoleKey.M)
            {
                await Console.Out.WriteAsync("Lütfen göndereceğiniz mesajı yazınız.");
                await Console.Out.WriteAsync("Mesaj :");
                string message = Console.ReadLine();
                await Console.Out.WriteLineAsync();
                //SendMessage fonk. tetikler
                await connection.InvokeAsync("SendMessage", message);
            }
        }
    }
}

