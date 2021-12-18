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
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            List = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
            list.ItemsSource = List;

            searchall.ItemsSource = List;
        }

        public ObservableCollection<NHANVIEN> List { get; }
    }
}
