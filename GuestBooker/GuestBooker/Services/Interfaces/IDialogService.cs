using System;
using System.Threading.Tasks;

namespace GuestBooker.Services.Interfaces
{
    public interface IDialogService
    {
        Task ShowAlertAsync(string message, string title, string buttonLabel);
        Task<bool> ShowConfirmAsync(string message, string title, string buttonOkLabel, string buttonCancelLabel);
    }
}
