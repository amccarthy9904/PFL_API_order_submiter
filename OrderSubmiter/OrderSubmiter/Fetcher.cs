using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;
using System.Text.RegularExpressions;

namespace OrderSubmiter
{
    class Fetcher
    {
        private string api = "https://testapi.pfl.com/products?apikey=136085";
        private string products = "/products";
        private string apiKey = "136085";
        private string credentials;
        private WebClient client;
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore};
        //private string pattern = "({\"id\".* \"del)";

        public Fetcher()
        {
            //TODO
            //setup connectiuon with API
            this.client = new WebClient();
            this.credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes("miniproject:Pr!nt123"));
            this.client.UseDefaultCredentials = true;
        }

        public dynamic getProducts()
        {
            this.client.Headers[HttpRequestHeader.Authorization] = $"Basic {this.credentials}";
            this.client.Headers.Add("Content-Type", "application/json");
            ArrayList prodList = new ArrayList();
            string prodStr = this.client.DownloadString(api);
            dynamic temp = JsonConvert.DeserializeObject(prodStr, settings);
            return temp.results.data;
            //return a list of all products
        }

        public void orderProduct(object product)
        {
            //orers the product from the API
        }


    }
}
