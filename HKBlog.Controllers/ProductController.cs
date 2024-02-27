using HKBlog.Database;
using HKBlog.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.Controllers
{
    public class ProductController : IProductController
    {
        private readonly IDatabase database;
        public ProductController(IDatabase database)
        {
            this.database = database;
        }
        public async Task<bool> AddCategory(string categoryName)
        {
            var key = JsonConvert.SerializeObject(Guid.NewGuid().ToString());
            var value = JsonConvert.SerializeObject(categoryName.ToLower());
            var isAdded = await database.Create("Category", key, value);
            return isAdded;
        }
        public async Task<List<string>> GetCategories()
        {
            List<string> categories = new List<string>();
            var data = await database.ReadAll("Category");
            foreach (var category in data)
            {
                if (!string.IsNullOrEmpty(category.Value))
                {
                    var cat = JsonConvert.DeserializeObject<string>(category.Value);
                    if (cat != null)
                    {
                        categories.Add(cat);
                    }
                }
            }
            return categories;
        }
        public async Task<bool> AddPaystackKey(Dictionary<string,string> keys)
        {
            bool isAdded = false;
            foreach (var item in keys)
            {
                string key = JsonConvert.SerializeObject(item.Key);
                string value = JsonConvert.SerializeObject(item.Value);
                isAdded = await database.Create("Paystack", key, value);
            }
            return isAdded;
        }
        public async Task<Dictionary<string, string>>  GetPaystackKeys()
        {
            Dictionary<string, string> keys = new Dictionary<string, string>(); 
            var data = await database.ReadAll("Paystack");
            if (data != null && data.Count() > 0)
            {
                foreach (var key in data)
                {
                    var k = JsonConvert.DeserializeObject<string>(key.Key) ?? "";
                    var v = JsonConvert.DeserializeObject<string>(key.Value) ?? "";
                    if (k != "" && v != "")
                    {
                        keys.Add(k, v);
                    }
                }
            }
            return keys;
        }
        public async Task<bool> AddProduct(Product product)
        {
            string key = JsonConvert.SerializeObject(product.Id);
            string value = JsonConvert.SerializeObject(product);
            bool isAdded = await database.Create("Products", key, value);
            return isAdded;
        }
        public async Task<Product> GetProduct(string id)
        {
            Product product = new Product();
            string key = JsonConvert.SerializeObject(id);
            var data = await database.Read("Products", key);
            if (!string.IsNullOrEmpty(data.Value))
            {
                var p = JsonConvert.DeserializeObject<Product>(data.Value);
                if (p != null)
                {
                    product = p;
                }
            }
            return product;
        }
        public async Task<List<Product>> GetProducts()
        {
            List<Product> products = new List<Product>();
            var data = await database.ReadAll("Products");
            if (data != null && data.Count() > 0)
            {
                foreach (var product in data)
                {
                    var p = JsonConvert.DeserializeObject<Product>(product.Value);
                    if (p != null)
                    {
                        products.Add(p);
                    }
                }
            }
            return products;
        }
        public async Task<bool> DeleteProduct(string id)
        {
            var key = JsonConvert.SerializeObject(id);
            var isDeleted = await database.Delete("Products", key);
            return isDeleted;
        }
    }
}
