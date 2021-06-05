using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEDLATEC2019.Entity
{
    [Serializable]

    public class ImageCLS
    {
        #region Constructors  
        public ImageCLS() { }
        #endregion
        #region Private Fields  
        private int ID;
        private int IDCLS;
        private string MaCP;
        private string MaLoaiKT;
        private string imageLink;
        private bool _InKQ;
        private DateTime _createdate;
        private int IDAnhCLS;
        private int _Accession_no;
        private int _PATIENT_ID;
        private byte[] _IMG;
        #endregion
        #region Public Properties  
        public int _ID { get { return ID; } set { ID = value; } }
        public int _IDCLS { get { return IDCLS; } set { IDCLS = value; } }
        public string _MaCP { get { return MaCP; } set { MaCP = value; } }
        public string _MaLoaiKT { get { return MaLoaiKT; } set { MaLoaiKT = value; } }
        public string _imageLink { get { return imageLink; } set { imageLink = value; } }
        public bool InKQ { get { return _InKQ; } set { _InKQ = value; } }
        public DateTime createdate { get { return _createdate; } set { _createdate = value; } }
        public int _IDAnhCLS { get { return IDAnhCLS; } set { IDAnhCLS = value; } }
        public int Accession_no { get { return _Accession_no; } set { _Accession_no = value; } }
        public int PATIENT_ID { get { return _PATIENT_ID; } set { _PATIENT_ID = value; } }
        public byte[] IMG { get { return _IMG; } set { _IMG = value; } }
        #endregion  }


    }
}