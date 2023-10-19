using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace SmartApp
{
    /// <summary>
    /// Web Api cient for product Services.
    /// </summary>
    internal class ProductService
    {
        private readonly string _category;
        public ProductResponse productResponse { get; private set; }
        public ProductService(string category)
        {
            _category = category;
        }
        public async Task<bool> FillProducts()
        {
            // Create a new HttpClient object.
            using (HttpClient client = new HttpClient())
            {
                // Create a new HttpRequestMessage object with the GET method and the URL of your Web API.
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, MyUrls.GetProductUrl(_category)))
                {

                    // Send the HttpRequestMessage object to the HttpClient object and get the HttpResponseMessage object.
                    HttpResponseMessage response = await client.SendAsync(request);

                    // Check the HttpResponseMessage object to see if the request was successful.
                    if (response.IsSuccessStatusCode)
                    {
                        // Deserialize the response content into a ProductResponse objects.
                        string resp = await response.Content.ReadAsStringAsync();
                        productResponse = JsonConvert.DeserializeObject<ProductResponse>(resp);
                        // Sort the List<Products> by title.
                        productResponse.Sort();
                    }
                    return response.IsSuccessStatusCode;
                }
            }

        }
    }
}
