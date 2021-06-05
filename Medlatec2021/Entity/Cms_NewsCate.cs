using System;
using System.Collections.Generic;
using System.Text;
namespace MEDLATEC.BusinessLayer
{
    [Serializable]
    public class Cms_NewsCate
	{

		#region InnerClass
		public enum Cms_NewsFields
		{
			NewsId,
            CateName,
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
			UrlSource
		}
		#endregion

		#region Data Members

			int _newsId;
        string _CateName;
        int? _cateId;
			int? _sourceId;
			int? _userId;
			string _newsName;
			string _newsKeyword;
			string _newsDescription;
			string _newsContent;
			string _newsImages;
			string _newsTitleImages;
			bool? _isShowImages;
			string _newsAuthor;
			DateTime _dateCreate;
			string _newsFile;
			bool? _copyRight;
			bool? _allowComment;
			bool? _alowSend;
			bool? _alowPrint;
			string _lang;
			int? _accountTypeId;
			bool? _active;
			long? _countR;
			string _tukhoa;
			string _type;
			int? _chuyenmonID;
			string _motaSeo;
			DateTime? _datepub;
			string _urlSource;

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

		public int?  CateId
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

		public int?  SourceId
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

		public int?  UserId
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
        public string  NewsName
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

		public string  NewsKeyword
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

		public string  NewsDescription
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

		public string  NewsContent
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

		public string  NewsImages
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

		public string  NewsTitleImages
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

		public bool?  IsShowImages
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

		public string  NewsAuthor
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

		public DateTime  DateCreate
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

		public string  NewsFile
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

		public bool?  CopyRight
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

		public bool?  AllowComment
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

		public bool?  AlowSend
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

		public bool?  AlowPrint
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

		public string  Lang
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

		public int?  AccountTypeId
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

		public bool?  Active
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

		public long?  CountR
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

		public string  Tukhoa
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

		public string  Type
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

		public int?  ChuyenmonID
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

		public string  MotaSeo
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

		public DateTime?  Datepub
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

		public string  UrlSource
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


		#endregion

		#region Validation


		#endregion

	}


}
