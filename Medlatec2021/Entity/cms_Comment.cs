using System;
using System.Collections.Generic;
using System.Text;
namespace MEDLATEC.BusinessLayer
{
    [Serializable]
    public class cms_Comment
    {

		#region InnerClass
		public enum Cms_NewsFields
		{
            CommentId,

            NewsId,
            FullName,
            Email,
            Title,
            Content,
            DateCreate,
            Activate,
            linkNews,
            ImgAvatar, linkFB, type, CommentParent, status, CreateBy

        }
		#endregion

		#region Data Members

			int _CommentId;
			int _NewsId;
			
			string _FullName;
			string _Email;
			string _Title;
			string _Content;
		
			DateTime _DateCreate;
		
			bool _Activate;
		
			string _linkNews;
        string _ImgAvatar;

        string _linkFB;
       

        int _type;
			
			int _CommentParent;
        int _status;

        int _CreateBy;

        
        #endregion

        #region Properties

        public int CommentId
        {
			 get { return _CommentId; }
			 set
			 {
				 if (_CommentId != value)
				 {
                    _CommentId = value;
					 
				 }
			 }
		}

		public int NewsId
        {
			 get { return _NewsId; }
			 set
			 {
				 if (_NewsId != value)
				 {
                    _NewsId = value;
					
				 }
			 }
		}


        public string FullName
        {
            get { return _FullName; }
            set
            {
                if (_FullName != value)
                {
                    _FullName = value;

                }
            }
        }
        public string Email
        {
            get { return _Email; }
            set
            {
                if (_Email != value)
                {
                    _Email = value;

                }
            }
        }

        public string Title
        {
            get { return _Title; }
            set
            {
                if (_Title != value)
                {
                    _Title = value;

                }
            }
        }

        public string Content
        {
            get { return _Content; }
            set
            {
                if (_Content != value)
                {
                    _Content = value;

                }
            }
        }
        public DateTime DateCreate
        {
            get { return _DateCreate; }
            set
            {
                if (_DateCreate != value)
                {
                    _DateCreate = value;

                }
            }
        }

        public bool Activate
        {
            get { return _Activate; }
            set
            {
                if (_Activate != value)
                {
                    _Activate = value;

                }
            }
        }
        public string linkNews
        {
            get { return _linkNews; }
            set
            {
                if (_linkNews != value)
                {
                    _linkNews = value;

                }
            }
        }
        public string ImgAvatar
        {
            get { return _ImgAvatar; }
            set
            {
                if (_ImgAvatar != value)
                {
                    _ImgAvatar = value;

                }
            }
        }
        public string linkFB
        {
            get { return _linkFB; }
            set
            {
                if (_linkFB != value)
                {
                    _linkFB = value;

                }
            }
        }

        public int type
        {
			 get { return _type; }
			 set
			 {
				 if (_type != value)
				 {
                    _type = value;
					
				 }
			 }
		}
        public int CommentParent
        {
            get { return _CommentParent; }
            set
            {
                if (_CommentParent != value)
                {
                    _CommentParent = value;

                }
            }
        }
        public int status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;

                }
            }
        }
        public int CreateBy
        {
            get { return _CreateBy; }
            set
            {
                if (_CreateBy != value)
                {
                    _CreateBy = value;

                }
            }
        }


 
        

	
        #endregion

        #region Validation


        #endregion

    }


}
