using System.Threading.Tasks;
using Discord.WebSocket;
using RestSharp;

namespace SeeSharpBotty
{
    public static class FService
    {
        private static readonly RestClient Client = new RestClient("https://foaas.com/");

        private static async Task RestCall(SocketMessage message, string endpoint)
        {
            var request = new RestRequest {Resource = endpoint};
            request.AddHeader("Accept", "text/plain");
            
            IRestResponse response = await Client.ExecuteGetTaskAsync(request);
            await message.Channel.SendMessageAsync(response.Content);
        }
        
        public static async Task Anyway(SocketMessage message, string company = "Google", string from = "SeeSharpBotty")
        {
            await RestCall(message, $"anyway/{company}/{from}");
        }
    }
}