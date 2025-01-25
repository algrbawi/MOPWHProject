using aspnetcore.ntier.BLL.Services.IServices;
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
        CreateMap<WeightTblDto, WeightTbl>().ReverseMap();
        CreateMap<TrucksTblDto, TrucksTbl>();
        CreateMap<ProductsTblDto, ProductsTbl>();
        CreateMap<UsersTblDto, UsersTbl>();
        CreateMap<DriversTblDto, DriversTbl>();
        CreateMap<NationTblDto, NationTbl>();
        CreateMap<WeightClassTblDto, WeightClassTbl>();
        CreateMap<SiteTblDto, SiteTbl>().ReverseMap();
        CreateMap<PictureTblDto, PicturesTbl>();
        CreateMap<DashboardUserDto, DashboardUser>().ReverseMap();
        CreateMap<AccessUserDto, AccessUser>().ReverseMap();





    }
}
