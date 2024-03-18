using HKBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.States.SubStates
{
    public class ProductUploadVal
    {
        public Product ProductVal { get; } = new Product();
        public ProductUploadVal(Product product) 
        { 
            ProductVal = product;
        }
    }
}
