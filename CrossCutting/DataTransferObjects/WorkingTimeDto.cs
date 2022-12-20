namespace CrossCutting.DataTransferObjects;

public class WorkingTimeDto
{
    public int Id { get; set; }
    public DateTime? Date { get; set; }
    public double TimeEntry { get; set; }
    public int ProjectId { get; set; }
    public int CategoryId { get; set; }
    public int EmployeeId { get; set; }
    public string Comment { get; set; }
}