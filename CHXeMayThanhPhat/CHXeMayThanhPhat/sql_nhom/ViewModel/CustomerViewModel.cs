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
    public class CustomerViewModel : BaseViewModel
    {
        private ObservableCollection<KHACHHANG> _List;
        public ObservableCollection<KHACHHANG> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private KHACHHANG _SelectedItem;
        public KHACHHANG SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    MAKH = SelectedItem.MAKH;
                    TENKH = SelectedItem.TENKH;
                    DIACHI = SelectedItem.DIACHI;
                    SDT = SelectedItem.SDT;
                }
            }
        }

        private string _MAKH;
        public string MAKH { get => _MAKH; set { _MAKH = value; OnPropertyChanged(); } }


        private string _TENKH;
        public string TENKH { get => _TENKH; set { _TENKH = value; OnPropertyChanged(); } }


        private string _DIACHI;
        public string DIACHI { get => _DIACHI; set { _DIACHI = value; OnPropertyChanged(); } }


        private string _SDT;
        public string SDT { get => _SDT; set { _SDT = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public CustomerViewModel()
        {
            List = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var Khachhang = new KHACHHANG() { MAKH = MAKH, TENKH = TENKH, DIACHI = DIACHI, SDT = SDT};

                DataProvider.Ins.DB.KHACHHANGs.Add(Khachhang);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Khachhang);
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.KHACHHANGs.Where(x => x.MAKH == SelectedItem.MAKH);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Khachhang = SelectedItem;

                DataProvider.Ins.DB.KHACHHANGs.Remove(Khachhang);
                DataProvider.Ins.DB.SaveChanges();

                List.Remove(Khachhang);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.KHACHHANGs.Where(x => x.MAKH == SelectedItem.MAKH);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {


                var khachhang = DataProvider.Ins.DB.KHACHHANGs.Where(x => x.MAKH == SelectedItem.MAKH).SingleOrDefault();
                khachhang.MAKH = MAKH;
                khachhang.TENKH = TENKH;
                khachhang.DIACHI = DIACHI;
                khachhang.SDT = SDT;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.MAKH = MAKH;
            });
        }
    }
}
