using aspnetcore.ntier.BLL.Services.Apis;
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
        CreateMap<TrucksTblDto, TrucksTbl>().ReverseMap();
        CreateMap<ProductsTblDto, ProductsTbl>().ReverseMap();
        CreateMap<UsersTblDto, UsersTbl>().ReverseMap();
        CreateMap<DriversTblDto, DriversTbl>().ReverseMap();
        CreateMap<NationTblDto, NationTbl>().ReverseMap();
        CreateMap<WeightClassTblDto, WeightClassTbl>().ReverseMap();
        CreateMap<SiteTblDto, SiteTbl>().ReverseMap();
        CreateMap<PictureTblDto, PicturesTbl>().ReverseMap();
        CreateMap<DashboardUserDto, DashboardUser>().ReverseMap();
        CreateMap<AccessUserDto, AccessUser>().ReverseMap();
        CreateMap<LogTbl, LogTblDto>().ReverseMap();
        CreateMap<Log, LogRequestDto>().ReverseMap();
        CreateMap<UserAction, UserActionDto>().ReverseMap();
    }
}
