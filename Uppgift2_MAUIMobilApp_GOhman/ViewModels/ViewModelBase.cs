using CommunityToolkit.Mvvm.ComponentModel;

namespace Uppgift2_MAUIMobilApp_GOhman.ViewModels
{
    public partial class ViewModelBase : ObservableObject
    {
        [ObservableProperty]
        public string title = "";
    }
}
