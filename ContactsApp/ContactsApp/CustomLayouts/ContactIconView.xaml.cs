using ContactsApp.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactsApp.CustomLayouts
{
    /// <summary>
    /// Creates a squircle with a random colour and displays a letter inside.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactIconView : ContentView
    {
        static List<Color> Colours = new List<Color>()
        {
            Color.LightBlue,
            Color.LightGreen,
            Color.Lavender,
            Color.Moccasin,
            Color.PaleGoldenrod,
            Color.PaleGreen,
            Color.PaleTurquoise,
            Color.LightCoral,
            Color.LightSalmon,
            Color.LightSkyBlue
        };

        public ContactIconView()
        {
            InitializeComponent();
            Squircle.Fill = Colours[0];
        }

        /// <summary>
        /// Uses the letters to pick a colour
        /// </summary>
        void SetColour()
        {
            try
            {
                var index = LettersToIndexHelper.LettersToIndex(FirstLetter, SecondLetter, Colours.Count);
                Squircle.Fill = Colours[index];
            }
            catch (Exception)
            {
                Squircle.Fill = Colours[0];
            }
        }


        public static readonly BindableProperty FirstLetterProperty = BindableProperty.Create("FirstLetter", typeof(string), typeof(ContactIconView), "",
           propertyChanged: (bindable, oldValue, newValue) =>
           {
               ContactIconView control = (ContactIconView)bindable;
               control.UpdateLabel();
           }
        );
        public string FirstLetter
        {
            get
            {
                return (string)GetValue(FirstLetterProperty);
            }
            set
            {
                SetValue(FirstLetterProperty, value);
            }
        }

        public static readonly BindableProperty SecondLetterProperty = BindableProperty.Create("SecondLetter", typeof(string), typeof(ContactIconView), "",
   propertyChanged: (bindable, oldValue, newValue) =>
   {
       ContactIconView control = (ContactIconView)bindable;
       control.UpdateLabel();
   }
);
        public string SecondLetter
        {
            get
            {
                return (string)GetValue(SecondLetterProperty);
            }
            set
            {
                SetValue(SecondLetterProperty, value);
            }
        }

        public void UpdateLabel()
        {
            DisplayedLabel.Text = $"{FirstLetter}{SecondLetter}";
            SetColour();
        }

        int fontSize;
        public int LabelFontSize
        {
            get
            {
                return fontSize;
            }
            set
            {
                fontSize = value;
                DisplayedLabel.FontSize = value;
            }
        }

    }
}