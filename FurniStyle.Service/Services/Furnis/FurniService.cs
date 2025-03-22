using AutoMapper;
using FurniStyle.Core.DTOs.Furnis;
using FurniStyle.Core.Entities;
using FurniStyle.Core.IServices.Furnis;
using FurniStyle.Core.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniStyle.Service.Services.Furnis
{
    public class FurniService : IFurniService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FurniService(IUnitOfWork unitOfWork,IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<FurniDTO>> GetAllFurnisAsync()
        {
            return _mapper.Map<IEnumerable<FurniDTO>>( await _unitOfWork.Repository<Furni, int>().GetAllAsync());
        }

        public async Task<FurniDTO> GetFurniByIdAsync(int id)
        {
            return _mapper.Map<FurniDTO>(await _unitOfWork.Repository<Furni, int>().GetAsync(id));

        }

        public async Task AddFurniAsync(FurniDTO furniDTO)
        {
            throw new NotImplementedException();
        }

        public void UpdateFurni(FurniDTO furniDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteFurni(FurniDTO furniDTO)
        {
            throw new NotImplementedException();
        }

        

      
    }
}
