using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.Models
{
    public class Product
    {
        public string Id { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Category { get; set; } = string.Empty;
        public string Filepath { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        [Required]
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool IsProductInStock { get; set; } = true;
    }
}
