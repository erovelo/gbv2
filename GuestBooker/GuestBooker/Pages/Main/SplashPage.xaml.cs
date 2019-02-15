using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GuestBooker.Pages.Main
{
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }
    }
}
