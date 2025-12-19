
using ApiServiceLayer.Models;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace ApiServiceLayer
{
    public class NewsApiService
    {
        private string ApiKey { get; } = "59b26409f67844bc91c27adec5648894"; //TODO: Bryt ut detta till en fil i klienten
        public string Endpoint { get; set; } = "";

        public List<string> Queries { get; set; } = new();
        private HttpClient httpClient;

        public NewsApiService()
        {
            httpClient = new HttpClient();
        }

        public async Task<(List<Article>, int)> GetTopHeadLines(string category, int step, int page)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("X-Api-Key", ApiKey);
            client.DefaultRequestHeaders.Add("User-Agent", "NewsMauiStuff/1.0");
            Endpoint = $"https://newsapi.org/v2/top-headlines?country=us&category={category}&pageSize={step}&page={page}";
            var response = await client.GetAsync(Endpoint);
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var articles = JsonSerializer.Deserialize<NewsApiResponse>(jsonString, options);
            return (articles.Articles, articles.TotalResults);
        }
    }
}
