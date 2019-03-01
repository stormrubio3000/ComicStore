using System;
using System.Collections.Generic;

namespace ET.ComicStore.Library
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Orders>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }

        public virtual ComicStore LocationNavigation { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
