using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Colosseum.Services
{
    public class ApiServices
    {
        private const string _nowPlayingMoviesUrl = "http://colosseum.somee.com/api/NowPlayingMovies";

        public async Task<List<NowPlayingMovies>> GetNowPlayingMovies()
        {
            var client = new HttpClient();
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, _nowPlayingMoviesUrl);
            requestMessage.Headers.Add("ApiKey", "2ee2b3b0-3988-4546-b03f-43d9063e4ff0");
            var responseMessage = await client.SendAsync(requestMessage);
            var movieJson = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<NowPlayingMovies>>(movieJson);
        }

    }

}
