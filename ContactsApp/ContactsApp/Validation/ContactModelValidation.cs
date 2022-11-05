using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Essentials;

namespace ContactsApp.Validation
{
    /// <summary>
    /// Quick simple validation for the contact model
    /// </summary>
    public class ContactModelValidation
    {
        //Names must be at least 1 letter and all letters
        static public bool NameValidation(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;
            if (name.Length < 1)
                return false;

            return name.All(char.IsLetter);
        }

        //Telephone Numbers must be all numbers and can not be null
        static public bool PhoneNumberValidation(string number, bool allowBlank)
        {
            if (number == null)
                return false;


            if (number.Trim().Length == 0 && allowBlank)
                    return true;

            return number.All(char.IsNumber);
        }

        static public bool EmailValidation(string email, bool allowBlank)
        {
            //Cannot be null
            if (email == null)
                return false;

            //Can be whitespace
            if (email.Trim().Length == 0 && allowBlank)
                return true;

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;
        }

    }
}
