using System.Collections.Generic;
using System.Net.Http;
using AutoDataReader.Entities;
using Newtonsoft.Json;
using AutoDataReader.Helpers;
using System.Text;

namespace AutoDataReader.ApiClients
{
    public class ApiWordClient
    {
        private readonly HttpClient _client;

        public ApiWordClient()
        {
            _client = HttpClientHelper.GetClient();
        }

        public HttpResponseMessage Create(Word word)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"word")
            {
                Content = new StringContent(JsonConvert.SerializeObject(word), Encoding.UTF8, "application/json")
            };

            var response = _client.SendAsync(requestMessage).Result;

            if (response.IsSuccessStatusCode)
            {
                var contentResult = response.Content.ReadAsStringAsync().Result;
                var content = JsonConvert.DeserializeObject<Word>(contentResult);
            }

            return response;
        }

        public Word Get(int id)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"word/{id}");
            var response = _client.SendAsync(requestMessage).Result;

            if (response.IsSuccessStatusCode)
            {
                var contentResult = response.Content.ReadAsStringAsync().Result;
                var content = JsonConvert.DeserializeObject<Word>(contentResult);
                return content;
            }

            return null;
        }

        public List<Word> GetAll()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "word");
            var response = _client.SendAsync(requestMessage).Result;

            if (response.IsSuccessStatusCode)
            {
                var contentResult = response.Content.ReadAsStringAsync().Result;
                var content = JsonConvert.DeserializeObject<List<Word>>(contentResult);
                return content;
            }

            return null;
        }
        
    }
}
