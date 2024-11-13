using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TestApp.Maui.ViewModels;

public partial class TimeRegistrationViewModel : ObservableObject
{
    private int latestId = 1;
    private readonly List<TimeRegistration> data = new();

    [ObservableProperty] private bool loading;

    public TimeRegistrationViewModel()
    {
        LoadCommand.Execute(null);
    }

    public ObservableCollection<TimeRegistrationCellViewModel> TimeRegistrations { get; } = new();

    [RelayCommand]
    private async Task AddRegistration()
    {
        await Task.Delay(100);

        var from = Random.Shared.Next(1, 10);

        data.Add(new TimeRegistration
        {
            Id = latestId++,
            Date = DateTime.Now,
            From = from.ToString("00") + ":00",
            To = (from + 1).ToString("00") + ":00"
        });

        LoadCommand.Execute(null);
    }

    [RelayCommand]
    private async Task DeleteTimeRegistration(TimeRegistrationCellViewModel item)
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
        TimeRegistrations.Clear();

        await Task.Delay(100);
        foreach (var r in data.Select(TimeRegistrationCellViewModel.FromModel))
        {
            TimeRegistrations.Add(r);
        }

        Loading = false;
    }
}