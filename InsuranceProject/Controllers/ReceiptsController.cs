using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

public class ReceiptsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ReceiptsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var receipts = await _context.Receipts
            .Include(r => r.Employer)
            .ToListAsync();
        return View(receipts);
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
    public async Task<IActionResult> Create([Bind("EmployerName,Amount,ReceiptType,ReceiptDate")] Receipt receipt)
    {
        if (ModelState.IsValid)
        {
            _context.Add(receipt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // اگر مدل معتبر نباشد، دوباره لیست کارفرماها را به View ارسال کنید
        var employers = await _context.Employers.ToListAsync();
        ViewBag.Employers = new SelectList(employers, "EmployerId", "EmployerName");

        return View(receipt);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var receipt = await _context.Receipts
            .Include(r => r.Employer)
            .FirstOrDefaultAsync(m => m.ReceiptId == id);
        if (receipt == null)
        {
            return NotFound();
        }

        return View(receipt);
    }

   
}
