using CMS_Core.Common;
using MEDLATEC.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MEDLATEC2019.Controllers
{
    public class BMIController : Controller
    {
        // GET: BMI
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            try
            {
                SQLServerConnection<Cms_News> sQLServer = new SQLServerConnection<Cms_News>();
                List<Cms_News> _News = sQLServer.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());

              

            ViewBag.News = _News;
        

      
            }
            catch { }


            return View();
        }
    }
}