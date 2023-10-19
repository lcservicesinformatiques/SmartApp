using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApp
{
    /// <summary>
    ///  View model for Product.
    /// </summary>
    internal class ProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public ProductViewModel(Product product)
        {
            Id = product.Id;
            Title = product.Title;
            Thumbnail = product.Thumbnail;            
        }
    }
}
