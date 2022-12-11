using CrossCutting.DataObjects;

namespace HourCountApi.ViewModels;

public class WorkingTimeAdapter
{
    public WorkingTimeViewModel ToWorkingTimeViewModel(WorkingTime workingTime)
    {
        WorkingTimeViewModel model = new()
        {
            Id = workingTime.Id,
            Date = workingTime.Date,
            TimeEntry = workingTime.TimeEntry,
            ProjectName = "",//workingTime.Project.Name,
            CategoryName = workingTime.Category.Name,
            Comment = workingTime.Comment
        };

        return model;
    }

    public IEnumerable<WorkingTimeViewModel> ToWorkingTimeViewModels(IEnumerable<WorkingTime> workingTimes)
    {
        List<WorkingTimeViewModel> result = new List<WorkingTimeViewModel>();

        foreach (var workingTime in workingTimes)
        {
            result.Add(ToWorkingTimeViewModel(workingTime));
        }

        return result;
    }
}