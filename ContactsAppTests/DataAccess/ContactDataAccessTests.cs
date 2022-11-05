using ContactsApp.DataAccess;
using ContactsApp.Models;

namespace ContactsAppTests.DataAccess
{
    internal class ContactDataAccessTests
    {
        ContactDataAccess dataAccess;
        [SetUp]
        public void Init()
        {
            dataAccess = new ContactDataAccess();
        }

        [Test]
        public void ReplaceRecord_ShouldPass()
        {
            var contacts = MockContactData.GetShortList();
            var newContact = new ContactModel() { ID = 1, FirstName = "New", LastName = "Contact", Email = "email@email.com", PhoneNumber = "01234567890" };

            dataAccess.ReplaceRecord(contacts, contacts[1], newContact);

            Assert.IsTrue(contacts.Count == 3);
            Assert.IsTrue(contacts.Contains(newContact));
        }

        [Test]
        public void AddRecord_ShouldPass()
        {
            var contacts = MockContactData.GetShortList();
            var newContact = new ContactModel() { FirstName = "New", LastName = "Contact", Email = "email@email.com", PhoneNumber = "01234567890" };

            dataAccess.AddNewRecord(contacts, newContact);

            Assert.IsTrue(contacts.Count == 4);
            Assert.IsTrue(contacts.Contains(newContact));
            Assert.IsTrue(newContact.ID == 3);
            Assert.That(contacts[3].FirstName, Is.EqualTo("New"));
        }
    }
}
