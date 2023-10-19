using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartApp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// Main Window
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Call this function when main window is up and running.
        /// </summary>
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //check for internet avaliability
            if (!await IsInternetAvailable())
            {
                MessageBox.Show("No internet connection.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // load the categories
            if (!await InitializeServices())
            {
                MessageBox.Show("Can't connect to server.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        /// <summary>
        /// check internet from google.
        /// </summary>
        /// <returns>bool true on success.</returns>
        public async Task<bool> IsInternetAvailable()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    // You can use any valid URL to make a simple GET request
                    HttpResponseMessage response = await httpClient.GetAsync("https://www.google.com");
                    return response.IsSuccessStatusCode;
                }
            }
            catch (HttpRequestException)
            {
                // An exception is thrown if there is no internet connection or if the request fails.
                return false;
            }
        }
        /// <summary>
        /// Download the categories
        /// </summary>
        public async Task<bool> InitializeServices()
        {
            CategoryService categoryService = new CategoryService();
            // fill the categories model
            if (!await categoryService.FillCategories())
                return false;
            // Populate the CategoryListViewModel class with the list of Category objects.
            CategoryListViewModel _categoryListViewModel = new CategoryListViewModel(categoryService.categories);

            // Set the DataContext of the Window to the CategoryListViewModel class.
            CategoriesCombo.DataContext = _categoryListViewModel;

            return true;

        }
        /// <summary>
        /// Load products of a category
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <returns>bool true on success.</returns>
        public async Task<bool> ProductServices(string category)
        {
            ProductService productService = new ProductService(category);
            if (!await productService.FillProducts())
                return false;
            //Populate the ProductListViewModel class with the list of Product objects.
            ProductListViewModel _productListViewModel = new ProductListViewModel(productService.productResponse.Products);

            // Set the DataContext of the Window to the CategoryListViewModel class.
            ProductsCombo.DataContext = _productListViewModel;
            if (DataContext != null)
            {
                ProductDetailViewModel model = DataContext as ProductDetailViewModel;
                if (model != null)
                {
                    model.Erase();
                }
            }
            return true;

        }
        /// <summary>
        /// Load products from an id
        /// </summary>
        /// <param name="id">id of the producty.</param>
        /// <returns>bool true on success.</returns>
        public async Task<bool> ProductDetailServices(int id)
        {
            ProductDetailService productDetailService = new ProductDetailService(id);
            if (!await productDetailService.FillProductDetail())
                return false;
            //Populate the ProductListViewModel class with the list of Product objects.
            ProductDetailViewModel _productDetailViewModel = new ProductDetailViewModel(productDetailService.productDetail);

            // Set the DataContext of the Window to the CategoryListViewModel class.
            DataContext = _productDetailViewModel;
            return true;

        }
        /// <summary>
        /// Event function called when changing category in the combo
        /// </summary>
        private async void CategoriesCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PurshaseButton.IsEnabled = false;
            //retrieve the category selection name
            CategoryViewModel item = CategoriesCombo.SelectedItem as CategoryViewModel;
            if (item != null)
            {
                string category = item.Name;
                //load the category's products
                if (!await ProductServices(category))
                    return;
            }
        }
        /// <summary>
        /// Event function called when changing product in the combo 
        /// and will look for the product details
        /// </summary>
        private async void ProductsCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductViewModel item = ProductsCombo.SelectedItem as ProductViewModel;
            if (item != null)
            {
                int id = item.Id;
                if (!await ProductDetailServices(id))
                    return;
                PurshaseButton.IsEnabled = true;
            }
        }
        /// <summary>
        /// Event function called clicking purshase to open 
        /// the purshase child window
        /// </summary>
        private void PurshaseButton_Click(object sender, RoutedEventArgs e)
        {
            PurshaseWindow purshaseWindow = new PurshaseWindow();
            purshaseWindow.price = PriceLabel.Text;
            purshaseWindow.Owner = this;
            purshaseWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;   
            purshaseWindow.ShowDialog();
        }
    }
}
