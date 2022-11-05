using ContactsApp.DataAccess;
using ContactsApp.Models;
using ContactsApp.Validation;
using ContactsApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ContactsApp.ViewModels
{
    internal class EditContactVM : BaseViewModel
    {
        public ICommand SaveCommand { get; protected set; }
        public ICommand DiscardCommand { get; protected set; }
        public ContactModel EditContact { get; set; }

        IDataAccess<ContactModel> dataAccess;

        //Reference to Model that is been passed in in order to update detail view
        ContactModel contactModel;
        public EditContactVM(ContactModel contact, IDataAccess<ContactModel> dataAccess)
        {
            contactModel = contact;
            EditContact = new ContactModel(contact);
            SaveCommand = new Command(SaveContact);
            this.dataAccess = dataAccess;
        }

        void SaveContact()
        {
            if (!ValidateModel())
                return;

            //Copy new changes from the edit contact model to the origional contactModel
            contactModel.Copy(EditContact);

            //Save changes to disk and navigate back
            dataAccess.SaveItem(EditContact);
            OnBackCalled?.Invoke();
            Application.Current.MainPage.Navigation.PopAsync();
        }

        //Quick validation
        bool ValidateModel()
        {
            //Validate
            if (!ContactModelValidation.NameValidation(EditContact.FirstName))
            {
                Application.Current.MainPage.DisplayAlert("Error", "First Name must have 1 character and contain all letters", "OK");
                return false;
            }

            if (!ContactModelValidation.NameValidation(EditContact.LastName))
            {
                Application.Current.MainPage.DisplayAlert("Error", "Last Name must have 1 character and contain all letters", "OK");
                return false;
            }

            if (!ContactModelValidation.EmailValidation(EditContact.Email, true))
            {
                Application.Current.MainPage.DisplayAlert("Error", "Please enter a valid email address", "OK");
                return false;
            }

            if (!ContactModelValidation.PhoneNumberValidation(EditContact.PhoneNumber, true))
            {
                Application.Current.MainPage.DisplayAlert("Error", "Phone number must have 1 character and contain all letters", "OK");
                return false;
            }
            return true;
        }

    }
}
