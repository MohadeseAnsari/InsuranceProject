using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

public class InsuranceList
{
    public int InsuranceListId { get; set; } // اصلاح شده
    public string EmployerName { get; set; }
    public Employer Employer { get; set; } = null!;
    public int ListMonth { get; set; }
    public int ListYear { get; set; }
    public decimal TotalAmount { get; set; }
}
