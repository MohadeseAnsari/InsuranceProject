using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

public class DebtTracking
{
    public int DebtId { get; set; }
    public string EmployerName { get; set; }
    public Employer Employer { get; set; } = null!;
    public decimal Amount { get; set; }
    public string Status { get; set; } = null!;
    public DateTime NotificationDate { get; set; }
    public DateTime? DeadlineDate { get; set; }
    public string Remarks { get; set; } = null!;
    public DateTime StartDate { get; set; } // اضافه شده
    public bool IsPaid { get; set; } // اضافه شده
    public ICollection<Installment> Installments { get; set; } = new List<Installment>(); // اضافه شده
}
