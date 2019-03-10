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
    public class ComicStoreController : Controller
    {
        
        public FrameworkRepo ComicDB { get; set; }

         
        public ComicStoreController(FrameworkRepo comicDB)
        {
            ComicDB = comicDB;
        }


        // GET: ComicStore
        public ActionResult Index()
        {
            var stores = ComicDB.GetStores();
            var viewmodel = stores.Select(s => new ComicStoreModelView
            {
                Id = s.StoreId,
                Location = s.Location
            });
            return View(viewmodel);
        }

        // GET: ComicStore/Details/5
        public ActionResult Details(int id)
        {
            var store = ComicDB.GetStore(id);
            var viewmodel = new ComicStoreModelView
            {
                Id = store.StoreId,
                Location = store.Location
            };
            return View(viewmodel);
        }

        // GET: ComicStore/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComicStore/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComicStoreModelView store)
        {
            try
            {
                var stor = new ET.ComicStore.Library.ComicStore
                {
                    Location = store.Location
                };

                ComicDB.AddStore(stor);

                int stores = ComicDB.GetStores().Last().StoreId;

                

                ComicDB.AddInventory(stores);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ComicStore/Edit/5
        public ActionResult Edit(int id)
        {

            var store = ComicDB.GetStore(id);
            var viewmodel = new ComicStoreModelView
            {
                Id = store.StoreId,
                Location = store.Location
            };
            return View(viewmodel);
        }

        // POST: ComicStore/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,  ComicStoreModelView store)
        {
            try
            {

                ComicDB.UpdateStore(id, store.Location);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(store);
            }
        }

        // GET: ComicStore/Delete/5
        public ActionResult Delete(int id)
        {
            var store = ComicDB.GetStore(id);
            var viewmodel = new ComicStoreModelView
            {
                Id = store.StoreId,
                Location = store.Location
            };
            return View(viewmodel);
        }

        // POST: ComicStore/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                ComicDB.DeleteStore(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}