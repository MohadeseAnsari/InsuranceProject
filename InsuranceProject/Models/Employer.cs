using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

public class Employer
{
    public string EmployerName { get; set; }
    public int EmployerId { get; set; }
    public string EmployerType { get; set; } = null!; // حقیقی یا حقوقی
    public string EmployerCode { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public ICollection<InsuranceList> InsuranceLists { get; set; } = new List<InsuranceList>(); // اضافه شده
    public ICollection<ClaimCase> ClaimCases { get; set; } = new List<ClaimCase>(); // اضافه شده
    public ICollection<Complaint> Complaints { get; set; } = new List<Complaint>(); // اضافه شده
    public ICollection<DebtTracking> Debts { get; set; } = new List<DebtTracking>(); // اضافه شده
}