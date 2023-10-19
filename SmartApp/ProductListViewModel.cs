using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApp
{
    /// <summary>
    /// List View Model class for products.
    /// </summary>
    internal class ProductListViewModel
    {
        public ObservableCollection<ProductViewModel> Products { get; set; }
        public ProductListViewModel(List<Product> products)
        {
            Products = new ObservableCollection<ProductViewModel>();
            foreach (Product product in products)
            {
                Products.Add(new ProductViewModel(product));
            }
        }

    }
}
