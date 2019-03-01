using System;
using System.Collections.Generic;

namespace ET.ComicStore.Library
{
    public partial class Inventory
    {
        public Inventory()
        {
            StoreProduct = new HashSet<StoreProduct>();
        }

        public int InventoryId { get; set; }
        public int? StoreId { get; set; }

        public virtual ComicStore Store { get; set; }
        public virtual ICollection<StoreProduct> StoreProduct { get; set; }
    }
}
