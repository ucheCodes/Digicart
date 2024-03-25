using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.Models
{
    public class NewOrder
    {
        public string Id { get; set; } = "";
        public string UserId { get; set; } = "";
        public string PaymentId { get; set; } = "";
        public List<Product> Products { get; set; } = new();
        public OrderStatus Status { get; set; }
        public DateTime Date { get; set; }
        public string PaymentChannel { get; set; } = "";
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.None;
        public double Price { get; set; }
        public bool IsViewed { get; set; } = false;
        public string  ApprovedBy { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
    public enum PaymentStatus
    {
        None,Paid,Not_Paid
    }
    public enum OrderStatus
    {
        Pending, 
        Approved,
        Cancelled
    }
}
