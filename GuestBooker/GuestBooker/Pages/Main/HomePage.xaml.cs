using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GuestBooker.Pages.Main
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }
    }
}
