using Microsoft.Extensions.Logging;
using TechChallenge.MauiClient.Services;
using TechChallenge.MauiClient.ViewModels;
using Microsoft.Extensions.Http;

namespace TechChallenge.AppClient
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddHttpClient<ContactApiService>();

            builder.Services.AddSingleton<ContactApiService>();
            builder.Services.AddSingleton<ContactsViewModel>();
            builder.Services.AddSingleton<MainPage>();

            return builder.Build();
        }
    }
}
