using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
namespace MyBot
{
    public class SeeSharpBotty
    {
        public static void Main(string[] args)
            => new SeeSharpBotty().MainAsync().GetAwaiter().GetResult();
        

        public async Task MainAsync()
        {
            var client = new DiscordSocketClient();

            client.Log += Log;
            client.MessageReceived += MessageReceived;

            string token = "NTE2NzIxMTMwMDgyNDAyMzE5.Dt3yzQ.379PqQLMxzYkaOGtLa8ETIKwbFI"; // Remember to keep this private!
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private async Task MessageReceived(SocketMessage message)
        {
            Console.WriteLine($"\n\nAuthor: {message.Author.Username}\nChannel: {message.Channel.Name}\nMessage: {message.Content}");
            if (message.Content.ToUpper().Contains("SEE"))
            {
                await message.Author.SendMessageAsync("I see you.");
            }
            if (message.Content == "!ping")
            {
                await message.Channel.SendMessageAsync("Pong!");
            }
        }
    }
}
