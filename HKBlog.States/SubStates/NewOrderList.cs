using HKBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.States.SubStates
{
    public class NewOrderList
    {
        public IReadOnlyList<NewOrder> Data { get;}
        public NewOrderList(List<NewOrder> data)
        {
            Data = data;
        }
    }
}
