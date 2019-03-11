using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ET.ComicStore.Library
{
	/*
     * ToDo: Add to cart error
     */
	public class FrameworkRepo
	{

		private readonly Project0Context _db;

		public FrameworkRepo(Project0Context db)
		{
			_db = db;
		}


		public IEnumerable<ComicStore> GetStores()
		{
			return _db.ComicStore.OrderBy(x => x.StoreId).ToList();
		}



		public ComicStore GetStore(int id)
		{
			return _db.ComicStore.First(x => x.StoreId == id);
		}




		public void AddStore(ComicStore store)
		{
			var tri = _db.ComicStore.FirstOrDefault(x => x.Location == store.Location);
			if (tri == null)
			{
				_db.Add(store);
				_db.SaveChanges();
			}
			else
			{
				throw new ArgumentException("A store of that name already exists.");
			}

		}




		public void DeleteStore(int id)
		{
			var ComicStore = _db.ComicStore.FirstOrDefault(x => x.StoreId == id);
			if (ComicStore == null)
			{
				throw new ArgumentException("Store of that name not Found.");
			}
			try
			{
				_db.Remove(ComicStore);
				_db.SaveChanges();
			}
			catch (Exception)
			{
				Console.WriteLine("Cannot delete this store it has database dependencies.");
			}

		}



		public void UpdateStore(int id, string store)
		{

			var ComicStore = _db.ComicStore.First(x => x.StoreId == id);
			ComicStore.Location = store;
			_db.SaveChanges();
		}


		public IEnumerable<Customer> GetCustomers()
		{
			return _db.Customer.OrderBy(x => x.CustomerId).ToList();
		}


		public Customer GetCustomer(int id)
		{
			return _db.Customer.First(x => x.CustomerId == id);
		}


		public void AddCustomer(Customer customer)
		{
			var tri = _db.Customer.FirstOrDefault(x => x.Name == customer.Name);
			if (tri == null)
			{
				_db.Add(customer);
				_db.SaveChanges();
			}
			else
			{
				throw new ArgumentException("A store of that name already exists.");
			}
		}

		public void UpdateCustomer(Customer customer)
		{
			var cust = _db.Customer.First(x => x.CustomerId == customer.CustomerId);
			cust.Name = customer.Name;
			cust.Email = customer.Email;
			cust.StoreId = customer.StoreId;
			_db.SaveChanges();
		}


		public void DeleteCustomer(int id)
		{
			var cust = _db.Customer.First(x => x.CustomerId == id);
			_db.Remove(cust);
			_db.SaveChanges();
		}

		public IEnumerable<Inventory> GetInventory()
		{
			return _db.Inventory.OrderBy(x => x.InventoryId).ToList();
		}


		public void AddInventory(int storeid)
		{
			var inv = new Inventory { StoreId = storeid };
			_db.Add(inv);
			_db.SaveChanges();
		}


		public IEnumerable<StoreProduct> GetStoreProducts()
		{
			return _db.StoreProduct.OrderBy(x => x.Id).ToList();
		}



		public StoreProduct GetStoreProduct(int id)
		{
			return _db.StoreProduct.First(x => x.Id == id);
		}


		public void AddStoreProduct(StoreProduct product)
		{

			_db.Add(product);
			_db.SaveChanges();
		}


		public void UpdateStoreProduct(StoreProduct product)
		{
			var pro = _db.StoreProduct.First(x => x.Id == product.Id);
			pro.Name = product.Name;
			pro.Price = product.Price;
			pro.InventorySize = product.InventorySize;
			pro.InventoryId = product.InventoryId;
			_db.SaveChanges();
		}




		public void DeleteStoreProduct(int id)
		{
			var pro = _db.StoreProduct.First(x => x.Id == id);
			_db.Remove(pro);
			_db.SaveChanges();

		}


		public IEnumerable<Orders> GetOrders()
		{
			return _db.Orders.OrderBy(x => x.OrdersId).ToList();
		}

		public IEnumerable<OrdersProduct> GetOrderProducts()
		{
			return _db.OrdersProduct.OrderBy(x => x.Id).ToList();
		}


		public int GetCount()
		{
			return _db.Customer.Count();
		}

		public decimal GetTotal()
		{
			decimal total = 0;
			foreach ( var item in _db.OrdersProduct)
			{
				total = total + item.Price * item.InventorySize;
			}
			return total;
		}

		public int GetOrderss()
		{
			return _db.Orders.Count();
		}


		public void AddOrder()
		{
			var order = new Orders { CustomerId = 1 };
			_db.Add(order);
			_db.SaveChanges();
		}

		public void UpdateOrder(Orders id)
		{
			var order = _db.Orders.First(x => x.OrdersId == id.OrdersId);
			order.CustomerId = id.CustomerId;
			_db.SaveChanges();
		}


		public void AddOrderProduct(OrdersProduct product)
		{
			_db.Add(product);
			_db.SaveChanges();
		}

		public void RemoveOrderProduct(OrdersProduct product)
		{
			_db.Remove(product);
			_db.SaveChanges();
		}

		public IEnumerable<OrdersProduct> GetCart(int id)
		{
			return _db.OrdersProduct.Where(y  => y.OrdersId == id).OrderBy(x => x.Id).ToList();
		}

		public void ProuductAdded(StoreProduct product)
		{
			var pro = _db.StoreProduct.First(x => x.Id == product.Id);
			pro.InventorySize = pro.InventorySize - 1;
			_db.SaveChanges();
		}
	}
}
