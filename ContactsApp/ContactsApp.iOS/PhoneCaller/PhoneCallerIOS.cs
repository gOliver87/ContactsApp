using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using CallKit;
using Contacts;
using System.Security.Policy;
using ContactsApp.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(ContactsApp.iOS.PhoneCaller.PhoneCallerIOS))]
namespace ContactsApp.iOS.PhoneCaller
{
    public class PhoneCallerIOS : IPhoneCaller
    {
        public bool CallNumber(string phoneNumber)
        {
            try
            {
                var phoneCallURL = new NSUrl($"tel://{phoneNumber}");
                var application = UIApplication.SharedApplication;
                if (application.CanOpenUrl(phoneCallURL))
                    application.OpenUrl(phoneCallURL);
            }
            catch (Exception)
            {
                //Should be logged and user told.
                return false;
            }

            return true;
        }
    }
}