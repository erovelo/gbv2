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
        private bool NotAnimate = false;

        public LoginPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if(!NotAnimate) AnimationInitAsync();
        }

        // Animacion del logo inicial
        private async Task AnimationInitAsync()
        {
            NotAnimate = true;

            // Show logo
            await Task.Delay(2000);

            // Posicionando el logo en el centro
            var w = (Application.Current.MainPage.Width / 2f) - 200;
            LogoImg.TranslationX = w;

            // Mostrando y moviendo logo
            await LogoImg.FadeTo(1, 1200, Easing.SinIn);
            await LogoImg.TranslateTo(0, 0, 1000);

            // Mostrando controles
            BgDark.FadeTo(0.5, 1200);
            Logins.FadeTo(1, 1200);

            // Move logo to left
            /*
            var MoveLogoAnimation = new Animation(v => ColLogoSpacing.Width = new GridLength(v,GridUnitType.Star), 1, 0);
            MoveLogoAnimation.Commit(this, "MoveLogoAnimation", 20, 1000, Easing.Linear, (v, c) => 
            {
                // Mostrar login
                BgDark.FadeTo(0.5, 1200);
                Logins.FadeTo(1, 1200);
            });
            */
        }
    }
}
