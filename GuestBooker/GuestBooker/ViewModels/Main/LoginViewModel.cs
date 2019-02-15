using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GuestBooker.ViewModels.Base;
using Xamarin.Forms;

namespace GuestBooker.ViewModels.Main
{
    public class LoginViewModel : ViewModelBase
    {
        private int _PosCV;
        public int PosCV { get => _PosCV; set { _PosCV = value; RaisePropertyChanged(() => PosCV); } }

        public LoginViewModel()
        {
            //Task<int> result = OnStart();
        }

        #region Loading
        private async Task<int> OnStart()
        {
            try
            {
                await Task.Delay(1000);
                await NavigationService.NavigateToAsync<HomeViewModel>(); // NAVEGA HACIA LOGIN
            }
            catch (Exception ex)
            {
                string error = ex.Message + ex.StackTrace;
                await Application.Current.MainPage.DisplayAlert("Error", $"{error}", "Accept");
            }
            return 0;
        }
        #endregion


        public ICommand TestCommand => new Command(() => PosCV = 2);
    }
}
