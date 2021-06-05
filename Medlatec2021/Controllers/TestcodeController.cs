using CMS_Core.Common;
using MEDLATEC.BusinessLayer;
using MEDLATEC2019.Entity;
using MEDLATEC2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MEDLATEC2019.Controllers
{
    public class TestcodeController : Controller
    {
        // GET: Testcode
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult TestcodeDetails(string id)
        {
            TestcodeViewModel obj = new TestcodeViewModel();
            try
            {
               
                if (!string.IsNullOrEmpty(id))
                {
                    SQLServerConnection<tbl_TestCode> sQLServer = new SQLServerConnection<tbl_TestCode>();
                    SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();

                    List<tbl_TestCode> TestCodes = sQLServer.SelectQueryCommand("tbl_TestCode_SelectByPrimaryKey", Common.getConnectionString(), int.Parse(id));
                    if (TestCodes != null)
                    {
                        if (TestCodes.Count > 0)
                        {
                            obj.TestCode = TestCodes[0];
                        }
                        List<Cms_News> _TinLienquan = sQLServer2.SelectQueryCommand("SP_cms_News_TinlienquanTestcode", Common.getConnectionString(), id);
                        obj.News = _TinLienquan;
                        List<Cms_News> _TinNoiBat = sQLServer2.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                        obj.NewsNew = _TinNoiBat;

                    }
                    else
                    {
                        Response.RedirectPermanent("https://medlatec.vn/tin-tuc/tin-tuc-y-hoc-s28", false);
                    }
                }
               

            }
            catch (Exception ex)
            {

            }

            return View(obj);
        }



    }
}