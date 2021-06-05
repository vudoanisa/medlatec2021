using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEDLATEC2019.Entity
{
    [Serializable]
    public class Goikham
    {
        int pIDGoi;
        string pMaGoi;
        string pTenGoi;
        DateTime pNgayBan;
        string pTel;
        DateTime pNgayKham;
        DateTime pGioHen1;
        DateTime pGioHen2;
        string pNguoiMua;
        string pDiaChi;
        string pEmail;

        public int pIDGoi1 { get => pIDGoi; set => pIDGoi = value; }
        public string pMaGoi1 { get => pMaGoi; set => pMaGoi = value; }
        public string pTenGoi1 { get => pTenGoi; set => pTenGoi = value; }
        public DateTime pNgayBan1 { get => pNgayBan; set => pNgayBan = value; }
        public string pTel1 { get => pTel; set => pTel = value; }

        public DateTime pNgayKham1 { get => pNgayKham; set => pNgayKham = value; }
        public DateTime pGioHen11 { get => pGioHen1; set => pGioHen1 = value; }
        public DateTime pGioHen21 { get => pGioHen2; set => pGioHen2 = value; }


        public string pNguoiMua1 { get => pNguoiMua; set => pNguoiMua = value; }
        public string pDiaChi1 { get => pDiaChi; set => pDiaChi = value; }
        public string pEmail1 { get => pEmail; set => pEmail = value; }
    }
}