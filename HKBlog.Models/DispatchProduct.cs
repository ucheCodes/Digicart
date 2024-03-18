using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.Models
{
    public class DispatchProduct
    {
        public string Id { get; set; } = "";
        public Product Product { get; set; } = new();
        public int Quantity { get; set; }
        public string VendorId { get; set; } = "";
        public string AdminId { get; set; } = "";
        public DateTime Date { get; set; }
        public OrderStatus DispatchStatus { get; set; } = OrderStatus.Pending;
    }
}
