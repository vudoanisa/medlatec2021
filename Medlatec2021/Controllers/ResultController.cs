using CMS_Core.Common;
using MEDLATEC.BusinessLayer;
using MEDLATEC2019.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.Web.Mvc;

namespace MEDLATEC2019.Controllers
{
    public class ResultController : Controller
    {
        private SQLServerConnection<tbl_TestCode> sQLServerTestcode;

        public ResultController()
        {
            sQLServerTestcode = new SQLServerConnection<tbl_TestCode>();
             
        }




        // GET: Result
        public ActionResult Home()
        {
            SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _News = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.News = _News;
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Link404()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Thankyou()
        {
            return View();
        }

        public ActionResult Finish()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sid"></param>
        /// <param name="place"></param>
        /// <param name="LA"></param>
        /// <param name="token"></param>
        /// <param name="print"></param>
        /// <returns></returns>
        public ActionResult PrintKQ(string sid, string place, string LA, string token, string print)
        {
            try
            {
                if (string.IsNullOrEmpty(token))
                {
                    token = string.Empty;
                }
                if (string.IsNullOrEmpty(sid))
                {
                    sid = string.Empty;
                }
                if (string.IsNullOrEmpty(place))
                {
                    place = "HN";
                }

                sid = sid.Replace(" ", "+");
                sid = AES.Decrypt(sid, "");
                sid = sid.Replace("\u000f", "").Trim();
                sid = sid.Replace("\u000e", "").Trim();
                sid = sid.Replace("\u0010", "").Trim();
                string ip = Request.UserHostAddress;
                if (string.IsNullOrEmpty(ip))
                {
                    ip = string.Empty;
                }

                string tokenkey = "m$dl4tec";
                string url = string.Empty;
                tokenkey = SaltedHash.GetSHA512(tokenkey + sid.Trim());



                if (tokenkey.Equals(token))
                {


                    List<Cms_Patient> _Thongtin = null;

                    if (sid.Length > 0)
                    {
                        if ("HN".Equals(place.Trim()))
                        {
                            if (Session["thongtinHN" + sid] != null)
                            {
                                _Thongtin = (List<Cms_Patient>)Session["thongtinHN" + sid];
                            }
                            else
                            {
                                CMS_Core.Common.Common.AddToLogFile(DateTime.Now.ToString("ddMMyyyyHHmm") + " PrintKQ:" + sid + " ip:" + ip);

                                url = "api/Result/GetPatientBySID?username=" + sid + "&token=" + Common.generalKeyPrivate(sid);
                                var result = ImpCallAPI<Cms_Patient>.geContentAPI(url);
                                if (result != null)
                                {
                                    _Thongtin = result;
                                    Session["thongtinHN" + sid] = _Thongtin;
                                }
                                else
                                {
                                    Session["thongtinHN" + sid] = null;
                                }


                            }
                        }
                        else
                        {
                            if (Session["thongtinSG" + sid] != null)
                            {
                                _Thongtin = (List<Cms_Patient>)Session["thongtinSG" + sid];
                            }
                            else
                            {
                                CMS_Core.Common.Common.AddToLogFile(DateTime.Now.ToString("ddMMyyyyHHmm") + " PrintKQ:" + sid + " ip:" + ip);

                                url = "api/Result/GetPatientBySIDSG?username=" + sid + "&token=" + Common.generalKeyPrivate(sid);
                                var result = ImpCallAPI<Cms_Patient>.geContentAPI(url);
                                if (result != null)
                                {
                                    _Thongtin = result;
                                    Session["thongtinSG" + sid] = _Thongtin;
                                }
                                else
                                {
                                    Session["thongtinSG" + sid] = null;
                                }


                            }
                        }


                        ViewBag.Thongtin = _Thongtin;

                        url = "api/Result/ResultBySID?sid=" + sid + "&token=" + Common.generalKeyPrivate(sid);
                        List<Cms_Result> _Ketqua = ImpCallAPI<Cms_Result>.geContentAPI(url);
                        ViewBag.Ketqua = _Ketqua;

                       // return View();

                        string footer = "--footer-right \" [page]\" --footer-line --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"calibri light\"";
                        return new Rotativa.MVC.PartialViewAsPdf()
                        {
                            RotativaOptions = new Rotativa.Core.DriverOptions()
                            {
                                // PageMargins = { Left = 20, Bottom = 20, Right = 20, Top = 20 },

                                IsLowQuality = false,
                                PageOrientation = Rotativa.Core.Options.Orientation.Portrait,
                                PageSize = Rotativa.Core.Options.Size.A4,
                                CustomSwitches = footer,
                                // CustomSwitches = "--disable-smart-shrinking"

                            },

                        };
                    }
                    else
                    {
                        TempData["msg"] = "<script>alert('Thông tin khách hàng không đúng! vui lòng đăng nhập lại.');</script>";
                    }
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="P"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public ActionResult PID_Lichsukham(string P, string token)
        {
            try
            {
                string tokenkey = "m$dl4tec";

                if (string.IsNullOrEmpty(P))
                {
                    P = string.Empty;
                }
                P = P.Replace(" ", "+");
                P = AES.Decrypt(P, "");
                P = P.Replace("\u000f", "").Trim();
                P = P.Replace("\u000e", "").Trim();

                P = P.Replace("\u0010", "").Trim();

                if (string.IsNullOrEmpty(token + P.Trim()))
                {
                    token = string.Empty;
                }
                tokenkey = SaltedHash.GetSHA512(tokenkey + P.Trim());

                if (tokenkey.Equals(token))
                {
                    string ip = Request.UserHostAddress;
                    if (string.IsNullOrEmpty(ip))
                    {
                        ip = string.Empty;
                    }


                    List<Cms_Patient> _Thongtin = null;
                    if (Session["thongtinLichsukham" + P] != null)
                    {
                        _Thongtin = (List<Cms_Patient>)Session["thongtinLichsukham" + P];
                    }
                    else
                    {
                        CMS_Core.Common.Common.AddToLogFile(DateTime.Now.ToString("ddMMyyyyHHmm") + " PID_Lichsukham:" + P + " ip:" + ip);

                        string url = "api/Result/GetPatientByPIDNew?PID=" + P + "&token=" + Common.generalKeyPrivate(P);
                        _Thongtin = ImpCallAPI<Cms_Patient>.geContentAPI(url);
                        Session["thongtinLichsukham" + P] = _Thongtin;
                    }

                    ViewBag.Thongtin = _Thongtin;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="P"></param>
        /// <param name="token"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult PID_Thongtin(string P, string token, FormCollection form)
        {
            try
            {
                string tokenkey = "m$dl4tec";
                if (string.IsNullOrEmpty(token))
                {
                    token = string.Empty;
                }
                if (string.IsNullOrEmpty(P))
                {
                    P = string.Empty;
                }
                P = P.Replace(" ", "+");
                P = AES.Decrypt(P, "");
                P = P.Replace("\u000f", "").Trim();
                P = P.Replace("\u000e", "").Trim();

                P = P.Replace("\u0010", "").Trim();


                tokenkey = SaltedHash.GetSHA512(tokenkey + P.Trim());
                if (tokenkey.Equals(token))
                {
                    string url = "api/Result/GetInfomationByPID?p=" + P + "&token=" + Common.generalKeyPrivate(P);
                    var result = ImpCallAPI<Cms_Patient>.geContentAPI(url);
                    if (result != null)
                    {
                        CMS_Core.Common.Common.AddToLogFile(DateTime.Now.ToString("ddMMyyyyHHmmss") + " PID_Lichsukham_:" + P);
                        ViewBag.Thongtin = result;
                    }
                    else
                    {
                        TempData["msg"] = "<script>alert('Thông tin khách hàng không đúng! vui lòng đăng nhập lại.');</script>";
                    }
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="U"></param>
        /// <param name="token"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult DoiMKGM(string U, string token, FormCollection form)
        {
            try
            {
                if (string.IsNullOrEmpty(U))
                {
                    U = string.Empty;
                }

                U = U.Replace(" ", "+");
                U = AES.Decrypt(U, "");
                U = U.Replace("\u000f", "").Trim();

                string tokenkey = "m$dl4tec";
                tokenkey = SaltedHash.GetSHA512(tokenkey + U.Trim());
                if (string.IsNullOrEmpty(token))
                {
                    token = string.Empty;
                }

                if (tokenkey.Equals(token))
                {

                    string url = "api/Result/GetInfomationByPID?p=" + U + "&token=" + Common.generalKeyPrivate(U);
                    var result = ImpCallAPI<Cms_Patient>.geContentAPI(url);
                    if (result != null)
                    {
                        ViewBag.Thongtin = result;
                    }
                    else
                    {
                        TempData["msg"] = "<script>alert('Thông tin khách hàng không đúng! vui lòng đăng nhập lại.');</script>";
                    }

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="submit"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoiMKGM(string submit, FormCollection form)
        {
            try
            {
                //63fucWlQi185SSy+pUpEtBfapPs+JHV+RX7ieJ7rlSs=
                if (submit != null)
                {
                    if (submit == "SaveAdd")
                    {
                        string mabs = form["txtmabs"].ToString();
                        string matkhau = form["txtMkcu"].ToString();
                        string matkhaumoi = form["txtmkmoi1"].ToString();
                        string matkhaumoi2 = form["txtmkmoi2"].ToString();
                        if (matkhaumoi.Length < 1)
                        {
                            Response.Redirect(@CMS_Core.Common.Common.GetLinkDoiMKDVGM(mabs));
                        }
                        if (matkhaumoi2.Length < 1)
                        {
                            Response.Redirect(@CMS_Core.Common.Common.GetLinkDoiMKDVGM(mabs));
                        }
                        if (matkhaumoi.Equals(matkhaumoi2))
                        {
                            //TempData["msg"] = "<script>alert('Mật khẩu mới không giống nhau');</script>";
                            Response.Redirect(@CMS_Core.Common.Common.GetLinkDoiMKDVGM(mabs));
                            //  return View();
                        }

                        string url = "api/Result/ChangePassUnit?username=" + mabs + "&newPassword=" + matkhaumoi.Trim() + "&oldPassword=" + matkhau.Trim() + "&token=" + Common.generalKeyPrivate(mabs);
                        var _Thongtin = ImpCallAPI<Cms_Patient>.geContentAPIRespon(url);

                        if (_Thongtin == true)
                        {
                            Response.Redirect("/thankyou", false);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sid"></param>
        /// <param name="place"></param>
        /// <param name="LA"></param>
        /// <param name="token"></param>
        /// <param name="print"></param>
        /// <returns></returns>
        public ActionResult KQSID(string sid, string place, string LA, string token, string print)
        {
            try
            {
                Session.Timeout = 1;
                string tokenkey = "m$dl4tec";
                string url = string.Empty;
                if (string.IsNullOrEmpty(token))
                {
                    token = string.Empty;
                }
                if (string.IsNullOrEmpty(sid))
                {
                    sid = string.Empty;
                }
                sid = sid.Replace(" ", "+");
                sid = AES.Decrypt(sid, "");
                sid = sid.Replace("\u000f", "").Trim();
                sid = sid.Replace("\u000e", "").Trim();
                sid = sid.Replace("\u0010", "").Trim();

                tokenkey = SaltedHash.GetSHA512(tokenkey + sid.Trim());
                ViewBag.Token = tokenkey;
                ViewBag.SID = AES.EncryptString(sid.Trim(), "").Trim(); //sid;
                if (tokenkey.Equals(token)) //Kiểm tra token đúng thì tiếp tục thực hiện tác vụ tiếp theo
                {


                    List<tbl_TestCode> TestCodes = sQLServerTestcode.SelectQueryCommand("tbl_TestCode_SelectValid", Common.getConnectionString() );
                    ViewBag.TestCodes = TestCodes;

                    string ip = Request.UserHostAddress;
                    if (string.IsNullOrEmpty(ip))
                    {
                        ip = string.Empty;
                    }


                    if (place == "HN")
                    {
                        CMS_Core.Common.Common.AddToLogFile("start:" + DateTime.Now.ToString("ddMMyyyyHHmm") + " KQSID:" + sid );


                        Session[sid] = "HN-" + sid + DateTime.Now.ToString("-dd_MM_yyyy_HH_mm");
                        if (Session[sid] != null)
                        {
                            if (Session["thongtinHN" + sid] == null) //Nếu chưa có session lưu kết quả tra cứu
                            {                              
                                url = "api/Result/GetPatientBySID?username=" + sid + "&token=" + Common.generalKeyPrivate(sid);
                                var result = ImpCallAPI<Cms_Patient>.geContentAPI(url);
                                ViewBag.Thongtin = result;
                                Session["thongtinHN" + sid] = result; //Lưu session thông tin khách hàng                               
                            }
                            else //Nếu đã tồn tại Session -> Lấy kết quả từ session
                            {
                                ViewBag.ThongTin = (List<Cms_Patient>)Session["thongtinHN" + sid];
                            }


                            if (Session["ketqua" + sid] == null) //Nếu chưa có session lưu kết quả tra cứu
                            {

                                url = "api/Result/ResultBySID?sid=" + sid + "&token=" + Common.generalKeyPrivate(sid);
                                List<Cms_Result> _Ketqua = ImpCallAPI<Cms_Result>.geContentAPI(url);
                              
                                ViewBag.Ketqua = _Ketqua;
                                Session["ketqua" + sid] = _Ketqua; //Lưu session thông tin kết quả khám bệnh

                            }
                            else
                            {
                                ViewBag.Ketqua = (List<Cms_Result>)Session["ketqua" + sid];
                            }



                        }
                        CMS_Core.Common.Common.AddToLogFile("end:" + DateTime.Now.ToString("ddMMyyyyHHmm") + " KQSID:" + sid);

                    }
                    else
                    {
                        Session[sid] = "SG-" + sid + DateTime.Now.ToString("-dd_MM_yyyy_HH_mm");
                        if (Session[sid] != null)
                        {
                            if (Session["thongtinSG" + sid] == null) //Nếu chưa có session lưu kết quả tra cứu
                            {

                                url = "api/Result/GetPatientBySIDSG?username=" + sid + "&token=" + Common.generalKeyPrivate(sid);
                                var result = ImpCallAPI<Cms_Patient>.geContentAPI(url);
                                if (result != null)
                                {
                                    ViewBag.Thongtin = result;
                                    Session["thongtinSG" + sid] = result;
                                }
                                else
                                {
                                    Session["thongtinSG" + sid] = null;
                                }

                               
                            }
                            else
                            {
                                ViewBag.ThongTin = (List<Cms_Patient>)Session["thongtinSG" + sid];

                            }

                            if (Session["ketqua" + sid] == null) //Nếu chưa có session lưu kết quả tra cứu
                            {
                                url = "api/Result/ResultBySID?sid=" + sid + "&token=" + Common.generalKeyPrivate(sid);
                                List<Cms_Result> _Ketqua = ImpCallAPI<Cms_Result>.geContentAPI(url);

                                ViewBag.Ketqua = _Ketqua;
                                Session["ketqua" + sid] = _Ketqua;

                            }
                            else
                            {
                                ViewBag.Ketqua = (List<Cms_Result>)Session["ketqua" + sid];
                            }


                        }
                    }
                }
                else
                {
                    TempData["msg"] = "<script>alert('Thông tin khách hàng không đúng! vui lòng đăng nhập lại.');</script>";
                }
            }
            catch (Exception ex)
            {

            }

            CMS_Core.Common.Common.AddToLogFile("finish:" + DateTime.Now.ToString("ddMMyyyyHHmm") + " KQSID:" + sid);

            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sid"></param>
        /// <param name="place"></param>
        /// <param name="LA"></param>
        /// <param name="token"></param>
        /// <param name="print"></param>
        /// <returns></returns>
        public ActionResult KQSIDEN(string sid, string place, string LA, string token, string print)
        {
            try
            {




                string tokenkey = "m$dl4tec";

                if (string.IsNullOrEmpty(sid))
                {
                    sid = string.Empty;
                }
                ViewBag.SID = sid;
                sid = sid.Replace(" ", "+");
                sid = AES.Decrypt(sid, "");
                sid = sid.Replace("\u000f", "").Trim();
                sid = sid.Replace("\u000e", "").Trim();
                sid = sid.Replace("\u0010", "").Trim();
                string url = string.Empty;
                if (string.IsNullOrEmpty(token))
                {
                    token = string.Empty;
                }

                tokenkey = SaltedHash.GetSHA512(tokenkey + sid.Trim());
                ViewBag.Token = tokenkey;

                if (tokenkey.Equals(token)) //Kiểm tra token đúng thì tiếp tục thực hiện tác vụ tiếp theo
                {

                    string ip = Request.UserHostAddress;
                    if (string.IsNullOrEmpty(ip))
                    {
                        ip = string.Empty;
                    }



                    if (place == "HN")
                    {
                        Session[sid] = "HN-EN-" + sid + DateTime.Now.ToString("-dd_MM_yyyy_HH_mm");
                        if (Session[sid] != null)
                        {
                            if (Session["thongtinHN" + sid] == null || Session["ketqua" + sid] == null) //Nếu chưa có session lưu kết quả tra cứu
                            {
                                CMS_Core.Common.Common.AddToLogFile(DateTime.Now.ToString("ddMMyyyyHHmm") + " KQSIDEN:" + sid + " ip:" + ip);

                                url = "api/Result/GetPatientBySID?username=" + sid + "&token=" + Common.generalKeyPrivate(sid);
                                var result = ImpCallAPI<Cms_Patient>.geContentAPI(url);

                                ViewBag.Thongtin = result;
                                Session["thongtinHN" + sid] = result; //Lưu session thông tin khách hàng    

                                url = "api/Result/ResultBySID?sid=" + sid + "&token=" + Common.generalKeyPrivate(sid);
                                List<Cms_Result> _Ketqua = ImpCallAPI<Cms_Result>.geContentAPI(url);

                                ViewBag.Ketqua = _Ketqua;
                                Session["ketqua" + sid] = _Ketqua;


                            }
                            else //Nếu đã tồn tại Session -> Lấy kết quả từ session
                            {
                                ViewBag.ThongTin = (List<Cms_Patient>)Session["thongtin" + sid];
                                ViewBag.Ketqua = (List<Cms_Result>)Session["ketqua" + sid];
                            }
                        }
                    }
                    else
                    {
                        Session[sid] = "SG-EN-" + sid + DateTime.Now.ToString("-dd_MM_yyyy_HH_mm");
                        if (Session["thongtinSG" + sid] == null || Session["ketqua" + sid] == null) //Nếu chưa có session lưu kết quả tra cứu
                        {
                            CMS_Core.Common.Common.AddToLogFile(DateTime.Now.ToString("ddMMyyyyHHmm") + " KQSIDEN:" + sid + " ip:" + ip);

                            url = "api/Result/GetPatientBySIDSG?username=" + sid + "&token=" + Common.generalKeyPrivate(sid);
                            var result = ImpCallAPI<Cms_Patient>.geContentAPI(url);
                            if (result != null)
                            {
                                ViewBag.Thongtin = result;
                                Session["thongtinSG" + sid] = result;
                            }
                            else
                            {
                                Session["thongtinSG" + sid] = null;
                            }





                            url = "api/Result/ResultBySID?sid=" + sid + "&token=" + Common.generalKeyPrivate(sid);
                            List<Cms_Result> _Ketqua = ImpCallAPI<Cms_Result>.geContentAPI(url);

                            ViewBag.Ketqua = _Ketqua;
                            Session["ketqua" + sid] = _Ketqua;


                        }
                        else //Nếu đã tồn tại Session -> Lấy kết quả từ session
                        {
                            ViewBag.ThongTin = (List<Cms_Patient>)Session["thongtin" + sid];
                            ViewBag.Ketqua = (List<Cms_Result>)Session["ketqua" + sid];
                        }

                    }
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="U"></param>
        /// <param name="place"></param>
        /// <param name="token"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult KQDVGM(string U, string place, string token, FormCollection form)
        {
            try
            {
                string tokenkey = "m$dl4tec";

                if (string.IsNullOrEmpty(token))
                {
                    token = string.Empty;
                }
                if (string.IsNullOrEmpty(U))
                {
                    U = string.Empty;
                }
                U = U.Replace(" ", "+");
                U = AES.Decrypt(U, "");
                U = U.Replace("\u000f", "").Trim();
                U = U.Replace("\u000e", "").Trim();
                U = U.Replace("\u0010", "").Trim();
                tokenkey = SaltedHash.GetSHA512(tokenkey + U.Trim());


                if (tokenkey.Equals(token))
                {


                    List<Cms_Patient> _Thongtin = null;
                    if (Session["thongtinDVGM" + U] != null)
                    {
                        _Thongtin = (List<Cms_Patient>)Session["thongtinDVGM" + U];
                        ViewBag.Thongtin = _Thongtin;
                    }
                    else
                    {
                        string ip = Request.UserHostAddress;
                        if (string.IsNullOrEmpty(ip))
                        {
                            ip = string.Empty;
                        }
                        CMS_Core.Common.Common.AddToLogFile(DateTime.Now.ToString("ddMMyyyyHHmm") + " KQDVGM:" + U + " ip:" + ip);

                       // string url = "api/Result/GetCheckByDoctor?DoctorID=" + U.Trim() + "&ngay=" + DateTime.Now.ToString("yyyyMM") + "&PatientName=" + string.Empty + "&token=" + Common.generalKeyPrivate(U.Trim());


                        string url = "api/Result/GetPatientByUnitNoPass?username=" + U.Trim() + "&token=" + Common.generalKeyPrivate(U.Trim());
                        var result = ImpCallAPI<Cms_Patient>.geContentAPI(url);
                        if (result != null)
                        {
                            ViewBag.Thongtin = result;
                            Session["thongtinDVGM" + U] = result;
                        }
                        else
                        {
                            Session["thongtinDVGM" + form["txtusersid"].ToString()] = null;
                        }

                    }

                    // ViewBag.Thongtin = _Thongtin;

                    ViewBag.check = DateTime.Now.Month.ToString();

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="submit"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KQDVGM(string submit, FormCollection form)
        {
            try
            {
                //63fucWlQi185SSy+pUpEtBfapPs+JHV+RX7ieJ7rlSs=
                if (submit != null)
                {
                    if (submit == "Tracuu")
                    {
                        string abc = form["txtU"];
                        string name = form["txthoten"];
                        if (name.Length > 40)
                        {
                            return View();
                        }
                        string ngay = form["dllNgay"].ToString();
                        string url = "api/Result/GetCheckByDoctor?DoctorID=" + abc.Trim() + "&ngay=" + ngay + "&PatientName=" + name + "&token=" + Common.generalKeyPrivate(abc.Trim());
                        var result = ImpCallAPI<Cms_Patient>.geContentAPI(url);
                        if (result != null)
                        {
                            ViewBag.Thongtin = result;
                        }

                        ViewBag.check = ngay;

                    }
                    if (submit == "Phanhoi")
                    {
                        string abc = form["txtU"];

                        sendGmail("Mã bác sỹ : " + abc + ".Ngày:" + DateTime.Now.ToString("dd/MM/yyyy"), form["txtphanhoi"].ToString());

                        Response.Redirect("/thankyou", false);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="form"></param>
        ///// <param name="logged"></param>
        //private void CreateLogs_Doctor(FormCollection form, bool logged)
        //{
        //    SQLServerConnection<Cms_Patient> sQLServer1 = new SQLServerConnection<Cms_Patient>();

        //    SqlParameter[] spParameter = new SqlParameter[4];

        //    spParameter[0] = new SqlParameter("@Username", SqlDbType.NVarChar, 50);
        //    spParameter[0].Direction = ParameterDirection.Input;
        //    spParameter[0].Value = form["txtusersid"];

        //    spParameter[1] = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
        //    spParameter[1].Direction = ParameterDirection.Input;
        //    spParameter[1].Value = form["txtmkuser"];

        //    spParameter[2] = new SqlParameter("@LoginTime", SqlDbType.DateTime);
        //    spParameter[2].Direction = ParameterDirection.Input;
        //    spParameter[2].Value = DateTime.Now;


        //    spParameter[3] = new SqlParameter("@IsLogged", SqlDbType.Bit);
        //    spParameter[3].Direction = ParameterDirection.Input;
        //    spParameter[3].Value = logged;

        //    int v = SQLHelper.SqlHelper.ExecuteNonQuery(Common.getConnectionString(), CommandType.StoredProcedure, "SP_CreateLogs_Doctor", spParameter);

        //}
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        /// <param name="logged"></param>
        private void CreateLogs_LogCheckResult(string sid, int status, string sessionid)
        {

            SQLServerConnection<Cms_Patient> sQLServer1 = new SQLServerConnection<Cms_Patient>();

            SqlParameter[] spParameter = new SqlParameter[5];

            spParameter[0] = new SqlParameter("@SessionID", SqlDbType.NVarChar, 50);
            spParameter[0].Direction = ParameterDirection.Input;
            spParameter[0].Value = sessionid;

            spParameter[1] = new SqlParameter("@IP", SqlDbType.NVarChar, 10);
            spParameter[1].Direction = ParameterDirection.Input;
            spParameter[1].Value = GetIPAddress();

            spParameter[2] = new SqlParameter("@TimeAccess", SqlDbType.DateTime);
            spParameter[2].Direction = ParameterDirection.Input;
            spParameter[2].Value = DateTime.Now;


            spParameter[3] = new SqlParameter("@SID", SqlDbType.NVarChar, 30);
            spParameter[3].Direction = ParameterDirection.Input;
            spParameter[3].Value = sid;

            spParameter[4] = new SqlParameter("@Status", SqlDbType.Int, 4);
            spParameter[4].Direction = ParameterDirection.Input;
            spParameter[4].Value = status;

            int v = SQLHelper.SqlHelper.ExecuteNonQuery(Common.getConnectionString(), CommandType.StoredProcedure, "sp_cms_LogCheckResult_Insert", spParameter);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="body"></param>
        private void sendGmail(string title, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("suport.medlatec@gmail.com");
                mail.To.Add("info@medlatec.com");
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="submit"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Home(string submit, FormCollection form)
        {
            try
            {
                SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _News = sQLServer2.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.News = _News;

               
                string noikham = "HN";// form["dllNoiKhamSID"].ToString();
                string tokenkey = "m$dl4tec";

                if (submit == "SaveAdd")
                {

                    string ngaykham = form["txtngaykham"];
                  
                    if (form["txtngaykham"].Length > 50)
                    {
                        return View();
                    }
                    if (form["txtSID"].Length > 30)
                    {
                        return View();
                    }
                    ngaykham = ngaykham.Replace("/", "").Remove(4, 2);
                    string sid1 = ngaykham + "-" + form["txtSID"];

                    string ip = Request.UserHostAddress;
                    if (string.IsNullOrEmpty(ip))
                    {
                        ip = string.Empty;
                    }


                    if (noikham == "HN")
                    {
                      
                        List<Cms_Patient> Ketqua = null;
                        if (Session["thongtinHNNew" + sid1] != null)
                        {
                            Ketqua = (List<Cms_Patient>)Session["thongtinHN" + sid1];
                        }
                        else
                        {

                            string url = "api/Result/GetPatientByPassword?username=" + sid1 + "&password=" + form["txtMKSID"].ToString().Trim() + "&token=" + Common.generalKeyPrivate(sid1);
                            var result = ImpCallAPI<Cms_Patient>.geContentAPI(url);
                            if (result != null)
                            {
                                Ketqua = result;
                                Session["thongtinHNNew" + sid1] = Ketqua;
                            }
                            else
                            {
                                Session["thongtinHNNew" + sid1] = null;
                            }
                           
                        }

                        if (Ketqua != null)
                        {
                            if (Ketqua.Count > 0)
                            {
                               
                                tokenkey = SaltedHash.GetSHA512(tokenkey + sid1.Trim());
                                sid1 = AES.EncryptString(sid1.Trim(), "").Trim();
                                if (form["dllNgonngu"].ToString() == "VN")
                                {
                                    Response.Redirect("/tra-cuu-ket-qua/sid?sid=" + sid1 + "&place=" + noikham + "&" + "La=" + form["dllNgonngu"].ToString() + "&token=" + tokenkey, false);

                                }
                                else
                                    Response.Redirect("/tra-cuu-ket-qua-en/sid?sid=" + sid1 + "&place=" + noikham + "&" + "La=" + form["dllNgonngu"].ToString() + "&token=" + tokenkey, false);
                            }
                            else
                            {
                                TempData["msg"] = "<script>alert('Thông tin khách hàng không đúng! vui lòng đăng nhập lại.');</script>";
                            }
                        }
                        else
                        {
                            TempData["msg"] = "<script>alert('Thông tin khách hàng không đúng! vui lòng đăng nhập lại.');</script>";
                        }
                    }
                    else
                    {

                        SqlParameter[] arrpar = new SqlParameter[6];

                        List<Cms_Patient> Ketqua = null;
                        if (Session["thongtinSG" + sid1] != null)
                        {
                            Ketqua = (List<Cms_Patient>)Session["thongtinSG" + sid1];
                        }
                        else
                        {
                            string url = "api/Result/GetPatientBySIDSG?username=" + sid1 + "&token=" + Common.generalKeyPrivate(sid1);
                            var result = ImpCallAPI<Cms_Patient>.geContentAPI(url);
                            if (result != null)
                            {
                                Ketqua = result;
                                Session["thongtinSG" + sid1] = Ketqua;
                            }
                            else
                            {
                                Session["thongtinSG" + sid1] = null;
                            }

                           
                        }

                        if (Ketqua != null)
                        {
                            if (Ketqua.Count > 0)
                            {
                                tokenkey = SaltedHash.GetSHA512(tokenkey + sid1.Trim());
                                sid1 = AES.EncryptString(sid1.Trim(), "").Trim();

                                Response.Redirect("/tra-cuu-ket-qua/sid?sid=" + sid1 + "&place=" + noikham + "&" + "La=" + form["dllNgonngu"].ToString() + "&token=" + tokenkey, true);
                                Response.BufferOutput = true;
                            }
                            else
                            {
                                TempData["msg"] = "<script>alert('Thông tin khách hàng không đúng! vui lòng đăng nhập lại.');</script>";
                            }
                        }
                        else
                        {
                            TempData["msg"] = "<script>alert('Thông tin khách hàng không đúng! vui lòng đăng nhập lại.');</script>";
                        }
                    }
                }
                if (submit == "DVGM")
                {
                    if (form["txtusersid"].Length > 50)
                    {
                        return View();
                    }
                    if (form["txtmkuser"].Length > 30)
                    {
                        return View();
                    }

                    List<Cms_Patient> Ketqua = null;
                    if (Session["thongtinDVGM" + form["txtusersid"].ToString()] != null)
                    {
                        Ketqua = (List<Cms_Patient>)Session["thongtinDVGM" + form["txtusersid"].ToString()];
                    }
                    else
                    {
                        //string ip = Request.UserHostAddress;
                        //if (string.IsNullOrEmpty(ip))
                        //{
                        //    ip = string.Empty;
                        //}
                      
                        string url = "api/Result/GetPatientByUnit?username=" + form["txtusersid"].ToString().Trim() + "&password=" + form["txtmkuser"].Trim() + "&token=" + Common.generalKeyPrivate(form["txtusersid"].ToString().Trim());
                        var result = ImpCallAPI<Cms_Patient>.geContentAPI(url);
                        if (result != null)
                        {
                            Ketqua = result;
                            Session["thongtinDVGM" + form["txtusersid"].ToString()] = Ketqua;
                        }
                        else
                        {
                            Session["thongtinDVGM" + form["txtusersid"].ToString()] = null;
                        }

                    }

                    string ip = Request.UserHostAddress;
                    if (string.IsNullOrEmpty(ip))
                    {
                        ip = string.Empty;
                    }

                    if (Ketqua != null)
                    {

                       
                        if (Ketqua.Count > 0)
                        {
                            string matracuu = "";
                            matracuu = form["txtusersid"];

                         

                            Common.LogtraCuu(matracuu, ip, Ketqua[0].DoctorID);

                            tokenkey = SaltedHash.GetSHA512(tokenkey + matracuu.Trim());
                            matracuu = AES.EncryptString(matracuu.Trim(), "").Trim();

                           

                            Response.Redirect("/tra-cuu-ket-qua/dvgm?U=" + matracuu + "&place=" + form["dllNoikhamDVGM"].ToString() + "&token=" + tokenkey, true);
                            Response.BufferOutput = true;
                        }
                        else
                        {

                            Common.LogtraCuu(form["txtusersid"], ip, "");


                            TempData["msg"] = "<script>alert('Thông tin khách hàng không đúng! vui lòng đăng nhập lại.');</script>";
                        }
                    }
                    else
                    {
                        Common.LogtraCuu(form["txtusersid"], ip, "");

                        TempData["msg"] = "<script>alert('Thông tin khách hàng không đúng! vui lòng đăng nhập lại.');</script>";
                    }
                }

                if (submit == "PID")
                {
                    if (form["txtPid"].Length > 50)
                    {
                        return View();
                    }
                    if (form["txtmkpid"].Length > 30)
                    {
                        return View();
                    }

                   
                    List<Cms_Patient> Ketqua = null;
                    if (Session["thongtinPID" + form["txtPid"].ToString()] != null)
                    {
                        Ketqua = (List<Cms_Patient>)Session["thongtinPID" + form["txtPid"].ToString()];
                    }
                    else
                    {
                        string ip = Request.UserHostAddress;
                        if (string.IsNullOrEmpty(ip))
                        {
                            ip = string.Empty;
                        }
                        
                        string url = "api/Result/GetPatientByPID?pid=" + form["txtPid"].ToString().Trim() + "&password=" + form["txtmkpid"].Trim() + "&token=" + Common.generalKeyPrivate(form["txtPid"].ToString().Trim());
                        var result = ImpCallAPI<Cms_Patient>.geContentAPI(url);
                        if (result != null)
                        {
                            Ketqua = result;
                            Session["thongtinPID" + form["txtPid"].ToString()] = Ketqua;
                        }
                        else
                        {
                            Session["thongtinPID" + form["txtPid"].ToString()] = null;
                        }


                         
                    }

                 
                    if (Ketqua != null)
                    {
                        if (Ketqua.Count > 0)
                        {
                            string matracuu = "";
                            matracuu = form["txtPid"];
                            tokenkey = SaltedHash.GetSHA512(tokenkey + matracuu.Trim());
                            matracuu = AES.EncryptString(matracuu.Trim(), "").Trim();
                            Session["thongtinLichsukham" + form["txtPid"].ToString()] = Ketqua;
                           
                            Response.Redirect("/thekhachhang/lich-su-kham?p=" + matracuu + "&token=" + tokenkey, false);
                            Response.BufferOutput = true;
                        }
                        else
                        {
                            TempData["msg"] = "<script>alert('Thông tin khách hàng không đúng! vui lòng đăng nhập lại.');</script>";
                        }
                    }
                    else
                    {
                        TempData["msg"] = "<script>alert('Thông tin khách hàng không đúng! vui lòng đăng nhập lại.');</script>";
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sid"></param>
        /// <param name="place"></param>
        /// <param name="LA"></param>
        /// <param name="token"></param>
        /// <param name="print"></param>
        /// <returns></returns>
        public ActionResult ShortUrl(string shortUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(shortUrl))
                {
                    shortUrl = string.Empty;
                }
                string ip = Request.UserHostAddress;
                if (string.IsNullOrEmpty(ip))
                {
                    ip = string.Empty;
                }
                string url = string.Empty;

                CMS_Core.Common.Common.AddToLogFile(DateTime.Now.ToString("ddMMyyyyHHmm") + " shortUrl:" + shortUrl + " ip:" + ip);
                if (shortUrl.Length == 8)
                {
                  

                    url = "api/Result/GetsidByShortUrl?shortUrl=" + shortUrl.Trim() + "&token=" + Common.generalKeyPrivate(shortUrl.Trim());
                    var _Ketqua = ImpCallAPI<tblMapSIDAndShortUrl>.geContentAPI(url);

                  

                    if (_Ketqua != null)
                    {
                        if (_Ketqua.Count > 0)
                        {
                            List<Cms_Patient> thongtin = null;


                            if (Session["thongtinHNNew" + _Ketqua[0]._sid.Trim()] != null)
                            {
                                thongtin = (List<Cms_Patient>)Session["thongtinHNNew" + _Ketqua[0]._sid.Trim()];
                            }
                            else
                            {

                                url = "api/Result/GetPatientByCheckLoginNewDoAn?username=" + _Ketqua[0]._sid.Trim() + "&token=" + Common.generalKeyPrivate(_Ketqua[0]._sid.Trim());
                                var result = ImpCallAPI<Cms_Patient>.geContentAPI(url);
                                if (result != null)
                                {
                                    thongtin = result;
                                    Session["thongtinHNNew" + _Ketqua[0]._sid.Trim()] = thongtin;
                                }
                                else
                                {
                                    Session["thongtinHNNew" + _Ketqua[0]._sid.Trim()] = null;
                                }

                                
                            }

                            if (thongtin != null)
                            {
                                if (thongtin.Count > 0)
                                {
                                    string tokenkey = "m$dl4tec";
                                    string sid = _Ketqua[0]._sid;
                                    tokenkey = SaltedHash.GetSHA512(tokenkey + sid.Trim());

                                    sid = AES.EncryptString(sid.Trim(), "").Trim();
                                    Response.Redirect("/tra-cuu-ket-qua/sid?sid=" + sid.Trim() + "&place=HN&La=VN&token=" + tokenkey, true);
                                }
                                else
                                {
                                    Response.Redirect("https://medlatec.vn/tra-cuu-ket-qua", true);
                                }

                            }
                            else
                            {
                                Response.Redirect("https://medlatec.vn/tra-cuu-ket-qua", true);
                            }

                        }
                        else
                        {
                            Response.Redirect("https://medlatec.vn/tra-cuu-ket-qua", true);
                        }
                    }
                    else
                    {
                        Response.Redirect("https://medlatec.vn/tra-cuu-ket-qua", true);
                    }
                }
                else
                {
                    Response.Redirect("https://medlatec.vn/tra-cuu-ket-qua", true);
                }

            }
            catch (Exception ex)
            {

            }
            return View();
        }


        public ActionResult ShortUrlNew(string shorturl)
        {
            if (string.IsNullOrEmpty(shorturl))
            {
                shorturl = string.Empty;
            }

            SQLServerConnection<tblShortUrlNew> sQLServer1 = new SQLServerConnection<tblShortUrlNew>();
            List<tblShortUrlNew> _News = sQLServer1.SelectQueryCommand("GettblShortUrlNew", Common.getConnectionString(), shorturl);

            if (_News != null)
            {
                if (_News.Count > 0)
                {
                    Response.Redirect(_News[0].Link.Trim(), true);
                }
                else
                {
                    Response.Redirect("https://medlatec.vn", true);
                }
            }
            else
            {
                Response.Redirect("https://medlatec.vn", true);
            }

            return View();
        }


    }
}
