using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartApp
{
    /// <summary>
    /// Web Api cient for product details.
    /// </summary>
    internal class ProductDetailService
    {
        private readonly int _id;
        public ProductDetail productDetail { get; private set; }
        public ProductDetailService(int id)
        {
            _id = id;
        }
        public async Task<bool> FillProductDetail()
        {
            // Create a new HttpClient object.
            using (HttpClient client = new HttpClient())
            {
                // Create a new HttpRequestMessage object with the GET method and the URL of your Web API.
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, MyUrls.GetProductFromIdUrl(_id)))
                {

                    // Send the HttpRequestMessage object to the HttpClient object and get the HttpResponseMessage object.
                    HttpResponseMessage response = await client.SendAsync(request);

                    // Check the HttpResponseMessage object to see if the request was successful.
                    if (response.IsSuccessStatusCode)
                    {
                        // Deserialize the response content into a ProductResponse objects.
                        string resp = await response.Content.ReadAsStringAsync();
                        productDetail = JsonConvert.DeserializeObject<ProductDetail>(resp);
                    }
                    return response.IsSuccessStatusCode;
                }
            }

        }

    }
}
