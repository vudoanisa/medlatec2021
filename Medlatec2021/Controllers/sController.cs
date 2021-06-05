using CMS_Core.Common;
using MEDLATEC.BusinessLayer;
using MEDLATEC2019.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MEDLATEC2019.Controllers
{
    public class sController : Controller
    {
        // GET: s
        public ActionResult Index()
        {
            return View();
        }

        // GET: s
        public ActionResult Index(string shorturl)
        {
            if (string.IsNullOrEmpty(shorturl))
            {
                shorturl = string.Empty;
            }

            SQLServerConnection<tblShortUrlNew> sQLServer1 = new SQLServerConnection<tblShortUrlNew>();
            List<tblShortUrlNew> _News = sQLServer1.SelectQueryCommand("GettblShortUrlNew", Common.getConnectionString(), shorturl);

            if(_News != null)
            {
                if(_News.Count > 0)
                {
                    Response.Redirect(_News[0].Link, true);
                }else
                {
                    Response.Redirect("https://medlatec.vn", true);
                }
            }else
            {
                Response.Redirect("https://medlatec.vn", true);
            }

            return View();
        }


        public ActionResult RedirectBanner(string idBanner)
        {
            if (string.IsNullOrEmpty(idBanner))
            {
                idBanner = string.Empty;
            }

            SQLServerConnection<MEDLATEC2019.Entity.cms_Banner_rows> sQLServer1 = new SQLServerConnection<MEDLATEC2019.Entity.cms_Banner_rows>();
            List<MEDLATEC2019.Entity.cms_Banner_rows> _News = sQLServer1.SelectQueryCommand("cms_Banner_Plans$selectByID", Common.getConnectionString(), idBanner);

            if (_News != null)
            {
                if (_News.Count > 0)
                {
                    Response.Redirect(_News[0].clickUrl, true);
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