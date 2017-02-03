using FlowerWorld.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerWorld.BL.Service.ProductService
{
    public interface IProductService
    {
        IEnumerable<Product> FullProductList { get; }
        ProductDto GetProductById(int id);
        void CreateProduct(ProductDto dto);
        void EditProduct(ProductDto dto);
        void DeleteProduct(int id);
        List<Product> FilterProducts(int typeId, int minPrice, int maxPrice);
        List<Product> FilterProducts(int typeId);
        List<Product> SearchProducts(string critery);
    }
}
