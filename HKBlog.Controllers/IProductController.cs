using HKBlog.Models;

namespace HKBlog.Controllers
{
    public interface IProductController
    {
        Task<bool> AddCategory(string categoryName);
        Task<bool> AddProduct(Product product);
        Task<bool> DeleteProduct(string id);
        Task<List<string>> GetCategories();
        Task<Product> GetProduct(string id);
        Task<List<Product>> GetProducts();
        void AddPaystackKey(Dictionary<string, string> keys);
        Task<Dictionary<string, string>> GetPaystackKeys();
    }
}