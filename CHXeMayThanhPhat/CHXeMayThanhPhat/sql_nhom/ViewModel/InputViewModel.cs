using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sql_nhom.Model;
using System.Windows.Input;

namespace sql_nhom.ViewModel
{
    public class InputViewModel : BaseViewModel
    {
        private ObservableCollection<CHITIETHOADONNHAP> _List;
        public ObservableCollection<CHITIETHOADONNHAP> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<XE> _List1;
        public ObservableCollection<XE> List1 { get => _List1; set { _List1 = value; OnPropertyChanged(); } }

        private ObservableCollection<HOADONNHAP> _List2;
        public ObservableCollection<HOADONNHAP> List2 { get => _List2; set { _List2 = value; OnPropertyChanged(); } }

        private CHITIETHOADONNHAP _SelectedItem;
        public CHITIETHOADONNHAP SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    SelectedHDN = SelectedItem.HOADONNHAP;
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

        private HOADONNHAP _SelectedHDN;
        public HOADONNHAP SelectedHDN
        {
            get => _SelectedHDN;
            set
            {
                _SelectedHDN = value;
                OnPropertyChanged();
            }
        }

        private string _MAXE;
        public string MAXE { get => _MAXE; set { _MAXE = value; OnPropertyChanged(); } }


        private string _MAHDN;
        public string MAHDN { get => _MAHDN; set { _MAHDN = value; OnPropertyChanged(); } }


        private double _DONGIA;
        public double DONGIA { get => _DONGIA; set { _DONGIA = value; OnPropertyChanged(); } }

        private int _SOLUONG;
        public int SOLUONG { get => _SOLUONG; set { _SOLUONG = value; OnPropertyChanged(); } }

        private double _TONGTIEN;
        public double TONGTIEN { get => _TONGTIEN; set { _TONGTIEN = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public InputViewModel()
        {
            List = new ObservableCollection<CHITIETHOADONNHAP>(DataProvider.Ins.DB.CHITIETHOADONNHAPs);
            List1 = new ObservableCollection<XE>(DataProvider.Ins.DB.XEs);
            List2 = new ObservableCollection<HOADONNHAP>(DataProvider.Ins.DB.HOADONNHAPs);

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var Chitietnhap = new CHITIETHOADONNHAP() { MAHDN = SelectedHDN.MAHDN, MAXE = SelectedXE.MAXE, DONGIA = DONGIA, SOLUONG = SOLUONG, TONGTIEN = TONGTIEN };

                DataProvider.Ins.DB.CHITIETHOADONNHAPs.Add(Chitietnhap);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Chitietnhap);

            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedXE == null || SelectedHDN == null)
                    return false;

                var displayList = DataProvider.Ins.DB.CHITIETHOADONNHAPs.Where(x => x.MAHDN == SelectedHDN.MAHDN);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Chitietnhap = SelectedItem;

                DataProvider.Ins.DB.CHITIETHOADONNHAPs.Remove(Chitietnhap);
                DataProvider.Ins.DB.SaveChanges();

                List.Remove(Chitietnhap);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedXE == null || SelectedHDN == null)
                    return false;

                var displayList = DataProvider.Ins.DB.CHITIETHOADONNHAPs.Where(x => x.MAHDN == SelectedHDN.MAHDN);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {

                var ctnhap = DataProvider.Ins.DB.CHITIETHOADONNHAPs.Where(x => x.MAHDN == SelectedHDN.MAHDN).SingleOrDefault();
                ctnhap.MAHDN = SelectedHDN.MAHDN;
                ctnhap.DONGIA = DONGIA;
                ctnhap.SOLUONG = SOLUONG;
                ctnhap.TONGTIEN = TONGTIEN;
                ctnhap.MAXE = SelectedXE.MAXE;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.MAHDN = MAHDN;
            });
        }
    }
}
