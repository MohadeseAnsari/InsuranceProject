using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

public class InstallmentsController : Controller
{
    private readonly ApplicationDbContext _context;

    public InstallmentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var installments = await _context.Installments
            .Include(i => i.DebtTracking)
            .ToListAsync();
        return View(installments);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("DebtId,Amount,DueDate,IsPaid")] Installment installment)
    {
        if (ModelState.IsValid)
        {
            _context.Add(installment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // دریافت لیست کارفرماها از پایگاه داده
        var installments = await _context.Installments.ToListAsync();
        // ارسال لیست کارفرماها به View
        ViewBag.Installments = new SelectList(installments, "DeptId");

        return View(installment);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var installment = await _context.Installments
            .Include(i => i.DebtTracking)
            .FirstOrDefaultAsync(m => m.InstallmentId == id);
        if (installment == null)
        {
            return NotFound();
        }

        return View(installment);
    }
}
