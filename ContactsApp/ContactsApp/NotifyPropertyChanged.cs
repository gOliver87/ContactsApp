using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ContactsApp
{
    /// <summary>
    /// Implements INoftifyPropertyChanged and hides warning created by there being no OnPropertyChanged() method
    /// OnPropertyChanged method and calls are injected in using PropertyChanged.fody nuget
    /// </summary>
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67
    }
}
