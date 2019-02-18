using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace GuestBooker.Controls
{
    public class CustomEntry : Entry
    {
        public CustomEntry()
        {
            // Teclado sin autocompletado o sugerencias
            Keyboard = Keyboard.Create(KeyboardFlags.None);
            
            // Evento cuando cambie el texto
            this.TextChanged += CustomEntryTextChanged;
        }

        // Convierte el texto ingresado a minusculas
        // Si el entry es numerico, verifica que solo haya números
        private void CustomEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            // Viejo valor
            var old = e.OldTextValue;

            // Si es teclado numerico solo se aceptan numeros
            if ((Keyboard == Keyboard.Numeric || Keyboard == Keyboard.Telephone) && (!string.IsNullOrEmpty(e.NewTextValue)))
            {
                if (HasInvalidNumber(e.NewTextValue)) Text = e.OldTextValue;
            }
            else
            {
                // Solo se aceptan minusculas
                Text = Text.ToLower();
            }
        }

        // Regresa true si no es numero
        bool HasInvalidNumber(string cad) => cad.Any(c => char.IsLetter(c) || char.IsSymbol(c) || char.IsWhiteSpace(c) || char.IsPunctuation(c));
    }
}
