using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TestApp.Maui.ViewModels;

public partial class TimeRegistrationViewModel : ObservableObject
{
    private int latestId;
    private readonly List<RowModel> rowData = new();

    public ObservableCollection<RowModel> Rows { get; } = new();

    [RelayCommand]
    private async Task Add()
    {
        // simulate network request
        await Task.Delay(100);

        rowData.Add(new RowModel
        {
            Text = latestId++.ToString("0000000")
        });

        LoadCommand.Execute(null);
    }

    [RelayCommand]
    private async Task Delete(RowModel item)
    {
        // simulate network request
        await Task.Delay(100);

        var dataItem = rowData.Single(d => d.Text == item.Text);
        rowData.Remove(dataItem);

        LoadCommand.Execute(null);
    }

    [RelayCommand]
    private async Task Load()
    {
        await Task.Delay(100);
        Rows.Clear();

        foreach (var r in rowData)
        {
            Rows.Add(r);
        }
    }
}