using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace MEDLATEC.BusinessLayer
{
    [Serializable]
    public class Cms_TheTT
    {

        #region InnerClass

        #endregion

        #region Data Members

        private int _IDThe;
        private string _MaTheTT;

        private string _SoThe;
        private DateTime _DateActive;
        private bool _Active;
        private string _Content;
        private string _dtkh;

        private string _Sodt;
        private string _OTP;

        #endregion
        #region Public Properties  
        public int IDThe { get { return _IDThe; } set { _IDThe = value; } }
        public string MaTheTT { get { return _MaTheTT; } set { _MaTheTT = value; } }

        public string SoThe { get { return _SoThe; } set { _SoThe = value; } }

        public DateTime DateActive { get { return _DateActive; } set { _DateActive = value; } }

        public bool Active { get { return _Active; } set { _Active = value; } }

        #endregion
        public string Content { get { return _Content; } set { _Content = value; } }
        public string dtkh { get { return _dtkh; } set { _dtkh = value; } }
        public string Sodt { get { return _Sodt; } set { _Sodt = value; } }
        public string OTP { get { return _OTP; } set { _OTP = value; } }




    }


}
