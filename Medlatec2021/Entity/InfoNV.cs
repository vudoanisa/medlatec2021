using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEDLATEC2019.Entity
{
    [Serializable]
    public class InfoNV
    {
        #region Constructors  
        public InfoNV() { }
        #endregion
        #region Private Fields  


        private string _Manhanvien;
        private string _Hoten;
        private string _Dienthoai;
        private string _TuKhoaDongName;

        #endregion
        #region Public Properties  


        public string Manhanvien { get { return _Manhanvien; } set { _Manhanvien = value; } }
        public string Hoten { get { return _Hoten; } set { _Hoten = value; } }
        public string Dienthoai { get { return _Dienthoai; } set { _Dienthoai = value; } }
        public string TuKhoaDongName { get { return _TuKhoaDongName; } set { _TuKhoaDongName = value; } }

        #endregion   
    }
}