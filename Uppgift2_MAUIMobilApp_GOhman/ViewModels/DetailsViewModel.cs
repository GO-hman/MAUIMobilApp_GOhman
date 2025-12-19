using ApiServiceLayer.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Uppgift2_MAUIMobilApp_GOhman.ViewModels
{
    [QueryProperty("Article", "Article")]
    public partial class DetailsViewModel : ViewModelBase
    {
        [ObservableProperty]
        ArticleViewModel article;

        [RelayCommand]
        async Task OpenUrl(string url)
        {
            await Launcher.Default.OpenAsync(url);
        }
    }
}
