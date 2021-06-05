using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace MEDLATEC.BusinessLayer
{
    [Serializable]
    public class Cms_Hoinghi
    {

        #region InnerClass

        #endregion

        #region Data Members
        private int _ID;
        private string _Hoten;
        private string _Phone;
        private string _Datcauhoi;

        #endregion
        #region Public Properties  
        public int ID { get { return _ID; } set { _ID = value; } }
        public string Hoten { get { return _Hoten; } set { _Hoten = value; } }
        public string Phone { get { return _Phone; } set { _Phone = value; } }
        public string Datcauhoi { get { return _Datcauhoi; } set { _Datcauhoi = value; } }
   
        #endregion

      



    }


}
