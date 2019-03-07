using System;
using System.Collections.Generic;
using System.Linq;
using ET.ComicStore.Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;


namespace ComicStore
{
    static class Program
    {

        public static readonly LoggerFactory AppLoggerFactory =
        #pragma warning disable CS0618 // Type or member is obsolete
        new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });
        #pragma warning restore CS0618 // Type or member is obsolete
        static void Main(string[] args)
        {
            var Repo = new FrameworkRepo();
            string curr_name = "";
            string curr_email;
            int curr_cart;
            DateTime newt = DateTime.Now;


            var optionsBuilder = new DbContextOptionsBuilder<Project0Context>();
            optionsBuilder.UseSqlServer(Secret.ConnectionString);
            //optionsBuilder.UseLoggerFactory(AppLoggerFactory); This works but spams the console with data.
            var options = optionsBuilder.Options;
            Console.WriteLine("Welcome to Comic League United the 7th largest comic supply store in the tri-state area.");
            Console.WriteLine("Please login in order make a new customer. ");
            Console.WriteLine("Please enter Customer name now. ");
            curr_name = Console.ReadLine();
            Console.WriteLine("Please enter Customer email now. ");
            curr_email = Console.ReadLine();

            using (var dbContext = new Project0Context(options))
            {
                var store = dbContext.Customer.FirstOrDefault(x => x.Name == curr_name || x.Email == curr_email);
                if (store == null)
                {
                    Console.WriteLine("Please enter your store location now. ");
                    string temp = Console.ReadLine();
                    Repo.AddCustomer(dbContext, curr_name, curr_email, temp);
                    dbContext.SaveChanges();
                    Console.WriteLine("Welcome New Customer. ");
                }
                else
                {
                    Console.WriteLine("Welcome Back " + curr_name);
                }
                var cart = new Orders();
                cart.CustomerId = store.CustomerId;
                cart.OrderTime = newt;
                dbContext.Add(cart);
                dbContext.SaveChanges();
                curr_cart = cart.OrdersId;
                Console.ReadKey();
            }

            while (true)
            {
                Repo.MainMenu();
                string choice = "11";
                string temp = "";


                try
                {
                    choice = Console.ReadLine();
                    Console.Clear();
                    if (choice == "0")
                    {
                        break;
                    }
                    else if (choice == "1")
                    {
                        choice = "11";
                        Console.WriteLine("1: Add a Store");
                        Console.WriteLine("2: Delete a Store");
                        Console.WriteLine("3: Update a Store");
                        choice = Console.ReadLine();
                        Console.Clear();
                        if (choice == "1")
                        {
                            Console.WriteLine("Please enter a Store Name to add");
                            temp = Console.ReadLine();
                            using (var dbContext = new Project0Context(options))
                            {
                                Repo.AddStore(dbContext, temp);
                            }
                        }
                        else if (choice == "2")
                        {
                            Console.WriteLine("Please enter a Store Name to delete");
                            temp = Console.ReadLine();
                            using (var dbContext = new Project0Context(options))
                            {
                                Repo.DeleteStore(dbContext, temp);
                            }
                        }
                        else if (choice == "3")
                        {
                            Console.WriteLine("Please enter a Store Name to update");
                            temp = Console.ReadLine();
                            Console.WriteLine("Please enter the new name. ");
                            string temp2 = Console.ReadLine();
                            using (var dbContext = new Project0Context(options))
                            {
                                Repo.UpdateStore(dbContext, temp, temp2);
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Please pick a valid option. ");
                        }
                    }
                    else if (choice == "2")
                    {
                        choice = "11";
                        Console.WriteLine("1: Show All Stores. ");
                        Console.WriteLine("2: Show One Store. ");
                        choice = Console.ReadLine();
                        Console.Clear();
                        if (choice == "1")
                        {
                            using (var dbContext = new Project0Context(options))
                            {
                                Repo.ShowStores(dbContext);
                                Console.ReadKey();
                            }
                        }
                        else if (choice == "2")
                        {
                            Console.WriteLine("Please enter the store name. ");
                            temp = Console.ReadLine();
                            using (var dbContext = new Project0Context(options))
                            {
                                Repo.ShowStores(dbContext, temp);
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Please pick a valid option. ");
                        }
                    }
                    else if (choice == "3")
                    {
                        choice = "11";
                        Console.WriteLine("1: Add a Product");
                        Console.WriteLine("2: Delete a Product");
                        Console.WriteLine("3: Update a Product");
                        choice = Console.ReadLine();
                        Console.Clear();
                        if (choice == "1")
                        {
                            string placeholder;
                            int inv = 1;
                            decimal price = 5.00m;
                            int id;
                            Console.WriteLine("Please enter a Product Name.");
                            placeholder = Console.ReadLine();
                            Console.WriteLine("Please enter the number of products in inventory.");
                            temp = Console.ReadLine();
                            int.TryParse(temp, out inv);
                            Console.WriteLine("Please enter the price of the product.");
                            temp = Console.ReadLine();
                            decimal.TryParse(temp, out price);
                            Console.WriteLine("Please enter a Store ID to add the Product.");
                            temp = Console.ReadLine();
                            int.TryParse(temp, out id);
                            if (id == 2)
                            {
                                id = 6;
                            }
                            if (id == 3)
                            {
                                id = 11;
                            }

                            using (var dbContext = new Project0Context(options))
                            {
                                Repo.AddProduct(dbContext, placeholder, price, inv, id);
                            }
                        }
                        else if (choice == "2")
                        {
                            Console.WriteLine("Please enter a product Name to delete");
                            temp = Console.ReadLine();
                            using (var dbContext = new Project0Context(options))
                            {
                                Repo.DeleteProduct(dbContext, temp);
                            }
                        }
                        else if (choice == "3")
                        {
                            string placeholder;
                            string old;
                            int inv = 1;
                            decimal price = 5.00m;
                            int id;
                            Console.WriteLine("Please enter the old Product Name.");
                            old = Console.ReadLine();
                            Console.WriteLine("Please enter the new Product Name.");
                            placeholder = Console.ReadLine();
                            Console.WriteLine("Please enter the number of products in inventory.");
                            temp = Console.ReadLine();
                            int.TryParse(temp, out inv);
                            Console.WriteLine("Please enter the price of the product.");
                            temp = Console.ReadLine();
                            decimal.TryParse(temp, out price);
                            Console.WriteLine("Please enter a Store ID to add the Product.");
                            temp = Console.ReadLine();
                            int.TryParse(temp, out id);


                            using (var dbContext = new Project0Context(options))
                            {
                                Repo.UpdateProduct(dbContext, placeholder, price, inv, id, old);
                            }
                        }

                        else
                        {
                            throw new ArgumentException("Please pick a valid option. ");
                        }
                    }
                    else if (choice == "4")
                    {
                        choice = "11";
                        Console.WriteLine("1: Show All Products");
                        Console.WriteLine("2: Show A Product");
                        choice = Console.ReadLine();
                        Console.Clear();
                        if (choice == "1")
                        {
                            using (var dbContext = new Project0Context(options))
                            {
                                Repo.ShowProducts(dbContext);
                                Console.ReadKey();
                            }
                        }
                        else if (choice == "2")
                        {
                            Console.WriteLine("Please enter the product name. ");
                            temp = Console.ReadLine();
                            using (var dbContext = new Project0Context(options))
                            {
                                Repo.ShowProducts(dbContext, temp);
                                Console.ReadKey();
                            }

                        }
                        else
                        {
                            throw new ArgumentException("Please pick a valid option. ");
                        }
                    }
                    else if (choice == "5")
                    {
                        choice = "11";
                        Console.WriteLine("1: Add a Customer");
                        Console.WriteLine("2: Delete a Customer");
                        Console.WriteLine("3: Update a Customer");
                        choice = Console.ReadLine();
                        Console.Clear();
                        if (choice == "1")
                        {
                            string email;
                            string id;
                            Console.WriteLine("Please enter the name of the customer. ");
                            temp = Console.ReadLine();
                            Console.WriteLine("Please enter the customers email. ");
                            email = Console.ReadLine();
                            Console.WriteLine("Please enter the customers store name. ");
                            id = Console.ReadLine();
                            using (var dbContext = new Project0Context(options))
                            {
                                Repo.AddCustomer(dbContext, temp, email, id);
                            }
                        }
                        else if (choice == "2")
                        {
                            string email;
                            Console.WriteLine("Please enter the name of the customer. ");
                            temp = Console.ReadLine();
                            Console.WriteLine("Please enter the customers email. ");
                            email = Console.ReadLine();
                            using (var dbContext = new Project0Context(options))
                            {
                                Repo.DeleteCustomer(dbContext, temp, email);
                            }
                        }
                        else if (choice == "3")
                        {
                            string email, oldn, olde;
                            Console.WriteLine("Please enter the name of the customer to edit. ");
                            oldn = Console.ReadLine();
                            Console.WriteLine("Please enter the old customers email. ");
                            olde = Console.ReadLine();
                            Console.WriteLine("Please enter the new name of the customer. ");
                            temp = Console.ReadLine();
                            Console.WriteLine("Please enter the new customers email. ");
                            email = Console.ReadLine();
                            using (var dbContext = new Project0Context(options))
                            {
                                Repo.UpdateCustomer(dbContext, temp, email, oldn, olde);
                            }


                        }
                        else
                        {
                            throw new ArgumentException("Please pick a valid option. ");
                        }
                    }
                    else if (choice == "6")
                    {
                        Console.Clear();
                        using (var dbContext = new Project0Context(options))
                        {
                            Repo.ShowCustomers(dbContext);
                            Console.ReadKey();
                        }
                    }
                    else if (choice == "7")
                    {
                        choice = "11";
                        Console.WriteLine("1: Add a product to your cart");
                        Console.WriteLine("2: Delete a product from your cart");
                        Console.WriteLine("3: Checkout");
                        choice = Console.ReadLine();
                        Console.Clear();
                        if (choice == "1")
                        {
                            int inv = 1;
                            string name;
                            Console.WriteLine("Please enter the name of the product you'd like to add. ");
                            name = Console.ReadLine();
                            Console.WriteLine("How many would you like to add. ");
                            temp = Console.ReadLine();
                            int.TryParse(temp, out inv);
                            using (var dbContext = new Project0Context(options))
                            {
                                if (name.Substring(name.Length - 4, 3) == "Set")
                                {
                                    Repo.AddSet(dbContext, name, inv, curr_cart);
                                }
                                else
                                {
                                    Repo.AddCart(dbContext, name, inv, curr_cart);
                                }
                            }
                        }
                        else if (choice == "2")
                        {
                            int inv = 1;
                            Console.WriteLine("Please enter the name of the product you'd like to remove. ");
                            temp = Console.ReadLine();
                            Console.WriteLine("How many would you like to remove. ");
                            string temper = Console.ReadLine();
                            int.TryParse(temper, out inv);
                            using (var dbContext = new Project0Context(options))
                            {
                                Repo.DeleteCart(dbContext, temp, inv, curr_cart);
                            }

                        }
                        else if (choice == "3")
                        {
                            Console.Clear();
                            decimal total = 0;

                            using (var dbContext = new Project0Context(options))
                            {
                                if (Repo.CheckCartTime(dbContext, curr_name, curr_cart, newt))
                                {
                                    var ordertotal = dbContext.Orders.First(x => x.OrdersId == curr_cart);
                                    Repo.CheckOut(dbContext, curr_name, curr_cart, out total);
                                    Console.WriteLine("Total: " + total);
                                    Console.WriteLine("Thank you for shopping with us come back soon. ");
                                    ordertotal.Total = total;
                                    Console.ReadKey();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Cannot checkout at this time.");
                                    Console.ReadKey();
                                }
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Please pick a valid option. ");
                        }
                    }
                    else if (choice == "8")
                    {
                        Console.Clear();
                        using (var dbContext = new Project0Context(options))
                        {
                            Repo.ShowCart(dbContext, curr_name, curr_cart);
                            Console.WriteLine("Please press any key to return. ");
                            Console.ReadKey();
                        }

                    }
                    else if (choice == "9")
                    {
                        choice = "11";
                        Console.WriteLine("1: Sort by earliest");
                        Console.WriteLine("2: Sort by latest");
                        Console.WriteLine("3: Sort by cheapest");
                        Console.WriteLine("4: Sort by most expensive");
                        Console.WriteLine("5: Show Order Statistics.");
                        choice = Console.ReadLine();
                        Console.Clear();

                        using (var dbContext = new Project0Context(options))
                        {
                            if (choice == "1" || choice == "2" || choice == "3" || choice == "4")
                            {
                                Repo.ShowHistory(dbContext, curr_name, choice);
                                Console.ReadKey();
                            }
                            else if (choice == "5")
                            {
                                Repo.ShowStatistics(dbContext);
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Please only enter a valid option ");
                            }

                        }
                    }
                    else
                    {
                        throw new ArgumentException("Please pick a valid option. ");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.Clear();
                    Console.WriteLine(e);
                    Console.ReadKey();
                }


                choice = "11";
            }
        }
    }
}