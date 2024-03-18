using HKBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.States.SubStates
{
    public class ProductReviews
    {
        public IReadOnlyList<Review> Data { get; }
        public ProductReviews(List<Review> reviews)
        {
            Data = reviews.AsReadOnly();
        }
    }
}
