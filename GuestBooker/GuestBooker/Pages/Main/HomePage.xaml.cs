using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuestBooker.Pages.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            //cv.ItemsSource = new List<int>() { 1, 1, 1, 1, 1, };
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //cv.AnimateTransition = false;
            cv.Position = 4;
        }
    }
}
