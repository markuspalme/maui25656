using CommunityToolkit.Mvvm.ComponentModel;

namespace TestApp.Maui.ViewModels;

public partial class RowModel : ObservableObject
{
    [ObservableProperty] private int? id;

    [ObservableProperty] private string text;
}