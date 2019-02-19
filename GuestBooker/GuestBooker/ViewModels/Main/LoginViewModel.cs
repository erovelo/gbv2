using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GuestBooker.ViewModels.Base;
using Xamarin.Forms;

namespace GuestBooker.ViewModels.Main
{
    public class LoginViewModel : ViewModelBase
    {
        // Pos del cv de formulario
        public int PosCV { get; set; }

        #region Commands
        public ICommand LoginAccessCodeCommand => new Command(async () => LoginAccessCode());
        private async Task LoginAccessCode()
        {
            IsBusy = true;
            await Task.Delay(5000);
            IsBusy = false;
        }
        #endregion


        public ICommand TestCommand => new Command(() => PosCV = 1);
    }
}
