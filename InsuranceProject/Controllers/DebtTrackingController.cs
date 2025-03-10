using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

public class DebtTrackingController : Controller
{
    private readonly ApplicationDbContext _context;

    public DebtTrackingController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var debtTrackings = await _context.DebtTrackings
            .Include(d => d.Employer)
            .ToListAsync();
        return View(debtTrackings);
    }

    public async Task<IActionResult> Create()
    {
        // دریافت لیست کارفرماها از پایگاه داده
        var employers = await _context.Employers.ToListAsync();
        // ارسال لیست کارفرماها به View
        ViewBag.Employers = new SelectList(employers, "EmployerId", "EmployerName");
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("EmployerName,Amount,Status,NotificationDate,DeadlineDate,Remarks")] DebtTracking debtTracking)
    {
        if (ModelState.IsValid)
        {
            _context.Add(debtTracking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // اگر مدل معتبر نباشد، دوباره لیست کارفرماها را به View ارسال کنید
        var employers = await _context.Employers.ToListAsync();
        ViewBag.Employers = new SelectList(employers, "EmployerId", "EmployerName");

        return View(debtTracking);
    }
}
