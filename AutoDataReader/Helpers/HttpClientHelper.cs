using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace AutoDataReader.Helpers
{
    public class HttpClientHelper
    {
        public static HttpClient GetClient()
        {
            var uriApiWord = new BuilderHelper()._configuration["APIWord_Access:UrlBase"];

            var client = new HttpClient
            {
                BaseAddress = new Uri(uriApiWord)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
