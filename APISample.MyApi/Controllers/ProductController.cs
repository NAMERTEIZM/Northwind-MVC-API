using APISample.MyApi.Models.Dtos;
using APISample.MyApi.Models.IDAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.MyApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : Controller
	{
		private readonly IProductDal _dal;
		private readonly ICategoryDAL _dalCategory;
		private readonly ISupplierDAL _dalSupplier;
		public ProductController(IProductDal dal,ICategoryDAL categoryDAL,ISupplierDAL supplierDAL)
		{
			_dal = dal;
			_dalCategory = categoryDAL;
			_dalSupplier = supplierDAL;
		}
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet("~/api/productgetir")]
		public List<ProductSelectDTO> ProductGetir()
		{
			return _dal.GetAllProducts();
		}

		[HttpGet("~/api/kategoriGetir")]
		public List<CategorySelectDTO> KategoriGetir()
		{
			return _dalCategory.getAllCategory();
		
		}
		[HttpGet("{ID}")]
		public ProductUpdateDTO ProductGetirByID(int ID)
		{
			return _dal.GetProductsByID(ID);

		}


		[HttpGet("~/api/supplierGetir")]
		public List<SupplierSelectDTO> SupplierGetir()
		{
			return _dalSupplier.getAllSuppliers();

		}

		[HttpPost("~/api/productekle")]
		public IActionResult ProductEkle([FromBody] ProductInsertDTO addProduct)
		{
			if (_dal.AddProduct(addProduct) > 0)
			{
				return Ok();
			}
			return BadRequest();
		}
		[HttpPost("~/api/productguncelle")]
		public IActionResult ProductGuncelle([FromBody] ProductUpdateDTO updateProduct)
		{
			if (_dal.UpdateProduct(updateProduct) > 0)
			{
				return Ok();
			}
			return BadRequest();
		}
		[HttpDelete("{ID}")]
		public IActionResult ProductSil(int ID)
		{
			if (_dal.DeleteProduct(ID) > 0)
			{
				return Ok();
			}
			return BadRequest();
		}


	}
}
