using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MEDLATEC2019.Models
{
    public class MapViewModel
    {
        [Required]
        [Display(Name = "Vị trí")]
        public string Khuvuc { get; set; }

    }
}