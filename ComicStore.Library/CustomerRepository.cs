using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComicStore.Library
{
    public class CustomerRepository
    {
        private readonly ICollection<Customer> _data;

        public CustomerRepository(ICollection<Customer> data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }


        //search Customer

        public IEnumerable<Customer> GetCustomer(string search = null)
        {
            if (search == null)
            {
                foreach (var item in _data)
                {
                    yield return item;
                }
            }
            else
            {
                foreach (var item in _data.Where(r => r.Name.Contains(search)))
                {
                    yield return item;
                }
            }
        }


        public Customer CheckCustomer(string name, string email)
        {
            if (_data.Any(c => c.Name == name))
            {
                return _data.First(c => c.Name == name);
            }
            else
            {
                return new Customer()
                {
                    Name = name,
                    Email = email
                };
            }

        }
        //add customer 


        public void AddCustomer(Customer customer)
        {
            if (_data.Any(c => c.Name == customer.Name))
            {
                throw new InvalidOperationException("A Comic Store with that name already exists. ");
            }
            _data.Add(customer);
        }



        //delete comic 

        public void DeleteCustomer(Customer customer)
        {
            _data.Remove(_data.First(x => x.Name == customer.Name && x.Email == customer.Email));
        }


        //update comic 
        public void UpdateCustomer(Customer old, Customer ne)
        {
            DeleteCustomer(old);
            AddCustomer(ne);
        }


        /////////////////////


        //show

        public IEnumerable<Product> GetProduct(string cust)
        {
            var _cust = _data.First(x => x.Name == cust);
            foreach (var item in _cust.Products)
            {
                yield return item;
            }
        }


        public IEnumerable<Order> GetHistory(string cust)
        {
            var _cust = _data.First(x => x.Name == cust);
            foreach (var item in _cust.Orders)
            {
                yield return item;
            }
        }






        //add
        public void AddProduct(Product product, string customer, int amount = 1)
        {
            if (amount > 0)
            {
                for (int i = 0; i < amount;i++)
                {
                    var cust = _data.First(x => x.Name == customer);
                    cust.Products.Add(product);
                }
            }
            else
            {
                throw new InvalidOperationException("Must enter a positive non zero amount. ");
            }
        }



        //delete product
        public void DeleteProduct(string product, string customer, int amount = 1)
        {
            var cust = _data.First(x => x.Products.Any(y => y.Name == product && x.Name == customer));
            cust.Products.Remove(cust.Products.First(x => x.Name == product));
        }

    }
}
