using CaptchaMvc.HtmlHelpers;
using CMS_Core.Common;
using MEDLATEC.BusinessLayer;
using MEDLATEC2019.Entity;
using MEDLATEC2019.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MEDLATEC2019.Controllers
{
    public class LandingController : Controller
    {
        private SQLServerConnection<tbl_logLanding> sQLServer;

        public LandingController()
        {
            sQLServer = new SQLServerConnection<tbl_logLanding>();
        }
        // GET: Landing
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LandingTN()
        {
            MEDLATEC2019.Models.MPTXViewModel obj = new Models.MPTXViewModel();
            obj.txtError = string.Empty;
            obj.txtdt = string.Empty;
            obj.txtEmail = string.Empty;
            obj.txthoten = string.Empty;
            obj.txtnote = string.Empty;

            SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 192, 4, 1);
            ViewBag.NewsCate = _NewsCate;

            return View(obj);
        }
        public ActionResult LandingHotrosuckhoe()
        {

            return View();
        }
        public ActionResult LandingMPTX()
        {
            this.ViewBag.GetDichvu = Common.GetDichvu();


            return View();
        }

        public ActionResult LandingSongkhoe()
        {
            MEDLATEC2019.Models.MPTXViewModel obj = new Models.MPTXViewModel();
            obj.txtError = string.Empty;
            obj.txtdt = string.Empty;
            obj.txtEmail = string.Empty;
            obj.txthoten = string.Empty;
            obj.txtnote = string.Empty;

            return View(obj);
        }
        public ActionResult LandingSuckhoeTQ()
        {

            return View();
        }

        public ActionResult BenhHoHap()
        {
            MEDLATEC2019.Models.MPTXViewModel obj = new Models.MPTXViewModel();
            obj.txtAddress = string.Empty;
            obj.txtdt = string.Empty;
            obj.txthoten = string.Empty;
            obj.txtEmail = string.Empty;
            obj.txtnote = string.Empty;
            obj.txtError = string.Empty;


            this.ViewBag.GetDichvu = Common.GetDichvuShopee();
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BenhHoHap(MEDLATEC2019.Models.MPTXViewModel obj)
        {

            try
            {
                if (string.IsNullOrEmpty(obj.txthoten))
                {
                    obj.txtError = "Mời bạn nhập tên bạn";
                    return View(obj);
                }

                if (!string.IsNullOrEmpty(obj.txtdt))
                {
                    if (IsNumeric(obj.txtdt.Trim()))
                    {

                        if ((obj.txtdt.Trim().Length != 10))
                        {
                            obj.txtError = "Số điện thoại phải là 10 số";
                            return View(obj);
                        }
                    }

                }
                else
                {
                    obj.txtError = "Mời bạn nhập số điện thoại";
                    return View(obj);

                }





                string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2") + " " + DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":00";
                int idgoi = 0;
                string magoi = "";
                string tengoi = "";

                idgoi = 3089;
                tengoi = "2020 CHTRINH MP KHÁM CK HH VÀ GIẢM 30% CT";
                magoi = "20KMCKHH";


                // check sdt tồn tại chưa tbl_logLanding_selectBySDT
                List<tbl_logLanding> logLandings = sQLServer.SelectQueryCommand("tbl_logLanding_selectBySDT", Common.getConnectionString(), obj.txtdt.ToString().Trim(), magoi);
                if (logLandings != null)
                {
                    if (logLandings.Count > 0)
                    {
                        obj.txtError = "Số điện thoại đã đăng ký rồi mời bạn dùng SĐT khác";
                        return View(obj);
                    }
                }

                CMS_Core.Common.Common.DatGoiKham(idgoi, magoi, tengoi, DateTime.Parse(abc), obj.txtdt.ToString().Trim(), DateTime.Parse(abc), DateTime.Parse(abc), DateTime.Parse(abc), obj.txthoten.Trim(), "");

                if (string.IsNullOrEmpty(obj.txtAddress))
                {
                    obj.txtAddress = string.Empty;
                }
                if (string.IsNullOrEmpty(obj.txtnote))
                {
                    obj.txtnote = string.Empty;
                }
                if (string.IsNullOrEmpty(obj.txtEmail))
                {
                    obj.txtEmail = string.Empty;
                }
                // chèn log
                string result = sQLServer.ExecuteInsert("tbl_logLanding_Insert", obj.txtdt.ToString().Trim(), obj.txtEmail, obj.txtnote, obj.txtAddress, Common.GetIPHelper(), magoi, obj.txthoten.Trim());



                Response.Redirect("/thankyou?u=BenhHoHap", true);

            }
            catch (Exception ex)
            {

            }




            return View(obj);
        }




        public ActionResult quisleShopee()
        {
            MEDLATEC2019.Models.MPTXViewModel obj = new Models.MPTXViewModel();
            obj.txtAddress = string.Empty;
            obj.txtdt = string.Empty;
            obj.txthoten = string.Empty;
            obj.txtEmail = string.Empty;
            obj.txtnote = string.Empty;
            obj.txtError = string.Empty;


            this.ViewBag.GetDichvu = Common.GetDichvuShopee();
            return View(obj);
        }

        public ActionResult XetNghiemTongQuat()
        {
            MEDLATEC2019.Models.MPTXViewModel obj = new Models.MPTXViewModel();
            obj.txtAddress = string.Empty;
            obj.txtdt = string.Empty;
            obj.txthoten = string.Empty;
            obj.txtEmail = string.Empty;
            obj.txtnote = string.Empty;
            obj.txtError = string.Empty;
            obj.Dichvu = string.Empty;

            this.ViewBag.GetDichvu = Common.XetNghiemTongQuat();
            return View(obj);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult XetNghiemTongQuat(MEDLATEC2019.Models.MPTXViewModel obj)
        {
            this.ViewBag.GetDichvu = Common.XetNghiemTongQuat();
            try
            {
                if (string.IsNullOrEmpty(obj.txthoten))
                {
                    obj.txtError = "Mời bạn nhập tên bạn";
                    return View(obj);

                }

                if (string.IsNullOrEmpty(obj.Dichvu))
                {
                    obj.txtError = "Mời bạn chọn dịch vụ";
                    return View(obj);

                }


                if (!string.IsNullOrEmpty(obj.txtdt))
                {
                    if (IsNumeric(obj.txtdt.Trim()))
                    {

                        if ((obj.txtdt.Trim().Length != 10))
                        {
                            obj.txtError = "Số điện thoại phải là 10 số";
                            return View(obj);
                        }
                    }

                }
                else
                {
                    obj.txtError = "Mời bạn nhập số điện thoại";
                    return View(obj);

                }

                string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2") + " " + DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":00";


                int idgoi = 0;
                string magoi = "";
                string tengoi = "";
                if ("20KMGKTN8".Equals(obj.Dichvu.Trim()))
                {
                    idgoi = 3076;
                    tengoi = "2020 CHTRINH KM GÓI KHÁM TSUT TẠI NHÀ NỮ ";
                    magoi = "20KMGKTN8";
                }

                if ("20KMGKTN9".Equals(obj.Dichvu.Trim()))
                {
                    idgoi = 3079;
                    tengoi = "2020 CHTRINH KM GÓI KHÁM TSUT TẠI NHÀ NAM ";
                    magoi = "20KMGKTN9";
                }

                if ("20KMGKTN10".Equals(obj.Dichvu.Trim()))
                {
                    idgoi = 3078;
                    tengoi = "2020 CHTRINH KM GÓI KHÁM TSUT TẠI NHÀ NC NỮ ";
                    magoi = "20KMGKTN10";
                }

                if ("20KMGKTN11".Equals(obj.Dichvu.Trim()))
                {
                    idgoi = 3077;
                    tengoi = "2020 CHTRINH KM GÓI KHÁM TSUT TẠI NHÀ NC NAM ";
                    magoi = "20KMGKTN11";
                }


                // check sdt tồn tại chưa tbl_logLanding_selectBySDT
                List<tbl_logLanding> logLandings = sQLServer.SelectQueryCommand("tbl_logLanding_selectBySDT", Common.getConnectionString(), obj.txtdt.ToString().Trim(), magoi);
                if (logLandings != null)
                {
                    if (logLandings.Count > 0)
                    {
                        obj.txtError = "Số điện thoại đã đăng ký rồi mời bạn dùng SĐT khác";
                        return View(obj);
                    }
                }

                CMS_Core.Common.Common.DatGoiKham(idgoi, magoi, tengoi, DateTime.Parse(abc), obj.txtdt.ToString().Trim(), DateTime.Parse(abc), DateTime.Parse(abc), DateTime.Parse(abc), obj.txthoten.Trim(), "");

                if (string.IsNullOrEmpty(obj.txtAddress))
                {
                    obj.txtAddress = string.Empty;
                }
                if (string.IsNullOrEmpty(obj.txtnote))
                {
                    obj.txtnote = string.Empty;
                }
                if (string.IsNullOrEmpty(obj.txtEmail))
                {
                    obj.txtEmail = string.Empty;
                }
                // chèn log
                string result = sQLServer.ExecuteInsert("tbl_logLanding_Insert", obj.txtdt.ToString().Trim(), obj.txtEmail, obj.txtnote, obj.txtAddress, Common.GetIPHelper(), magoi, obj.txthoten.Trim());

                Response.Redirect("/thankyou?u=XetNghiemTongQuat", true);

            }
            catch (Exception ex)
            {

            }




            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult XetNghiemTongQuat1(MEDLATEC2019.Models.MPTXViewModel obj)
        {
            this.ViewBag.GetDichvu = Common.XetNghiemTongQuat();
            try
            {
                if (!string.IsNullOrEmpty(obj.txthoten))
                {

                }
                else
                {
                    obj.txtError = "Mời bạn nhập tên bạn";
                    return View(obj);

                }

                if (!string.IsNullOrEmpty(obj.txtdt))
                {
                    if (IsNumeric(obj.txtdt.Trim()))
                    {

                        if ((obj.txtdt.Trim().Length != 10))
                        {
                            obj.txtError = "Số điện thoại phải là 10 số";
                            return View(obj);
                        }
                    }

                }
                else
                {
                    obj.txtError = "Mời bạn nhập số điện thoại";
                    return View(obj);

                }

                string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2") + " " + DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":00";


                int idgoi = 0;
                string magoi = "";
                string tengoi = "";
                if ("20KMGKTN8".Equals(obj.Dichvu.Trim()))
                {
                    idgoi = 3076;
                    tengoi = "2020 CHTRINH KM GÓI KHÁM TSUT TẠI NHÀ NỮ ";
                    magoi = "20KMGKTN8";
                }

                if ("20KMGKTN9".Equals(obj.Dichvu.Trim()))
                {
                    idgoi = 3079;
                    tengoi = "2020 CHTRINH KM GÓI KHÁM TSUT TẠI NHÀ NAM ";
                    magoi = "20KMGKTN9";
                }

                if ("20KMGKTN10".Equals(obj.Dichvu.Trim()))
                {
                    idgoi = 3078;
                    tengoi = "2020 CHTRINH KM GÓI KHÁM TSUT TẠI NHÀ NC NỮ ";
                    magoi = "20KMGKTN10";
                }

                if ("20KMGKTN11".Equals(obj.Dichvu.Trim()))
                {
                    idgoi = 3077;
                    tengoi = "2020 CHTRINH KM GÓI KHÁM TSUT TẠI NHÀ NC NAM ";
                    magoi = "20KMGKTN11";
                }


                // check sdt tồn tại chưa tbl_logLanding_selectBySDT
                List<tbl_logLanding> logLandings = sQLServer.SelectQueryCommand("tbl_logLanding_selectBySDT", Common.getConnectionString(), obj.txtdt.ToString().Trim(), magoi);
                if (logLandings != null)
                {
                    if (logLandings.Count > 0)
                    {
                        obj.txtError = "Số điện thoại đã đăng ký rồi mời bạn dùng SĐT khác";
                        return View(obj);
                    }
                }

                CMS_Core.Common.Common.DatGoiKham(idgoi, magoi, tengoi, DateTime.Parse(abc), obj.txtdt.ToString().Trim(), DateTime.Parse(abc), DateTime.Parse(abc), DateTime.Parse(abc), obj.txthoten.Trim(), "");

                if (string.IsNullOrEmpty(obj.txtAddress))
                {
                    obj.txtAddress = string.Empty;
                }
                if (string.IsNullOrEmpty(obj.txtnote))
                {
                    obj.txtnote = string.Empty;
                }
                if (string.IsNullOrEmpty(obj.txtEmail))
                {
                    obj.txtEmail = string.Empty;
                }
                // chèn log
                string result = sQLServer.ExecuteInsert("tbl_logLanding_Insert", obj.txtdt.ToString().Trim(), obj.txtEmail, obj.txtnote, obj.txtAddress, Common.GetIPHelper(), magoi, obj.txthoten.Trim());

                Response.Redirect("/thankyou?u=XetNghiemTongQuat", true);

            }
            catch (Exception ex)
            {

            }




            return View(obj);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult quisleShopee(MEDLATEC2019.Models.MPTXViewModel obj)
        {
            this.ViewBag.GetDichvu = Common.GetDichvuShopee();
            try
            {
                if (string.IsNullOrEmpty(obj.txthoten))
                {
                    obj.txtError = "Mời bạn nhập tên bạn";
                    return View(obj);
                }

                if (!string.IsNullOrEmpty(obj.txtdt))
                {
                    if (IsNumeric(obj.txtdt.Trim()))
                    {

                        if ((obj.txtdt.Trim().Length != 10))
                        {
                            obj.txtError = "Số điện thoại phải là 10 số";
                            return View(obj);
                        }
                    }

                }
                else
                {
                    obj.txtError = "Mời bạn nhập số điện thoại";
                    return View(obj);

                }

                if (string.IsNullOrEmpty(obj.Dichvu))
                {
                    obj.txtError = "Mời bạn chọn dịch vụ";
                    return View(obj);

                }

                //Voucher 200.000vnđ
                if ("200".Equals(obj.Dichvu.Trim()))
                {
                    SQLServerConnection<Cms_TheTT> sQLServer2 = new SQLServerConnection<Cms_TheTT>();
                    List<Cms_TheTT> _Otp = sQLServer2.SelectQueryCommand("OTP_SelectOTP_Selectchannels", Common.getConnectionString(), obj.txtdt.Trim().Replace(" ", ""), "SPEE200K");

                    if (_Otp != null)
                    {
                        if (_Otp.Count > 0)
                        {
                            obj.txtError = "Số điện thoại bạn đã đăng ký chương trình này rồi.Vui lòng kiểm tra lại.Xin cám ơn!";
                            return View(obj);
                        }
                        else
                        {


                            string giatien = "";
                            string number = "";

                            giatien = "200,000";
                            number = "SPEE200K";


                            List<Cms_TheTT> _TheTT = new List<Cms_TheTT>();

                            HttpClient http2 = new HttpClient();

                            string baseUrl2 = CMS_Core.Common.Common.getLINKAPI() + "api/Thett/Get_TheTT/?token=" + Common.generalKeyPrivate(number) + "&MaTheTT=" + number;

                            string url2 = baseUrl2;
                            HttpResponseMessage response2 = http2.GetAsync(new Uri(url2)).Result;
                            string responseBody2 = response2.Content.ReadAsStringAsync().Result;
                            var countries2 = JsonConvert.DeserializeObject(responseBody2);

                            JArray jsonResponse2 = JArray.Parse(responseBody2);

                            foreach (var item in jsonResponse2)
                            {
                                Cms_TheTT rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Cms_TheTT>(item.ToString());
                                _TheTT.Add(rowsDoctor);

                            }

                            using (var client = new HttpClient())
                            {
                                try
                                {

                                    client.BaseAddress = new Uri(CMS_Core.Common.Common.getLINKAPI());

                                    MEDLATEC.BusinessLayer.Cms_TheTT objd = new MEDLATEC.BusinessLayer.Cms_TheTT();
                                    objd.Content = "nội dung";
                                    objd.dtkh = "8479307930";
                                    string hoten = obj.txthoten.Trim();
                                    string sdt = obj.txtdt.Trim();

                                    //string email = obj.txtEmail.Trim();
                                    string diachi = obj.txtAddress.Trim();

                                    if (sdt.Substring(0, 1) == "0")
                                    {
                                        sdt = sdt.Remove(0, 1);
                                        sdt = "84" + sdt;

                                    }

                                    object result = string.Empty;

                                    string serialisedData = JsonConvert.SerializeObject(obj);

                                    string abc = _TheTT[0].SoThe;

                                    string contentsms = "BV MEDLATEC va SHOPEE gui tang QK ma 200.000vnd(DK: 1 trieu) " + abc + " kham va xet nghiem. Ap dung tai BV, PK va dich vu lay mau xet nghiem tai nha toan quoc. QK vui long xuat trinh ma khi thanh toan. Hotline 1900565656";

                                    string urlfull = $"{CMS_Core.Common.Common.getLINKAPI()}api/Thett/SendSMS/?token=" + Common.generalKeyPrivate(sdt.Trim()) + "&content=" + contentsms + "&sdt=" + sdt.Trim() + "";
                                    HttpContent httpContent = new StringContent(serialisedData);
                                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                    HttpResponseMessage message = client.PostAsync(urlfull, httpContent).Result;
                                    string urlfull1 = $"{CMS_Core.Common.Common.getLINKAPI()}api/Thett/Update_TheTT?token=" + Common.generalKeyPrivate(abc.Trim()) + "&SoThe=" + abc.Trim() + "";
                                    HttpContent httpContent1 = new StringContent(serialisedData);
                                    httpContent1.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                    HttpResponseMessage message1 = client.PostAsync(urlfull1, httpContent1).Result;
                                    string ghichu = "Khách hàng từ chương trình shoppe:" + number;

                                    CMS_Core.Common.Common.DatlichTin(hoten, obj.txtdt.Trim(), ghichu, "", "Khách hàng từ chương trình shoppe", number);


                                    SqlConnection _conn;
                                    _conn = new SqlConnection(ConfigurationManager.AppSettings["Main.ConnectionString"]);
                                    _conn.Open();


                                    // Info.  
                                    string sql = string.Empty;
                                    sql = "insert into tbl_OTP(Sodt,channels) values(";
                                    sql += "@Sodt,@channels)";

                                    SqlCommand comd = new SqlCommand(sql, _conn);



                                    comd.Parameters.Add("@Sodt", SqlDbType.NVarChar, 15).Value = obj.txtdt.Trim().Replace(" ", "");
                                    comd.Parameters.Add("@channels", SqlDbType.NVarChar, 15).Value = "SPEE200K";

                                    comd.ExecuteNonQuery();
                                    _conn.Close();

                                }
                                catch (Exception ex)
                                {

                                    throw;
                                }
                            }
                        }
                    }
                }
                else
                {

                    string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2") + " " + DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":00";
                    int idgoi = 0;
                    string magoi = "";
                    string tengoi = "";
                    if ("20KMSHOPE1".Equals(obj.Dichvu.Trim()))
                    {
                        idgoi = 3038;
                        tengoi = "Miễn phí khám Nhi ";
                        magoi = "20KMSHOPE1";
                    }

                    if ("20KMSHOPE2".Equals(obj.Dichvu.Trim()))
                    {
                        idgoi = 3042;
                        tengoi = "Gói khám Tổng quát và vi chất nhi gói 1 – 25CS ";
                        magoi = "20KMSHOPE2";
                    }

                    if ("20KMSHOPE3".Equals(obj.Dichvu.Trim()))
                    {
                        idgoi = 3043;
                        tengoi = "Gói khám Tổng quát và vi chất nhi gói 2 – 25 CS ";
                        magoi = "20KMSHOPE3";
                    }

                    if ("20KMSHOPE4".Equals(obj.Dichvu.Trim()))
                    {
                        idgoi = 3052;
                        tengoi = "Gói khám Tổng quát và vi chất nhi gói 1 – 18CS ";
                        magoi = "20KMSHOPE4";
                    }

                    if ("20KMSHOPE5".Equals(obj.Dichvu.Trim()))
                    {
                        idgoi = 3053;
                        tengoi = "Gói khám Tổng quát và vi chất nhi gói 2 – 18CS ";
                        magoi = "20KMSHOPE5";
                    }

                    // check sdt tồn tại chưa tbl_logLanding_selectBySDT
                    List<tbl_logLanding> logLandings = sQLServer.SelectQueryCommand("tbl_logLanding_selectBySDT", Common.getConnectionString(), obj.txtdt.ToString().Trim(), magoi);
                    if (logLandings != null)
                    {
                        if (logLandings.Count > 0)
                        {
                            obj.txtError = "Số điện thoại đã đăng ký rồi mời bạn dùng SĐT khác";
                            return View(obj);
                        }
                    }

                    CMS_Core.Common.Common.DatGoiKham(idgoi, magoi, tengoi, DateTime.Parse(abc), obj.txtdt.ToString().Trim(), DateTime.Parse(abc), DateTime.Parse(abc), DateTime.Parse(abc), obj.txthoten.Trim(), "");

                    if (string.IsNullOrEmpty(obj.txtAddress))
                    {
                        obj.txtAddress = string.Empty;
                    }
                    if (string.IsNullOrEmpty(obj.txtnote))
                    {
                        obj.txtnote = string.Empty;
                    }
                    if (string.IsNullOrEmpty(obj.txtEmail))
                    {
                        obj.txtEmail = string.Empty;
                    }
                    // chèn log
                    string result = sQLServer.ExecuteInsert("tbl_logLanding_Insert", obj.txtdt.ToString().Trim(), obj.txtEmail, obj.txtnote, obj.txtAddress, Common.GetIPHelper(), magoi, obj.txthoten.Trim());

                }


                Response.Redirect("/thankyou?u=quisleShopee", true);

            }
            catch (Exception ex)
            {

            }




            return View(obj);
        }



        public ActionResult LandingUngThu()
        {

            return View();
        }
        public ActionResult LandingSieuamthaichudong()
        {

            return View();
        }

        public ActionResult LandingBaohiemyte()
        {
            SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 165, 15, 1);
            ViewBag.NewsCate = _NewsCate;

            return View();
        }
        public ActionResult LandingBaolanhvienphi()
        {
            SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 191, 15, 1);
            ViewBag.NewsCate = _NewsCate;

            return View();
        }
        public ActionResult LandingTuyengiap()
        {

            return View();
        }


        public ActionResult LandingKhamsk()
        {

            SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 150, 15, 1);
            ViewBag.NewsCate = _NewsCate;

            return View();
        }


        public ActionResult LandingMPXNMauT9()
        {

            return View();
        }

        public ActionResult LandingChuyengia()
        {
            this.ViewBag.GetChuyengia = Common.GetChuyengia();
            return View();
        }


        public ActionResult LandingBenhlyPhoi()
        {

            return View();
        }

        public ActionResult LandingCEA2019()
        {

            return View();
        }
        public ActionResult LandingThanhXuan()
        {

            return View();
        }

        public ActionResult nipt()
        {
            this.ViewBag.GetDichvu = Common.GetDichvuNIPT();
            return View();
        }

        public ActionResult niptNew()
        {
            this.ViewBag.GetDichvu = Common.GetDichvuNIPTNew();
            return View();
        }


        public ActionResult Medem()
        {
            this.ViewBag.GetDichvu = Common.Getthoigiankham();
            return View();
        }

        public ActionResult coxuongkhop()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult coxuongkhop(MEDLATEC2019.Models.MPTXViewModel obj)
        {

            try
            {

                if (string.IsNullOrEmpty(obj.txthoten))
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập tên bạn');</script>";
                    return View(obj);
                }

                if (!string.IsNullOrEmpty(obj.txtdt))
                {
                    if (IsNumeric(obj.txtdt.Trim()))
                    {

                        if ((obj.txtdt.Trim().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện thoại phải là 10 số.');</script>";
                            return View(obj);
                        }
                    }

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập số điện thoại');</script>";
                    return View(obj);

                }

                string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2") + " " + DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":00";


                int idgoi = 0;
                string magoi = "";
                string tengoi = "";

                idgoi = 2993;
                tengoi = "2020 Chtrinh Ck Cxk 1 Bs - Ban Cskh";
                magoi = "20KMCXK1";

                if (!string.IsNullOrEmpty(obj.txtAddress))
                {
                    obj.txtAddress = string.Empty;
                }

                CMS_Core.Common.Common.DatGoiKham(idgoi, magoi, tengoi, DateTime.Parse(abc), obj.txtdt.ToString().Trim(), DateTime.Parse(abc), DateTime.Parse(abc), DateTime.Parse(abc), obj.txthoten.Trim(), obj.txtAddress.Trim());

                Response.Redirect("/thankyou?u=coxuongkhop", true);

            }
            catch (Exception ex)
            {

            }




            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Medem(MEDLATEC2019.Models.MPTXViewModel obj)
        {

            this.ViewBag.GetDichvu = Common.Getthoigiankham();

            try
            {

                if (string.IsNullOrEmpty(obj.txthoten))
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập tên bạn');</script>";
                    return View(obj);
                }

                if (string.IsNullOrEmpty(obj.Dichvu))
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập giờ hẹn');</script>";
                    return View(obj);
                }
                else if (obj.Dichvu == "")
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập giờ hẹn');</script>";
                    return View(obj);
                }


                if (!string.IsNullOrEmpty(obj.txtdt))
                {
                    if (IsNumeric(obj.txtdt.Trim()))
                    {

                        if ((obj.txtdt.Trim().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện thoại phải là 10 số.');</script>";
                            return View(obj);
                        }
                    }

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập số điện thoại');</script>";
                    return View(obj);

                }

                string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2") + " " + DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":00";


                int idgoi = 0;
                string magoi = "";
                string tengoi = "";

                idgoi = 2931;
                tengoi = "Gói Xét Nghiệm Phòng Khám Prep";
                magoi = "20GOIPREP";

                if (!string.IsNullOrEmpty(obj.txtAddress))
                {
                    obj.txtAddress = string.Empty;
                }
                else if ("7h12h".Equals(obj.Dichvu.Trim()))
                {
                    obj.txtAddress = obj.txtAddress + " Hẹn khám sáng 7h30 đến 12h";
                }
                else
                {
                    obj.txtAddress = obj.txtAddress + " Hẹn khám chiều 13h30 đến 17h";
                }
                CMS_Core.Common.Common.DatGoiKham(idgoi, magoi, tengoi, DateTime.Parse(abc), obj.txtdt.ToString().Trim(), DateTime.Parse(abc), DateTime.Parse(abc), DateTime.Parse(abc), obj.txthoten.Trim(), obj.txtAddress.Trim());

                Response.Redirect("/thankyou?u=Medem", true);

            }
            catch (Exception ex)
            {

            }




            return View();
        }

        public ActionResult LandingSangkien()
        {

            return View();
        }
        public ActionResult Goichamsocskngayle()
        {

            return View();
        }
        public ActionResult Dotsongcaotang()
        {
            return View();

        }

        public ActionResult Dotsongcaotangrfa()
        {
            MEDLATEC2019.Models.MPTXViewModel obj = new Models.MPTXViewModel();
            obj.txtAddress = string.Empty;
            obj.txtdt = string.Empty;
            obj.txthoten = string.Empty;
            obj.txtEmail = string.Empty;
            obj.txtnote = string.Empty;
            obj.txtError = string.Empty;


            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Dotsongcaotangrfa(MEDLATEC2019.Models.MPTXViewModel obj)
        {

            try
            {

                if (string.IsNullOrEmpty(obj.txthoten))
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập tên bạn');</script>";
                    return View(obj);
                }

                if (!string.IsNullOrEmpty(obj.txtdt))
                {
                    if (IsNumeric(obj.txtdt.Trim()))
                    {

                        if ((obj.txtdt.Trim().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện thoại phải là 10 số.');</script>";
                            return View(obj);
                        }
                    }

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập số điện thoại');</script>";
                    return View(obj);

                }

                if (string.IsNullOrEmpty(obj.txtAddress))
                {
                    obj.txtAddress = string.Empty;
                }
                if (string.IsNullOrEmpty(obj.txtEmail))
                {
                    obj.txtEmail = string.Empty;
                }


                CMS_Core.Common.Common.DatlichTin(obj.txthoten.Trim(), obj.txtdt.ToString().Trim(), obj.txtAddress.Trim(), obj.txtEmail.Trim(), "WebMed - Landing dot song cao tang", "LDTNOL");


                //string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2") + " " + DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":00";


                //int idgoi = 0;
                //string magoi = "";
                //string tengoi = "";

                //idgoi = 2993;
                //tengoi = "2020 Chtrinh Ck Cxk 1 Bs - Ban Cskh";
                //magoi = "20KMCXK1";

                //if (!string.IsNullOrEmpty(obj.txtAddress))
                //{
                //    obj.txtAddress = string.Empty;
                //}

                //CMS_Core.Common.Common.DatGoiKham(idgoi, magoi, tengoi, DateTime.Parse(abc), obj.txtdt.ToString().Trim(), DateTime.Parse(abc), DateTime.Parse(abc), DateTime.Parse(abc), obj.txthoten.Trim(), obj.txtAddress.Trim());

                Response.Redirect("/thankyou?u=Dotsongcaotangrfa", true);

            }
            catch (Exception ex)
            {

            }




            return View(obj);
        }




        public ActionResult udaiksk()
        {

            return View();
        }


        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Dotsongcaotang(FormCollection form)
        {

            try
            {

                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập tên bạn');</script>";
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

                string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2") + " " + DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":00";

                CMS_Core.Common.Common.Datlich("", form["txthoten"].ToString(), form["txtsdt"].ToString(), "", "", "", "", "Dotsongcaotang", "");

                // CMS_Core.Common.Common.DatGoiKham(2725, "20KMKTRTN", "Gói xét nghiệm kiểm tra sức khỏe tổng quát", DateTime.Parse(abc), form["txtdt"].ToString().Trim(), DateTime.Parse(ngay), DateTime.Parse(giochuan11), DateTime.Parse(giochuan12), form["txthoten"].ToString(), form["txtdiachi"].ToString().Trim());

                Response.Redirect("/thankyou?u=Dotsongcaotang", true);

            }
            catch (Exception ex)
            {

            }




            return View();
        }


        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult LandingSuckhoeTQ(FormCollection form)
        {
            Response.Redirect("/finish?LandingSuckhoeTQ", true);


            //try
            //{

            //    if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
            //    {

            //    }
            //    else
            //    {
            //        TempData["msg"] = "<script>alert('Mời bạn nhập tên bạn');</script>";
            //        return View();

            //    }

            //    if (!string.IsNullOrEmpty(form["txtdt"].ToString().Trim()))
            //    {
            //        if (IsNumeric(form["txtdt"].ToString().Trim()))
            //        {

            //            if ((form["txtdt"].ToString().Length != 10))
            //            {
            //                TempData["msg"] = "<script>alert('Số điện thoại phải là 10 số.');</script>";
            //                return View();
            //            }
            //        }
            //        else
            //        {
            //        }
            //    }
            //    else
            //    {
            //        TempData["msg"] = "<script>alert('Mời bạn nhập số điện thoại');</script>";
            //        return View();

            //    }

            //    string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2") + " " + DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":00";

            //    string ngay = form["dllNgayhen"].ToString();
            //    DateTime ngay1 = DateTime.Parse(ngay);
            //    ngay = ngay1.Year.ToString() + "-" + ngay1.Month.ToString("d2") + "-" + ngay1.Day.ToString("d2");

            //    string gio = form["dllGiohen"].ToString();
            //    string giohen1 = ngay + " " + gio;
            //    DateTime giochuan1 = DateTime.Parse(giohen1, new CultureInfo("en-US"));

            //    string giochuan11 = giochuan1.Year.ToString() + "-" + giochuan1.Month.ToString("d2") + "-" + giochuan1.Day.ToString("d2") + " " + giochuan1.Hour.ToString("d2") + ":" + giochuan1.Minute.ToString("d2") + ":00";
            //    DateTime giochuan2 = DateTime.Parse(giochuan11).AddHours(1);
            //    string giochuan12 = giochuan2.Year.ToString() + "-" + giochuan2.Month.ToString("d2") + "-" + giochuan2.Day.ToString("d2") + " " + giochuan2.Hour.ToString("d2") + ":" + giochuan2.Minute.ToString("d2") + ":00";


            //    CMS_Core.Common.Common.DatGoiKham(2725, "20KMKTRTN", "Gói xét nghiệm kiểm tra sức khỏe tổng quát", DateTime.Parse(abc), form["txtdt"].ToString().Trim(), DateTime.Parse(ngay), DateTime.Parse(giochuan11), DateTime.Parse(giochuan12), form["txthoten"].ToString(), form["txtdiachi"].ToString().Trim());

            //    Response.Redirect("/thankyou?LandingSuckhoeTQ", true);

            //}
            //catch (Exception ex)
            //{

            //}




            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LandingMPTX(MEDLATEC2019.Models.MPTXViewModel obj)
        {

            try
            {
                this.ViewBag.GetDichvu = Common.GetDichvu();

                if (!string.IsNullOrEmpty(obj.txthoten))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập tên bạn');</script>";
                    return View();

                }

                if (!string.IsNullOrEmpty(obj.txtdt))
                {
                    if (IsNumeric(obj.txtdt.Trim()))
                    {

                        if ((obj.txtdt.Trim().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện thoại phải là 10 số.');</script>";
                            return View();
                        }
                    }

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập số điện thoại');</script>";
                    return View();

                }

                string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2") + " " + DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":00";


                int idgoi = 0;
                string magoi = "";
                string tengoi = "";
                if (obj.Dichvu.Trim() == "20KMTGTX")
                {
                    idgoi = 2758;
                    tengoi = "MIEN PHI SIEU AM TUYEN GIAP";
                    magoi = "20KMTGTX";
                }
                if (obj.Dichvu.Trim() == "20KMATX")
                {
                    idgoi = 2757;
                    tengoi = "MIEN PHI AFP";
                    magoi = "20KMATX";
                }
                CMS_Core.Common.Common.DatGoiKham(idgoi, magoi, tengoi, DateTime.Parse(abc), obj.txtdt.ToString().Trim(), DateTime.Parse(abc), DateTime.Parse(abc), DateTime.Parse(abc), obj.txthoten.Trim(), "");

                Response.Redirect("/thankyou?u=LandingMPTX", true);

            }
            catch (Exception ex)
            {

            }




            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult udaiksk(MEDLATEC2019.Models.MPTXViewModel obj)
        {

            try
            {
                this.ViewBag.GetDichvu = Common.GetDichvu();

                if (!string.IsNullOrEmpty(obj.txthoten))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập tên bạn');</script>";
                    return View();

                }

                if (!string.IsNullOrEmpty(obj.txtdt))
                {
                    if (IsNumeric(obj.txtdt.Trim()))
                    {

                        if ((obj.txtdt.Trim().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện thoại phải là 10 số.');</script>";
                            return View();
                        }
                    }

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập số điện thoại');</script>";
                    return View();

                }

                string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2") + " " + DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":00";


                int idgoi = 0;
                string magoi = "";
                string tengoi = "";

                idgoi = 2996;
                tengoi = "2020 Km G50% Gói Khám Tại Nhà 2";
                magoi = "20KMGKTN2";

                if (!string.IsNullOrEmpty(obj.txtAddress))
                {
                    obj.txtAddress = string.Empty;
                }

                CMS_Core.Common.Common.DatGoiKham(idgoi, magoi, tengoi, DateTime.Parse(abc), obj.txtdt.ToString().Trim(), DateTime.Parse(abc), DateTime.Parse(abc), DateTime.Parse(abc), obj.txthoten.Trim(), obj.txtAddress.Trim());

                Response.Redirect("/thankyou?u=udaiksk", true);

            }
            catch (Exception ex)
            {

            }




            return View();
        }


        #region landing xét nghiệm tầm soát nguy cơ ut gan

        public ActionResult LandingXNTSUTGan()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LandingXNTSUTGan(ATPXetnghiemGanModel model)
        {
            try
            {
                string msg = "";

                if (string.IsNullOrEmpty(model.Name))
                    msg = "Mời bạn nhập Họ và tên<br/>";
                if (string.IsNullOrEmpty(model.Phone))
                    msg += "Mời bạn nhập số điện thoại<br/>";
                if (model.Date <= DateTime.MinValue)
                    msg += "Mời bạn chọn ngày đặt lịch<br/>";
                if (model.idGoi <= 0)
                    msg += "Mời bạn chọn địa điểm";

                if (!string.IsNullOrEmpty(msg))
                {
                    TempData["msg"] = "<script type=\"text/javascript\">zebra_alert('Thông báo','" + msg + @"');</script>";
                    return View(model);
                }
                else
                {
                    List<tbl_logLanding> logLandings = sQLServer.SelectQueryCommand("tbl_logLanding_selectBySDT", Common.getConnectionString(), model.Phone.Trim(), model.Magoi);
                    if (logLandings != null)
                        if (logLandings.Count > 0)
                        {
                            msg = " Số điện thoại đã đăng ký rồi mời bạn dùng SĐT khác";

                            TempData["msg"] = "<script type=\"text/javascript\">zebra_alert('Thông báo','" + msg + @"');</script>";
                            return View(model);


                        }


                    string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2") + " " + DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":00";
                    string tengoi = string.Empty;

                    if ("21KDTT3".Equals(model.Magoi.Trim()))
                        tengoi = "MP AFP TẠI HUẾ";

                    if ("21KDTT4".Equals(model.Magoi.Trim()))
                        tengoi = "MP AFP TẠI ĐÀ NẴNG";

                    if ("21KDTT5".Equals(model.Magoi.Trim()))
                        tengoi = "MP AFP TẠI HCM,CT";


                    if ("21KDTT6".Equals(model.Magoi.Trim()))
                        tengoi = "MP AFP TẠI HÀ NỘI";


                    CMS_Core.Common.Common.DatGoiKham(model.idGoi,
                            model.Magoi, tengoi,
                            DateTime.Parse(abc),
                            model.Phone.Trim(),
                           DateTime.Parse(abc),
                           DateTime.Parse(abc),
                           DateTime.Parse(abc),
                            model.Name, "");


                    string result = sQLServer.ExecuteInsert("tbl_logLanding_Insert", model.Phone.Trim(), "", model.Name, "", Common.GetIPHelper(), model.Magoi, model.Name);


                    Response.Redirect("/thankyou5?u=/xet-nghiem-tam-soat-nguy-co-ung-thu-gan", true);
                }

            }
            catch (Exception ex)
            {
                Common.AddToLogFile("LandingXNTSUTGan Loi he thong: " + ex.Message);
            }

            return View(model);
        }

        #endregion



        #region landing nội soi tiêu hóa 

        public ActionResult LandingNoiSoiTieuHoa()
        {
            ATPXetnghiemGanModel model = new ATPXetnghiemGanModel();
            model.Date = DateTime.Now;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LandingNoiSoiTieuHoa(ATPXetnghiemGanModel model)
        {
            try
            {
                string msg = "";

                if (string.IsNullOrEmpty(model.Name))
                    msg = "Mời bạn nhập Họ và tên<br/>";
                if (string.IsNullOrEmpty(model.Phone))
                    msg += "Mời bạn nhập số điện thoại<br/>";
                else if (!string.IsNullOrEmpty(model.Phone) && !Global.Utils.IsPhoneNumber(model.Phone))
                    msg += "Số điện thoại không đúng định dạng<br/>";
                if (model.Date < DateTime.Now.AddDays(-1))
                    msg += "Mời bạn chọn ngày đặt lịch<br/>";
                if (model.idGoi <= 0)
                    msg += "Mời bạn chọn gói khám";

                List<tbl_logLanding> logLandings = sQLServer.SelectQueryCommand("tbl_logLanding_selectBySDT", Common.getConnectionString(), model.Phone.Trim(), model.Magoi);
                if (logLandings != null)
                    if (logLandings.Count > 0)
                    {
                        msg = " Số điện thoại đã đăng ký rồi mời bạn dùng SĐT khác";
                        ViewBag.Data = model;
                        TempData["msg"] = "<script type=\"text/javascript\">zebra_alert('Thông báo','" + msg + @"');</script>";
                        return View(model);

                    }


                if (!string.IsNullOrEmpty(msg))
                {
                    TempData["msg"] = "<script type=\"text/javascript\">zebra_alert('Thông báo','" + msg + @"');</script>";
                    ViewBag.Data = model;
                    return View(model);
                }
                else
                {
                    string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2") + " " + DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":00";

                    CMS_Core.Common.Common.DatGoiKham(model.idGoi,
                        model.Magoi, model.Tengoi,
                        DateTime.Parse(abc),
                        model.Phone.Trim(),
                        model.Date,
                        DateTime.Parse(abc),
                        DateTime.Parse(abc),
                        model.Name, "", model.Donvi);
                    string result = sQLServer.ExecuteInsert("tbl_logLanding_Insert", model.Phone.Trim(), "", model.Name, "", Common.GetIPHelper(), model.Magoi, model.Name);


                    Response.Redirect("/thankyou5?u=/noi-soi-tieu-hoa", true);


                }


            }
            catch (Exception ex)
            {

            }
            ViewBag.Data = model;
            return View(model);
        }

        #endregion


        public ActionResult xuanmoi2021()
        {
            MEDLATEC2019.Models.MPTXViewModel obj = new Models.MPTXViewModel();
            obj.txtAddress = string.Empty;
            obj.txtdt = string.Empty;
            obj.txthoten = string.Empty;
            obj.txtEmail = string.Empty;
            obj.txtnote = string.Empty;
            obj.txtError = string.Empty;


            return View(obj);
        }



        public ActionResult kyniem25()
        {
            MEDLATEC2019.Models.MPTXViewModel obj = new Models.MPTXViewModel();
            obj.txtAddress = string.Empty;
            obj.txtdt = string.Empty;
            obj.txthoten = string.Empty;
            obj.txtEmail = string.Empty;
            obj.txtnote = string.Empty;
            obj.txtError = string.Empty;

            this.ViewBag.GetDichvu = Common.Getkyniem25();

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult kyniem25(MEDLATEC2019.Models.MPTXViewModel obj)
        {

            try
            {
                this.ViewBag.GetDichvu = Common.Getkyniem25();

                if (string.IsNullOrEmpty(obj.txthoten))
                {
                    obj.txtError = "Mời bạn nhập họ và tên!";
                    return View(obj);
                }

                if (string.IsNullOrEmpty(obj.noidung))
                {
                    obj.txtError = "Mời bạn nhập mã nhân viên!";
                    return View(obj);
                }

                if (string.IsNullOrEmpty(obj.Dichvu))
                {
                    obj.txtError = "Mời  bạn chọn đơn vị/ phòng ban!";
                    return View(obj);
                }

                Common.ImportLandingKyniem25(obj.txthoten, obj.noidung, obj.Dichvu);
                Response.Redirect("/thankyou3?u=kyniem25", true);



            }
            catch (Exception ex)
            {

            }




            return View(obj);
        }


        public ActionResult benhlycoban()
        {
            MEDLATEC2019.Models.MPTXViewModel obj = new Models.MPTXViewModel();
            obj.txtAddress = string.Empty;
            obj.txtdt = string.Empty;
            obj.txthoten = string.Empty;
            obj.txtEmail = string.Empty;
            obj.txtnote = string.Empty;
            obj.txtError = string.Empty;
            this.ViewBag.GetDichvu = Common.benhlycoban();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult benhlycoban(MEDLATEC2019.Models.MPTXViewModel obj)
        {

            try
            {
                this.ViewBag.GetDichvu = Common.benhlycoban();

                if (string.IsNullOrEmpty(obj.txthoten))
                {
                    obj.txtError = "Mời bạn nhập họ và tên!";
                    return View(obj);
                }

                if (string.IsNullOrEmpty(obj.txtdt))
                {
                    obj.txtError = "Mời bạn nhập số điện thoại!";
                    return View(obj);
                }

                if (string.IsNullOrEmpty(obj.Dichvu))
                {
                    obj.txtError = "Mời bạn chọn địa điểm sử dụng dịch vụ!";
                    return View(obj);
                }

                DateTime Tungay = new DateTime();

                if (string.IsNullOrEmpty(obj.txtnote))
                {
                    obj.txtError = "Mời  bạn chọn thời gian!";
                    return View(obj);
                }
                else
                {
                    try
                    {
                        Tungay = DateTime.ParseExact(obj.txtnote, "dd/MM/yyyy", new CultureInfo("en-US"));

                        if (Tungay < DateTime.Now.AddDays(-1))
                        {
                            obj.txtError = "Ngày khám phải lớn hơn ngày hiện tại!";
                            return View(obj);
                        }
                        if (Tungay > DateTime.Now.AddMonths(4))
                        {
                            obj.txtError = "Ngày khám lớn hơn 4 tháng so với ngày hiện tại!";
                            return View(obj);
                        }
                    }
                    catch
                    {
                        obj.txtError = "Mời  bạn chọn thời gian!";
                        return View(obj);
                    }

                }

                string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2") + " " + DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":00";

                int idgoi = 0;
                string magoi = "";
                string tengoi = "";
                if ("1".Equals(obj.Dichvu.Trim()))
                {
                    idgoi = 3234;
                    tengoi = "2021 Hà Nội, Vĩnh Phúc MP kiểm tra bệnh lý cơ bản về máu và men gan";
                    magoi = "21KDT3G1";
                }
                if ("2".Equals(obj.Dichvu.Trim()))
                {
                    idgoi = 3235;
                    tengoi = "2021 Bắc Ninh MP kiểm tra bệnh lý cơ bản về máu và men gan";
                    magoi = "21KDT3G2";
                }
                if ("5".Equals(obj.Dichvu.Trim()))
                {
                    idgoi = 3239;
                    tengoi = "2021 HCM, Cần Thơ MP kiểm tra bệnh lý cơ bản về máu và men gan";
                    magoi = "21KDT3G3";
                }
                if ("4".Equals(obj.Dichvu.Trim()))
                {
                    idgoi = 3236;
                    tengoi = "2021 Huế MP kiểm tra bệnh lý cơ bản về máu và men gan";
                    magoi = "21KDT3G4";
                }

                if ("3".Equals(obj.Dichvu.Trim()))
                {
                    idgoi = 3237;
                    tengoi = "2021 Đà Nẵng MP kiểm tra bệnh lý cơ bản về máu và men gan ";
                    magoi = "21KDT3G5";
                }

                if ("6".Equals(obj.Dichvu.Trim()))
                {
                    idgoi = 3238;
                    tengoi = "2021 MP kiểm tra bệnh lý cơ bản về máu và men gan ";
                    magoi = "21KDT3G6";
                }


                if (string.IsNullOrEmpty(obj.txtAddress))
                    obj.txtAddress = string.Empty;

                List<tbl_logLanding> logLandings = sQLServer.SelectQueryCommand("tbl_logLanding_selectBySDT", Common.getConnectionString(), obj.txtdt.ToString().Trim(), magoi);
                if (logLandings != null)
                    if (logLandings.Count > 0)
                    {
                        obj.txtError = "Số điện thoại đã đăng ký rồi mời bạn dùng SĐT khác";
                        return View(obj);
                    }

                CMS_Core.Common.Common.DatGoiKham(idgoi, magoi, tengoi, DateTime.Parse(abc), obj.txtdt.ToString().Trim(), DateTime.Parse(abc), DateTime.Parse(abc), DateTime.Parse(abc), obj.txthoten.Trim(), obj.txtAddress.Trim());
                string result = sQLServer.ExecuteInsert("tbl_logLanding_Insert", obj.txtdt.ToString().Trim(), obj.txtEmail, obj.txtnote, obj.txtAddress, Common.GetIPHelper(), magoi, obj.txthoten.Trim());

                Response.Redirect("/Thankyou4?u=benhlycoban", true);




            }
            catch (Exception ex)
            {

            }




            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult xuanmoi2021(MEDLATEC2019.Models.MPTXViewModel obj)
        {

            try
            {
                this.ViewBag.GetDichvu = Common.GetDichvu();

                if (!string.IsNullOrEmpty(obj.txthoten))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập tên bạn');</script>";
                    return View();

                }

                if (!string.IsNullOrEmpty(obj.txtdt))
                {
                    if (IsNumeric(obj.txtdt.Trim()))
                    {

                        if ((obj.txtdt.Trim().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện thoại phải là 10 số.');</script>";
                            return View();
                        }
                    }

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập số điện thoại');</script>";
                    return View();

                }

                string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2") + " " + DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":00";


                int idgoi = 0;
                string magoi = "";
                string tengoi = "";

                idgoi = 3188;
                tengoi = "21 MP GÓI XN TẾT 2021";
                magoi = "21KDTT1";

                if (!string.IsNullOrEmpty(obj.txtAddress))
                {
                    obj.txtAddress = string.Empty;
                }

                CMS_Core.Common.Common.DatGoiKham(idgoi, magoi, tengoi, DateTime.Parse(abc), obj.txtdt.ToString().Trim(), DateTime.Parse(abc), DateTime.Parse(abc), DateTime.Parse(abc), obj.txthoten.Trim(), obj.txtAddress.Trim());

                Response.Redirect("/thankyou?u=xuanmoi2021", true);

            }
            catch (Exception ex)
            {

            }




            return View(obj);
        }

        public ActionResult LandingHNKH2020Value()
        {
            SQLServerConnection<tbl_hoinghi> sQLServer1 = new SQLServerConnection<tbl_hoinghi>();
            List<tbl_hoinghi> hoinghis = sQLServer1.SelectQueryCommand("SP_tbl_hoinghi_Select", Common.getConnectionString());
            ViewBag.hoinghis = hoinghis;

            return View();
        }



        //public ActionResult LandingHNKH2020()
        //{
        //    MEDLATEC2019.Models.HoiNghiViewModel obj = new Models.HoiNghiViewModel();
        //    obj.hoinghi = new tbl_hoinghi();
        //    obj.hoinghi.Content = string.Empty;
        //    obj.hoinghiCauHoi = new tbl_hoinghiCauHoi();
        //    obj.hoinghiCauHoi.hoten = string.Empty;
        //    obj.hoinghiCauHoi.mobile = string.Empty;
        //    obj.hoinghiCauHoi.nghenghiep = string.Empty;
        //    obj.hoinghiCauHoi.email = string.Empty;
        //    obj.hoinghiCauHoi.donvi = string.Empty;
        //    obj.hoinghiCauHoi.chuyenkhoa = string.Empty;
        //    obj.hoinghiCauHoi.cau9 = string.Empty;
        //    obj.hoinghiCauHoi.cau14 = string.Empty;
        //    obj.hoinghiCauHoi.cau13 = string.Empty;
        //    obj.hoinghiCauHoi.cau11 = string.Empty;
        //    obj.hoinghiCauHoi.cau81 = false;
        //    obj.hoinghiCauHoi.cau82 = false;
        //    obj.hoinghiCauHoi.cau83 = false;
        //    obj.hoinghiCauHoi.cau84 = false;
        //    obj.hoinghiCauHoi.cau85 = false;
        //    obj.hoinghiCauHoi.cau101 = false;
        //    obj.hoinghiCauHoi.cau102 = false;
        //    obj.hoinghiCauHoi.cau103 = false;
        //    obj.hoinghiCauHoi.cau104 = false;
        //    obj.hoinghiCauHoi.cau105 = false;
        //    obj.hoinghiCauHoi.cau121 = false;
        //    obj.hoinghiCauHoi.cau122 = false;
        //    obj.hoinghiCauHoi.cau123 = false;
        //    obj.hoinghiCauHoi.cau124 = false;


        //    obj.txtError = string.Empty;
        //    obj.txtError2 = string.Empty;


        //    return View(obj);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult LandingHNKH2020(MEDLATEC2019.Models.HoiNghiViewModel obj, string submit)
        //{

        //    try
        //    {
        //        switch (submit)
        //        {
        //            case "question":

        //                var errorsSave = obj.hoinghi.Validate(new ValidationContext(obj.hoinghi));
        //                if (errorsSave.ToList().Count == 0)
        //                {
        //                    Common.ImportLandingHNKH2020(obj.hoinghi.Content);
        //                    Response.Redirect("/thankyou1?u=LandingHNKH2020", true);
        //                }
        //                else
        //                {
        //                    obj.txtError = errorsSave.ToList()[0].ErrorMessage;
        //                }

        //                break;
        //            case "answer":

        //                var errorsSave1 = obj.hoinghiCauHoi.Validate(new ValidationContext(obj.hoinghiCauHoi));
        //                if (errorsSave1.ToList().Count == 0)
        //                {

        //                    if (obj.hoinghiCauHoi.cau8 == "1")
        //                        obj.hoinghiCauHoi.cau8 = "Rất hài lòng";
        //                    if (obj.hoinghiCauHoi.cau8 == "2")
        //                        obj.hoinghiCauHoi.cau8 = "Hài lòng";
        //                    if (obj.hoinghiCauHoi.cau8 == "3")
        //                        obj.hoinghiCauHoi.cau8 = "Bình thường";
        //                    if (obj.hoinghiCauHoi.cau8 == "4")
        //                        obj.hoinghiCauHoi.cau8 = "Không hài lòng";
        //                    if (obj.hoinghiCauHoi.cau8 == "5")
        //                        obj.hoinghiCauHoi.cau8 = "Rất không hài lòng";
        //                    if (string.IsNullOrEmpty(obj.hoinghiCauHoi.cau8))
        //                        obj.hoinghiCauHoi.cau8 = string.Empty;


        //                    if (obj.hoinghiCauHoi.cau10 == "1")
        //                        obj.hoinghiCauHoi.cau10 = "Rất hài lòng";
        //                    if (obj.hoinghiCauHoi.cau10 == "2")
        //                        obj.hoinghiCauHoi.cau10 = "Hài lòng";
        //                    if (obj.hoinghiCauHoi.cau10 == "3")
        //                        obj.hoinghiCauHoi.cau10 = "Bình thường";
        //                    if (obj.hoinghiCauHoi.cau10 == "4")
        //                        obj.hoinghiCauHoi.cau10 = "Không hài lòng";
        //                    if (obj.hoinghiCauHoi.cau10 == "5")
        //                        obj.hoinghiCauHoi.cau10 = "Rất không hài lòng";

        //                    if (string.IsNullOrEmpty(obj.hoinghiCauHoi.cau9))
        //                        obj.hoinghiCauHoi.cau9 = string.Empty;

        //                    if (string.IsNullOrEmpty(obj.hoinghiCauHoi.cau10))
        //                        obj.hoinghiCauHoi.cau10 = string.Empty;

        //                    if (string.IsNullOrEmpty(obj.hoinghiCauHoi.cau11))
        //                        obj.hoinghiCauHoi.cau11 = string.Empty;

        //                    if (obj.hoinghiCauHoi.cau121 == true)
        //                        obj.hoinghiCauHoi.cau12 = "MedOn - Giải pháp Y tế số cho Bác sĩ và người bệnh";
        //                    if (obj.hoinghiCauHoi.cau122 == true)
        //                        if (!string.IsNullOrEmpty(obj.hoinghiCauHoi.cau12))
        //                        {
        //                            if (obj.hoinghiCauHoi.cau12.Length > 0)
        //                            {
        //                                obj.hoinghiCauHoi.cau12 = obj.hoinghiCauHoi.cau12 + "; Nền tảng công nghệ giúp tăng tốc hành trình chuyển đổi số trong lĩnh vực y tế";
        //                            }
        //                            else
        //                            {
        //                                obj.hoinghiCauHoi.cau12 = "Nền tảng công nghệ giúp tăng tốc hành trình chuyển đổi số trong lĩnh vực y tế";
        //                            }
        //                        }
        //                        else
        //                        {
        //                            obj.hoinghiCauHoi.cau12 = "Nền tảng công nghệ giúp tăng tốc hành trình chuyển đổi số trong lĩnh vực y tế";
        //                        }

        //                    if (obj.hoinghiCauHoi.cau123 == true)
        //                        if (!string.IsNullOrEmpty(obj.hoinghiCauHoi.cau12))
        //                        {
        //                            if (obj.hoinghiCauHoi.cau12.Length > 0)
        //                            {
        //                                obj.hoinghiCauHoi.cau12 = obj.hoinghiCauHoi.cau12 + "; Sàng lọc, chẩn đoán trước sinh và sau sinh: vì 1 tương lai khỏe mạnh";
        //                            }
        //                            else
        //                            {
        //                                obj.hoinghiCauHoi.cau12 = "Sàng lọc, chẩn đoán trước sinh và sau sinh: vì 1 tương lai khỏe mạnh";
        //                            }
        //                        }
        //                        else
        //                        {
        //                            obj.hoinghiCauHoi.cau12 = "Sàng lọc, chẩn đoán trước sinh và sau sinh: vì 1 tương lai khỏe mạnh";
        //                        }

        //                    if (obj.hoinghiCauHoi.cau124 == true)
        //                        if (!string.IsNullOrEmpty(obj.hoinghiCauHoi.cau12))
        //                        {
        //                            if (obj.hoinghiCauHoi.cau12.Length > 0)
        //                            {
        //                                obj.hoinghiCauHoi.cau12 = obj.hoinghiCauHoi.cau12 + "; Vi chất dinh dưỡng với sức khỏe";
        //                            }
        //                            else
        //                            {
        //                                obj.hoinghiCauHoi.cau12 = "Vi chất dinh dưỡng với sức khỏe";
        //                            }
        //                        }
        //                        else
        //                        {
        //                            obj.hoinghiCauHoi.cau12 = "Vi chất dinh dưỡng với sức khỏe";
        //                        }

        //                    if (string.IsNullOrEmpty(obj.hoinghiCauHoi.cau12))
        //                        obj.hoinghiCauHoi.cau12 = string.Empty;
        //                    if (string.IsNullOrEmpty(obj.hoinghiCauHoi.cau13))
        //                        obj.hoinghiCauHoi.cau13 = string.Empty;
        //                    if (string.IsNullOrEmpty(obj.hoinghiCauHoi.cau14))
        //                        obj.hoinghiCauHoi.cau14 = string.Empty;


        //                    Common.ImportLandingHNKH2020Cautraloi(obj.hoinghiCauHoi.hoten, obj.hoinghiCauHoi.namsinh, obj.hoinghiCauHoi.mobile, obj.hoinghiCauHoi.nghenghiep, obj.hoinghiCauHoi.email, obj.hoinghiCauHoi.donvi, obj.hoinghiCauHoi.chuyenkhoa, obj.hoinghiCauHoi.cau8, obj.hoinghiCauHoi.cau9, obj.hoinghiCauHoi.cau10, obj.hoinghiCauHoi.cau11, obj.hoinghiCauHoi.cau12, obj.hoinghiCauHoi.cau13, obj.hoinghiCauHoi.cau14);
        //                    Response.Redirect("/thankyou1?u=LandingHNKH2020", true);
        //                }
        //                else
        //                {
        //                    obj.txtError2 = errorsSave1.ToList()[0].ErrorMessage;
        //                }

        //                break;

        //        }




        //        //  CMS_Core.Common.Common.DatGoiKham(idgoi, magoi, tengoi, DateTime.Parse(abc), obj.txtdt.ToString().Trim(), DateTime.Parse(abc), DateTime.Parse(abc), DateTime.Parse(abc), obj.txthoten.Trim(), obj.txtAddress.Trim());



        //    }
        //    catch (Exception ex)
        //    {

        //    }




        //    return View(obj);
        //}



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult nipt(MEDLATEC2019.Models.MPTXViewModel obj)
        {

            try
            {
                this.ViewBag.GetDichvu = Common.GetDichvuNIPT();

                if (!string.IsNullOrEmpty(obj.txthoten))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập tên bạn');</script>";
                    return View();

                }

                if (!string.IsNullOrEmpty(obj.txtdt))
                {
                    if (IsNumeric(obj.txtdt.Trim()))
                    {

                        if ((obj.txtdt.Trim().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện thoại phải là 10 số.');</script>";
                            return View();
                        }
                    }

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập số điện thoại');</script>";
                    return View();

                }

                if (!string.IsNullOrEmpty(obj.Dichvu))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn chọn dịch vụ');</script>";
                    return View();

                }

                if (string.IsNullOrEmpty(obj.txtAddress))
                {
                    obj.txtAddress = string.Empty;
                }

                string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2") + " " + DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":00";



                int idgoi = 0;
                string magoi = "";
                string tengoi = "";
                if ("20KMNIBA".Equals(obj.Dichvu.Trim()))
                {
                    idgoi = 2761;
                    tengoi = "2020 CHTRINH NIPT-BASICSAVE";
                    magoi = "20KMNIBA";
                }
                if ("20KMNIPO".Equals(obj.Dichvu.Trim()))
                {
                    idgoi = 2762;
                    tengoi = "2020 CHTRINH NIPT-PROSAVE";
                    magoi = "20KMNIPO";
                }
                if ("18820NIPTBA".Equals(obj.Dichvu.Trim()))
                {
                    idgoi = 2757;
                    tengoi = "2020 CHTRINH NIPT-BasicSave";
                    magoi = "18820NIPTBA";
                }
                if ("18820NIPTPO".Equals(obj.Dichvu.Trim()))
                {
                    idgoi = 2757;
                    tengoi = "2020 CHTRINH NIPT-ProSave";
                    magoi = "18820NIPTPO";
                }

                if (string.IsNullOrEmpty(obj.txtAddress))
                    obj.txtAddress = string.Empty;

                CMS_Core.Common.Common.DatGoiKham(idgoi, magoi, tengoi, DateTime.Parse(abc), obj.txtdt.ToString().Trim(), DateTime.Parse(abc), DateTime.Parse(abc), DateTime.Parse(abc), obj.txthoten.Trim(), obj.txtAddress.Trim());

                Response.Redirect("/thankyou?u=nipt", true);

            }
            catch (Exception ex)
            {

            }




            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult niptNew(MEDLATEC2019.Models.MPTXViewModel obj)
        {

            try
            {
                this.ViewBag.GetDichvu = Common.GetDichvuNIPTNew();

                if (!string.IsNullOrEmpty(obj.txthoten))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập tên bạn');</script>";
                    return View();

                }

                if (!string.IsNullOrEmpty(obj.txtdt))
                {
                    if (IsNumeric(obj.txtdt.Trim()))
                    {

                        if ((obj.txtdt.Trim().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện thoại phải là 10 số.');</script>";
                            return View();
                        }
                    }

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập số điện thoại');</script>";
                    return View();

                }

                if (!string.IsNullOrEmpty(obj.Dichvu))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn chọn dịch vụ');</script>";
                    return View();

                }

                if (string.IsNullOrEmpty(obj.txtAddress))
                {
                    obj.txtAddress = string.Empty;
                }

                string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2") + " " + DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":00";



                int idgoi = 0;
                string magoi = "";
                string tengoi = "";
                if ("21KDTT16".Equals(obj.Dichvu.Trim()))
                {
                    idgoi = 3396;
                    tengoi = "NIPT BASIC 6 ngày (21KDTT16)";
                    magoi = "21KDTT16";
                }
                if ("21KDTT17".Equals(obj.Dichvu.Trim()))
                {
                    idgoi = 3397;
                    tengoi = "NIPT PRO 6 ngày (21KDTT17)";
                    magoi = "21KDTT17";
                }
                if ("21KDTT18".Equals(obj.Dichvu.Trim()))
                {
                    idgoi = 3398;
                    tengoi = "NIPT PLUS (21KDTT18)";
                    magoi = "21KDTT18";
                }
                if ("21KDTT19".Equals(obj.Dichvu.Trim()))
                {
                    idgoi = 3399;
                    tengoi = "NIPT TWIN (21KDTT19)";
                    magoi = "21KDTT19";
                }

                if ("21KDTT20".Equals(obj.Dichvu.Trim()))
                {
                    idgoi = 3400;
                    tengoi = "NIPT BASIC 4 ngày (21KDTT20)";
                    magoi = "21KDTT20";
                }

                if ("21KDTT21".Equals(obj.Dichvu.Trim()))
                {
                    idgoi = 3401;
                    tengoi = "NIPT PRO 4 ngày (21KDTT21)";
                    magoi = "21KDTT21";
                }




                if (string.IsNullOrEmpty(obj.txtAddress))
                    obj.txtAddress = string.Empty;

                CMS_Core.Common.Common.DatGoiKham(idgoi, magoi, tengoi, DateTime.Parse(abc), obj.txtdt.ToString().Trim(), DateTime.Parse(abc), DateTime.Parse(abc), DateTime.Parse(abc), obj.txthoten.Trim(), obj.txtAddress.Trim());

                Response.Redirect("/thankyou?u=niptnew", true);

            }
            catch (Exception ex)
            {

            }




            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LandingChuyengia(MEDLATEC2019.Models.MPTXViewModel obj)
        {

            try
            {
                this.ViewBag.GetChuyengia = Common.GetChuyengia();

                if (!string.IsNullOrEmpty(obj.txthoten))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập tên bạn');</script>";
                    return View();

                }

                if (!string.IsNullOrEmpty(obj.Dichvu))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn chọn chuyên gia');</script>";
                    return View();

                }


                if (!string.IsNullOrEmpty(obj.txtdt))
                {
                    if (IsNumeric(obj.txtdt.Trim()))
                    {

                        if ((obj.txtdt.Trim().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện thoại phải là 10 số.');</script>";
                            return View();
                        }
                    }

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập số điện thoại');</script>";
                    return View();

                }

                string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2") + " " + DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":00";


                int idgoi = 0;
                string magoi = "";
                string tengoi = "";
                if (obj.Dichvu.Length > 2)
                {
                    magoi = obj.Dichvu.ToString().Substring(2);

                    if (magoi.Equals("20KMCG1"))
                    {
                        idgoi = 2860;
                        tengoi = "2020 CHTRINH TRUYENF THONG CHUYEN GIA MP HBSAG";
                    }

                    if (magoi.Equals("20KMCG2"))
                    {
                        idgoi = 2861;
                        tengoi = "2020 CHTRINH TRUYENF THONG CHUYEN GIA CT NGỰC PHỔI";
                    }

                    if (magoi.Equals("20KMCG3"))
                    {
                        tengoi = "2020 CHTRINH TRUYENF THONG CHUYEN GIA NSTH";
                        idgoi = 2862;
                    }

                    if (magoi.Equals("20KMCG4"))
                    {
                        idgoi = 2863;
                        tengoi = "2020 CHTRINH TRUYENF THONG CHUYEN GIA HPV";
                    }


                    CMS_Core.Common.Common.DatGoiKham(idgoi, magoi, tengoi, DateTime.Parse(abc), obj.txtdt.ToString().Trim(), DateTime.Parse(abc), DateTime.Parse(abc), DateTime.Parse(abc), obj.txthoten.Trim(), "");
                }
                Response.Redirect("/thankyou?u=LandingChuyengia", false);



            }
            catch (Exception ex)
            {

            }




            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LandingSongkhoe(MEDLATEC2019.Models.MPTXViewModel obj)
        {

            try
            {
                if (!string.IsNullOrEmpty(obj.txthoten))
                {

                }
                else
                {
                    obj.txtError = "Mời bạn nhập tên bạn";
                    // TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    //return RedirectToAction(nameof(Index));
                    return View(obj);

                }

                if (!string.IsNullOrEmpty(obj.txtdt))
                {
                    if (IsNumeric(obj.txtdt.Trim()))
                    {

                        if ((obj.txtdt.Trim().Length != 10))
                        {
                            obj.txtError = "Số điện thoại phải là 10 số";

                            // TempData["msg"] = "<script>alert('Số điện thoại phải là 10 số.');</script>";
                            //return RedirectToAction(nameof(Index));
                            return View(obj);
                        }
                    }

                }
                else
                {
                    obj.txtError = "Mời bạn nhập số điện thoại";
                    //TempData["msg"] = "<script>alert('Mời bạn nhập số điện thoại');</script>";
                    //return RedirectToAction(nameof(Index));
                    return View(obj);

                }

                string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2") + " " + DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":00";


                int idgoi = 0;
                string magoi = "";
                string tengoi = "";


                idgoi = 3137;
                tengoi = "20KMCHOT52  2020 CHTRINH MP CHOLESTEROL - BAN KDTT ";
                magoi = "20KMCHOT52";
                // check sdt tồn tại chưa tbl_logLanding_selectBySDT
                List<tbl_logLanding> logLandings = sQLServer.SelectQueryCommand("tbl_logLanding_selectBySDT", Common.getConnectionString(), obj.txtdt.ToString().Trim(), magoi);
                if (logLandings != null)
                    if (logLandings.Count > 0)
                    {
                        obj.txtError = "Số điện thoại đã đăng ký rồi mời bạn dùng SĐT khác";

                        // TempData["msg"] = "<script>alert('Số điện thoại đã đăng ký rồi mời bạn dùng SĐT khác');</script>";
                        return View(obj);
                    }

                CMS_Core.Common.Common.DatGoiKham(idgoi, magoi, tengoi, DateTime.Parse(abc), obj.txtdt.ToString().Trim(), DateTime.Parse(abc), DateTime.Parse(abc), DateTime.Parse(abc), obj.txthoten.Trim(), "");

                if (string.IsNullOrEmpty(obj.txtAddress))
                {
                    obj.txtAddress = string.Empty;
                }
                if (string.IsNullOrEmpty(obj.txtnote))
                {
                    obj.txtnote = string.Empty;
                }
                if (string.IsNullOrEmpty(obj.txtEmail))
                {
                    obj.txtEmail = string.Empty;
                }
                // chèn log
                string result = sQLServer.ExecuteInsert("tbl_logLanding_Insert", obj.txtdt.ToString().Trim(), obj.txtEmail, obj.txtnote, obj.txtAddress, Common.GetIPHelper(), magoi, obj.txthoten.Trim());

                Response.Redirect("/thankyou?u=LandingSongkhoe", true);

            }
            catch (Exception ex)
            {

            }




            return View();
        }



        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult LandingSieuamthaichudong(FormCollection form)
        {

            try
            {

                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập tên bạn');</script>";
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

                string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2") + " " + DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":00";

                string ngay = form["dllNgayKham"].ToString();
                string thang = form["dllThangKham"].ToString();

                DateTime ngay1 = DateTime.Parse("2020" + "-" + thang + "-" + ngay);
                ngay = "2020" + "-" + ngay1.Month.ToString("d2") + "-" + ngay1.Day.ToString("d2");

                string gio = form["dllGiohen"].ToString();
                string giohen1 = ngay + " " + gio;
                DateTime giochuan1 = DateTime.Parse(giohen1, new CultureInfo("en-US"));

                string giochuan11 = giochuan1.Year.ToString() + "-" + giochuan1.Month.ToString("d2") + "-" + giochuan1.Day.ToString("d2") + " " + giochuan1.Hour.ToString("d2") + ":" + giochuan1.Minute.ToString("d2") + ":00";
                DateTime giochuan2 = DateTime.Parse(giochuan11).AddHours(1);
                string giochuan12 = giochuan2.Year.ToString() + "-" + giochuan2.Month.ToString("d2") + "-" + giochuan2.Day.ToString("d2") + " " + giochuan2.Hour.ToString("d2") + ":" + giochuan2.Minute.ToString("d2") + ":00";
                int idgoi = 0;
                string mact = "";
                string tenct = "";
                if (form["dllGoikham"].ToString().Trim() == "20KMSATH")
                {
                    idgoi = 2720;
                    mact = "20KMSATH";
                    tenct = "Siêu âm thai doppler màu";
                }
                if (form["dllGoikham"].ToString().Trim() == "20KMSATH1")
                {
                    idgoi = 2721;
                    mact = "20KMSATH1";
                    tenct = "Siêu âm thai 4D";
                }
                if (form["dllGoikham"].ToString().Trim() == "20KMSATH2")
                {
                    idgoi = 2722;
                    mact = "20KMSATH2";
                    tenct = "Siêu âm thai 4D (song thai)";
                }
                if (form["dllGoikham"].ToString().Trim() == "20KMSATH3")
                {
                    idgoi = 2723;
                    mact = "20KMSATH3";
                    tenct = "Siêu âm thai doppler màu (song thai)";
                }
                string diachi = "";
                if (form["dllDiadiem"].ToString().Trim() == "ND")
                {
                    diachi = "42 Nghĩa Dũng - Ba Đình - Hà Nội";
                }
                if (form["dllDiadiem"].ToString().Trim() == "TS")
                {
                    diachi = "99 Trích Sài - Tây Hồ - Hà Nội";
                }
                if (form["dllDiadiem"].ToString().Trim() == "TX")
                {
                    diachi = "03 Khuất Duy Tiến - Thanh Xuân - Hà Nội";
                }
                CMS_Core.Common.Common.DatGoiKham(idgoi, mact, tenct, DateTime.Parse(abc), form["txtdt"].ToString().Trim(), DateTime.Parse(ngay), DateTime.Parse(giochuan11), DateTime.Parse(giochuan12), form["txthoten"].ToString(), diachi);

                Response.Redirect("/thankyou?u=LandingSieuamthaichudong", true);

            }
            catch (Exception ex)
            {

            }




            return View();
        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult LandingHotrosuckhoe(FormCollection form)
        {


            try
            {

                if (!string.IsNullOrEmpty(form["txtHoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập tên bạn');</script>";
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
                        TempData["msg"] = "<script>alert('Mời bạn nhập số điện thoại');</script>";
                        return View();
                    }
                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập số điện thoại');</script>";
                    return View();

                }


                SQLServerConnection<Cms_TheTT> sQLServer2 = new SQLServerConnection<Cms_TheTT>();
                List<Cms_TheTT> _Otp = sQLServer2.SelectQueryCommand("OTP_Select", Common.getConnectionString(), form["txtdt"].ToString().Replace(" ", ""), "KSONLINE200T");

                if (_Otp != null)
                {
                    if (_Otp.Count > 0)
                    {
                        TempData["msg"] = "<script>alert('Số điện thoại bạn đã đăng ký chương trình này rồi.Vui lòng kiểm tra lại.Xin cám ơn!');</script>";

                        return View();
                    }
                    else
                    {
                        string diadiem = form["dllNgayhen"].ToString();

                        string giatien = "";
                        string number = "";
                        if (diadiem == "v200")
                        {
                            giatien = "200,000";
                            number = "KSONL200";
                        }
                        if (diadiem == "v300")
                        {
                            giatien = "300,000";
                            number = "KSONL300";
                        }
                        List<Cms_TheTT> _TheTT = new List<Cms_TheTT>();

                        HttpClient http2 = new HttpClient();

                        string baseUrl2 = CMS_Core.Common.Common.getLINKAPI() + "api/Thett/Get_TheTT/?token=" + Common.generalKeyPrivate(number) + "&MaTheTT=" + number;

                        string url2 = baseUrl2;
                        HttpResponseMessage response2 = http2.GetAsync(new Uri(url2)).Result;
                        string responseBody2 = response2.Content.ReadAsStringAsync().Result;
                        var countries2 = JsonConvert.DeserializeObject(responseBody2);

                        JArray jsonResponse2 = JArray.Parse(responseBody2);

                        foreach (var item in jsonResponse2)
                        {
                            Cms_TheTT rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Cms_TheTT>(item.ToString());
                            _TheTT.Add(rowsDoctor);

                        }

                        using (var client = new HttpClient())
                        {
                            try
                            {

                                client.BaseAddress = new Uri(CMS_Core.Common.Common.getLINKAPI());

                                MEDLATEC.BusinessLayer.Cms_TheTT obj = new MEDLATEC.BusinessLayer.Cms_TheTT();
                                obj.Content = "nội dung";
                                obj.dtkh = "8479307930";
                                string hoten = form["txtHoten"].ToString();
                                string sdt = form["txtdt"].ToString();
                                string email = form["txtemail"].ToString();
                                string diachi = form["txtdiachi"].ToString();

                                if (sdt.Substring(0, 1) == "0")
                                {
                                    sdt = sdt.Remove(0, 1);
                                    sdt = "84" + sdt;

                                }
                                object result = string.Empty;

                                string serialisedData = JsonConvert.SerializeObject(obj);

                                string abc = _TheTT[0].SoThe;

                                string contentsms = "MEDLATEC TB Quy khach da nhan duoc 01 the qua tang kiem tra suc khoe tri gia " + giatien + ".Quy khach vui long cung cap ma " + abc.Trim() + " khi su dung dich vu.Xin cam on!";

                                string urlfull = $"{CMS_Core.Common.Common.getLINKAPI()}api/Thett/SendSMS/?token=" + Common.generalKeyPrivate(sdt.Trim()) + "&content=" + contentsms + "&sdt=" + sdt.Trim() + "";
                                HttpContent httpContent = new StringContent(serialisedData);
                                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                HttpResponseMessage message = client.PostAsync(urlfull, httpContent).Result;
                                string urlfull1 = $"{CMS_Core.Common.Common.getLINKAPI()}api/Thett/Update_TheTT?token=" + Common.generalKeyPrivate(abc.Trim()) + "&SoThe=" + abc.Trim() + "";
                                HttpContent httpContent1 = new StringContent(serialisedData);
                                httpContent1.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                HttpResponseMessage message1 = client.PostAsync(urlfull1, httpContent1).Result;
                                string ghichu = "Khách hàng từ chương trình Hỗ trợ chi phí giúp người dân chăm sóc sức khỏe" + number;

                                CMS_Core.Common.Common.DatlichTin(hoten, form["txtdt"].ToString(), ghichu, email, "WebMed Landing Hỗ trợ chăm sóc sức khỏe", number);


                                SqlConnection _conn;
                                _conn = new SqlConnection(ConfigurationManager.AppSettings["Main.ConnectionString"]);
                                _conn.Open();


                                // Info.  
                                string sql = string.Empty;
                                sql = "insert into tbl_OTP(Sodt,OTP) values(";
                                sql += "@Sodt,@OTP)";

                                SqlCommand comd = new SqlCommand(sql, _conn);



                                comd.Parameters.Add("@Sodt", SqlDbType.NVarChar, 15).Value = form["txtdt"].ToString().Replace(" ", "");
                                comd.Parameters.Add("@OTP", SqlDbType.NVarChar, 15).Value = "KSONLINE200T";

                                comd.ExecuteNonQuery();
                                _conn.Close();

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                throw;
                            }
                        }
                    }


                }

                Response.Redirect("/thankyou?u=LandingHotrosuckhoe", false);
            }
            catch (Exception ex)
            {

            }




            return View();
        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Goichamsocskngayle(FormCollection form)
        {


            try
            {

                if (!string.IsNullOrEmpty(form["txtHoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập tên bạn');</script>";
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

                string ngay = form["dllNgayhen"].ToString();



                SqlConnection _conn1;
                _conn1 = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                _conn1.Open();

                string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2") + " " + DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":00";
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



                if (form["dllGoikham"].ToString().Trim() == "1")
                {
                    parameter1 = new SqlParameter("@pIDGoi", SqlDbType.Int);
                    parameter1.Value = 2386;
                    parameter2 = new SqlParameter("@pMaGoi", SqlDbType.VarChar);
                    parameter2.Value = "19BLGM";
                    parameter3 = new SqlParameter("@pTenGoi", SqlDbType.NVarChar);
                    parameter3.Value = "Gói khám kiểm tra sức khỏe GAN - MẬT";
                }
                if (form["dllGoikham"].ToString().Trim() == "2")
                {
                    parameter1 = new SqlParameter("@pIDGoi", SqlDbType.Int);
                    parameter1.Value = 2387;
                    parameter2 = new SqlParameter("@pMaGoi", SqlDbType.VarChar);
                    parameter2.Value = "19BLTB";
                    parameter3 = new SqlParameter("@pTenGoi", SqlDbType.NVarChar);
                    parameter3.Value = "Gói khám sàng lọc nguy cơ gây ĐỘT QUỴ";
                }




                parameter4 = new SqlParameter("@pNgayBan", SqlDbType.DateTime);
                parameter4.Value = abc;
                parameter5 = new SqlParameter("@pTel", SqlDbType.VarChar);
                parameter5.Value = form["txtdt"].ToString().Trim();

                DateTime ngay1 = DateTime.Parse(ngay);
                ngay = ngay1.Year.ToString() + "-" + ngay1.Month.ToString("d2") + "-" + ngay1.Day.ToString("d2");
                parameter6 = new SqlParameter("@pNgayKham", SqlDbType.DateTime);
                parameter6.Value = ngay;
                string gio = form["dllGiohen"].ToString();
                string giohen1 = ngay + " " + gio;
                DateTime giochuan1 = DateTime.Parse(giohen1, new CultureInfo("en-US"));

                string giochuan11 = giochuan1.Year.ToString() + "-" + giochuan1.Month.ToString("d2") + "-" + giochuan1.Day.ToString("d2") + " " + giochuan1.Hour.ToString("d2") + ":" + giochuan1.Minute.ToString("d2") + ":00";

                parameter7 = new SqlParameter("@pGioHen1", SqlDbType.DateTime);
                parameter7.Value = giochuan11;


                DateTime giochuan2 = DateTime.Parse(giochuan11).AddHours(1);
                string giochuan12 = giochuan2.Year.ToString() + "-" + giochuan2.Month.ToString("d2") + "-" + giochuan2.Day.ToString("d2") + " " + giochuan2.Hour.ToString("d2") + ":" + giochuan2.Minute.ToString("d2") + ":00";


                parameter8 = new SqlParameter("@pGioHen2", SqlDbType.DateTime);
                parameter8.Value = giochuan12;


                parameter9 = new SqlParameter("@pNguoiMua", SqlDbType.NVarChar);
                parameter9.Value = form["txtHoten"].ToString();







                SQLHelper.SqlHelper.ExecuteNonQuery(_conn1, CommandType.StoredProcedure, "GoiKhamCTBan_Toan", parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7, parameter9);
                _conn1.Close();



                Response.Redirect("/thankyou?u=LandingHotrosuckhoe", true);
            }
            catch (Exception ex)
            {

            }




            return View();
        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult LandingCEA2019(FormCollection form)
        {


            try
            {

                if (!string.IsNullOrEmpty(form["txtHoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập tên bạn');</script>";
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

                string ngay = form["dllNgayhen"].ToString();



                SqlConnection _conn1;
                _conn1 = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                _conn1.Open();

                string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2") + " " + DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":00";
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

                parameter1 = new SqlParameter("@pIDGoi", SqlDbType.Int);
                parameter1.Value = 2257;
                parameter2 = new SqlParameter("@pMaGoi", SqlDbType.VarChar);
                parameter2.Value = "19MPPNVN";
                parameter3 = new SqlParameter("@pTenGoi", SqlDbType.NVarChar);
                parameter3.Value = "Miễn Phí Cea";



                parameter4 = new SqlParameter("@pNgayBan", SqlDbType.DateTime);
                parameter4.Value = abc;
                parameter5 = new SqlParameter("@pTel", SqlDbType.VarChar);
                parameter5.Value = form["txtdt"].ToString().Trim();

                DateTime ngay1 = DateTime.Parse(ngay);
                ngay = ngay1.Year.ToString() + "-" + ngay1.Month.ToString("d2") + "-" + ngay1.Day.ToString("d2");
                parameter6 = new SqlParameter("@pNgayKham", SqlDbType.DateTime);
                parameter6.Value = ngay;
                string gio = form["dllGiohen"].ToString();
                string giohen1 = ngay + " " + gio;
                DateTime giochuan1 = DateTime.Parse(giohen1, new CultureInfo("en-US"));

                string giochuan11 = giochuan1.Year.ToString() + "-" + giochuan1.Month.ToString("d2") + "-" + giochuan1.Day.ToString("d2") + " " + giochuan1.Hour.ToString("d2") + ":" + giochuan1.Minute.ToString("d2") + ":00";

                parameter7 = new SqlParameter("@pGioHen1", SqlDbType.DateTime);
                parameter7.Value = giochuan11;


                DateTime giochuan2 = DateTime.Parse(giochuan11).AddHours(1);
                string giochuan12 = giochuan2.Year.ToString() + "-" + giochuan2.Month.ToString("d2") + "-" + giochuan2.Day.ToString("d2") + " " + giochuan2.Hour.ToString("d2") + ":" + giochuan2.Minute.ToString("d2") + ":00";


                parameter8 = new SqlParameter("@pGioHen2", SqlDbType.DateTime);
                parameter8.Value = giochuan12;


                parameter9 = new SqlParameter("@pNguoiMua", SqlDbType.NVarChar);
                parameter9.Value = form["txtHoten"].ToString();


                parameter10 = new SqlParameter("@pDiaChi", SqlDbType.NVarChar);
                parameter10.Value = form["txtdiachi"].ToString().Trim();

                parameter11 = new SqlParameter("@pEmail", SqlDbType.NVarChar);
                parameter11.Value = form["txtemail"].ToString();



                //  SQLHelper.SqlHelper.ExecuteNonQuery(_conn1, CommandType.StoredProcedure, "GoiKhamCTBan_Toan", parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7,parameter9, parameter10,parameter11);
                _conn1.Close();

                //SqlConnection _conn;
                //_conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                //_conn.Open();
                //// Info.  
                //string sql = string.Empty;
                //sql = "insert into Datlich(tenkh,sodt,ngayhen,email,address,ghichu,tinhtrang,Ghichudv,PLDL) values(";
                //sql += "@hoten,@sdt,@ngayhen,@email,@address,@ghichu,0,N'WebMed - Landing xét nghiệm miễn phí CEA 2019','CEA2019')";


                //SqlCommand comd = new SqlCommand(sql, _conn);


                ////  string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");


                //comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                //comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 11).Value = form["txtdt"].ToString();
                //comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                //comd.Parameters.AddWithValue("@email", SqlDbType.DateTime).Value = form["txtemail"].ToString();
                //comd.Parameters.AddWithValue("@address", SqlDbType.DateTime).Value = form["txtdiachi"].ToString();
                //comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = "Lịch hẹn xét nghiệm miễn phí CEA vào ngày : " + ngay;


                //comd.ExecuteNonQuery();



                //_conn.Close();

                //  Response.Redirect("/thankyou", true);
            }
            catch (Exception ex)
            {

            }




            return View();
        }



        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult LandingBenhlyPhoi(FormCollection form)
        {


            try
            {

                if (!string.IsNullOrEmpty(form["txtHoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập tên bạn');</script>";
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

                string ngay = form["dllNgayhen"].ToString();
                string gio = form["dllGiohen"].ToString();


                SqlConnection _conn1;
                _conn1 = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                _conn1.Open();

                string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2") + " " + DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":00";
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

                if (form["dllGoikham"].ToString().Trim() == "1")
                {
                    parameter1 = new SqlParameter("@pIDGoi", SqlDbType.Int);
                    parameter1.Value = 2236;
                    parameter2 = new SqlParameter("@pMaGoi", SqlDbType.VarChar);
                    parameter2.Value = "19PHBLP1";
                    parameter3 = new SqlParameter("@pTenGoi", SqlDbType.NVarChar);
                    parameter3.Value = "Phát Hiện Bệnh Lý Phổi 1";
                }
                if (form["dllGoikham"].ToString().Trim() == "2")
                {
                    parameter1 = new SqlParameter("@pIDGoi", SqlDbType.Int);
                    parameter1.Value = 2237;
                    parameter2 = new SqlParameter("@pMaGoi", SqlDbType.VarChar);
                    parameter2.Value = "19PHBLP2";
                    parameter3 = new SqlParameter("@pTenGoi", SqlDbType.NVarChar);
                    parameter3.Value = "Phát Hiện Bệnh Lý Phổi 2";
                }

                parameter4 = new SqlParameter("@pNgayBan", SqlDbType.DateTime);
                parameter4.Value = abc;
                parameter5 = new SqlParameter("@pTel", SqlDbType.VarChar);
                parameter5.Value = form["txtdt"].ToString().Trim();

                DateTime ngay1 = DateTime.Parse(ngay);
                ngay = ngay1.Year.ToString() + "-" + ngay1.Month.ToString("d2") + "-" + ngay1.Day.ToString("d2");
                parameter6 = new SqlParameter("@pNgayKham", SqlDbType.DateTime);
                parameter6.Value = ngay;

                string giohen1 = ngay + " " + gio;
                DateTime giochuan1 = DateTime.Parse(giohen1, new CultureInfo("en-US"));

                string giochuan11 = giochuan1.Year.ToString() + "-" + giochuan1.Month.ToString("d2") + "-" + giochuan1.Day.ToString("d2") + " " + giochuan1.Hour.ToString("d2") + ":" + giochuan1.Minute.ToString("d2") + ":00";

                DateTime giochuan2 = DateTime.Parse(giochuan11).AddHours(1);
                string giochuan12 = giochuan2.Year.ToString() + "-" + giochuan2.Month.ToString("d2") + "-" + giochuan2.Day.ToString("d2") + " " + giochuan2.Hour.ToString("d2") + ":" + giochuan2.Minute.ToString("d2") + ":00";

                parameter7 = new SqlParameter("@pGioHen1", SqlDbType.DateTime);
                parameter7.Value = giochuan11;
                parameter8 = new SqlParameter("@pGioHen2", SqlDbType.DateTime);
                parameter8.Value = giochuan12;

                parameter9 = new SqlParameter("@pNguoiMua", SqlDbType.NVarChar);
                parameter9.Value = form["txtHoten"].ToString();


                parameter10 = new SqlParameter("@pNoiKham", SqlDbType.NVarChar);
                parameter10.Value = "BVĐK MEDLATEC-42 Nghĩa Dũng";





                //  SQLHelper.SqlHelper.ExecuteNonQuery(_conn1, CommandType.StoredProcedure, "GoiKhamCTBan_Toan", parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7, parameter8, parameter9, parameter10);


                // SqlConnection _conn;
                // _conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                // _conn.Open();
                // // Info.  
                // string sql = string.Empty;
                // sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,Ghichudv,PLDL) values(";
                // sql += "@hoten,@sdt,@ngayhen,@ghichu,0,N'WebMed - Landing khám phát hiện bệnh lý về phổi','KBLGOL')";


                // SqlCommand comd = new SqlCommand(sql, _conn);


                // //  string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");


                // comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                // comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 11).Value = form["txtdt"].ToString();
                // comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);

                // comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = "Lịch hẹn khám phát hiện bệnh lý về phổi vào ngày : " + ngay + " vào lúc: " + gio;


                //comd.ExecuteNonQuery();



                // _conn.Close();

                //  Response.Redirect("/thankyou", true);
            }
            catch (Exception ex)
            {

            }




            return View();
        }


        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult LandingUngThu(FormCollection form)
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

                string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");

                // Info.  
                string sql = string.Empty;
                sql = "insert into Datlich(tenkh,sodt,ngayhen,email,ghichu,tinhtrang,address,Ghichudv,PLDL) values(";
                sql += "@hoten,@sdt,@ngayhen,@email,@ghichu,0,@diachi,N'WebMed - Landing Ung Thư Gan','TNOL')";


                SqlCommand comd = new SqlCommand(sql, _conn);


                comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 11).Value = form["txtdt"].ToString();
                comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                comd.Parameters.Add("@email", SqlDbType.NVarChar).Value = form["txtemail"].ToString();
                comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();





                comd.Parameters.AddWithValue("@diachi", SqlDbType.NVarChar).Value = form["txtdiachi"].ToString();




                //  comd.ExecuteNonQuery();
                _conn.Close();
                //    Response.Redirect("/thankyou", true);
            }
            catch (Exception ex)
            {

            }




            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LandingTN(MEDLATEC2019.Models.MPTXViewModel obj)
        {


            try
            {

                SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 192, 4, 1);
                ViewBag.NewsCate = _NewsCate;



                if (string.IsNullOrEmpty(obj.txthoten))
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View(obj);

                }
                if (!string.IsNullOrEmpty(obj.txtdt))
                {
                    if (IsNumeric(obj.txtdt.ToString().Trim()))
                    {

                        if ((obj.txtdt.ToString().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện thoại phải là 10 số.');</script>";
                            return View(obj);
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập số điện thoại');</script>";
                    return View(obj);

                }

                if (string.IsNullOrEmpty(obj.txtAddress))
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập địa chỉ');</script>";
                    return View(obj);

                }



                if (string.IsNullOrEmpty(obj.txtEmail))
                {
                    obj.txtEmail = string.Empty;
                }

                CMS_Core.Common.Common.DatlichTin(obj.txthoten.ToString(), obj.txtdt.ToString(), obj.txtnote.ToString(), obj.txtEmail.ToString(), "WebMed - Landing Lấy mẫu tại nhà", "LDTNOL");
                Response.Redirect("/thankyou?u=LandingTN", false);
            }
            catch (Exception ex)
            {

            }




            return View(obj);
        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult LandingBaohiemyte(FormCollection form)
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

                SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 165, 15, 1);
                ViewBag.NewsCate = _NewsCate;

                //SqlConnection _conn;
                //_conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                //_conn.Open();



                //// Info.  
                //string sql = string.Empty;
                //sql = "insert into Datlich(tenkh,sodt,ngayhen,email,ghichu,tinhtrang,Ghichudv,PLDL) values(";
                //sql += "@hoten,@sdt,@ngayhen,@email,@ghichu,0,N'WebMed - Landing Bảo hiểm y tế','BHTNOL')";


                //SqlCommand comd = new SqlCommand(sql, _conn);
                //string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");




                //comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                //comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 11).Value = form["txtdt"].ToString();
                //comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                //comd.Parameters.Add("@email", SqlDbType.NVarChar).Value = form["txtemail"].ToString();
                //comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();





                //comd.ExecuteNonQuery();
                //_conn.Close();
                //Response.Redirect("/thankyou", true);

                CMS_Core.Common.Common.DatlichTin(form["txthoten"].ToString(), form["txtdt"].ToString(), form["txtghichu"].ToString(), form["txtemail"].ToString(), "WebMed - Landing Bảo hiểm y tế", "BHTNOL");
                Response.Redirect("/thankyou?u=landingbaohiemyte", false);

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

        [ValidateAntiForgeryToken]
        public ActionResult LandingBaolanhvienphi(FormCollection form)
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

                SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 191, 15, 1);
                ViewBag.NewsCate = _NewsCate;

                //SqlConnection _conn;
                //_conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                //_conn.Open();



                //// Info.  
                //string sql = string.Empty;
                //sql = "insert into Datlich(tenkh,sodt,ngayhen,email,ghichu,tinhtrang,Ghichudv,PLDL) values(";
                //sql += "@hoten,@sdt,@ngayhen,@email,@ghichu,0,N'WebMed - Landing Bảo lãnh viện phí','BLVPTNOL')";


                //SqlCommand comd = new SqlCommand(sql, _conn);


                //string abc = DateTime.Now.Year.ToString() +"-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");


                //comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                //comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 11).Value = form["txtdt"].ToString();
                //comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                //comd.Parameters.Add("@email", SqlDbType.NVarChar).Value = form["txtemail"].ToString();
                //comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();








                //comd.ExecuteNonQuery();
                //_conn.Close();
                //Response.Redirect("/thankyou", true);

                CMS_Core.Common.Common.DatlichTin(form["txthoten"].ToString(), form["txtdt"].ToString(), form["txtghichu"].ToString(), form["txtemail"].ToString(), "WebMed - Landing Bảo lãnh viện phí", "BLVPTNOL");
                Response.Redirect("/thankyou?u=landingbaohiemvienphi", false);

            }
            catch (Exception ex)
            {

            }




            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LandingKhamsk(MEDLATEC2019.Entity.DatLich obj)
        {


            try
            {
                if (string.IsNullOrEmpty(obj.Hoten))
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập tên công ty');</script>";
                    return View(obj);

                }


                if (string.IsNullOrEmpty(obj.Tennguoilienhe))
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập tên người liên hệ');</script>";
                    return View(obj);
                }


                if (!string.IsNullOrEmpty(obj.Sdt))
                {

                    if ((obj.Sdt.Length < 10))
                    {
                        TempData["msg"] = "<script>alert('Số điện thoại phải là 10 số.');</script>";
                        return View(obj);
                    }

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập số điện thoại');</script>";
                    return View(obj);

                }


                if (string.IsNullOrEmpty(obj.Diachi))
                {
                    TempData["msg"] = "<script>alert('mời bạn nhập địa chỉ liên hệ');</script>";
                    return View();
                }

                SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 150, 15, 1);
                ViewBag.NewsCate = _NewsCate;


                CMS_Core.Common.Common.DatlichTin(obj.Hoten.Trim(), obj.Sdt.Trim(), "Người liên hệ:" + obj.Tennguoilienhe + ". Địa chỉ doanh nghiệp : " + obj.Diachi.Trim() + ". Số lượng : " + obj.Soluong.ToString() + " Nội dung yêu cầu:" + obj.Ghichudv, "", "WebMed - Landing khám sức khỏe doanh nghiệp", "KSKNOL");
                Response.Redirect("/thankyou?u=landingksk", false);


            }
            catch (Exception ex)
            {

            }




            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LandingTuyengiap(FormCollection form)
        {


            try
            {
                if (!string.IsNullOrEmpty(form["txtHoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập tên bạn');</script>";
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

                string ngay = form["dllNgayhen"].ToString();
                string gio = form["dllGiohen"].ToString();


                SqlConnection _conn1;
                _conn1 = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                _conn1.Open();

                string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");
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

                parameter1 = new SqlParameter("@pIDGoi", SqlDbType.Int);
                parameter1.Value = 2131;
                parameter2 = new SqlParameter("@pMaGoi", SqlDbType.VarChar);
                parameter2.Value = "19MPCKNT";
                parameter3 = new SqlParameter("@pTenGoi", SqlDbType.NVarChar);
                parameter3.Value = "MIEN PHI KHAM , SIEU AM PHAT HIEN CAC BENH LY TUYEN GIAP";
                parameter4 = new SqlParameter("@pNgayBan", SqlDbType.DateTime);
                parameter4.Value = abc;
                parameter5 = new SqlParameter("@pTel", SqlDbType.VarChar);
                parameter5.Value = form["txtdt"].ToString().Trim();

                DateTime ngay1 = DateTime.Parse(ngay);
                ngay = ngay1.Year.ToString() + "-" + ngay1.Month.ToString("d2") + "-" + ngay1.Day.ToString("d2");
                parameter6 = new SqlParameter("@pNgayKham", SqlDbType.DateTime);
                parameter6.Value = ngay;

                string giohen1 = ngay + " " + gio;
                DateTime giochuan1 = DateTime.Parse(giohen1, new CultureInfo("en-US"));

                string giochuan11 = giochuan1.Year.ToString() + "-" + giochuan1.Month.ToString("d2") + "-" + giochuan1.Day.ToString("d2") + " " + giochuan1.Hour.ToString("d2") + ":" + giochuan1.Minute.ToString("d2") + ":00";

                DateTime giochuan2 = DateTime.Parse(giochuan11).AddHours(1);
                string giochuan12 = giochuan2.Year.ToString() + "-" + giochuan2.Month.ToString("d2") + "-" + giochuan2.Day.ToString("d2") + " " + giochuan2.Hour.ToString("d2") + ":" + giochuan2.Minute.ToString("d2") + ":00";

                parameter7 = new SqlParameter("@pGioHen1", SqlDbType.DateTime);
                parameter7.Value = giochuan11;
                parameter8 = new SqlParameter("@pGioHen2", SqlDbType.DateTime);
                parameter8.Value = giochuan12;

                parameter9 = new SqlParameter("@pNguoiMua", SqlDbType.NVarChar);
                parameter9.Value = form["txtHoten"].ToString();
                string noikham = "";
                if (form["dllNoihen"].ToString().Trim() == "ND")
                {
                    noikham = "BVĐK MEDLATEC-42 Nghĩa Dũng";
                }
                else
                {
                    noikham = "PKĐK MEDLATEC-99 Trích Sài";
                }

                parameter10 = new SqlParameter("@pNoiKham", SqlDbType.NVarChar);
                parameter10.Value = noikham;



                //List<SqlParameter> parameters = new List<SqlParameter>();
                //parameters.Add(new SqlParameter("@pIDGoi", form["txtHoten"].ToString().Trim()));
                //parameters.Add(new SqlParameter("@pMaGoi", ));
                //parameters.Add(new SqlParameter("@pTenGoi", ));
                //parameters.Add(new SqlParameter("@pNgayBan", ));
                //parameters.Add(new SqlParameter("@pTel", ));
                //parameters.Add(new SqlParameter("@pNgayKham", ));
                //parameters.Add(new SqlParameter("@pGioHen1", ));
                //parameters.Add(new SqlParameter("@pGioHen2", ));
                //parameters.Add(new SqlParameter("",)

                //  SQLHelper.SqlHelper.ExecuteNonQuery(_conn1, CommandType.StoredProcedure, "GoiKhamCTBan_Toan", parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7, parameter8,parameter9,parameter10);


                //     SqlConnection _conn;
                //     _conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                //     _conn.Open();
                //     // Info.  
                //     string sql = string.Empty;
                //     sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,Ghichudv,PLDL) values(";
                //     sql += "@hoten,@sdt,@ngayhen,@ghichu,0,N'WebMed - Landing khám và siêu âm tuyến giáp miễn phí','SMTGNOL')";


                //     SqlCommand comd = new SqlCommand(sql, _conn);


                //   //  string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");


                //     comd.Parameters.Add("@hoten", SqlDbType.NVarChar,30).Value = form["txthoten"].ToString();
                //     comd.Parameters.Add("@sdt", SqlDbType.NVarChar,11).Value = form["txtdt"].ToString();
                //     comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);

                //     comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = "Lịch hẹn miễn phí siêu âm tuyến giá vào ngày : "+ ngay+" vào lúc: " + gio;


                ////     comd.ExecuteNonQuery();



                //     _conn.Close();

                //     Response.Redirect("/thankyou", true);
            }
            catch (Exception ex)
            {

            }




            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LandingMPXNMauT9(FormCollection form)
        {


            try
            {
                //    if (!string.IsNullOrEmpty(form["txtHoten"].ToString().Trim()))
                //    {

                //    }
                //    else
                //    {
                //        TempData["msg"] = "<script>alert('Mời bạn nhập tên bạn');</script>";
                //        return View();

                //    }





                //    if (!string.IsNullOrEmpty(form["txtdt"].ToString().Trim()))
                //    {
                //        if (IsNumeric(form["txtdt"].ToString().Trim()))
                //        {

                //            if ((form["txtdt"].ToString().Length != 10))
                //            {
                //                TempData["msg"] = "<script>alert('Số điện thoại phải là 10 số.');</script>";
                //                return View();
                //            }
                //        }
                //        else
                //        {
                //        }
                //    }
                //    else
                //    {
                //        TempData["msg"] = "<script>alert('Mời bạn nhập số điện thoại');</script>";
                //        return View();

                //    }

                //    string ngay = form["dllNgayhen"].ToString();
                //    string gio = form["dllGiohen"].ToString();


                //    SqlConnection _conn1;
                //    _conn1 = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                //    _conn1.Open();

                //    string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2") + " " + DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":00"; 
                //    SqlParameter parameter1 = new SqlParameter();
                //    SqlParameter parameter2 = new SqlParameter();
                //    SqlParameter parameter3 = new SqlParameter();
                //    SqlParameter parameter4 = new SqlParameter();
                //    SqlParameter parameter5 = new SqlParameter();
                //    SqlParameter parameter6 = new SqlParameter();
                //    SqlParameter parameter7 = new SqlParameter();
                //    SqlParameter parameter8 = new SqlParameter();
                //    SqlParameter parameter9 = new SqlParameter();
                //    SqlParameter parameter10 = new SqlParameter();

                //    parameter1 = new SqlParameter("@pIDGoi", SqlDbType.Int);
                //    parameter1.Value = 2182;
                //    parameter2 = new SqlParameter("@pMaGoi", SqlDbType.VarChar);
                //    parameter2.Value = "19SKCD";
                //    parameter3 = new SqlParameter("@pTenGoi", SqlDbType.NVarChar);
                //    parameter3.Value = "Miễn phí Xét nghiệm tổng phân tích máu, men gan";
                //    parameter4 = new SqlParameter("@pNgayBan", SqlDbType.DateTime);
                //    parameter4.Value = abc;
                //    parameter5 = new SqlParameter("@pTel", SqlDbType.VarChar);
                //    parameter5.Value = form["txtdt"].ToString().Trim();

                //    DateTime ngay1 = DateTime.Parse(ngay);
                //    ngay = ngay1.Year.ToString() + "-" + ngay1.Month.ToString("d2") + "-" + ngay1.Day.ToString("d2");
                //    parameter6 = new SqlParameter("@pNgayKham", SqlDbType.DateTime);
                //    parameter6.Value = ngay;

                //    string giohen1 = ngay + " " + gio;
                //    DateTime giochuan1 = DateTime.Parse(giohen1, new CultureInfo("en-US"));

                //    string giochuan11 = giochuan1.Year.ToString() + "-" + giochuan1.Month.ToString("d2") + "-" + giochuan1.Day.ToString("d2") + " " + giochuan1.Hour.ToString("d2") + ":" + giochuan1.Minute.ToString("d2") + ":00";

                //    DateTime giochuan2 = DateTime.Parse(giochuan11).AddHours(1);
                //    string giochuan12 = giochuan2.Year.ToString() + "-" + giochuan2.Month.ToString("d2") + "-" + giochuan2.Day.ToString("d2") + " " + giochuan2.Hour.ToString("d2") + ":" + giochuan2.Minute.ToString("d2") + ":00";

                //    parameter7 = new SqlParameter("@pGioHen1", SqlDbType.DateTime);
                //    parameter7.Value = giochuan11;
                //    parameter8 = new SqlParameter("@pGioHen2", SqlDbType.DateTime);
                //    parameter8.Value = giochuan12;

                //    parameter9 = new SqlParameter("@pNguoiMua", SqlDbType.NVarChar);
                //    parameter9.Value = form["txtHoten"].ToString();
                //    string noikham = "";
                //    if (form["dllNoihen"].ToString().Trim() == "ND")
                //    {
                //        noikham = "BVĐK MEDLATEC-42 Nghĩa Dũng";
                //    }
                //    else if (form["dllNoihen"].ToString().Trim() == "TS")
                //    {
                //        noikham = "PKĐK MEDLATEC-99 Trích Sài";
                //    }
                //    else
                //    {
                //        noikham = "PKĐK MEDLATEC- THANH XUÂN";
                //    }

                //    parameter10 = new SqlParameter("@pNoiKham", SqlDbType.NVarChar);
                //    parameter10.Value = noikham;



                //    //List<SqlParameter> parameters = new List<SqlParameter>();
                //    //parameters.Add(new SqlParameter("@pIDGoi", form["txtHoten"].ToString().Trim()));
                //    //parameters.Add(new SqlParameter("@pMaGoi", ));
                //    //parameters.Add(new SqlParameter("@pTenGoi", ));
                //    //parameters.Add(new SqlParameter("@pNgayBan", ));
                //    //parameters.Add(new SqlParameter("@pTel", ));
                //    //parameters.Add(new SqlParameter("@pNgayKham", ));
                //    //parameters.Add(new SqlParameter("@pGioHen1", ));
                //    //parameters.Add(new SqlParameter("@pGioHen2", ));
                //    //parameters.Add(new SqlParameter("",)

                //    SQLHelper.SqlHelper.ExecuteNonQuery(_conn1, CommandType.StoredProcedure, "GoiKhamCTBan_Toan", parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7, parameter8, parameter9, parameter10);


                //    SqlConnection _conn;
                //    _conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                //    _conn.Open();
                //    // Info.  
                //    string sql = string.Empty;
                //    sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,Ghichudv,PLDL) values(";
                //    sql += "@hoten,@sdt,@ngayhen,@ghichu,0,N'WebMed - Landing miễn phí xét nghiệm tổng phân tích và men gan','TPTVMGOL')";


                //    SqlCommand comd = new SqlCommand(sql, _conn);


                //    //  string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");


                //    comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                //    comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 11).Value = form["txtdt"].ToString();
                //    comd.Parameters.AddWithValue("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);

                //    comd.Parameters.AddWithValue("@ghichu", SqlDbType.NVarChar).Value = "Lịch hẹn miễn phí tổng phân tích máu và men gan vào ngày : " + ngay + " vào lúc: " + gio;


                //    comd.ExecuteNonQuery();



                //    _conn.Close();

                //    Response.Redirect("/thankyou", false);
            }
            catch (Exception ex)
            {

            }




            return View();
        }
    }
}