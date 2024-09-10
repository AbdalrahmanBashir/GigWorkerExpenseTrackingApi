using AutoMapper;
using GigWorkerExpenseTracking.Application.DTOs.AuthenticationDTOs;
using GigWorkerExpenseTracking.Application.DTOs.ExpensesDTOs;
using GigWorkerExpenseTracking.Application.DTOs.MileagesDTOs;
using GigWorkerExpenseTracking.Domain.ExpenseAggregate;
using GigWorkerExpenseTracking.Domain.MileageAggregate;
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


            
            CreateMap<AddExpenseDto, Expense>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => UserId.CreateID(src.UserId)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<AddUserDto, User>().ReverseMap();


            CreateMap<AddMileageDto, Mileage>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => UserId.CreateID(src.UserId)))
                .ForMember(dest => dest.LogDate, opt => opt.MapFrom(src => src.LogDate));
               

        }
    }
}

