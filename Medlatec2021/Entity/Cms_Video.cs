using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace MEDLATEC.BusinessLayer
{
    [Serializable]
    public class Cms_Video
    {

        #region InnerClass

        #endregion

        #region Data Members

        private int _videoId;
        private string _VideoName;
        

        private string _VideoTitle;
        private string _VideoDescription;
        private int _VideoType;

        private string _VideoFile;
        private string _VideoCode;
        private string _VideoImageThumb;

        private int _VideoWidth;
        private int _VideoHight;
        private bool _VideoActive;
        private DateTime _dateCreate;


        private int _vId;
        private string _vName;
        private string _vTitle;
        private string _vDescription;
        private string _vKeyword;
        private bool _vActive;
        private string _linkvideo;
        private string _linkUrl;
        private string _VideoFileWeb;

        #endregion
        #region Public Properties  
        public int videoId { get { return _videoId; } set { _videoId = value; } }

        public string VideoName { get { return _VideoName; } set { _VideoName = value; } }
        public string VideoFileWeb { get { return _VideoFileWeb; } set { _VideoFileWeb = value; } }
        public string Linkvideo { get { return _linkvideo; } set { _linkvideo = value; } }
        public string VideoTitle { get { return _VideoTitle; } set { _VideoTitle = value; } }
        public string VideoDescription { get { return _VideoDescription; } set { _VideoDescription = value; } }
        public int VideoType { get { return _VideoType; } set { _VideoType = value; } }   
        public string VideoFile { get { return _VideoFile; } set { _VideoFile = value; } }
        public string VideoCode { get { return _VideoCode; } set { _VideoCode = value; } }
        public string VideoImageThumb { get { return _VideoImageThumb; } set { _VideoImageThumb = value; } }
        public int VideoWidth { get { return _VideoWidth; } set { _VideoWidth = value; } }
        public int VideoHight { get { return _VideoHight; } set { _VideoHight = value; } }

        public bool VideoActive { get { return _VideoActive; } set { _VideoActive = value; } }
        public DateTime dateCreate { get { return _dateCreate; } set { _dateCreate = value; } }
        public int vId { get { return _vId; } set { _vId = value; } }

        public string vName { get { return _vName; } set { _vName = value; } }
        public string vTitle { get { return _vTitle; } set { _vTitle = value; } }
        public string vDescription { get { return _vDescription; } set { _vDescription = value; } }
        public string vKeyword { get { return _vKeyword; } set { _vKeyword = value; } }
        public bool vActive { get { return _vActive; } set { _vActive = value; } }

        public string linkUrl { get { return CMS_Core.Common.Common.GetURLDetailVideoByNews("video", VideoName, vId.ToString(), videoId.ToString()); } set { linkUrl = value; } }


        #endregion





    }


}
