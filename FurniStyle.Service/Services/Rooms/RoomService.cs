using AutoMapper;
using FurniStyle.Core.DTOs.Categories;
using FurniStyle.Core.DTOs.Rooms;
using FurniStyle.Core.Entities;
using FurniStyle.Core.IServices.Rooms;
using FurniStyle.Core.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniStyle.Service.Services.Rooms
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomDTO>> GetAllRoomsAsync()
        {
            return _mapper.Map<IEnumerable<RoomDTO>>(await _unitOfWork.Repository<Room, int>().GetAllAsync());
        }

        public async Task<RoomDTO> GetRoomByIdAsync(int id)
        {
            return _mapper.Map<RoomDTO>(await _unitOfWork.Repository<Room, int>().GetAsync(id));
        }

        public Task AddRoomAsync(RoomDTO roomDTO)
        {
            throw new NotImplementedException();
        }

        public void UpdateRoom(RoomDTO roomDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteRoom(RoomDTO roomDTO)
        {
            throw new NotImplementedException();
        }

      

      
    }
}
