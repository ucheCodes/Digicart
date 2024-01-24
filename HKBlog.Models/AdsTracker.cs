using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.Models
{
    public class AdsTracker
    {
        public string Id { get; set; } = "";
        public string AdsUrl { get; set; } = "";
        public User User { get; set; } = new();
        public DateTime Date { get; set; }
    }
}
