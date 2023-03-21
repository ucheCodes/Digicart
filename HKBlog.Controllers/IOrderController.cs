using HKBlog.Models;

namespace HKBlog.Controllers
{
    public interface IOrderController
    {
        Task<bool> AddPaystackTransaction(PaystackTransaction pt);
        Task<bool> AddPendingOrder(Orders order);
        Task<IEnumerable<Orders>> GetAllOrders();
        Task<Orders> GetOrder(string key);
        Task<PaystackTransaction> GetPaystackTransaction(string key);
        Task<bool> DeleteOrder(string id);
    }
}