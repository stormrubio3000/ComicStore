using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComicStore.Library
{
    public class Customer
    {
        private string _Name;
        private string _Email;
        private List<Order> _Orders;
        private List<Product> _Products;



        public string Name
        {
            get => _Name;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name of Customer must not be empty. ");
                }
                _Name = value;
            }
        }

        public string Email
        {
            get => _Email;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Email must not be empty. ");
                }
                _Email = value;
            }
        }


        public List<Order> Orders
        {
            get => _Orders;
            set
            {
                if (value?.Any() != true)
                {
                    throw new ArgumentException("Cannot accept a null or empty list for customer orders. ");
                }
                _Orders = value;
            }
        }

        public List<Product> Products
        {
            get => _Products;
            set
            {
                if (value?.Any() != true)
                {
                    throw new ArgumentException("Cannot accept a null or empty list for customer orders. ");
                }
                _Products = value;
            }
        }


    }
}
