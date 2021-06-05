using System;
using System.Collections.Generic;
using System.Text;
namespace MEDLATEC.BusinessLayer
{
    [Serializable]
    public class Question
    {
        #region Constructors  
        public Question() { }
        #endregion
        #region Private Fields  
        private int _QuestionID;
        private string _QuestionTitle;
        private string _QuestionContent;
        private int _SpecialistID;
        private int _UserID;
        private string _Gender;
        private string _BirthYear;
        private string _FullName;
        private string _Phone;
        private string _Email;
        private string _Address;
        private int _Reader;
        private int _CountRead;
        private int _CountAnswer;
        private bool _Active;
        private int _DoctorID;
        private DateTime _ExprireTime;
        private string _ImgStr;
        private string _ImgThumbnailStr;
        private DateTime _DateCreate;
        private int _CountLike;
        private int _CountComment;
        private int _CountShare;
        private string _KeySearchTitle;
        private string _QuestionImage;
        private string _TypeDevice;
        private string _SpecialName;
        private DateTime _ngayhoi;
        private DateTime _ngaytraloi;
        private string _AnswerContent;
        private int _Total;
        private string _AnswerContentAutoLink;

        #endregion
        #region Public Properties  
        public int QuestionID { get { return _QuestionID; } set { _QuestionID = value; } }
        public string QuestionTitle { get { return _QuestionTitle; } set { _QuestionTitle = value; } }
        public string QuestionContent { get { return _QuestionContent; } set { _QuestionContent = value; } }
        public int SpecialistID { get { return _SpecialistID; } set { _SpecialistID = value; } }
        public int UserID { get { return _UserID; } set { _UserID = value; } }
        public string Gender { get { return _Gender; } set { _Gender = value; } }
        public string BirthYear { get { return _BirthYear; } set { _BirthYear = value; } }
        public string FullName { get { return _FullName; } set { _FullName = value; } }
        public string Phone { get { return _Phone; } set { _Phone = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
        public string Address { get { return _Address; } set { _Address = value; } }
        public int Reader { get { return _Reader; } set { _Reader = value; } }
        public int CountRead { get { return _CountRead; } set { _CountRead = value; } }
        public int CountAnswer { get { return _CountAnswer; } set { _CountAnswer = value; } }
        public bool Active { get { return _Active; } set { _Active = value; } }
        public int DoctorID { get { return _DoctorID; } set { _DoctorID = value; } }
        public DateTime ExprireTime { get { return _ExprireTime; } set { _ExprireTime = value; } }
        public string ImgStr { get { return _ImgStr; } set { _ImgStr = value; } }
        public string ImgThumbnailStr { get { return _ImgThumbnailStr; } set { _ImgThumbnailStr = value; } }
        public DateTime DateCreate { get { return _DateCreate; } set { _DateCreate = value; } }
        public int CountLike { get { return _CountLike; } set { _CountLike = value; } }
        public int CountComment { get { return _CountComment; } set { _CountComment = value; } }
        public int CountShare { get { return _CountShare; } set { _CountShare = value; } }
        public string KeySearchTitle { get { return _KeySearchTitle; } set { _KeySearchTitle = value; } }
        public string QuestionImage { get { return _QuestionImage; } set { _QuestionImage = value; } }
        public string TypeDevice { get { return _TypeDevice; } set { _TypeDevice = value; } }




        public string SpecialName { get { return _SpecialName; } set { _SpecialName = value; } }
        public DateTime NgayTraLoi { get { return _ngaytraloi; } set { _ngaytraloi = value; } }
        public DateTime NgayHoi { get { return _ngayhoi; } set { _ngayhoi = value; } }
        public string AnswerContent { get { return _AnswerContent; } set { _AnswerContent = value; } }
        public int Total { get { return _Total; } set { _Total = value; } }

        public string AnswerContentAutoLink { get { return _AnswerContentAutoLink; } set { _AnswerContentAutoLink = value; } }
        
        #endregion


    }
}
