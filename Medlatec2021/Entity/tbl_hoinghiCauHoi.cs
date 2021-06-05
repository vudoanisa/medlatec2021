using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MEDLATEC2019.Entity
{
    [Serializable]
    public class tbl_hoinghiCauHoi : IValidatableObject
    {
        #region Constructors  
        public tbl_hoinghiCauHoi() { }
        #endregion
        #region Private Fields  
        private int _id;
        private string _hoten;
        private int _namsinh;
        private string _mobile;
        private string _nghenghiep;
        private string _email;
        private string _donvi;
        private string _chuyenkhoa;
        private string _cau8;
        private string _cau9;
        private string _cau10;
        private string _cau11;
        private string _cau12;
        private string _cau13;
        private string _cau14;
        private DateTime _datesave;
        #endregion
        #region Public Properties  
        public int id { get { return _id; } set { _id = value; } }
        public string hoten { get { return _hoten; } set { _hoten = value; } }
        public int namsinh { get { return _namsinh; } set { _namsinh = value; } }
        public string mobile { get { return _mobile; } set { _mobile = value; } }
        public string nghenghiep { get { return _nghenghiep; } set { _nghenghiep = value; } }
        public string email { get { return _email; } set { _email = value; } }
        public string donvi { get { return _donvi; } set { _donvi = value; } }
        public string chuyenkhoa { get { return _chuyenkhoa; } set { _chuyenkhoa = value; } }
        public string cau8 { get { return _cau8; } set { _cau8 = value; } }
        public string cau9 { get { return _cau9; } set { _cau9 = value; } }
        public string cau10 { get { return _cau10; } set { _cau10 = value; } }
        public string cau11 { get { return _cau11; } set { _cau11 = value; } }
        public string cau12 { get { return _cau12; } set { _cau12 = value; } }
        public string cau13 { get { return _cau13; } set { _cau13 = value; } }
        public string cau14 { get { return _cau14; } set { _cau14 = value; } }
        public DateTime datesave { get { return _datesave; } set { _datesave = value; } }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
        #endregion  }
    }
}