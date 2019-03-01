using System;
using System.Collections.Generic;

namespace ET.ComicStore.Library
{
    public partial class ComicStore
    {
        public ComicStore()
        {
            Customer = new HashSet<Customer>();
            Inventory = new HashSet<Inventory>();
        }

        public int StoreId { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
