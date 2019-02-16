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
            AnimationInitAsync();
        }

        // Animacion del logo inicial
        private async Task AnimationInitAsync()
        {
            //LogoImg.Opacity = 0;
            await Task.Delay(2000);
            await LogoImg.FadeTo(1, 1200, Easing.SinIn);
            
            var MoveLogoAnimation = new Animation(v => ColLogoSpacing.Width = new GridLength(v, GridUnitType.Star), 1, 0);
            MoveLogoAnimation.Commit(this, "MoveLogoAnimation", 16, 1000, Easing.SinInOut, (v, c) => 
            {
                BgDark.FadeTo(0.5, 1200);
                Logins.FadeTo(1, 1200);
            });
        }
    }
}
