using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using sql_nhom.Model;

namespace sql_nhom.ViewModel
{
    public class UnitViewModel : BaseViewModel
    {
        private ObservableCollection<XE> _List;
        public ObservableCollection<XE> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<LOAIXE> _List1;
        public ObservableCollection<LOAIXE> List1 { get => _List1; set { _List1 = value; OnPropertyChanged(); } }

        private ObservableCollection<NHACUNGCAP> _List2;
        public ObservableCollection<NHACUNGCAP> List2 { get => _List2; set { _List2 = value; OnPropertyChanged(); } }

        private XE _SelectedItem;
        public XE SelectedItem 
        { 
            get => _SelectedItem; 
            set 
            { 
                _SelectedItem = value;
                OnPropertyChanged(); 
                if (SelectedItem != null) 
                {
                    MAXE = SelectedItem.MAXE;
                    TENXE = SelectedItem.TENXE;
                    SelectedLX = SelectedItem.LOAIXE;
                    SelectedNCC = SelectedItem.NHACUNGCAP;
                    SOLUONG = SelectedItem.SOLUONG;
                    GIA = SelectedItem.GIA;
                }
            } 
        }

        private LOAIXE _SelectedLX;
        public LOAIXE SelectedLX
        {
            get => _SelectedLX;
            set
            {
                _SelectedLX = value;
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

        private string _MAXE;
        public string MAXE { get => _MAXE; set { _MAXE = value; OnPropertyChanged(); } }

        private string _TENXE;
        public string TENXE { get => _TENXE; set { _TENXE = value; OnPropertyChanged(); } }

        private string _MALOAI;
        public string MALOAI { get => _MALOAI; set { _MALOAI = value; OnPropertyChanged(); } }

        private string _MANCC;
        public string MANCC { get => _MANCC; set { _MANCC = value; OnPropertyChanged(); } }

        private int _SOLUONG;
        public int SOLUONG { get => _SOLUONG; set { _SOLUONG = value; OnPropertyChanged(); } }

        private double _GIA;
        public double GIA { get => _GIA; set { _GIA = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public UnitViewModel()
        {
            List = new ObservableCollection<XE>(DataProvider.Ins.DB.XEs);
            List1 = new ObservableCollection<LOAIXE>(DataProvider.Ins.DB.LOAIXEs);
            List2 = new ObservableCollection<NHACUNGCAP>(DataProvider.Ins.DB.NHACUNGCAPs);

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var Xe = new XE() { MANCC = SelectedNCC.MANCC, MAXE = MAXE, TENXE = TENXE, MALOAI = SelectedLX.MALOAI, SOLUONG = SOLUONG, GIA = GIA };

                DataProvider.Ins.DB.XEs.Add(Xe);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Xe);
              
                
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedLX == null || SelectedNCC == null)
                    return false;

                var displayList = DataProvider.Ins.DB.XEs.Where(x => x.MAXE == SelectedItem.MAXE);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Xe = SelectedItem;

                DataProvider.Ins.DB.XEs.Remove(Xe);
                DataProvider.Ins.DB.SaveChanges();

                List.Remove(Xe);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedLX == null || SelectedNCC == null)
                    return false;

                var displayList = DataProvider.Ins.DB.XEs.Where(x => x.MAXE == SelectedItem.MAXE);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {


                var xe = DataProvider.Ins.DB.XEs.Where(x => x.MAXE == SelectedItem.MAXE).SingleOrDefault();
                xe.MAXE = MAXE;
                xe.TENXE = TENXE;
                xe.SOLUONG = SOLUONG;
                xe.GIA = GIA;
                xe.MALOAI = SelectedLX.MALOAI;
                xe.MANCC = SelectedNCC.MANCC;
                
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.MAXE = MAXE;
            });
        }


    }
}
