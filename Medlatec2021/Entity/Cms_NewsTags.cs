using System;
using System.Collections.Generic;
using System.Text;
namespace MEDLATEC.BusinessLayer
{
    [Serializable]
    public class Cms_NewsTags
    {

		#region InnerClass
		public enum Cms_NewsFields
		{
			NewsId,
            
			Tagid,
			TagName
		
        }
		#endregion

		#region Data Members

			int _newsId;
			int _Tagid;
			string _TagName;
			
        #endregion

        #region Properties

        public int  NewsId
		{
			 get { return _newsId; }
			 set
			 {
				 if (_newsId != value)
				 {
					_newsId = value;
					 
				 }
			 }
		}


        public int Tagid
        {
            get { return _Tagid; }
            set
            {
                if (_Tagid != value)
                {
                    _Tagid = value;

                }
            }
        }

        public string TagName
        {
			 get { return _TagName; }
			 set
			 {
				 if (_TagName != value)
				 {
                    _TagName = value;
					
				 }
			 }
		}


	


        #endregion

        #region Validation


        #endregion

    }


}
