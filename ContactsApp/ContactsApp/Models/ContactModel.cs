using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ContactsApp.Models
{
    public class ContactModel : NotifyPropertyChanged
    {
        public int ID { get; set; } = -1;
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";


        public ContactModel()
        {
        }

        public ContactModel(ContactModel other)
        {
            Copy(other);
        }

        public void Copy(ContactModel other)
        {
            ID = other.ID;
            FirstName = other.FirstName;
            LastName = other.LastName;
            Email = other.Email;
            PhoneNumber = other.PhoneNumber;
        }
    }
}
