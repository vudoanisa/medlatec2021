using System;
using System.Collections.Generic;
using System.Text;
namespace MEDLATEC.BusinessLayer
{
    [Serializable]
    public class GoiKhamCTBan
    {
        #region Constructors  
        public GoiKhamCTBan() { }
        #endregion
        #region Private Fields  
        private object _TT;
        private int _IDGoi;
        private string _MaGoi;
        private string _TenGoi;
        private string _MaNV;
        private string _TenNV;
        private DateTime _NgayBan;
        private string _NguonBan;
        private string _MaGen;
        private string _NguoiMua;
        private string _Tel;
        private string _DiaChi;
        private bool _TTOnline;
        private DateTime _NgaySD;
        private string _TinhTrang;
        private bool _Del;
        private DateTime _AutoDate;
        private bool _IsGoiDien;
        private bool _IsTN;
        private string _MaBS;
        private string _PhanLoai;
        private string _GhiChu;
        private DateTime _TGCheck;
        private string _NoiKham;
        private DateTime _NgayKham;
        private DateTime _GioHen1;
        private DateTime _GioHen2;
        private DateTime _DateActive;
        private float _TienCKLienKet;
        private object _MaKH;
        private float _DiemTich;
        private bool _NewPatient;
        private object _rowguid;
        #endregion
        #region Public Properties  
        public object TT { get { return _TT; } set { _TT = value; } }
        public int IDGoi { get { return _IDGoi; } set { _IDGoi = value; } }
        public string MaGoi { get { return _MaGoi; } set { _MaGoi = value; } }
        public string TenGoi { get { return _TenGoi; } set { _TenGoi = value; } }
        public string MaNV { get { return _MaNV; } set { _MaNV = value; } }
        public string TenNV { get { return _TenNV; } set { _TenNV = value; } }
        public DateTime NgayBan { get { return _NgayBan; } set { _NgayBan = value; } }
        public string NguonBan { get { return _NguonBan; } set { _NguonBan = value; } }
        public string MaGen { get { return _MaGen; } set { _MaGen = value; } }
        public string NguoiMua { get { return _NguoiMua; } set { _NguoiMua = value; } }
        public string Tel { get { return _Tel; } set { _Tel = value; } }
        public string DiaChi { get { return _DiaChi; } set { _DiaChi = value; } }
        public bool TTOnline { get { return _TTOnline; } set { _TTOnline = value; } }
        public DateTime NgaySD { get { return _NgaySD; } set { _NgaySD = value; } }
        public string TinhTrang { get { return _TinhTrang; } set { _TinhTrang = value; } }
        public bool Del { get { return _Del; } set { _Del = value; } }
        public DateTime AutoDate { get { return _AutoDate; } set { _AutoDate = value; } }
        public bool IsGoiDien { get { return _IsGoiDien; } set { _IsGoiDien = value; } }
        public bool IsTN { get { return _IsTN; } set { _IsTN = value; } }
        public string MaBS { get { return _MaBS; } set { _MaBS = value; } }
        public string PhanLoai { get { return _PhanLoai; } set { _PhanLoai = value; } }
        public string GhiChu { get { return _GhiChu; } set { _GhiChu = value; } }
        public DateTime TGCheck { get { return _TGCheck; } set { _TGCheck = value; } }
        public string NoiKham { get { return _NoiKham; } set { _NoiKham = value; } }
        public DateTime NgayKham { get { return _NgayKham; } set { _NgayKham = value; } }
        public DateTime GioHen1 { get { return _GioHen1; } set { _GioHen1 = value; } }
        public DateTime GioHen2 { get { return _GioHen2; } set { _GioHen2 = value; } }
        public DateTime DateActive { get { return _DateActive; } set { _DateActive = value; } }
        public float TienCKLienKet { get { return _TienCKLienKet; } set { _TienCKLienKet = value; } }
        public object MaKH { get { return _MaKH; } set { _MaKH = value; } }
        public float DiemTich { get { return _DiemTich; } set { _DiemTich = value; } }
        public bool NewPatient { get { return _NewPatient; } set { _NewPatient = value; } }
        public object rowguid { get { return _rowguid; } set { _rowguid = value; } }
        #endregion
    }
}

