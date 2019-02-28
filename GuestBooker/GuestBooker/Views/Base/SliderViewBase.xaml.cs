using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuestBooker.Views.Base
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SliderViewBase : Grid
    {
        public ImageSource BackgroundImage { get => cImageBackground.Source; set => cImageBackground.Source = value; } //Imagen de fondo
        public View Header { get => ContentHeader.Content; set => ContentHeader.Content = value; } //Contenido de cabecera
        public View Content { get => ContentSlider.Content; set => ContentSlider.Content = value; } //Contenido del slider

        // Contenido del slider

        public SliderViewBase()
        {
            InitializeComponent();
        }
    }
}
