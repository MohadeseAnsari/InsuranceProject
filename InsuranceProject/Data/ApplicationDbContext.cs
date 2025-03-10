using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Data.Entity;
using InsuranceProject.Controllers;
using InsuranceProject.Models;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // جداول مربوط به سیستم
    public DbSet<Employer> Employers { get; set; }
    public DbSet<InsuranceList> InsuranceLists { get; set; }
    public DbSet<ClaimCase> ClaimCases { get; set; }
    public DbSet<Complaint> Complaints { get; set; }
    public DbSet<Installment> Installments { get; set; }
    public DbSet<Receipt> Receipts { get; set; }
    public DbSet<DebtTracking> DebtTrackings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // تعریف کلیدهای اصلی
        modelBuilder.Entity<Employer>().HasKey(e => e.EmployerName);
        modelBuilder.Entity<InsuranceList>().HasKey(il => il.InsuranceListId);
        modelBuilder.Entity<ClaimCase>().HasKey(cc => cc.ClaimCaseId);
        modelBuilder.Entity<Complaint>().HasKey(c => c.ComplaintId);
        modelBuilder.Entity<Installment>().HasKey(i => i.InstallmentId);
        modelBuilder.Entity<Receipt>().HasKey(r => r.ReceiptId);
        modelBuilder.Entity<DebtTracking>().HasKey(dt => dt.DebtId);

        // ارتباطات بین جداول

        // ارتباط یک به چند بین کارفرما و لیست‌های بیمه
        modelBuilder.Entity<InsuranceList>()
            .HasOne(il => il.Employer)
            .WithMany(e => e.InsuranceLists)
            .HasForeignKey(il => il.EmployerName);

        // ارتباط یک به چند بین کارفرما و پرونده‌های مطالباتی
        modelBuilder.Entity<ClaimCase>()
            .HasOne(cc => cc.Employer)
            .WithMany(e => e.ClaimCases)
            .HasForeignKey(cc => cc.EmployerName);

        // ارتباط یک به چند بین کارفرما و شکایات
        modelBuilder.Entity<Complaint>()
            .HasOne(c => c.Employer)
            .WithMany(e => e.Complaints)
            .HasForeignKey(c => c.EmployerName);

        // ارتباط یک به چند بین بدهی و اقساط
        modelBuilder.Entity<Installment>()
            .HasOne(i => i.DebtTracking)
            .WithMany(dt => dt.Installments)
            .HasForeignKey(i => i.DebtId);

        // ارتباط یک به چند بین کارفرما و بدهی‌ها
        modelBuilder.Entity<DebtTracking>()
            .HasOne(dt => dt.Employer)
            .WithMany(e => e.Debts)
            .HasForeignKey(dt => dt.EmployerName);
    }
}
