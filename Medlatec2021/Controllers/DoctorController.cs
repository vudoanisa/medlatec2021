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
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CateDoctor(string page)
        {
            int pagesize = 0;

            if (page != null)
            {
                pagesize = int.Parse(page);
            }
            else
            {
                pagesize = 1;
            }

            SQLServerConnection<cms_Group_Doctor> sQLServer = new SQLServerConnection<cms_Group_Doctor>();
            List<cms_Group_Doctor> _GroupDoctor = sQLServer.SelectQueryCommand("SP_cms_Group_Doctor_SelectActive", Common.getConnectionString());
            if (_GroupDoctor.Count > 0)
            {
                ViewBag.GroupDoctor = _GroupDoctor;
            }
            else
            {
                Response.RedirectPermanent("https://medlatec.vn", false);
            }
            SQLServerConnection<Cms_Doctor> sQLServer3 = new SQLServerConnection<Cms_Doctor>();
            List<Cms_Doctor> _Cms_Doctor = sQLServer3.SelectQueryCommand("SP_cms_Doctor_Getall_Cate", Common.getConnectionString(),pagesize);
            if (_Cms_Doctor.Count > 0)
            {
                ViewBag.Doctor = _Cms_Doctor;
            }
            else
            {
                Response.RedirectPermanent("https://medlatec.vn", false);
            }
            SQLServerConnection<Cms_Doctor> sQLServer4 = new SQLServerConnection<Cms_Doctor>();
            List<Cms_Doctor> _Cms_DoctorTotal = sQLServer4.SelectQueryCommand("Total_Bs", Common.getConnectionString());
            ViewBag.Total = _Cms_DoctorTotal;

            ViewBag.page = pagesize;
            SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.TinNoiBat = _TinNoiBat;
            return View();
        }
        public ActionResult DoctorDetails(string did)
        {
            string id = did.Replace("d", "");
            SQLServerConnection<Cms_Doctor> sQLServer = new SQLServerConnection<Cms_Doctor>();
            List<Cms_Doctor> _Cms_Doctor = sQLServer.SelectQueryCommand("SP_cms_Doctor_SelectByID_Cate", Common.getConnectionString(),int.Parse(id));
            if (_Cms_Doctor.Count > 0)
            {
                ViewBag.Doctor = _Cms_Doctor;
                SQLServerConnection<Cms_Doctor> sQLServer3 = new SQLServerConnection<Cms_Doctor>();
                List<Cms_Doctor> _DoctorCate = sQLServer3.SelectQueryCommand("SP_cms_Doctor_CateID", Common.getConnectionString(), _Cms_Doctor[0].DoctorCate);
                ViewBag.DoctorCate = _DoctorCate;

                SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("SP_cms_News_bsyDuyet", Common.getConnectionString(), id);
                ViewBag.NewsCate = _NewsCate;


            }
            else
            {
                Response.RedirectPermanent("https://medlatec.vn", false);
            }
            SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.TinNoiBat = _TinNoiBat;

         

          

            return View();
        }


        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult DoctorDetails(FormCollection form)
        {


            try
            {

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



                //SqlConnection _conn;
                //_conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                //_conn.Open();



                //// Info.  
                //string sql = string.Empty;
                //sql = "insert into Datlich(tenkh,sodt,ngayhen,email,ghichu,tinhtrang,Ghichudv,PLDL) values(";
                //sql += "@hoten,@sdt,@ngayhen,@email,@ghichu,0,N'WebMed - Trang chi tiết bác sỹ','DoctorOL')";


                //SqlCommand comd = new SqlCommand(sql, _conn);
                //string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");




                //comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                //comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 11).Value = form["txtsdt"].ToString();
                //comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                //comd.Parameters.Add("@email", SqlDbType.NVarChar).Value = form["txtemail"].ToString();
                //comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = form["txtGhichu"].ToString();

                //comd.ExecuteNonQuery();
                //_conn.Close();

                CMS_Core.Common.Common.DatlichTin(form["txthoten"].ToString(), form["txtsdt"].ToString(), form["txtGhichu"].ToString(), form["txtemail"].ToString(), "WebMed - Trang chi tiết bác sỹ", "DoctorOL");



            
                Response.Redirect("/thankyou?u=chitietbacsy", false);
            }
            catch (Exception ex)
            {

            }




            return View();
        }

        public static bool IsNumeric(string input)
        {
            return Regex.IsMatch(input, @"^\d+$");
        }
    }
}