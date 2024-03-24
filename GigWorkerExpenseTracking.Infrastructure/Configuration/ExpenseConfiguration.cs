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
            ConfigureExpenseItemsTable(builder);
        }

        private void ConfigureExpenseItemsTable(EntityTypeBuilder<Expense> builder)
        {
            builder.OwnsMany(x => x.ExpenseItems, item =>
            {
                item.ToTable("ExpenseItems");
                item.WithOwner()
                .HasForeignKey("ExpenseId");

                item.HasKey("Id", "ExpenseId");
                item.Property(x => x.Id)
                .HasConversion(id => id!.expenseItemId,
                value => ExpenseItemId.Create(value));

                item.Property(x => x.Amount)
                .HasPrecision(10, 2);

                item.Property(x => x.Date);

                item.Property(x => x.Description);
            });


            var Navigation = builder.Metadata.FindNavigation(nameof(Expense.ExpenseItems))!;
            Navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

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


            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(e => e.Description)
                .HasMaxLength(200);
            builder.Ignore(e => e.TotalAmount);




            builder.HasOne<User>()
              .WithMany()
              .HasForeignKey(e => e.UserId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
