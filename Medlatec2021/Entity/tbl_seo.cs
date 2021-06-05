﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MEDLATEC2019.Entity
{
    [Serializable]
    public class tbl_seo : IValidatableObject
    {
        #region Constructors  
        public tbl_seo() { }
        #endregion
        #region Private Fields  
        private int _id;
        private string _Content;
        private int _type;
        private int _status;
        private string _createby;
        private DateTime _createdate;
        private string _updateby;
        private DateTime _updatedate;
        private int _cateid;
        #endregion
        #region Public Properties  
        public int id { get { return _id; } set { _id = value; } }
        public string Content { get { return _Content; } set { _Content = value; } }
        public int type { get { return _type; } set { _type = value; } }
        public int status { get { return _status; } set { _status = value; } }
        public string createby { get { return _createby; } set { _createby = value; } }
        public DateTime createdate { get { return _createdate; } set { _createdate = value; } }
        public string updateby { get { return _updateby; } set { _updateby = value; } }
        public DateTime updatedate { get { return _updatedate; } set { _updatedate = value; } }
        public int cateid { get { return _cateid; } set { _cateid = value; } }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
        #endregion  }
    }
}