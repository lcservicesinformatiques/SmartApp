using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// This static class will manage URLS for categories products and product details
/// For a real production software It would be better to store this URL data outside the code
/// in IsolatedStorageSettings for example
/// for the exercice i will put it inside the code
/// We could also use Uri instead of strings
/// </summary>
public static class MyUrls
{
    /// <summary>
    /// this variable contains the API base address
    /// </summary>
    private static readonly string _baseUrl = "https://dummyjson.com/products/";
    /// <summary>
    /// this variable contains the API category address
    /// </summary>
    /// <returns>The URL representing the categories.</returns>
    public static string GetCategoryUrl() => _baseUrl + "categories";
    /// <summary>
    /// Constructs the URL for a specific product under the current category.
    /// </summary>
    /// <param name="product">The name of the product.</param>
    /// <returns>The URL representing the product within the current category.</returns>
    public static string GetProductUrl(string category) => _baseUrl + "category" + $"/{category}?select=id,title,thumbnail";
    /// <summary>
    /// Constructs the URL for a specific product details from ID.
    /// </summary>
    /// <param name="productId">The identifier of the product.</param>
    /// <returns>The URL representing the product details from ID.</returns>
    public static string GetProductFromIdUrl(int productId) => _baseUrl + $"{productId}";
}