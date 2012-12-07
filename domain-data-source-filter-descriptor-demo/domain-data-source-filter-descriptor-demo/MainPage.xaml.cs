using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace domain_data_source_filter_descriptor_demo
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            smsDataSource.RefreshInterval = TimeSpan.FromSeconds(10);
            smsDataSource.LoadingData += SmsDataSourceOnLoadingData;
        }

        private void SmsDataSourceOnLoadingData(object sender, LoadingDataEventArgs loadingDataEventArgs)
        {
            loadingDataEventArgs.LoadBehavior = LoadBehavior.MergeIntoCurrent;
            smsDataSource.FilterDescriptors.Clear();
            smsDataSource.FilterDescriptors.Add(new FilterDescriptor("time", FilterOperator.IsGreaterThan, DateTime.Today));
        }
    }
}
