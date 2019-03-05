using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ET.ComicStore.Library
{
    public class FrameworkRepo : IFrameworkRepo
    {

        private readonly Project0Context _db;


        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Edit a store Location. ");
            Console.WriteLine("2. Show a store Location. ");
            Console.WriteLine("3. Edit a Product. ");
            Console.WriteLine("4. Show a Product. ");
            Console.WriteLine("5. Edit a Customer. ");
            Console.WriteLine("6. Show Customer Info. ");
            Console.WriteLine("7. Edit Cart. ");
            Console.WriteLine("8. Show Cart. ");
            Console.WriteLine("9. Show Order History. ");
            Console.WriteLine("0. Quit. ");
        }


        public void ShowStores(Project0Context dbContext, string name = null)
        {
            var stores = dbContext.ComicStore.Include(customer => customer.Customer).ThenInclude(order => order.Orders).ThenInclude(orderp => orderp.OrdersProduct).ToList();
            if (name == null)
            {
                foreach (var store in dbContext.ComicStore)
                {
                    Console.WriteLine("Store Id: " + store.StoreId + "  Location: " + store.Location);
                }
            }
            else
            {
                var store = dbContext.ComicStore.FirstOrDefault(x => x.Location == name);
                if (store == null)
                {
                    Console.WriteLine("No store of that name found. ");
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine("Store Id: " + store.StoreId + "  Location: " + store.Location);
                foreach (var comicstores in stores)
                {
                    if (comicstores.Location == name)
                    {
                        foreach (var customer in comicstores.Customer)
                        {
                            if (customer.Location == name)
                            {
                                foreach (var order in customer.Orders)
                                {
                                    foreach (var item in order.OrdersProduct)
                                    {
                                        Console.WriteLine(item.Name + "  -  " + item.Price + "    Order id: " + item.OrdersId + "   at: " + order.OrderTime);
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }



        public void AddStore(Project0Context dbContext, string name)
        {
            var ComicStore = new ET.ComicStore.Library.ComicStore();
            ComicStore.Location = name;
            var tri = dbContext.ComicStore.FirstOrDefault(x => x.Location == name);
            if (tri == null)
            {
                dbContext.Add(ComicStore);
                dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("A store with that name already exists. ");
                Console.ReadKey();
            }

        }




        public void DeleteStore(Project0Context dbContext, string name)
        {
            var ComicStore = dbContext.ComicStore.FirstOrDefault(x => x.Location == name);
            if (ComicStore == null)
            {
                Console.WriteLine("No store of that name found. ");
                Console.ReadKey();
                return;
            }
            try
            {
                dbContext.Remove(ComicStore);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot delete this store it has database dependencies.");
            }

        }



        public void UpdateStore(Project0Context dbContext, string name, string ne)
        {
            var ComicStore = dbContext.ComicStore.FirstOrDefault(x => x.Location == name);
            if (ComicStore == null)
            {
                Console.WriteLine("No store of that name found. ");
                Console.ReadKey();
                return;
            }
            dbContext.Remove(ComicStore);
            var ComicStore2 = new ET.ComicStore.Library.ComicStore();
            ComicStore2.Location = ne;
            dbContext.Add(ComicStore2);
            dbContext.SaveChanges();
        }



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
                    if (customer.Name == name)
                    {
                        foreach (var order in customer.Orders)
                        {
                            foreach (var history in order.OrdersProduct)
                            {
                                Console.WriteLine(history.Name + "     " + history.InventorySize);
                            }
                        }
                    }
                }
            }
            else if (option == "2")
            {
                foreach (var customer in stores)
                {
                    if (customer.Name == name)
                    {
                        foreach (var order in customer.Orders)
                        {
                            foreach (var history in order.OrdersProduct.Reverse())
                            {
                                Console.WriteLine(history.Name + "     " + history.InventorySize);
                            }
                        }
                    }
                }
            }
            else if (option == "3")
            {
                foreach (var customer in stores)
                {
                    if (customer.Name == name)
                    {
                        foreach (var order in customer.Orders)
                        {
                            foreach (var history in order.OrdersProduct.OrderBy(p => p.Price))
                            {
                                Console.WriteLine(history.Name + "     " + history.InventorySize);
                            }
                        }
                    }
                }
            }
            else if (option == "4")
            {
                foreach (var customer in stores)
                {
                    if (customer.Name == name)
                    {
                        foreach (var order in customer.Orders)
                        {
                            foreach (var history in order.OrdersProduct.OrderBy(p => p.Price).Reverse())
                            {
                                Console.WriteLine(history.Name + "     " + history.InventorySize);
                            }
                        }
                    }
                }
            }
        }


        public void ShowStatistics(Project0Context dbContext)//working
        {

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
            var product = dbContext.OrdersProduct.Where(x => x.Name == name).FirstOrDefault();
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
                        Console.WriteLine("Items in cart: ");
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
                        if (inv.CustomerId == customers.CustomerId && inv.OrdersId <= orderid)
                        {
                            DateTime check = (DateTime)inv.OrderTime;
                            if (check.AddHours(2.00) >= curr_order)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

    }
}
