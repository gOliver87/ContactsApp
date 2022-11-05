using ContactsApp.DataAccess;
using ContactsApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactsApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MockContactData.MockData();
            MainPage = new NavigationPage(new ContactsList());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
