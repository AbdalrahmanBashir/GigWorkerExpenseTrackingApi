using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigWorkerExpenseTracking.Application.DTOs.MileagesDTOs
{
    public class UpdateMileageDto
    {
        public Guid UserId { get; set; }
        public DateTime LogDate { get; set; }
        public decimal Distance { get; set; }
    }
}
