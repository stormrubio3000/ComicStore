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

        


    }
}