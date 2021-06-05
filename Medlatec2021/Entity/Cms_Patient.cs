using System;
using System.Collections.Generic;
using System.Text;
namespace MEDLATEC.BusinessLayer
{
    [Serializable]
    public class Cms_Patient
    {
        #region Constructors  
        public Cms_Patient() { }
        #endregion
        #region Private Fields  
        private DateTime _Intime;
        private string _PID;
        private string _SID;
        private string _PatientName;
        private string _Age;
        private string _Sex;
        private float _SumMoney;
        private float _SumPerTage;
        private float _SumTransport;
        private float _Total;


        private string _LocationID;
        private string _LocationName;
        private string _DoctorID;
        private string _DoctorName;
        private string _Address;
        private string _Phone;
        private bool _Valid;
        private bool _FullResult;
        private int _Random;
        private bool _ShowWeb;
        private string _Description;
        private bool _ShowMoney;

        private string _Mabs;
        private string _Tenbs;


        #endregion
        #region Public Properties  
        public DateTime Intime { get { return _Intime; } set { _Intime = value; } }
        public string PID { get { return _PID; } set { _PID = value; } }
        public string SID { get { return _SID; } set { _SID = value; } }

        public string PatientName { get { return _PatientName; } set { _PatientName = value; } }
        public string Age { get { return _Age; } set { _Age = value; } }
        public string Sex { get { return _Sex; } set { _Sex = value; } }

        public float SumMoney { get { return _SumMoney; } set { _SumMoney = value; } }
        public float SumPerTage { get { return _SumPerTage; } set { _SumPerTage = value; } }
        public float SumTransport { get { return _SumTransport; } set { _SumTransport = value; } }
        public float Total { get { return _Total; } set { _Total = value; } }


        public string LocationID { get { return _LocationID; } set { _LocationID = value; } }
        public string LocationName { get { return _LocationName; } set { _LocationName = value; } }
        public string DoctorID { get { return _DoctorID; } set { _DoctorID = value; } }
        public string DoctorName { get { return _DoctorName; } set { _DoctorName = value; } }
        public string Address { get { return _Address; } set { _Address = value; } }




        public string Phone { get { return _Phone; } set { _Phone = value; } }
        public bool Valid { get { return _Valid; } set { _Valid = value; } }
        public bool FullResult { get { return _FullResult; } set { _FullResult = value; } }
        public int Random { get { return _Random; } set { _Random = value; } }
        public bool ShowWeb { get { return _ShowWeb; } set { _ShowWeb = value; } }
        public string Description { get { return _Description; } set { _Description = value; } }
        public bool ShowMoney { get { return _ShowMoney; } set { _ShowMoney = value; } }


        public string Mabs { get { return _Mabs; } set { _Mabs = value; } }
        public string Tenbs { get { return _Tenbs; } set { _Tenbs = value; } }




        #endregion


    }
}
