using System;
using System.Collections.Generic;

namespace ET.ComicStore.Library
{
    public partial class StoreProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InventorySize { get; set; }
        public int? InventoryId { get; set; }

        public virtual Inventory Inventory { get; set; }
    }
}
