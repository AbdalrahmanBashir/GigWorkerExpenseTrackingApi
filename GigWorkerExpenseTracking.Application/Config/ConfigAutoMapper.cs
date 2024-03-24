using AutoMapper;
using GigWorkerExpenseTracking.Application.DTOs.AuthenticationDTOs;
using GigWorkerExpenseTracking.Application.DTOs.ExpenseItemDTOs;
using GigWorkerExpenseTracking.Application.DTOs.ExpensesDTOs;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate.Entities;
using GigWorkerExpenseTracking.Domain.UserAggregate;
using GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects;

namespace GigWorkerExpenseTracking.Application.Config
{
    public class ConfigAutoMapper : Profile
    {
        public ConfigAutoMapper()
        {
            CreateMap<Expense, ExpenseDto>()
                .ForMember(dest => dest.ExpenseId, opt => opt.MapFrom(src => src.Id.expenseId))
                .ForMember(dest => dest.userId, opt => opt.MapFrom(src => src.UserId.userId))
                .IgnoreAllPropertiesWithAnInaccessibleSetter();


            CreateMap<ExpenseItem, ExpenseItemDto>()
                .ForMember(dest => dest.ExpenseItemId, opt => opt.MapFrom(src => src.Id!.expenseItemId));
            CreateMap<AddExpenseItemDto, ExpenseItem>().ReverseMap();
            CreateMap<AddExpenseDto, Expense>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => UserId.CreateID(src.UserId)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<AddUserDto, User>().ReverseMap();

        }
    }
}

