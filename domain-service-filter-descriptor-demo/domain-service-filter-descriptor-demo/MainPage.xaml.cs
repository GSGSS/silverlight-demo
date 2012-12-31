using System.Windows;
using System.Windows.Controls;
using domain_service_filter_descriptor_demo.Web;

namespace domain_service_filter_descriptor_demo
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BookDataSource_OnLoadedData(object sender, LoadedDataEventArgs e)
        {
            var context = bookDataSource.DomainContext as LibraryDomainContext;
            MessageBox.Show(context.Books.Count.ToString());
        }
    }
}