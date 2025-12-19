using ApiServiceLayer;
using Microsoft.Extensions.Logging;
using Uppgift2_MAUIMobilApp_GOhman.Services;
using Uppgift2_MAUIMobilApp_GOhman.ViewModels;

namespace Uppgift2_MAUIMobilApp_GOhman
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<DetailPage>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddTransient<DetailsViewModel>();
            builder.Services.AddScoped<NewsApiService>();
            builder.Services.AddScoped<NewsService>();
            builder.Services.AddScoped<AppShell>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
