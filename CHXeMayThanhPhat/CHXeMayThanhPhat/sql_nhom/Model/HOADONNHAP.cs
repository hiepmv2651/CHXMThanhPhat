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

    public partial class HOADONNHAP : BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADONNHAP()
        {
            this.CHITIETHOADONNHAPs = new HashSet<CHITIETHOADONNHAP>();
        }

        private string _MAHDN;
        public string MAHDN { get => _MAHDN; set { _MAHDN = value; OnPropertyChanged(); } }

        private string _MANV;
        public string MANV { get => _MANV; set { _MANV = value; OnPropertyChanged(); } }

        private string _MANCC;
        public string MANCC { get => _MANCC; set { _MANCC = value; OnPropertyChanged(); } }

        private System.DateTime _NGAYNHAP;
        public System.DateTime NGAYNHAP { get => _NGAYNHAP; set { _NGAYNHAP = value; OnPropertyChanged(); } }

        
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADONNHAP> CHITIETHOADONNHAPs { get; set; }

        private NHACUNGCAP _NHACUNGCAP;
        public virtual NHACUNGCAP NHACUNGCAP { get => _NHACUNGCAP; set { _NHACUNGCAP = value; OnPropertyChanged(); } }

        private NHANVIEN _NHANVIEN;
        public virtual NHANVIEN NHANVIEN { get => _NHANVIEN; set { _NHANVIEN = value; OnPropertyChanged(); } }
        
    }
}
