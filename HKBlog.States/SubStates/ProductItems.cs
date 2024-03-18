using HKBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.States.SubStates
{
    public class ProductItems
    {
        public IReadOnlyList<Product> Products { get;}
        public ProductItems(List<Product> products)
        {
            Products = products.AsReadOnly();
        }
    }
}
