using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicStore.WebApp.ViewModel
{
    public class StoreProductModelView
    {
        public int Id { get; set; }


        public string Name { get; set; }


        public decimal Price { get; set; }


        public int Inventorysize { get; set; }


        public int InventoryId { get; set; }


        public int SetId { get; set; }


        public List<ET.ComicStore.Library.ComicStore> Stores { get; set; }
        

        public ET.ComicStore.Library.ComicStore Store { get; set; }


        public ET.ComicStore.Library.Inventory Inv { get; set; }


        public List<ET.ComicStore.Library.Inventory> Inventory { get; set; }



    }

}