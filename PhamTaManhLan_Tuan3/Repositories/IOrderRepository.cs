using System.Collections.Generic;
using PhamTaManhLan_Tuan3.Models;

namespace PhamTaManhLan_Tuan3.Repositories
{
	public interface IOrderRepository
	{
		IEnumerable<Order> GetAllOrders();
		Order GetOrderById(int id);
		void AddOrder(Order order);
		void UpdateOrder(Order order);
		void DeleteOrder(int id);
	}
}
