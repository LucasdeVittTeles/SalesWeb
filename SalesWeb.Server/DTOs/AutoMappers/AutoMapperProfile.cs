using AutoMapper;
using SalesWeb.Server.Models;

namespace SalesWeb.Server.DTOs.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Seller, SellerDto>().ReverseMap();
            CreateMap<SalesRecord, SalesRecordDto>().ReverseMap();
        }
    }
}
