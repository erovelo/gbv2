using System;
using Xamarin.Forms;

namespace GuestBooker.Services.Interfaces
{
    public interface IBaseUrl
    {
        string Get();
        string Acquire();
        HtmlWebViewSource GetHTML();
    }
}
