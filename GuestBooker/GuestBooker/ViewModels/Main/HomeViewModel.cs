using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using GuestBooker.Models;
using GuestBooker.ViewModels.Base;
using Xamarin.Forms;

namespace GuestBooker.ViewModels.Main
{
    public class HomeViewModel : ViewModelBase
    {
        public bool ShowDetail { get; set; }
        public ObservableCollection<SelectableItem<object>> ItemsTest { get; set; }

        public HomeViewModel()
        {
            ShowDetail = true;

            ItemsTest = new ObservableCollection<SelectableItem<object>>();

            for (int i = 0; i < 10; i++)
            {
                ItemsTest.Add(new SelectableItem<object>() { IsOdd = !(i % 2 == 0) });
            }

            ItemsTest[1].IsSelected = true;
        }

        // Cambiar
        public ICommand HideShowDetailCommand => new Command(async () => HideShowDetail());
        public async Task HideShowDetail()
        {
            ShowDetail = !ShowDetail;
        }
    }
}
