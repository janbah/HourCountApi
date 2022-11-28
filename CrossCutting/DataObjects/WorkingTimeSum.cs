namespace HourCountApi.ViewModels;

public class WorkingTimeSum
{
    public WorkingTimeSum(DateTime date, decimal sum)
    {
        Date = date;
        Sum = sum;
    }

    public DateTime Date { get;  }
    public Decimal Sum { get;  }
}