using CMS_Core.Common;
using MEDLATEC2019.Entity;
using MEDLATEC2019.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace MEDLATEC2019.Controllers
{
    public class CustomerServiceController : Controller
    {
        // GET: CustomerService
        public ActionResult Index(string sid)
        {
            try
            {
                if (!string.IsNullOrEmpty(sid))
                {
                    sid = sid.Replace(" ", "+");
                    sid = AES.DecryptQrCode(sid, Common.getKeyPrivate());
                    sid = sid.Replace("\u000f", "").Trim();
                    sid = sid.Replace("\u000e", "").Trim();
                    sid = sid.Replace("\u0010", "").Trim();

                    HttpClient http3 = new HttpClient();
                    string baseUrl3 = "http://m.medlatec.vn/api/Result/GetPatientBySID?username=" + sid.Trim() + "&token=" + Common.generalKeyPrivate(sid.Trim());

                    string url3 = baseUrl3;
                    HttpResponseMessage response3 = http3.GetAsync(new Uri(url3)).Result;
                    string responseBody3 = response3.Content.ReadAsStringAsync().Result;
                    var models = JsonConvert.DeserializeObject<List<CustomerServiceModel>>(responseBody3);
                    ViewBag.Data = models != null ? models[0] : new CustomerServiceModel();
                    ViewBag.Unit = ModUnitService.Instance.CreateQuery()
                                                    .Select(o => new { o.Hotline, o.ID, o.Name, o.Code })
                                                    .Where(o => o.IsLock == false && o.IsUnit == true)
                                                    .OrderByAsc(o => o.Name)
                                                    .ToList();


                }
                else
                {
                    ViewBag.Data = new CustomerServiceModel();
                    ViewBag.Unit = ModUnitService.Instance.CreateQuery()
                                                            .Select(o => new { o.Hotline, o.ID, o.Name, o.Code })
                                                            .Where(o => o.IsLock == false && o.IsUnit == true)
                                                            .OrderByAsc(o => o.Name)
                                                            .ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return View();
        }
    }


}