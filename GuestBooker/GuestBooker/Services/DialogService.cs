using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using GuestBooker.Services.Interfaces;

namespace GuestBooker.Services
{
    public class DialogService : IDialogService
    {
        public Task ShowAlertAsync(string message, string title, string buttonLabel)
        {
            return UserDialogs.Instance.AlertAsync(message, title, buttonLabel);
        }

        public Task<bool> ShowConfirmAsync(string message, string title, string buttonOkLabel, string buttonCancelLabel)
        {
            return UserDialogs.Instance.ConfirmAsync(message, title, buttonOkLabel, buttonCancelLabel);
        }
    }
}
