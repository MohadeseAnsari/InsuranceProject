using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

public class Installment
{
    public int InstallmentId { get; set; }
    public int DebtId { get; set; }
    public DebtTracking DebtTracking { get; set; } = null!;
    public decimal Amount { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsPaid { get; set; }
}