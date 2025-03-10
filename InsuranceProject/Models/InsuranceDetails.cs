using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

public class InsuranceDetails
{
    public int DetailId { get; set; }
    public int ListId { get; set; }
    public string InsuredName { get; set; }
    public string NationalId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal DailyWage { get; set; }
    public decimal MonthlyWage { get; set; }
    public decimal Benefits { get; set; }

    public virtual InsuranceList InsuranceList { get; set; }
}
