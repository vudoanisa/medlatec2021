using System;
using System.Collections.Generic;
using System.Text;
namespace MEDLATEC.BusinessLayer
{
    [Serializable]
    public class Cms_Price
    {
        #region Constructors  
        public Cms_Price() { }
        #endregion
        #region Private Fields  
        private string TenCP;
        private float DG;
        private int _total;
        private float _DGBH;

        #endregion
        #region Public Properties  
        public string TenCP1 { get { return TenCP; } set { TenCP = value; } }
      
        public float DG1 { get { return DG; } set { DG = value; } }

        public int Total { get { return _total; } set { _total = value; } }
        public float DGBH
        {
            get
            {
                return this._DGBH;
            }
            set
            {
                this._DGBH = value;
            }
        }




        //public int QuestionID { get { return _QuestionID; } set { _QuestionID = value; } }
        //public string QuestionTitle { get { return _QuestionTitle; } set { _QuestionTitle = value; } }


        #endregion


    }
}
