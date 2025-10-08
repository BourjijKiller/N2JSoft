using Microsoft.EntityFrameworkCore;

using Repository.Entities;

namespace Repository;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {

    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        SavingChanges += Expenses_SavingChanges;
    }

    public DbSet<Expense> Expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=N2JSoft;Username=postgres;Password=root");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ExpenseEntityTypeConfiguration());
    }

    private void Expenses_SavingChanges(object? sender, SavingChangesEventArgs e)
    {
        ChangeTracker.Entries<Expense>()
                     .Where(x => x.State is EntityState.Added or EntityState.Modified)
                     .ToList()
                     .ForEach(x =>
                     {
                         var entity = x.Entity;

                         if (x.State is EntityState.Added)
                         {
                             entity.DateCreation = DateTime.UtcNow;
                             entity.Id = Guid.NewGuid();
                         }
                         else if (x.State is EntityState.Modified)
                         {
                             entity.DateModification = DateTime.UtcNow;
                         }
                     });
    }
}