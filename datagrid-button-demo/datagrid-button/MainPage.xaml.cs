using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace datagrid_button
{
    public partial class MainPage : UserControl
    {
        private ObservableCollection<NumberItem> items;

        public MainPage()
        {
            InitializeComponent();
            InitItems();
            numberGrid.ItemsSource = items;
        }

        private void InitItems()
        {
            List<NumberItem> numberItems = new List<NumberItem>();
            numberItems.Add(new NumberItem {Number = 3});
            numberItems.Add(new NumberItem {Number = 4});
            items = new ObservableCollection<NumberItem>(numberItems);
        }

        private void Increase_click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var item = button.DataContext as NumberItem;
            item.Number += 1;
            numberGrid.ItemsSource = null;
            numberGrid.ItemsSource = items;
        }
    }

    public class NumberItem
    {
        public int Number { get; set; }
    }
}