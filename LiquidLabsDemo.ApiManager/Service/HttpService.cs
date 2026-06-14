using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LiquidLabsDemo.ApiManager.Service
{
    public  class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string?> GetAsync(string url, CancellationToken cancellationToken)
        {
            using var response = await _httpClient.GetAsync(url,cancellationToken);

            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadAsStringAsync(cancellationToken);
        }
    }
}
