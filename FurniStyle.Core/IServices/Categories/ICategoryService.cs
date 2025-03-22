using FurniStyle.Core.DTOs.Categories;
using FurniStyle.Core.DTOs.Furnis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniStyle.Core.IServices.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllCategorisAsync();
        Task<CategoryDTO> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(CategoryDTO categoryDTO);
        void UpdateCategory(CategoryDTO categoryDTO);
        void DeleteCategory(CategoryDTO categoryDTO);
    }
}
