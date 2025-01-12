using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.DAL.Repositories.IRepositories;
using aspnetcore.ntier.DTO.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.BLL.Services.Apis
{
    public class PictureService : IPictureService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<PicturesTbl> _pictureTblRepository;

        public PictureService(IMapper mapper, IGenericRepository<PicturesTbl> pictureTblRepository)
        {
            _mapper = mapper;
            _pictureTblRepository = pictureTblRepository;
        }
        public async Task AddAsync(PictureTblDto model)
        {
            var siteTbl = _mapper.Map<PicturesTbl>(model);
            await _pictureTblRepository.AddAsync(siteTbl);
        }
    }
}
