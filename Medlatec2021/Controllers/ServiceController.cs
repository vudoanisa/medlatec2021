using CaptchaMvc.HtmlHelpers;
using CMS_Core.Common;
using MEDLATEC.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;


namespace MEDLATEC2019.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Sankhoa()
        {
            SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.TinNoiBat = _TinNoiBat;
          

            SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 152, 15, 1);
            ViewBag.NewsCate = _NewsCate;

            return View();
        }

        public ActionResult Truyennhiem()
        {
            SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.TinNoiBat = _TinNoiBat;


            SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 153, 15, 1);
            ViewBag.NewsCate = _NewsCate;

            return View();
        }

        public ActionResult Noitiet()
        {
            SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.TinNoiBat = _TinNoiBat;


            SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 172, 15, 1);
            ViewBag.NewsCate = _NewsCate;

            return View();
        }

        public ActionResult Namkhoa()
        {
            SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.TinNoiBat = _TinNoiBat;


            SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 174, 15, 1);
            ViewBag.NewsCate = _NewsCate;

            return View();
        }
        public ActionResult Taimuihong()
        {
            SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.TinNoiBat = _TinNoiBat;


            SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 156, 15, 1);
            ViewBag.NewsCate = _NewsCate;

            return View();
        }

        public ActionResult Timmach()
        {
            SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.TinNoiBat = _TinNoiBat;


            SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 175, 15, 1);
            ViewBag.NewsCate = _NewsCate;

            return View();
        }


        public ActionResult Ngoaikhoa()
        {
            SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.TinNoiBat = _TinNoiBat;


            SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 160, 15, 1);
            ViewBag.NewsCate = _NewsCate;

            return View();
        }


        public ActionResult Mat()
        {
            SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.TinNoiBat = _TinNoiBat;


            SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 158, 15, 1);
            ViewBag.NewsCate = _NewsCate;

            return View();
        }
        public ActionResult Ungbuou()
        {
            SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.TinNoiBat = _TinNoiBat;


            SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 151, 15, 1);
            ViewBag.NewsCate = _NewsCate;

            return View();
        }
        public ActionResult Thankinh()
        {
            SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.TinNoiBat = _TinNoiBat;


            SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 163, 15, 1);
            ViewBag.NewsCate = _NewsCate;

            return View();
        }

        public ActionResult Ranghammat()
        {
            SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.TinNoiBat = _TinNoiBat;


            SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 157, 15, 1);
            ViewBag.NewsCate = _NewsCate;

            return View();
        }
        public ActionResult Chandoanhinhanh()
        {
            SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.TinNoiBat = _TinNoiBat;


            SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 154, 15, 1);
            ViewBag.NewsCate = _NewsCate;

            return View();
        }
        public ActionResult ChuyenkhoaNoi()
        {
            SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.TinNoiBat = _TinNoiBat;


            SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 188, 15, 1);
            ViewBag.NewsCate = _NewsCate;

            return View();
        }


        public ActionResult XetNghiem()
        {
            SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.TinNoiBat = _TinNoiBat;


            SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 159, 15, 1);
            ViewBag.NewsCate = _NewsCate;

            return View();
        }



        public ActionResult Coxuongkhop()
        {
            SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.TinNoiBat = _TinNoiBat;


            SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 161, 15, 1);
            ViewBag.NewsCate = _NewsCate;

            return View();
        }
        public ActionResult Dalieu()
        {
            SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.TinNoiBat = _TinNoiBat;


            SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 189, 15, 1);
            ViewBag.NewsCate = _NewsCate;

            return View();
        }
        public ActionResult Nhikhoa()
        {
            SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.TinNoiBat = _TinNoiBat;


            SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 166, 15, 1);
            ViewBag.NewsCate = _NewsCate;

            return View();
        }
        public ActionResult Tieuhoa()
        {
            SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.TinNoiBat = _TinNoiBat;


            SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 173, 15, 1);
            ViewBag.NewsCate = _NewsCate;

            return View();
        }

        public static bool IsNumeric(string input)
        {
            return Regex.IsMatch(input, @"^\d+$");
        }
        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Sankhoa(FormCollection form)
        {


            try
            {
         
                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

                SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 152, 15, 1);
                ViewBag.NewsCate = _NewsCate;
                //}
                //catch (Exception ex)
                //{

                //}
                string ghichuwweb = "";


                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtsdt"].ToString().Trim()))
                {
                    if (IsNumeric(form["txtsdt"].ToString().Trim()))
                    {

                        if ((form["txtsdt"].ToString().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện không đúng');</script>";
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
                if (!string.IsNullOrEmpty(form["txtghichu"].ToString().Trim()))
                {

                }
                else
                {
                    ghichuwweb = "Khách hàng liên hệ từ website medlatec.";

                }


                SqlConnection _conn;
                _conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                _conn.Open();



                // Info.  
                string sql = string.Empty;
                sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,email,Ghichudv,PLDL) values(";
                sql += "@hoten,@sdt,@ngayhen,@ghichu,0,@email,N'WebMed - Đăng ký nhanh từ trang landing chuyên khoa sản khoa','WEBMEDMOI')";


                SqlCommand comd = new SqlCommand(sql, _conn);

                string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");

                comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 11).Value = form["txtsdt"].ToString();
                comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();
                comd.Parameters.Add("@email", SqlDbType.NVarChar, 30).Value = form["txtemail"].ToString();


              //  //comd.ExecuteNonQuery();
                _conn.Close();

                Response.Redirect("/thankyou", false);
                // TempData["msg"] = "<script>alert('Cảm ơn Quý khách đã đăng ký với chúng tôi. Chúng tôi sẽ liên lạc với Quý khách để xác nhận lịch hẹn.LH 1900565656 khi cần hỗ trợ. Rất hân hạnh được phục vụ!');</script>";
                // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                // TempData["msg"] = "<script>alert('Cam on Quy khach da dang ky DV Kham tai nha. Chung toi se lien lac voi Quy khach de xac nhan lich hen. LH 1900565656 khi can ho tro. Rat han hanh duoc phuc vu!    ');</script>";
            }
            catch (Exception ex)
            {

            }




            return View();
        }


        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Nhikhoa(FormCollection form)
        {


            try
            {

                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

                SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 166, 15, 1);
                ViewBag.NewsCate = _NewsCate;
                //}
                //catch (Exception ex)
                //{

                //}
                string ghichuwweb = "";


                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtsdt"].ToString().Trim()))
                {
                    if (IsNumeric(form["txtsdt"].ToString().Trim()))
                    {

                        if ((form["txtsdt"].ToString().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện không đúng');</script>";
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
                if (!string.IsNullOrEmpty(form["txtghichu"].ToString().Trim()))
                {

                }
                else
                {
                    ghichuwweb = "Khách hàng liên hệ từ website medlatec.";

                }


                //SqlConnection _conn;
                //_conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                //_conn.Open();



                //// Info.  
                //string sql = string.Empty;
                //sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,email,Ghichudv,PLDL) values(";
                //sql += "@hoten,@sdt,@ngayhen,@ghichu,0,@email,N'WebMed - Đăng ký nhanh từ trang landing chuyên khoa nhi','WEBMEDMOI')";


                //SqlCommand comd = new SqlCommand(sql, _conn);

                //string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");

                //comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                //comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 11).Value = form["txtsdt"].ToString();
                //comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                //comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();
                //comd.Parameters.Add("@email", SqlDbType.NVarChar, 30).Value = form["txtemail"].ToString();


                //comd.ExecuteNonQuery();
                //_conn.Close();

                //Response.Redirect("/thankyou", true);

                CMS_Core.Common.Common.DatlichTin(form["txthoten"].ToString(), form["txtsdt"].ToString(), form["txtghichu"].ToString(), form["txtemail"].ToString(), "WebMed - Đăng ký nhanh từ trang landing chuyên khoa nhi", "WEBMEDMOI");
                Response.Redirect("/thankyou?u=dichvunhikhoa", false);


                // TempData["msg"] = "<script>alert('Cảm ơn Quý khách đã đăng ký với chúng tôi. Chúng tôi sẽ liên lạc với Quý khách để xác nhận lịch hẹn.LH 1900565656 khi cần hỗ trợ. Rất hân hạnh được phục vụ!');</script>";
                // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                // TempData["msg"] = "<script>alert('Cam on Quy khach da dang ky DV Kham tai nha. Chung toi se lien lac voi Quy khach de xac nhan lich hen. LH 1900565656 khi can ho tro. Rat han hanh duoc phuc vu!    ');</script>";
            }
            catch (Exception ex)
            {

            }




            return View();
        }




        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Truyennhiem(FormCollection form)
        {


            try
            {

                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

                SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 153, 15, 1);
                ViewBag.NewsCate = _NewsCate;
                //}
                //catch (Exception ex)
                //{

                //}
                string ghichuwweb = "";


                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtsdt"].ToString().Trim()))
                {
                    if (IsNumeric(form["txtsdt"].ToString().Trim()))
                    {

                        if ((form["txtsdt"].ToString().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện không đúng');</script>";
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
                if (!string.IsNullOrEmpty(form["txtghichu"].ToString().Trim()))
                {

                }
                else
                {
                    ghichuwweb = "Khách hàng liên hệ từ website medlatec.";

                }


                // SqlConnection _conn;
                // _conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                // _conn.Open();



                // // Info.  
                // string sql = string.Empty;
                // sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,email,Ghichudv,PLDL) values(";
                // sql += "@hoten,@sdt,@ngayhen,@ghichu,0,@email,N'WebMed - Đăng ký nhanh từ trang landing chuyên khoa truyền nhiễm','WEBMEDMOI')";


                // SqlCommand comd = new SqlCommand(sql, _conn);

                // string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");


                // comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                // comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 11).Value = form["txtsdt"].ToString();
                // comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                // comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();
                // comd.Parameters.Add("@email", SqlDbType.NVarChar, 30).Value = form["txtemail"].ToString();


                //comd.ExecuteNonQuery();
                // _conn.Close();

                // Response.Redirect("/thankyou", true);

                CMS_Core.Common.Common.DatlichTin(form["txthoten"].ToString(), form["txtsdt"].ToString(), form["txtghichu"].ToString(), form["txtemail"].ToString(), "WebMed - Đăng ký nhanh từ trang landing chuyên khoa truyền nhiễm", "WEBMEDMOI");
                Response.Redirect("/thankyou?u=dichvutruyennhiem", false);


                // TempData["msg"] = "<script>alert('Cảm ơn Quý khách đã đăng ký với chúng tôi. Chúng tôi sẽ liên lạc với Quý khách để xác nhận lịch hẹn.LH 1900565656 khi cần hỗ trợ. Rất hân hạnh được phục vụ!');</script>";
                // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                // TempData["msg"] = "<script>alert('Cam on Quy khach da dang ky DV Kham tai nha. Chung toi se lien lac voi Quy khach de xac nhan lich hen. LH 1900565656 khi can ho tro. Rat han hanh duoc phuc vu!    ');</script>";
            }
            catch (Exception ex)
            {

            }




            return View();
        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Noitiet(FormCollection form)
        {


            try
            {

                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

                SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 172, 15, 1);
                ViewBag.NewsCate = _NewsCate;
                //}
                //catch (Exception ex)
                //{

                //}
                string ghichuwweb = "";


                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtsdt"].ToString().Trim()))
                {
                    if (IsNumeric(form["txtsdt"].ToString().Trim()))
                    {

                        if ((form["txtsdt"].ToString().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện không đúng');</script>";
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
                if (!string.IsNullOrEmpty(form["txtghichu"].ToString().Trim()))
                {

                }
                else
                {
                    ghichuwweb = "Khách hàng liên hệ từ website medlatec.";

                }


                // SqlConnection _conn;
                // _conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                // _conn.Open();



                // // Info.  
                // string sql = string.Empty;
                // sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,email,Ghichudv,PLDL) values(";
                // sql += "@hoten,@sdt,@ngayhen,@ghichu,0,@email,N'WebMed - Đăng ký nhanh từ trang landing chuyên khoa nội tiết','WEBMEDMOI')";


                // SqlCommand comd = new SqlCommand(sql, _conn);

                // string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");

                // comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                // comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 11).Value = form["txtsdt"].ToString();
                // comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                // comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();
                // comd.Parameters.Add("@email", SqlDbType.NVarChar, 30).Value = form["txtemail"].ToString();


                //comd.ExecuteNonQuery();
                // _conn.Close();

                // Response.Redirect("/thankyou", true);

                CMS_Core.Common.Common.DatlichTin(form["txthoten"].ToString(), form["txtsdt"].ToString(), form["txtghichu"].ToString(), form["txtemail"].ToString(), "WebMed - Đăng ký nhanh từ trang landing chuyên khoa nội tiết", "WEBMEDMOI");
                Response.Redirect("/thankyou?u=dichvunoitiet", false);



                // TempData["msg"] = "<script>alert('Cảm ơn Quý khách đã đăng ký với chúng tôi. Chúng tôi sẽ liên lạc với Quý khách để xác nhận lịch hẹn.LH 1900565656 khi cần hỗ trợ. Rất hân hạnh được phục vụ!');</script>";
                // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                // TempData["msg"] = "<script>alert('Cam on Quy khach da dang ky DV Kham tai nha. Chung toi se lien lac voi Quy khach de xac nhan lich hen. LH 1900565656 khi can ho tro. Rat han hanh duoc phuc vu!    ');</script>";
            }
            catch (Exception ex)
            {

            }




            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Namkhoa(FormCollection form)
        {


            try
            {

                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

                SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 174, 15, 1);
                ViewBag.NewsCate = _NewsCate;
                //}
                //catch (Exception ex)
                //{

                //}
                string ghichuwweb = "";


                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtsdt"].ToString().Trim()))
                {
                    if (IsNumeric(form["txtsdt"].ToString().Trim()))
                    {

                        if ((form["txtsdt"].ToString().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện không đúng');</script>";
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
                if (!string.IsNullOrEmpty(form["txtghichu"].ToString().Trim()))
                {

                }
                else
                {
                    ghichuwweb = "Khách hàng liên hệ từ website medlatec.";

                }


                //  SqlConnection _conn;
                //  _conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                //  _conn.Open();



                //  // Info.  
                //  string sql = string.Empty;
                //  sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,email,Ghichudv,PLDL) values(";
                //  sql += "@hoten,@sdt,@ngayhen,@ghichu,0,@email,N'WebMed - Đăng ký nhanh từ trang landing chuyên khoa nam khoa','WEBMEDMOI')";


                //  SqlCommand comd = new SqlCommand(sql, _conn);

                //  string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");


                //  comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                //  comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 11).Value = form["txtsdt"].ToString();
                //  comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                //  comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();
                //  comd.Parameters.Add("@email", SqlDbType.NVarChar, 30).Value = form["txtemail"].ToString();


                //comd.ExecuteNonQuery();
                //  _conn.Close();

                //  Response.Redirect("/thankyou", true);


                CMS_Core.Common.Common.DatlichTin(form["txthoten"].ToString(), form["txtsdt"].ToString(), form["txtghichu"].ToString(), form["txtemail"].ToString(), "WebMed - Đăng ký nhanh từ trang landing chuyên khoa nam khoa", "WEBMEDMOI");
                Response.Redirect("/thankyou?u=dichvunamkhoa", false);


                // TempData["msg"] = "<script>alert('Cảm ơn Quý khách đã đăng ký với chúng tôi. Chúng tôi sẽ liên lạc với Quý khách để xác nhận lịch hẹn.LH 1900565656 khi cần hỗ trợ. Rất hân hạnh được phục vụ!');</script>";
                // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                // TempData["msg"] = "<script>alert('Cam on Quy khach da dang ky DV Kham tai nha. Chung toi se lien lac voi Quy khach de xac nhan lich hen. LH 1900565656 khi can ho tro. Rat han hanh duoc phuc vu!    ');</script>";
            }
            catch (Exception ex)
            {

            }




            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Taimuihong(FormCollection form)
        {


            try
            {

                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

                SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 156, 15, 1);
                ViewBag.NewsCate = _NewsCate;
                //}
                //catch (Exception ex)
                //{

                //}
                string ghichuwweb = "";


                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtsdt"].ToString().Trim()))
                {
                    if (IsNumeric(form["txtsdt"].ToString().Trim()))
                    {

                        if ((form["txtsdt"].ToString().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện không đúng');</script>";
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
                if (!string.IsNullOrEmpty(form["txtghichu"].ToString().Trim()))
                {

                }
                else
                {
                    ghichuwweb = "Khách hàng liên hệ từ website medlatec.";

                }


                //   SqlConnection _conn;
                //   _conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                //   _conn.Open();



                //   // Info.  
                //   string sql = string.Empty;
                //   sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,email,Ghichudv,PLDL) values(";
                //   sql += "@hoten,@sdt,@ngayhen,@ghichu,0,@email,N'WebMed - Đăng ký nhanh từ trang landing chuyên khoa nam khoa','WEBMEDMOI')";


                //   SqlCommand comd = new SqlCommand(sql, _conn);

                //   string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");


                //   comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                //   comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 11).Value = form["txtsdt"].ToString();
                //   comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                //   comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();
                //   comd.Parameters.Add("@email", SqlDbType.NVarChar, 30).Value = form["txtemail"].ToString();


                //comd.ExecuteNonQuery();
                //   _conn.Close();

                //   Response.Redirect("/thankyou", true);


                CMS_Core.Common.Common.DatlichTin(form["txthoten"].ToString(), form["txtsdt"].ToString(), form["txtghichu"].ToString(), form["txtemail"].ToString(), "WebMed - Đăng ký nhanh từ trang landing chuyên khoa tai mũi họng", "WEBMEDMOI");
                Response.Redirect("/thankyou?u=dichvutaimuihong", false);


                // TempData["msg"] = "<script>alert('Cảm ơn Quý khách đã đăng ký với chúng tôi. Chúng tôi sẽ liên lạc với Quý khách để xác nhận lịch hẹn.LH 1900565656 khi cần hỗ trợ. Rất hân hạnh được phục vụ!');</script>";
                // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                // TempData["msg"] = "<script>alert('Cam on Quy khach da dang ky DV Kham tai nha. Chung toi se lien lac voi Quy khach de xac nhan lich hen. LH 1900565656 khi can ho tro. Rat han hanh duoc phuc vu!    ');</script>";
            }
            catch (Exception ex)
            {

            }




            return View();
        }
        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Timmach(FormCollection form)
        {


            try
            {

                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

                SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 175, 15, 1);
                ViewBag.NewsCate = _NewsCate;
                //}
                //catch (Exception ex)
                //{

                //}
                string ghichuwweb = "";


                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtsdt"].ToString().Trim()))
                {
                    if (IsNumeric(form["txtsdt"].ToString().Trim()))
                    {

                        if ((form["txtsdt"].ToString().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện không đúng');</script>";
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
                if (!string.IsNullOrEmpty(form["txtghichu"].ToString().Trim()))
                {

                }
                else
                {
                    ghichuwweb = "Khách hàng liên hệ từ website medlatec.";

                }


                //SqlConnection _conn;
                //_conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                //_conn.Open();



                //// Info.  
                //string sql = string.Empty;
                //sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,email,Ghichudv,PLDL) values(";
                //sql += "@hoten,@sdt,@ngayhen,@ghichu,0,@email,N'WebMed - Đăng ký nhanh từ trang landing chuyên khoa Tim mạch','WEBMEDMOI')";


                //SqlCommand comd = new SqlCommand(sql, _conn);

                //string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");


                //comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                //comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 11).Value = form["txtsdt"].ToString();
                //comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                //comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();
                //comd.Parameters.Add("@email", SqlDbType.NVarChar, 30).Value = form["txtemail"].ToString();


                //comd.ExecuteNonQuery();
                //_conn.Close();

                //Response.Redirect("/thankyou", true);

                CMS_Core.Common.Common.DatlichTin(form["txthoten"].ToString(), form["txtsdt"].ToString(), form["txtghichu"].ToString(), form["txtemail"].ToString(), "WebMed - Đăng ký nhanh từ trang landing chuyên khoa Tim mạch", "WEBMEDMOI");
                Response.Redirect("/thankyou?u=dichvutimmach", false);



                // TempData["msg"] = "<script>alert('Cảm ơn Quý khách đã đăng ký với chúng tôi. Chúng tôi sẽ liên lạc với Quý khách để xác nhận lịch hẹn.LH 1900565656 khi cần hỗ trợ. Rất hân hạnh được phục vụ!');</script>";
                // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                // TempData["msg"] = "<script>alert('Cam on Quy khach da dang ky DV Kham tai nha. Chung toi se lien lac voi Quy khach de xac nhan lich hen. LH 1900565656 khi can ho tro. Rat han hanh duoc phuc vu!    ');</script>";
            }
            catch (Exception ex)
            {

            }




            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Ngoaikhoa(FormCollection form)
        {


            try
            {

                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

                SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 160, 15, 1);
                ViewBag.NewsCate = _NewsCate;
                //}
                //catch (Exception ex)
                //{

                //}
                string ghichuwweb = "";


                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtsdt"].ToString().Trim()))
                {
                    if (IsNumeric(form["txtsdt"].ToString().Trim()))
                    {

                        if ((form["txtsdt"].ToString().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện không đúng');</script>";
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
                if (!string.IsNullOrEmpty(form["txtghichu"].ToString().Trim()))
                {

                }
                else
                {
                    ghichuwweb = "Khách hàng liên hệ từ website medlatec.";

                }


                // SqlConnection _conn;
                // _conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                // _conn.Open();



                // // Info.  
                // string sql = string.Empty;
                // sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,email,Ghichudv,PLDL) values(";
                // sql += "@hoten,@sdt,@ngayhen,@ghichu,0,@email,N'WebMed - Đăng ký nhanh từ trang landing chuyên khoa Ngoại khoa','WEBMEDMOI')";


                // SqlCommand comd = new SqlCommand(sql, _conn);

                // string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");


                // comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                // comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 11).Value = form["txtsdt"].ToString();
                // comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                // comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();
                // comd.Parameters.Add("@email", SqlDbType.NVarChar, 30).Value = form["txtemail"].ToString();


                //comd.ExecuteNonQuery();
                // _conn.Close();

                // Response.Redirect("/thankyou", true);


                CMS_Core.Common.Common.DatlichTin(form["txthoten"].ToString(), form["txtsdt"].ToString(), form["txtghichu"].ToString(), form["txtemail"].ToString(), "WebMed - Đăng ký nhanh từ trang landing chuyên khoa Ngoại khoa", "WEBMEDMOI");
                Response.Redirect("/thankyou?u=dichvungoaikhoa", false);

                // TempData["msg"] = "<script>alert('Cảm ơn Quý khách đã đăng ký với chúng tôi. Chúng tôi sẽ liên lạc với Quý khách để xác nhận lịch hẹn.LH 1900565656 khi cần hỗ trợ. Rất hân hạnh được phục vụ!');</script>";
                // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                // TempData["msg"] = "<script>alert('Cam on Quy khach da dang ky DV Kham tai nha. Chung toi se lien lac voi Quy khach de xac nhan lich hen. LH 1900565656 khi can ho tro. Rat han hanh duoc phuc vu!    ');</script>";
            }
            catch (Exception ex)
            {

            }




            return View();
        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Mat(FormCollection form)
        {


            try
            {

                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

                SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 158, 15, 1);
                ViewBag.NewsCate = _NewsCate;
                //}
                //catch (Exception ex)
                //{

                //}
                string ghichuwweb = "";


                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtsdt"].ToString().Trim()))
                {
                    if (IsNumeric(form["txtsdt"].ToString().Trim()))
                    {

                        if ((form["txtsdt"].ToString().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện không đúng');</script>";
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
                if (!string.IsNullOrEmpty(form["txtghichu"].ToString().Trim()))
                {

                }
                else
                {
                    ghichuwweb = "Khách hàng liên hệ từ website medlatec.";

                }


                // SqlConnection _conn;
                // _conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                // _conn.Open();



                // // Info.  
                // string sql = string.Empty;
                // sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,email,Ghichudv,PLDL) values(";
                // sql += "@hoten,@sdt,@ngayhen,@ghichu,0,@email,N'WebMed - Đăng ký nhanh từ trang landing chuyên khoa mắt','WEBMEDMOI')";


                // SqlCommand comd = new SqlCommand(sql, _conn);

                // string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");


                // comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                // comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 11).Value = form["txtsdt"].ToString();
                // comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                // comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();
                // comd.Parameters.Add("@email", SqlDbType.NVarChar, 30).Value = form["txtemail"].ToString();


                //comd.ExecuteNonQuery();
                // _conn.Close();

                // Response.Redirect("/thankyou", true);


                CMS_Core.Common.Common.DatlichTin(form["txthoten"].ToString(), form["txtsdt"].ToString(), form["txtghichu"].ToString(), form["txtemail"].ToString(), "WebMed - Đăng ký nhanh từ trang landing chuyên khoa mắt", "WEBMEDMOI");
                Response.Redirect("/thankyou?u=dichvumat", false);

                // TempData["msg"] = "<script>alert('Cảm ơn Quý khách đã đăng ký với chúng tôi. Chúng tôi sẽ liên lạc với Quý khách để xác nhận lịch hẹn.LH 1900565656 khi cần hỗ trợ. Rất hân hạnh được phục vụ!');</script>";
                // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                // TempData["msg"] = "<script>alert('Cam on Quy khach da dang ky DV Kham tai nha. Chung toi se lien lac voi Quy khach de xac nhan lich hen. LH 1900565656 khi can ho tro. Rat han hanh duoc phuc vu!    ');</script>";
            }
            catch (Exception ex)
            {

            }




            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Ungbuou(FormCollection form)
        {


            try
            {

                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

                SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 151, 15, 1);
                ViewBag.NewsCate = _NewsCate;
                //}
                //catch (Exception ex)
                //{

                //}
                string ghichuwweb = "";


                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtsdt"].ToString().Trim()))
                {
                    if (IsNumeric(form["txtsdt"].ToString().Trim()))
                    {

                        if ((form["txtsdt"].ToString().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện không đúng');</script>";
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
                if (!string.IsNullOrEmpty(form["txtghichu"].ToString().Trim()))
                {

                }
                else
                {
                    ghichuwweb = "Khách hàng liên hệ từ website medlatec.";

                }


                //  SqlConnection _conn;
                //  _conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                //  _conn.Open();



                //  // Info.  
                //  string sql = string.Empty;
                //  sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,email,Ghichudv,PLDL) values(";
                //  sql += "@hoten,@sdt,@ngayhen,@ghichu,0,@email,N'WebMed - Đăng ký nhanh từ trang landing chuyên khoa ung bướu','WEBMEDMOI')";


                //  SqlCommand comd = new SqlCommand(sql, _conn);

                //  string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");


                //  comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                //  comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 11).Value = form["txtsdt"].ToString();
                //  comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                //  comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();
                //  comd.Parameters.Add("@email", SqlDbType.NVarChar, 30).Value = form["txtemail"].ToString();


                //comd.ExecuteNonQuery();
                //  _conn.Close();

                //  Response.Redirect("/thankyou", true);


                CMS_Core.Common.Common.DatlichTin(form["txthoten"].ToString(), form["txtsdt"].ToString(), form["txtghichu"].ToString(), form["txtemail"].ToString(), "WebMed - Đăng ký nhanh từ trang landing chuyên khoa ung bướu", "WEBMEDMOI");
                Response.Redirect("/thankyou?u=dichvuungbuou", false);


                // TempData["msg"] = "<script>alert('Cảm ơn Quý khách đã đăng ký với chúng tôi. Chúng tôi sẽ liên lạc với Quý khách để xác nhận lịch hẹn.LH 1900565656 khi cần hỗ trợ. Rất hân hạnh được phục vụ!');</script>";
                // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                // TempData["msg"] = "<script>alert('Cam on Quy khach da dang ky DV Kham tai nha. Chung toi se lien lac voi Quy khach de xac nhan lich hen. LH 1900565656 khi can ho tro. Rat han hanh duoc phuc vu!    ');</script>";
            }
            catch (Exception ex)
            {

            }




            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Thankinh(FormCollection form)
        {


            try
            {

                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

                SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 163, 15, 1);
                ViewBag.NewsCate = _NewsCate;
                //}
                //catch (Exception ex)
                //{

                //}
                string ghichuwweb = "";


                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtsdt"].ToString().Trim()))
                {
                    if (IsNumeric(form["txtsdt"].ToString().Trim()))
                    {

                        if ((form["txtsdt"].ToString().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện không đúng');</script>";
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
                if (!string.IsNullOrEmpty(form["txtghichu"].ToString().Trim()))
                {

                }
                else
                {
                    ghichuwweb = "Khách hàng liên hệ từ website medlatec.";

                }


                SqlConnection _conn;
                _conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                _conn.Open();



                //// Info.  
                //string sql = string.Empty;
                //sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,email,Ghichudv,PLDL) values(";
                //sql += "@hoten,@sdt,@ngayhen,@ghichu,0,@email,N'WebMed - Đăng ký nhanh từ trang landing chuyên khoa thần kinh','WEBMEDMOI')";


                //SqlCommand comd = new SqlCommand(sql, _conn);

                //string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");


                //comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                //comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 11).Value = form["txtsdt"].ToString();
                //comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                //comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();
                //comd.Parameters.Add("@email", SqlDbType.NVarChar, 30).Value = form["txtemail"].ToString();


                //comd.ExecuteNonQuery();
                //_conn.Close();

                //Response.Redirect("/thankyou", true);

                CMS_Core.Common.Common.DatlichTin(form["txthoten"].ToString(), form["txtsdt"].ToString(), form["txtghichu"].ToString(), form["txtemail"].ToString(), "WebMed - Đăng ký nhanh từ trang landing chuyên khoa thần kinh", "WEBMEDMOI");
                Response.Redirect("/thankyou?u=dichvuthankinh", false);


                // TempData["msg"] = "<script>alert('Cảm ơn Quý khách đã đăng ký với chúng tôi. Chúng tôi sẽ liên lạc với Quý khách để xác nhận lịch hẹn.LH 1900565656 khi cần hỗ trợ. Rất hân hạnh được phục vụ!');</script>";
                // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                // TempData["msg"] = "<script>alert('Cam on Quy khach da dang ky DV Kham tai nha. Chung toi se lien lac voi Quy khach de xac nhan lich hen. LH 1900565656 khi can ho tro. Rat han hanh duoc phuc vu!    ');</script>";
            }
            catch (Exception ex)
            {

            }




            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ranghammat(FormCollection form)
        {


            try
            {

                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

                SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 157, 15, 1);
                ViewBag.NewsCate = _NewsCate;
                //}
                //catch (Exception ex)
                //{

                //}
                string ghichuwweb = "";


                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtsdt"].ToString().Trim()))
                {
                    if (IsNumeric(form["txtsdt"].ToString().Trim()))
                    {

                        if ((form["txtsdt"].ToString().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện không đúng');</script>";
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
                if (!string.IsNullOrEmpty(form["txtghichu"].ToString().Trim()))
                {

                }
                else
                {
                    ghichuwweb = "Khách hàng liên hệ từ website medlatec.";

                }


                SqlConnection _conn;
                _conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                _conn.Open();



                //// Info.  
                //string sql = string.Empty;
                //sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,email,Ghichudv,PLDL) values(";
                //sql += "@hoten,@sdt,@ngayhen,@ghichu,0,@email,N'WebMed - Đăng ký nhanh từ trang landing chuyên khoa răng  hàm mặt','WEBMEDMOI')";


                //SqlCommand comd = new SqlCommand(sql, _conn);

                //string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");

                //comd.Parameters.Add("@hoten", SqlDbType.NVarChar,30).Value = form["txthoten"].ToString();
                //comd.Parameters.Add("@sdt", SqlDbType.NVarChar,11).Value = form["txtsdt"].ToString();
                //comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                //comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();
                //comd.Parameters.Add("@email", SqlDbType.NVarChar,30).Value = form["txtemail"].ToString();


                //comd.ExecuteNonQuery();
                //_conn.Close();

                //Response.Redirect("/thankyou", true);


                CMS_Core.Common.Common.DatlichTin(form["txthoten"].ToString(), form["txtsdt"].ToString(), form["txtghichu"].ToString(), form["txtemail"].ToString(), "WebMed - Đăng ký nhanh từ trang landing chuyên khoa răng hàm mặt", "WEBMEDMOI");
                Response.Redirect("/thankyou?u=dichvuranghammat", false);


                // TempData["msg"] = "<script>alert('Cảm ơn Quý khách đã đăng ký với chúng tôi. Chúng tôi sẽ liên lạc với Quý khách để xác nhận lịch hẹn.LH 1900565656 khi cần hỗ trợ. Rất hân hạnh được phục vụ!');</script>";
                // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                // TempData["msg"] = "<script>alert('Cam on Quy khach da dang ky DV Kham tai nha. Chung toi se lien lac voi Quy khach de xac nhan lich hen. LH 1900565656 khi can ho tro. Rat han hanh duoc phuc vu!    ');</script>";
            }
            catch (Exception ex)
            {

            }




            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Chandoanhinhanh(FormCollection form)
        {


            try
            {

                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

                SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 154, 15, 1);
                ViewBag.NewsCate = _NewsCate;
                //}
                //catch (Exception ex)
                //{

                //}
                string ghichuwweb = "";


                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtsdt"].ToString().Trim()))
                {
                    if (IsNumeric(form["txtsdt"].ToString().Trim()))
                    {

                        if ((form["txtsdt"].ToString().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện không đúng');</script>";
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
                if (!string.IsNullOrEmpty(form["txtghichu"].ToString().Trim()))
                {

                }
                else
                {
                    ghichuwweb = "Khách hàng liên hệ từ website medlatec.";

                }


                SqlConnection _conn;
                _conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                _conn.Open();



                // Info.  
                //string sql = string.Empty;
                //sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,email,Ghichudv,PLDL) values(";
                //sql += "@hoten,@sdt,@ngayhen,@ghichu,0,@email,N'WebMed - Đăng ký nhanh từ trang landing chuyên khoa chẩn đoán hình ảnh','WEBMEDMOI')";


                //SqlCommand comd = new SqlCommand(sql, _conn);

                //string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");

                //comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                //comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 11).Value = form["txtsdt"].ToString();
                //comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                //comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();
                //comd.Parameters.Add("@email", SqlDbType.NVarChar, 30).Value = form["txtemail"].ToString();


                //comd.ExecuteNonQuery();
                //_conn.Close();

                //Response.Redirect("/thankyou", true);

                CMS_Core.Common.Common.DatlichTin(form["txthoten"].ToString(), form["txtsdt"].ToString(), form["txtghichu"].ToString(), form["txtemail"].ToString(), "WebMed - Đăng ký nhanh từ trang landing chuyên khoa chẩn đoán hình ảnh", "WEBMEDMOI");
                Response.Redirect("/thankyou?u=dichvuchandoanhinhanh", false);


                // TempData["msg"] = "<script>alert('Cảm ơn Quý khách đã đăng ký với chúng tôi. Chúng tôi sẽ liên lạc với Quý khách để xác nhận lịch hẹn.LH 1900565656 khi cần hỗ trợ. Rất hân hạnh được phục vụ!');</script>";
                // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                // TempData["msg"] = "<script>alert('Cam on Quy khach da dang ky DV Kham tai nha. Chung toi se lien lac voi Quy khach de xac nhan lich hen. LH 1900565656 khi can ho tro. Rat han hanh duoc phuc vu!    ');</script>";
            }
            catch (Exception ex)
            {

            }




            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChuyenkhoaNoi(FormCollection form)
        {


            try
            {

                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

                SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 188, 15, 1);
                ViewBag.NewsCate = _NewsCate;
                //}
                //catch (Exception ex)
                //{

                //}
                string ghichuwweb = "";


                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtsdt"].ToString().Trim()))
                {
                    if (IsNumeric(form["txtsdt"].ToString().Trim()))
                    {

                        if ((form["txtsdt"].ToString().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện không đúng');</script>";
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
                if (!string.IsNullOrEmpty(form["txtghichu"].ToString().Trim()))
                {

                }
                else
                {
                    ghichuwweb = "Khách hàng liên hệ từ website medlatec.";

                }


                SqlConnection _conn;
                _conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                _conn.Open();



                // Info.  
                //string sql = string.Empty;
                //sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,email,Ghichudv,PLDL) values(";
                //sql += "@hoten,@sdt,@ngayhen,@ghichu,0,@email,N'WebMed - Đăng ký nhanh từ trang landing chuyên khoa Nội','WEBMEDMOI')";


                //SqlCommand comd = new SqlCommand(sql, _conn);

                //string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");

                //comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                //comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 11).Value = form["txtsdt"].ToString();
                //comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                //comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();
                //comd.Parameters.Add("@email", SqlDbType.NVarChar, 30).Value = form["txtemail"].ToString();


                //comd.ExecuteNonQuery();
                //_conn.Close();

                //Response.Redirect("/thankyou", true);

                CMS_Core.Common.Common.DatlichTin(form["txthoten"].ToString(), form["txtsdt"].ToString(), form["txtghichu"].ToString(), form["txtemail"].ToString(), "WebMed - Đăng ký nhanh từ trang landing chuyên khoa Nội", "WEBMEDMOI");
                Response.Redirect("/thankyou?u=dichvucknoi", false);


                // TempData["msg"] = "<script>alert('Cảm ơn Quý khách đã đăng ký với chúng tôi. Chúng tôi sẽ liên lạc với Quý khách để xác nhận lịch hẹn.LH 1900565656 khi cần hỗ trợ. Rất hân hạnh được phục vụ!');</script>";
                // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                // TempData["msg"] = "<script>alert('Cam on Quy khach da dang ky DV Kham tai nha. Chung toi se lien lac voi Quy khach de xac nhan lich hen. LH 1900565656 khi can ho tro. Rat han hanh duoc phuc vu!    ');</script>";
            }
            catch (Exception ex)
            {

            }




            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult XetNghiem(FormCollection form)
        {


            try
            {

                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

                SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 159, 15, 1);
                ViewBag.NewsCate = _NewsCate;
                //}
                //catch (Exception ex)
                //{

                //}
                string ghichuwweb = "";


                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtsdt"].ToString().Trim()))
                {
                    if (IsNumeric(form["txtsdt"].ToString().Trim()))
                    {

                        if ((form["txtsdt"].ToString().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện không đúng');</script>";
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
                if (!string.IsNullOrEmpty(form["txtghichu"].ToString().Trim()))
                {

                }
                else
                {
                    ghichuwweb = "Khách hàng liên hệ từ website medlatec.";

                }


                SqlConnection _conn;
                _conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                _conn.Open();



                // Info.  
                //string sql = string.Empty;
                //sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,email,Ghichudv,PLDL) values(";
                //sql += "@hoten,@sdt,@ngayhen,@ghichu,0,@email,N'WebMed - Đăng ký nhanh từ trang landing trung tâm xét nghiệm','WEBMEDMOI')";


                //SqlCommand comd = new SqlCommand(sql, _conn);

                //string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");

                //comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                //comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 11).Value = form["txtsdt"].ToString();
                //comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                //comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();
                //comd.Parameters.Add("@email", SqlDbType.NVarChar, 30).Value = form["txtemail"].ToString();


                //comd.ExecuteNonQuery();
                //_conn.Close();

                //Response.Redirect("/thankyou", true);

                CMS_Core.Common.Common.DatlichTin(form["txthoten"].ToString(), form["txtsdt"].ToString(), form["txtghichu"].ToString(), form["txtemail"].ToString(), "WebMed - Đăng ký nhanh từ trang landing trung tâm xét nghiệm", "WEBMEDMOI");
                Response.Redirect("/thankyou?u=dichvuxetnghiem", false);


                // TempData["msg"] = "<script>alert('Cảm ơn Quý khách đã đăng ký với chúng tôi. Chúng tôi sẽ liên lạc với Quý khách để xác nhận lịch hẹn.LH 1900565656 khi cần hỗ trợ. Rất hân hạnh được phục vụ!');</script>";
                // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                // TempData["msg"] = "<script>alert('Cam on Quy khach da dang ky DV Kham tai nha. Chung toi se lien lac voi Quy khach de xac nhan lich hen. LH 1900565656 khi can ho tro. Rat han hanh duoc phuc vu!    ');</script>";
            }
            catch (Exception ex)
            {

            }




            return View();
        }
        

            [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Coxuongkhop(FormCollection form)
        {


            try
            {

                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

                SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 161, 15, 1);
                ViewBag.NewsCate = _NewsCate;
                //}
                //catch (Exception ex)
                //{

                //}
                string ghichuwweb = "";


                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtsdt"].ToString().Trim()))
                {
                    if (IsNumeric(form["txtsdt"].ToString().Trim()))
                    {

                        if ((form["txtsdt"].ToString().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện không đúng');</script>";
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
                if (!string.IsNullOrEmpty(form["txtghichu"].ToString().Trim()))
                {

                }
                else
                {
                    ghichuwweb = "Khách hàng liên hệ từ website medlatec.";

                }


                SqlConnection _conn;
                _conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                _conn.Open();



                // Info.  
                //string sql = string.Empty;
                //sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,email,Ghichudv,PLDL) values(";
                //sql += "@hoten,@sdt,@ngayhen,@ghichu,0,@email,N'WebMed - Đăng ký nhanh từ trang landing Cơ xương khớp','WEBMEDMOI')";


                //SqlCommand comd = new SqlCommand(sql, _conn);

                //string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");

                //comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                //comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 11).Value = form["txtsdt"].ToString();
                //comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                //comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();
                //comd.Parameters.Add("@email", SqlDbType.NVarChar, 30).Value = form["txtemail"].ToString();


                //comd.ExecuteNonQuery();
                //_conn.Close();

                //Response.Redirect("/thankyou", true);

                CMS_Core.Common.Common.DatlichTin(form["txthoten"].ToString(), form["txtsdt"].ToString(), form["txtghichu"].ToString(), form["txtemail"].ToString(), "WebMed - Đăng ký nhanh từ trang landing Cơ xương khớp", "WEBMEDMOI");
                Response.Redirect("/thankyou?u=dichvucoxuongkhop", false);


                // TempData["msg"] = "<script>alert('Cảm ơn Quý khách đã đăng ký với chúng tôi. Chúng tôi sẽ liên lạc với Quý khách để xác nhận lịch hẹn.LH 1900565656 khi cần hỗ trợ. Rất hân hạnh được phục vụ!');</script>";
                // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                // TempData["msg"] = "<script>alert('Cam on Quy khach da dang ky DV Kham tai nha. Chung toi se lien lac voi Quy khach de xac nhan lich hen. LH 1900565656 khi can ho tro. Rat han hanh duoc phuc vu!    ');</script>";
            }
            catch (Exception ex)
            {

            }




            return View();
        }


        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Dalieu(FormCollection form)
        {


            try
            {

                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

                SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 189, 15, 1);
                ViewBag.NewsCate = _NewsCate;
                //}
                //catch (Exception ex)
                //{

                //}
                string ghichuwweb = "";


                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtsdt"].ToString().Trim()))
                {
                    if (IsNumeric(form["txtsdt"].ToString().Trim()))
                    {

                        if ((form["txtsdt"].ToString().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện không đúng');</script>";
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
                if (!string.IsNullOrEmpty(form["txtghichu"].ToString().Trim()))
                {

                }
                else
                {
                    ghichuwweb = "Khách hàng liên hệ từ website medlatec.";

                }


                SqlConnection _conn;
                _conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                _conn.Open();



                // Info.  
                //  string sql = string.Empty;
                //  sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,email,Ghichudv,PLDL) values(";
                //  sql += "@hoten,@sdt,@ngayhen,@ghichu,0,@email,N'WebMed - Đăng ký nhanh từ trang landing Da Liễu','WEBMEDMOI')";


                //  SqlCommand comd = new SqlCommand(sql, _conn);

                //  string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");

                //  comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                //  comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 11).Value = form["txtsdt"].ToString();
                //  comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                //  comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();
                //  comd.Parameters.Add("@email", SqlDbType.NVarChar, 30).Value = form["txtemail"].ToString();


                //comd.ExecuteNonQuery();

                //  _conn.Close();

                //  Response.Redirect("/thankyou", true);

                CMS_Core.Common.Common.DatlichTin(form["txthoten"].ToString(), form["txtsdt"].ToString(), form["txtghichu"].ToString(), form["txtemail"].ToString(), "WebMed - Đăng ký nhanh từ trang landing Da Liễu", "WEBMEDMOI");
                Response.Redirect("/thankyou?u=dichvudalieu", false);


                // TempData["msg"] = "<script>alert('Cảm ơn Quý khách đã đăng ký với chúng tôi. Chúng tôi sẽ liên lạc với Quý khách để xác nhận lịch hẹn.LH 1900565656 khi cần hỗ trợ. Rất hân hạnh được phục vụ!');</script>";
                // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                // TempData["msg"] = "<script>alert('Cam on Quy khach da dang ky DV Kham tai nha. Chung toi se lien lac voi Quy khach de xac nhan lich hen. LH 1900565656 khi can ho tro. Rat han hanh duoc phuc vu!    ');</script>";
            }
            catch (Exception ex)
            {

            }




            return View();
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Tieuhoa(FormCollection form)
        {


            try
            {

                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

                SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 173, 15, 1);
                ViewBag.NewsCate = _NewsCate;
                //}
                //catch (Exception ex)
                //{

                //}
                string ghichuwweb = "";


                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtsdt"].ToString().Trim()))
                {
                    if (IsNumeric(form["txtsdt"].ToString().Trim()))
                    {

                        if ((form["txtsdt"].ToString().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện không đúng');</script>";
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
                if (!string.IsNullOrEmpty(form["txtghichu"].ToString().Trim()))
                {

                }
                else
                {
                    ghichuwweb = "Khách hàng liên hệ từ website medlatec.";

                }


                SqlConnection _conn;
                _conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                _conn.Open();



                // Info.  
                //  string sql = string.Empty;
                //  sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,email,Ghichudv,PLDL) values(";
                //  sql += "@hoten,@sdt,@ngayhen,@ghichu,0,@email,N'WebMed - Đăng ký nhanh từ trang landing Tiêu hóa','WEBMEDMOI')";


                //  SqlCommand comd = new SqlCommand(sql, _conn);

                //  string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");

                //  comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                //  comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 11).Value = form["txtsdt"].ToString();
                //  comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                //  comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();
                //  comd.Parameters.Add("@email", SqlDbType.NVarChar, 30).Value = form["txtemail"].ToString();


                //comd.ExecuteNonQuery();
                //  _conn.Close();

                //  Response.Redirect("/thankyou", true);

                CMS_Core.Common.Common.DatlichTin(form["txthoten"].ToString(), form["txtsdt"].ToString(), form["txtghichu"].ToString(), form["txtemail"].ToString(), "WebMed - Đăng ký nhanh từ trang landing Tiêu hóa", "WEBMEDMOI");
                Response.Redirect("/thankyou?u=dichvutieuhoa", false);


                // TempData["msg"] = "<script>alert('Cảm ơn Quý khách đã đăng ký với chúng tôi. Chúng tôi sẽ liên lạc với Quý khách để xác nhận lịch hẹn.LH 1900565656 khi cần hỗ trợ. Rất hân hạnh được phục vụ!');</script>";
                // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                // TempData["msg"] = "<script>alert('Cam on Quy khach da dang ky DV Kham tai nha. Chung toi se lien lac voi Quy khach de xac nhan lich hen. LH 1900565656 khi can ho tro. Rat han hanh duoc phuc vu!    ');</script>";
            }
            catch (Exception ex)
            {

            }




            return View();
        }



        


      

    }
}