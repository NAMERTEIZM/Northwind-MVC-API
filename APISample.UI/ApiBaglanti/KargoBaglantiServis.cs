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
    public class KargoBaglantiServis
    {
		//    HttpClient _client;
		//    public KargoBaglantiServis(HttpClient client)
		//    {
		//        _client = client;

		//    }

		//    public async Task<List<ShipperDTO>> KargoGetir()
		//    {
		//        var response = await _client.GetAsync("kargolarigetir");
		//        if (response.IsSuccessStatusCode)
		//        {
		//            //calisti
		//            return JsonConvert.DeserializeObject<List<ShipperDTO>>(await response.Content.ReadAsStringAsync());
		//        }
		//        return null;
		//    }

		//    public async Task<string> KargoEkle(ShipperDTO dto)
		//    {
		//        var str = new StringContent(JsonConvert.SerializeObject(dto));
		//        str.Headers.ContentType = new MediaTypeHeaderValue("application/json");
		//        var response = await _client.PostAsync("kargoekle", str);

		//        //_client.DefaultRequestHeaders.Add(,) token ile api calling yapacağımız zaman buna ihtiyaç olacak

		//        if (response.IsSuccessStatusCode)
		//        {
		//            return response.Content.ReadAsStringAsync().Result == null ? "veri eklenirken bir hata olustu" : "eklendii..";
		//        }
		//        return null;
		//    }

		//    public async Task<string> KargoSil(int id)
		//    {
		//        var response = await _client.DeleteAsync($"Kargo/{id}");

		//        if (response.IsSuccessStatusCode)
		//        {
		//            return response.Content.ReadAsStringAsync().Result == null ? "veri silinirken bir hata olustu" : "silindi..";
		//        }
		//        return null;
		//    }

		//    public async Task<string> KargoSil(ShipperDTO dto)
		//    {
		//        var str = new StringContent(JsonConvert.SerializeObject(dto));
		//        str.Headers.ContentType = new MediaTypeHeaderValue("application/json");
		//        var response = await _client.PostAsync("kargosil", str);

		//        if (response.IsSuccessStatusCode)
		//        {
		//            return response.Content.ReadAsStringAsync().Result == null ? "veri silinirken bir hata olustu" : "silindi..";
		//        }
		//        return null;
		//    }

		//    public async Task<ShipperDTO> IdGoreKargoCek(int id)
		//    {
		//        var response = await _client.GetAsync("kargolarigetir");
		//        if (response.IsSuccessStatusCode)
		//        {
		//            //calisti
		//            return JsonConvert.DeserializeObject<ShipperDTO>(await response.Content.ReadAsStringAsync());
		//        }
		//        return null;
		//    }

		//    public async Task<string> KargoDuzenlemeApisiniCagir(ShipperDTO duzenlenmisdata)
		//    {
		//        var str = new StringContent(JsonConvert.SerializeObject(duzenlenmisdata));
		//        str.Headers.ContentType = new MediaTypeHeaderValue("application/json");
		//        var response = await _client.PostAsync("kargoduzenle", str);

		//        if (response.IsSuccessStatusCode)
		//        {
		//            return response.Content.ReadAsStringAsync().Result == null ? "veri guncellenirken bir hata olustu" : "guncellendi..";
		//        }
		//        return null;
		//    }
	}
}
