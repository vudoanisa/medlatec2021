using MEDLATEC.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MEDLATEC2019.Models
{
    public class VideoHomeViewModel
    {
        [Required]
        [Display(Name = "Video Top")]
        public Cms_Video VideoTop { get; set; }

        public List<Cms_Video> videoCate1 { get; set; }

        public List<Cms_Video> videoCate2 { get; set; }

        public List<Cms_Video> videoCate3 { get; set; }
        public List<Cms_Video> videoCate4 { get; set; }
        public List<Cms_Video> videoCate5 { get; set; }
        public List<Cms_Video> videoCate6 { get; set; }
        public List<Cms_Video> videoCate7 { get; set; }

        public List<Cms_Video> videoCate8 { get; set; }
        public List<Cms_Video> videoCate9 { get; set; }
    }
}