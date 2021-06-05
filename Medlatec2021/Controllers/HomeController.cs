using CMS_Core.Common;
using MEDLATEC.BusinessLayer;
using MEDLATEC2019.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MEDLATEC2019.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                SQLServerConnection<Cms_News> sQLServer = new SQLServerConnection<Cms_News>();
                SQLServerConnection<tbl_slider> sQLServer3 = new SQLServerConnection<tbl_slider>();
                SQLServerConnection<Cms_Video> sQLServer1 = new SQLServerConnection<Cms_Video>();
                //SQLServerConnection<Cms_Video> sQLServer1 = new SQLServerConnection<Cms_Video>();
                List<Cms_News> _News = sQLServer.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());

                List<tbl_slider> slider = sQLServer3.SelectQueryCommand("SP_tbl_Slider_web", Common.getConnectionString());

                List<Cms_News> _NewsDichvu = sQLServer.SelectQueryCommand("SP_cms_News_SelectTopDichvu", Common.getConnectionString());
                List<Cms_Video> _Video = sQLServer1.SelectQueryCommand("Web$cms_Video_SelectAll", Common.getConnectionString());
                //  SQLServerConnectionToDatabase sQLServerConnectionToDatabase = new SQLServerConnectionToDatabase();
                //  DataTable datatable = sQLServerConnectionToDatabase.ExecuteToDataTable("select top 5 newsId,cateId,SourceId,userId,newsName,newsKeyword,newsDescription,newsImages,newsTitleImages,newsAuthor,dateCreate,newsFile,active,countR,Tukhoa from  cms_News", Common.getConnectionString());
                ViewBag.News = _News;
                ViewBag.NewsDichVu = _NewsDichvu;
                ViewBag.Video = _Video;
                ViewBag.slider = slider;
                //  ViewBag.datatable = datatable;

                //List<Cms_Video> _News = sQLServer.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                //ViewBag.News = _News;
                //dung do server icnm treo
                //SQLServerConnection<Question> sQLServer1 = new SQLServerConnection<Question>();
                //List<Question> _Topcauhoi = sQLServer1.SelectQueryCommand("Question_GetTieuDe", Common.getConnectionStringIcnm());
                //ViewBag.Topcauhoi = _Topcauhoi;

                ViewBag.Title = "Đây là trang chủ bệnh viện đa khoa med";
            }
            catch { }


            return View();
        }
        public ActionResult Index1()
                    {
            return View();
        }
            //public ActionResult Timkiem()
            //{
            //    try
            //    {
            //        Response.Redirect("https://medlatec.vn");
            //    }
            //    catch { }


            //    return View();
            //}
            public ActionResult TestModal()
        {

            return View();
        }
        public ActionResult Hoinghi()
        {

            return View();
        }
        public ActionResult KSHoinghi()
        {

            return View();
        }
        public ActionResult CamonHN()
        {

            return View();
        }
        public ActionResult Daxem(string id)
        {
            SqlConnection _conn;
            _conn = new SqlConnection(ConfigurationManager.AppSettings["Main.ConnectionString"]);
            _conn.Open();


           
            string sql = string.Empty;
            sql = "update tbl_hoinghi2019 set Type = 3 where ID ="+ id;
           

            SqlCommand comd = new SqlCommand(sql, _conn);

            comd.ExecuteNonQuery();

            Response.Redirect("/dscauhoi", false);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KSHoinghi(FormCollection form)
        {


            try
            {
               


                SqlConnection _conn1;
                _conn1 = new SqlConnection(ConfigurationManager.AppSettings["Main.ConnectionString"]);
                _conn1.Open();

      
                SqlParameter parameter1 = new SqlParameter();
                SqlParameter parameter2 = new SqlParameter();
                SqlParameter parameter3 = new SqlParameter();
                SqlParameter parameter4 = new SqlParameter();
                SqlParameter parameter5 = new SqlParameter();
                SqlParameter parameter6 = new SqlParameter();
                SqlParameter parameter7 = new SqlParameter();
                SqlParameter parameter8 = new SqlParameter();
                SqlParameter parameter9 = new SqlParameter();
                SqlParameter parameter10 = new SqlParameter();
                SqlParameter parameter11 = new SqlParameter();
                SqlParameter parameter12 = new SqlParameter();
                SqlParameter parameter13 = new SqlParameter();
                SqlParameter parameter14 = new SqlParameter();
                SqlParameter parameter15 = new SqlParameter();
                SqlParameter parameter16 = new SqlParameter();
                SqlParameter parameter17 = new SqlParameter();
                SqlParameter parameter18 = new SqlParameter();
                SqlParameter parameter19 = new SqlParameter();
                SqlParameter parameter20 = new SqlParameter();
                SqlParameter parameter21 = new SqlParameter();

                parameter1 = new SqlParameter("@Hoten", SqlDbType.NVarChar);
                parameter1.Value = form["txthoten"].ToString();

                parameter2 = new SqlParameter("@Phone", SqlDbType.NVarChar);
                parameter2.Value = form["txtsdt"].ToString();

               
                if (form["cau1"].ToString().Trim() == "cau11")
                {
                    parameter3 = new SqlParameter("@Cau11", SqlDbType.NChar);
                    parameter3.Value = "1";
                    parameter4 = new SqlParameter("@Cau12", SqlDbType.NChar);
                    parameter4.Value = "0";
                    parameter5 = new SqlParameter("@Cau13", SqlDbType.NChar);
                    parameter5.Value = "0";
                    parameter6 = new SqlParameter("@Cau14", SqlDbType.NChar);
                    parameter6.Value = "0";
                    parameter7 = new SqlParameter("@Cau15", SqlDbType.NChar);
                    parameter7.Value = "0";

                }
                if (form["cau1"].ToString().Trim() == "cau12")
                {
                    parameter3 = new SqlParameter("@Cau11", SqlDbType.NChar);
                    parameter3.Value = "0";
                    parameter4 = new SqlParameter("@Cau12", SqlDbType.NChar);
                    parameter4.Value = "1";
                    parameter5 = new SqlParameter("@Cau13", SqlDbType.NChar);
                    parameter5.Value = "0";
                    parameter6 = new SqlParameter("@Cau14", SqlDbType.NChar);
                    parameter6.Value = "0";
                    parameter7 = new SqlParameter("@Cau15", SqlDbType.NChar);
                    parameter7.Value = "0";

                }
                if (form["cau1"].ToString().Trim() == "cau13")
                {
                    parameter3 = new SqlParameter("@Cau11", SqlDbType.NChar);
                    parameter3.Value = "0";
                    parameter4 = new SqlParameter("@Cau12", SqlDbType.NChar);
                    parameter4.Value = "0";
                    parameter5 = new SqlParameter("@Cau13", SqlDbType.NChar);
                    parameter5.Value = "1";
                    parameter6 = new SqlParameter("@Cau14", SqlDbType.NChar);
                    parameter6.Value = "0";
                    parameter7 = new SqlParameter("@Cau15", SqlDbType.NChar);
                    parameter7.Value = "0";

                }
                if (form["cau1"].ToString().Trim() == "cau14")
                {
                    parameter3 = new SqlParameter("@Cau11", SqlDbType.NChar);
                    parameter3.Value = "0";
                    parameter4 = new SqlParameter("@Cau12", SqlDbType.NChar);
                    parameter4.Value = "0";
                    parameter5 = new SqlParameter("@Cau13", SqlDbType.NChar);
                    parameter5.Value = "0";
                    parameter6 = new SqlParameter("@Cau14", SqlDbType.NChar);
                    parameter6.Value = "1";
                    parameter7 = new SqlParameter("@Cau15", SqlDbType.NChar);
                    parameter7.Value = "0";

                }
                if (form["cau1"].ToString().Trim() == "cau15")
                {
                    parameter3 = new SqlParameter("@Cau11", SqlDbType.NChar);
                    parameter3.Value = "0";
                    parameter4 = new SqlParameter("@Cau12", SqlDbType.NChar);
                    parameter4.Value = "0";
                    parameter5 = new SqlParameter("@Cau13", SqlDbType.NChar);
                    parameter5.Value = "0";
                    parameter6 = new SqlParameter("@Cau14", SqlDbType.NChar);
                    parameter6.Value = "0";
                    parameter7 = new SqlParameter("@Cau15", SqlDbType.NChar);
                    parameter7.Value = "1";

                }

                parameter8 = new SqlParameter("@Text1", SqlDbType.NVarChar);
                parameter8.Value = form["txtcau1"].ToString();



                if (form["cau2"].ToString().Trim() == "cau21")
                {
                    parameter9 = new SqlParameter("@Cau21", SqlDbType.NChar);
                    parameter9.Value = "1";
                    parameter10 = new SqlParameter("@Cau22", SqlDbType.NChar);
                    parameter10.Value = "0";
                    parameter11 = new SqlParameter("@Cau23", SqlDbType.NChar);
                    parameter11.Value = "0";
                    parameter12 = new SqlParameter("@Cau24", SqlDbType.NChar);
                    parameter12.Value = "0";
                    parameter13 = new SqlParameter("@Cau25", SqlDbType.NChar);
                    parameter13.Value = "0";

                }
                if (form["cau2"].ToString().Trim() == "cau22")
                {
                    parameter9 = new SqlParameter("@Cau21", SqlDbType.NChar);
                    parameter9.Value = "1";
                    parameter10 = new SqlParameter("@Cau22", SqlDbType.NChar);
                    parameter10.Value = "0";
                    parameter11 = new SqlParameter("@Cau23", SqlDbType.NChar);
                    parameter11.Value = "0";
                    parameter12 = new SqlParameter("@Cau24", SqlDbType.NChar);
                    parameter12.Value = "0";
                    parameter13 = new SqlParameter("@Cau25", SqlDbType.NChar);
                    parameter13.Value = "0";

                }
                if (form["cau2"].ToString().Trim() == "cau23")
                {
                    parameter9 = new SqlParameter("@Cau21", SqlDbType.NChar);
                    parameter9.Value = "1";
                    parameter10 = new SqlParameter("@Cau22", SqlDbType.NChar);
                    parameter10.Value = "0";
                    parameter11 = new SqlParameter("@Cau23", SqlDbType.NChar);
                    parameter11.Value = "0";
                    parameter12 = new SqlParameter("@Cau24", SqlDbType.NChar);
                    parameter12.Value = "0";
                    parameter13 = new SqlParameter("@Cau25", SqlDbType.NChar);
                    parameter13.Value = "0";

                }
                if (form["cau2"].ToString().Trim() == "cau24")
                {
                    parameter9 = new SqlParameter("@Cau21", SqlDbType.NChar);
                    parameter9.Value = "1";
                    parameter10 = new SqlParameter("@Cau22", SqlDbType.NChar);
                    parameter10.Value = "0";
                    parameter11 = new SqlParameter("@Cau23", SqlDbType.NChar);
                    parameter11.Value = "0";
                    parameter12 = new SqlParameter("@Cau24", SqlDbType.NChar);
                    parameter12.Value = "0";
                    parameter13 = new SqlParameter("@Cau25", SqlDbType.NChar);
                    parameter13.Value = "0";

                }
                if (form["cau2"].ToString().Trim() == "cau25")
                {
                    parameter9 = new SqlParameter("@Cau21", SqlDbType.NChar);
                    parameter9.Value = "1";
                    parameter10 = new SqlParameter("@Cau22", SqlDbType.NChar);
                    parameter10.Value = "0";
                    parameter11 = new SqlParameter("@Cau23", SqlDbType.NChar);
                    parameter11.Value = "0";
                    parameter12 = new SqlParameter("@Cau24", SqlDbType.NChar);
                    parameter12.Value = "0";
                    parameter13 = new SqlParameter("@Cau25", SqlDbType.NChar);
                    parameter13.Value = "0";

                }

                parameter14 = new SqlParameter("@Text2", SqlDbType.NVarChar);
                parameter14.Value = form["txtcau2"].ToString();

                if (form["cau3"].ToString().Trim() == "cau31")
                {
                    parameter15 = new SqlParameter("@Cau31", SqlDbType.NChar);
                    parameter15.Value = "1";
                    parameter16 = new SqlParameter("@Cau32", SqlDbType.NChar);
                    parameter16.Value = "0";
                    parameter17 = new SqlParameter("@Cau33", SqlDbType.NChar);
                    parameter17.Value = "0";
                   

                }

                if (form["cau3"].ToString().Trim() == "cau32")
                {
                    parameter15 = new SqlParameter("@Cau31", SqlDbType.NChar);
                    parameter15.Value = "0";
                    parameter16 = new SqlParameter("@Cau32", SqlDbType.NChar);
                    parameter16.Value = "1";
                    parameter17 = new SqlParameter("@Cau33", SqlDbType.NChar);
                    parameter17.Value = "0";


                }

                if (form["cau3"].ToString().Trim() == "cau33")
                {
                    parameter15 = new SqlParameter("@Cau31", SqlDbType.NChar);
                    parameter15.Value = "0";
                    parameter16 = new SqlParameter("@Cau32", SqlDbType.NChar);
                    parameter16.Value = "0";
                    parameter17 = new SqlParameter("@Cau33", SqlDbType.NChar);
                    parameter17.Value = "1";


                }




                parameter18 = new SqlParameter("@Text4", SqlDbType.NChar);
                parameter18.Value = form["txtcau4"].ToString();
                parameter19 = new SqlParameter("@Text5", SqlDbType.NChar);
                parameter19.Value = form["txtcau5"].ToString();

                parameter20 = new SqlParameter("@Datcauhoi", SqlDbType.NVarChar);
                parameter20.Value = "";
                parameter21 = new SqlParameter("@Type", SqlDbType.NVarChar);
                parameter21.Value = "1";


                SQLHelper.SqlHelper.ExecuteNonQuery(_conn1, CommandType.StoredProcedure, "tbl_hoinghi2019_insert", parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7, parameter8,parameter9,parameter10, parameter11, parameter12, parameter13, parameter14, parameter15, parameter16, parameter17, parameter18, parameter19, parameter20, parameter21);





                Response.Redirect("/camon", false);
            }
            catch (Exception ex)
            {

            }




            return View();
        }
        public ActionResult CauhoiHoinghi()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CauhoiHoinghi(FormCollection form)
        {


            try
            {



                SqlConnection _conn1;
                _conn1 = new SqlConnection(ConfigurationManager.AppSettings["Main.ConnectionString"]);
                _conn1.Open();


                SqlParameter parameter1 = new SqlParameter();
                SqlParameter parameter2 = new SqlParameter();
                SqlParameter parameter3 = new SqlParameter();
                SqlParameter parameter4 = new SqlParameter();
                SqlParameter parameter5 = new SqlParameter();
                SqlParameter parameter6 = new SqlParameter();
                SqlParameter parameter7 = new SqlParameter();
                SqlParameter parameter8 = new SqlParameter();
                SqlParameter parameter9 = new SqlParameter();
                SqlParameter parameter10 = new SqlParameter();
                SqlParameter parameter11 = new SqlParameter();
                SqlParameter parameter12 = new SqlParameter();
                SqlParameter parameter13 = new SqlParameter();
                SqlParameter parameter14 = new SqlParameter();
                SqlParameter parameter15 = new SqlParameter();
                SqlParameter parameter16 = new SqlParameter();
                SqlParameter parameter17 = new SqlParameter();
                SqlParameter parameter18 = new SqlParameter();
                SqlParameter parameter19 = new SqlParameter();
                SqlParameter parameter20 = new SqlParameter();
                SqlParameter parameter21 = new SqlParameter();

                parameter1 = new SqlParameter("@Hoten", SqlDbType.NVarChar);
                parameter1.Value = form["txthoten"].ToString();

                parameter2 = new SqlParameter("@Phone", SqlDbType.NVarChar);
                parameter2.Value = form["txtsdt"].ToString();



                parameter3 = new SqlParameter("@Cau11", SqlDbType.NChar);
                    parameter3.Value = "";
                    parameter4 = new SqlParameter("@Cau12", SqlDbType.NChar);
                    parameter4.Value = "";
                    parameter5 = new SqlParameter("@Cau13", SqlDbType.NChar);
                    parameter5.Value = "";
                    parameter6 = new SqlParameter("@Cau14", SqlDbType.NChar);
                    parameter6.Value = "";
                    parameter7 = new SqlParameter("@Cau15", SqlDbType.NChar);
                    parameter7.Value = "";

                

                parameter8 = new SqlParameter("@Text1", SqlDbType.NVarChar);
                parameter8.Value = "";
                    parameter9 = new SqlParameter("@Cau21", SqlDbType.NChar);
                    parameter9.Value = "";
                    parameter10 = new SqlParameter("@Cau22", SqlDbType.NChar);
                    parameter10.Value = "";
                    parameter11 = new SqlParameter("@Cau23", SqlDbType.NChar);
                    parameter11.Value = "";
                    parameter12 = new SqlParameter("@Cau24", SqlDbType.NChar);
                    parameter12.Value = "";
                    parameter13 = new SqlParameter("@Cau25", SqlDbType.NChar);
                    parameter13.Value = "";
                parameter14 = new SqlParameter("@Text2", SqlDbType.NVarChar);
                parameter14.Value ="";

                    parameter15 = new SqlParameter("@Cau31", SqlDbType.NChar);
                    parameter15.Value = "";
                    parameter16 = new SqlParameter("@Cau32", SqlDbType.NChar);
                    parameter16.Value = "";
                    parameter17 = new SqlParameter("@Cau33", SqlDbType.NChar);
                    parameter17.Value = "";





                parameter18 = new SqlParameter("@Text4", SqlDbType.NChar);
                parameter18.Value = "";
                parameter19 = new SqlParameter("@Text5", SqlDbType.NChar);
                parameter19.Value = "";

                parameter20 = new SqlParameter("@Datcauhoi", SqlDbType.NVarChar);
                parameter20.Value = form["txtGhichu"].ToString();
                parameter21 = new SqlParameter("@Type", SqlDbType.NVarChar);
                parameter21.Value = "2";


                SQLHelper.SqlHelper.ExecuteNonQuery(_conn1, CommandType.StoredProcedure, "tbl_hoinghi2019_insert", parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7, parameter8, parameter9, parameter10, parameter11, parameter12, parameter13, parameter14, parameter15, parameter16, parameter17, parameter18, parameter19, parameter20, parameter21);




                Response.Redirect("/camon", false);
            }
            catch (Exception ex)
            {

            }




            return View();
        }
        public ActionResult DsCauhoi()
        {

            SQLServerConnection<Cms_Hoinghi> sQLServer1 = new SQLServerConnection<Cms_Hoinghi>();
            List<Cms_Hoinghi> _Hoinghi = sQLServer1.SelectQueryCommand("SP_Hoinghi_All", Common.getConnectionString());

            //List<Cms_News> _NewsDichvu = sQLServer.SelectQueryCommand("SP_cms_News_SelectTopDichvu", Common.getConnectionString());
            ViewBag.Hoinghi = _Hoinghi;
            return View();
        }
        public ActionResult Trachnhiem()
        {
            
            return View();
        }
        public ActionResult Chinhsach()
        {
           


            return View();
        }
        public ActionResult Quyche()
        {


            return View();
        }
        public ActionResult Timkiem(string tukhoa)
        {
            try
            {
               
                if (!string.IsNullOrEmpty(tukhoa))
                {

                    ViewBag.Tukhoa = tukhoa;
                    SQLServerConnection<Cms_News> sQLServer = new SQLServerConnection<Cms_News>();
                    List<Cms_News> _NewsCate = sQLServer.SelectQueryCommand("SP_cms_News_Timkiem", Common.getConnectionString(), tukhoa);
                    ViewBag.NewsCate = _NewsCate;
                    //dung do server icnm treo
                    SQLServerConnection<Question> sQLServer2 = new SQLServerConnection<Question>();
                    List<Question> _QuestionCate = sQLServer2.SelectQueryCommand("Question_GetByCateIDAndPage1", Common.getConnectionStringIcnm(), tukhoa);
                    ViewBag.QuestionCate = _QuestionCate;




                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập vào từ tìm kiếm');</script>";

                    Response.Redirect("https://medlatec.vn",false);
                }
                //dung do server icnm treo
                SQLServerConnection<Question> sQLServer3 = new SQLServerConnection<Question>();
                List<Question> _TopCauHoi = sQLServer3.SelectQueryCommand("Question_GetTieuDe", Common.getConnectionStringIcnm());
                ViewBag.TopCauHoi = _TopCauHoi;
                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

            }
            catch (Exception ex)
            {

            }


            return View();

        }
        public ActionResult KQTimkiem(string tukhoa)
        {
            try
            {
               
                if (!string.IsNullOrEmpty(tukhoa))
                {
                  

                    SQLServerConnection<Cms_News> sQLServer = new SQLServerConnection<Cms_News>();
                    List<Cms_News> _NewsCate = sQLServer.SelectQueryCommand("SP_cms_News_Timkiem", Common.getConnectionString(), tukhoa);
                    ViewBag.NewsCate = _NewsCate;
                    //dung do server icnm treo
                    SQLServerConnection<Question> sQLServer2 = new SQLServerConnection<Question>();
                    List<Question> _QuestionCate = sQLServer2.SelectQueryCommand("Question_GetByCateIDAndPage1", Common.getConnectionStringIcnm(), tukhoa);
                    ViewBag.QuestionCate = _QuestionCate;
                    ViewBag.Tukhoa = tukhoa;



                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập vào từ tìm kiếm');</script>";

                    Response.Redirect("https://medlatec.vn",false);
                }
                //dung do server icnm treo
                SQLServerConnection<Question> sQLServer3 = new SQLServerConnection<Question>();
                List<Question> _TopCauHoi = sQLServer3.SelectQueryCommand("Question_GetTieuDe", Common.getConnectionStringIcnm());
                ViewBag.TopCauHoi = _TopCauHoi;
                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

            }
            catch (Exception ex)
            {

            }
     

            return View();
           
        }

       
    }
    }