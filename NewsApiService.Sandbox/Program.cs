using ApiServiceLayer;

namespace NewsApiService.Sandbox
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var apiService = new ApiServiceLayer.NewsApiService();

            //await apiService.GetTopHeadLines();
            await apiService.GetEverything();
        }
    }
}
