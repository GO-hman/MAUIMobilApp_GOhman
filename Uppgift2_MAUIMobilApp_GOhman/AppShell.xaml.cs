namespace Uppgift2_MAUIMobilApp_GOhman
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
        }
    }
}
