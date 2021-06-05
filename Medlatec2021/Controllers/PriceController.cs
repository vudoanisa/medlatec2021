using CaptchaMvc.HtmlHelpers;
using CMS_Core.Common;
using Dapper;
using MEDLATEC.BusinessLayer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;


namespace MEDLATEC2019.Controllers
{
    public class PriceController : Controller
    {
        // GET: Price
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home(string size, string page)
        {
            try
            {

                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _News = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.News = _News;

                int pagesize = 0;
                
                    if (page != null)
                    {
                        pagesize = int.Parse(page);
                    }
                    else
                    {
                        pagesize = 1;
                    }
 

                List<Cms_Price> _Price = new List<Cms_Price>();

                HttpClient http = new HttpClient();
                string baseUrl = CMS_Core.Common.Common.getLINKAPI() + "api/Question/Get_PriceIDAndPage/?token=" + Common.generalKeyPrivate(pagesize.ToString()) + "&size=20&page=" + pagesize;
                string baseUrlAll = CMS_Core.Common.Common.getLINKAPI() + "api/Question/Get_PriceIDAndPage/?token=" + Common.generalKeyPrivate(pagesize.ToString()) + "&size=1000&page=" + pagesize;


                string url = baseUrlAll;
                string url1 = baseUrl;
                HttpResponseMessage response = http.GetAsync(new Uri(url)).Result;
                string responseBody = response.Content.ReadAsStringAsync().Result;

                HttpResponseMessage response1 = http.GetAsync(new Uri(url1)).Result;
                string responseBody1 = response1.Content.ReadAsStringAsync().Result;

                var countries = JsonConvert.DeserializeObject(responseBody);

                JArray jsonResponse = JArray.Parse(responseBody);

                JArray jsonResponse1 = JArray.Parse(responseBody1);

                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Tra cứu dịch vụ", Value = "" });

                foreach (var item in jsonResponse)
                {
                    Cms_Price rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Cms_Price>(item.ToString());                   
                    items.Add(new SelectListItem { Text = rowsDoctor.TenCP1, Value = rowsDoctor.TenCP1 });
                }

                foreach (var item in jsonResponse1)
                {
                    Cms_Price rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Cms_Price>(item.ToString());
                    _Price.Add(rowsDoctor);
                    
                }


                ViewBag.Price = _Price;
                ViewBag.GetDichvu = items;


                List<Cms_Price> _Total = new List<Cms_Price>();

                HttpClient http3 = new HttpClient();
                string number = Common.getRandom();
                string baseUrl3 = CMS_Core.Common.Common.getLINKAPI() + "api/Question/Get_PriceIDAndPage_Total/?token=" + Common.generalKeyPrivate(number) + "&number=" + number;
                 
                string url3 = baseUrl3;
                HttpResponseMessage response3 = http3.GetAsync(new Uri(url3)).Result;
                string responseBody3 = response3.Content.ReadAsStringAsync().Result;
                var countries3 = JsonConvert.DeserializeObject(responseBody3);

                JArray jsonResponse3 = JArray.Parse(responseBody3);

              

               
               

                foreach (var item in jsonResponse3)
                {

                    Cms_Price rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Cms_Price>(item.ToString());
                    _Total.Add(rowsDoctor);

                  

                }

                ViewBag.Total = _Total;
               

                ViewBag.page = pagesize;

            }
            catch (Exception ex)
            {

            }
            

            return View();
          
        }


        public ActionResult SearchKeyword(string tukhoa,string size, string page)
        {
            try
            {
                ViewBag.TukhoaLink = tukhoa;
                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _News = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.News = _News;

                int pagesize = 0;

                if (page != null)
                {
                    pagesize = int.Parse(page);
                }
                else
                {
                    pagesize = 1;
                }
                tukhoa = tukhoa.Replace("-", " ");

                string url = "api/Question/Get_PriceByText_Page?tukhoa=" + tukhoa + "&token=" + Common.generalKeyPrivate(tukhoa) + "&size=" + 20 + "&page=" + pagesize;
                List<Cms_Price> _Price = ImpCallAPI<Cms_Price>.geContentAPI(url);


                string baseUrlAll =  "api/Question/Get_PriceIDAndPage/?token=" + Common.generalKeyPrivate(pagesize.ToString()) + "&size=1000&page=" + pagesize;
                List<Cms_Price> _Price1 = ImpCallAPI<Cms_Price>.geContentAPI(baseUrlAll);

                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Tra cứu dịch vụ", Value = "" });

                foreach (var item in _Price1)
                {
                    
                    items.Add(new SelectListItem { Text = item.TenCP1, Value = item.TenCP1 });
                }
                ViewBag.GetDichvu = items;

             
                url = "api/Question/Get_PriceByText_Page_Total?tukhoa=" + tukhoa + "&token=" + Common.generalKeyPrivate(tukhoa) ;
                List<Cms_Price> _Total = ImpCallAPI<Cms_Price>.geContentAPI(url);

                ViewBag.Total = _Total;                 

                if (_Price.Count > 0)
                {
                    ViewBag.Price = _Price;



                    ViewBag.Tukhoa = tukhoa;

                }
                else
                {

                }



                ViewBag.page = pagesize;



            }
            catch (Exception ex)
            {

            }
          

            return View();

        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Home(string submit, string page, FormCollection form)
        {
            try
            {
                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _News = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.News = _News;

                SQLServerConnection<Cms_Price> sQLServer2 = new SQLServerConnection<Cms_Price>();
                List<Cms_Price> _Total = sQLServer2.SelectQueryCommand("Get_PriceIDAndPage_Total", Common.getConnectionStringPMBV());
                ViewBag.Total = _Total;

                if (submit != null)
                {
                    if (submit == "SaveAdd")
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
                        ViewBag.page = pagesize;
                        string timkiem = form["Dichvu"].ToString();


                        Response.Redirect("/bang-gia-dich-vu/s/"+Common.getNiceUrl_TV(timkiem),false);

                    }

                    if (submit == "SaveDK")
                    {
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

                                if ((form["txtsdt"].ToString().Length > 11) && (form["txtsdt"].ToString().Length < 9))
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

                        int pagesize = 0;

                        if (page != null)
                        {
                            pagesize = int.Parse(page);
                        }
                        else
                        {
                            pagesize = 1;
                        }
                        ViewBag.page = pagesize;

                        SQLServerConnection<Cms_Price> sQLServer = new SQLServerConnection<Cms_Price>();
                        List<Cms_Price> _Price = sQLServer.SelectQueryCommand("Get_PriceIDAndPage", Common.getConnectionStringPMBV(), 20, pagesize);
                        ViewBag.Price = _Price;
                 


                        //SqlConnection _conn;
                        //_conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                        //_conn.Open();



                        //// Info.  
                        //string sql = string.Empty;
                        //sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,email,Ghichudv,PLDL) values(";
                        //sql += "@hoten,@sdt,@ngayhen,@ghichu,0,@email,N'WebMed - Đăng ký nhanh từ bảng giá','WEBMEDMOI')";


                        //SqlCommand comd = new SqlCommand(sql, _conn);



                        //comd.Parameters.AddWithValue("@hoten", SqlDbType.NVarChar).Value = form["txthoten"].ToString();
                        //comd.Parameters.AddWithValue("@sdt", SqlDbType.NVarChar).Value = form["txtsdt"].ToString();
                        //comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString());
                        //comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();
                        //comd.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = form["txtemail"].ToString();


                        //comd.ExecuteNonQuery();
                        //_conn.Close();

                        //Response.Redirect("/thankyou", false);


                        CMS_Core.Common.Common.DatlichTin(form["txthoten"].ToString(), form["txtsdt"].ToString(), form["txtghichu"].ToString(), form["txtemail"].ToString(), "WebMed - Đăng ký nhanh từ bảng giá", "WEBMEDMOI");
                        Response.Redirect("/thankyou?u=banggia", false);

                    


                    }




                }




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
        [HttpPost]

        public ActionResult SearchKeyword(string submit, string page, FormCollection form)
        {
            try
            {
                SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _News = sQLServer2.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.News = _News;
                //63fucWlQi185SSy+pUpEtBfapPs+JHV+RX7ieJ7rlSs=
                if (submit != null)
                {
                    if (submit == "SaveAdd")
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
                        ViewBag.page = pagesize;

                        string timkiem = form["Dichvu"].ToString();// form["txttimkiem"].ToString();



                        Response.Redirect("/bang-gia-dich-vu/s/" + Common.getNiceUrl_TV(timkiem), false);


                    }




                }




            }
            catch (Exception ex)
            {

            }


            return View();
        }
    }
}