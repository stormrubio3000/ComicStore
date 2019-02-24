using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComicStore.Library
{
     public class Order
    {
        private int _ID;
        private double _Total = 0.00;
        private List<Product> _Products;

        public int ID
        {
            get => _ID;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Please enter a positive ID number. ");
                }
                _ID = value;
            }
        }

        public double Total
        {
            get => _Total;
            set
            {
                if (value < 0.00)
                {
                    throw new ArgumentException("There is a invalid total order price. ");
                }
                _Total = value;
            }
        }

        public List<Product> Products
        {
            get => _Products;
            set
            {
                if (value?.Any() != true)
                {
                    throw new ArgumentException("Cannot accept a null or empty list of products in order. ");
                }
                _Products = value;
            }
        }


    }
}
