using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using ContactsApp.Droid.PhoneCaller;
using ContactsApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Dependency(typeof(PhoneCallerDroid))]
namespace ContactsApp.Droid.PhoneCaller
{
    internal class PhoneCallerDroid : IPhoneCaller
    {
        public bool CallNumber(string phoneNumber)
        {
            Intent phoneIntent = new Intent(Intent.ActionCall);

            phoneIntent.SetData(Android.Net.Uri.Parse($"tel:{phoneNumber}"));
            phoneIntent.SetFlags(Android.Content.ActivityFlags.NewTask);
            try
            {
                Android.App.Application.Context.StartActivity(phoneIntent);
            }
            catch (Exception)
            {
                //Should be logged
                return false;
            }

            return true;
        }


    }
}