using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace MEDLATEC.BusinessLayer
{
    [Serializable]
    public class cms_Group_Doctor
    {

        #region InnerClass

        #endregion

        #region Data Members

        private int _id;
        private string _Name;
        private string _Image;
        private string _Desc;
        private string _keyword;
        private int _ord;
        private bool _Active;
        private DateTime _DateSave;
        #endregion
        #region Public Properties  
        public int id { get { return _id; } set { _id = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Image { get { return _Image; } set { _Image = value; } }
        public string Desc { get { return _Desc; } set { _Desc = value; } }
        public string keyword { get { return _keyword; } set { _keyword = value; } }
        public int ord { get { return _ord; } set { _ord = value; } }
        public bool Active { get { return _Active; } set { _Active = value; } }
        public DateTime DateSave { get { return _DateSave; } set { _DateSave = value; } }
        public HttpPostedFileBase ImageFile { get; set; }
        #endregion





    }


}
