using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApp
{
    /// <summary>
    ///  View model for category.
    /// </summary>
    internal class CategoryViewModel
    {
        public string Name { get; set; }
        public CategoryViewModel(string category)
        {
            Name = category;
        }
    }
}
