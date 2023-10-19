using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApp
{
    /// <summary>
    ///  View model for ProductDetailViewModel.
    /// </summary>
    internal class ProductDetailViewModel : INotifyPropertyChanged
    {
        private ProductDetail _productDetail;
        public int Id
        {
            get { return _productDetail.Id; }
            set
            {
                if (_productDetail.Id != value)
                {
                    _productDetail.Id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }
        public string Title
        {
            get { return _productDetail.Title; }
            set
            {
                if (_productDetail.Title != value)
                {
                    _productDetail.Title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public string Description
        {
            get { return _productDetail.Description; }
            set
            {
                if (_productDetail.Description != value)
                {
                    _productDetail.Description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public double Price
        {
            get { return _productDetail.Price; }
            set
            {
                if (_productDetail.Price != value)
                {
                    _productDetail.Price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }
        public double DiscountPercentage
        {
            get { return _productDetail.DiscountPercentage; }
            set
            {
                if (_productDetail.DiscountPercentage != value)
                {
                    _productDetail.DiscountPercentage = value;
                    OnPropertyChanged(nameof(DiscountPercentage));
                }
            }
        }
        public double Rating
        {
            get { return _productDetail.Rating; }
            set
            {
                if (_productDetail.Rating != value)
                {
                    _productDetail.Rating = value;
                    OnPropertyChanged(nameof(Rating));
                }
            }
        }
        public int Stock
        {
            get { return _productDetail.Stock; }
            set
            {
                if (_productDetail.Stock != value)
                {
                    _productDetail.Stock = value;
                    OnPropertyChanged(nameof(Stock));
                }
            }
        }
        public string Brand
        {
            get { return _productDetail.Brand; }
            set
            {
                if (_productDetail.Brand != value)
                {
                    _productDetail.Brand = value;
                    OnPropertyChanged(nameof(Brand));
                }
            }
        }
        public string Category
        {
            get { return _productDetail.Category; }
            set
            {
                if (_productDetail.Category != value)
                {
                    _productDetail.Category = value;
                    OnPropertyChanged(nameof(Category));
                }
            }
        }
        public string Thumbnail
        {
            get { return _productDetail.Thumbnail; }
            set
            {
                if (_productDetail.Thumbnail != value)
                {
                    _productDetail.Thumbnail = value;
                    OnPropertyChanged(nameof(Thumbnail));
                }
            }
        }
        public List<string> Images
        {
            get { return _productDetail.Images; }
            set
            {
                if (_productDetail.Images != value)
                {
                    _productDetail.Images = value;
                    OnPropertyChanged(nameof(Images));
                }
            }
        }
        public void Erase()
        {
            Id = -1;
            Title = "";
            Description = "";
            Price = 0;
            DiscountPercentage = 0;
            Rating = 0;
            Stock = 0;
            Brand = "";
            Category = "";
            Thumbnail = "";
            Images = new List<string>() {""};
    }
    // Implement INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ProductDetailViewModel(ProductDetail productDetail)
        {
            _productDetail = productDetail;
        }
    }
}
