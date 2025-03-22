using FurniStyle.Core.DTOs.Furnis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniStyle.Core.IServices.Furnis
{
    public interface IFurniService
    {
        Task<IEnumerable<FurniDTO>> GetAllFurnisAsync();
        Task<FurniDTO> GetFurniByIdAsync(int id);
        Task AddFurniAsync(FurniDTO furniDTO);
        void UpdateFurni(FurniDTO furniDTO);
        void DeleteFurni(FurniDTO furniDTO);
    }
}
