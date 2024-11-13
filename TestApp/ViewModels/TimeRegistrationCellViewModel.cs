using System.Globalization;

namespace TestApp.Maui.ViewModels;

public class TimeRegistrationCellViewModel
{
    public static TimeRegistrationCellViewModel FromModel(Shared.Model.TimeRegistration model)
    {
        var vm = new TimeRegistrationCellViewModel
        {
            Date = model.Date,
            Index = model.Index,
            TimeRange = model.From + (!string.IsNullOrWhiteSpace(model.To) ? (" - " + model.To) : ""),
            Id = model.Id,
            FromTime = model.From,
            ToTime = model.To
        };

        if (!string.IsNullOrWhiteSpace(model.To) && !string.IsNullOrWhiteSpace(model.From))
        {
            var from = TimeSpan.ParseExact(model.From, "hh\\:mm", CultureInfo.InvariantCulture);
            var to = TimeSpan.ParseExact(model.To, "hh\\:mm", CultureInfo.InvariantCulture);

            var duration = to - from;

            if (duration.TotalHours < 0)
            {
                duration = duration.Add(new TimeSpan(24, 0, 0));
            }

            vm.Duration = duration.ToString("hh\\:mm");
        }
        else
        {
            vm.Duration = "Unvollständiger Eintrag";
        }

        return vm;
    }

    #region Properties

    public string TimeRange { get; set; }

    public string Duration { get; set; }

    public DateTime Date { get; set; }

    public int? Id { get; set; }

    public int Index { get; set; }

    public string FromTime { get; set; }

    public string ToTime { get; set; }

    #endregion
}