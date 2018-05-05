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
using System.Net.Http.Headers;

namespace OrderSubmiter
{
    class Fetcher
    {   
        /// <summary>
        /// uri to interact with API
        /// </summary>
        private string api = "https://testapi.pfl.com/{0}?apikey={1}";

        /// <summary>
        /// api{0} substring to get products
        /// </summary>
        private string products = "/products";

        /// <summary>
        /// api{0} substring to make orders 
        /// </summary>
        private string orders = "/orders";

        /// <summary>
        /// api{1} substring to access api
        /// </summary>
        private string apiKey = "136085";

        /// <summary>
        /// user and pass for api authentification
        /// </summary>
        private string credentials;

        /// <summary>
        /// interacts with server - gets product list
        /// </summary>
        private WebClient webClient;

        /// <summary>
        /// interacts with server - sends orders
        /// </summary>
        private HttpClient httpClient;

        /// <summary>
        /// JsonSettings needed in more than one place
        /// </summary>
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore};

        /// <summary>
        /// Inits Fetcher. sends and recieves data fom API server
        /// </summary>
        public Fetcher()
        {
            this.webClient = new WebClient();
            this.httpClient = new HttpClient();
            this.credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes("miniproject:Pr!nt123"));
            this.webClient.UseDefaultCredentials = true;
        }

        /// <summary>
        /// gets a list of all products availible
        /// </summary>
        /// <returns>Dynamic obj with structure of json returned by API</returns>
        public dynamic getProducts()
        {
            this.webClient.Headers[HttpRequestHeader.Authorization] = $"Basic {this.credentials}";
            this.webClient.Headers.Add("Content-Type", "application/json");
            string prodStr = this.webClient.DownloadString(string.Format(api, products, apiKey));
            dynamic temp = JsonConvert.DeserializeObject(prodStr, settings);
            return temp.results.data;
        }

        /// <summary>
        /// orders the specified product with the specified amount
        /// </summary>
        /// <param name="product">product to order</param>
        /// <returns>string containing order information</returns>
        public async void orderProduct(Order product, OrderButton button)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", this.credentials);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var temp = JsonConvert.SerializeObject(product, Formatting.Indented);
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(string.Format(api, orders, apiKey), product);
           
            if (response.IsSuccessStatusCode)
            {
                button.Content = "Success";
            }
            else
            {
                button.Content = "Failure";
            }
        }
    }
}
