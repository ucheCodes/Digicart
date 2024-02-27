using HKBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.States.SubStates
{
    public class OrderList
    {
        public IReadOnlyList<Orders> Data { get;}
        public OrderList(List<Orders> data)
        {
            Data = data;
        }
    }
}
