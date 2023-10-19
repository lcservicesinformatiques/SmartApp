using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SmartApp
{
    /// <summary>
    /// Web Api cient for categories.
    /// </summary>
    internal class CategoryService
    {
        public List<string> categories { get; private set; }
        public async Task<bool> FillCategories()
        {
            // Create a new HttpClient object.
            using (HttpClient client = new HttpClient())
            {
                // Create a new HttpRequestMessage object with the GET method and the URL of your Web API.
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, MyUrls.GetCategoryUrl()))
                {

                    // Send the HttpRequestMessage object to the HttpClient object and get the HttpResponseMessage object.
                    HttpResponseMessage response = await client.SendAsync(request);

                    // Check the HttpResponseMessage object to see if the request was successful.
                    if (response.IsSuccessStatusCode)
                    {
                        // Deserialize the response content into a list of Category objects.
                        string resp = await response.Content.ReadAsStringAsync();
                        categories = JsonConvert.DeserializeObject<List<string>>(resp);
                        //sort the result for better display
                        categories.Sort();
                    }
                    return response.IsSuccessStatusCode;
                }
            }
        }
    }
}
