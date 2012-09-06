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
using mode_check_demo.MyDataService;

namespace mode_check_demo
{
    public partial class Data : UserControl
    {
        public Data()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                var client = new MyDataServiceSoapClient();
                client.GetDataCompleted += (s, args) => displayBox.Text = args.Result;
                client.GetDataAsync();
            }
        }
    }
}