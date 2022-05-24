namespace MauiApp3;
using CommunityToolkit.Maui;

using MauiApp3.Services;
using MauiApp3.Views;
using MauiApp3.ViewModels;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<FileService>();

        builder.Services.AddTransient<ViewModel>();
        builder.Services.AddTransient<DetailPage>();

        return builder.Build();
    }
}
