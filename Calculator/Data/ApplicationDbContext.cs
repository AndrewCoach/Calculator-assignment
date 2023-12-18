using Calculator.Models;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<CalculationHistory> CalculationHistory { get; set; }
}
