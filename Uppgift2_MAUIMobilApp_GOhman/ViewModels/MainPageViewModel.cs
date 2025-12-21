using ApiServiceLayer.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Uppgift2_MAUIMobilApp_GOhman.Services;

namespace Uppgift2_MAUIMobilApp_GOhman.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase
    {
        private readonly NewsService newsService;


        public int Step { get; } = 20;
        public int Page { get; set; } = 1;

        public bool HideIfRefreshing => !IsRefreshing;
        partial void OnIsRefreshingChanged(bool value)
        {
            OnPropertyChanged(nameof(HideIfRefreshing));
        }

        [ObservableProperty]
        bool isLoading;

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        int totalCount;

        [ObservableProperty]
        bool moreToLoad;

        [ObservableProperty]
        string? errorLabel;

        [ObservableProperty]
        ObservableCollection<ArticleViewModel> articles = new();

        [ObservableProperty]
        ObservableCollection<string> categories = new()
        {
            "All",
            "Business",
            "Entertainment",
            "General",
            "Health",
            "Science",
            "Sports",
            "Technology"
        };

        private string _selectedCategory;
        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                if (_selectedCategory != value)
                {
                    Page = 1;
                    _selectedCategory = value;
                    OnPropertyChanged();
                    Articles.Clear();
                    FetchByPageCommand.Execute(_selectedCategory);
                }
            }
        }

        public MainPageViewModel(NewsService newsService)
        {
            this.newsService = newsService;
        }

        public async void InitializeTopNews()
        {
            await FetchByPage();
            Page = 1;
        }

        [RelayCommand]
        async Task RefreshPage()
        {
            IsRefreshing = true;
            Articles.Clear();
            Page = 1;
            await FetchByPage();
            Page = 1;
            IsRefreshing = false;
        }

        [RelayCommand]
        async Task GotoDetail(ArticleViewModel article)
        {
            if (article == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}", true, new Dictionary<string, object> { { "Article", article } });
        }

        [RelayCommand(CanExecute = nameof(CanLoadMore))]
        async Task FetchByPage()
        {
            IsLoading = true;
            MoreToLoad = false;
            Page++;
            try
            {
                (List<Article> fetchArticles, TotalCount) = await newsService.GetTopHeadlines(SelectedCategory, Step, Page);
                foreach (var article in fetchArticles)
                {
                    Articles.Add(new ArticleViewModel(article));
                }
                IsLoading = false;
                MoreToLoad = fetchArticles.Count > 0;
                ErrorLabel = "";
                FetchByPageCommand.NotifyCanExecuteChanged();
            }
            catch (Exception)
            {
                IsLoading = false;
                ErrorLabel = "Error encountered. Try again!";
            }
        }

        bool CanLoadMore()
        {
            return !IsLoading && MoreToLoad;
        }
    }
}
