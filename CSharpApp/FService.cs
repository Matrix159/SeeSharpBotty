using System.Threading.Tasks;
using Discord.WebSocket;
using RestSharp;

namespace SeeSharpBotty
{
    public static class FService
    {
        private static readonly RestClient Client = new RestClient("https://foaas.com/");
        
        public static async Task RestCall(SocketMessage message)
        {
            var request = new RestRequest {Resource = "/asshole/SeeSharpBotty"};
            request.AddHeader("Accept", "text/plain");
            
            IRestResponse response = await Client.ExecuteGetTaskAsync(request);
            await message.Channel.SendMessageAsync(response.Content);
        }
    }
}