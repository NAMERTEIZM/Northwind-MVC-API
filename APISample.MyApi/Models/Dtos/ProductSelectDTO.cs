using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.MyApi.Models.Dtos
{
	public class ProductSelectDTO
	{
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public string CompanyName { get; set; }
		public int CategoryID { get; set; }
		public int SupplierID { get; set; }
		public string CategoryName { get; set; }
		public string QuantityPerUnit { get; set; }
		public int UnitPrice { get; set; }
		public int UnitsInStock { get; set; }
		public int UnitsOnOrder { get; set; }
		public short ReorderLevel { get; set; }
		public bool Discontinued { get; set; }

	}
}
