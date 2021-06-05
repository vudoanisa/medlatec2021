using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MEDLATEC2019.Entity
{
    [Serializable]
    public class tbl_hoinghi : IValidatableObject
    {

        #region Constructors  
        public tbl_hoinghi() { }
        #endregion
        #region Private Fields  
        private int _id;
        private string _Content;
        private DateTime _datesave;
        #endregion
        #region Public Properties  
        public int id { get { return _id; } set { _id = value; } }
        public string Content { get { return _Content; } set { _Content = value; } }
        public DateTime datesave { get { return _datesave; } set { _datesave = value; } }
        #endregion  }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }

    }
}