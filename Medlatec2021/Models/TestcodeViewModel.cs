using MEDLATEC.BusinessLayer;
using MEDLATEC2019.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEDLATEC2019.Models
{
    public class TestcodeViewModel
    {
        public tbl_TestCode TestCode { get; set; }
        public List<Cms_News> News { get; set; }

        public List<Question> QuestionS { get; set; }

        public List<Question> Questionnew { get; set; }

        public List<Cms_News> NewsNew { get; set; }
    }
}