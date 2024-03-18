using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.Models
{
    public class Review
    {
        public string Id { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public int StarRating { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; } = new();
    }
}
