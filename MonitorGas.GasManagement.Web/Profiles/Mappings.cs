using AutoMapper;
using MonitorGas.GasManagement.Data.Entities;
using MonitorGas.GasManagement.Web.Models;
using MonitorGas.GasManagement.Web.Models.OrderViewModel;

namespace MonitorGas.GasManagement.Web.Profiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Gas, GasListViewModel>().ReverseMap();
            CreateMap<Gas, GasDetailsViewModel>().ReverseMap();
            CreateMap<GasListViewModel, Gas>();
            CreateMap<GasSize, GasSizesViewModel>().ReverseMap();
            CreateMap<GasSize, GasSizesWithGasModel>().ReverseMap();
            CreateMap<Gas, GasesNestedViewModel>().ReverseMap();
            CreateMap<GasesNestedViewModel, Gas>().ReverseMap();
            CreateMap<Order, OrdersForMonthListViewModel>().ReverseMap();
        }
    }
}