using System;
namespace GuestBooker.Services.Interfaces
{
    public interface IPageWithParameters
    {
        void InitializeWith(object parameter);
    }
}
