using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MEDLATEC2019.Entity
{
    [Serializable]
    public class tbl_TestCode : IValidatableObject
    {
        #region Constructors  
        public tbl_TestCode() { }
        #endregion
        #region Private Fields  
        private Int32 _ID;
        private string _TestCode;
        private string _QuickCode;
        private string _TestName;
        private string _Category;
        private float _Price;
        private string _UserI;
        private string _UserU;
        private DateTime _Intime;
        private DateTime _UpdateTime;
        private string _Conclusion;
        private string _linkurl;
        private string _Conclusion1;
        #endregion
        #region Public Properties  

        public Int32 ID { get { return _ID; } set { _ID = value; } }
        public string TestCode { get { return _TestCode; } set { _TestCode = value; } }
        public string QuickCode { get { return _QuickCode; } set { _QuickCode = value; } }
        public string TestName { get { return _TestName; } set { _TestName = value; } }
        public string Category { get { return _Category; } set { _Category = value; } }
        public float Price { get { return _Price; } set { _Price = value; } }
        public string UserI { get { return _UserI; } set { _UserI = value; } }
        public string UserU { get { return _UserU; } set { _UserU = value; } }
        public DateTime Intime { get { return _Intime; } set { _Intime = value; } }
        public DateTime UpdateTime { get { return _UpdateTime; } set { _UpdateTime = value; } }
        public string Conclusion { get { return _Conclusion; } set { _Conclusion = value; } }
        public string Conclusion1 { get { return _Conclusion1; } set { _Conclusion1 = value; } }
        public string linkurl { get { return _linkurl; } set { _linkurl = value; } }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.TestCode))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào mã TestCode"));
            }
            else if (this.TestCode.Length > 200)
            {
                results.Add(new ValidationResult("TestCode lớn hơn 15 ký tự"));
            }

            if (string.IsNullOrWhiteSpace(this.TestName))
            {
                results.Add(new ValidationResult("Mời bạn nhập vào tên xét nghiệm TestName"));
            }
            else if (this.TestName.Length > 150)
            {
                results.Add(new ValidationResult("Tên xét nghiệm TestName lớn hơn 150 ký tự"));
            }

            if (!string.IsNullOrWhiteSpace(this.linkurl))
            {
                if (this.linkurl.Length > 150)
                {
                    results.Add(new ValidationResult("Đường link ý nghĩa xét nghiệm lớn hơn 300 ký tự"));
                }
            }


            return results;
        }
        #endregion  }
    }
}