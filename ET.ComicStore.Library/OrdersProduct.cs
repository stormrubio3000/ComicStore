using System;
using System.Collections.Generic;

namespace ET.ComicStore.Library
{
    public partial class OrdersProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InventorySize { get; set; }
        public int? OrdersId { get; set; }

        public virtual Orders Orders { get; set; }
    }
}
