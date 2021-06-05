using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEDLATEC2019.BusinessLayer
{
    
    
    public class Phongkham
    {
        public int OrganizeID { get; set; }
        public string OrganizeCode { get; set; }
        public string OrganizeName { get; set; }
        public bool Active { get; set; }
        public string ImageStr { get; set; }
        public bool IsShowResult { get; set; }
        public DateTime? DateCreate { get; set; }
        public int OrderNum { get; set; }
        public string Email { get; set; }
        public string OrganizeAddress { get; set; }
        public int OrganizeType { get; set; }

    }
}