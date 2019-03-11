using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicStore.WebApp.ViewModel
{
	public class CartModelView
	{
		public int Id { get; set; }


		public string Name { get; set; }


		public decimal Price { get; set; }


		public int InventorySize { get; set; }


		public int OrdersId { get; set; }


		public ET.ComicStore.Library.Orders Order {get; set;}


		public List<ET.ComicStore.Library.Orders> Orders { get; set; }


		public ET.ComicStore.Library.Customer Customer { get; set; }


		public List<ET.ComicStore.Library.Customer> Customers { get; set; }



		public List<ET.ComicStore.Library.OrdersProduct> Cart { get; set; }


		public List<ET.ComicStore.Library.StoreProduct> Products { get; set; }


		public ET.ComicStore.Library.StoreProduct Product { get; set; }


		public ET.ComicStore.Library.OrdersProduct ProductO { get; set; }
	}
}
