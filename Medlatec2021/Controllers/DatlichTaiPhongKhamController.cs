using MEDLATEC2019.Global;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MEDLATEC2019.Controllers
{
    public class DatlichTaiPhongKhamController : Controller
    {
        // GET: DatlichTaiPhongKham
        public ActionResult Index()
        {
            string output = Global.Utils.GetResponseJson("http://icnmservice.icnm.vn/api/Organize");

            var listdata = JsonConvert.DeserializeObject<List<BusinessLayer.Phongkham>>(output);

            if (listdata != null)
                ViewBag.Data = listdata;


            return View();
        }

        public ActionResult Bacsi(string id)
        {
            var listDoctorOnAir = new List<BusinessLayer.DoctorWithPhongKham>();
            var listchuyenkhoa = new List<BusinessLayer.Chuyenkhoa>();
            if (string.IsNullOrEmpty(id))
            {
                TempData["msg"] = "<script type=\"text/javascript\">zebra_infor('Thông báo','Bạn chưa chọn phòng khám nào.<br/> Vui lòng quay lại chọn phòng khám.','/danh-sach-phong-kham/');</script>";
            }
            else
            {


                string output2 = Global.Utils.GetResponseJson("http://icnmservice.icnm.vn/api/Specialist/Get");
                listchuyenkhoa = JsonConvert.DeserializeObject<List<BusinessLayer.Chuyenkhoa>>(output2);

                string uri = "http://icnmservice.icnm.vn/api/Schedule/GetLichBySpecIDAnd/" + id;
                string output = Global.Utils.GetResponseJson(uri);

                try
                {
                    var listdata = JsonConvert.DeserializeObject<List<BusinessLayer.DoctorWithPhongKham>>(output);

                    if (listdata != null)
                    {


                        for (int i = 0; i < listdata.Count; i++)
                        {
                            if (listdata[i].timeBS != null && listdata[i].timeBS.Count > 0)
                            {
                                int zz = 0;
                                while (listdata[i].timeBS.Count > 0 && listdata[i].timeBS.Count > zz)
                                {

                                    string[] _time = listdata[i].timeBS[zz].DoctorTime.Split('-');
                                    string time1 = _time[1].Replace("h", ":");

                                    TimeSpan s1 = TimeSpan.Parse(time1);
                                    TimeSpan s2 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm"));

                                    if (s1 < s2) { listdata[i].timeBS.RemoveAt(zz); }
                                    else zz++;
                                }

                                if (listdata[i].timeBS.Count > 0) { listDoctorOnAir.Add(listdata[i]); }

                            }
                        }

                    }


                    ViewBag.Param = id;
                }
                catch (Exception ex)
                {

                    throw;
                }

            }
            ViewBag.Doctor = listDoctorOnAir;
            ViewBag.ChuyenKhoa = listchuyenkhoa;
            return View();
        }

        public ActionResult Datlich()
        {

            var Data = new LichKham();
            if (HttpContext.Request.Cookies["booking"] != null)
            {
                string cookie = HttpContext.Request.Cookies["booking"].Value;
                Data = JsonConvert.DeserializeObject<LichKham>(cookie);

            }
            else TempData["msg"] = "<script type=\"text/javascript\">zebra_infor('Thông báo','Bạn chưa đăng ký lịch với bác sĩ nào.<br/> Vui lòng quay lại chọn bác sĩ.','/danh-sach-phong-kham/');</script>";
            ViewBag.Data = Data;
            ViewBag.Model = new DatLichModel();
            return View();
        }
        public Message Message { get; } = new Message();
        [HttpPost]
        public ActionResult Datlich(DatLichModel model)
        {

            var Data = new LichKham();
            if (string.IsNullOrEmpty(model.Name))
                Message.ListMessage.Add("Mời bạn nhập họ tên.");
            if (string.IsNullOrEmpty(model.Phone))
                Message.ListMessage.Add("Mời bạn nhập số điện thoại.");
            if (string.IsNullOrEmpty(model.Address))
                Message.ListMessage.Add("Mời bạn nhập địa chỉ.");

            if (HttpContext.Request.Cookies["booking"] != null)
            {
                string cookie = HttpContext.Request.Cookies["booking"].Value;
                Data = JsonConvert.DeserializeObject<LichKham>(cookie);

            }
            else TempData["msg"] = "<script type=\"text/javascript\">zebra_infor('Thông báo','Bạn chưa đăng ký lịch với bác sĩ nào.<br/> Vui lòng quay lại chọn bác sĩ.','/danh-sach-phong-kham/');</script>";
            if (Message.ListMessage.Count < 1)
            {



                string url = "http://icnmservice.icnm.vn/api/Schedule/InsertScheduleFixDoctorNew";
                string _mess = "";
                try
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.MediaType = "application/json";
                    httpWebRequest.Accept = "application/json";
                    httpWebRequest.Method = "POST";

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string jsonToken = JsonConvert.SerializeObject(model);

                        streamWriter.Write(jsonToken);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }


                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        var _me = JsonConvert.DeserializeObject<Messenger>(result);
                        if (_me != null)
                        {
                            _mess = _me.stringResult + (_me.result != null ? "<br/>mã hẹn:" + _me.result.magen : "");

                        }

                    }
                    TempData["msg"] = "<script type=\"text/javascript\">zebra_infor('Thông báo','" + _mess + "','/');</script>";
                    ViewBag.Data = Data;
                    ViewBag.Model = model;
                }
                catch (Exception ex)
                {

                    throw;
                }


            }
            else
            {
                string _mess = "";
                for (int i = 0; i < Message.ListMessage.Count; i++)
                {
                    _mess += Message.ListMessage[i] + "<br/>";
                }
                TempData["msg"] = "<script type=\"text/javascript\">zebra_alert('Thông báo', '" + _mess + "');</script>";
                ViewBag.Data = Data;
                ViewBag.Model = model;
            }




            return View();
        }
        public class Messenger
        {
            public string stringResult { get; set; }
            public result result { get; set; }
        }
        public class result
        {
            public string magen { get; set; }
        }

        public class DatLichModel
        {

            public int UserID = 0;
            public string Name { get; set; }
            public int OrganizeID { get; set; }
            public string OrganizeCode { get; set; }
            public int ScheduleTypeID = 5;
            public int ScheduleTimeID { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public string Gender { get; set; }
            public int DoctorID { get; set; }
            public string DoctorIDCode { get; set; }
            public string BirthYear { get; set; }
            public string DateSchedule { get; set; }
            public string SpecialistID { get; set; }
            public string LydoKham { get; set; }
            public string NgayKham { get; set; }
            public string GioHen { get; set; }

        }

        public class LichKham
        {

            public string giokham { get; set; }
            public string bacsi { get; set; }
            public string mabacsi { get; set; }
            public int timeid { get; set; }
            public int idbacsi { get; set; }
            public int idpk { get; set; }
            public string mapk { get; set; }
            public string tenpk { get; set; }
            public string ngaykham { get; set; }
            public string tenchuyenkhoa { get; set; }
            public int chuyenkhoa { get; set; }
        }
    }
}