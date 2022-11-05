using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ContactsApp.Helpers
{
    internal class PermissionHelper
    {
        static public async Task<bool> CheckAndRequestPhonePermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.Phone>();

            if (status == PermissionStatus.Granted)
                return true;

            if (await Permissions.RequestAsync<Permissions.Phone>() == PermissionStatus.Granted)
                return true;

            return false;
        }
    }
}
