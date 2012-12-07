using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ria_association_domain_service.Web;

namespace ria_association_domain_service
{
    public partial class RecordForm : ChildWindow
    {
        public Record CurrentRecord { get; set; }

        public RecordForm(Record record)
        {
            InitializeComponent();
            CurrentRecord = record;
            recordDataForm.CurrentItem = CurrentRecord;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            recordDataForm.CommitEdit();
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentRecord = null;
            recordDataForm.CancelEdit();
            this.DialogResult = false;
        }

        public void EnableFieldEdit()
        {
            
        }
    }
}

