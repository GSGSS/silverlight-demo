using System.ComponentModel;
using System.Windows.Controls;

namespace xaml_binding_to_variable_demo
{
    public partial class MainPage : UserControl, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();

            ClickCount = 0;
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public int ClickCount { get; set; }

        private void clickButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ClickCount += 1;
            NotifyPropertyChanged("ClickCount");
        }
    }
}