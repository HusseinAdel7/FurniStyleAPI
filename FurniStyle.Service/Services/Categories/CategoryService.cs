using AutoMapper;
using FurniStyle.Core.DTOs.Categories;
using FurniStyle.Core.DTOs.Furnis;
using FurniStyle.Core.Entities;
using FurniStyle.Core.IServices.Categories;
using FurniStyle.Core.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniStyle.Service.Services.Categories
{
    public class CategoryService:ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategorisAsync()
        {
            return _mapper.Map<IEnumerable<CategoryDTO>>(await _unitOfWork.Repository<Category, int>().GetAllAsync());
        }



        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            return _mapper.Map<CategoryDTO>(await _unitOfWork.Repository<Category, int>().GetAsync(id));

        }

        public Task AddCategoryAsync(CategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(CategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(CategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }

      

     
       
    }
}
