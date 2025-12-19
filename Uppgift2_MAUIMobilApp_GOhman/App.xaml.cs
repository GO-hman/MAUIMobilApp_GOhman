namespace Uppgift2_MAUIMobilApp_GOhman
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            Application.Current!.UserAppTheme = AppTheme.Unspecified;

            MainPage = serviceProvider.GetService<AppShell>();
        }
    }
}
