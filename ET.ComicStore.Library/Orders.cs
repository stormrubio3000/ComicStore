using System;
using System.Collections.Generic;

namespace ET.ComicStore.Library
{
    public partial class Orders
    {
        public Orders()
        {
            OrdersProduct = new HashSet<OrdersProduct>();
        }

        public int OrdersId { get; set; }
        public decimal? Total { get; set; }
        public int CustomerId { get; set; }
        public DateTime? OrderTime { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrdersProduct> OrdersProduct { get; set; }
    }
}
