using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.Models
{
    public class PaystackData
    {
        //public string ref { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public double  amount { get; set; }
        public string key { get; set; } = string.Empty; 
    }
}
