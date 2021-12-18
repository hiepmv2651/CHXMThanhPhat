using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using sql_nhom.Model;

namespace sql_nhom
{
    /// <summary>
    /// Interaction logic for Input1Window.xaml
    /// </summary>
    public partial class Input1Window : Window
    {
        public Input1Window()
        {
            InitializeComponent();
            List = new ObservableCollection<HOADONNHAP>(DataProvider.Ins.DB.HOADONNHAPs);
            list.ItemsSource = List;

            searchall.ItemsSource = List;
        }

        public ObservableCollection<HOADONNHAP> List { get; }
    }
}
