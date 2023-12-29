using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.MyApi.Models.Entities
{

    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        
        public decimal Discount { get; set; }
    }

}
