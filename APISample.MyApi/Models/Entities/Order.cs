using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.MyApi.Models.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }


        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
