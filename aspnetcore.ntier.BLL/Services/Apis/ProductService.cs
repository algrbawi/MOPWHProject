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
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ProductsTbl> _productTblRepository;

        public ProductService(IMapper mapper, IGenericRepository<ProductsTbl> productTblRepository)
        {
            _mapper = mapper;
            _productTblRepository = productTblRepository;
        }
        public async Task AddAsync(ProductsTblDto model)
        {

            var productTbl = _mapper.Map<ProductsTbl>(model);
            await _productTblRepository.AddAsync(productTbl);
        }
    }
}
