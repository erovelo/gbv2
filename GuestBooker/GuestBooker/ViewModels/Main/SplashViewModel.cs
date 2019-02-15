using System;
using System.Threading.Tasks;
using GuestBooker.ViewModels.Base;
using Xamarin.Forms;

namespace GuestBooker.ViewModels.Main
{
    public class SplashViewModel : ViewModelBase
    {
        public SplashViewModel()
        {
        }

        #region Setup View
        public override async Task InitializeAsync(object navigationData)
        {
            //userCode = Settings.UserGuid;
            Task<int> result = OnStart();
        }
        #endregion


        #region Loading
        private async Task<int> OnStart()
        {
            try
            {
                await Task.Delay(500);
                await NavigationService.NavigateToAsync<LoginViewModel>(); // NAVEGA HACIA LOGIN
            }
            catch (Exception ex)
            {
                string error = ex.Message + ex.StackTrace;
                await Application.Current.MainPage.DisplayAlert("Error", $"{error}", "Accept");
            }
            return 0;
        }
        #endregion
    }
}
