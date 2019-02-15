using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace GuestBooker.Pages.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Task.Delay(2000);
            LogoImg.FadeTo(1, 4000, Easing.Linear);
        }

        // Animacion del logo inicial
        private async Task AnimationInitAsync()
        {
            //LogoImg.Opacity = 0;
            //await Task.Delay(2000);
            await LogoImg.FadeTo(1, 4000, Easing.Linear);
            
            //var MoveLogoAnimation = new Animation(v => ColLogoSpacing.Width = new GridLength(v, GridUnitType.Star), 1, 0);
            //MoveLogoAnimation.Commit(this, "MoveLogoAnimation", 16, 1000, Easing.Linear);
        }
    }
}
