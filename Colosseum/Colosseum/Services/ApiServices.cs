using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Colosseum.Model;
using Newtonsoft.Json;

namespace Colosseum.Services
{
    public class ApiServices
    {
        private const string _nowPlayingMoviesUrl = "http://colosseum.somee.com/api/NowPlayingMovies";
        private const string _upComingMoviesUrl = "http://colosseum.somee.com/api/UpcomingMovies";
        private const string _latestMoviesUrl = "http://colosseum.somee.com/api/LatestMovies";
        private const string _orderUrl = "http://colosseum.somee.com/api/Orders";


        public async Task<List<NowPlayingMovie>> GetNowPlayingMovies()
        {
            var client = new HttpClient();
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, _nowPlayingMoviesUrl);
            requestMessage.Headers.Add("ApiKey", "2ee2b3b0-3988-4546-b03f-43d9063e4ff0");
            var responseMessage = await client.SendAsync(requestMessage);
            var movieJson = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<NowPlayingMovie>>(movieJson);
        }

        public async Task<List<UpComingMovie>> GetUpComingMovies()
        {
            var client = new HttpClient();
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, _upComingMoviesUrl);
            requestMessage.Headers.Add("ApiKey", "2ee2b3b0-3988-4546-b03f-43d9063e4ff0");
            var responseMessage = await client.SendAsync(requestMessage);
            var movieJson = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<UpComingMovie>>(movieJson);
        }

        public async Task<List<LatestMovie>>GetLatestMovies()
        {
            var client = new HttpClient();
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, _latestMoviesUrl);
            requestMessage.Headers.Add("ApiKey", "2ee2b3b0-3988-4546-b03f-43d9063e4ff0");
            var responseMessage = await client.SendAsync(requestMessage);
            var movieJson = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<LatestMovie>>(movieJson);
        }


        public async Task<bool> PostOrder(BookTicket orderTicket)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(orderTicket);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            content.Headers.Add("ApiKey", "2ee2b3b0-3988-4546-b03f-43d9063e4ff0");
            var response = await client.PostAsync(_orderUrl, content);
            return response.IsSuccessStatusCode;

        }




    }

}
