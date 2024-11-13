using System.Net;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Platform;
using TestApp.Maui.ViewModels;

namespace TestApp.Maui;

public partial class App : Application
{
    public App(AppShell appShell)
    {
        InitializeComponent();

        MainPage = appShell;

        #if IOS
        Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping("Testmaui", (handler, view) =>
        {
            if (view is Editor { AutoSize: EditorAutoSizeOption.TextChanges })
            {
                handler.PlatformView.Layer.BorderColor = UIKit.UIColor.SystemGray6.CGColor;
                handler.PlatformView.Layer.BorderWidth = 1.0f;
                handler.PlatformView.Layer.MasksToBounds = true;
                handler.PlatformView.Layer.CornerRadius = 5.0f;
            }
        });
#endif
    }
}