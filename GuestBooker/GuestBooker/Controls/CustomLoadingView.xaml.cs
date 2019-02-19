using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace GuestBooker.Controls
{
    public partial class CustomLoadingView : Grid
    {
        public bool IsRunning { get => (bool)GetValue(IsRunningProperty); set => SetValue(IsRunningProperty, value); }
        public static readonly BindableProperty IsRunningProperty = BindableProperty.Create(
            nameof(IsRunning),
            typeof(bool),
            typeof(CustomLoadingView),
            false
        );

        public CustomLoadingView()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if(propertyName == IsRunningProperty.PropertyName)
            {
                if(IsRunning)
                {
                    IsVisible = true;

                    Indicator.Speed = 0.5f;
                    Indicator.Play();
                    //Indicator.IsRunning = true;
                    this.FadeTo(1, 400);
                }
                else
                {
                    this.FadeTo(0, 400);
                    Indicator.Pause();
                    //Indicator.IsRunning = false;
                    IsVisible = false;
                }
            }
        }
    }
}
