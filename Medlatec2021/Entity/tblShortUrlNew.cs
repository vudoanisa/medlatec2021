using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEDLATEC2019.Entity
{
    public class tblShortUrlNew
    {
        #region Constructors  
        public tblShortUrlNew() { }
        #endregion
        #region Private Fields  
        private object _ID;
        private string _shortURL;
        private string _Link;
        private object _datesave;
        #endregion
        #region Public Properties  
        public object ID { get { return _ID; } set { _ID = value; } }
        public string shortURL { get { return _shortURL; } set { _shortURL = value; } }
        public string Link { get { return _Link; } set { _Link = value; } }
        public object datesave { get { return _datesave; } set { _datesave = value; } }
        #endregion  

    }
}