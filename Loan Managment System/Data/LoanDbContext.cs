using Loan_Managment_System.Models;
using Microsoft.EntityFrameworkCore;
namespace Loan_Managment_System.Data
{
    public class LoanDbContext : DbContext
    {
        public LoanDbContext(DbContextOptions<LoanDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<LoanSchedule> LoanSchedules { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.PersonalNumber)
                .IsUnique();

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Customer)
                .WithMany(c => c.Loans)
                .HasForeignKey(l => l.CustomerId);

            modelBuilder.Entity<Payment>()
                 .HasOne(p => p.Loan)
                 .WithMany(l => l.Payments)
                 .HasForeignKey(p => p.LoanId);
                
            modelBuilder.Entity<LoanSchedule>()
                 .HasOne(ls => ls.Loan)
                 .WithMany(l => l.LoanSchedules)
                 .HasForeignKey(ls => ls.LoanId);



            modelBuilder.Entity<Loan>()
            .Property(x => x.Amount)
             .HasPrecision(18, 2);

            modelBuilder.Entity<Loan>()
                .Property(x => x.MonthlyPayment)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Payment>()
                .Property(x => x.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<LoanSchedule>()
                .Property(x => x.PMT)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }

    }

}
