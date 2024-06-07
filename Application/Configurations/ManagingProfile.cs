using Application.Contracts.Administrators.Commands;
using Application.Contracts.Customers.Commands;
using Application.Contracts.Customers.Queries;
using Application.Contracts.DairyExchange.Commands;
using Application.Contracts.DairyExchange.Queries;
using Application.Contracts.MilkDeliveries.Commands;
using Application.Contracts.MilkDeliveries.Queries;
using Application.Contracts.Stores.Commands;
using Application.Contracts.Stores.Queries;
using AutoMapper;
using Domain.Models.Administrators;
using Domain.Models.Customers;
using Domain.Models.DairyExchange;
using Domain.Models.MilkDeliveries;
using Domain.Models.Stores;

namespace Application.Configurations
{
    public class ManagingProfile : Profile
    {
        public ManagingProfile()
        {
            CreateMap<CreateAdminDto, Admin>();
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<Customer, GetAllCustomersDto>();
            CreateMap<CreateMilkStoreDto, MilkStore>();
            CreateMap<MilkStore, GetAllMilkStoteDto>();
            CreateMap<CreateMilkDeliveryDto, MilkDelivery>();
            CreateMap<MilkDelivery, GetAllMilkDeliveryDto>(); 
            CreateMap<CreateDairyExchangeDto, DairyExchange>();
            CreateMap<DairyExchange, GetDairyExchangeDto>();




        }
    }
}
