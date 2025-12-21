using ApiServiceLayer.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift2_MAUIMobilApp_GOhman.ViewModels
{
    public partial class ArticleViewModel : ViewModelBase
    {
        private readonly Article model;

        public ArticleViewModel(Article model)
        {
            this.model = model;

            //Initialize values for properties
            Source = model.Source;
            Author = model.Author;
            Title = model.Title;
            Description = model.Description;
            Url = model.Url;
            UrlToImage = model.UrlToImage;
            PublishedAt = model.PublishedAt;
            Content = model.Content;
        }

        [ObservableProperty]
        private Source source;

        [ObservableProperty]

        private string author;
     
        [ObservableProperty]

        string description;
        [ObservableProperty]

        string url;
        [ObservableProperty]

        string urlToImage;
        [ObservableProperty]

        DateTime publishedAt;
        [ObservableProperty]
        string content;

        public int ImgHeight => string.IsNullOrEmpty(UrlToImage) ? 0 : 250;

        public bool HasAuthor => !string.IsNullOrEmpty(Author);
    }
}
