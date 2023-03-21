using HKBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.States.SubStates
{
    public  class Cart
    {
        //public List<Product> Items { get;} = new();
        //public Cart(List<Product> items)
        //{
        //    Items = items;
        //}
        public IReadOnlyList<Product> Items { get; }
        public Cart(List<Product> items)
        {
            Items = items.AsReadOnly();
        }
    }
}
