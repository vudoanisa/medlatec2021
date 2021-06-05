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

    public class ScientistController : Controller
    {
        private SQLServerConnection<cms_Scientist> sQLServer;
        private SQLServerConnection<cms_Scientist_Cate> sQLServerCate;
        private SQLServerConnection<Cms_News> sQLServerNews;
        public ScientistController()
        {
            sQLServer = new SQLServerConnection<cms_Scientist>();
            sQLServerCate = new SQLServerConnection<cms_Scientist_Cate>();
            sQLServerNews = new SQLServerConnection<Cms_News>();
        }


        // GET: Scientist
        public ActionResult Index()
        {
            ScientistViewModel viewModel = new ScientistViewModel();
            this.ViewBag.NamThuchien = CMS_Core.Common.Common.getNamThuchien();
            this.ViewBag.getChuyenKhoa = CMS_Core.Common.Common.getChuyenKhoa();

            viewModel.PersionPerform = string.Empty;
            viewModel.keyworkd = string.Empty;
            viewModel.DatePerform = string.Empty;
            viewModel.ScientistCate = "0";

            List<cms_Scientist> Scientists = sQLServer.SelectQueryCommand("cms_Scientist_web", Common.getConnectionString(), viewModel.DatePerform, viewModel.ScientistCate, viewModel.keyworkd, viewModel.PersionPerform);

            viewModel.Scientist = Scientists;


            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ScientistViewModel viewModel, string submit)
        {
            this.ViewBag.NamThuchien = CMS_Core.Common.Common.getNamThuchien();
            this.ViewBag.getChuyenKhoa = CMS_Core.Common.Common.getChuyenKhoa();

            try
            {
                if (string.IsNullOrEmpty(viewModel.keyworkd))
                    viewModel.keyworkd = string.Empty;

                if (string.IsNullOrEmpty(viewModel.PersionPerform))
                    viewModel.PersionPerform = string.Empty;

                if (string.IsNullOrEmpty(viewModel.DatePerform))
                    viewModel.DatePerform = string.Empty;

                if (string.IsNullOrEmpty(viewModel.ScientistCate))
                    viewModel.ScientistCate = "0";


                List<cms_Scientist> Scientists = sQLServer.SelectQueryCommand("cms_Scientist_web", Common.getConnectionString(), viewModel.DatePerform, viewModel.ScientistCate, viewModel.keyworkd, viewModel.PersionPerform);

                viewModel.Scientist = Scientists;


            }
            catch (Exception ex)
            {

            }

            // Info.  
            return View(viewModel);
        }



        public ActionResult ScientistDetails(string cid, string id)
        {

            ScientistViewModel viewModel = new ScientistViewModel();
            this.ViewBag.NamThuchien = CMS_Core.Common.Common.getNamThuchien();
            this.ViewBag.getChuyenKhoa = CMS_Core.Common.Common.getChuyenKhoa();

            if (string.IsNullOrEmpty(cid))
            {
                cid = "0";
            }

            if (string.IsNullOrEmpty(id))
            {
                id = "0";
            }


            viewModel.PersionPerform = string.Empty;
            viewModel.keyworkd = string.Empty;
            viewModel.DatePerform = string.Empty;
            viewModel.ScientistCate = "0";

            List<cms_Scientist> ScientistHome = sQLServer.SelectQueryCommand("cms_Scientist_ByID", Common.getConnectionString(), id);
            if (ScientistHome != null)
            {
                if (ScientistHome.Count > 0)
                {
                    viewModel.ScientistDetail = ScientistHome[0];
                }
            }

            List<Cms_News> News = sQLServerNews.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), 199, 15, 1);

            viewModel.News = News;


            List<cms_Scientist> Scientists = sQLServer.SelectQueryCommand("cms_Scientist_CateIDAndID", Common.getConnectionString(), cid, id);

            viewModel.Scientist = Scientists;
            

            return View(viewModel);
        }


        // GET: Scientist
        public ActionResult ScientistCate(string cid, string size, string page)
        {
            ScientistViewModel viewModel = new ScientistViewModel();
            this.ViewBag.NamThuchien = CMS_Core.Common.Common.getNamThuchien();
            this.ViewBag.getChuyenKhoa = CMS_Core.Common.Common.getChuyenKhoa();

            viewModel.PersionPerform = string.Empty;
            viewModel.keyworkd = string.Empty;
            viewModel.DatePerform = string.Empty;
            viewModel.ScientistCate = cid;

            if (string.IsNullOrEmpty(cid))
            {
                cid = "0";
            }

            if (string.IsNullOrEmpty(size))
            {
                size = "15";
            }

            if (string.IsNullOrEmpty(page))
            {
                page = "1";
            }


            List<cms_Scientist> Scientists = sQLServer.SelectQueryCommand("Get_cms_ScientistByCateIDAndPage", Common.getConnectionString(), cid, size, page);

            viewModel.Scientist = Scientists;

            List<cms_Scientist> ScientistsTotal = sQLServer.SelectQueryCommand("Get_cms_Scientist_Total", Common.getConnectionString(), cid);

            viewModel.tongso = ScientistsTotal[0].tongso;
            viewModel.page = Convert.ToInt32(page);

            List<cms_Scientist_Cate> Scientist_Cate = sQLServerCate.SelectQueryCommand("Get_cms_Scientist_ByCateid", Common.getConnectionString(), cid);
            if(Scientist_Cate != null)
            {
                if(Scientist_Cate.Count > 0)
                {
                    viewModel.Scientist_Cates = Scientist_Cate;
                }
            }

            viewModel.ScientistNew = null;


            return View(viewModel);
        }


    }
}