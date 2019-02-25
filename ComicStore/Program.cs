using System;
using System.Collections.Generic;
using ComicStore.Library;

namespace ComicStore
{
    static class Program
    {
        static void Main(string[] args)
        {
            var CSdata = new List<Comicstore>;
            var Cdata = new List<Customer>;

            var csrepo = new ComicStoreRepository(CSdata);
            //var crepo = new CustomerRepository(Cdata);
            Console.WriteLine("Welcome to Comic League United the 7th largest comic supply store in the tri-state area./b");

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
                        Console.WriteLine("1: Add a Store");
                        Console.WriteLine("2: Delete a Store");
                        Console.WriteLine("3: Update a Store");
                        choice = Console.ReadLine();
                        if (choice == "1")
                        {
                            Console.WriteLine("Please enter a Store Name to add");
                            temp = Console.ReadLine();
                            var placeholder = new ComicStore();
                            placeholder.Name(temp);
                            csrepo.AddComicStore(placeholder);
                        }
                        else if (choice == "2")
                        {
                            Console.WriteLine("Please enter a Store Name to delete");
                            temp = Console.ReadLine();
                            var placeholder = new ComicStore();
                            placeholder.Name(temp);
                            csrepo.DeleteComicStore(placeholder);
                        }
                        else if (choice == "3")
                        {
                            Console.WriteLine("Please enter a Store Name to update");
                            temp = Console.ReadLine();
                            var placeholder = new ComicStore();
                            placeholder.Name(temp);
                            Console.WriteLine("Please enter the new name. ");
                            string temp2 = Console.ReadLine();
                            var placeholder2 = new ComicStore();
                            placeholder2.Name(temp2);
                            csrepo.UpdateComicStore(placeholder, placeholder2);
                        }
                        else
                        {
                            throw new ArgumentException("Please pick a valid option. ");
                        }
                    }
                    else if (choice == "2")
                    {

                    }
                    else if (choice == "3")
                    {

                    }
                    else if (choice == "4")
                    {

                    }
                    else if (choice == "5")
                    {

                    }
                    else if (choice == "6")
                    {

                    }
                    else if (choice == "7")
                    {

                    }
                    else if (choice == "8")
                    {

                    }
                    else if (choice == "9")
                    {

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

            /* Todo: console needs menu of options
             * Todo: option to add comic store
             * Todo: option to show comic store
             * Todo: option to edit comic store
             * Todo: option to delete comic stores
             * Todo: to show all products
             * Todo: Add a product
             * option to update product
             * Todo: option to show what products are in a location
             * Todo: option to delete product
             * Todo: Add to product inventory 
             * Todo: Add customer
             * Todo: delete customer
             * Todo: update customer
             * Todo: Add product to cart
             * Todo: Show cart and total
             * Todo: option to load stored data
             * Todo: option to save data
             */





            //add repository clas
            //make console outputs with menu
            //do the testing stuff
            //add saving
            //add loading

       
        }

        static public  void MainMenu()
        {
            Console.WriteLine("1. Edit a store Location. ");
            Console.WriteLine("2. Show a store Location. ");
            Console.WriteLine("3. Edit a Product. ");
            Console.WriteLine("4. Show a Product. ");
            Console.WriteLine("5. Edit a Customer. ");
            Console.WriteLine("6. Show a Customer. ");
            Console.WriteLine("7. Show Cart. ");
            Console.WriteLine("8. Add Item to Cart. ");
            Console.WriteLine("9. Remove Item from Cart. ");
            Console.WriteLine("0. Quit. ");
        }
    }
}
