using ContactsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Shapes;
using Xamarin.Forms;

namespace ContactsApp.DataAccess
{
    internal class MockContactData
    {
        //Method to check if contacts file exists. If it does not it will add some test data
        public static void MockData()
        {
            if (!FileAccess.FileExists(ContactDataAccess.Filename))
            {
                //Should be read in from a file really
                List<ContactModel> records = new List<ContactModel>();

                records.Add(new ContactModel() { ID = 0, FirstName = "Graham ", LastName = "Mcmahon", Email = "email@email.com", PhoneNumber = "01234567890" });
                records.Add(new ContactModel() { ID = 1, FirstName = "Amy", LastName = "Golding", Email = "email@email.com", PhoneNumber = "01234567890" });
                records.Add(new ContactModel() { ID = 2, FirstName = "Elizabeth", LastName = "Cameron", Email = "email@email.com", PhoneNumber = "01234567890" });
                records.Add(new ContactModel() { ID = 3, FirstName = "Jeremy", LastName = "Lindsey", Email = "email@email.com", PhoneNumber = "01234567890" });
                records.Add(new ContactModel() { ID = 4, FirstName = "Clara", LastName = "Gregory", Email = "email@email.com", PhoneNumber = "01234567890" });
                records.Add(new ContactModel() { ID = 5, FirstName = "Neil", LastName = "Redman", Email = "email@email.com", PhoneNumber = "01234567890" });
                records.Add(new ContactModel() { ID = 6, FirstName = "Simon", LastName = "Huber", Email = "email@email.com", PhoneNumber = "01234567890" });
                records.Add(new ContactModel() { ID = 7, FirstName = "Kate", LastName = "Lane", Email = "email@email.com", PhoneNumber = "01234567890" });
                records.Add(new ContactModel() { ID = 8, FirstName = "Holly", LastName = "Price", Email = "email@email.com", PhoneNumber = "01234567890" });
                records.Add(new ContactModel() { ID = 9, FirstName = "Miranda", LastName = "Brown", Email = "email@email.com", PhoneNumber = "01234567890" });
                records.Add(new ContactModel() { ID = 10, FirstName = "Debra", LastName = "Parkinson", Email = "email@email.com", PhoneNumber = "01234567890" });
                records.Add(new ContactModel() { ID = 10, FirstName = "Adam", LastName = "Richardson", Email = "email@email.com", PhoneNumber = "01234567890" });
                records.Add(new ContactModel() { ID = 11, FirstName = "Stacey", LastName = "Hunt", Email = "email@email.com", PhoneNumber = "01234567890" });
                records.Add(new ContactModel() { ID = 12, FirstName = "Daniel", LastName = "Askew", Email = "email@email.com", PhoneNumber = "01234567890" });
                records.Add(new ContactModel() { ID = 13, FirstName = "Kevin", LastName = "Jones", Email = "email@email.com", PhoneNumber = "01234567890" });
                records.Add(new ContactModel() { ID = 14, FirstName = "Mathew", LastName = "Mallows", Email = "email@email.com", PhoneNumber = "01234567890" });
                records.Add(new ContactModel() { ID = 15, FirstName = "Jack", LastName = "Broadbent", Email = "email@email.com", PhoneNumber = "01234567890" });

                new ContactDataAccess().SaveToFile(records);
            }
        }






    }
}
