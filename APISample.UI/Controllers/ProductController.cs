using APISample.UI.ApiBaglanti;
using APISample.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.UI.Controllers
{
	public class ProductController : Controller
	{
		ProductBaglantiServis _api;
		GenericService<ProductInsertDTO, ProductUpdateDTO, ProductSelectDTO> _generic;
		public ProductController(ProductBaglantiServis api,GenericService<ProductInsertDTO,ProductUpdateDTO, ProductSelectDTO> generic)
		{
			_api = api;
			_generic = generic;
		}
		//public IActionResult Index()
		//{
		//	return View();
		//}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			
			var sonuc = await _api.ProductGetir();

			return View(sonuc);
		}

		//product guncellleme ekranı dolu gelir
		[HttpGet]
		public async Task<IActionResult> ProductDoldurGetir(int ID)
		{
			var sonuc = await _api.ProductGetirByID(ID);
			var kategoriler = await _api.CategoryGetir();
			var suppliers = await _api.SupplierGetir();
			ViewBag.Suppliers = suppliers;
			ViewBag.Categories = kategoriler;
;			return View("ProductGuncelle",sonuc);
		}


		[HttpPost]
		public async Task<IActionResult> ProductGuncelle(ProductUpdateDTO updateDTO)
		{
			//genericsssss
		//var sonuc=	await _generic.VeriDuzenle(updateDTO,"productguncelle");

			var sonuc = await _api.ProductGuncelle(updateDTO);

			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> ProductEkle()
		{

			//denenecek
			await _generic.VeriGetir("urungetir");

			var kategoriler = await _api.CategoryGetir();
			var suppliers = await _api.SupplierGetir();
			ViewBag.Suppliers = suppliers;
			ViewBag.Categories = kategoriler;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ProductEkle(ProductInsertDTO insertDTO)
		{
			
			await _generic.VeriEkle(insertDTO,"productekle");

			var sonuc = await _api.ProductEkle(insertDTO);

			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> ProductSil(int ID)
		{
			var sonuc = await _api.ProductSil(ID);

			return RedirectToAction("Index");
		}



	}
}
