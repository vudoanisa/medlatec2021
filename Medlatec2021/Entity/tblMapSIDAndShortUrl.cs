using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEDLATEC2019.Entity
{
    [Serializable]
    public class tblMapSIDAndShortUrl
    {
        public int _ID { get; set; }
        public string _shortURL { get; set; }
        public string _sid { get; set; }
        public DateTime _datesave { get; set; }

    }
}