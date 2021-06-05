using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEDLATEC2019.Entity
{
    [Serializable]
    public class cms_Banner_rows
    {
        #region Constructors  
        public cms_Banner_rows() { }
        #endregion
        #region Private Fields  
        private int _bannerId;
        private int _planId;
        private string _title;
        private string _fileName;
        private string _fileMine;
        private int _width;
        private int _height;
        private string _clickUrl;
        private DateTime _addTime;
        private DateTime _expTime;
        private string _addTimeView;
        private string _expTimeView;
        private int _ord;
        private bool _active;
        private Int64 _hit;
        #endregion
        #region Public Properties  
        public int bannerId { get { return _bannerId; } set { _bannerId = value; } }
        public int planId { get { return _planId; } set { _planId = value; } }
        public string title { get { return _title; } set { _title = value; } }
        public string fileName { get { return _fileName; } set { _fileName = value; } }
        public string fileMine { get { return _fileMine; } set { _fileMine = value; } }
        public int width { get { return _width; } set { _width = value; } }
        public int height { get { return _height; } set { _height = value; } }
        public string clickUrl { get { return _clickUrl; } set { _clickUrl = value; } }
        public DateTime addTime { get { return _addTime; } set { _addTime = value; _addTimeView = _addTime.ToString("dd/MM/yyyy HH:mm:ss"); } }
        public DateTime expTime { get { return _expTime; } set { _expTime = value; _expTimeView = _expTime.ToString("dd/MM/yyyy HH:mm:ss"); } }
        public int ord { get { return _ord; } set { _ord = value; } }
        public bool active { get { return _active; } set { _active = value; } }
        public HttpPostedFileBase ImageFile { get; set; }

        public string addTimeView { get { return _addTimeView; } set { _addTimeView = value; } }
        public string expTimeView { get { return _expTimeView; } set { _expTimeView = value; } }

        public Int64 hit { get { return _hit; } set { _hit = value; } }
        #endregion
    }
}