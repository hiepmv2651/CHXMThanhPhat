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
    public class SuplierViewModel : BaseViewModel
    {
        private ObservableCollection<NHACUNGCAP> _List;
        public ObservableCollection<NHACUNGCAP> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private NHACUNGCAP _SelectedItem;
        public NHACUNGCAP SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    MANCC = SelectedItem.MANCC;
                    TENNCC = SelectedItem.TENNCC;
                    DIACHI = SelectedItem.DIACHI;
                    SDT = SelectedItem.SDT;
                    SOLUONG = SelectedItem.SOLUONG;
                }
            }
        }

        private string _MANCC;
        public string MANCC { get => _MANCC; set { _MANCC = value; OnPropertyChanged(); } }


        private string _TENNCC;
        public string TENNCC { get => _TENNCC; set { _TENNCC = value; OnPropertyChanged(); } }


        private string _DIACHI;
        public string DIACHI { get => _DIACHI; set { _DIACHI = value; OnPropertyChanged(); } }


        private string _SDT;
        public string SDT { get => _SDT; set { _SDT = value; OnPropertyChanged(); } }


        private int _SOLUONG;
        public int SOLUONG { get => _SOLUONG; set { _SOLUONG = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public SuplierViewModel()
        {
            List = new ObservableCollection<NHACUNGCAP>(DataProvider.Ins.DB.NHACUNGCAPs);

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var Nhacungcap = new NHACUNGCAP() { MANCC = MANCC, TENNCC = TENNCC, DIACHI = DIACHI, SDT = SDT, SOLUONG = SOLUONG };

                DataProvider.Ins.DB.NHACUNGCAPs.Add(Nhacungcap);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Nhacungcap);
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.NHACUNGCAPs.Where(x => x.MANCC == SelectedItem.MANCC);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Nhacungcap = SelectedItem;

                DataProvider.Ins.DB.NHACUNGCAPs.Remove(Nhacungcap);
                DataProvider.Ins.DB.SaveChanges();

                List.Remove(Nhacungcap);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.NHACUNGCAPs.Where(x => x.MANCC == SelectedItem.MANCC);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {


                var ncc = DataProvider.Ins.DB.NHACUNGCAPs.Where(x => x.MANCC == SelectedItem.MANCC).SingleOrDefault();
                ncc.MANCC = MANCC;
                ncc.SDT = SDT;
                ncc.SOLUONG = SOLUONG;
                ncc.TENNCC = TENNCC;
                ncc.DIACHI = DIACHI;

                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.MANCC = MANCC;
            });
        }
    }
}
