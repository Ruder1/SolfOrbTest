using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class OrdersWithItems
    {
        public int Id { get; init; } 

        public int? OrderId { get; init; }

        public int? OrderItemId { get; init; }

        //public Order Order { get; init; }

        //public OrderItem OrderItem { get; init; }
    }
}
