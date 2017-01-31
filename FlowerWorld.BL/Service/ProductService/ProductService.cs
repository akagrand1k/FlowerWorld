using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerWorld.DAL.Models;
using FlowerWorld.DAL.Repository;
using System.IO;
using System.Web;

namespace FlowerWorld.BL.Service.ProductService
{
    public class ProductService : IProductService
    {
        private IRepository<Product> prodRepository { get; set; }

        public ProductService(IRepository<Product> prodRepo)
        {
            prodRepository = prodRepo;
        }
        public IEnumerable<Product> FullProductList
        {
            get
            {
                return prodRepository.Get;
            }
        }

        public void CreateProduct(ProductDto dto)
        {
            Product entity = new Product();
            if (dto != null)
            {
                entity.ProductName = dto.ProductName;
                entity.Price = dto.Price;
                entity.Description = dto.Description;
                entity.largePath = dto.largePath;
                entity.smallPath = dto.smallPath;
                entity.CategoryId = dto.CategoryId;
                entity.DateCreate = DateTime.Now;
                entity.DateUpdate = DateTime.Now;

                prodRepository.Add(entity);
            }
        }

        public void DeleteProduct(int id)
        {
            if (id != 0)
            {
                var itemDelete = prodRepository.GetById(id);
                DeleteExistFile(itemDelete.smallPath);
                DeleteExistFile(itemDelete.largePath);

                prodRepository.Delete(id);
            }
        }

        public void EditProduct(ProductDto dto)
        {
            var entityEdit = prodRepository.GetById(dto.Id);
            if (dto != null)
            {
                entityEdit.ProductName = dto.ProductName;
                entityEdit.Price = dto.Price;
                entityEdit.Description = dto.Description;
                entityEdit.CategoryId = dto.CategoryId;
                entityEdit.DateUpdate = DateTime.Now;

                prodRepository.Update(entityEdit);
            }
        }

        public Product GetProductById(int id)
        {
            return prodRepository.GetById(id);
        }
        private void DeleteExistFile(string path)
        {
            if (File.Exists(@HttpContext.Current.Server.MapPath(path)))
            {
                File.Delete(@HttpContext.Current.Server.MapPath(@path));
            }
        }
        private void ReplaceExistFile(string path)
        {

        }
    }
}
