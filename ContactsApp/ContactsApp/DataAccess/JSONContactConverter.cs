using ContactsApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ContactsApp.DataAccess
{
    internal class JSONContactConverter
    {
        public static string ConvterToJSON(List<ContactModel> contacts)
        {
                return JsonConvert.SerializeObject(contacts);
        }

        public static List<ContactModel> ConvertToList(string json)
        {
            return JsonConvert.DeserializeObject<List<ContactModel>>(json);
        }

    }
}
