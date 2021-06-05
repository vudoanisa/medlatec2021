using System;
using System.Collections.Generic;
using System.Text;
namespace MEDLATEC.BusinessLayer
{
    [Serializable]
    public class Cms_News
    {

        #region InnerClass
        public enum Cms_NewsFields
        {
            NewsId,

            CateId,
            SourceId,
            UserId,
            NewsName,
            NewsKeyword,
            NewsDescription,
            NewsContent,
            NewsImages,
            NewsTitleImages,
            IsShowImages,
            NewsAuthor,
            DateCreate,
            NewsFile,
            CopyRight,
            AllowComment,
            AlowSend,
            AlowPrint,
            Lang,
            AccountTypeId,
            Active,
            CountR,
            Tukhoa,
            Type,
            ChuyenmonID,
            MotaSeo,
            Datepub,
            UrlSource, Slug, ParentName, Tags, CateName, cateDescription, TitleSeo, cateKeyword, Tongso, newsContentAutoLink, TagId, TagName, doctor_ID, DoctorName, isTextToSpeed, idTextToSpeed, linkAudio
        }
        #endregion

        #region Data Members

        int _newsId;
        int _cateId;
        int _sourceId;
        int _userId;
        string _newsName;
        string _newsKeyword;
        string _newsDescription;
        string _newsContent;
        string _newsImages;
        string _newsImagesweb;
        string _newsTitleImages;
        bool _isShowImages;
        string _newsAuthor;
        DateTime _dateCreate;
        string _newsFile;
        bool _copyRight;
        bool _allowComment;
        bool _alowSend;
        bool _alowPrint;
        string _lang;
        int _accountTypeId;
        bool _active;
        long _countR;
        string _tukhoa;
        string _type;
        int _chuyenmonID;
        string _motaSeo;
        DateTime _datepub;
        string _urlSource;
        string _ParentName;
        string _Tagsr;
        string _CateName;
        string _cateDescription;
        string _TitleSeo;
        string _cateKeyword;
        int _Tongso;
        string _newsContentAutoLink;
        int _TagId;
        string _TagName;
        int _doctor_ID;
        string _DoctorName;


        int _isTextToSpeed;
        string _idTextToSpeed;
        string _linkAudio;
        #endregion

        #region Properties

        public int NewsId
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

        public int CateId
        {
            get { return _cateId; }
            set
            {
                if (_cateId != value)
                {
                    _cateId = value;

                }
            }
        }

        public int SourceId
        {
            get { return _sourceId; }
            set
            {
                if (_sourceId != value)
                {
                    _sourceId = value;

                }
            }
        }

        public int UserId
        {
            get { return _userId; }
            set
            {
                if (_userId != value)
                {
                    _userId = value;

                }
            }
        }

        public string NewsName
        {
            get { return _newsName; }
            set
            {
                if (_newsName != value)
                {
                    _newsName = value;

                }
            }
        }

        public string NewsKeyword
        {
            get { return _newsKeyword; }
            set
            {
                if (_newsKeyword != value)
                {
                    _newsKeyword = value;

                }
            }
        }

        public string NewsDescription
        {
            get { return _newsDescription; }
            set
            {
                if (_newsDescription != value)
                {
                    _newsDescription = value;

                }
            }
        }

        public string NewsContent
        {
            get { return _newsContent; }
            set
            {
                if (_newsContent != value)
                {
                    _newsContent = value;

                }
            }
        }

        public string NewsImages
        {
            get { return _newsImages; }
            set
            {
                if (_newsImages != value)
                {
                    _newsImages = value;

                }
            }
        }

        public string newsImagesweb
        {
            get { return _newsImagesweb; }
            set
            {
                if (_newsImagesweb != value)
                {
                    _newsImagesweb = value;

                }
            }
        }

        

        public string NewsTitleImages
        {
            get { return _newsTitleImages; }
            set
            {
                if (_newsTitleImages != value)
                {
                    _newsTitleImages = value;

                }
            }
        }

        public bool IsShowImages
        {
            get { return _isShowImages; }
            set
            {
                if (_isShowImages != value)
                {
                    _isShowImages = value;

                }
            }
        }

        public string NewsAuthor
        {
            get { return _newsAuthor; }
            set
            {
                if (_newsAuthor != value)
                {
                    _newsAuthor = value;

                }
            }
        }

        public DateTime DateCreate
        {
            get { return _dateCreate; }
            set
            {
                if (_dateCreate != value)
                {
                    _dateCreate = value;

                }
            }
        }

        public string NewsFile
        {
            get { return _newsFile; }
            set
            {
                if (_newsFile != value)
                {
                    _newsFile = value;

                }
            }
        }

        public bool CopyRight
        {
            get { return _copyRight; }
            set
            {
                if (_copyRight != value)
                {
                    _copyRight = value;

                }
            }
        }

        public bool AllowComment
        {
            get { return _allowComment; }
            set
            {
                if (_allowComment != value)
                {
                    _allowComment = value;

                }
            }
        }

        public bool AlowSend
        {
            get { return _alowSend; }
            set
            {
                if (_alowSend != value)
                {
                    _alowSend = value;

                }
            }
        }

        public bool AlowPrint
        {
            get { return _alowPrint; }
            set
            {
                if (_alowPrint != value)
                {
                    _alowPrint = value;

                }
            }
        }

        public string Lang
        {
            get { return _lang; }
            set
            {
                if (_lang != value)
                {
                    _lang = value;

                }
            }
        }

        public int AccountTypeId
        {
            get { return _accountTypeId; }
            set
            {
                if (_accountTypeId != value)
                {
                    _accountTypeId = value;

                }
            }
        }

        public bool Active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value;

                }
            }
        }

        public long CountR
        {
            get { return _countR; }
            set
            {
                if (_countR != value)
                {
                    _countR = value;

                }
            }
        }

        public string Tukhoa
        {
            get { return _tukhoa; }
            set
            {
                if (_tukhoa != value)
                {
                    _tukhoa = value;

                }
            }
        }

        public string Type
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

        public int ChuyenmonID
        {
            get { return _chuyenmonID; }
            set
            {
                if (_chuyenmonID != value)
                {
                    _chuyenmonID = value;

                }
            }
        }

        public string MotaSeo
        {
            get { return _motaSeo; }
            set
            {
                if (_motaSeo != value)
                {
                    _motaSeo = value;

                }
            }
        }

        public DateTime Datepub
        {
            get { return _datepub; }
            set
            {
                if (_datepub != value)
                {
                    _datepub = value;

                }
            }
        }

        public string UrlSource
        {
            get { return _urlSource; }
            set
            {
                if (_urlSource != value)
                {
                    _urlSource = value;

                }
            }
        }

        public string ParentName
        {
            get { return _ParentName; }
            set
            {
                if (_ParentName != value)
                {
                    _ParentName = value;

                }
            }
        }
        public string Tagsr
        {
            get { return _Tagsr; }
            set
            {
                if (_Tagsr != value)
                {
                    _Tagsr = value;

                }
            }
        }
        public string CateName
        {
            get { return _CateName; }
            set
            {
                if (_CateName != value)
                {
                    _CateName = value;

                }
            }
        }
        public string cateDescription
        {
            get { return _cateDescription; }
            set
            {
                if (_cateDescription != value)
                {
                    _cateDescription = value;

                }
            }
        }
        public string TitleSeo
        {
            get { return _TitleSeo; }
            set
            {
                if (_TitleSeo != value)
                {
                    _TitleSeo = value;

                }
            }
        }
        public string cateKeyword
        {
            get { return _cateKeyword; }
            set
            {
                if (_cateKeyword != value)
                {
                    _cateKeyword = value;

                }
            }
        }
        public int Tongso
        {
            get { return _Tongso; }
            set
            {
                if (_Tongso != value)
                {
                    _Tongso = value;

                }
            }
        }

        public string newsContentAutoLink
        {
            get { return _newsContentAutoLink; }
            set
            {
                if (_newsContentAutoLink != value)
                {
                    _newsContentAutoLink = value;

                }
            }
        }

        public int TagId
        {
            get { return _TagId; }
            set
            {
                if (_TagId != value)
                {
                    _TagId = value;

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

        public int doctor_ID
        {
            get { return _doctor_ID; }
            set
            {
                if (_doctor_ID != value)
                {
                    _doctor_ID = value;

                }
            }
        }
        public string DoctorName
        {
            get { return _DoctorName; }
            set
            {
                if (_DoctorName != value)
                {
                    _DoctorName = value;

                }
            }
        }

        public int isTextToSpeed
        {
            get { return _isTextToSpeed; }
            set
            {
                if (_isTextToSpeed != value)
                {
                    _isTextToSpeed = value;

                }
            }
        }
        public string idTextToSpeed
        {
            get { return _idTextToSpeed; }
            set
            {
                if (_idTextToSpeed != value)
                {
                    _idTextToSpeed = value;

                }
            }
        }
        public string linkAudio
        {
            get { return _linkAudio; }
            set
            {
                if (_linkAudio != value)
                {
                    _linkAudio = value;

                }
            }
        }
        #endregion

        #region Validation


        #endregion

    }


}
