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
        Task<bool> AddPaystackKey(Dictionary<string, string> keys);
        Task<bool> AddDispatchedProducts(DispatchProduct product);
        Task<List<DispatchProduct>> GetDispatchedProducts();
        Task<bool> DeleteDispatchedProduct(string id);
        Task<Dictionary<string, string>> GetPaystackKeys();
    }
}