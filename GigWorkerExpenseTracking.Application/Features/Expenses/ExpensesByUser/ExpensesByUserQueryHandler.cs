using AutoMapper;
using Microsoft.AspNetCore.Http;
using GigWorkerExpenseTracking.Application.Contracts;
using GigWorkerExpenseTracking.Application.DTOs.ExpensesDTOs;
using GigWorkerExpenseTracking.Application.Models;
using GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects;
using MediatR;
using GigWorkerExpenseTracking.Application.Services;

namespace GigWorkerExpenseTracking.Application.Features.Expenses.ExpensesByUser
{
    public class ExpensesByUserQueryHandler : IRequestHandler<ExpensesByUserQuery, PagedResponse<ExpenseDto>>
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;
        private readonly IUrlGenerator _urlGenerator;


        public ExpensesByUserQueryHandler(IExpenseRepository expenseRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IUrlGenerator urlGenerator)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
            _urlGenerator = urlGenerator;
        }

        public async Task<PagedResponse<ExpenseDto>> Handle(ExpensesByUserQuery request, CancellationToken cancellationToken)
        {

            if (request.UserId == null)
            {
                throw new ArgumentNullException(nameof(request.UserId), "User ID cannot be null.");
            }

            var expenses = await _expenseRepository.GetExpensesByUserAsync(
                UserId.CreateID(request.UserId!));

            if (expenses == null)
            {
                throw new ArgumentNullException(nameof(expenses), "Expenses cannot be null.");
            }

            var expensesDto = expenses.Select(expense => _mapper.Map<ExpenseDto>(expense)).AsQueryable();

            var pageRespose = new PagedResponse<ExpenseDto>(expensesDto, request.paging!);
            if (pageRespose.Paging.HasNextPage)
            {
                pageRespose.Paging.NextPageURL = _urlGenerator.GenerateUrl("api/Expense", new
                {
                    request.UserId,
                    request.paging!.rowCount,
                    pagNumber = request.paging.pagNumber + 1
                });
            }
            if (pageRespose.Paging.HasPrevPage)
            {
                pageRespose.Paging.PrevPageURL = _urlGenerator.GenerateUrl("api/Expense", new
                {
                    request.UserId,
                    request.paging!.rowCount,
                    pagNumber = request.paging.pagNumber - 1
                });
            }


            return pageRespose;
            
        }

    }
}
