using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactsApp.CustomLayouts
{
    /// <summary>
    /// Wraps a tap gesture around anything so it can be used as a button (Existing code I have created before)
    /// </summary>
    class CustomButton : ContentView
    {
        Xamarin.Forms.TapGestureRecognizer tapGestureRecognizer;
        public CustomButton()
        {
            tapGestureRecognizer = new Xamarin.Forms.TapGestureRecognizer();
            tapGestureRecognizer.Tapped += Tapped;
            GestureRecognizers.Add(tapGestureRecognizer);
        }

        private void Tapped(object sender, EventArgs e)
        {
            if (Command != null && Command.CanExecute(null))
                Command.Execute(null);
        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(CustomButton));
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public event EventHandler Clicked
        {
            add
            {
                tapGestureRecognizer.Tapped += value;
            }
            remove
            {
                tapGestureRecognizer.Tapped -= value;
            }
        }
    }
}
