using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApp
{
    /// <summary>
    /// Class for Data Product cf API
    /// </summary>

    internal class ProductResponse
    {
        public List<Product> Products { get; set; }
        public int Total { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; }
        // Sort the List<Products> by title.
        public void Sort()
        {
            Products.Sort((x, y) => x.Title.CompareTo(y.Title));
        }

    }
}
