using ContactsApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ContactsApp.DataAccess
{
    /// <summary>
    /// Interface for accessing data
    /// </summary>
    internal interface IDataAccess<T>
    {
        List<T> GetAllItems();
        void SaveToFile(List<T> contacts);
        void SaveItem(T newRecord);
    }
}
