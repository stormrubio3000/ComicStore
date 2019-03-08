using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ET.ComicStore.Library
{
    /*
     * ToDo: Add Crud For Customer
     * ToDo: Add Crud for OrderProducts
     * ToDo: Add Crud for StoreProducts
     * ToDo: Add model state checks
     * ToDo: Make it pretty
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

        /*

        public void ShowProducts(Project0Context dbContext, string name = null)
        {
            if (name == null)
            {
                var stores = dbContext.ComicStore.Include(inventory => inventory.Inventory).ThenInclude(products => products.StoreProduct).ToList();
                foreach (var store in stores)
                {
                    Console.WriteLine(store.Location + "  -");
                    foreach (var inv in store.Inventory)
                    {
                        if (inv.StoreId == store.StoreId)
                        {
                            foreach (var product in inv.StoreProduct)
                            {
                                if (product.InventoryId == inv.InventoryId)
                                {
                                    Console.WriteLine("    " + product.Name + "  -  " + product.Price + "  Left in stock: " + product.InventorySize);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                var store = dbContext.StoreProduct.FirstOrDefault(x => x.Name == name);
                if (store == null)
                {
                    Console.WriteLine("No comic of that name found. ");
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine(store.Name + "  -  " + store.Price + "  Left in stock: " + store.InventorySize);
            }
        }


        public void AddProduct(Project0Context dbContext, string name, decimal price, int size, int store)//
        {
            var stores = dbContext.ComicStore.Include(x => x.Inventory).ThenInclude(y => y.StoreProduct);
            var ComicStore = new ET.ComicStore.Library.StoreProduct();
            ComicStore.Name = name;
            ComicStore.InventorySize = size;
            ComicStore.Price = price;
            ComicStore.InventoryId = store;
            dbContext.Add(ComicStore);
            dbContext.SaveChanges();
        }



        public void DeleteProduct(Project0Context dbContext, string name)//
        {
            var ComicStore = dbContext.StoreProduct.FirstOrDefault(x => x.Name == name);
            if (ComicStore == null)
            {
                Console.WriteLine("No Comic of that name found. ");
                Console.ReadKey();
                return;
            }
            dbContext.Remove(ComicStore);
            dbContext.SaveChanges();
        }


        public void UpdateProduct(Project0Context dbContext, string name, decimal price, int size, int store, string old)//
        {
            var stores = dbContext.ComicStore.Include(x => x.Inventory).ThenInclude(y => y.StoreProduct);
            var oldstore = dbContext.StoreProduct.FirstOrDefault(x => x.Name == old);
            if (oldstore == null)
            {
                Console.WriteLine("No Comic of that name found. ");
                Console.ReadKey();
                return;
            }
            var ComicStore = new ET.ComicStore.Library.StoreProduct();
            ComicStore.Name = name;
            ComicStore.InventorySize = size;
            ComicStore.Price = price;
            ComicStore.InventoryId = store;
            dbContext.Remove(oldstore);
            dbContext.Add(ComicStore);
            dbContext.SaveChanges();
        }




        public void ShowCustomers(Project0Context dbContext, string name = null)
        {
            if (name == null)
            {
                foreach (var store in dbContext.Customer)
                {
                    Console.WriteLine(store.Name + "  -  " + store.Email + "  Store Location " + store.Location);
                }
            }
            else
            {
                var store = dbContext.Customer.FirstOrDefault(x => x.Name == name || x.Email == name);
                if (store == null)
                {
                    Console.WriteLine("No customer was found. ");
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine(store.Name + "  -  " + store.Email + "  Store Location " + store.Location);
            }
        }



        public void AddCustomer(Project0Context dbContext, string name, string email, string storeid)
        {
            var ComicStore = new ET.ComicStore.Library.Customer();
            ComicStore.Name = name;
            ComicStore.Email = email;
            var tri = dbContext.ComicStore.FirstOrDefault(x => x.Location == storeid);
            if (tri == null)
            {
                Console.WriteLine("This is no store on record with that name. ");
                Console.ReadKey();
                return;
            }
            else
            {
                ComicStore.Location = storeid;
                dbContext.Add(ComicStore);
                dbContext.SaveChanges();
            }
        }

        public void DeleteCustomer(Project0Context dbContext, string name, string email)
        {
            var ComicStore = dbContext.Customer.FirstOrDefault(x => x.Name == name && x.Email == email);
            if (ComicStore == null)
            {
                Console.WriteLine("No customer of that name found. ");
                Console.ReadKey();
                return;
            }
            dbContext.Remove(ComicStore);
            dbContext.SaveChanges();
        }



        public void UpdateCustomer(Project0Context dbContext, string name, string email, string oldn, string olde)
        {
            var oldstore = dbContext.Customer.FirstOrDefault(x => x.Name == oldn && x.Email == olde);
            if (oldstore == null)
            {
                Console.WriteLine("No customer of that name found. ");
                Console.ReadKey();
                return;
            }
            var ComicStore = new ET.ComicStore.Library.Customer();
            ComicStore.Name = name;
            ComicStore.Email = email;
            ComicStore.Location = oldstore.Location;
            dbContext.Remove(oldstore);
            dbContext.Add(ComicStore);
            dbContext.SaveChanges();
        }


        public void ShowCart(Project0Context dbContext, string name, int cartid)
        {
            var stores = dbContext.Customer.Include(order => order.Orders).ThenInclude(orderp => orderp.OrdersProduct).ToList();
            foreach (var customer in stores)
            {
                if (customer.Name == name)
                {
                    foreach (var order in customer.Orders)
                    {

                        if (order.OrdersId >= cartid)
                        {
                            foreach (var history in order.OrdersProduct)
                            {
                                Console.WriteLine("Items in cart: ");
                                Console.WriteLine(history.Name + "     " + history.InventorySize);
                            }
                        }
                    }
                }
            }
        }

        public void ShowHistory(Project0Context dbContext, string name, string option)
        {
            var stores = dbContext.Customer.Include(order => order.Orders).ThenInclude(orderp => orderp.OrdersProduct).ToList();
            if (option == "1")
            {
                foreach (var customer in stores)
                {
                        foreach (var order in customer.Orders)
                        {
                            foreach (var history in order.OrdersProduct)
                            {
                                Console.WriteLine(history.Name + "     " + history.InventorySize + "    At " + customer.Location);
                            }
                        }
                }
            }
            else if (option == "2")
            {
                foreach (var customer in stores)
                {
                        foreach (var order in customer.Orders)
                        {
                            foreach (var history in order.OrdersProduct.Reverse())
                            {
                                Console.WriteLine(history.Name + "     " + history.InventorySize + "    At " + customer.Location);
                            }
                        }
                }
            }
            else if (option == "3")
            {
                foreach (var customer in stores)
                {
                        foreach (var order in customer.Orders)
                        {
                            foreach (var history in order.OrdersProduct.OrderBy(p => p.Price))
                            {
                                Console.WriteLine(history.Name + "     " + history.InventorySize + "    At " + customer.Location);
                            }
                        }
                }
            }
            else if (option == "4")
            {
                foreach (var customer in stores)
                {
                        foreach (var order in customer.Orders)
                        {
                            foreach (var history in order.OrdersProduct.OrderBy(p => p.Price).Reverse())
                            {
                                Console.WriteLine(history.Name + "     " + history.InventorySize + "    At " + customer.Location);
                            }
                        }
                }
            }
        }


        public void ShowStatistics(Project0Context dbContext)
        {
            decimal totalsales = 0;
            int customerss = 0;
            var customers = dbContext.Customer.Include(orders => orders.Orders).ThenInclude(products => products.OrdersProduct).ToList();
            foreach (var customer in customers)
            {
                customerss++;
                foreach (var order in customer.Orders)
                {
                    foreach (var product in order.OrdersProduct)
                    {
                        totalsales = totalsales + product.Price;
                    }
                }
            }


            
            Console.WriteLine("The total sales amount for this quarter is: " + totalsales);
            Console.WriteLine("The average amount of sales product per customer was: " + Decimal.Divide(totalsales,(decimal)customerss));
        }




        public void AddCart(Project0Context dbContext, string name, int size, int ID)
        {
            var SProduct = dbContext.StoreProduct.Where(x => x.Name == name).FirstOrDefault();
            if (SProduct == null)
            {
                Console.WriteLine("Sorry that isn't a current product name. ");
                Console.ReadKey();
                return;
            }
            if (SProduct.InventorySize - size > 0)
            {
                SProduct.InventorySize = SProduct.InventorySize - size;
                var OProduct = new OrdersProduct();
                OProduct.Name = SProduct.Name;
                OProduct.Price = SProduct.Price;
                OProduct.InventorySize = size;
                OProduct.OrdersId = ID;
                dbContext.Add(OProduct);
                dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Sorry there are not enough products to fulfill your request at this time. ");
                throw new ArgumentException();
            }
        }


        public void AddSet(Project0Context dbContext, string name, int size, int ID)
        {
            var SProduct = dbContext.StoreProduct.Where(x => x.Name == name).FirstOrDefault();
            while (SProduct != null)
            {
                if (SProduct == null)
                {
                    Console.WriteLine("Sorry that isn't a current product name. ");
                    Console.ReadKey();
                    return;
                }
                if (SProduct.InventorySize - size > 0)
                {
                    SProduct.InventorySize = SProduct.InventorySize - size;
                    var OProduct = new OrdersProduct();
                    OProduct.Name = SProduct.Name;
                    OProduct.Price = SProduct.Price;
                    OProduct.InventorySize = size;
                    OProduct.OrdersId = ID;
                    dbContext.Add(OProduct);
                    dbContext.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Sorry there are not enough products to fulfill your request at this time. ");
                }
                SProduct = dbContext.StoreProduct.Where(x => x.InventoryId == SProduct.SetId).FirstOrDefault();
            }
        }




        public void DeleteCart(Project0Context dbContext, string name, int size, int ID)
        {
            var product = dbContext.OrdersProduct.Where(x => x.Name == name && x.OrdersId >= ID).FirstOrDefault();
            if (product == null)
            {
                Console.WriteLine("No Product in the cart of that name found. ");
                Console.ReadKey();
                return;
            }
            else if (product.InventorySize - size == 0)
            {
                dbContext.Remove(product);
            }
            else if (product.InventorySize - size > 0)
            {
                product.InventorySize = product.InventorySize - size;
            }
            else
            {
                Console.WriteLine("Trying to remove to many items. ");
                Console.ReadKey();
                return;
            }

            dbContext.SaveChanges();
        }




        public void CheckOut(Project0Context dbContext, string name, int cartid, out decimal total)
        {
            var stores = dbContext.Customer.Include(order => order.Orders).ThenInclude(orderp => orderp.OrdersProduct).ToList();
            decimal totals = 0;
            foreach (var customer in stores)
            {
                if (customer.Name == name)
                {
                    foreach (var order in customer.Orders)
                    {
                        if (order.OrdersId == cartid)
                        {
                            foreach (var history in order.OrdersProduct)
                            {
                                totals += history.Price * history.InventorySize;
                                Console.WriteLine(history.Name + "     " + history.InventorySize);
                            }
                        }
                    }
                }
            }
            total = totals;
        }


        public bool CheckCartTime(Project0Context dbContext, string cust, int orderid, DateTime curr_order)
        {
            var customer = dbContext.Customer.Include(order => order.Orders).ThenInclude(orderp => orderp.OrdersProduct).ToList();
            foreach (var customers in customer)
            {
                if (customers.Name == cust)
                {
                    foreach (var inv in customers.Orders)
                    {
                        if (inv.CustomerId == customers.CustomerId && inv.OrdersId < orderid)
                        {
                            DateTime check = (DateTime)inv.OrderTime;
                            if (check.AddHours(2.00) <= curr_order)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        */
    }
}
