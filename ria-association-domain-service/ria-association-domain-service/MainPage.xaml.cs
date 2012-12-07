using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ria_association_domain_service.Web;

namespace ria_association_domain_service
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            var ids = new List<string> {"1", "2", "3"};
            idComboBox.ItemsSource = ids;
            idComboBox.SelectedIndex = 0;
        }

        private void ModifyButton_OnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var record = button.DataContext as Record;
            var form = new RecordForm(record);
            form.Closed += (o, args) =>
                               {
                                   var recordForm = o as RecordForm;
                                   if (recordForm.CurrentRecord != null)
                                   {
                                       libraryDataSource.SubmitChanges();
                                   }
                               };
            form.Show();
        }

        private void AddRecordButton_OnClick(object sender, RoutedEventArgs e)
        {
            var form = new RecordForm(new Record());
            form.Closed += (o, args) =>
                               {
                                   var recordForm = o as RecordForm;
                                   Record currentRecord = recordForm.CurrentRecord;
                                   if (currentRecord != null)
                                   {
                                       var libraryContext = libraryDataSource.DomainContext as LibraryContext;
                                       libraryContext.Records.Add(currentRecord);
                                       libraryDataSource.SubmitChanges();
                                   }
                               };
            form.EnableFieldEdit();
            form.Show();
        }

        private void LibraryDataSource_OnSubmittedChanges(object sender, SubmittedChangesEventArgs e)
        {
            if (e.HasError)
            {
                System.Diagnostics.Debug.WriteLine(e.Error.ToString());
                e.MarkErrorAsHandled();
            }
            libraryDataSource.Load();
        }

        private void IdComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (idComboBox == null) return;
            if (idComboBox.SelectionBoxItem == null) return;
//            string text = idComboBox.SelectedValue as string;
            string text = idComboBox.SelectedItem.ToString();
            
//            text = idComboBox as string;
            
            MessageBox.Show(text);
        }
    }
}