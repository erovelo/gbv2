using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GuestBooker.Views;
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
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //cv.AnimateTransition = false;
            //cv.Position = 4;
        }
    }
}
