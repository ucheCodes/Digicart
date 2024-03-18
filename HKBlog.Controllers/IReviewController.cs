using HKBlog.Models;

namespace HKBlog.Controllers
{
    public interface IReviewController
    {
        Task<bool> Create(Review review);
        Task<bool> Delete(string id);
        Task<List<Review>> ReadAll();
    }
}