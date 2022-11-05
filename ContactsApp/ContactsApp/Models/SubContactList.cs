using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ContactsApp.Models
{
    /// <summary>
    /// Part of the contact list once its been split by first letter
    /// </summary>
    internal class SubContactList : ObservableCollection<ContactModel>
    {
        public string Heading { get; set; }
        public ObservableCollection<ContactModel> Contacts => this;
    }
}
