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
    public class CartController : Controller
    {
		public FrameworkRepo ComicDB { get; set; }


		public CartController(FrameworkRepo comicDB)
		{
			ComicDB = comicDB;
		}


		// GET: Cart
		public ActionResult Index()
        {
			var cart = ComicDB.GetCart(ComicDB.GetOrders().Last().OrdersId).ToList();

			var viewmodel = new CartModelView { Cart = cart };
            return View(viewmodel);
        }


        // GET: Cart/Create
        public ActionResult Create()
        {
			var products = ComicDB.GetStoreProducts().ToList();

			var viewmodel = new CartModelView { Products = products };

			return View(viewmodel);
        }

        // POST: Cart/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CartModelView collection)
        {
            try
            {
				var product = new OrdersProduct
				{
					Name = collection.Product.Name,
					Price = collection.Product.Price,
					InventorySize = 1,
					OrdersId = ComicDB.GetOrderss()
				};

				ComicDB.ProuductAdded(collection.Product);
				ComicDB.AddOrderProduct(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cart/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cart/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


		public ActionResult Place()
		{
			
			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Place(IFormCollection collection)
		{
			ComicDB.AddOrder();
			return RedirectToAction(nameof(Index));
		}

	}
}