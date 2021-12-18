using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceProcess;
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
using DocumentFormat.OpenXml.Spreadsheet;
using sql_nhom.Model;

namespace sql_nhom
{
    /// <summary>
    /// Interaction logic for BaoHanhWindow.xaml
    /// </summary>
    public partial class BaoHanhWindow : Window
    {
        public ObservableCollection<BAOHANH> List { get; }

        public BaoHanhWindow()
        {
            InitializeComponent();
            List = new ObservableCollection<BAOHANH>(DataProvider.Ins.DB.BAOHANHs);
            list.ItemsSource = List;

            searchall.ItemsSource = List;
        }


        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExport_Click_1(object sender, RoutedEventArgs e)
        {
          
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
    }
}