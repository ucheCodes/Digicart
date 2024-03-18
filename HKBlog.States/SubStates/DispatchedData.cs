using HKBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.States.SubStates
{
    public class DispatchedData
    {
        public IReadOnlyList<DispatchProduct> Products { get; }
        public DispatchedData(List<DispatchProduct> items)
        {
            Products = items.AsReadOnly();
        }
    }
}
