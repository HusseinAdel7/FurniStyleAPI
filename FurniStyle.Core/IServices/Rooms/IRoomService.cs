using FurniStyle.Core.DTOs.Furnis;
using FurniStyle.Core.DTOs.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniStyle.Core.IServices.Rooms
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDTO>> GetAllRoomsAsync();
        Task<RoomDTO> GetRoomByIdAsync(int id);
        Task AddRoomAsync(RoomDTO roomDTO);
        void UpdateRoom(RoomDTO roomDTO);
        void DeleteRoom(RoomDTO roomDTO);
    }
}
