using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace SeeSharpBotty
{
    public class Bot
    {
        private string Token { get; set; }

        public static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                new Bot(args[0]).MainAsync().GetAwaiter().GetResult();
            }
            else
            {
                Console.WriteLine("Please enter the bot's token.");
                Console.ReadKey();
            }
        }

        public Bot(string token)
        {
            Token = token;
        }

        private async Task MainAsync()
        {
            var client = new DiscordSocketClient();

            client.Log += Log;
            client.MessageReceived += MessageReceived;

            await client.LoginAsync(TokenType.Bot, Token);
            await client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private static Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private static async Task MessageReceived(SocketMessage message)
        {
            Console.WriteLine(
                $"\n\nAuthor: {message.Author.Username}\nChannel: {message.Channel.Name}\nMessage: {message.Content}");
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