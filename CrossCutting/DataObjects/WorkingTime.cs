namespace CrossCutting.DataObjects;

public class WorkingTime
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public Decimal TimeEntry { get; set; }
    public Project Project { get; set; }
    public Category Category { get; set; }
    public Employee Employee { get; set; }
    public string Comment { get; set; }
}