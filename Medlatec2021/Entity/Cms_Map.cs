using System;
using System.Collections.Generic;
using System.Text;
namespace MEDLATEC.BusinessLayer
{
    [Serializable]
    public class Cms_Map
    {

        #region InnerClass

        #endregion

        #region Data Members

        private int _ID;
        private string _TenPK;
        private string _Diachi;
        private string _Img;
        private string _Giamdoc;
        private string _Hotline;
        private string _Website;
        private string _Fanpage;
        private string _Lo;
        private string _Lu;
        private string _Truso;
        private string _Khuvuc;
        private string _Thongso;
      

        #endregion

        #region Properties

        public int ID
        {
			 get { return _ID; }
			 set
			 {
				 if (_ID != value)
				 {
                    _ID = value;
					 
				 }
			 }
		}


		public string TenPK
        {
			 get { return _TenPK; }
			 set
			 {
				 if (_TenPK != value)
				 {
                    _TenPK = value;
					
				 }
			 }
		}
        public string Diachi
        {
            get { return _Diachi; }
            set
            {
                if (_Diachi != value)
                {
                    _Diachi = value;

                }
            }
        }
        public string Img
        {
            get { return _Img; }
            set
            {
                if (_Img != value)
                {
                    _Img = value;

                }
            }
        }
        public string Giamdoc
        {
            get { return _Giamdoc; }
            set
            {
                if (_Giamdoc != value)
                {
                    _Giamdoc = value;

                }
            }
        }
        public string Hotline
        {
            get { return _Hotline; }
            set
            {
                if (_Hotline != value)
                {
                    _Hotline = value;

                }
            }
        }
        public string Website
        {
            get { return _Website; }
            set
            {
                if (_Website != value)
                {
                    _Website = value;

                }
            }
        }
        public string Fanpage
        {
            get { return _Fanpage; }
            set
            {
                if (_Fanpage != value)
                {
                    _Fanpage = value;

                }
            }
        }
        public string Lo
        {
            get { return _Lo; }
            set
            {
                if (_Lo != value)
                {
                    _Lo = value;

                }
            }
        }
        public string Lu
        {
            get { return _Lu; }
            set
            {
                if (_Lu != value)
                {
                    _Lu = value;

                }
            }
        }
        public string Truso
        {
            get { return _Truso; }
            set
            {
                if (_Truso != value)
                {
                    _Truso = value;

                }
            }
        }
        public string Khuvuc
        {
            get { return _Khuvuc; }
            set
            {
                if (_Khuvuc != value)
                {
                    _Khuvuc = value;

                }
            }
        }

        public string Thongso
        {
            get { return _Thongso; }
            set
            {
                if (_Thongso != value)
                {
                    _Thongso = value;

                }
            }
        }


        #endregion

        #region Validation


        #endregion

    }


}
