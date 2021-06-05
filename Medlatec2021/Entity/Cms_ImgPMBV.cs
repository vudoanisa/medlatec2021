using System;
using System.Collections.Generic;
using System.Text;
namespace MEDLATEC.BusinessLayer
{
    [Serializable]
    public class Cms_ImgPMBV
    {
        public int ID { get; set; }
        public int IDCLS { get; set; }
        public string MaCP { get; set; }
        public string MaLoaiKT { get; set; }
        public string Anh { get; set; }
        public string _AnhLink { get; set; }


    }
}
