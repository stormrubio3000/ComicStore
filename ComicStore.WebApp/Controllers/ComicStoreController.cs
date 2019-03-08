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
            return View();
        }

        // GET: ComicStore/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComicStore/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

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
            return View();
        }

        // POST: ComicStore/Edit/5
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

        // GET: ComicStore/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComicStore/Delete/5
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
    }
}