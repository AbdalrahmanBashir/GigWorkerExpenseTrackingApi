using GigWorkerExpenseTracking.Application.DTOs.PagingsDTOs;

namespace GigWorkerExpenseTracking.Application.Models
{
    public class PagedResponse<T>
    {
        public PagingDetails Paging { get; set; }
        public List<T> Data { get; set; }

        public PagedResponse(IQueryable<T> queryable, PagingDTO pagingdDTO)
        {
            Paging = new PagingDetails();
            Paging.TotalRows = queryable.Count();
            Paging.TotalPages = (int)Math.Ceiling((double)Paging.TotalRows / pagingdDTO.rowCount);
            Paging.CurPage = pagingdDTO.pagNumber;
            Paging.HasNextPage = Paging.CurPage < Paging.TotalPages;
            Paging.HasPrevPage = Paging.CurPage > 1;

            Data = queryable.Skip((pagingdDTO.pagNumber - 1) * pagingdDTO.rowCount)
                 .Take(pagingdDTO.rowCount).ToList();
        }
    }
}
