using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

public class Complaint
{
    public int ComplaintId { get; set; }
    public string EmployerName { get; set; }
    public Employer Employer { get; set; } = null!;
    public DateTime ComplaintDate { get; set; }
    public string ComplaintDetails { get; set; } = null!;
    public string Status { get; set; } = null!; // در حال بررسی یا بررسی شده
    public string Title { get; set; } = null!; // اضافه شده
    public string Description { get; set; } = null!; // اضافه شده
}
