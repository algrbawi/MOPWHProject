using aspnetcore.ntier.DAL.Entities;
using aspnetcore.ntier.DTO.DTOs;
using AutoMapper;

namespace aspnetcore.ntier.BLL.Utilities.AutoMapperProfiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        //CreateMap<ApiUser, UserDTO>().ReverseMap();
        //CreateMap<ApiUser, UserToAddDTO>().ReverseMap();
        //CreateMap<ApiUser, UserToUpdateDTO>().ReverseMap();
        //CreateMap<ApiUser, UserToRegisterDTO>().ReverseMap();
        //CreateMap<ApiUser, UserToReturnDTO>().ReverseMap();
        //CreateMap<WeightTbl, WeightTblDto>();
        CreateMap<WeightTblDto, WeightTbl>();
        CreateMap<TrucksTblDto, TrucksTbl>();


    }
}
