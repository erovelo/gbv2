using System;
namespace GuestBooker.Models
{
    public class SelectableItem<T>
    {
        public T Data { get; set; }
        public bool IsOdd { get; set; } // Es impar
        public bool IsSelected { get; set; } // Esta seleccionado
    }
}
