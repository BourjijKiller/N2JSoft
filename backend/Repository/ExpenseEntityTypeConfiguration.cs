using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Repository.Entities;

namespace Repository;

internal sealed class ExpenseEntityTypeConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.ToTable("expenses");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.Description)
               .HasMaxLength(1000)
               .IsRequired();

        builder.Property(x => x.Amount)
               .HasPrecision(10, 2)
               .IsRequired();

        builder.Property(x => x.Categorie)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(x => x.DateCreation)
               .IsRequired();

        builder.Property(x => x.DateModification);
    }
}