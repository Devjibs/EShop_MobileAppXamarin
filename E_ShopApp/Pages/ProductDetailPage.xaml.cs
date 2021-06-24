using E_ShopApp.Models;
using E_ShopApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_ShopApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailPage : ContentPage
    {
        private int _productId;
        public ProductDetailPage(int productId)
        {
            InitializeComponent();
            GetProductDetails(productId);
            _productId = productId;
        }

        private async void GetProductDetails(int productId)
        {
            var product = await ApiService.GetProductById(productId);
            LblName.Text = product.name;
            LblDetail.Text = product.detail;
            ImgProduct.Source = product.FullImageUrl;
            LblPrice.Text = product.price.ToString();
            LblTotalPrice.Text = LblPrice.Text;
        }

        private void TapIncrement_Tapped(object sender, EventArgs e)
        {
            var total = Convert.ToInt16(LblQty.Text);
            total++;
            LblQty.Text = total.ToString();
            LblTotalPrice.Text = (Convert.ToInt16(LblQty.Text) * Convert.ToInt16(LblPrice.Text)).ToString();
        }

        private void TapDecrement_Tapped(object sender, EventArgs e)
        {
            var total = Convert.ToInt16(LblQty.Text);
            total--;
            if(total < 1)
            {
                return;
            }
            LblQty.Text = total.ToString();
            LblTotalPrice.Text = (Convert.ToInt16(LblQty.Text) * Convert.ToInt16(LblPrice.Text)).ToString();
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void BtnAddToCart_Clicked(object sender, EventArgs e)
        {
            var addToCart = new AddToCart();
            addToCart.Qty = LblQty.Text;
            addToCart.Price = LblPrice.Text;
            addToCart.TotalAmount = LblTotalPrice.Text;
            addToCart.ProductId = _productId;
            addToCart.CustomerId = Preferences.Get("userId", 0);

            var response = await ApiService.AddItemsInCart(addToCart);
            if (response)
            {
                await DisplayAlert("Well Done", "Items Added to cart successfully", "Great!");
            }
            else
            {
                await DisplayAlert("uhm", "Unable to add Items to your cart", "okay?");
            }
        }
    }
}