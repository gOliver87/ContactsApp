using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactsApp.ViewModels
{
    /// <summary>
    /// Base class for view models that implements notifypropertychanged and default back command
    /// </summary>
    internal class BaseViewModel : NotifyPropertyChanged
    {
        public Action OnBackCalled { get; set; }
        public ICommand BackCommand { get; private set; }

        public BaseViewModel()
        {
            BackCommand = new Command(Back);
        }

        protected virtual void Back()
        {
            OnBackCalled?.Invoke();
            Application.Current.MainPage.Navigation.PopAsync();
        }

    }
}
