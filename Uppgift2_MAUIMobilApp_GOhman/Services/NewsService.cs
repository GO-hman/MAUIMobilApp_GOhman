using ApiServiceLayer;
using ApiServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift2_MAUIMobilApp_GOhman.Services
{
    public class NewsService
    {
        private readonly NewsApiService apiService;

        public NewsService(NewsApiService apiService)
        {
            this.apiService = apiService;
        }

        public async Task<(List<Article>, int)> GetTopHeadlines(string category, int step, int page)
        {
            if (category == "All")
                category = "";
            return await apiService.GetTopHeadLines(category, step, page);
        }
    }
}
