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

namespace domain_service_auto_refresh_demo
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            countDataSource.RefreshInterval = TimeSpan.FromSeconds(3);
            countDataSource.SubmittedChanges += CountDataSourceOnSubmittedChanges;
            
        }

        private void CountDataSourceOnSubmittedChanges(object sender, SubmittedChangesEventArgs submittedChangesEventArgs)
        {
            if (submittedChangesEventArgs.HasError)
            {
                MessageBox.Show(submittedChangesEventArgs.Error.ToString());

            }
        }

        private void CountDataSource_OnLoadedData(object sender, LoadedDataEventArgs e)
        {
//            MessageBox.Show(countDataSource.CanLoad.ToString());
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            countDataSource.SubmitChanges();
        }
    }
}
