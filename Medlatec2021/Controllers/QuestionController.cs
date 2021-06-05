using CaptchaMvc.HtmlHelpers;
using CMS_Core.Common;
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
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;


namespace MEDLATEC2019.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Question
        public static bool IsNumeric(string input)
        {
            return Regex.IsMatch(input, @"^\d+$");
        }
        public ActionResult Index(string size, string page)
        {
            try
            {
                int pagesize = 0;

                if (page != null)
                {
                    if (IsNumeric(page) == true)
                    {
                        pagesize = int.Parse(page);

                    }
                    else
                    {
                        if (page.Contains("q"))
                        {

                            int vitri = page.IndexOf("q");
                            string a = page.Replace(page.Substring(0, vitri + 1), "");



                            string rl = "";
                            //List<Question> _Cauhoi;

                            List<Question> _Cauhoi = new List<Question>();

                            HttpClient http4 = new HttpClient();
                            string baseUrl4 = CMS_Core.Common.Common.getLINKAPI() + "api/Question/GetDetailsQuestionByID/?token=" + Common.generalKeyPrivate(a) + "&id=" + a;

                            string url4 = baseUrl4;
                            HttpResponseMessage response4 = http4.GetAsync(new Uri(url4)).Result;
                            string responseBody4 = response4.Content.ReadAsStringAsync().Result;
                            var countries4 = JsonConvert.DeserializeObject(responseBody4);

                            JArray jsonResponse4 = JArray.Parse(responseBody4);

                            foreach (var item in jsonResponse4)
                            {
                                Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                                _Cauhoi.Add(rowsDoctor);

                            }



                            if (_Cauhoi.Count > 0)
                            {
                                string linkcheck1 = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByNews("hoi-dap", CMS_Core.Common.Common.removeCharEncode(_Cauhoi[0].QuestionTitle.ToString().TrimStart().TrimEnd().ToLower()), "c" + _Cauhoi[0].SpecialistID.ToString(), "q" + _Cauhoi[0].QuestionID.ToString());
                                Response.RedirectPermanent(linkcheck1, false);
                            }





                        }

                    }

                }
                else
                {
                    pagesize = 1;
                }


               

                List<Question> _QuestionCate = new List<Question>();

                HttpClient http3 = new HttpClient();
                string baseUrl3 = CMS_Core.Common.Common.getLINKAPI() + "api/Question/Question_GetByPage/?token=" + Common.generalKeyPrivate("15") + "&size=15&page=" + pagesize;

                string url3 = baseUrl3;
                HttpResponseMessage response3 = http3.GetAsync(new Uri(url3)).Result;
                string responseBody3 = response3.Content.ReadAsStringAsync().Result;
                var countries3 = JsonConvert.DeserializeObject(responseBody3);

                JArray jsonResponse3 = JArray.Parse(responseBody3);

                foreach (var item in jsonResponse3)
                {
                    Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                    _QuestionCate.Add(rowsDoctor);

                }
                ViewBag.QuestionCate = _QuestionCate;

                ViewBag.page = pagesize;







                List<Question> _TopCauHoi = new List<Question>();

                HttpClient http2 = new HttpClient();
                string number = Common.getRandom();
                string baseUrl2 = CMS_Core.Common.Common.getLINKAPI() + "api/Question/Question_GetTieuDe/?token=" + Common.generalKeyPrivate(number) + "&number=" + number;

                string url2 = baseUrl2;
                HttpResponseMessage response2 = http2.GetAsync(new Uri(url2)).Result;
                string responseBody2 = response2.Content.ReadAsStringAsync().Result;
                var countries2 = JsonConvert.DeserializeObject(responseBody2);

                JArray jsonResponse2 = JArray.Parse(responseBody2);

                foreach (var item in jsonResponse2)
                {
                    Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                    _TopCauHoi.Add(rowsDoctor);

                }
                ViewBag.TopCauHoi = _TopCauHoi;


                List<Question> _DanhMucCauHoi = new List<Question>();

                HttpClient http1 = new HttpClient();
                string baseUrl1 = CMS_Core.Common.Common.getLINKAPI() + "api/Question/GetSpecialist/?token=" + Common.generalKeyPrivate(number) + "&number=" + number;

                string url1 = baseUrl1;
                HttpResponseMessage response1 = http1.GetAsync(new Uri(url1)).Result;
                string responseBody1 = response1.Content.ReadAsStringAsync().Result;
                var countries1 = JsonConvert.DeserializeObject(responseBody1);

                JArray jsonResponse1 = JArray.Parse(responseBody1);

                foreach (var item in jsonResponse1)
                {
                    Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                    _DanhMucCauHoi.Add(rowsDoctor);

                }
                ViewBag.DanhMucCauHoi = _DanhMucCauHoi;





                List<Question> _Tongcauhoi = new List<Question>();

                HttpClient http = new HttpClient();
                string baseUrl = CMS_Core.Common.Common.getLINKAPI() + "api/Question/GetSumQuestion/?token=" + Common.generalKeyPrivate(number) + "&number=" + number;

                string url = baseUrl;
                HttpResponseMessage response = http.GetAsync(new Uri(url)).Result;
                string responseBody = response.Content.ReadAsStringAsync().Result;
                var countries = JsonConvert.DeserializeObject(responseBody);

                JArray jsonResponse = JArray.Parse(responseBody);

                foreach (var item in jsonResponse)
                {
                    Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                    _Tongcauhoi.Add(rowsDoctor);

                }
                ViewBag.Tongcauhoi = _Tongcauhoi;

                SQLServerConnection<Cms_News> sQLServer4 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer4.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

            }
            catch (Exception ex)
            {

            }

            return View();

        }
        public ActionResult QuestionCate(string cid, string size, string page)
        {
            try
            {
                int pagesize = 0;
                if (!string.IsNullOrEmpty(cid))
                {
                    if (page != null)
                    {
                        pagesize = int.Parse(page);
                    }
                    else
                    {
                        pagesize = 1;
                    }




                    List<Question> _QuestionCate = new List<Question>();
                    //SQLServerConnection<Question> sQLServer = new SQLServerConnection<Question>();
                    //_QuestionCate = sQLServer.SelectQueryCommand("Question_GetByCateIDAndPage", Common.getConnectionStringIcnm(), cid, 15, pagesize);



                    //List<Question> _QuestionCate = new List<Question>();

                    HttpClient http3 = new HttpClient();
                    string baseUrl3 = CMS_Core.Common.Common.getLINKAPI() + "api/Question/Question_GetByCateIDAndPage/?token=" + Common.generalKeyPrivate(cid) + "&SpecialistID=" + cid + "&size=15&page=" + pagesize;

                    string url3 = baseUrl3;
                    HttpResponseMessage response3 = http3.GetAsync(new Uri(url3)).Result;
                    string responseBody3 = response3.Content.ReadAsStringAsync().Result;
                    var countries3 = JsonConvert.DeserializeObject(responseBody3);

                    JArray jsonResponse3 = JArray.Parse(responseBody3);

                    foreach (var item in jsonResponse3)
                    {
                        Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                        _QuestionCate.Add(rowsDoctor);

                    }
                    //  ViewBag.TopCauHoi = _QuestionCate;





                    if (_QuestionCate.Count == 0)
                    {
                        _QuestionCate = new List<Question>();
                        //SQLServerConnection<Question> sQLServer6 = new SQLServerConnection<Question>();
                        //  _QuestionCate = sQLServer6.SelectQueryCommand("Question_GetByCateIDAndPage", Common.getConnectionStringIcnm(), cid, 15, 1);

                        HttpClient http4 = new HttpClient();
                        string baseUrl4 = CMS_Core.Common.Common.getLINKAPI() + "api/Question/Question_GetByCateIDAndPage/?token=" + Common.generalKeyPrivate(cid) + "&SpecialistID=" + cid + "&size=15&page=1";

                        string url4 = baseUrl4;
                        HttpResponseMessage response4 = http4.GetAsync(new Uri(url4)).Result;
                        string responseBody4 = response4.Content.ReadAsStringAsync().Result;
                        var countries4 = JsonConvert.DeserializeObject(responseBody4);

                        JArray jsonResponse4 = JArray.Parse(responseBody4);

                        foreach (var item in jsonResponse4)
                        {
                            Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                            _QuestionCate.Add(rowsDoctor);

                        }



                        if (_QuestionCate.Count > 0)
                        {
                            ViewBag.QuestionCate = _QuestionCate;

                            ViewBag.page = 1;
                            string abc = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByCate("hoi-dap", _QuestionCate[0].SpecialName.ToString().ToLower(), "c" + _QuestionCate[0].SpecialistID.ToString());
                            Response.RedirectPermanent(abc, false);


                        }
                        else
                        {
                            Response.RedirectPermanent("https://medlatec.vn", true);
                        }

                        ViewBag.page = 1;

                    }
                    else
                    {
                        ViewBag.QuestionCate = _QuestionCate;

                        ViewBag.page = pagesize;

                    }

                }



                List<Question> _TopCauHoi = new List<Question>();

                HttpClient http2 = new HttpClient();
                string number = Common.getRandom();
                string baseUrl2 = CMS_Core.Common.Common.getLINKAPI() + "api/Question/Question_GetTieuDe/?token=" + Common.generalKeyPrivate(number) + "&number=" + number;

                string url2 = baseUrl2;
                HttpResponseMessage response2 = http2.GetAsync(new Uri(url2)).Result;
                string responseBody2 = response2.Content.ReadAsStringAsync().Result;
                var countries2 = JsonConvert.DeserializeObject(responseBody2);

                JArray jsonResponse2 = JArray.Parse(responseBody2);

                foreach (var item in jsonResponse2)
                {
                    Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                    _TopCauHoi.Add(rowsDoctor);

                }
                ViewBag.TopCauHoi = _TopCauHoi;


                List<Question> _DanhMucCauHoi = new List<Question>();

                HttpClient http1 = new HttpClient();
                string baseUrl1 = CMS_Core.Common.Common.getLINKAPI() + "api/Question/GetSpecialist/?token=" + Common.generalKeyPrivate(number) + "&number=" + number;


                string url1 = baseUrl1;
                HttpResponseMessage response1 = http1.GetAsync(new Uri(url1)).Result;
                string responseBody1 = response1.Content.ReadAsStringAsync().Result;
                var countries1 = JsonConvert.DeserializeObject(responseBody1);

                JArray jsonResponse1 = JArray.Parse(responseBody1);

                foreach (var item in jsonResponse1)
                {
                    Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                    _DanhMucCauHoi.Add(rowsDoctor);

                }
                ViewBag.DanhMucCauHoi = _DanhMucCauHoi;





                List<Question> _Tongcauhoi = new List<Question>();

                HttpClient http = new HttpClient();
                string baseUrl = CMS_Core.Common.Common.getLINKAPI() + "api/Question/GetSumQuestion/?token=" + Common.generalKeyPrivate(number) + "&number=" + number;


                string url = baseUrl;
                HttpResponseMessage response = http.GetAsync(new Uri(url)).Result;
                string responseBody = response.Content.ReadAsStringAsync().Result;
                var countries = JsonConvert.DeserializeObject(responseBody);

                JArray jsonResponse = JArray.Parse(responseBody);

                foreach (var item in jsonResponse)
                {
                    Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                    _Tongcauhoi.Add(rowsDoctor);

                }
                ViewBag.Tongcauhoi = _Tongcauhoi;



                SQLServerConnection<Cms_News> sQLServer4 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer4.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;



                List<Question> _TotalCK = new List<Question>();

                HttpClient http5 = new HttpClient();
                string baseUrl5 = CMS_Core.Common.Common.getLINKAPI() + "api/Question/Question_GetByCateIDAndPage_Total_1/?token=" + Common.generalKeyPrivate(cid) + "&SpecialistID=" + cid;


                string url5 = baseUrl5;
                HttpResponseMessage response5 = http.GetAsync(new Uri(url5)).Result;
                string responseBody5 = response.Content.ReadAsStringAsync().Result;
                var countries5 = JsonConvert.DeserializeObject(responseBody5);

                JArray jsonResponse5 = JArray.Parse(responseBody5);

                foreach (var item in jsonResponse)
                {
                    Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                    _TotalCK.Add(rowsDoctor);

                }
                ViewBag.TotalCK = _TotalCK;


            }
            catch (Exception ex)
            {

            }

            return View();

        }
        public ActionResult EditCauhoi()
        {
            try
            {

            }
            catch (Exception ex)
            {
            }
            return View();
        }
        public ActionResult UpdateCauhoi(string id)
        {
            try
            {
                List<Question> _Cauhoi = new List<Question>();

                HttpClient http4 = new HttpClient();
                string baseUrl4 = CMS_Core.Common.Common.getLINKAPI() + "api/Question/GetDetailsQuestionByID/?token=" + Common.generalKeyPrivate(id) + "&id=" + id;
                string url4 = baseUrl4;
                HttpResponseMessage response4 = http4.GetAsync(new Uri(url4)).Result;
                string responseBody4 = response4.Content.ReadAsStringAsync().Result;
                var countries4 = JsonConvert.DeserializeObject(responseBody4);

                JArray jsonResponse4 = JArray.Parse(responseBody4);

                foreach (var item in jsonResponse4)
                {
                    Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                    _Cauhoi.Add(rowsDoctor);

                }
                if (_Cauhoi.Count > 0)
                {
                    ViewBag.CauHoi = _Cauhoi;
                }
                else
                {
                    TempData["msg"] = "<script>alert('Thông tin khách hàng không đúng! vui lòng đăng nhập lại.');</script>";
                }
            }
            catch (Exception ex)
            {
            }
            return View();
        }
        public ActionResult SendQuestion()
        {
            try
            {



                SQLServerConnection<Cms_News> sQLServer4 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer4.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;



                List<Question> _TopCauHoi = new List<Question>();

                HttpClient http2 = new HttpClient();
                //string number = Common.getRandom().ToString();
                string number = Common.getRandom();
                string baseUrl2 = CMS_Core.Common.Common.getLINKAPI() + "api/Question/Question_GetTieuDe/?token=" + Common.generalKeyPrivate(number) + "&number=" + number;

                string url2 = baseUrl2;
                HttpResponseMessage response2 = http2.GetAsync(new Uri(url2)).Result;
                string responseBody2 = response2.Content.ReadAsStringAsync().Result;
                var countries2 = JsonConvert.DeserializeObject(responseBody2);

                JArray jsonResponse2 = JArray.Parse(responseBody2);

                foreach (var item in jsonResponse2)
                {
                    Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                    _TopCauHoi.Add(rowsDoctor);

                }
                ViewBag.TopCauHoi = _TopCauHoi;


                List<Question> _DanhMucCauHoi = new List<Question>();

                HttpClient http1 = new HttpClient();
                string baseUrl1 = CMS_Core.Common.Common.getLINKAPI() + "api/Question/GetSpecialist/?token=" + Common.generalKeyPrivate(number) + "&number=" + number;

                string url1 = baseUrl1;
                HttpResponseMessage response1 = http1.GetAsync(new Uri(url1)).Result;
                string responseBody1 = response1.Content.ReadAsStringAsync().Result;
                var countries1 = JsonConvert.DeserializeObject(responseBody1);

                JArray jsonResponse1 = JArray.Parse(responseBody1);

                foreach (var item in jsonResponse1)
                {
                    Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                    _DanhMucCauHoi.Add(rowsDoctor);

                }
                ViewBag.DanhMucCauHoi = _DanhMucCauHoi;





                List<Question> _Tongcauhoi = new List<Question>();

                HttpClient http = new HttpClient();
                string baseUrl = CMS_Core.Common.Common.getLINKAPI() + "api/Question/GetSumQuestion/?token=" + Common.generalKeyPrivate(number) + "&number=" + number;

                string url = baseUrl;
                HttpResponseMessage response = http.GetAsync(new Uri(url)).Result;
                string responseBody = response.Content.ReadAsStringAsync().Result;
                var countries = JsonConvert.DeserializeObject(responseBody);

                JArray jsonResponse = JArray.Parse(responseBody);

                foreach (var item in jsonResponse)
                {
                    Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                    _Tongcauhoi.Add(rowsDoctor);

                }
                ViewBag.Tongcauhoi = _Tongcauhoi;


            }
            catch (Exception ex)
            {

            }

            return View();
        }


        public ActionResult GenMapCauhoi()
        {
            try
            {


                SQLServerConnection<Question> sQLServer8 = new SQLServerConnection<Question>();
                List<Question> _QuestionCT = sQLServer8.SelectQueryCommand("GetQuestionSitemap", Common.getConnectionStringIcnm());
                if (_QuestionCT.Count > 0)
                {
                    ViewBag.QuestionCT = _QuestionCT;

                }



            }
            catch (Exception ex)
            {

            }

            return View();
        }


        //public ActionResult QuestionDetails()
        //{
        //    return View();
        //}
        public ActionResult QuestionDetails(string qid, string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {


                    List<Question> _Cauhoi = new List<Question>();

                    HttpClient http4 = new HttpClient();
                    string baseUrl4 = CMS_Core.Common.Common.getLINKAPI() + "api/Question/GetDetailsQuestionByID/?token=" + Common.generalKeyPrivate(id) + "&id=" + id;
                    string url4 = baseUrl4;
                    HttpResponseMessage response4 = http4.GetAsync(new Uri(url4)).Result;
                    string responseBody4 = response4.Content.ReadAsStringAsync().Result;
                    var countries4 = JsonConvert.DeserializeObject(responseBody4);

                    JArray jsonResponse4 = JArray.Parse(responseBody4);

                    foreach (var item in jsonResponse4)
                    {
                        Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                        _Cauhoi.Add(rowsDoctor);

                    }



                    if (_Cauhoi != null)
                    {
                        if (_Cauhoi.Count > 0)
                        {

                            string rl = "";

                            List<Question> _CahoiLienQuan = new List<Question>();

                            HttpClient http7 = new HttpClient();
                            string baseUrl7 = CMS_Core.Common.Common.getLINKAPI() + "api/Question/GetListQuestionRelated/?token=" + Common.generalKeyPrivate(id) + "&id=" + id + "&SpecialistID=" + _Cauhoi[0].SpecialistID;

                            string url7 = baseUrl7;
                            HttpResponseMessage response7 = http7.GetAsync(new Uri(url7)).Result;
                            string responseBody7 = response7.Content.ReadAsStringAsync().Result;
                            var countries7 = JsonConvert.DeserializeObject(responseBody7);

                            JArray jsonResponse7 = JArray.Parse(responseBody7);

                            foreach (var item in jsonResponse7)
                            {
                                Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                                _CahoiLienQuan.Add(rowsDoctor);

                            }
                            ViewBag.CahoiLienQuan = _CahoiLienQuan;
                            ViewBag.CauHoi = _Cauhoi;




                            SQLServerConnection<Cms_NewsTags> sQLServer4 = new SQLServerConnection<Cms_NewsTags>();
                            List<Cms_NewsTags> _Tag = sQLServer4.SelectQueryCommand("Get_Tags_ByTagsName_Q", Common.getConnectionString(), _Cauhoi[0].SpecialName.ToString().TrimEnd().TrimStart());
                            ViewBag.Tag = _Tag;




                            SQLServerConnection<Cms_News> sQLServer5 = new SQLServerConnection<Cms_News>();
                            List<Cms_News> _TinNoiBat = sQLServer5.SelectQueryCommand("SP_cms_News_by_Q", Common.getConnectionString(), _Cauhoi[0].SpecialName.ToString().TrimEnd().TrimStart());
                            ViewBag.TinNoiBat = _TinNoiBat;






                        }
                        else
                        {

                            HttpClient http6 = new HttpClient();
                            string baseUrl6 = CMS_Core.Common.Common.getLINKAPI() + "api/Question/Question_GetTheoID_NotCate/?token=" + Common.generalKeyPrivate(id) + "&QuestionID=" + id;

                            string url6 = baseUrl6;
                            HttpResponseMessage response6 = http6.GetAsync(new Uri(url6)).Result;
                            string responseBody6 = response6.Content.ReadAsStringAsync().Result;
                            var countries6 = JsonConvert.DeserializeObject(responseBody6);

                            JArray jsonResponse6 = JArray.Parse(responseBody6);

                            foreach (var item in jsonResponse6)
                            {
                                Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                                _Cauhoi.Add(rowsDoctor);

                            }
                            ViewBag.CauHoi = _Cauhoi;



                            Response.RedirectPermanent("https://medlatec.vn/hoi-dap", true);

                        }
                    }
                    else
                    {

                        Response.RedirectPermanent("https://medlatec.vn/hoi-dap", true);

                    }



                    List<Question> _TopCauHoi = new List<Question>();

                    HttpClient http2 = new HttpClient();
                    string number = Common.getRandom();
                    string baseUrl2 = CMS_Core.Common.Common.getLINKAPI() + "api/Question/Question_GetTieuDe/?token=" + Common.generalKeyPrivate(number) + "&number=" + number;

                    string url2 = baseUrl2;
                    HttpResponseMessage response2 = http2.GetAsync(new Uri(url2)).Result;
                    string responseBody2 = response2.Content.ReadAsStringAsync().Result;
                    var countries2 = JsonConvert.DeserializeObject(responseBody2);

                    JArray jsonResponse2 = JArray.Parse(responseBody2);

                    foreach (var item in jsonResponse2)
                    {
                        Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                        _TopCauHoi.Add(rowsDoctor);

                    }
                    ViewBag.TopCauHoi = _TopCauHoi;


                    List<Question> _DanhMucCauHoi = new List<Question>();

                    HttpClient http1 = new HttpClient();
                    string baseUrl1 = CMS_Core.Common.Common.getLINKAPI() + "api/Question/GetSpecialist/?token=" + Common.generalKeyPrivate(number) + "&number=" + number;

                    string url1 = baseUrl1;
                    HttpResponseMessage response1 = http1.GetAsync(new Uri(url1)).Result;
                    string responseBody1 = response1.Content.ReadAsStringAsync().Result;
                    var countries1 = JsonConvert.DeserializeObject(responseBody1);

                    JArray jsonResponse1 = JArray.Parse(responseBody1);

                    foreach (var item in jsonResponse1)
                    {
                        Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                        _DanhMucCauHoi.Add(rowsDoctor);

                    }
                    ViewBag.DanhMucCauHoi = _DanhMucCauHoi;





                    List<Question> _Tongcauhoi = new List<Question>();

                    HttpClient http = new HttpClient();
                    string baseUrl = CMS_Core.Common.Common.getLINKAPI() + "api/Question/GetSumQuestion/?token=" + Common.generalKeyPrivate(number) + "&number=" + number;

                    string url = baseUrl;
                    HttpResponseMessage response = http.GetAsync(new Uri(url)).Result;
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    var countries = JsonConvert.DeserializeObject(responseBody);

                    JArray jsonResponse = JArray.Parse(responseBody);

                    foreach (var item in jsonResponse)
                    {
                        Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                        _Tongcauhoi.Add(rowsDoctor);

                    }
                    ViewBag.Tongcauhoi = _Tongcauhoi;

                }


            }
            catch (Exception ex)
            {

            }

            return View();
        }


        public ActionResult AMPQuestionDetails(string qid, string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    //List<Question> _Cauhoi;


                    List<Question> _Cauhoi = new List<Question>();

                    HttpClient http4 = new HttpClient();
                    string baseUrl4 = CMS_Core.Common.Common.getLINKAPI() + "api/Question/GetDetailsQuestionByID/?token=" + Common.generalKeyPrivate(id) + "&id=" + id;

                    string url4 = baseUrl4;
                    HttpResponseMessage response4 = http4.GetAsync(new Uri(url4)).Result;
                    string responseBody4 = response4.Content.ReadAsStringAsync().Result;
                    var countries4 = JsonConvert.DeserializeObject(responseBody4);

                    JArray jsonResponse4 = JArray.Parse(responseBody4);

                    foreach (var item in jsonResponse4)
                    {
                        Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                        _Cauhoi.Add(rowsDoctor);

                    }


                    if (_Cauhoi != null)
                    {
                        if (_Cauhoi.Count > 0)
                        {

                            string rl = "";


                            List<Question> _CahoiLienQuan = new List<Question>();

                            HttpClient http7 = new HttpClient();
                            string baseUrl7 = CMS_Core.Common.Common.getLINKAPI() + "api/Question/GetListQuestionRelated/?token=" + Common.generalKeyPrivate(id) + "&id=" + id + "&SpecialistID=" + _Cauhoi[0].SpecialistID;


                            string url7 = baseUrl7;
                            HttpResponseMessage response7 = http7.GetAsync(new Uri(url7)).Result;
                            string responseBody7 = response7.Content.ReadAsStringAsync().Result;
                            var countries7 = JsonConvert.DeserializeObject(responseBody7);

                            JArray jsonResponse7 = JArray.Parse(responseBody7);

                            foreach (var item in jsonResponse7)
                            {
                                Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                                _CahoiLienQuan.Add(rowsDoctor);

                            }
                            ViewBag.CahoiLienQuan = _CahoiLienQuan;
                            ViewBag.CauHoi = _Cauhoi;

                            SQLServerConnection<Cms_NewsTags> sQLServer4 = new SQLServerConnection<Cms_NewsTags>();
                            List<Cms_NewsTags> _Tag = sQLServer4.SelectQueryCommand("Get_Tags_ByTagsName_Q", Common.getConnectionString(), _Cauhoi[0].SpecialName.ToString().TrimEnd().TrimStart());
                            ViewBag.Tag = _Tag;

                            SQLServerConnection<Cms_News> sQLServer5 = new SQLServerConnection<Cms_News>();
                            List<Cms_News> _TinNoiBat = sQLServer5.SelectQueryCommand("SP_cms_News_by_Q", Common.getConnectionString(), _Cauhoi[0].SpecialName.ToString().TrimEnd().TrimStart());
                            ViewBag.TinNoiBat = _TinNoiBat;





                        }
                        else
                        {


                            HttpClient http6 = new HttpClient();
                            string baseUrl6 = CMS_Core.Common.Common.getLINKAPI() + "api/Question/Question_GetTheoID_NotCate/?token=" + Common.generalKeyPrivate(id) + "&QuestionID=" + id;
                            string url6 = baseUrl6;
                            HttpResponseMessage response6 = http6.GetAsync(new Uri(url6)).Result;
                            string responseBody6 = response6.Content.ReadAsStringAsync().Result;
                            var countries6 = JsonConvert.DeserializeObject(responseBody6);

                            JArray jsonResponse6 = JArray.Parse(responseBody6);

                            foreach (var item in jsonResponse6)
                            {
                                Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                                _Cauhoi.Add(rowsDoctor);

                            }
                            ViewBag.CauHoi = _Cauhoi;

                            Response.RedirectPermanent("https://medlatec.vn/hoi-dap", true);

                        }
                    }
                    else
                    {

                        Response.RedirectPermanent("https://medlatec.vn/hoi-dap", true);

                    }



                    List<Question> _TopCauHoi = new List<Question>();

                    HttpClient http2 = new HttpClient();
                    string number = Common.getRandom();
                    string baseUrl2 = CMS_Core.Common.Common.getLINKAPI() + "api/Question/Question_GetTieuDe/?token=" + Common.generalKeyPrivate(number) + "&number=" + number;


                    string url2 = baseUrl2;
                    HttpResponseMessage response2 = http2.GetAsync(new Uri(url2)).Result;
                    string responseBody2 = response2.Content.ReadAsStringAsync().Result;
                    var countries2 = JsonConvert.DeserializeObject(responseBody2);

                    JArray jsonResponse2 = JArray.Parse(responseBody2);

                    foreach (var item in jsonResponse2)
                    {
                        Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                        _TopCauHoi.Add(rowsDoctor);

                    }
                    ViewBag.TopCauHoi = _TopCauHoi;


                    List<Question> _DanhMucCauHoi = new List<Question>();

                    HttpClient http1 = new HttpClient();
                    string baseUrl1 = CMS_Core.Common.Common.getLINKAPI() + "api/Question/GetSpecialist/?token=" + Common.generalKeyPrivate(number) + "&number=" + number;

                    string url1 = baseUrl1;
                    HttpResponseMessage response1 = http1.GetAsync(new Uri(url1)).Result;
                    string responseBody1 = response1.Content.ReadAsStringAsync().Result;
                    var countries1 = JsonConvert.DeserializeObject(responseBody1);

                    JArray jsonResponse1 = JArray.Parse(responseBody1);

                    foreach (var item in jsonResponse1)
                    {
                        Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                        _DanhMucCauHoi.Add(rowsDoctor);

                    }
                    ViewBag.DanhMucCauHoi = _DanhMucCauHoi;





                    List<Question> _Tongcauhoi = new List<Question>();

                    HttpClient http = new HttpClient();
                    string baseUrl = CMS_Core.Common.Common.getLINKAPI() + "api/Question/GetSumQuestion/?token=" + Common.generalKeyPrivate(number) + "&number=" + number;


                    string url = baseUrl;
                    HttpResponseMessage response = http.GetAsync(new Uri(url)).Result;
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    var countries = JsonConvert.DeserializeObject(responseBody);

                    JArray jsonResponse = JArray.Parse(responseBody);

                    foreach (var item in jsonResponse)
                    {
                        Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                        _Tongcauhoi.Add(rowsDoctor);

                    }
                    ViewBag.Tongcauhoi = _Tongcauhoi;

                }


            }
            catch (Exception ex)
            {

            }

            return View();
        }



        public static string RemoveUnicode13(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
    "đ",
    "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
    "í","ì","ỉ","ĩ","ị",
    "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
    "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
    "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
    "d",
    "e","e","e","e","e","e","e","e","e","e","e",
    "i","i","i","i","i",
    "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
    "u","u","u","u","u","u","u","u","u","u","u",
    "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text.Replace("&", "").Replace("@", "").Replace("--", "").Replace("select", "").Replace("insert", "").Replace("update", "").Replace("delete", "").Replace("truncate", "").Replace("'", "").Replace("\"", "");
        }
        private void sendGmail(string title, string to, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("suport.medlatec@gmail.com");
                mail.To.Add(to);
                //mail.Bcc.Add("nguyennhathoang@medlatec.com");
                //mail.CC.Add("nguyennhathoang@medlatec.com");
                //  mail.CC.Add("trandinhtoan1988@gmail.com");
                mail.Subject = title;

                mail.IsBodyHtml = true;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = body;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("suport.medlatec@gmail.com", "theson267");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                // lbnThongbao.Text = "Gửi mail bị lỗi";
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendQuestion(FormCollection form)
        {


            try
            {


                List<Question> _TopCauHoi = new List<Question>();

                HttpClient http2 = new HttpClient();
                string number = Common.getRandom();
                string baseUrl2 = CMS_Core.Common.Common.getLINKAPI() + "api/Question/Question_GetTieuDe/?token=" + Common.generalKeyPrivate(number) + "&number=" + number;


                string url2 = baseUrl2;
                HttpResponseMessage response2 = http2.GetAsync(new Uri(url2)).Result;
                string responseBody2 = response2.Content.ReadAsStringAsync().Result;
                var countries2 = JsonConvert.DeserializeObject(responseBody2);

                JArray jsonResponse2 = JArray.Parse(responseBody2);

                foreach (var item in jsonResponse2)
                {
                    Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                    _TopCauHoi.Add(rowsDoctor);

                }
                ViewBag.TopCauHoi = _TopCauHoi;


                List<Question> _DanhMucCauHoi = new List<Question>();

                HttpClient http1 = new HttpClient();
                string baseUrl1 = CMS_Core.Common.Common.getLINKAPI() + "api/Question/GetSpecialist/?token=" + Common.generalKeyPrivate(number) + "&number=" + number;


                string url1 = baseUrl1;
                HttpResponseMessage response1 = http1.GetAsync(new Uri(url1)).Result;
                string responseBody1 = response1.Content.ReadAsStringAsync().Result;
                var countries1 = JsonConvert.DeserializeObject(responseBody1);

                JArray jsonResponse1 = JArray.Parse(responseBody1);

                foreach (var item in jsonResponse1)
                {
                    Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                    _DanhMucCauHoi.Add(rowsDoctor);

                }
                ViewBag.DanhMucCauHoi = _DanhMucCauHoi;





                List<Question> _Tongcauhoi = new List<Question>();

                HttpClient http = new HttpClient();
                string baseUrl = CMS_Core.Common.Common.getLINKAPI() + "api/Question/GetSumQuestion/?token=" + Common.generalKeyPrivate(number) + "&number=" + number;

                string url = baseUrl;
                HttpResponseMessage response = http.GetAsync(new Uri(url)).Result;
                string responseBody = response.Content.ReadAsStringAsync().Result;
                var countries = JsonConvert.DeserializeObject(responseBody);

                JArray jsonResponse = JArray.Parse(responseBody);

                foreach (var item in jsonResponse)
                {
                    Question rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Question>(item.ToString());
                    _Tongcauhoi.Add(rowsDoctor);

                }
                ViewBag.Tongcauhoi = _Tongcauhoi;


                SQLServerConnection<Cms_News> sQLServer4 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer4.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;



                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {
                    if (form["txthoten"].ToString().Trim().Length > 50)
                    {
                        TempData["msg"] = "<script>alert('Họ tên không quá 50 ký tự');</script>";
                        return View();
                    }
                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtphone"].ToString().Trim()))
                {
                    if (form["txtphone"].ToString().Trim().Length != 10)
                    {
                        TempData["msg"] = "<script>alert('Điện thoại phải là 10 số');</script>";
                        return View();
                    }
                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập số điện thoại');</script>";
                    return View();

                }

                if (!string.IsNullOrEmpty(form["txttieude"].ToString().Trim()))
                {
                    if (form["txttieude"].ToString().Trim().Length > 120)
                    {
                        TempData["msg"] = "<script>alert('Tiêu đề không quá 120 ký tự');</script>";
                        return View();
                    }
                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn tiêu đề câu hỏi');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtcontent"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập nội dung câu hỏi');</script>";
                    return View();

                }

                //SqlConnection _conn;
                //_conn = new SqlConnection(ConfigurationManager.AppSettings["Icnm.ConnectionString"]);
                //_conn.Open();


                // Info.  
                //string sql = string.Empty;

                //sql =
                //  "insert into Question (FullName,Phone,Email,Address,QuestionTitle,QuestionContent,SpecialistID,DateCreate,Active,KeySearchTitle,TypeDevice,UserID) values(@hoten,@sdt,@email,@diachi,@tieude,@content,@danhmuc,GETDATE(),'1',@key,N'webMED','99306')";


                ////sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,email,Gioitinh,Namsinh,address,Ghichudv,PLDL) values(";
                ////sql += "@hoten,@sdt,@ngayhen,@ghichu,0,@email,@gioitinh,@namsinh,@diachi,N'WebMed - Đặt lịch OL Tại Nhà','TNOL')";


                //SqlCommand comd = new SqlCommand(sql, _conn);

                var gt = form["dllDM"];
                gt.ToString();

                //comd.Parameters.AddWithValue("@hoten", SqlDbType.NVarChar).Value = form["txthoten"].ToString();
                //comd.Parameters.AddWithValue("@sdt", SqlDbType.NVarChar).Value = form["txtphone"].ToString();
                //comd.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = form["txtemail"].ToString();
                //comd.Parameters.AddWithValue("@diachi", SqlDbType.NVarChar).Value = form["txtdiachi"].ToString();
                //comd.Parameters.AddWithValue("@tieude", SqlDbType.NVarChar).Value = form["txttieude"].ToString();
                //comd.Parameters.AddWithValue("@content", SqlDbType.NVarChar).Value = form["txtcontent"].ToString();

                //comd.Parameters.AddWithValue("@danhmuc", SqlDbType.Int).Value = int.Parse(gt.ToString());

                //comd.Parameters.AddWithValue("@key", SqlDbType.NVarChar).Value = RemoveUnicode13(form["txttieude"].ToString());




                //comd.ExecuteNonQuery();
                //_conn.Close();


                using (var client = new HttpClient())
                {
                    try
                    {
                        // Next two lines are not required. You can comment or delete that lines without any regrets

                        client.BaseAddress = new Uri(CMS_Core.Common.Common.getLINKAPI());

                        //                  var content = new FormUrlEncodedContent(new[]
                        //                  {
                        //  new KeyValuePair<string, string>("deadId", "3"),
                        //  new KeyValuePair<string, string>("flagValueToSet", "true")
                        //});

                        // response.Result.IsSuccessStatusCode == true and no errors

                        string hoten = form["txthoten"].ToString();
                        string sdt = form["txtphone"].ToString();
                        string email = form["txtemail"].ToString();
                        string diachi = form["txtdiachi"].ToString();
                        string tieude = form["txttieude"].ToString();
                        string content = form["txtcontent"].ToString();

                        string danhmuc = gt.ToString();

                        string keytieude = RemoveUnicode13(form["txttieude"].ToString());

                        MEDLATEC.BusinessLayer.Question obj = new MEDLATEC.BusinessLayer.Question();
                        obj.FullName = hoten;
                        obj.Phone = sdt;
                        obj.Email = email;
                        obj.Address = diachi;
                        obj.QuestionTitle = tieude;
                        obj.QuestionContent = content;
                        obj.KeySearchTitle = keytieude;
                        obj.SpecialistID = Convert.ToInt32(danhmuc);



                        object result = string.Empty;

                        string serialisedData = JsonConvert.SerializeObject(obj);


                        

                        string urlfull = $"{CMS_Core.Common.Common.getLINKAPI()}/api/Question/AddQuestion/?token=" + Common.generalKeyPrivate(number) + "&number=" + number;


                        HttpContent httpContent = new StringContent(serialisedData);
                        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                       
                        HttpResponseMessage message = client.PostAsync(urlfull, httpContent).Result;

                         


                      //  string link = $"{CMS_Core.Common.Common.getLINKAPI()}/api/Question/AddQuestion/?token=" + Common.generalKeyPrivate(hoten.Trim()) + "&hoten=" + hoten.Trim() + "&phone=" + sdt + "&email=" + email + "&diachi=" + diachi + "&tieude=" + tieude + "&content=" + content;

                        //  var response11 = client.PostAsync($"{CMS_Core.Common.Common.getLINKAPI()}/api/Question/AddQuestion/?token=" + Common.generalKeyPrivate(hoten.Trim()) + "&hoten=" + hoten.Trim() + "&phone=" + sdt + "&email=" + email + "&diachi=" + diachi + "&tieude=" + tieude + "&content=" + content, null);

                        // response.Result.IsSuccessStatusCode == false and 404 error
                        // var response = client.PostAsync($"{baseUri}/Deals/SetDealFlag", content); 
                        //response11.Wait();
                        //if (response11.Result.IsSuccessStatusCode)
                        //{

                        //}
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw;
                    }
                }



                string bodymail = "";
                bodymail =
                    "&nbsp;<i><span style='font-size: 13pt; font-family: 'Times New Roman', serif;'>K&iacute;nh gửi Qu&yacute; kh&aacute;ch,</span></i>";
                bodymail +=
                    "<p class='MsoNormal'><span style='font-size: 13pt; font-family: 'Times New Roman', serif;'>Bệnh viện Đa khoa MEDLATEC ch&uacute;c mừng Qu&yacute; kh&aacute;ch đ&atilde; gửi th&agrave;nh c&ocirc;ng c&acirc;u hỏi về hệ thống quản trị của ch&uacute;ng t&ocirc;i. </span><span lang='VI' style='font-size: 13pt; font-family: 'Times New Roman', serif;'>C&acirc;u hỏi Qu&yacute; kh&aacute;ch</span><span style='font-size: 13pt; font-family: 'Times New Roman', serif;'> gửi,</span><span lang='VI' style='font-size: 13pt; font-family: 'Times New Roman', serif;'> ch&uacute;ng t&ocirc;i </span><span style='font-size: 13pt; font-family: 'Times New Roman', serif;'>sẽ </span><span lang='VI' style='font-size: 13pt; font-family: 'Times New Roman', serif;'>chuyển tới c&aacute;c</span><span style='font-size: 13pt; font-family: 'Times New Roman', serif;'> gi&aacute;o sư,</span><span lang='VI' style='font-size: 13pt; font-family: 'Times New Roman', serif;'> thạc sỹ, b&aacute;c sỹ</span><span style='font-size: 13pt; font-family: 'Times New Roman', serif;'> v&agrave; </span><span lang='VI' style='font-size: 13pt; font-family: 'Times New Roman', serif;'>sẽ hồi </span><span style='font-size: 13pt; font-family: 'Times New Roman', serif;'>&acirc;m </span><span lang='VI' style='font-size: 13pt; font-family: 'Times New Roman', serif;'>lại </span><span style='font-size: 13pt; font-family: 'Times New Roman', serif;'>Qu&yacute; </span><span lang='VI' style='font-size: 13pt; font-family: 'Times New Roman', serif;'>kh&aacute;ch</span><span lang='VI' style='font-size: 13pt; font-family: 'Times New Roman', serif;'> </span><span lang='VI' style='font-size: 13pt; font-family: 'Times New Roman', serif;'>trong thời gian sớm nhất.</span><span style='font-size: 13pt; font-family: 'Times New Roman', serif;'><o:p></o:p></span></p>";
                bodymail +=
                    "<p class='MsoNormal'><span lang='VI' style='font-size: 13pt; font-family: 'Times New Roman', serif;'>Xin </span><span style='font-size: 13pt; font-family: 'Times New Roman', serif;'>Q</span><span lang='VI' style='font-size: 13pt; font-family: 'Times New Roman', serif;'>u&yacute; kh&aacute;ch lưu &yacute;, với những c&acirc;u </span><span style='font-size: 13pt; font-family: 'Times New Roman', serif;'>cần </span><span lang='VI' style='font-size: 13pt; font-family: 'Times New Roman', serif;'>trả lời gấp, Qu&yacute; kh&aacute;ch c&oacute; thể gọi điện trực tiếp tới tổng đ&agrave;i</span><span style='font-size: 13pt; font-family: 'Times New Roman', serif;'>: </span><b><span lang='VI' style='font-size: 13pt; font-family: 'Times New Roman', serif;'>1900 56 56 56</span></b><span lang='VI' style='font-size: 13pt; font-family: 'Times New Roman', serif;'> để nhận được sự hỗ trợ, tư vấn nhanh nhất từ </span><span style='font-size: 13pt; font-family: 'Times New Roman', serif;'>gi&aacute;o sư, </span><span lang='VI' style='font-size: 13pt; font-family: 'Times New Roman', serif;'>thạc sỹ, b&aacute;c sỹ chuy&ecirc;n khoa.</span><span style='font-size: 13pt; font-family: 'Times New Roman', serif;'><o:p></o:p></span></p>";
                bodymail +=
                    "<p class='MsoNormal'><span lang='VI' style='font-size: 13pt; font-family: 'Times New Roman', serif;'>Hoặc Qu&yacute; kh&aacute;ch c&oacute; thể tra cứu c&acirc;u </span><span style='font-size: 13pt; font-family: 'Times New Roman', serif;'>trả lời</span><span lang='VI' style='font-size: 13pt; font-family: 'Times New Roman', serif;'> nhanh với nội dung tương tự qua từ kh&oacute;a t&igrave;m kiếm </span><span style='font-size: 13pt; font-family: 'Times New Roman', serif;'>tại </span><span lang='VI' style='font-size: 13pt; font-family: 'Times New Roman', serif;'>mục </span><b><span style='font-size: 13pt; font-family: 'Times New Roman', serif;'>Tư vấn sức khỏe </span></b><b><span lang='VI' style='font-size: 13pt; font-family: 'Times New Roman', serif;'>online</span></b><span lang='VI' style='font-size: 13pt; font-family: 'Times New Roman', serif;'> tr&ecirc;n website <a href='http://medlatec.vn/' target='_blank'><span style='color:black'>medlatec.vn</span></a></span><span style='font-size: 13pt; font-family: 'Times New Roman', serif;'><o:p></o:p></span></p>";
                bodymail +=
                    "<p class='MsoNormal'><span style='font-size: 13pt; font-family: 'Times New Roman', serif;'>Ch&uacute;c Qu&yacute; kh&aacute;ch một ng&agrave;y tốt l&agrave;nh. <o:p></o:p></span></p><p class='MsoNormal' align='left' style='margin-top: 0in;'><span style='font-size:13.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;'>Tr&acirc;n trọng,<o:p></o:p></span></p><p class='MsoNormal' align='left' style='margin-top: 0in;'><b><span style='font-size:13.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;'>Bệnh viện Đa khoa MEDLATEC<o:p></o:p></span></b></p><p class='MsoNormal' align='left' style='margin-top: 0in;'><b><span style='font-size:13.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;'>&nbsp;</span></b></p>";
                bodymail +=
                    "<table class='MsoNormalTable' border='1' cellspacing='0' cellpadding='0' style='background:#DAEEF3;border-collapse:collapse;border:none;mso-border-alt:solid windowtext .5pt;mso-yfti-tbllook:1184;mso-padding-alt:0in 5.4pt 0in 5.4pt;mso-border-insideh:.5pt solid windowtext;mso-border-insidev:.5pt solid windowtext'><tbody><tr>";
                bodymail +=
                    "<td width='616' valign='top' style='width:462.25pt;border:solid windowtext 1.0pt;mso-border-alt:solid windowtext .5pt;padding:0in 5.4pt 0in 5.4pt'><p class='MsoNormal'><b><span style='font-size:13.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;'>Bệnh viện Đa   khoa MEDLATEC hiện cung c&aacute;c dịch vụ:<o:p></o:p></span></b></p><p class='MsoNormal' style='margin-left:.5in;text-indent:-.25in;mso-list:l0 level1 lfo1'><!--[if !supportLists]--><span style='font-size:13.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;'>1.<span style='font-size: 7pt; font-family: 'Times New Roman';'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   </span></span><!--[endif]--><span style='font-size:13.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;'>Lấy mẫu x&eacute;t nghiệm tận nơi, trả kết quả x&eacute;t qua:   Website, Fax, Email, đường bưu điện v&agrave; trực tiếp.<o:p></o:p></span></p>";
                bodymail +=
                    "<p class='MsoNormal' style='margin-left:.5in;text-indent:-.25in;mso-list:l0 level1 lfo1'><!--[if !supportLists]--><span style='font-size:13.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;'>2.<span style='font-size: 7pt; font-family: 'Times New Roman';'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   </span></span><!--[endif]--><span style='font-size:13.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;'>Kh&aacute;m c&aacute;c chuy&ecirc;n khoa Nội, Ngoại, Sản, Nhi, Chuy&ecirc;n   khoa lẻ (Tai-Mũi-Họng, Răng-H&agrave;m-Mắt, Mắt).<o:p></o:p></span></p><p class='MsoNormal' style='margin-left:.5in;text-indent:-.25in;mso-list:l0 level1 lfo1'><!--[if !supportLists]--><span style='font-size:13.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;'>3.<span style='font-size: 7pt; font-family: 'Times New Roman';'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   </span></span><!--[endif]--><span style='font-size:13.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;'>Kiểm tra sức khỏe định kỳ cho c&aacute; nh&acirc;n v&agrave; tập thể.<o:p></o:p></span></p>";
                bodymail +=
                    "<p class='MsoNormal' style='margin-left:.5in;text-indent:-.25in;mso-list:l0 level1 lfo1'><!--[if !supportLists]--><span style='font-size:13.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;'>4.<span style='font-size: 7pt; font-family: 'Times New Roman';'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   </span></span><!--[endif]--><span style='font-size:13.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;'>X&eacute;t nghiệm: Huyết học, H&oacute;a sinh - Miễn dịch (c&aacute;c   loại hormone, c&aacute;c loại marker ung thư,&hellip;), Giải phẫu bệnh (m&ocirc; mềm, m&ocirc; xương, tế   b&agrave;o &acirc;m đạo, tế b&agrave;o học,&hellip;), Sinh học ph&acirc;n tử (HBV, HCB, HPV, lậu,   chlamydia,&hellip;).<o:p></o:p></span></p>            <p class='MsoNormal' style='margin-left:.5in;text-indent:-.25in;mso-list:l0 level1 lfo1'><!--[if !supportLists]--><span style='font-size:13.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;'>5.<span style='font-size: 7pt; font-family: 'Times New Roman';'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   </span></span><!--[endif]--><span style='font-size:13.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;'>Chẩn đo&aacute;n h&igrave;nh ảnh - Thăm d&ograve; chức năng: Chụp CT,   si&ecirc;u &acirc;m 3D, 4D, chụp X quang kỹ thuật số, nội soi dạ d&agrave;y,&hellip;<o:p></o:p></span></p>";
                bodymail +=
                    "<p class='MsoNormal'><span style='font-size:13.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;'>Bệnh   viện l&agrave;m việc 24 giờ/7 ng&agrave;y&nbsp; *&nbsp; Tổng đ&agrave;i li&ecirc;n hệ v&agrave; tư vấn: 1900 56 56 56</span><span style='font-size: 13pt;'><o:p></o:p></span></p><p class='MsoNormal' align='left' style='margin-top: 0in;'><b><span style='font-size:13.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;'>&nbsp;</span></b></p></td></tr></tbody></table>";
                bodymail +=
                    "<p class='MsoNormal' align='left' style='margin-top: 0in;'><b><span style='font-size:13.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;'>&nbsp;</span></b></p><table class='MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='654' style='width:490.5pt;margin-left:-.3in;border-collapse:collapse;mso-yfti-tbllook:1184;mso-padding-alt:0in 5.4pt 0in 5.4pt'><tbody><tr><td width='312' valign='top' style='width:3.25in;background:#92CDDC;padding:0in 5.4pt 0in 5.4pt'><p class='MsoNormal'><b><span style='font-size:13.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;'>BỆNH VIỆN ĐA   KHOA MEDLATEC<o:p></o:p></span></b></p></td><td width='342' valign='top' style='width:256.5pt;background:#92CDDC;padding:0in 5.4pt 0in 5.4pt'><p class='MsoNormal'><b><span style='font-size:13.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;'>CHI NH&Aacute;NH TP.   HỒ CH&Iacute; MINH<o:p></o:p></span></b></p>";
                bodymail +=
                    "</td></tr><tr><td width='312' valign='top' style='width:3.25in;padding:0in 5.4pt 0in 5.4pt'><p class='MsoNormal'><span style='font-size:13.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;'>42   Nghĩa Dũng, Ba Đ&igrave;nh, H&agrave; Nội<o:p></o:p></span></p><p class='MsoNormal'><span style='font-size:13.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;'>ĐT:   1900 56 56 56 * Fax: (04)3715 0366<o:p></o:p></span></p></td><td width='342' valign='top' style='width:256.5pt;padding:0in 5.4pt 0in 5.4pt'><p class='MsoNormal'><span style='font-size:13.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;'>323   V&otilde; Th&agrave;nh Trang, P.11, Q. T&acirc;n B&igrave;nh<o:p></o:p></span></p><p class='MsoNormal'><span style='font-size:13.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;'>ĐT:   (08) 38 657 574 * Fax: (08) 38 657 574<o:p></o:p></span></p></td></tr></tbody></table>";
                sendGmail("Chúc mừng Quý khách đã tham gia hỏi thành công trên website medlatec.vn", form["txtemail"].ToString(), bodymail);


                Response.Redirect("/thankyou", false);
                //  TempData["msg"] = "<script>alert('Quý khách đã đặt câu hỏi thành công trên website.Liên hệ 1900565656 khi cần hỗ trợ. Rất hân hạnh được phục vụ!');</script>";
                // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                // TempData["msg"] = "<script>alert('Cam on Quy khach da dang ky DV Kham tai nha. Chung toi se lien lac voi Quy khach de xac nhan lich hen. LH 1900565656 khi can ho tro. Rat han hanh duoc phuc vu!    ');</script>";
            }
            catch (Exception ex)
            {

            }




            return View();
        }

        public class person
        {
            public string name { get; set; }
            public string surname { get; set; }
        }
        public class StudentViewModel
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }


        }
        [HttpPost]

        public ActionResult EditCauhoi(string submit, FormCollection form)
        {
            try
            {
                //63fucWlQi185SSy+pUpEtBfapPs+JHV+RX7ieJ7rlSs=
                if (submit != null)
                {
                    if (submit == "SaveAdd")
                    {

                        string id = form["txttimkiem"].ToString();
                        SQLServerConnection<Question> sQLServer = new SQLServerConnection<Question>();
                        List<Question> _Cauhoi = sQLServer.SelectQueryCommand("Question_GetTheoID", Common.getConnectionStringIcnm(), int.Parse(id));

                        if (_Cauhoi.Count > 0)
                        {
                            Response.Redirect("/Question/UpdateCauhoi?id=" + id.ToString(), false);

                        }
                        else
                        {
                            TempData["msg"] = "<script>alert('Thông tin khách hàng không đúng! vui lòng đăng nhập lại.');</script>";
                        }
                    }
                    if (submit == "Update")
                    {
                        string id = form["txttimkiem"].ToString();
                        SQLServerConnection<Question> sQLServer = new SQLServerConnection<Question>();
                        List<Question> _Cauhoi = sQLServer.SelectQueryCommand("Question_GetTheoID", Common.getConnectionStringIcnm(), int.Parse(id));
                        ViewBag.CauHoi = _Cauhoi;
                        if (_Cauhoi.Count > 0)
                        {
                            //SqlConnection _conn;
                            //_conn = new SqlConnection(ConfigurationManager.AppSettings["PMBV.ConnectionString"]);
                            //_conn.Open();
                            //// Info.  
                            //string sql = string.Empty;
                            //sql = "update DMBS set PassWeb = @mk where MaBS =@doctorid";

                            //SqlCommand comd = new SqlCommand(sql, _conn);
                            //comd.Parameters.AddWithValue("@mk", SqlDbType.NVarChar).Value = matkhaumoi;
                            //comd.Parameters.AddWithValue("@doctorid", SqlDbType.NVarChar).Value = mabs;
                            //comd.ExecuteNonQuery();
                            //_conn.Close();
                            //Response.Redirect("/thankyou", false);

                        }
                        else
                        {
                            TempData["msg"] = "<script>alert('Thông tin khách hàng không đúng! vui lòng đăng nhập lại.');</script>";
                        }


                    }
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        [HttpPost]

        public ActionResult UpdateCauhoi(string submit, FormCollection form)
        {
            try
            {
                string abc = "";
                //63fucWlQi185SSy+pUpEtBfapPs+JHV+RX7ieJ7rlSs=
                if (submit != null)
                {

                    if (submit == "SaveAdd")
                    {

                        string id1 = form["hidden1"].ToString();
                        SQLServerConnection<Question> sQLServer = new SQLServerConnection<Question>();
                        List<Question> _Cauhoi = sQLServer.SelectQueryCommand("Question_GetTheoID", Common.getConnectionStringIcnm(), int.Parse(id1));

                        if (_Cauhoi.Count > 0)
                        {
                            ViewBag.CauHoi = _Cauhoi;
                            SqlConnection _conn;
                            _conn = new SqlConnection(ConfigurationManager.AppSettings["Icnm.ConnectionString"]);
                            _conn.Open();
                            // Info.  
                            string sql = string.Empty;
                            sql = "update Question set QuestionTitle = @title,QuestionContent =@content  where QuestionID = @QuestionID";

                            SqlCommand comd = new SqlCommand(sql, _conn);
                            comd.Parameters.AddWithValue("@title", SqlDbType.NVarChar).Value = form["txttieude"].ToString();
                            comd.Parameters.AddWithValue("@content", SqlDbType.NVarChar).Value = form["txtnoidung"].ToString();
                            comd.Parameters.AddWithValue("@QuestionID", SqlDbType.BigInt).Value = _Cauhoi[0].QuestionID;

                            comd.ExecuteNonQuery();
                            _conn.Close();

                            Response.Redirect("https://medlatec.vn/thankyou", false);

                        }
                        else
                        {
                            TempData["msg"] = "<script>alert('Thông tin khách hàng không đúng! vui lòng đăng nhập lại.');</script>";
                        }


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