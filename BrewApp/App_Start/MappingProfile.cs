using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrewApp.DTOs;
using BrewApp.Models;

namespace BrewApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Employee, EmployeeDTO>();
            Mapper.CreateMap<EmployeeDTO, Employee>();

            Mapper.CreateMap<StockMaster, StockMasterDTO>();
            Mapper.CreateMap<StockMasterDTO, StockMaster>();

            Mapper.CreateMap<RecipeMaster, RecipeMasterDTO>();
            Mapper.CreateMap<RecipeMasterDTO, RecipeMaster>();

            Mapper.CreateMap<BrewingMaster, BrewingMasterDTO>();
            Mapper.CreateMap<BrewingMasterDTO, BrewingMaster>();

            Mapper.CreateMap<OrderEntry, OrderEntryDTO>();
            Mapper.CreateMap<OrderEntryDTO, OrderEntry>();

            Mapper.CreateMap<vw_Order_Blotter, OrderBlotterDTO>();
            Mapper.CreateMap<OrderBlotterDTO, vw_Order_Blotter>();

            Mapper.CreateMap<vw_Brewing_Blotter, BrewingBlotterDTO>();
            Mapper.CreateMap<BrewingBlotterDTO, vw_Brewing_Blotter>();

            Mapper.CreateMap<ExpenseMaster, ExpenseMasterDTO>();
            Mapper.CreateMap<ExpenseMasterDTO, ExpenseMaster>();

            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();

            Mapper.CreateMap<Keg, KegDTO>();
            Mapper.CreateMap<KegDTO, Keg>();
        }

    }
}