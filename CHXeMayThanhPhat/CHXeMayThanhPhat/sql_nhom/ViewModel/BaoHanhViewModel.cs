using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.Win32;
using OpenQA.Selenium.Chrome;
using sql_nhom.Model;

namespace sql_nhom.ViewModel
{
    public class BaoHanhViewModel : BaseViewModel 
    {
        private ObservableCollection<excel> _ex;
        public ObservableCollection<excel> ex { get => _ex; set { _ex = value; OnPropertyChanged(); } }

        private ObservableCollection<BAOHANH> _List;
        public ObservableCollection<BAOHANH> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<XE> _List1;
        public ObservableCollection<XE> List1 { get => _List1; set { _List1 = value; OnPropertyChanged(); } }

        private ObservableCollection<NHANVIEN> _List2;
        public ObservableCollection<NHANVIEN> List2 { get => _List2; set { _List2 = value; OnPropertyChanged(); } }

        private ObservableCollection<KHACHHANG> _List3;
        public ObservableCollection<KHACHHANG> List3 { get => _List3; set { _List3 = value; OnPropertyChanged(); } }

        private BAOHANH _SelectedItem;
        public BAOHANH SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    SelectedXE = SelectedItem.XE;
                    MABH = SelectedItem.MABH;
                    SelectedNV = SelectedItem.NHANVIEN;
                    SelectedKH = SelectedItem.KHACHHANG;
                    
                }
            }
        }

        private XE _SelectedXE;
        public XE SelectedXE
        {
            get => _SelectedXE;
            set
            {
                _SelectedXE = value;
                OnPropertyChanged();
            }
        }

        private NHANVIEN _SelectedNV;
        public NHANVIEN SelectedNV
        {
            get => _SelectedNV;
            set
            {
                _SelectedNV = value;
                OnPropertyChanged();
            }
        }

        private KHACHHANG _SelectedKH;
        public KHACHHANG SelectedKH
        {
            get => _SelectedKH;
            set
            {
                _SelectedKH = value;
                OnPropertyChanged();
            }
        }


        

        private string _MAXE;
        public string MAXE { get => _MAXE; set { _MAXE = value; OnPropertyChanged(); } }

        private string _MABH;
        public string MABH { get => _MABH; set { _MABH = value; OnPropertyChanged(); } }

        private string _MANV;
        public string MANV { get => _MANV; set { _MANV = value; OnPropertyChanged(); } }

        private string _MAKH;
        public string MAKH { get => _MAKH; set { _MAKH = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand XuatCommand { get; set; }
        
        public BaoHanhViewModel()
        {
            List = new ObservableCollection<BAOHANH>(DataProvider.Ins.DB.BAOHANHs);
            List1 = new ObservableCollection<XE>(DataProvider.Ins.DB.XEs);
            List2 = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
            List3 = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedXE == null || SelectedNV == null || SelectedKH == null)
                    return false;

                var displayList = DataProvider.Ins.DB.BAOHANHs.Where(x => x.MABH == SelectedItem.MABH);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var baohanh = new BAOHANH() { MAXE = SelectedXE.MAXE, MABH = MABH, MANV = SelectedNV.MANV, MAKH = SelectedKH.MAKH };

                DataProvider.Ins.DB.BAOHANHs.Add(baohanh);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(baohanh);
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedXE == null || SelectedNV == null || SelectedKH == null)
                    return false;

                var displayList = DataProvider.Ins.DB.BAOHANHs.Where(x => x.MABH == SelectedItem.MABH);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                 var baohanh = SelectedItem;

                 DataProvider.Ins.DB.BAOHANHs.Remove(baohanh);
                 DataProvider.Ins.DB.SaveChanges();

                 List.Remove(baohanh);
               
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedXE == null || SelectedNV == null || SelectedKH == null)
                    return false;

                var displayList = DataProvider.Ins.DB.BAOHANHs.Where(x => x.MABH == SelectedItem.MABH);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
               

                var baohanh = DataProvider.Ins.DB.BAOHANHs.Where(x => x.MABH == SelectedItem.MABH).SingleOrDefault();
                baohanh.MABH = MABH;
                baohanh.MAKH = SelectedKH.MAKH;
                baohanh.MANV = SelectedNV.MANV;
                baohanh.MAXE = SelectedXE.MAXE;
                DataProvider.Ins.DB.SaveChanges();
                
                SelectedItem.MABH = MABH;
            });

            SearchCommand = new RelayCommand<object>((p) =>
            {
                return true;
                    

            }, (p) =>
            {
                Microsoft.Office.Interop.Excel.Application ex = new Microsoft.Office.Interop.Excel.Application();
                ex.Application.Workbooks.Add(Type.Missing);

                
            });

            
        }
    
    }
}
