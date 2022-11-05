using ContactsApp.Helpers;
using ContactsApp.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsAppTests.Validation
{
    internal class ContactModelValidationTests
    {
        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase("G", true)]
        [TestCase("George", true)]
        [TestCase("5", false)]
        [TestCase("George54", false)]
        public void NameValidation_ShouldPass(string input, bool expected)
        {
            var actual = ContactModelValidation.NameValidation(input);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
