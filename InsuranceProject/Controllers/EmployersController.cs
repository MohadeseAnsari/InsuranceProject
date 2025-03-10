using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

public class EmployersController : Controller
{
    private readonly ApplicationDbContext _context;

    public EmployersController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Employers.ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("EmployerName,EmployerType,EmployerCode,Address,PhoneNumber,Email")] Employer employer)
    {
        if (ModelState.IsValid)
        {
            _context.Add(employer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(employer);
    }
}
