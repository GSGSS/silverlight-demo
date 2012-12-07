using System;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
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
            var register = new Register {name = nameTextBox.Text, status = "Wait"};
            var context = guardDataSource.DomainContext as RegisterDomainContext;
            context.Registers.Add(register);
            guardDataSource.SubmitChanges();
        }

        private void AcceptButton_OnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var register = button.DataContext as Register;
            register.status = "Accept";
            officerDataSource.SubmitChanges();
        }

        private void GuardDataSource_OnLoadingData(object sender, LoadingDataEventArgs e)
        {
            e.LoadBehavior = LoadBehavior.MergeIntoCurrent;
        }

        private void GuardDataSource_OnLoadedData(object sender, LoadedDataEventArgs e)
        {
            foreach (var entity in e.Entities)
            {
                Register register = entity as Register;
            }
        }
    }
}

namespace domain_service_duplex_by_auto_refresh_demo.Web
{
    public partial class Register
    {
        partial void OnstatusChanged()
        {
            RaisePropertyChanged("CanRegister");
        }
        public bool CanRegister { get { return status == "Accept"; } }
    }
}