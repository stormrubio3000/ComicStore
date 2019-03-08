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
    public class CustomerController : Controller
    {

        public FrameworkRepo ComicDB { get; set; }


        public CustomerController(FrameworkRepo comicDB)
        {
            ComicDB = comicDB;
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customers = ComicDB.GetCustomers();
            var viewmodel = customers.Select(s => new CustomerModelView
            {
                Id = s.CustomerId,
                Name = s.Name,
                Email = s.Email,
                StoreId = s.StoreId
            });
            return View(viewmodel);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var customer = ComicDB.GetCustomer(id);
            var viewmodel = new CustomerModelView
            {
                Id = customer.CustomerId,
                Name = customer.Name,
                Email = customer.Email,
                StoreId = customer.StoreId
            };
            return View(viewmodel);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerModelView customer)
        {
            try
            {
                var cust = new ET.ComicStore.Library.Customer
                {
                    Name = customer.Name,
                    Email = customer.Email,
                    StoreId = customer.StoreId
                };

                ComicDB.AddCustomer(cust);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = ComicDB.GetCustomer(id);
            var viewmodel = new CustomerModelView
            {
                Id = customer.CustomerId,
                Name = customer.Name,
                Email = customer.Email,
                StoreId = customer.StoreId
            };
            return View(viewmodel);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerModelView customer)
        {
            try
            {
                var cust = new Customer
                {
                    CustomerId = id,
                    Name = customer.Name,
                    Email = customer.Email,
                    StoreId = customer.StoreId
                };
                ComicDB.UpdateCustomer(cust);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(customer);
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = ComicDB.GetCustomer(id);
            var viewmodel = new CustomerModelView
            {
                Id = customer.CustomerId,
                Name = customer.Name,
                Email = customer.Email,
                StoreId = customer.StoreId
            };
            return View(viewmodel);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                ComicDB.DeleteCustomer(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}