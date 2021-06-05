using CMS_Core.Common;
using Dapper;
using MEDLATEC.BusinessLayer;
using MEDLATEC2019.Entity;
using MEDLATEC2019.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MEDLATEC2019.Controllers
{
    /// <summary>
    /// Controller danh sách bệnh
    /// </summary>
    public class DictionaryController : Controller
    {
        public ActionResult Index()
        {
            string cacheName = "[cms_Dictionary].Cache_Dictionary";
            string cacheNameViews = "[cms_Dictionary].Cache_Dictionary_Views";
            var getCache = Cache.GetValue(cacheName) as List<string>;
            var getCacheViews = Cache.GetValue(cacheNameViews) as List<Cms_DictionaryEntity>;
            if (getCache != null)
            {
                ViewBag.Views = getCacheViews;
                ViewBag.Data = getCache;
                return View();
            }
            else
            {


                var dbQuery = Cms_DictionaryService.Instance.CreateQuery()
                                            .Select(o => o.GroupName)
                                            .Where(o => o.IsActive == true)
                                            .GroupBy(o => o.GroupName)
                                            .ToList();

                var listViews = Cms_DictionaryService.Instance.CreateQuery()
                                            .Select(o => new { o.Name, o.Url })
                                            .Where(o => o.IsActive == true)
                                            .Take(12)
                                            .OrderByDesc(o => o.Views)
                                            .ToList();
                List<string> mylst = dbQuery != null ? dbQuery.Select(x => x.GroupName).ToList() : new List<string>();
                ViewBag.Data = mylst;
                ViewBag.Views = listViews;
                Cache.SetValue(cacheName, dbQuery);
                Cache.SetValue(cacheNameViews, listViews);

                return View();
            }
        }
        public ActionResult Detail(string url)
        {
            string cacheName = "[cms_Dictionary].Cache_Dictionary_Detail_" + url;
            var getCache = Cache.GetValue(cacheName) as Cms_DictionaryEntity;
            if (getCache != null)
            {
                ViewBag.Data = getCache;
                SQLServerConnection<Cms_News> sQLServer = new SQLServerConnection<Cms_News>();
                ViewBag.RelateNews = sQLServer.SelectQueryCommand("SP_cms_News_SelectByWhereINPrimarykey", Common.getConnectionString(), getCache.NewIds) ?? new List<Cms_News>();
                ViewBag.Keyword = sQLServer.SelectQueryCommand("SP_cms_News_SelectSearchNew", Common.getConnectionString(), 0, getCache.Name);
                SQLServerConnection<Cms_Doctor> sQLServerDoctor = new SQLServerConnection<Cms_Doctor>();
                List<Cms_Doctor> _Cms_Doctor = sQLServerDoctor.SelectQueryCommand("SP_cms_Doctor_SelectByID_Cate", Common.getConnectionString(), getCache.DoctorID);
                if (_Cms_Doctor.Count > 0) ViewBag.Doctor = _Cms_Doctor[0];
                return View();
            }
            else
            {


                var dbQuery = Cms_DictionaryService.Instance.CreateQuery()
                                            .Where(o => o.IsActive == true && o.Url == url)
                                            .ToSingle();
                if (dbQuery != null)
                {
                    dbQuery.Upview();
                    SQLServerConnection<Cms_News> sQLServer = new SQLServerConnection<Cms_News>();
                    ViewBag.RelateNews = sQLServer.SelectQueryCommand("SP_cms_News_SelectByWhereINPrimarykey", Common.getConnectionString(), dbQuery.NewIds) ?? new List<Cms_News>();
                    ViewBag.Keyword = sQLServer.SelectQueryCommand("SP_cms_News_SelectSearchNew", Common.getConnectionString(), 0, dbQuery.Name);
                    SQLServerConnection<Cms_Doctor> sQLServerDoctor = new SQLServerConnection<Cms_Doctor>();
                    List<Cms_Doctor> _Cms_Doctor = sQLServerDoctor.SelectQueryCommand("SP_cms_Doctor_SelectByID_Cate", Common.getConnectionString(), dbQuery.DoctorID);
                    if (_Cms_Doctor.Count > 0) ViewBag.Doctor = _Cms_Doctor[0];

                    ViewBag.Data = dbQuery;
                    Cache.SetValue(cacheName, dbQuery);
                  
                }



                return View();
            }
        }

    }


}