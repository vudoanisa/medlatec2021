using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEDLATEC2019.Entity
{
    [Serializable]
    public class DatLich
    {
        string hoten;
        string sdt;
        DateTime ngayhen;
        string ghichu;
        string email;
        int gioitinh;
        DateTime namsinh;
        string namsinh1;
        string diachi;
        string ghichudv;
        string PLDL;
        string tennguoilienhe;
        string manv;
        string nguogioithieu;

        int soluong;

        public string Manv { get => manv; set => manv = value; }
        public string Nguogioithieu { get => nguogioithieu; set => nguogioithieu = value; }

        public string Hoten { get => hoten; set => hoten = value; }
        public string Tennguoilienhe { get => tennguoilienhe; set => tennguoilienhe = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public DateTime Ngayhen { get => ngayhen; set => ngayhen = value; }
        public string Ghichu { get => ghichu; set => ghichu = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public string Email { get => email; set => email = value; }
        public int Gioitinh { get => gioitinh; set => gioitinh = value; }
        public DateTime Namsinh { get => namsinh; set => namsinh = value; }
        public string Namsinh1 { get => namsinh1; set => namsinh1 = value; }

        public string Diachi { get => diachi; set => diachi = value; }
        public string Ghichudv { get => ghichudv; set => ghichudv = value; }
        public string PLDL1 { get => PLDL; set => PLDL = value; }
    }
}