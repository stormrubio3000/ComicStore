using System;
using System.Collections.Generic;
using System.Linq;
using ComicStore.Library;

namespace ComicStore
{
    static class Program
    {
        static void Main(string[] args)
        {
            var CSdata = new List<Comicstore>();
            var Cdata = new List<Customer>();

            var csrepo = new ComiceStoreRepository(CSdata);
            var crepo = new CustomerRepository(Cdata);
            string curr_name;
            string curr_email;
            
            Console.WriteLine("Welcome to Comic League United the 7th largest comic supply store in the tri-state area.");
            Console.WriteLine("Please login in order make a new customer. ");
            Console.WriteLine("Please enter Customer name now. ");
            curr_name = Console.ReadLine();
            Console.WriteLine("Please enter Customer email now. ");
            curr_email = Console.ReadLine();


            //ToDo: add check to see if current cust is a new cust or returning.
            var curr_cust = new Customer()
            {
                Name = curr_name,
                Email = curr_email
            };

            while (true)
            {
                MainMenu();
                string choice = "11";
                string temp = "";

                try
                {
                    choice = Console.ReadLine();
                    if (choice == "0")
                    {
                        break;
                    }
                    else if (choice == "1")
                    {
                        choice = "11";
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("1: Add a Store");
                        Console.WriteLine("2: Delete a Store");
                        Console.WriteLine("3: Update a Store");
                        choice = Console.ReadLine();
                        if (choice == "1")
                        {
                            Console.WriteLine("Please enter a Store Name to add");
                            temp = Console.ReadLine();
                            var placeholder = new Comicstore();
                            placeholder.Name = temp;
                            csrepo.AddComicStore(placeholder);
                        }
                        else if (choice == "2")
                        {
                            Console.WriteLine("Please enter a Store Name to delete");
                            temp = Console.ReadLine();
                            var placeholder = new Comicstore();
                            placeholder.Name = temp;
                            csrepo.DeleteComicStore(placeholder);
                        }
                        else if (choice == "3")
                        {
                            Console.WriteLine("Please enter a Store Name to update");
                            temp = Console.ReadLine();
                            var placeholder = new Comicstore();
                            placeholder.Name = temp;
                            Console.WriteLine("Please enter the new name. ");
                            string temp2 = Console.ReadLine();
                            var placeholder2 = new Comicstore();
                            placeholder2.Name = temp2;
                            csrepo.UpdateComicStore(placeholder, placeholder2);
                        }
                        else
                        {
                            throw new ArgumentException("Please pick a valid option. ");
                        }
                    }
                    else if (choice == "2")
                    {
                        choice = "11";
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("1: Show All Stores. ");
                        Console.WriteLine("2: Show One Store. ");
                        choice = Console.ReadLine();
                        if (choice == "1")
                        {
                            var stores = csrepo.GetComicStore().ToList();
                            for (int i = 0; i < stores.Count; i++)
                            {
                                Console.WriteLine(i + ": " + stores[i].Name);
                            }
                        }
                        else if (choice == "2")
                        {
                            Console.WriteLine("Please enter the store name. ");
                            temp = Console.ReadLine();
                            var store = csrepo.GetComicStore(temp).ToList();
                            for (int i = 0; i < store.Count; i++)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine(store[i].Name);
                            }
                            //ToDo: add in inventory output
                        }
                        else
                        {
                            throw new ArgumentException("Please pick a valid option. ");
                        }
                    }
                    else if (choice == "3")
                    {
                        choice = "11";
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("1: Add a Product");
                        Console.WriteLine("2: Delete a Product");
                        Console.WriteLine("3: Update a Product");
                        choice = Console.ReadLine();
                        if (choice == "1")
                        {
                            var placeholder = new Product();
                            int inv = 1;
                            double price = 5.00;
                            Console.WriteLine("Please enter a Product Name.");
                            temp = Console.ReadLine();
                            placeholder.Name = temp;
                            Console.WriteLine("Please enter the number of products in inventory.");
                            temp = Console.ReadLine();
                            int.TryParse(temp, out inv);
                            placeholder.Inventory = inv;
                            Console.WriteLine("Please enter the price of the product.");
                            temp = Console.ReadLine();
                            double.TryParse(temp, out price);
                            placeholder.Price = price;
                            Console.WriteLine("Please enter a Store Name to add the Product.");
                            temp = Console.ReadLine();

                            csrepo.AddProduct(placeholder, temp);
                        }
                        else if (choice == "2")
                        {
                            Console.WriteLine("Please enter a product Name to delete");
                            temp = Console.ReadLine();
                            csrepo.DeleteProduct(temp);
                        }
                        else if (choice == "3")
                        {
                            Console.WriteLine("Please enter a product Name to Update");
                            temp = Console.ReadLine();
                            csrepo.DeleteProduct(temp);
                            var placeholder = new Product();
                            double price = 5.00;
                            int inv = 1;
                            Console.WriteLine("Please enter a new Product Name.");
                            temp = Console.ReadLine();
                            placeholder.Name = temp;
                            Console.WriteLine("Please enter the new price of the product.");
                            temp = Console.ReadLine();
                            double.TryParse(temp, out price);
                            placeholder.Price = price;
                            Console.WriteLine("Please enter the new number of products in inventory.");
                            temp = Console.ReadLine();
                            int.TryParse(temp, out inv);
                            placeholder.Inventory = inv;

                            csrepo.AddProduct(placeholder, temp);
                        }

                        else
                        {
                            throw new ArgumentException("Please pick a valid option. ");
                        }
                    }
                    else if (choice == "4")
                    {
                        choice = "11";
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("1: Show All Products");
                        Console.WriteLine("2: Show A Product");
                        choice = Console.ReadLine();

                        if (choice == "1")
                        {
                            var stores = csrepo.GetProduct().ToList();
                            for (int i = 0; i < stores.Count; i++)
                            {
                                Console.WriteLine(i + ": " + stores[i].Name);
                            }

                        }
                        else if (choice == "2")
                        {
                            Console.WriteLine("Please enter the product name. ");
                            temp = Console.ReadLine();
                            var store = csrepo.GetProduct(temp).ToList();
                            for (int i = 0; i < store.Count; i++)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine(store[i].Name);
                                Console.WriteLine("In Inventory: " + store[i].Inventory);
                                Console.WriteLine("Current Price: " + store[i].Price);
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
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("1: Add a Customer");
                        Console.WriteLine("2: Delete a Customer");
                        Console.WriteLine("3: Update a Customer");
                        choice = Console.ReadLine();
                        if (choice == "1")
                        {
                            Console.WriteLine("Please enter the name of the customer. ");
                            temp = Console.ReadLine();
                            var cust = new Customer();
                            cust.Name = temp;
                            Console.WriteLine("Please enter the customers email. ");
                            temp = Console.ReadLine();
                            cust.Email = temp;
                            crepo.AddCustomer(cust);
                        }
                        else if (choice == "2")
                        {
                            Console.WriteLine("Please enter the name of the customer. ");
                            temp = Console.ReadLine();
                            var cust = new Customer();
                            cust.Name = temp;
                            Console.WriteLine("Please enter the customers email. ");
                            temp = Console.ReadLine();
                            cust.Email = temp;
                            crepo.DeleteCustomer(cust);
                        }
                        else if (choice == "3")
                        {
                            Console.WriteLine("Please enter the name of the customer to edit. ");
                            temp = Console.ReadLine();
                            var cust = new Customer();
                            cust.Name = temp;
                            Console.WriteLine("Please enter the customers email. ");
                            temp = Console.ReadLine();
                            cust.Email = temp;
                            var cust2 = new Customer();
                            Console.WriteLine("Please enter the new name of the customer. ");
                            temp = Console.ReadLine();
                            cust2.Name = temp;
                            Console.WriteLine("Please enter the new customers email. ");
                            temp = Console.ReadLine();
                            cust2.Email = temp;
                            crepo.UpdateCustomer(cust,cust2);

                        }
                        else
                        {
                            throw new ArgumentException("Please pick a valid option. ");
                        }
                    }

                    else if (choice == "6")
                    {
                        crepo.GetCustomer(curr_name);
                        //ToDo: add in order history show.
                    }
                    else if (choice == "7")
                    {
                        choice = "11";
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("1: Add a product to your cart");
                        Console.WriteLine("2: Delete a product from your cart");
                        choice = Console.ReadLine();

                        if (choice == "1")
                        {
                            int inv = 1;
                            Console.WriteLine("Please enter the name of the product you'd like to add. ");
                            temp = Console.ReadLine();
                            var prod = csrepo.GetProduct(temp).ToList();
                            Console.WriteLine("How many would you like to add. ");
                            temp = Console.ReadLine();
                            int.TryParse(temp, out inv);
                            crepo.AddProduct(prod[0], curr_name, inv);

                        }
                        else if (choice == "2")
                        {
                            int inv = 1;
                            Console.WriteLine("Please enter the name of the product you'd like to remove. ");
                            temp = Console.ReadLine();
                            Console.WriteLine("How many would you like to remove. ");
                            string temper = Console.ReadLine();
                            int.TryParse(temper, out inv);
                            crepo.DeleteProduct(temp, curr_name, inv);

                        }
                        else
                        {
                            throw new ArgumentException("Please pick a valid option. ");
                        }
                    }
                    else if (choice == "8")
                    {
                        Console.WriteLine("ToDo");
                    }
                    else if (choice == "9")
                    {
                        Console.WriteLine("ToDo");
                    }
                    else
                    {
                        throw new ArgumentException("Please pick a valid option. ");
                    }
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e);
                }


                choice = "11";
            }

            /* 
             * Todo: Show cart and total
             * Todo: Show customer order history
             * Todo: All unit tests
             * Todo: SQL database for saving and loading
             */

            //customer should have order list and product list
            //product list is current cart
            //order list is just order history
       
        }

        static public  void MainMenu()
        {
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
    }
}
