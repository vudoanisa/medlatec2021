using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEDLATEC2019.BusinessLayer
{
    
    
    public class Chuyenkhoa
    {
        public int SpecialistID { get; set; }
        public string SpecialName { get; set; }
        public bool Active { get; set; }
        public string DateU { get; set; }
      
        public DateTime DateCreate { get; set; }
        public int OrderNum { get; set; }
        public string DateC { get; set; }
        public string UserCreate { get; set; }
        public string UserUpdate { get; set; }

    }
}