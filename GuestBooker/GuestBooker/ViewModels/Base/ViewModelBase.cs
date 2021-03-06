﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GuestBooker.Services.Interfaces;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace GuestBooker.ViewModels.Base
{
    public abstract class ViewModelBase : ExtendedBindableObject
    {
        protected readonly IDialogService DialogService;
        protected readonly INavigationService NavigationService;

        public bool IsBusy { get; set; }

        public bool IsEnable { get; set; }

        public ViewModelBase()
        {
            DialogService = ViewModelLocator.Instance.Resolve<IDialogService>();
            NavigationService = ViewModelLocator.Instance.Resolve<INavigationService>();
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }

        public ICommand TestCommand => new Command(async () => TestFunc());
        private async Task TestFunc()
        {
            var aux = 0;
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
