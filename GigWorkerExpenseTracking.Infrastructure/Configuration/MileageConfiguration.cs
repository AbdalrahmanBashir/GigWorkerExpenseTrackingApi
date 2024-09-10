using GigWorkerExpenseTracking.Domain.MileageAggregate;
using GigWorkerExpenseTracking.Domain.MileageAggregate.ValueObjects;
using GigWorkerExpenseTracking.Domain.UserAggregate;
using GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigWorkerExpenseTracking.Infrastructure.Configuration
{
    public class MileageConfiguration : IEntityTypeConfiguration<Mileage>
    {
        public void Configure(EntityTypeBuilder<Mileage> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id)
                .HasConversion(id => id!.Value,
                value => MileageId.ConvertId(value));

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(m => m.UserId);

            builder.Property(m => m.LogDate);
            builder.Property(m => m.Distance).HasPrecision(18, 2);
            builder.Property(m => m.CreatedDate);
            builder.Property(m => m.LastModifiedDate);

        }
    }
}
