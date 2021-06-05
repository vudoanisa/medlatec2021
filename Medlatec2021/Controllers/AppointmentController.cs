using CaptchaMvc.HtmlHelpers;
using CMS_Core.Common;
using Dapper;
using MEDLATEC.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using MEDLATEC2019.Entity;

namespace MEDLATEC2019.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            SQLServerConnection<Cms_News> sQLServer = new SQLServerConnection<Cms_News>();
            List<Cms_News> _News = sQLServer.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.News = _News;

            List<SelectListItem> items = new List<SelectListItem>();
            for (int i = 0; i < 31; i++)
            {
                items.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }

            ViewBag.dllTest = items;
            return View();
        }



        public ActionResult DatLich(string manv)
        {          

            MEDLATEC2019.Entity.DatLich datLich = new Entity.DatLich();
            datLich.Email = string.Empty;
            datLich.Hoten = string.Empty;
            datLich.Ghichu = string.Empty;
            datLich.Diachi = string.Empty;
            datLich.Sdt = string.Empty;
            datLich.Namsinh1 = DateTime.Now.ToString("dd/MM/yyyy");


            if (string.IsNullOrEmpty(manv))
            {
                manv = string.Empty;
            }
            else
            {
                try
                {
                    manv = manv.Replace(" ", "+");
                    manv = AES.Decrypt(manv, "");
                    manv = manv.Replace("\u000f", "").Trim();
                    manv = manv.Replace("\u000e", "").Trim();
                    manv = manv.Replace("\u0010", "").Trim();

                    string url = "api/CCOMed/GetInfoNV?MaNhanVien=" + manv + "&token=" + Common.generalKeyPrivate(manv);
                    var result = ImpCallAPI<InfoNV>.geContentAPI(url);
                    if (result != null)
                    {
                        if (result.Count > 0)
                        {
                            datLich.Manv = result[0].Manhanvien;
                            datLich.Nguogioithieu = "Chức vụ: " + result[0].TuKhoaDongName + " ,họ tên:" + result[0].Hoten + " ,mã nhân viên:" + result[0].Manhanvien;
                        }
                    }
                }
                catch ( Exception ex)
                {
                    manv = string.Empty;
                    datLich.Manv = manv;
                }
            }


            this.ViewBag.GetDichvu = Common.GetGioiTinh();
            return View(datLich);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DatLich(MEDLATEC2019.Entity.DatLich obj)
        {
            this.ViewBag.GetDichvu = Common.GetGioiTinh();


            try
            {
                if (string.IsNullOrEmpty(obj.Hoten))
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View(obj);
                }

                if (string.IsNullOrEmpty(obj.Sdt))
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập số điện thoại');</script>";
                    return View(obj);
                }
                else
                {
                    if (IsNumeric(obj.Sdt.Trim()))
                    {
                        if ((obj.Sdt.Trim().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Mời bạn nhập số điện thoại');</script>";
                            return View(obj);
                        }
                    }
                }

                string date = obj.Namsinh1;
                DateTime Namsinh = new DateTime();
                if (!string.IsNullOrEmpty(date))
                {
                    Namsinh = DateTime.ParseExact(date, "dd/MM/yyyy", new CultureInfo("en-US"));

                }
                else
                {
                    Namsinh = DateTime.Parse(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2"));
                }
                obj.Namsinh = Namsinh;

                string ghichudv = "WebMed - Đặt lịch OL Tại Nhà";
                string pldl = "TNOL";

                CMS_Core.Common.Common.Datlich(obj.Gioitinh.ToString(), obj.Hoten, obj.Sdt, obj.Ghichu + obj.Nguogioithieu , obj.Email, Namsinh.ToString("dd/MM/yyyy"), obj.Diachi, ghichudv, pldl);



                Response.Redirect("/thankyou?u=datlichlaymau", false);
            }
            catch (Exception ex)
            {

            }

            return View(obj);
        }




        private void getNews()
        {
            SQLServerConnection<Cms_News> sQLServer = new SQLServerConnection<Cms_News>();
            List<Cms_News> _News = sQLServer.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.News = _News;

            List<SelectListItem> items = new List<SelectListItem>();
            for (int i = 0; i < 31; i++)
            {
                items.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }

            ViewBag.dllTest = items;

        }
        public ActionResult GetComboxTest()
        {
            return View();

        }
        public ActionResult Thankyou1()
        {
            return View();

        }

        public ActionResult Thankyou2()
        {
            return View();

        }

        public ActionResult Thankyou3()
        {
            return View();

        }

        public ActionResult Thankyou4()
        {
            return View();

        }

        public ActionResult Thankyou5()
        {
            return View();

        }



        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Home(FormCollection form)
        {


            try
            {


                SQLServerConnection<Cms_News> sQLServer = new SQLServerConnection<Cms_News>();
                List<Cms_News> _News = sQLServer.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.News = _News;



                string date = form["txtngaysinh"].ToString();
                DateTime Tungay = new DateTime();
                if (!string.IsNullOrEmpty(date))
                {
                    Tungay = DateTime.ParseExact(date, "dd/MM/yyyy", new CultureInfo("en-US"));

                }
                else
                {
                    Tungay = DateTime.Parse(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2"));
                }

                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtdt"].ToString().Trim()))
                {
                    if (IsNumeric(form["txtdt"].ToString().Trim()))
                    {

                        if ((form["txtdt"].ToString().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện thoại phải là 10 số.');</script>";
                            return View();
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập số điện thoại');</script>";
                    return View();

                }



                var gt = form["dllGT"];
                gt.ToString();
                string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");


                string hoten = form["txthoten"].ToString();
                string dt = form["txtdt"].ToString();
                string ngayhen = DateTime.Parse(abc).ToString();
                string ghichu = form["txtghichu"].ToString();
                string email = form["txtemail"].ToString();
                string gioitinh = gt.ToString();
                if (gioitinh == "2")
                    gioitinh = "0";
                string namsinh = date;
                string diachi = form["txtdiachi"].ToString();
                string ghichudv = "WebMed - Đặt lịch OL Tại Nhà";
                string pldl = "TNOL";



                string danhmuc = gt.ToString();
                string namsinh2 = Tungay.ToString("MM-dd-yyyy");
                CMS_Core.Common.Common.Datlich(gt, hoten, dt, ghichu, email, namsinh, diachi, ghichudv, pldl);


                Response.Redirect("/thankyou?u=datlichlaymau", false);
                // TempData["msg"] = "<script>alert('Cảm ơn Quý khách đã đăng ký DV khám tại nhà. Chúng tôi sẽ liên lạc với Quý khách để xác nhận lịch hẹn.LH 1900565656 khi cần hỗ trợ. Rất hân hạnh được phục vụ!    ');</script>";
                // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                // TempData["msg"] = "<script>alert('Cam on Quy khach da dang ky DV Kham tai nha. Chung toi se lien lac voi Quy khach de xac nhan lich hen. LH 1900565656 khi can ho tro. Rat han hanh duoc phuc vu!    ');</script>";
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        [HttpPost]
        public ActionResult TaiVien(FormCollection form)
        {
            //try
            //{
            SQLServerConnection<Cms_News> sQLServer = new SQLServerConnection<Cms_News>();
            List<Cms_News> _News = sQLServer.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.News = _News;
            string date = form["txtngaysinh"].ToString();
            DateTime Tungay = new DateTime();
            if (!string.IsNullOrEmpty(date))
            {
                Tungay = DateTime.ParseExact(date, "dd/MM/yyyy", new CultureInfo("en-US"));
            }
            else
            {
                Tungay = DateTime.Parse(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2"));
            }
            if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
            {

            }
            else
            {
                TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                //return View();
            }
            if (!string.IsNullOrEmpty(form["txtdt"].ToString().Trim()))
            {
                if (IsNumeric(form["txtdt"].ToString().Trim()))
                {
                    if ((form["txtdt"].ToString().Length != 10))
                    {
                        TempData["msg"] = "<script>alert('Số điện thoại phải là 10 số.');</script>";
                        return View();
                    }
                }
                else
                {
                }
            }
            else
            {
                TempData["msg"] = "<script>alert('Mời bạn nhập số điện thoại');</script>";
                return View();
            }
            SqlConnection _conn;
            _conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
            _conn.Open();

            string myValue = form["txtemail"];
            // Info.  
            string sql = string.Empty;
            sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,email,Gioitinh,Namsinh,address,Ghichudv,PLDL,Gio1,DonVi) values(";
            sql += "@hoten,@sdt,@ngayhen,@ghichu,0,@email,@gioitinh,@namsinh,@diachi,N'WebMed - Đặt lịch OL Tại Viện','TVOL',@gio1,@Donvi)";

            SqlCommand comd = new SqlCommand(sql, _conn);
            var gt = form["dllGT"];
            gt.ToString();
            string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");
            comd.Parameters.AddWithValue("@hoten", SqlDbType.NVarChar).Value = form["txthoten"].ToString();
            comd.Parameters.AddWithValue("@sdt", SqlDbType.NVarChar).Value = form["txtdt"].ToString();
            comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(form["txtThoiGianKham"].ToString());
            comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();
            comd.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = form["txtemail"].ToString();
            comd.Parameters.AddWithValue("@gioitinh", SqlDbType.Int).Value = int.Parse(gt.ToString());
            comd.Parameters.AddWithValue("@namsinh", SqlDbType.SmallDateTime).Value = DateTime.Parse(form["txtngaysinh"].ToString());
            comd.Parameters.AddWithValue("@diachi", SqlDbType.NVarChar).Value = form["txtdiachi"].ToString();
            comd.Parameters.AddWithValue("@Gio1", SqlDbType.NVarChar).Value = form["txtKhungGio"].ToString();
            comd.Parameters.AddWithValue("@DonVi", SqlDbType.NVarChar).Value = form["ddrDiaDiem"].ToString();
            comd.ExecuteNonQuery();
            _conn.Close();
            Response.Redirect("/thankyou", false);
            //}
            //catch (Exception ex)
            //{
            //    TempData["msg"] = "<script>alert('Nhập đầy đủ thông tin!');</script>";
            //    return View();
            //}
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult TaiVien()
        {
            getNews();
            return View();
        }

        public static bool IsNumeric(string input)
        {
            return Regex.IsMatch(input, @"^\d+$");
        }
    }
}