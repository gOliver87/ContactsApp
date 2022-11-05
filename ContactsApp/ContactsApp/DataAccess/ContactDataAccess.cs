using ContactsApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ContactsApp.DataAccess
{
    internal class ContactDataAccess : IDataAccess<ContactModel>
    {
        public static string Filename => "Contacts.txt";

        public List<ContactModel> GetAllItems()
        {
            var jsonString = FileAccess.ReadText(Filename);
            var records = JSONContactConverter.ConvertToList(jsonString);
            return records;
        }

        public void SaveToFile(List<ContactModel> contacts)
        {
            string json = JSONContactConverter.ConvterToJSON(contacts);
            FileAccess.WriteTextToFile(Filename, json);
        }

        //ContactModel could inherit from interface with ID in it. Then this method could be abstracted out so it can be used with other models
        public void SaveItem(ContactModel newRecord)
        {
            var records = GetAllItems();
            var record = records.FirstOrDefault(x => x.ID == newRecord.ID);
            //If record exists, else add as new one
            if (record != null)
            {
                ReplaceRecord(records, record, newRecord);
            }
            else
            {
                AddNewRecord(records, newRecord);
            }
            SaveToFile(records);
        }

        void ReplaceRecord(List<ContactModel> records, ContactModel existingRecord, ContactModel newRecord)
        {
            //Replace old record with new
            var index = records.IndexOf(existingRecord);
            records[index] = newRecord;
        }

        void AddNewRecord(List<ContactModel> records, ContactModel newRecord)
        {
            //Get highest ID
            var max = records.Max(x => x.ID);
            newRecord.ID = max + 1;
            records.Add(newRecord);
        }
    }
}
