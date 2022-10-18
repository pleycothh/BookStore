using ConsoleWebApi.Models;
using System.Collections.Generic;

namespace ConsoleWebApi.Repo
{
    public interface IProductRepository
    {
        int AddProduct(ProductModel product);
        List<ProductModel> GetAllProducts();
    }
}