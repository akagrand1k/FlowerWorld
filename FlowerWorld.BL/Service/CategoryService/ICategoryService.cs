using FlowerWorld.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerWorld.BL.Service.CategoryService
{
    public interface ICategoryService
    {
        IEnumerable<Category> FullCategoryList { get; }
        Category GetCategoryById(int id);
        void CategoryCreate(CategoryDto Dto);
        void EditCategory(CategoryDto Dto);
        void DeleteCategory(int id);
    }
}
