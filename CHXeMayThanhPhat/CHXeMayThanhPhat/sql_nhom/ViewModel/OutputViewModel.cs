using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using sql_nhom.Model;

namespace sql_nhom.ViewModel
{
    public class OutputViewModel : BaseViewModel
    {
        private ObservableCollection<CHITIETHOADONXUAT> _List;
        public ObservableCollection<CHITIETHOADONXUAT> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<XE> _List1;
        public ObservableCollection<XE> List1 { get => _List1; set { _List1 = value; OnPropertyChanged(); } }

        private ObservableCollection<HOADONXUAT> _List2;
        public ObservableCollection<HOADONXUAT> List2 { get => _List2; set { _List2 = value; OnPropertyChanged(); } }

        private CHITIETHOADONXUAT _SelectedItem;
        public CHITIETHOADONXUAT SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    SelectedHDX = SelectedItem.HOADONXUAT;
                    SelectedXE = SelectedItem.XE;
                    DONGIA = SelectedItem.DONGIA;
                    SOLUONG = SelectedItem.SOLUONG;
                    TONGTIEN = SelectedItem.TONGTIEN;
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

        private HOADONXUAT _SelectedHDX;
        public HOADONXUAT SelectedHDX
        {
            get => _SelectedHDX;
            set
            {
                _SelectedHDX = value;
                OnPropertyChanged();
            }
        }

        private string _MAXE;
        public string MAXE { get => _MAXE; set { _MAXE = value; OnPropertyChanged(); } }


        private string _MAHDX;
        public string MAHDX { get => _MAHDX; set { _MAHDX = value; OnPropertyChanged(); } }


        private double _DONGIA;
        public double DONGIA { get => _DONGIA; set { _DONGIA = value; OnPropertyChanged(); } }

        private int _SOLUONG;
        public int SOLUONG { get => _SOLUONG; set { _SOLUONG = value; OnPropertyChanged(); } }

        private double _TONGTIEN;
        public double TONGTIEN { get => _TONGTIEN; set { _TONGTIEN = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public OutputViewModel()
        {
            List = new ObservableCollection<CHITIETHOADONXUAT>(DataProvider.Ins.DB.CHITIETHOADONXUATs);
            List1 = new ObservableCollection<XE>(DataProvider.Ins.DB.XEs);
            List2 = new ObservableCollection<HOADONXUAT>(DataProvider.Ins.DB.HOADONXUATs);

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedXE == null || SelectedHDX == null)
                    return false;

                var displayList = DataProvider.Ins.DB.CHITIETHOADONXUATs.Where(x => x.MAHDX == SelectedHDX.MAHDX);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Chitietxuat = new CHITIETHOADONXUAT() { MAHDX = MAHDX, MAXE = SelectedXE.MAXE, DONGIA = DONGIA, SOLUONG = SOLUONG, TONGTIEN = TONGTIEN };

                DataProvider.Ins.DB.CHITIETHOADONXUATs.Add(Chitietxuat);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Chitietxuat);
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedXE == null || SelectedHDX == null)
                    return false;

                var displayList = DataProvider.Ins.DB.CHITIETHOADONXUATs.Where(x => x.MAHDX == SelectedHDX.MAHDX);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Chitietxuat = SelectedItem;

                DataProvider.Ins.DB.CHITIETHOADONXUATs.Remove(Chitietxuat);
                DataProvider.Ins.DB.SaveChanges();

                List.Remove(Chitietxuat);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedXE == null || SelectedHDX == null)
                    return false;

                var displayList = DataProvider.Ins.DB.CHITIETHOADONXUATs.Where(x => x.MAHDX == SelectedHDX.MAHDX);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {

                var ctxuat = DataProvider.Ins.DB.CHITIETHOADONXUATs.Where(x => x.MAHDX == SelectedHDX.MAHDX).SingleOrDefault();
                ctxuat.MAHDX = SelectedHDX.MAHDX;
                ctxuat.DONGIA = DONGIA;
                ctxuat.SOLUONG = SOLUONG;
                ctxuat.TONGTIEN = TONGTIEN;
                ctxuat.MAXE = SelectedXE.MAXE;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.MAHDX = MAHDX;
            });
        }
    }
}
