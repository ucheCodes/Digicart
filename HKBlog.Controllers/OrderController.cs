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
    public class OrderController : IOrderController
    {
        private readonly IDatabase database;
        public OrderController(IDatabase database)
        {
            this.database = database;
        }
		public async Task<bool> AddNewOrderForEasyLifeUpdate(NewOrder order)
		{
			string key = JsonConvert.SerializeObject(order.Id);
			string value = JsonConvert.SerializeObject(order);
			var isAdded = await database.Create("NewOrder", key, value);
			return isAdded;
		}
		public async Task<List<NewOrder>> GetAllNewOrdersForEasyLifeUpdate()
		{
			var orders = await database.ReadAll("NewOrder");
			var data = new List<NewOrder>();
			if (orders != null && orders.Count() > 0)
			{
				foreach (var order in orders)
				{
					var ord = JsonConvert.DeserializeObject<NewOrder>(order.Value);
					if (ord != null)
					{
						data.Add(ord);
					}
				}
			}
			return data;
		}
		public async Task<bool> AddPendingOrder(Orders order)
        {
            string key = JsonConvert.SerializeObject(order.Reference);
            string value = JsonConvert.SerializeObject(order);
            var isAdded = await database.Create("Orders", key, value);
            return isAdded;
        }
        public async Task<bool> DeleteOrder(string id)
        {
            string key = JsonConvert.SerializeObject(id);
            var isDel = await database.Delete("Orders", key);
            return isDel;
        }
        public async Task<bool> AddPaystackTransaction(PaystackTransaction pt)
        {
            string key = JsonConvert.SerializeObject(pt.Reference);
            string value = JsonConvert.SerializeObject(pt);
            var isAdded = await database.Create("PaystackTransaction", key, value);
            return isAdded;
        }
        public async Task<PaystackTransaction> GetPaystackTransaction(string key)
        {
            var id = JsonConvert.SerializeObject(key);
            PaystackTransaction pt = new();
            var data = await database.Read("PaystackTransaction", id);
            if (!string.IsNullOrEmpty(data.Value))
            {
                var _pt = JsonConvert.DeserializeObject<PaystackTransaction>(data.Value);
                if (_pt != null)
                {
                    pt = _pt;
                }
            }
            return pt;

        }
        public async Task<Orders> GetOrder(string key)
        {
            var id = JsonConvert.SerializeObject(key);
            Orders order = new Orders();
            var data = await database.Read("Orders", id);
            if (!string.IsNullOrEmpty(data.Value))
            {
                var _order = JsonConvert.DeserializeObject<Orders>(data.Value);
                if (_order != null)
                {
                    order = _order;
                }
            }
            return order;
        }
        public async Task<List<Orders>> GetAllOrders()
        {
            var orders = await database.ReadAll("Orders");
            var data = new List<Orders>();
            if (orders != null && orders.Count() > 0)
            {
                foreach (var order in orders)
                {
                    var ord = JsonConvert.DeserializeObject<Orders>(order.Value);
                    if (ord != null)
                    {
                        data.Add(ord);
                    }
                }
            }
            return data;
        }
        public async Task<List<PaystackTransaction>> GetAllPaystackTransaction()
        {
            var pt = await database.ReadAll("PaystackTransaction");
            var data = new List<PaystackTransaction>();
            if (pt != null && pt.Count() > 0)
            {
                foreach (var p in pt)
                {
                    var pts = JsonConvert.DeserializeObject<PaystackTransaction>(p.Value);
                    if (pts != null)
                    {
                        data.Add(pts);
                    }
                }
            }
            return data;
        }

    }
}
