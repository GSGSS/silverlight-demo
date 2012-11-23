using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace datagrid_checkbox_demo
{
    public partial class MainPage : UserControl
    {
        private readonly List<Kiwi> selectedKiwis = new List<Kiwi>();

        public MainPage()
        {
            InitializeComponent();
            var kiwis = new List<Kiwi>();
            kiwis.Add(new Kiwi("a"));
            kiwis.Add(new Kiwi("b"));
            kiwis.Add(new Kiwi("c"));
            kiwiDataGrid.ItemsSource = kiwis;
        }

        private void SelectCheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            selectedKiwis.Add(SelectKiwi(sender));
        }

        private void SelectCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            selectedKiwis.Remove(SelectKiwi(sender));
        }

        private static Kiwi SelectKiwi(object sender)
        {
            var checkBox = sender as CheckBox;
            return checkBox.DataContext as Kiwi;
        }

        private void SelectButton_OnClick(object sender, RoutedEventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var kiwi in selectedKiwis)
            {
                builder.Append(kiwi.Name + "\n");
            }
            MessageBox.Show(builder.ToString());
        }
    }

    public class Kiwi
    {
        public Kiwi(String name)
        {
            Name = name;
        }

        public String Name { get; set; }
    }
}