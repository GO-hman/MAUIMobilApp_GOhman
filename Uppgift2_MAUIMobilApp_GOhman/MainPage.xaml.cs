using Uppgift2_MAUIMobilApp_GOhman.ViewModels;

namespace Uppgift2_MAUIMobilApp_GOhman
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
            vm.InitializeTopNews();
        }
    }
}
