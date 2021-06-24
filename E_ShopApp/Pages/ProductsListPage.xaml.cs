using E_ShopApp.Models;
using E_ShopApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_ShopApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsListPage : ContentPage
    {
        public ObservableCollection<ProductByCategory> ProductsByCategoryCollection;
        public ProductsListPage(int categoryId, string categoryName)
        {
            InitializeComponent();
            LblCategoryName.Text = categoryName;
            GetProducts(categoryId);
        }

        private async void GetProducts(int id)
        {
            var products = await ApiService.GetProductByCategory(id);
            foreach(var product in products)
            {
                ProductsByCategoryCollection.Add(product);
            }
            CvProducts.ItemsSource = ProductsByCategoryCollection;
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void CvProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelection = e.CurrentSelection.FirstOrDefault() as ProductByCategory;
            if (currentSelection == null) return;
            Navigation.PushModalAsync(new ProductDetailPage(currentSelection.id));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}