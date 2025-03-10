using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

public class ComplaintsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ComplaintsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var complaints = await _context.Complaints
            .Include(c => c.Employer)
            .ToListAsync();
        return View(complaints);
    }

    public async Task<IActionResult> Create()
    {
        // دریافت لیست کارفرماها از پایگاه داده
        var employers = await _context.Employers.ToListAsync();
        // ارسال لیست کارفرماها به View
        ViewBag.Employers = new SelectList(employers, "EmployerId","EmployerName");
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("EmployerName,ComplaintDetails")] Complaint complaint)
    {
        if (ModelState.IsValid)
        {
            complaint.ComplaintDate = DateTime.Now;
            complaint.Status = "در حال بررسی";
            _context.Add(complaint);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // اگر مدل معتبر نباشد، دوباره لیست کارفرماها را به View ارسال کنید
        var employers = await _context.Employers.ToListAsync();
        ViewBag.Employers = new SelectList(employers,"EmployerName");
        return View(complaint);
    }
}
