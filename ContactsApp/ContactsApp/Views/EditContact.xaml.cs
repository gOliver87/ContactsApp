using ContactsApp.DataAccess;
using ContactsApp.Models;
using ContactsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace ContactsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditContact : ContentPage
    {
        public EditContact(ContactModel contact, bool isEdit, Action OnBackCalled = null)
        {
            InitializeComponent();
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            Xamarin.Forms.NavigationPage.SetHasBackButton(this, false);
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);


            var vm = new EditContactVM(contact, new ContactDataAccess());
            vm.OnBackCalled += OnBackCalled;
            BindingContext = vm;

            TitleLabel.Text = isEdit ? "Edit Contact" : "Add Contact";
        }
    }
}