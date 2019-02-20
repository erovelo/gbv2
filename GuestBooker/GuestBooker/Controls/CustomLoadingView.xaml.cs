using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuestBooker.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
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
                if (IsRunning) ShowLoadingAsync();
                else HideLoadingAsync();
            }
        }

        async Task ShowLoadingAsync()
        {
            IsVisible = true;
            Indicator.Speed = 0.5f;
            Indicator.Play();
            await this.FadeTo(1, 200);
        }

        async Task HideLoadingAsync()
        {
            await this.FadeTo(0, 200);
            Indicator.Pause();
            IsVisible = false;
        }
    }
}
