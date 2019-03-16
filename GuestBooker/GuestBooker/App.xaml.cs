using System;
using System.Threading.Tasks;
using DLToolkit.Forms.Controls;
using GuestBooker.Helper;
using GuestBooker.Pages.Main;
using GuestBooker.Services;
using GuestBooker.Services.Interfaces;
using GuestBooker.ViewModels.Base;
using GuestBooker.ViewModels.Main;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GuestBooker
{
    public partial class App : Application
    {
        public static App Instance;

        public App()
        {
            InitializeComponent();
            FlowListView.Init();
            Instance = this;

            if (Xamarin.Forms.Device.iOS == Xamarin.Forms.Device.RuntimePlatform || Xamarin.Forms.Device.Android == Xamarin.Forms.Device.RuntimePlatform)
            {
            }
        }

        protected override async void OnStart()
        {
            // Handle when your app starts
            base.OnStart();
            await InitNavigation();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override async void OnResume()
        {
            // Handle when your app resumes
            var ns = MainPage.Navigation.NavigationStack;
            var np = ns[ns.Count - 1];

            if (np is SplashPage || Utils.ExistsNewVersion())
            {
                INavigationService navigationService = new NavigationService();
                await navigationService.NavigateToAsync<SplashViewModel>();
            }
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Instance.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        public static void Init()
        {
        }
    }
}
