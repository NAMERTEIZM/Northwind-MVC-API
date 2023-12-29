using APISample.MyApi.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.MyApi.Models.IDAL
{
	public interface IProductDal :IDisposable
	{
		List<ProductSelectDTO> GetAllProducts();
		int AddProduct(ProductInsertDTO addProduct);
		int UpdateProduct(ProductUpdateDTO updateProduct);
		ProductUpdateDTO GetProductsByID(int id);
		int DeleteProduct(int ID);
	}
}
