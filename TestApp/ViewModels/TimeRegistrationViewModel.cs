using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TestApp.Maui.ViewModels;

public partial class TimeRegistrationViewModel : ObservableObject
{
    private int latestId;
    private readonly List<RowModel> data = new();

    [ObservableProperty] private bool loading;

    public TimeRegistrationViewModel()
    {
        LoadCommand.Execute(null);
    }

    public ObservableCollection<RowModel> Rows { get; } = new();

    [RelayCommand]
    private async Task Add()
    {
        await Task.Delay(100);

        data.Add(new RowModel
        {
            Id = latestId++,
            Text = latestId.ToString("0000000")
        });

        LoadCommand.Execute(null);
    }

    [RelayCommand]
    private async Task Delete(RowModel item)
    {
        Loading = true;

        await Task.Delay(100);

        var dataItem = data.Single(d => d.Id == item.Id);
        data.Remove(dataItem);

        LoadCommand.Execute(null);
    }

    [RelayCommand]
    private async Task Load()
    {
        Loading = true;
        Rows.Clear();

        await Task.Delay(100);
        foreach (var r in data)
        {
            Rows.Add(r);
        }

        Loading = false;
    }
}