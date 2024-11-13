using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TestApp.Maui.ViewModels;

namespace TestApp.Maui;

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

        builder.Services.AddTransient<AppShell>();
        builder.Services.AddTransient<AppShellViewModel>();

        builder.Services.AddTransient<TimeRegistrationViewModel>();
        builder.Services.AddTransient<TimeRegistrationPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}