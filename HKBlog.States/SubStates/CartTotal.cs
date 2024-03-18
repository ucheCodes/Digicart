using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.States.SubStates
{
    public class CartTotal
    {
        public double Total { get; }
        public CartTotal(double total)
        {
            Total = total;
        }
    }
}
