﻿using System.Collections.Generic;
using System.Linq;
using PhamTaManhLan_Tuan3.Models;

namespace PhamTaManhLan_Tuan3.Repositories
{
	public class EFOrderRepository : IOrderRepository
	{
		private readonly ApplicationDbContext _context;

		public EFOrderRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Order> GetAllOrders()
		{
			return _context.Orders.ToList();
		}

		public Order GetOrderById(int id)
		{
			return _context.Orders.FirstOrDefault(o => o.Id == id);
		}

		public void AddOrder(Order order)
		{
			_context.Orders.Add(order);
			_context.SaveChanges();
		}

		public void UpdateOrder(Order order)
		{
			_context.Orders.Update(order);
			_context.SaveChanges();
		}

		public void DeleteOrder(int id)
		{
			var order = _context.Orders.Find(id);
			if (order != null)
			{
				_context.Orders.Remove(order);
				_context.SaveChanges();
			}
		}
	}
}
