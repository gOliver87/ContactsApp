using ContactsApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ContactsApp.Models
{
    /// <summary>
    /// Handles getting list of contact models and creating groups
    /// </summary>
    internal class ContactGroups
    {
        IDataAccess<ContactModel> dataAccess;

        ObservableCollection<SubContactList> contactModels;

        public ContactGroups(IDataAccess<ContactModel> dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public ObservableCollection<SubContactList> GetGroupedItems(string search)
        {
            var items = dataAccess.GetAllItems();

            //perform search
            if (!string.IsNullOrWhiteSpace(search))
                items = items.Where(x => x.FirstName.StartsWith(search, StringComparison.OrdinalIgnoreCase)
                || x.LastName.StartsWith(search, StringComparison.OrdinalIgnoreCase)).ToList();

            //sort by first name
            SortListByFirstName(items);

            var groupedContacts = CreateGroupList(items);
            return groupedContacts;
        }

        void SortListByFirstName(List<ContactModel> contacts)
        {
            try
            {
                contacts.Sort((a, b) => a.FirstName.CompareTo(b.FirstName));
            }
            catch (Exception)
            {
                //Should be logged/handled
            }
        }

        ObservableCollection<SubContactList> CreateGroupList(List<ContactModel> contacts)
        {
            var groupedContacts = new ObservableCollection<SubContactList>();
            foreach (var contact in contacts)
            {
                //Ignore contacts with null names
                if (contact.FirstName == null)
                    continue;

                //Get first letter
                var firstLetter = " "; //Default is blank
                    if (contact.FirstName.Length >0)
                        firstLetter = contact.FirstName.Substring(0, 1);
                
                //Check if subcontactlist exists, if not create it
                var list = groupedContacts.Where(x => x.Heading.ToLower() == firstLetter.ToLower()).FirstOrDefault();
                if (list == null)
                {
                    list = new SubContactList() { Heading = firstLetter.ToUpper() };
                    groupedContacts.Add(list);
                }
                list.Add(contact);
            }
            return groupedContacts;
        }
    }
}
