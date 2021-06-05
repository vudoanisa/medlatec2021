using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MEDLATEC2019.Entity
{
    [Serializable]

    public class tbl_kyniem25 : IValidatableObject
    {
        #region Constructors  
        public tbl_kyniem25() { }
        #endregion
        #region Private Fields  
        private int _ID;
        private string _Hovaten;
        private string _Manv;
        private string _Donvi;
        private DateTime _datecreate;
        #endregion
        #region Public Properties  
        public int ID { get { return _ID; } set { _ID = value; } }
        public string Hovaten { get { return _Hovaten; } set { _Hovaten = value; } }
        public string Manv { get { return _Manv; } set { _Manv = value; } }
        public string Donvi { get { return _Donvi; } set { _Donvi = value; } }
        public DateTime datecreate { get { return _datecreate; } set { _datecreate = value; } }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
        #endregion  }
    }
}