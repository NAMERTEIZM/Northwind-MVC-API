using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.UI.Models
{
	public class ProductSelectDTO
	{
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public string CompanyName { get; set; }
		public string CategoryName { get; set; }
		public string QuantityPerUnit { get; set; }
		public int UnitPrice { get; set; }
		public int UnitsInStock { get; set; }
		public int UnitsOnOrder { get; set; }
		public short ReorderLevel { get; set; }
		public bool Discontinued { get; set; }
	}
}
