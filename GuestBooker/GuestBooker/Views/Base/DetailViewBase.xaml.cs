using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace GuestBooker.Views.Base
{
    public partial class DetailViewBase : Grid
    {
        public double wHidden = 85;
        public double wNotHidden = 420;
        public View ContentPrimary { get => ContentViewPrimary.Content; set => ContentViewPrimary.Content = value; }
        public View ContentDetailSup { get => ContentViewDetailSup.Content; set => ContentViewDetailSup.Content = value; }
        public View ContentDetailInf { get => ContentViewDetailInf.Content; set => ContentViewDetailInf.Content = value; }
        public View ContentMenu { get => ContentViewMenu.Content; set => ContentViewMenu.Content = value; }
        public View ContentSecundary { get => ContentViewSecundary.Content; set => ContentViewSecundary.Content = value; }

        #region Propiedades Binding
        public bool HiddenDetail { get { return (bool)GetValue(HiddenDetailProperty); } set { SetValue(HiddenDetailProperty, value); } }
        public static readonly BindableProperty HiddenDetailProperty =
            BindableProperty.Create(
                nameof(HiddenDetail),
                typeof(bool),
                typeof(DetailViewBase),
                true,
                BindingMode.TwoWay
            );
        #endregion

        #region Constructor
        public DetailViewBase()
        {
            InitializeComponent();
        }
        #endregion

        #region PropertyChanges
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if(propertyName == HiddenDetailProperty.PropertyName)
            {
                // Oculta detalle
                if (HiddenDetail)
                {
                    //BgHembra.TranslationX = 3;
                    var animation = new Animation(v => ColumnDetail.Width = new GridLength(v), wNotHidden, wHidden);
                    animation.Commit(this, "HiddenDetailAnimation", 16, 500, Easing.Linear, (v, c) => {
                        ContentViewDetailSup.IsVisible = false;
                        ContentViewDetailInf.IsVisible = false;
                        //BgHembra.TranslationX = 0;
                    });
                }

                // Muestra
                else
                {
                    ContentViewDetailSup.IsVisible = true;
                    ContentViewDetailInf.IsVisible = true;
                    //BgHembra.TranslationX = 3;
                    var animation = new Animation(v => ColumnDetail.Width = new GridLength(v), wHidden, wNotHidden);
                    animation.Commit(this, "ShowingDetailAnimation", 16, 500, Easing.Linear, (v, c) => {
                        //BgHembra.TranslationX = 0;
                    });
                }
            }
        }
        #endregion
    }
}
