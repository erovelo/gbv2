using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GuestBooker.ViewModels.Base;
using Xamarin.Forms;

namespace GuestBooker.ViewModels.Main
{
    public class LoginViewModel : ViewModelBase
    {
        public int PosCV { get; set; } // Pos del CV de formulario

        public bool IsShowingAccessCode { get; set; } // Vista de AccessCode
        public bool IsShowingMailPass { get; set; } // Vista de MailPass
        public bool IsShowingConceptBranch{ get; set; } // Vista de Concepto y Sucursal
        public bool IsShowingRecoverPassword { get; set; } // Vista Recuperar contraseña

        #region Commands
        // Se manda para mostrar la vista de accesscode
        public ICommand ShowLoginCommand => new Command(async () => ShowLoginView());
        private async Task ShowLoginView()
        {
            PosCV = 0;
        }

        // Se manda para mostrar la vista de concepto y sucursal
        public ICommand ShowConceptBranchViewCommand => new Command(async () => ShowConceptBranchView());
        private async Task ShowConceptBranchView()
        {
            PosCV = 1;
            IsShowingConceptBranch = true;
            IsShowingRecoverPassword = false;
        }


        // Se manda para mostrar la vista de recuperar contraseña
        public ICommand ShowRecoverPasswordViewCommand => new Command(async () => ShowRecoverPasswordView());
        private async Task ShowRecoverPasswordView()
        {
            PosCV = 1;
            IsShowingConceptBranch = false;
            IsShowingRecoverPassword = true;
        }

        // Se manda a llamar cuando se loguea con su access code
        public ICommand LoginAccessCodeCommand => new Command(async () => LoginAccessCode());
        private async Task LoginAccessCode()
        {
            GoToHomeView();
        }

        // Se manda a llamar cuando se loguea con mail y pass
        public ICommand LoginMailPassCommand => new Command(async () => LoginMailPass());
        private async Task LoginMailPass()
        {
            IsBusy = true;
            IsShowingRecoverPassword = false;
            IsShowingConceptBranch = true;
            PosCV = 1;
            IsBusy = false;
        }

        // Se manda a llamar cuando se selecciona concepto y sucursal
        public ICommand ConceptBranchSelectedCommand => new Command(async () => ConceptBranchSelected());
        private async Task ConceptBranchSelected()
        {
            GoToHomeView();
        }


        // Navega hacia el Home
        private async Task GoToHomeView()
        {
            IsBusy = true;
            await Task.Delay(2000);
            await NavigationService.NavigateToAsync<HomeViewModel>();
            IsBusy = false;
        }
        #endregion
    }
}
