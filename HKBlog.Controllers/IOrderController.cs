using HKBlog.Models;

namespace HKBlog.Controllers
{
    public interface IOrderController
    {
        Task<bool> AddPaystackTransaction(PaystackTransaction pt);
        Task<List<PaystackTransaction>> GetAllPaystackTransaction();
        Task<bool> AddPendingOrder(Orders order);
        Task<List<Orders>> GetAllOrders();
        Task<Orders> GetOrder(string key);
        Task<PaystackTransaction> GetPaystackTransaction(string key);
        Task<bool> DeleteOrder(string id);
        Task<bool> AddNewOrderForEasyLifeUpdate(NewOrder order);
        Task<NewOrder> GetNewOrderForEasyLifeUpdate(string id);

        Task<List<NewOrder>> GetAllNewOrdersForEasyLifeUpdate();

	}
}