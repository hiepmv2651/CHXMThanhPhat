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
    public class ObjectViewModel : BaseViewModel
    {
        private ObservableCollection<LOAIXE> _List;
        public ObservableCollection<LOAIXE> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private LOAIXE _SelectedItem;
        public LOAIXE SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    MALOAI = SelectedItem.MALOAI;
                    TENLOAI = SelectedItem.TENLOAI;
                }
            }
        }

        private string _MALOAI;
        public string MALOAI { get => _MALOAI; set { _MALOAI = value; OnPropertyChanged(); } }


        private string _TENLOAI;
        public string TENLOAI { get => _TENLOAI; set { _TENLOAI = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ObjectViewModel()
        {
            List = new ObservableCollection<LOAIXE>(DataProvider.Ins.DB.LOAIXEs);

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var Loaixe = new LOAIXE() { MALOAI = MALOAI, TENLOAI = TENLOAI };

                DataProvider.Ins.DB.LOAIXEs.Add(Loaixe);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Loaixe);
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.LOAIXEs.Where(x => x.MALOAI == SelectedItem.MALOAI);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Loaixe = SelectedItem;

                DataProvider.Ins.DB.LOAIXEs.Remove(Loaixe);
                DataProvider.Ins.DB.SaveChanges();

                List.Remove(Loaixe);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.LOAIXEs.Where(x => x.MALOAI == SelectedItem.MALOAI);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {


                var loaixe = DataProvider.Ins.DB.LOAIXEs.Where(x => x.MALOAI == SelectedItem.MALOAI).SingleOrDefault();
                loaixe.MALOAI = MALOAI;
                loaixe.TENLOAI = TENLOAI;
                
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.MALOAI = MALOAI;
            });
        }
    }

    
}