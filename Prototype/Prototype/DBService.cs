using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class DBService
    {
        //const string Url = "http://pharmacyapiprototype123.azurewebsites.net/api/products";

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient(new NativeMessageHandler());
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;

        }

        public async Task<IEnumerable<ProductModel>> Get()
        {
            var client = GetClient();

            var response = await client.GetAsync(@"http://pharmacyapiprototype123.azurewebsites.net/api/products").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content;

                string jsonString = await content.ReadAsStringAsync().ConfigureAwait(false);

                return JsonConvert.DeserializeObject<IEnumerable<ProductModel>>(jsonString);

            }
            else return null;
        }
    }
}



