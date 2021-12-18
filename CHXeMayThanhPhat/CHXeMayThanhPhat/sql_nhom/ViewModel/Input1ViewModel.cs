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
    public class Input1ViewModel : BaseViewModel
    {
        private ObservableCollection<HOADONNHAP> _List;
        public ObservableCollection<HOADONNHAP> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<NHANVIEN> _List1;
        public ObservableCollection<NHANVIEN> List1 { get => _List1; set { _List1 = value; OnPropertyChanged(); } }

        private ObservableCollection<NHACUNGCAP> _List2;
        public ObservableCollection<NHACUNGCAP> List2 { get => _List2; set { _List2 = value; OnPropertyChanged(); } }

        private HOADONNHAP _SelectedItem;
        public HOADONNHAP SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    SelectedNV = SelectedItem.NHANVIEN;
                    SelectedNCC = SelectedItem.NHACUNGCAP;
                    MAHDN = SelectedItem.MAHDN;
                    NGAYNHAP = SelectedItem.NGAYNHAP;
                    
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

        private NHACUNGCAP _SelectedNCC;
        public NHACUNGCAP SelectedNCC
        {
            get => _SelectedNCC;
            set
            {
                _SelectedNCC = value;
                OnPropertyChanged();
            }
        }

        

        private string _MAHDN;
        public string MAHDN { get => _MAHDN; set { _MAHDN = value; OnPropertyChanged(); } }


        private DateTime _NGAYNHAP;
        public DateTime NGAYNHAP { get => _NGAYNHAP; set { _NGAYNHAP = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public Input1ViewModel()
        {
            List = new ObservableCollection<HOADONNHAP>(DataProvider.Ins.DB.HOADONNHAPs);
            List1 = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
            List2 = new ObservableCollection<NHACUNGCAP>(DataProvider.Ins.DB.NHACUNGCAPs);

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var Chitietnhap = new HOADONNHAP() { MAHDN = MAHDN, NGAYNHAP = NGAYNHAP, MANV = SelectedNV.MANV, MANCC = SelectedNCC.MANCC };

                DataProvider.Ins.DB.HOADONNHAPs.Add(Chitietnhap);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Chitietnhap);

            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedNCC == null || SelectedNV == null)
                    return false;

                var displayList = DataProvider.Ins.DB.HOADONNHAPs.Where(x => x.MAHDN == SelectedItem.MAHDN);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Chitietnhap = SelectedItem;

                DataProvider.Ins.DB.HOADONNHAPs.Remove(Chitietnhap);
                DataProvider.Ins.DB.SaveChanges();

                List.Remove(Chitietnhap);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedNCC == null || SelectedNV == null)
                    return false;

                var displayList = DataProvider.Ins.DB.HOADONNHAPs.Where(x => x.MAHDN == SelectedItem.MAHDN);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {


                var hoadonnhap = DataProvider.Ins.DB.HOADONNHAPs.Where(x => x.MAHDN == SelectedItem.MAHDN).SingleOrDefault();
                hoadonnhap.MAHDN = MAHDN;
                hoadonnhap.NGAYNHAP = NGAYNHAP;
                hoadonnhap.MANV = SelectedNV.MANV;
                hoadonnhap.MANCC = SelectedNCC.MANCC;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.MAHDN = MAHDN;
            });
        }
    }
}
