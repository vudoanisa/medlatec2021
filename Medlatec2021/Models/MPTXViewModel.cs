using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MEDLATEC2019.Models
{
    public class MPTXViewModel
    {
        [Required]
        [Display(Name = "Họ và tên")]
        public string txthoten { get; set; }

        [Required]
        [Display(Name = "Số điện thoại")]
        public string txtdt { get; set; }

        [Required]
        [Display(Name = "Dịch vụ")]
        public string Dichvu { get; set; }

        [Required]
        [Display(Name = "Ngày đăng ký")]
        public string ngaydangky { get; set; }


        [Required]
        [Display(Name = "Mội dung")]
        public string noidung { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string txtEmail { get; set; }


        [Required]
        [Display(Name = "Địa chỉ")]
        public string txtAddress { get; set; }

        [Required]
        [Display(Name = "Ghi chú")]
        public string txtnote { get; set; }

        [Required]
        [Display(Name = "Lỗi")]
        public string txtError { get; set; }

    }
}