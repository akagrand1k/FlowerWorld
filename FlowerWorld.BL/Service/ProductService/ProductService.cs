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
                entityEdit.Id = dto.Id;
                entityEdit.ProductName = dto.ProductName;
                entityEdit.Price = dto.Price;
                entityEdit.Description = dto.Description;
                entityEdit.CategoryId = dto.CategoryId;
                entityEdit.DateUpdate = DateTime.Now;

                prodRepository.Update(entityEdit);
            }
        }

        public ProductDto GetProductById(int id)
        {
            Product prod = new Product();
            prod = prodRepository.GetById(id);
            return ProductMappDto(prod);
        }
        private void DeleteExistFile(string path)
        {
            if (File.Exists(@HttpContext.Current.Server.MapPath(path)))
            {
                File.Delete(@HttpContext.Current.Server.MapPath(@path));
            }
        }

        public List<Product> FilterProducts(int typeId, int minPrice, int maxPrice)
        {
            List<Product> results = null;
            if (minPrice != 0 || maxPrice != 0)
            {
                return results = FullProductList.Where(x => x.CategoryId == typeId && ((x.Price >= minPrice || minPrice == 0)
                && (x.Price <= maxPrice || maxPrice == 0))).OrderBy(x => x.Price).ToList();
            }
            else
            {
                return results = FullProductList.Where(x => x.CategoryId == typeId).ToList();
            }
            
        }

        public List<Product> FilterProducts(int typeId)
        {
            List<Product> results = null;
            if (typeId != 0)
            {
                return results = FullProductList.Where(x => x.CategoryId == typeId).ToList();
            }
            else
            {
                return results = FullProductList.ToList();
            }
        }

        public ProductDto ProductMappDto(Product prod)
        {
            return new ProductDto
            {
                Id = prod.Id,
                ProductName = prod.ProductName,
                Price = prod.Price,
                Description = prod.Description,
                CategoryId = prod.CategoryId
            };
        }

        public List<Product> SearchProducts(string critery)
        {
            if (!string.IsNullOrEmpty(critery))
            {
                return prodRepository.Get.Where(x => x.ProductName.Contains(critery)).ToList();
            }
            else
            {
                List<Product> emptyList = new List<Product>();
                return emptyList;
            }
        }
    }
}
