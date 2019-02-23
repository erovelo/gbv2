using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuestBooker.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomPicker : ContentView
    {
        public IList ItemsSource { get { return PickerControl.ItemsSource; } set { PickerControl.ItemsSource = value; } }
        public BindingBase ItemDisplayBinding { get { return PickerControl.ItemDisplayBinding; } set { PickerControl.ItemDisplayBinding = value; } }
        public object SelectedItem { get { return PickerControl.SelectedItem; } set { PickerControl.SelectedItem = value; } }
        public int SelectedIndex { get { return PickerControl.SelectedIndex; } set { PickerControl.SelectedIndex = value; } }

        public CustomPicker()
        {
            InitializeComponent();

        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            //PickerControl.Focus();
        }
    }
}
