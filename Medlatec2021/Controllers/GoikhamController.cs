using CMS_Core.Common;
using MEDLATEC.BusinessLayer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MEDLATEC2019.Controllers
{
    public class GoikhamController : Controller
    {
        // GET: Goikham
        public ActionResult Index()
        {
            try
            {
                List<RootObject> _Service = new List<RootObject>();

                HttpClient http3 = new HttpClient();
                string baseUrl3 = "http://icnmservice.icnm.vn/api/Service/GetServiceByAllWeb";

                string url3 = baseUrl3;
                HttpResponseMessage response3 = http3.GetAsync(new Uri(url3)).Result;
                string responseBody3 = response3.Content.ReadAsStringAsync().Result;
                var countries3 = JsonConvert.DeserializeObject(responseBody3);

                JArray jsonResponse3 = JArray.Parse(responseBody3);



                foreach (var item in jsonResponse3)
                {


                    RootObject rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(item.ToString());
                    _Service.Add(rowsDoctor);

                }

                ViewBag.Service = _Service;

                List<ServiceGroup> _ServiceGroup = new List<ServiceGroup>();

                HttpClient http4 = new HttpClient();
                string baseUrl4 = "http://icnmservice.icnm.vn/api/Service/GetAllServiceGroups";

                string url4 = baseUrl4;
                HttpResponseMessage response4 = http4.GetAsync(new Uri(url4)).Result;
                string responseBody4 = response4.Content.ReadAsStringAsync().Result;
                var countries4 = JsonConvert.DeserializeObject(responseBody4);

                JArray jsonResponse4 = JArray.Parse(responseBody4);



                foreach (var item in jsonResponse4)
                {


                    ServiceGroup rowsDoctor1 = Newtonsoft.Json.JsonConvert.DeserializeObject<ServiceGroup>(item.ToString());
                    _ServiceGroup.Add(rowsDoctor1);

                }

                ViewBag.ServiceGroup = _ServiceGroup;

            }
            catch (Exception ex)
            {

            }


            return View();
        }
        public ActionResult ServiceGroup(string id)
        {
            try
            {
                List<RootObject> _Service = new List<RootObject>();

                HttpClient http3 = new HttpClient();
                string baseUrl3 = "http://icnmservice.icnm.vn/api/Service/GetServiceByGroups?serviceGroupID="+ id;

                string url3 = baseUrl3;
                HttpResponseMessage response3 = http3.GetAsync(new Uri(url3)).Result;
                string responseBody3 = response3.Content.ReadAsStringAsync().Result;
                var countries3 = JsonConvert.DeserializeObject(responseBody3);

                JArray jsonResponse3 = JArray.Parse(responseBody3);



                foreach (var item in jsonResponse3)
                {


                    RootObject rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(item.ToString());
                    _Service.Add(rowsDoctor);

                }

                ViewBag.Service = _Service;

                List<ServiceGroup> _ServiceGroup = new List<ServiceGroup>();

                HttpClient http4 = new HttpClient();
                string baseUrl4 = "http://icnmservice.icnm.vn/api/Service/GetAllServiceGroups";

                string url4 = baseUrl4;
                HttpResponseMessage response4 = http4.GetAsync(new Uri(url4)).Result;
                string responseBody4 = response4.Content.ReadAsStringAsync().Result;
                var countries4 = JsonConvert.DeserializeObject(responseBody4);

                JArray jsonResponse4 = JArray.Parse(responseBody4);



                foreach (var item in jsonResponse4)
                {


                    ServiceGroup rowsDoctor1 = Newtonsoft.Json.JsonConvert.DeserializeObject<ServiceGroup>(item.ToString());
                    _ServiceGroup.Add(rowsDoctor1);

                }

                ViewBag.ServiceGroup = _ServiceGroup;

            }
            catch (Exception ex)
            {

            }


            return View();
        }
        public ActionResult ServiceDetail(string rid,string gid)
        {
            try
            {
                List<Root> _Service = new List<Root>();
              //  baseURL + "api/Service/getAllServiceDetail?ServiceID=\(serviceID)"
                HttpClient http3 = new HttpClient();
                string baseUrl3 = "http://icnmservice.icnm.vn/api/Service/getAllServiceDetail?ServiceID="+gid;

                string url3 = baseUrl3;
                HttpResponseMessage response3 = http3.GetAsync(new Uri(url3)).Result;
                string responseBody3 = response3.Content.ReadAsStringAsync().Result;
                var countries3 = JsonConvert.DeserializeObject(responseBody3);


                Root rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(countries3.ToString());

            //    JArray jsonResponse3 = JArray.Parse(responseBody3);

                _Service.Add(rowsDoctor);

                //foreach (var item in jsonResponse3)
                //{


                //    RootObject rowsDoctor = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(item.ToString());
                //    _Service.Add(rowsDoctor);

                //}

                ViewBag.Service = _Service;
                string check = _Service[0].Service.ServiceDetails.Count.ToString();

                List<ServiceGroup> _ServiceGroup = new List<ServiceGroup>();

                HttpClient http4 = new HttpClient();
                string baseUrl4 = "http://icnmservice.icnm.vn/api/Service/GetAllServiceGroups";

                string url4 = baseUrl4;
                HttpResponseMessage response4 = http4.GetAsync(new Uri(url4)).Result;
                string responseBody4 = response4.Content.ReadAsStringAsync().Result;
                var countries4 = JsonConvert.DeserializeObject(responseBody4);

                JArray jsonResponse4 = JArray.Parse(responseBody4);



                foreach (var item in jsonResponse4)
                {


                    ServiceGroup rowsDoctor1 = Newtonsoft.Json.JsonConvert.DeserializeObject<ServiceGroup>(item.ToString());
                    _ServiceGroup.Add(rowsDoctor1);

                }

                ViewBag.ServiceGroup = _ServiceGroup;

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