using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

public class Receipt
{
    public int ReceiptId { get; set; }
    public int EmployerName { get; set; }
    public decimal Amount { get; set; }
    public DateTime ReceiptDate { get; set; }
    public string ReceiptType { get; set; } // حق بیمه، رانندگان، کارگران ساختمانی و غیره

    public virtual Employer Employer { get; set; }
}
