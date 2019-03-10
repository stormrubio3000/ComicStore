using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ET.ComicStore.Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ComicStore.WebApp.ViewModel;

namespace ComicStore.WebApp.Controllers
{
    public class StoreProductsController : Controller
    {


        public FrameworkRepo ComicDB { get; set; }


        public StoreProductsController(FrameworkRepo comicDB)
        {
            ComicDB = comicDB;
        }


        // GET: StoreProducts
        public ActionResult Index()
        {
            var stores = ComicDB.GetStores().OrderBy(x => x.Location);
            var Inventory = ComicDB.GetInventory();
            var Products = ComicDB.GetStoreProducts();

            var viewmodel = Products.Select(s => new StoreProductModelView
            {
                Id = s.Id,
                Name = s.Name,
                Price = s.Price,
                Inventorysize = s.InventorySize,
                Inv = Inventory.First(x => x.InventoryId == s.InventoryId),
                Store = stores.First(x => x.StoreId == s.InventoryId)
            });


            return View(viewmodel);
        }

        // GET: StoreProducts/Details/5
        public ActionResult Details(int id)
        {
            var stores = ComicDB.GetStores();
            var Inventory = ComicDB.GetInventory();
            var Products = ComicDB.GetStoreProduct(id);

            var viewmodel =  new StoreProductModelView
            {
                Id = Products.Id,
                Name = Products.Name,
                Price = Products.Price,
                Inventorysize = Products.InventorySize,
                Store = stores.First(x => x.StoreId == Products.InventoryId)
            };
            return View(viewmodel);
        }

        // GET: StoreProducts/Create
        public ActionResult Create()
        {
            var stores = ComicDB.GetStores();
            var viewmodel = new StoreProductModelView
            {
                Stores = stores.ToList()
            };
            return View(viewmodel);
        }

        // POST: StoreProducts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StoreProductModelView collection)
        {
            try
            {
                var stores = ComicDB.GetStores();
                var Inventory = ComicDB.GetInventory();


                int storeid = collection.Store.StoreId;


                int InvId = ComicDB.GetInventory().First(x => x.StoreId == storeid).InventoryId;
                var Product = new StoreProduct
                {
                    Name = collection.Name,
                    Price = collection.Price,
                    InventorySize = collection.Inventorysize,
                    InventoryId = InvId
                };

                ComicDB.AddStoreProduct(Product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreProducts/Edit/5
        public ActionResult Edit(int id)
        {
            var stores = ComicDB.GetStores();
            var Inventory = ComicDB.GetInventory();
            var Products = ComicDB.GetStoreProduct(id);

            var viewmodel = new StoreProductModelView
            {
                Id = Products.Id,
                Name = Products.Name,
                Price = Products.Price,
                Inventorysize = Products.InventorySize,
                Store = stores.First(x => x.StoreId == Products.InventoryId),
                Stores = stores.ToList()
            };
            return View(viewmodel);
        }

        // POST: StoreProducts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StoreProductModelView collection)
        {
            try
            {
                var stores = ComicDB.GetStores();
                var Inventory = ComicDB.GetInventory();


                int storeid = collection.Store.StoreId;


                int InvId = ComicDB.GetInventory().First(x => x.StoreId == storeid).InventoryId;
                var Product = new StoreProduct
                {
                    Id = collection.Id,
                    Name = collection.Name,
                    Price = collection.Price,
                    InventorySize = collection.Inventorysize,
                    InventoryId = InvId
                };

                ComicDB.UpdateStoreProduct(Product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var stores = ComicDB.GetStores();
                var Inventory = ComicDB.GetInventory();
                var Products = ComicDB.GetStoreProduct(id);

                var viewmodel = new StoreProductModelView
                {
                    Id = Products.Id,
                    Name = Products.Name,
                    Price = Products.Price,
                    Inventorysize = Products.InventorySize,
                    Store = stores.First(x => x.StoreId == Products.InventoryId),
                    Stores = stores.ToList()
                };
                return View(viewmodel);
            }
        }

        // GET: StoreProducts/Delete/5
        public ActionResult Delete(int id)
        {
            var stores = ComicDB.GetStores();
            var Inventory = ComicDB.GetInventory();
            var Products = ComicDB.GetStoreProduct(id);

            var viewmodel = new StoreProductModelView
            {
                Id = Products.Id,
                Name = Products.Name,
                Price = Products.Price,
                Inventorysize = Products.InventorySize,
                Store = stores.First(x => x.StoreId == Products.InventoryId)
            };
            return View(viewmodel);
        }

        // POST: StoreProducts/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {

                ComicDB.DeleteStoreProduct(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}