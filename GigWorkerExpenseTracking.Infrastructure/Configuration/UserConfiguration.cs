namespace GigWorkerExpenseTracking.Infrastructure.Configuration
{
    using GigWorkerExpenseTracking.Domain.UserAggregate;
    using GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id!.userId,
                    value => UserId.CreateID(value)
                );

            builder.Property(u => u.Username)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(u => u.FirstName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(u => u.LastName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(30)
                .IsRequired(); 
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.PasswordHash);
            builder.Property(u => u.PasswordSalt);
                

        }

    }


}