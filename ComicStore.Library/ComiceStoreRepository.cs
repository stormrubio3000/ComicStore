using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace ComicStore.Library
{
    public class ComiceStoreRepository
    {
        //handles the add/delete/edit for comicstores and products.
        private readonly ICollection<Comicstore> _data;



        public ComiceStoreRepository(ICollection<Comicstore> data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }



        //search comic

        public IEnumerable<Comicstore> GetComicStore(string search = null)
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

        //add comic 


        public void AddComicStore ( Comicstore comicstore)
        {
            if (_data.Any(c => c.Name == comicstore.Name))
            {
                throw new InvalidOperationException("A Comic Store with that name already exists. ");
            }
            _data.Add(comicstore);
        }


        //delete comic 

        public void DeleteComicStore (Comicstore comicstore)
        {
            _data.Remove(_data.First(x => x.Name == comicstore.Name));
        }


        //update comic 
        public void UpdateComicStore (Comicstore old, Comicstore ne)
        {
            DeleteComicStore(old);
            AddComicStore(ne);
        }


        ////////////////////////////////


        //search product name
        
        public IEnumerable<Product> GetProduct(string search = null)
        {
            if (search == null)
            {
                foreach (var item in _data.Select(x => x.Inventory).Distinct())
                {
                    foreach (var pro in item)
                    {
                        yield return pro;
                    }
                    
                }
            }
            else
            {
                foreach (var item in _data.Select(x => x.Inventory))
                {
                    
                    foreach (var pro in item.Where(r => r.Name.Contains(search)))
                    {
                        yield return pro;
                    }
                }
            }
        }
        

        //add product
        public void AddProduct(Product product, string comicstore)
        {
            Comicstore store = _data.First(x => x.Name == comicstore);
            store.Inventory.Add(product);
        }



        //delete product
        public void DeleteProduct(string product)
        {
            var store = _data.First(x => x.Inventory.Any(y => y.Name == product));
            store.Inventory.Remove(store.Inventory.First(x => x.Name == product));
        }



        //update product name
        public void UpdateProduct(Product product, string name)
        {
            var store = _data.First(x => x.Inventory.Any(y => y.Name == name));
            var placeholder = store.Inventory.IndexOf(store.Inventory.First(y => y.Name == name));
            store.Inventory[placeholder] = product;
        }
        










    }
}
