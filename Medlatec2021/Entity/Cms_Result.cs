using System;
using System.Collections.Generic;
using System.Text;
namespace MEDLATEC.BusinessLayer
{
    [Serializable]
    public class Cms_Result
    {
        #region Constructors  
        public Cms_Result() { }
        #endregion
        #region Private Fields  
        private string SID;
        private string IDCLS;
        private string TestCode;
        private string TestName;
        private string TestNameE;
        private string Result;
        private string DiagnosticResult;
        private string Unit;
        private string Posneg;
        private string Comment;
        private string CommentE;
        private bool TestHead;
        private string NormalRange;
        private string NormalRangeF;
        private byte[] IMG1;
        private byte[] IMG2;
        private byte[] IMG3;
        private byte[] IMG4;
        private byte[] IMG5;
        

        private float Price;
        private string CategoryName;
        private string CategoryNameE;
        private string PhanLoai;
        private bool Valid;
        private bool ShowWeb;
        private string NgayCDHA;
        private string UserCDHA;

        private string _Category;
        private string _bstv;
        private string _tenbs;
        


        #endregion

        #region Public Properties  
        public string SID1 { get { return SID; } set { SID = value; } }
        public string Category { get { return _Category; } set { _Category = value; } }
        public string bstv { get { return _bstv; } set { _bstv = value; } }
        public string tenbs { get { return _tenbs; } set { _tenbs = value; } }

        public string IDCLS1 { get { return IDCLS; } set { IDCLS = value; } }
        public string TestCode1 { get { return TestCode; } set { TestCode = value; } }
        public string TestName1 { get { return TestName; } set { TestName = value; } }
        public string TestNameE1 { get { return TestNameE; } set { TestNameE = value; } }
        public string Result1 { get { return Result; } set { Result = value; } }
        public string DiagnosticResult1 { get { return DiagnosticResult; } set { DiagnosticResult = value; } }
        public string Unit1 { get { return Unit; } set { Unit = value; } }
        public string Posneg1 { get { return Posneg; } set { Posneg = value; } }
        public string Comment1 { get { return Comment; } set { Comment = value; } }
        public string CommentE1 { get { return CommentE; } set { CommentE = value; } }
        public bool TestHead1 { get { return TestHead; } set { TestHead = value; } }
        public string NormalRange1 { get { return NormalRange; } set { NormalRange = value; } }
        public byte[] IMG11 { get { return IMG1; } set { IMG1 = value; } }
        public byte[] IMG21 { get { return IMG2; } set { IMG2 = value; } }
        public byte[] IMG31 { get { return IMG3; } set { IMG3 = value; } }
        public byte[] IMG41 { get { return IMG4; } set { IMG4 = value; } }
        public byte[] IMG51 { get { return IMG5; } set { IMG5 = value; } }

        public string _strIMG1 { get; set; }
        public string _strIMG2 { get; set; }
        public string _strIMG3 { get; set; }
        public string _strIMG4 { get; set; }
        public string _strIMG5 { get; set; }


 
        public float Price1 { get { return Price; } set { Price = value; } }
        public string CategoryName1 { get { return CategoryName; } set { CategoryName = value; } }
        public string CategoryNameE1 { get { return CategoryNameE; } set { CategoryNameE = value; } }
        public string PhanLoai1 { get { return PhanLoai; } set { PhanLoai = value; } }
        public bool Valid1 { get { return Valid; } set { Valid = value; } }
        public bool ShowWeb1 { get { return ShowWeb; } set { ShowWeb = value; } }
        public string NgayCDHA1 { get { return NgayCDHA; } set { NgayCDHA = value; } }
        public string UserCDHA1 { get { return UserCDHA; } set { UserCDHA = value; } }
        public string NormalRange1F { get { return NormalRangeF; } set { NormalRangeF = value; } }
        #endregion
    }
}
