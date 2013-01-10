using System;
using System.Windows.Controls;

namespace datagrid_raidobutton_demo
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}

namespace datagrid_raidobutton_demo.Web
{
    public partial class Book
    {
        private Boolean _isSelected;

        public Boolean IsSelected
        {
            get
            {
                if (_isSelected == null) _isSelected = false;
                return _isSelected;
            }
            set { _isSelected = value; }
        }
    }
}