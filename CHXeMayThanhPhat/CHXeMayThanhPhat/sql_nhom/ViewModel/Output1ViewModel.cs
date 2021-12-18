using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sql_nhom.Model;
using System.Windows.Input;
using ms = Microsoft.Office.Interop.Excel;
using System.Windows;

namespace sql_nhom.ViewModel
{
    public class Output1ViewModel : BaseViewModel
    {
        
        private ObservableCollection<HOADONXUAT> _List;
        public ObservableCollection<HOADONXUAT> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<NHANVIEN> _List1;
        public ObservableCollection<NHANVIEN> List1 { get => _List1; set { _List1 = value; OnPropertyChanged(); } }

        private ObservableCollection<KHACHHANG> _List2;
        public ObservableCollection<KHACHHANG> List2 { get => _List2; set { _List2 = value; OnPropertyChanged(); } }

        private HOADONXUAT _SelectedItem;
        public HOADONXUAT SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    SelectedNV = SelectedItem.NHANVIEN;
                    SelectedKH = SelectedItem.KHACHHANG;
                    MAHDX = SelectedItem.MAHDX;
                    NGAYXUAT = SelectedItem.NGAYXUAT;

                }
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

        private string _selected = "";
        public string selected
        {
            get { return _selected; }
            set
            {
                if (_selected == value) return;
                _selected = value;
                base.OnPropertyChanged("selected");
            }
        }

        private string _MAHDX;
        public string MAHDX { get => _MAHDX; set { _MAHDX = value; OnPropertyChanged(); } }


        private DateTime _NGAYXUAT;
        public DateTime NGAYXUAT { get => _NGAYXUAT; set { _NGAYXUAT = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand TimCommand { get; set; }
        

        public Output1ViewModel()
        {
            List = new ObservableCollection<HOADONXUAT>(DataProvider.Ins.DB.HOADONXUATs);
            List1 = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
            List2 = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var Chitietnhap = new HOADONXUAT() { MAHDX = MAHDX, NGAYXUAT = NGAYXUAT, MANV = SelectedNV.MANV, MAKH = SelectedKH.MAKH };

                DataProvider.Ins.DB.HOADONXUATs.Add(Chitietnhap);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Chitietnhap);

            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedKH == null || SelectedNV == null)
                    return false;

                var displayList = DataProvider.Ins.DB.HOADONXUATs.Where(x => x.MAHDX == SelectedItem.MAHDX);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Chitietnhap = SelectedItem;

                DataProvider.Ins.DB.HOADONXUATs.Remove(Chitietnhap);
                DataProvider.Ins.DB.SaveChanges();

                List.Remove(Chitietnhap);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedKH == null || SelectedNV == null)
                    return false;

                var displayList = DataProvider.Ins.DB.HOADONXUATs.Where(x => x.MAHDX == SelectedItem.MAHDX);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {

                var hoadonxuat = DataProvider.Ins.DB.HOADONXUATs.Where(x => x.MAHDX == SelectedItem.MAHDX).SingleOrDefault();
                hoadonxuat.MAHDX = MAHDX;
                hoadonxuat.NGAYXUAT = NGAYXUAT;
                hoadonxuat.MANV = SelectedNV.MANV;
                hoadonxuat.MAKH = SelectedKH.MAKH;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.MAHDX = MAHDX;
            });
           

            TimCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                


            });
        }
    }
}
