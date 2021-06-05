using MEDLATEC.BusinessLayer;
using MEDLATEC2019.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEDLATEC2019.Models
{
    public class ScientistViewModel
    {
        public string DatePerform { get; set; }
        public string ScientistCate { get; set; }

        public int tongso { get; set; }

        public int page { get; set; }

        public string keyworkd { get; set; }
        public string PersionPerform { get; set; }
        public cms_Scientist ScientistDetail { get; set; }

        public List<cms_Scientist> Scientist { get; set; }
        public List<cms_Scientist> ScientistNew { get; set; }


        public List<cms_Scientist_Cate> Scientist_Cates { get; set; }

        public List<Cms_News> News { get; set; }
    }
}