using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEDLATEC2019.Entity
{
    [Serializable]
    public class cms_Scientist
    {
        #region Constructors  
        public cms_Scientist() { }
        #endregion
        #region Private Fields  
        private int _ID;
        private string _ScientistTitle;
        private string _DatePerform;
        private string _PersionPerform;
        private string _UnitPerform;
        private string _CommissioningCommittee;
        private string _scientistDesc;
        private string _newsImages;
        private int _Status;
        private DateTime _dateCreate;
        private DateTime _datepub;
        private string _Slug;
        private string _newsContent;
        private int _userId;
        private DateTime _dateupdate;
        private string _newsKeyword;
        private int _ScientistCae;
        private string _ScientistCateName;
        private int _tongso;
        #endregion
        #region Public Properties  
        public int ID { get { return _ID; } set { _ID = value; } }
        public int tongso { get { return _tongso; } set { _tongso = value; } }
        public string ScientistTitle { get { return _ScientistTitle; } set { _ScientistTitle = value; } }
        public string ScientistCateName { get { return _ScientistCateName; } set { _ScientistCateName = value; } }
        public string DatePerform { get { return _DatePerform; } set { _DatePerform = value; } }
        public string PersionPerform { get { return _PersionPerform; } set { _PersionPerform = value; } }
        public string UnitPerform { get { return _UnitPerform; } set { _UnitPerform = value; } }
        public string CommissioningCommittee { get { return _CommissioningCommittee; } set { _CommissioningCommittee = value; } }
        public string scientistDesc { get { return _scientistDesc; } set { _scientistDesc = value; } }
        public string newsImages { get { return _newsImages; } set { _newsImages = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        public DateTime dateCreate { get { return _dateCreate; } set { _dateCreate = value; } }
        public DateTime datepub { get { return _datepub; } set { _datepub = value; } }
        public string Slug { get { return _Slug; } set { _Slug = value; } }
        public string newsContent { get { return _newsContent; } set { _newsContent = value; } }
        public int userId { get { return _userId; } set { _userId = value; } }
        public DateTime dateupdate { get { return _dateupdate; } set { _dateupdate = value; } }
        public string newsKeyword { get { return _newsKeyword; } set { _newsKeyword = value; } }
        public int ScientistCae { get { return _ScientistCae; } set { _ScientistCae = value; } }
        #endregion  }
    }
}