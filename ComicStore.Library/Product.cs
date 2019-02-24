using System;
using System.Collections.Generic;
using System.Text;

namespace ComicStore.Library
{
    public class Product
    {

        private double _Price;
        private string _Name;
        private int _Inventory;



        public double Price
        {
            get => _Price;
            set
            {
                if ( value <= 0)
                {
                    throw new ArgumentException("Please enter a positive non zero price. ");
                }

                _Price = value;
            }
        }

        public string Name
        {
            get => _Name;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name of Product must not be empty. ");
                }
                _Name = value;
            }
        }

        public int Inventory
        {
            get => _Inventory;
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("We are out of stock in " + _Name);
                }
                _Inventory = value;
            }
        }
    }
}
