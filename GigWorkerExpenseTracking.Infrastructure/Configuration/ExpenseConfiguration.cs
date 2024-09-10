using GigWorkerExpenseTracking.Domain.ExpenseAggregate;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GigWorkerExpenseTracking.Domain.UserAggregate;

namespace GigWorkerExpenseTracking.Infrastructure.Configuration
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)

        {
            ConfigureExpenseTable(builder);
            
        }

   

        private void ConfigureExpenseTable(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable("Expenses");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("ExpenseId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id!.expenseId,
                    value => ExpenseId.Create(value)
                );


            builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(200);
            builder.Property(e => e.Amount).HasPrecision(18, 2).IsRequired();
            builder.Property(e => e.ActualDate);
            builder.Property(e => e.CreatedDate);
            builder.Property(e => e.LastModifiedDate);

            builder.HasOne<User>()
              .WithMany()
              .HasForeignKey(e => e.UserId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
