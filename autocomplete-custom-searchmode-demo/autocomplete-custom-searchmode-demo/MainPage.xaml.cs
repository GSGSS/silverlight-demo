using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using autocomplete_custom_searchmode_demo.PersonService;

namespace autocomplete_custom_searchmode_demo
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            wordAutoCompleteBox.ItemFilter = (search, item) =>
            {
                Person person = item as Person;
                if (person != null)
                {
                    return person.FirstName.Contains(search);
                }
                return false;
            };
        }

        private void WordAutoCompleteBox_OnPopulating(object sender, PopulatingEventArgs e)
        {
            var client = new PersonServiceSoapClient();
            client.GetPersonsCompleted += GetPersonsCompleted;
            client.GetPersonsAsync();
        }

        private void GetPersonsCompleted(object sender, GetPersonsCompletedEventArgs e)
        {
            wordAutoCompleteBox.ItemsSource = e.Result;
            wordAutoCompleteBox.PopulateComplete();
        }
    }


}