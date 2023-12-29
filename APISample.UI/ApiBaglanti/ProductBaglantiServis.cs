using APISample.UI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace APISample.UI.ApiBaglanti
{
	public class ProductBaglantiServis
	{
		HttpClient _client;
		public ProductBaglantiServis(HttpClient client)
		{
			_client = client;
		}
		public async Task<List<ProductSelectDTO>> ProductGetir()
		{
			var response = await _client.GetAsync("productgetir");
			if (response.IsSuccessStatusCode)
			{
				//calisti
				return JsonConvert.DeserializeObject<List<ProductSelectDTO>>(await response.Content.ReadAsStringAsync());
			}
			return null;
		}
		public async Task<List<CategorySelectDTO>> CategoryGetir()
		{
			var response = await _client.GetAsync("kategorigetir");
			if (response.IsSuccessStatusCode)
			{
				//calisti
				return JsonConvert.DeserializeObject<List<CategorySelectDTO>>(await response.Content.ReadAsStringAsync());
			}
			return null;
		}
		public async Task<List<SupplierSelectDTO>> SupplierGetir()
		{
			var response = await _client.GetAsync("supplierGetir");
			if (response.IsSuccessStatusCode)
			{
				//calisti
				return JsonConvert.DeserializeObject<List<SupplierSelectDTO>>(await response.Content.ReadAsStringAsync());
			}
			return null;
		}
		public async Task <ProductUpdateDTO> ProductGetirByID(int ID)
		{
			var response = await _client.GetAsync($"Product/{ID}");
			if (response.IsSuccessStatusCode)
			{
				//calisti
				return JsonConvert.DeserializeObject<ProductUpdateDTO>(await response.Content.ReadAsStringAsync());
			}
			return null;
		}

		public async Task<string> ProductGuncelle(ProductUpdateDTO updateDTO)
		{
			var str = new StringContent(JsonConvert.SerializeObject(updateDTO));
			str.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			var response = await _client.PostAsync("productguncelle", str);

			if (response.IsSuccessStatusCode)
			{
				return response.Content.ReadAsStringAsync().Result == null ? "veri guncellenirken bir hata olustu" : "guncellendi..";
			}
			return null;
		}
		public async Task<string> ProductEkle(ProductInsertDTO insertDTO)
		{
			var str = new StringContent(JsonConvert.SerializeObject(insertDTO));
			str.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			var response = await _client.PostAsync("productekle", str);
			if (response.IsSuccessStatusCode)
			{
				return response.Content.ReadAsStringAsync().Result == null ? "veri guncellenirken bir hata olustu" : "guncellendi..";
			}
			return null;
		}
		public async Task<string> ProductSil(int ID)
		{
			var response = await _client.DeleteAsync($"Product/{ID}");
			if (response.IsSuccessStatusCode)
			{
				return response.Content.ReadAsStringAsync().Result == null ? "veri silinirken bir hata olustu" : "guncellendi..";
			}
			return null;
		}





	}
}
