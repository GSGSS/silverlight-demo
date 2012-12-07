using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace get_only_property_binding_demo
{
    public partial class MainPage : UserControl
    {
        private readonly List<Kiwi> kiwis;

        public MainPage()
        {
            InitializeComponent();

            kiwis = new List<Kiwi>();
            kiwis.Add(new Kiwi {Original = 1});
            kiwis.Add(new Kiwi {Original = 2});
            kiwis.Add(new Kiwi {Original = 3});

            kiwiDataGrid.ItemsSource = kiwis;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            foreach (Kiwi kiwi in kiwis)
            {
                kiwi.Original += 1;
            }
        }
    }

    public class Kiwi : INotifyPropertyChanged
    {
        private int _original;

        public int Original
        {
            get { return _original; }
            set
            {
                _original = value;
                NotifyPropertyChanged("Original");
                NotifyPropertyChanged("Twice");
            }
        }

        public int Twice
        {
            get { return Original*2; }
        }

        public bool Enable
        {
            get { return Original > 3; }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}