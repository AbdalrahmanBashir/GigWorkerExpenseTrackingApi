using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigWorkerExpenseTracking.Application.DTOs.PagingsDTOs
{
    public class PagingDTO
    {
        private int rowCount1 = 4;
        public int rowCount { get => rowCount1; set => rowCount1 = Math.Min(20, value); }
        public int pagNumber { get; set; } = 1;
    }
}
