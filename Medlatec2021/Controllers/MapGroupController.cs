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
    public class MapGroupController : Controller
    {
        // GET: MapGroup
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            MEDLATEC2019.Models.MapViewModel obj = new Models.MapViewModel();
            this.ViewBag.GetTypeLocaltion = Common.GetTypeLocaltion();
            try
            {
               

                obj.Khuvuc = "";
                SQLServerConnection<Cms_Map> sQLServer1 = new SQLServerConnection<Cms_Map>();
                List<Cms_Map> _Map = sQLServer1.SelectQueryCommand("GetAllMapPhongKham", Common.getConnectionString(), obj.Khuvuc);
                ViewBag.Map = _Map;

            }
            catch(Exception ex)
            {

            }
      

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult Home(MEDLATEC2019.Models.MapViewModel obj)
        {
            this.ViewBag.GetTypeLocaltion = Common.GetTypeLocaltion();
            try
            {
                if(string.IsNullOrEmpty(obj.Khuvuc))
                {
                    obj.Khuvuc = "";
                }

                SQLServerConnection<Cms_Map> sQLServer1 = new SQLServerConnection<Cms_Map>();
                List<Cms_Map> _Map = sQLServer1.SelectQueryCommand("GetAllMapPhongKham", Common.getConnectionString(), obj.Khuvuc);
                ViewBag.Map = _Map;

            }
            catch (Exception ex)
            {

            }


            return View(obj);
        }


        public ActionResult HomeHospitor()
        {
            try
            {
                SQLServerConnection<Cms_Map> sQLServer1 = new SQLServerConnection<Cms_Map>();
                List<Cms_Map> _Map = sQLServer1.SelectQueryCommand("GetAllMapHospitor", Common.getConnectionString());
                ViewBag.Map = _Map;

            }
            catch (Exception ex)
            {

            }


            return View();
        }

        public ActionResult HomeVanphong()
        {
            this.ViewBag.GetTypeLocaltion = Common.GetTypeLocaltion();
            MEDLATEC2019.Models.MapViewModel obj = new Models.MapViewModel();
            try
            {
                obj.Khuvuc = "";
                SQLServerConnection<Cms_Map> sQLServer1 = new SQLServerConnection<Cms_Map>();
                List<Cms_Map> _Map = sQLServer1.SelectQueryCommand("GetAllMapVanphong", Common.getConnectionString(), obj.Khuvuc);
                ViewBag.Map = _Map;

            }
            catch (Exception ex)
            {

            }


            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HomeVanphong(MEDLATEC2019.Models.MapViewModel obj)
        {
            this.ViewBag.GetTypeLocaltion = Common.GetTypeLocaltion();
            try
            {
                if (string.IsNullOrEmpty(obj.Khuvuc))
                {
                    obj.Khuvuc = "";
                }

                SQLServerConnection<Cms_Map> sQLServer1 = new SQLServerConnection<Cms_Map>();
                List<Cms_Map> _Map = sQLServer1.SelectQueryCommand("GetAllMapVanphong", Common.getConnectionString(), obj.Khuvuc);
                ViewBag.Map = _Map;

            }
            catch (Exception ex)
            {

            }


            return View(obj);
        }


        public ActionResult MapDetails(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    SQLServerConnection<Cms_Map> sQLServer1 = new SQLServerConnection<Cms_Map>();
                    List<Cms_Map> _Map = sQLServer1.SelectQueryCommand("GetAllMap_ByID", Common.getConnectionString(),int.Parse(id));
                    ViewBag.Map = _Map;
                }
                

            }
            catch (Exception ex)
            {

            }
           

            return View();
        }
    }
}