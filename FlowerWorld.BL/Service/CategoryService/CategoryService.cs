using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerWorld.DAL.Models;
using FlowerWorld.DAL.Repository;

namespace FlowerWorld.BL.Service.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private IRepository<Category> catRepository { get; set; }
        public CategoryService(IRepository<Category> catRepo)
        {
            catRepository = catRepo;
        }
        public IEnumerable<Category> FullCategoryList
        {
            get
            {
                return catRepository.Get;
            }
        }

        public void CategoryCreate(CategoryDto Dto)
        {
            Category entity = new Category();
            if (Dto != null)
            {
                entity.CategoryName = Dto.CategoryName;
                entity.largePath = Dto.largePath;
                entity.smallPath = Dto.smallPath;
                entity.DateCreate = DateTime.Now;
                entity.DateUpdate = DateTime.Now;
                catRepository.Add(entity);
            }
        }

        public void DeleteCategory(int id)
        {
            if (id != 0)
            {
                catRepository.Delete(id);
            }
        }

        public void EditCategory(CategoryDto Dto)
        {
            var entity = catRepository.GetById(Dto.Id);
            if (Dto != null)
            {
                entity.CategoryName = Dto.CategoryName;
                entity.DateUpdate = DateTime.Now;
                catRepository.Update(entity);
            }
        }

        public Category GetCategoryById(int id)
        {
            return catRepository.GetById(id);
        }
    }
}
