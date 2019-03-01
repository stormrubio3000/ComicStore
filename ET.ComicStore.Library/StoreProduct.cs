using System;
using System.Collections.Generic;

namespace ET.ComicStore.Library
{
    public partial class StoreProduct
    {
        public StoreProduct()
        {
            InverseSet = new HashSet<StoreProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InventorySize { get; set; }
        public int? InventoryId { get; set; }
        public int? SetId { get; set; }

        public virtual Inventory Inventory { get; set; }
        public virtual StoreProduct Set { get; set; }
        public virtual ICollection<StoreProduct> InverseSet { get; set; }
    }
}
