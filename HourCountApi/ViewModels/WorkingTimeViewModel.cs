namespace HourCountApi.ViewModels;

public class WorkingTimeViewModel
{
    public long Id { get; set; }
    public DateTime Date { get; set; }
    public Decimal TimeEntry { get; set; }
    public string ProjectName { get; set; }
    public string CategoryName { get; set; }
    public string Comment { get; set; }
}