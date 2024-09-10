using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigWorkerExpenseTracking.Application.Models
{
    public class PagingDetails
    {
        public int TotalRows { get; set; }
        public int TotalPages { get; set; }
        public int CurPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPrevPage { get; set; }
        public string NextPageURL { get; set; }
        public string PrevPageURL { get; set; }
    }
}
