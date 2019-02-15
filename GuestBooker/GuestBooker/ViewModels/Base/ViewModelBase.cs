using System;
using System.Threading.Tasks;
using GuestBooker.Services.Interfaces;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace GuestBooker.ViewModels.Base
{
    public abstract class ViewModelBase : ExtendedBindableObject
    {
        protected readonly IDialogService DialogService;
        protected readonly INavigationService NavigationService;

        private bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        private bool _isEnable;
        public bool IsEnable
        {
            get
            {
                return _isEnable;
            }

            set
            {
                _isEnable = value;
                RaisePropertyChanged(() => IsEnable);
            }
        }

        public ViewModelBase()
        {
            DialogService = ViewModelLocator.Instance.Resolve<IDialogService>();
            NavigationService = ViewModelLocator.Instance.Resolve<INavigationService>();
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }


        public async Task<PermissionStatus> RequestPermission(Permission permission, string title, string message, string titleDenied)
        {

            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(permission);
            if (status == PermissionStatus.Denied)
            {
                //await DialogService.ShowAlertAsync(message, titleDenied, AppResources.OkButtonLabel);
                CrossPermissions.Current.OpenAppSettings();
            }
            else if (status == PermissionStatus.Unknown)
            {
                if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(permission))
                {
                    //await DialogService.ShowAlertAsync(message, title, AppResources.OkButtonLabel);
                }

                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { permission });
                status = results[permission];
            }
            return status;
        }
    }
}
