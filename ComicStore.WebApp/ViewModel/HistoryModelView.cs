using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComicStore.WebApp.ViewModel
{
	public class HistoryModelView
	{
		public ET.ComicStore.Library.Orders Order { get; set; }


		public List<ET.ComicStore.Library.Orders> Orders { get; set; }


		public ET.ComicStore.Library.Customer Customer { get; set; }


		public List<ET.ComicStore.Library.Customer> Customers { get; set; }


		public List<ET.ComicStore.Library.OrdersProduct> Products { get; set; }


		public List<ET.ComicStore.Library.ComicStore> Stores { get; set; }


		public ET.ComicStore.Library.ComicStore Store { get; set; }


		[Display (Name = "Customer Ratio")]
		public int CustomerCount { get; set; }

		[Display(Name = "Total Sales")]
		public decimal TotalSales { get; set; }

	}
}
