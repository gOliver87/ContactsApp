using ContactsApp.DataAccess;
using ContactsApp.Models;
using ContactsApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ContactsApp.ViewModels
{
    internal class ContactsListVM : BaseViewModel
    {
        public ObservableCollection<SubContactList> GroupedContacts { get; set; }

        ContactGroups contactGroups;
        public string SearchText { get; set; }
        public ICommand AddNewCommand { get; set; }
        public ContactsListVM(IDataAccess<ContactModel> dataAccess)
        {
            ReLoadContacts();
            AddNewCommand = new Command(AddNew);
            contactGroups = new ContactGroups(dataAccess);
        }

        void ReLoadContacts()
        {
            Task.Run(() =>
            {
                var contactGroupList = contactGroups.GetGroupedItems(SearchText);
                MainThread.InvokeOnMainThreadAsync(() =>
                {
                    GroupedContacts = contactGroupList;
                });
            });
        }

        void OnSearchTextChanged()
        {
            //Should really search on the items in memory instead of reloading them
            ReLoadContacts();
        }

        ContactModel newContact;
        void AddNew()
        {
            newContact = new ContactModel();
            Application.Current.MainPage.Navigation.PushAsync(new EditContact(newContact, false, NewContactAdded));
        }

        void NewContactAdded()
        {
            //Should really add to the items in memory instead of reloading them
            ReLoadContacts();
        }
    }
}
