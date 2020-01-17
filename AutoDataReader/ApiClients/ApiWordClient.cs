using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using AutoDataReader.Entities;
using Newtonsoft.Json;
using AutoDataReader.Helpers;

namespace AutoDataReader.ApiClients
{
    public class ApiWordClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        public ApiWordClient(IConfiguration configuration)
        {
            _client = HttpClientHelper.GetClient();

            _configuration = configuration;
        }

        public HttpResponseMessage Create(Word word)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "word")
            {
                Content = new StringContent(
                JsonConvert.SerializeObject(word),
                Encoding.UTF8, "application / json")
            };

            var result = _client.SendAsync(requestMessage).Result;
            return result;
        }
        
    }
}
