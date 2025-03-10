using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

public class ClaimCase
{
    public int ClaimCaseId { get; set; }
    public string EmployerName { get; set; }
    public Employer Employer { get; set; }
    public string Status { get; set; }
}
