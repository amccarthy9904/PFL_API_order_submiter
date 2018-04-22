using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrderSubmiter
{
    class Fetcher
    {
        private string api = "https://testapi.pfl.com/products?apikey=136085";
        private string products = "/products";
        private string apiKey = "136085";
        private string credentials;
        private WebClient client;

        public Fetcher()
        {
            //TODO
            //setup connectiuon with API
            this.client = new WebClient();
            this.credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes("miniproject:Pr!nt123"));
            //this.client.Credentials = new NetworkCredential("miniproject", "Pr!nt123");
            this.client.UseDefaultCredentials = true;
        }

        public void getProducts()
        {
            this.client.Headers[HttpRequestHeader.Authorization] = this.credentials;
            this.client.Headers.Add("Content-Type", "application/json");
            //this.client.QueryString.Add("apikey", this.apiKey);
            //this.client.QueryString.Add("Content - Type", "application/json");

            string str = this.client.DownloadString(api);
            Console.WriteLine(str);
            //return a list of all products
        }

        public void orderProduct(object product)
        {
            //orers the product from the API
        }


    }
}
