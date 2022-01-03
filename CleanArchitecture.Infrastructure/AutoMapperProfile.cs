using AutoMapper;
using VehicleData.Application.ViewModels;
using VehicleData.Domain.Models;

namespace VehicleData.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Vehicle, VehicleViewModel>().ReverseMap();
        }
    }
}
