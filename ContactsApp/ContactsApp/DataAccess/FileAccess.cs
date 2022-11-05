using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ContactsApp.DataAccess
{
    /// <summary>
    /// Helper classes for file access
    /// </summary>
    internal class FileAccess
    {
        static string GetApplicationFolder()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
        }

        public static bool FileExists(string filename)
        {
            return File.Exists(Path.Combine(GetApplicationFolder(), filename));
        }

        public static string ReadText(string filename)
        {
            try
            {
                return File.ReadAllText(Path.Combine(GetApplicationFolder(), filename));
            }
            catch (Exception)
            {

            }
            return "";
        }

        public static void WriteTextToFile(string filename, string text)
        {
            try
            {
                File.WriteAllText(Path.Combine(GetApplicationFolder(), filename), text);
            }
            catch (Exception)
            {

            }
        }
    }
}
