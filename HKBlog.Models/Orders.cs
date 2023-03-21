using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.Models
{
    public class Orders
    {
        public string Reference { get; set; } = "";
        public string AccessCode { get; set; } = "";
        public string AuthorizationUrl { get; set; } = "";  
        public string Mobile { get; set; } = "";
        public string Email { get; set; } = "";
        public List<Product> Products { get; set; } = new();
        public DateTime Date { get; set; }
        public bool IsValid { get; set; }
    }
}
