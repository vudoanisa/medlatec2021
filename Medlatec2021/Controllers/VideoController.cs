using CMS_Core.Common;
using MEDLATEC.BusinessLayer;
using MEDLATEC2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MEDLATEC2019.Controllers
{
    public class VideoController : Controller
    {
        private SQLServerConnection<Cms_Video> sQLServer;

        public VideoController()
        {
            sQLServer = new SQLServerConnection<Cms_Video>();
        }


        // GET: Video
        public ActionResult Index()
        {
            VideoHomeViewModel viewModel = new VideoHomeViewModel();
            List<Cms_Video> Cms_VideoHome;
            List<Cms_Video> Cms_VideoCate1;
            Cms_VideoHome = sQLServer.SelectQueryCommand("cms_Video_Home", Common.getConnectionString());
            if (Cms_VideoHome != null)
                if (Cms_VideoHome.Count > 0)
                {
                    viewModel.VideoTop = Cms_VideoHome[0];
                }

            Cms_VideoCate1 = sQLServer.SelectQueryCommand("cms_Video_HomeCate", Common.getConnectionString(), 11);
            viewModel.videoCate1 = Cms_VideoCate1;
            Cms_VideoCate1 = null;
            Cms_VideoCate1 = sQLServer.SelectQueryCommand("cms_Video_HomeCate", Common.getConnectionString(), 12);
            viewModel.videoCate2 = Cms_VideoCate1;

            Cms_VideoCate1 = null;
            Cms_VideoCate1 = sQLServer.SelectQueryCommand("cms_Video_HomeCate", Common.getConnectionString(), 13);
            viewModel.videoCate3 = Cms_VideoCate1;

            Cms_VideoCate1 = null;
            Cms_VideoCate1 = sQLServer.SelectQueryCommand("cms_Video_HomeCate", Common.getConnectionString(), 14);
            viewModel.videoCate4 = Cms_VideoCate1;

            Cms_VideoCate1 = null;
            Cms_VideoCate1 = sQLServer.SelectQueryCommand("cms_Video_HomeCate", Common.getConnectionString(), 15);
            viewModel.videoCate5 = Cms_VideoCate1;

            Cms_VideoCate1 = null;
            Cms_VideoCate1 = sQLServer.SelectQueryCommand("cms_Video_HomeCate", Common.getConnectionString(), 16);
            viewModel.videoCate6 = Cms_VideoCate1;

            Cms_VideoCate1 = null;
            Cms_VideoCate1 = sQLServer.SelectQueryCommand("cms_Video_HomeCate", Common.getConnectionString(), 17);
            viewModel.videoCate7 = Cms_VideoCate1;

            Cms_VideoCate1 = null;
            Cms_VideoCate1 = sQLServer.SelectQueryCommand("cms_Video_HomeCate", Common.getConnectionString(), 18);
            viewModel.videoCate8 = Cms_VideoCate1;

            Cms_VideoCate1 = null;
            Cms_VideoCate1 = sQLServer.SelectQueryCommand("cms_Video_HomeCate", Common.getConnectionString(), 19);
            viewModel.videoCate9 = Cms_VideoCate1;

            return View(viewModel);
        }
        public ActionResult VideoDetails(string cid, string id )
        {
            VideoHomeViewModel viewModel = new VideoHomeViewModel();
            List<Cms_Video> Cms_VideoHome;
            List<Cms_Video> Cms_VideoCate1;
            Cms_VideoHome = sQLServer.SelectQueryCommand("cms_Video_Detail", Common.getConnectionString(),id);
            if (Cms_VideoHome != null)
                if (Cms_VideoHome.Count > 0)
                {
                    viewModel.VideoTop = Cms_VideoHome[0];
                }
 
            Cms_VideoCate1 = sQLServer.SelectQueryCommand("Get_VideoByCateIDAndPage", Common.getConnectionString(), cid, 12, 1,id);
            viewModel.videoCate1 = Cms_VideoCate1;



            return View(viewModel);
        }


        public ActionResult VideoCate(string cid, string page)
        {
            if(string.IsNullOrEmpty(cid))
            {
                cid = "11";
            }
            if (string.IsNullOrEmpty(page))
            {
                page = "1";
            }


            VideoHomeViewModel viewModel = new VideoHomeViewModel();
            List<Cms_Video> Cms_VideoHome;
            List<Cms_Video> Cms_VideoCate1;
            Cms_VideoHome = sQLServer.SelectQueryCommand("cms_Video_Cate", Common.getConnectionString(), cid);
            if (Cms_VideoHome != null)
                if (Cms_VideoHome.Count > 0)
                {
                    viewModel.VideoTop = Cms_VideoHome[0];
                }

            
            Cms_VideoCate1 = sQLServer.SelectQueryCommand("Get_VideoByCateIDAndPage", Common.getConnectionString(), cid,12, page, viewModel.VideoTop.videoId);
            viewModel.videoCate1 = Cms_VideoCate1;



            return View(viewModel);

        }


        [HttpPost]     
        public JsonResult VideoCateLoad(string cid, string page)
        {
            try
            {
                if (string.IsNullOrEmpty(cid))
                {
                    cid = "11";
                }
                if (string.IsNullOrEmpty(page))
                {
                    page = "1";
                    if (Convert.ToInt32(page) > 20)
                    {
                        page = "20";
                    }
                }

                IEnumerable<Cms_Video> modelList = new List<Cms_Video>();

                modelList = sQLServer.SelectQueryCommand("Get_VideoByCateIDAndPage", Common.getConnectionString(), cid, 12, page, 0);


                //  modelList = impcms_Menu.GetAllcms_MenuChildByUserid(  UserInfo.uid);
                return Json(modelList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                
                return Json(string.Empty);
            }
        }

        [HttpPost]
        public JsonResult VideoDetailLoad(string cid, string page, string videoid)
        {
            try
            {
                if (string.IsNullOrEmpty(cid))
                {
                    cid = "11";
                }
                if (string.IsNullOrEmpty(page))
                {
                    page = "1";
                    if(Convert.ToInt32(page) > 20)
                    {
                        page = "20";
                    }
                }


                IEnumerable<Cms_Video> modelList = new List<Cms_Video>();

                modelList = sQLServer.SelectQueryCommand("Get_VideoByCateIDAndPage", Common.getConnectionString(), cid, 12, page, videoid);


                //  modelList = impcms_Menu.GetAllcms_MenuChildByUserid(  UserInfo.uid);
                return Json(modelList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(string.Empty);
            }
        }



    }
}