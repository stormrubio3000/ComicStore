using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicStore.WebApp.ViewModel;
using ET.ComicStore.Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComicStore.WebApp.Controllers
{
	public class HistoryController : Controller
	{


		public FrameworkRepo ComicDB { get; set; }


		public HistoryController(FrameworkRepo comicDB)
		{
			ComicDB = comicDB;
		}



		// GET: History
		public ActionResult Index()
		{
			return View();
		}

		// GET: History/ShowStore
		public ActionResult ShowStore()
		{
			var viewmodel = new HistoryModelView
			{
				Stores = ComicDB.GetStores().ToList()
			};

			return View(viewmodel);
		}

		public ActionResult Store(int id)
		{
			var store = ComicDB.GetStore(id);
			var customers = ComicDB.GetCustomers();
			var orders = ComicDB.GetOrders();
			var products = ComicDB.GetOrderProducts();
			List<OrdersProduct> history = new List<OrdersProduct>();
			foreach (var customer in customers)
			{
				if (customer.StoreId == store.StoreId)
				{
					foreach (var order in orders)
					{
						if (customer.CustomerId == order.CustomerId)
						{
							foreach (var product in products)
							{
								if (product.OrdersId == order.OrdersId)
								{
									history.Add(product);
								}
							}
						}
					}
				}
			}

			var viewmodel = new HistoryModelView
			{
				Store = store,
				Products = history
			};

			return View(viewmodel);
		}


		public ActionResult ShowCustomer()
		{
			var viewmodel = new HistoryModelView
			{
				Customers = ComicDB.GetCustomers().ToList()
			};

			return View(viewmodel);
		}



		public ActionResult Customer(int id)
		{
			var customer = ComicDB.GetCustomer(id);
			var orders = ComicDB.GetOrders();
			var products = ComicDB.GetOrderProducts();
			List<OrdersProduct> history = new List<OrdersProduct>();
			foreach (var order in orders)
			{
				if (id == order.CustomerId)
				{
					foreach (var product in products)
					{
						if (product.OrdersId == order.OrdersId)
						{
							history.Add(product);
						}
					}
				}
			}



			var viewmodel = new HistoryModelView
			{
				Customer = customer,
				Products = history
			};

			return View(viewmodel);
		}


		public ActionResult ShowEarly()
		{
			var viewmodel = new HistoryModelView
			{
				Products = ComicDB.GetOrderProducts().OrderBy(x => x.Id).ToList()
			};

			return View(viewmodel);
		}


		public ActionResult ShowLate()
		{
			var viewmodel = new HistoryModelView
			{
				Products = ComicDB.GetOrderProducts().OrderByDescending(x => x.Id).ToList()
			};

			return View(viewmodel);
		}

		public ActionResult ShowCheap()
		{
			var viewmodel = new HistoryModelView
			{
				Products = ComicDB.GetOrderProducts().OrderBy(x => x.Price).ToList()
			};

			return View(viewmodel);
		}


		public ActionResult ShowExpensive()
		{
			var viewmodel = new HistoryModelView
			{
				Products = ComicDB.GetOrderProducts().OrderByDescending(x => x.Price).ToList()
			};

			return View(viewmodel);
		}


		public ActionResult ShowStats()
		{
			int count = ComicDB.GetCount();
			decimal total = ComicDB.GetTotal();
			int ocount = ComicDB.GetOrderss();
			var viewmodel = new HistoryModelView
			{
				CustomerCount = count/ ocount,
				TotalSales = total,
			};

			return View(viewmodel);
		}

	}
}