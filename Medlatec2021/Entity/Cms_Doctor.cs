using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace MEDLATEC.BusinessLayer
{
    [Serializable]
    public class Cms_Doctor
    {

        #region InnerClass

        #endregion

        #region Data Members

        private int _id;
        private string _DoctorName;
        private int _DoctorCate;
        private string _DoctorAddress;
        private string _DoctorImage;
        private string _DoctorEmail;
        private string _DoctorMobile;
        private string _DoctorWorkPlace;
        private string _DoctorInfo;
        private string _DoctorPosition;
        private string _DoctorExperience;
        private string _DoctorAwards;
        private string _DoctorLevel;
        private string _DoctorResearchWorks;
        private string _DoctorServices;
        private string _DoctorTraining;
        private string _DoctorOrganization;
        private string _DoctorLanguage;
        private int _DoctorOrd;
        private bool _Active;
        private DateTime _DateSave;
        private string _cateIdList;
        private string _cateIdListName;
        private int _Tongso;

        #endregion
        #region Public Properties  
        public int id { get { return _id; } set { _id = value; } }
        public string DoctorName { get { return _DoctorName; } set { _DoctorName = value; } }
        public int DoctorCate { get { return _DoctorCate; } set { _DoctorCate = value; } }
        public string DoctorAddress { get { return _DoctorAddress; } set { _DoctorAddress = value; } }
        public string DoctorImage { get { return _DoctorImage; } set { _DoctorImage = value; } }
        public string DoctorEmail { get { return _DoctorEmail; } set { _DoctorEmail = value; } }
        public string DoctorMobile { get { return _DoctorMobile; } set { _DoctorMobile = value; } }
        public string DoctorWorkPlace { get { return _DoctorWorkPlace; } set { _DoctorWorkPlace = value; } }
        public string DoctorInfo { get { return _DoctorInfo; } set { _DoctorInfo = value; } }
        public string DoctorPosition { get { return _DoctorPosition; } set { _DoctorPosition = value; } }
        public string DoctorExperience { get { return _DoctorExperience; } set { _DoctorExperience = value; } }
        public string DoctorAwards { get { return _DoctorAwards; } set { _DoctorAwards = value; } }
        public string DoctorLever { get { return _DoctorLevel; } set { _DoctorLevel = value; } }
        public string DoctorResearchWorks { get { return _DoctorResearchWorks; } set { _DoctorResearchWorks = value; } }
        public string DoctorServices { get { return _DoctorServices; } set { _DoctorServices = value; } }
        public string DoctorTraining { get { return _DoctorTraining; } set { _DoctorTraining = value; } }
        public string DoctorOrganization { get { return _DoctorOrganization; } set { _DoctorOrganization = value; } }
        public string DoctorLanguage { get { return _DoctorLanguage; } set { _DoctorLanguage = value; } }
        public int DoctorOrd { get { return _DoctorOrd; } set { _DoctorOrd = value; } }
        public bool Active { get { return _Active; } set { _Active = value; } }
        public DateTime DateSave { get { return _DateSave; } set { _DateSave = value; } }

        public string cateIdList { get { return _cateIdList; } set { _cateIdList = value; } }
        public string cateIdListName { get { return _cateIdListName; } set { _cateIdListName = value; } }
        public HttpPostedFileBase ImageFile { get; set; }
        public int Tongso { get { return _Tongso; } set { _Tongso = value; } }
        #endregion





    }


}
