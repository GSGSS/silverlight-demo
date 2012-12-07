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

namespace datagrid_cell_display_multiitems_demo
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            List<A> items = new List<A>();
            A a = new A();
            a.Name = "a";
            a.Sub.Add("a1");
            a.Sub.Add("a2");
            a.Sub.Add("a3");
            items.Add(a);
            A b = new A();
            b.Name = "b";
            b.Sub.Add("b1");
//            b.Sub.Add("b2");
//            b.Sub.Add("b3");
            items.Add(b);
            A c = new A();
            c.Name = "c";
            c.Sub.Add("c1");
            c.Sub.Add("c2");
//            c.Sub.Add("c3");
            items.Add(c);
            kiwiDataGrid.ItemsSource = items;


//            kiwiDataGrid.
        }
    }

    public class A
    {
        public A()
        {
            Name = "";
            Sub = new List<string>();
        }

        public String Name { get; set; }
        public List<String> Sub { get; set; }
    }
}
