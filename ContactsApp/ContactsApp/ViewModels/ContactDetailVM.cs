using ContactsApp.Helpers;
using ContactsApp.Interfaces;
using ContactsApp.Models;
using ContactsApp.Validation;
using ContactsApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ContactsApp.ViewModels
{
    internal class ContactDetailVM : BaseViewModel
    {
        public ContactModel Contact { get; set; }
        public ICommand CallContactCommand { get; private set; }
        public ICommand EmailContactCommand { get; private set; }
        public ICommand EditContactCommand { get; private set; }

        public ContactDetailVM(ContactModel contact) : base()
        {
            Contact = contact;
            CallContactCommand = new Command(CallContact);
            EmailContactCommand = new Command(EmailContact);
            EditContactCommand = new Command(EditContact);
        }

        async void CallContact()
        {
            //Dont do this on UWP
            if (Device.RuntimePlatform == Device.UWP)
            {
                //Could tell user, or just silently return as they would now know they could phone unless they have used iOS/Android version
                await Application.Current.MainPage.DisplayAlert("Error", "This feature is not available in Windows", "OK");
                return;
            }

            //Check phone number is valid
            if (!ContactModelValidation.PhoneNumberValidation(Contact.PhoneNumber, false))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Not a valid telephone number", "OK");
                return;
            }

            try
            {
                //Use Dependency Injection to make call (could use Xamarin essentials instead)
                if (await PermissionHelper.CheckAndRequestPhonePermission())
                    DependencyService.Get<IPhoneCaller>().CallNumber(Contact.PhoneNumber);
                else
                    await Application.Current.MainPage.DisplayAlert("Warning", "Please allow the app for permission to make calls", "OK");
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error making call", "OK");
            }

        }

        async void EditContact()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EditContact(Contact, true));
        }

        async void EmailContact()
        {
            if (!ContactModelValidation.EmailValidation(Contact.Email, false))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Not a valid email address", "OK");
                return;
            }

            try
            {
                var message = new EmailMessage
                {
                    Subject = "",
                    Body = "",
                    To = new List<string>() { Contact.Email},
                };
                await Email.ComposeAsync(message);
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error sending email", "OK");
            }
        }

        public string FullName
        {
            get
            {
                return $"{Contact.FirstName} {Contact.LastName}";
            }
        }

    }
}
