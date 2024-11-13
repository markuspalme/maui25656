using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TestApp.Maui.ViewModels;

public partial class TimeRegistrationCellViewModel : ObservableObject
{
    public static TimeRegistrationCellViewModel FromModel(TimeRegistration model)
    {
        var vm = new TimeRegistrationCellViewModel
        {
            Date = model.Date,
            TimeRange = model.From + (!string.IsNullOrWhiteSpace(model.To) ? (" - " + model.To) : ""),
            Id = model.Id,
            FromTime = model.From,
            ToTime = model.To
        };

        var from = TimeSpan.ParseExact(model.From, "hh\\:mm", CultureInfo.InvariantCulture);
        var to = TimeSpan.ParseExact(model.To, "hh\\:mm", CultureInfo.InvariantCulture);

        var duration = to - from;

        vm.Duration = duration.ToString("hh\\:mm");

        return vm;
    }

    #region Properties

    [ObservableProperty] private string timeRange;

    [ObservableProperty] private string duration;

    [ObservableProperty] private DateTime date;

    [ObservableProperty] private int? id;

    [ObservableProperty] private string fromTime;

    [ObservableProperty] private string toTime;

    #endregion
}