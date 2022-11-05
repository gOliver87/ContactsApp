using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsApp.Interfaces
{
    public interface IPhoneCaller
    {
        bool CallNumber(string phoneNumber);
    }
}
