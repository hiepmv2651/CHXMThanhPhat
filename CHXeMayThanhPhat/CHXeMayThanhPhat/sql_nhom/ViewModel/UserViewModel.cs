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
    public class UserViewModel : BaseViewModel
    {
        private ObservableCollection<NHANVIEN> _List;
        public ObservableCollection<NHANVIEN> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private NHANVIEN _SelectedItem;
        public NHANVIEN SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    MANV = SelectedItem.MANV;
                    TENNV = SelectedItem.TENNV;
                    NGAYSINH = SelectedItem.NGAYSINH;
                    SDT = SelectedItem.SDT;
                    DIACHI = SelectedItem.DIACHI;
                    NGAYLAM = SelectedItem.NGAYLAM;
                    LUONG = SelectedItem.LUONG;
                }
            }
        }

        private string _MANV;
        public string MANV { get => _MANV; set { _MANV = value; OnPropertyChanged(); } }


        private string _TENNV;
        public string TENNV { get => _TENNV; set { _TENNV = value; OnPropertyChanged(); } }


        private string _DIACHI;
        public string DIACHI { get => _DIACHI; set { _DIACHI = value; OnPropertyChanged(); } }


        private string _SDT;
        public string SDT { get => _SDT; set { _SDT = value; OnPropertyChanged(); } }


        private double _LUONG;
        public double LUONG { get => _LUONG; set { _LUONG = value; OnPropertyChanged(); } }

        private DateTime _NGAYSINH;
        public DateTime NGAYSINH { get => _NGAYSINH; set { _NGAYSINH = value; OnPropertyChanged(); } }

        private string _NGAYLAM;
        public string NGAYLAM { get => _NGAYLAM; set { _NGAYLAM = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public UserViewModel()
        {
            List = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var Nhanvien = new NHANVIEN() { MANV = MANV, TENNV = TENNV, NGAYSINH = NGAYSINH, SDT = SDT, DIACHI = DIACHI, NGAYLAM = NGAYLAM, LUONG = LUONG };

                DataProvider.Ins.DB.NHANVIENs.Add(Nhanvien);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Nhanvien);
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.NHANVIENs.Where(x => x.MANV == SelectedItem.MANV);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Nhanvien = SelectedItem;

                DataProvider.Ins.DB.NHANVIENs.Remove(Nhanvien);
                DataProvider.Ins.DB.SaveChanges();

                List.Remove(Nhanvien);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.NHANVIENs.Where(x => x.MANV == SelectedItem.MANV);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {


                var nv = DataProvider.Ins.DB.NHANVIENs.Where(x => x.MANV == SelectedItem.MANV).SingleOrDefault();
                nv.TENNV = TENNV;
                nv.NGAYLAM = NGAYLAM;
                nv.MANV = MANV;
                nv.NGAYSINH = NGAYSINH;
                nv.DIACHI = DIACHI;
                nv.LUONG = LUONG;
                nv.SDT = SDT;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.MANV = MANV;
            });
        }
    }
}
