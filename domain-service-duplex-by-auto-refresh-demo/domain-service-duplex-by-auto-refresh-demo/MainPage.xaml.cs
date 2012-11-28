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
using domain_service_duplex_by_auto_refresh_demo.Web;

namespace domain_service_duplex_by_auto_refresh_demo
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            guardDataSource.RefreshInterval = TimeSpan.FromSeconds(5);
            officerDataSource.RefreshInterval = TimeSpan.FromSeconds(5);
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register {name = nameTextBox.Text, status = "Wait"};
            RegisterDomainContext context = guardDataSource.DomainContext as RegisterDomainContext;
            context.Registers.Add(register);
            guardDataSource.SubmitChanges();
        }

        private void AcceptButton_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Register register = button.DataContext as Register;
            register.status = "Accept";
            officerDataSource.SubmitChanges();
        }

        private void GuardDataSource_OnLoadingData(object sender, LoadingDataEventArgs e)
        {
            e.LoadBehavior = LoadBehavior.MergeIntoCurrent;
        }
    }
}
