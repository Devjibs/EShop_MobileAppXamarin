using E_ShopApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_ShopApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            if (!EntPassword.Text.Equals(EntConfirmPassword.Text))
            {
                await DisplayAlert("Passwords do not match", "Please check again to confirm password", "okay");
            }
            else
            {
                var response = await ApiService.RegisterUser(EntName.Text, EntEmail.Text, EntPassword.Text);
                if (response)
                {
                    await DisplayAlert("Congratulations !", "Your Account has been successfully created", "Great!");
                    await Navigation.PushModalAsync(new LoginPage());
                }
                else
                {
                    await DisplayAlert("Oops !", "We couldn't register you", "Cancel");
                }
            }
            
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}