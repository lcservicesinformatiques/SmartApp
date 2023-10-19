using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApp
{
    /// <summary>
    /// List View Model class for categories.
    /// </summary>
    internal class CategoryListViewModel
    {
        public ObservableCollection<CategoryViewModel> Categories { get; set; }
        public CategoryListViewModel(List<string> categories)
        {
            Categories = new ObservableCollection<CategoryViewModel>();
            foreach (string category in categories)
            {
                Categories.Add(new CategoryViewModel(category));
            }
        }
    }
}
