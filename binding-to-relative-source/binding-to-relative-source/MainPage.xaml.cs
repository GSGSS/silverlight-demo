using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace binding_to_relative_source
{
    public partial class MainPage : UserControl, INotifyPropertyChanged 
    {
        public bool State { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainPage()
        {
            InitializeComponent();

            DataContext = this;

            var kiwis = new List<Kiwi>();
            kiwis.Add(new Kiwi {Name = "a"});
            kiwis.Add(new Kiwi {Name = "b"});
            kiwis.Add(new Kiwi {Name = "c"});
            kiwis.Add(new Kiwi {Name = "d"});

            kiwiDataGrid.ItemsSource = kiwis;

            State = true;
        }

        private void ChangeButton_OnClick(object sender, RoutedEventArgs e)
        {
            State = !State;
            NotifyPropertyChanged("State");
        }
    }

    public class Kiwi
    {
        public String Name { get; set; }
    }
}