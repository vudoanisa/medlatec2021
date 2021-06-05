using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEDLATEC2019.Entity
{
    [Serializable]
    public class tbl_logLanding
    {
        #region Constructors  
        public tbl_logLanding() { }
        #endregion
        #region Private Fields  
        private int _ID;
        private string _SDT;
        private string _Email;
        private string _Note;
        private string _adress;
        private DateTime _datesave;
        private string _IP;
        private string _magoi;
        private string _hoten;
        #endregion
        #region Public Properties  
        public int ID { get { return _ID; } set { _ID = value; } }
        public string SDT { get { return _SDT; } set { _SDT = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
        public string Note { get { return _Note; } set { _Note = value; } }
        public string adress { get { return _adress; } set { _adress = value; } }
        public DateTime datesave { get { return _datesave; } set { _datesave = value; } }
        public string IP { get { return _IP; } set { _IP = value; } }
        public string magoi { get { return _magoi; } set { _magoi = value; } }
        public string hoten { get { return _hoten; } set { _hoten = value; } }
        #endregion  }
    }
}