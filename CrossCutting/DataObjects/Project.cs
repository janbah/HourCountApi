using System.Text;

namespace CrossCutting.DataObjects;

public class Project
{
    public int Id { get; set; }
    public string Name
    {
        get
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Customer.Name);
            sb.Append("-");
            sb.Append(Fair.Name );
            sb.Append("-");
            sb.Append(Fair.StartDate.Year.ToString());
    
            return sb.ToString();
        }
        
    }
    public Customer Customer { get; set; }
    public Fair Fair { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
}