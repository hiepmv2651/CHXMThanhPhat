//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sql_nhom.Model
{
    using System;
    using System.Collections.Generic;
    using sql_nhom.ViewModel;

    public partial class CHITIETHOADONNHAP : BaseViewModel
    {
        private string _MAHDN;
        public string MAHDN { get => _MAHDN; set { _MAHDN = value; OnPropertyChanged(); } }

        private string _MAXE;
        public string MAXE { get => _MAXE; set { _MAXE = value; OnPropertyChanged(); } }

        private double _DONGIA;
        public double DONGIA { get => _DONGIA; set { _DONGIA = value; OnPropertyChanged(); } }

        private int _SOLUONG;
        public int SOLUONG { get => _SOLUONG; set { _SOLUONG = value; OnPropertyChanged(); } }

        private double _TONGTIEN;
        public double TONGTIEN { get => _TONGTIEN; set { _TONGTIEN = value; OnPropertyChanged(); } }

        
        
        private XE _XE;
        public virtual XE XE { get => _XE; set { _XE = value; OnPropertyChanged(); } }

        private HOADONNHAP _HOADONNHAP;
        public virtual HOADONNHAP HOADONNHAP { get => _HOADONNHAP; set { _HOADONNHAP = value; OnPropertyChanged(); } }
    }
}