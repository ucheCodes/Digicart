using HKBlog.Database;
using HKBlog.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.Controllers
{
    public class ReviewController : IReviewController
    {
        private readonly IDatabase database;
        public ReviewController(IDatabase database)
        {
            this.database = database;
        }
        public async Task<bool> Create(Review review)
        {
            var key = JsonConvert.SerializeObject(review.Id);
            var value = JsonConvert.SerializeObject(review);
            var isAdded = await database.Create("Review", key, value);
            return isAdded;
        }
        public async Task<List<Review>> ReadAll()
        {
            List<Review> reviews = new List<Review>();
            var data = await database.ReadAll("Review");
            foreach (var r in data)
            {
                if (!string.IsNullOrEmpty(r.Value))
                {
                    var review = JsonConvert.DeserializeObject<Review>(r.Value);
                    if (review != null)
                    {
                        reviews.Add(review);
                    }
                }
            }
            return reviews;
        }
        public async Task<bool> Delete(string id)
        {
            var key = JsonConvert.SerializeObject(id);
            var isDeleted = await database.Delete("Review", key);
            return isDeleted;
        }
    }
}
