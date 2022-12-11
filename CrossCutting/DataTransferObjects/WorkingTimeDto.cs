namespace CrossCutting.DataObjects;

public class WorkingTimeDto
{
    public int Id;
    public DateTime? Date { get; set; }
    public decimal TimeEntry { get; set; }
    public int ProjectId { get; set; }
    public int CategoryId { get; set; }
    public int EmployeeId { get; set; }
    public string Comment { get; set; }
}