using GigWorkerExpenseTracking.Domain.ExpenseAggregate.ValueObjects;
using GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigWorkerExpenseTracking.Application.DTOs.ExpensesDTOs
{
    public class ExpenseDto
    {
        public  string? ExpenseId { get; set; }
        public string? userId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime ActualDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

    }
}
