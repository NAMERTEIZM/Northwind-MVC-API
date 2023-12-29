using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace APISample.UI.ApiBaglanti
{
	
        public class GenericService<TInsert,TUpdate,TSelect>
        {
            HttpClient _client;
            public GenericService(HttpClient client)
            {
                _client = client;
            }

            public async Task<List<TSelect>> VeriGetir(string endpoint)
            {
                var response = await _client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<TSelect>>(await response.Content.ReadAsStringAsync());
                }
                return null;
            }

            public async Task<string> VeriEkle(TInsert dto, string endpoint)
            {
                var str = new StringContent(JsonConvert.SerializeObject(dto));
                str.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await _client.PostAsync(endpoint, str);

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result == null ? "veri eklenirken bir hata olustu" : "eklendii..";
                }
                return null;
            }

            public async Task<string> VeriSil(int id, string endpoint)
            {
                var response = await _client.DeleteAsync($"{endpoint}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result == null ? "veri silinirken bir hata olustu" : "silindi..";
                }
                return null;
            }

            public async Task<TSelect> IdGoreVeriCek(int id, string endpoint)
            {
                var response = await _client.GetAsync($"{endpoint}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<TSelect>(await response.Content.ReadAsStringAsync());
                }
                return default;
            }

            public async Task<string> VeriDuzenle(TUpdate duzenlenmisdata, string endpoint)
            {
                var str = new StringContent(JsonConvert.SerializeObject(duzenlenmisdata));
                str.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await _client.PostAsync(endpoint, str);

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result == null ? "veri guncellenirken bir hata olustu" : "guncellendi..";
                }
                return null;
            }
        }

    
}
