using CaptchaMvc.HtmlHelpers;
using CMS_Core.Common;
using MEDLATEC.BusinessLayer;
using MEDLATEC2019.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;


namespace MEDLATEC2019.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryNews()
        {
            return View();
        }
        public ActionResult HomeNews()
        {
            SQLServerConnection<Cms_News> sQLServer = new SQLServerConnection<Cms_News>();
            List<Cms_News> _News = sQLServer.SelectQueryCommand("SP_cms_News_Cate_Level", Common.getConnectionString(), "00004");

            //List<Cms_News> _NewsDichvu = sQLServer.SelectQueryCommand("SP_cms_News_SelectTopDichvu", Common.getConnectionString());
            ViewBag.News = _News;

            SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsYkhoa = sQLServer1.SelectQueryCommand("SP_cms_News_Cate_Level", Common.getConnectionString(), "00002");

            //List<Cms_News> _NewsDichvu = sQLServer.SelectQueryCommand("SP_cms_News_SelectTopDichvu", Common.getConnectionString());
            ViewBag.NewsYkhoa = _NewsYkhoa;
            SQLServerConnection<Cms_News> sQLServer3 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _TinNoiBat = sQLServer3.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.TinNoiBat = _TinNoiBat;

            return View();
        }

        public ActionResult AmpNews(string cid, string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    SQLServerConnection<Cms_News> sQLServer = new SQLServerConnection<Cms_News>();
                    SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                    SQLServerConnection<Cms_News> sQLServer3 = new SQLServerConnection<Cms_News>();
                    SQLServerConnection<Cms_NewsTags> sQLServer4 = new SQLServerConnection<Cms_NewsTags>();
                    List<Cms_News> _NewsDichvu = sQLServer.SelectQueryCommand("SP_cms_News_SelectByPrimaryKey", Common.getConnectionString(), int.Parse(id));




                    ViewBag.NewsDichvu = _NewsDichvu;

                    if (_NewsDichvu != null)
                    {
                        if (_NewsDichvu.Count > 0)
                        {

                            //string url = this.HttpContext.Request.Url.ToString();
                            //string dauten = "";
                            //string duoiten = "";
                            //if (url.Contains("?"))
                            //{
                            //    int vitri = url.IndexOf("?");
                            //    dauten = url.Substring(0, vitri);
                            //    duoiten = url.Replace(url.Substring(0, vitri), "");
                            //    string linkcheck = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByNews("tin-tuc", CMS_Core.Common.Common.removeCharEncode(_NewsDichvu[0].NewsName.ToString().ToLower().TrimStart().TrimEnd()), "s" + _NewsDichvu[0].CateId.ToString(), "n" + _NewsDichvu[0].NewsId.ToString());

                            //    if (dauten != linkcheck)
                            //    {
                            //        Response.RedirectPermanent(linkcheck + duoiten, false);
                            //    }
                            //}
                            //else
                            //{
                            //    string linkcheck = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByNews("tin-tuc", CMS_Core.Common.Common.removeCharEncode(_NewsDichvu[0].NewsName.ToString().ToLower().TrimStart().TrimEnd()), "s" + _NewsDichvu[0].CateId.ToString(), "n" + _NewsDichvu[0].NewsId.ToString());

                            //    if (url != linkcheck)
                            //    {
                            //        Response.RedirectPermanent(linkcheck, false);
                            //    }
                            //}




                            List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("SP_cms_News_TinCungChuyenMuc", Common.getConnectionString(), _NewsDichvu[0].CateId);
                            ViewBag.NewsCate = _NewsCate;

                            List<Cms_News> _TinLienquan = sQLServer3.SelectQueryCommand("SP_cms_News_Tinlienquan", Common.getConnectionString(), id);
                            ViewBag.TinLienQuan = _TinLienquan;

                            List<Cms_NewsTags> _Tag = sQLServer4.SelectQueryCommand("Get_Tags_ByNewsid", Common.getConnectionString(), id);
                            ViewBag.Tag = _Tag;



                        }
                        else
                        {
                            Response.Redirect("https://medlatec.vn/tin-tuc/tin-tuc-y-hoc-s28", true);
                             
                        }
                    }
                }
                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

            }
            catch (Exception ex)
            {

            }

            return View();
        }

        public ActionResult NewsDetails(string cid, string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    SQLServerConnection<Cms_News> sQLServer = new SQLServerConnection<Cms_News>();
                    SQLServerConnection<Cms_News> sQLServer2 = new SQLServerConnection<Cms_News>();
                    SQLServerConnection<Cms_News> sQLServer3 = new SQLServerConnection<Cms_News>();
                    SQLServerConnection<Cms_NewsTags> sQLServer4 = new SQLServerConnection<Cms_NewsTags>();
                    SQLServerConnection<Entity.cms_Banner_rows> sQLServer5 = new SQLServerConnection<Entity.cms_Banner_rows>();
                    //   SQLServerConnection<cms_Comment> sQLServer5 = new SQLServerConnection<cms_Comment>();

                    List<Cms_News> _NewsDichvu = sQLServer.SelectQueryCommand("SP_cms_News_SelectByPrimaryKey", Common.getConnectionString(), int.Parse(id));
                    ViewBag.NewsDichvu = _NewsDichvu;

                    if (_NewsDichvu != null)
                    {
                        if (_NewsDichvu.Count > 0)
                        {

                            //string url = this.HttpContext.Request.Url.ToString();
                            //string dauten = "";
                            //string duoiten = "";
                            //if (url.Contains("?"))
                            //{
                            //    int vitri = url.IndexOf("?");
                            //    dauten = url.Substring(0, vitri);
                            //    duoiten = url.Replace(url.Substring(0, vitri), "");
                            //    string linkcheck = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByNews("tin-tuc", CMS_Core.Common.Common.removeCharEncode(_NewsDichvu[0].NewsName.ToString().ToLower().TrimStart().TrimEnd()), "s" + _NewsDichvu[0].CateId.ToString(), "n" + _NewsDichvu[0].NewsId.ToString());

                            //    if (dauten != linkcheck)
                            //    {
                            //        Response.RedirectPermanent(linkcheck + duoiten, false);
                            //    }
                            //}
                            //else
                            //{
                            //    string linkcheck = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByNews("tin-tuc", CMS_Core.Common.Common.removeCharEncode(_NewsDichvu[0].NewsName.ToString().ToLower().TrimStart().TrimEnd()), "s" + _NewsDichvu[0].CateId.ToString(), "n" + _NewsDichvu[0].NewsId.ToString());

                            //    if (url != linkcheck)
                            //    {
                            //        Response.RedirectPermanent(linkcheck, false);
                            //    }
                            //}




                            List<Cms_News> _NewsCate = sQLServer2.SelectQueryCommand("SP_cms_News_TinCungChuyenMuc", Common.getConnectionString(), _NewsDichvu[0].CateId);
                            ViewBag.NewsCate = _NewsCate;

                            List<Cms_News> _TinLienquan = sQLServer3.SelectQueryCommand("SP_cms_News_Tinlienquan", Common.getConnectionString(), id);
                            ViewBag.TinLienQuan = _TinLienquan;

                            List<Cms_NewsTags> _Tag = sQLServer4.SelectQueryCommand("Get_Tags_ByNewsid", Common.getConnectionString(), id);
                            ViewBag.Tag = _Tag;

                            List<Entity.cms_Banner_rows> Banner = sQLServer5.SelectQueryCommand("cms_Banner_Plans$Web", Common.getConnectionString());
                            ViewBag.Banner = Banner;

                            List<Entity.cms_Banner_rows> BannerMobile = sQLServer5.SelectQueryCommand("cms_Banner_Plans$Mobile", Common.getConnectionString());
                            ViewBag.BannerMobile = BannerMobile;
                            //List<cms_Comment> _Comment = sQLServer5.SelectQueryCommand("SP_cms_Comment_SelectByNewsID", Common.getConnectionString(), id);
                            //ViewBag.Comment = _Comment;

                        }
                        else
                        {
                            Response.Redirect("https://medlatec.vn/tin-tuc/tin-tuc-y-hoc-s28", true);
                           // Response.RedirectPermanent("https://medlatec.vn/tin-tuc/tin-tuc-y-hoc-s28", false);
                        }
                    }
                }
                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

            }
            catch (Exception ex)
            {

            }

            return View();
        }

        public ActionResult NewsTags(string id, string size, string page)
        {
            try
            {
                int pagesize = 0;
                if (!string.IsNullOrEmpty(id))
                {
                    if (page != null)
                    {
                        pagesize = int.Parse(page);
                    }
                    else
                    {
                        pagesize = 1;
                    }
                    List<Cms_News> _Newstags;
                    SQLServerConnection<Cms_News> sQLServer = new SQLServerConnection<Cms_News>();
                    _Newstags = sQLServer.SelectQueryCommand("Get_NewsByTagsIDAndPage", Common.getConnectionString(), id, 15, pagesize);
                    if (_Newstags.Count == 0)
                    {
                        SQLServerConnection<Cms_News> sQLServer4 = new SQLServerConnection<Cms_News>();
                        _Newstags = sQLServer4.SelectQueryCommand("Get_NewsByTagsIDAndPage", Common.getConnectionString(), id, 15, 1);
                        if (_Newstags.Count > 0)
                        {
                            ViewBag.Newstags = _Newstags;
                            ViewBag.page = 1;
                            string abc = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByTags("chu-de", _Newstags[0].TagName.ToString().ToLower().TrimStart().TrimEnd(), "t" + _Newstags[0].TagId.ToString());
                            Response.RedirectPermanent(abc, false);

                        }
                        else
                        {
                            Response.RedirectPermanent("https://medlatec.vn", false);
                        }

                    }
                    else
                    {

                        ViewBag.Newstags = _Newstags;
                        ViewBag.page = pagesize;
                    }



                    SQLServerConnection<Cms_News> sQLServer3 = new SQLServerConnection<Cms_News>();
                    List<Cms_News> _NewsTagsTotal = sQLServer3.SelectQueryCommand("Get_NewsByTagsIDAndPage_Total", Common.getConnectionString(), int.Parse(id));
                    ViewBag.NewsTagsTotal = _NewsTagsTotal;



                }
                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

            }
            catch (Exception ex)
            {

            }


            return View();
        }


        public ActionResult NewsCate(string cid, string size, string page)
        {
            try
            {
                int pagesize = 0;
                if (!string.IsNullOrEmpty(cid))
                {
                    if (page != null)
                    {
                        pagesize = int.Parse(page);
                    }
                    else
                    {
                        pagesize = 1;
                    }
                    List<Cms_News> _NewsCate;
                    SQLServerConnection<Cms_News> sQLServer = new SQLServerConnection<Cms_News>();
                    _NewsCate = sQLServer.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), cid, 15, pagesize);
                    if (_NewsCate.Count == 0)
                    {
                        SQLServerConnection<Cms_News> sQLServer4 = new SQLServerConnection<Cms_News>();
                        _NewsCate = sQLServer4.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), cid, 15, 1);
                        if (_NewsCate.Count > 0)
                        {
                            ViewBag.NewsCate = _NewsCate;
                            ViewBag.page = 1;
                            string abc = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByCate("tin-tuc", _NewsCate[0].CateName.ToString().ToLower().TrimStart().TrimEnd(), "s" + _NewsCate[0].CateId.ToString());
                            Response.RedirectPermanent(abc, true);

                        }
                        else
                        {
                            Response.RedirectPermanent("https://medlatec.vn", true);
                            ViewBag.page = 1;
                        }

                    }
                    else
                    {

                        ViewBag.NewsCate = _NewsCate;
                        ViewBag.page = pagesize;
                    }


                    SQLServerConnection<tbl_seo> sQLServerSeo = new SQLServerConnection<tbl_seo>();
                    List<tbl_seo> _seo = sQLServerSeo.SelectQueryCommand("Get_SeoByCateID", Common.getConnectionString(), cid);
                    if (_seo != null)
                    {
                        if (_seo.Count > 0)
                        {
                            foreach (var data in _seo)
                            {
                                if (data.type == 1)
                                {
                                    ViewBag.keywords = data.Content;
                                }

                                if (data.type == 2)
                                {
                                    ViewBag.description = data.Content;
                                }
                            }

                        }
                    }


                    SQLServerConnection<Cms_News> sQLServer3 = new SQLServerConnection<Cms_News>();
                    List<Cms_News> _NewsCateTotal = sQLServer3.SelectQueryCommand("Get_NewsByCateIDAndPage_Total", Common.getConnectionString(), int.Parse(cid));
                    ViewBag.NewsCateTotal = _NewsCateTotal;



                }
                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

            }
            catch (Exception ex)
            {

            }


            return View();
        }
        public static bool IsNumeric(string input)
        {
            return Regex.IsMatch(input, @"^\d+$");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult HomeNews(FormCollection form)
        {

            SQLServerConnection<Cms_News> sQLServer = new SQLServerConnection<Cms_News>();
            List<Cms_News> _News = sQLServer.SelectQueryCommand("SP_cms_News_Cate_Level", Common.getConnectionString(), "00004");

            //List<Cms_News> _NewsDichvu = sQLServer.SelectQueryCommand("SP_cms_News_SelectTopDichvu", Common.getConnectionString());
            ViewBag.News = _News;

            SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsYkhoa = sQLServer1.SelectQueryCommand("SP_cms_News_Cate_Level", Common.getConnectionString(), "00002");

            //List<Cms_News> _NewsDichvu = sQLServer.SelectQueryCommand("SP_cms_News_SelectTopDichvu", Common.getConnectionString());
            ViewBag.NewsYkhoa = _NewsYkhoa;
            SQLServerConnection<Cms_News> sQLServer3 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _TinNoiBat = sQLServer3.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
            ViewBag.TinNoiBat = _TinNoiBat;


            try
            {

                //string ghichuwweb = "";
                //if (!this.IsCaptchaValid("Validate your captcha"))
                //{
                //    TempData["msg"] = "<script>alert('Mã xác nhận không đúng vui lòng nhập chính xác cả chữ in hoa và chữ thường.');</script>";



                //    return View();
                //}

                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtsdt"].ToString().Trim()))
                {
                    if (IsNumeric(form["txtsdt"].ToString().Trim()))
                    {

                        if ((form["txtsdt"].ToString().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện không đúng');</script>";
                            return View();
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập số điện thoại');</script>";
                    return View();

                }



                //SqlConnection _conn;
                //_conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                //_conn.Open();



                //// Info.  
                //string sql = string.Empty;
                //sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,email,Ghichudv,PLDL) values(";
                //sql += "@hoten,@sdt,@ngayhen,@ghichu,0,@email,N'WebMed - Đăng ký nhanh từ trang home tin tức','WEBMEDMOI')";


                //SqlCommand comd = new SqlCommand(sql, _conn);

                //string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");

                //comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                //comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 10).Value = form["txtsdt"].ToString();
                //comd.Parameters.Add("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                //comd.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();
                //comd.Parameters.Add("@email", SqlDbType.NVarChar, 30).Value = form["txtemail"].ToString();


                CMS_Core.Common.Common.DatlichTin(form["txthoten"].ToString(), form["txtsdt"].ToString(), form["txtghichu"].ToString(), form["txtemail"].ToString(), "WebMed - Đăng ký nhanh từ trang home tin tức", "WEBMEDMOI");


                //  comd.ExecuteNonQuery();
                //  _conn.Close();

                Response.Redirect("/thankyou?u=trangchutin", false);
                // TempData["msg"] = "<script>alert('Cảm ơn Quý khách đã đăng ký với chúng tôi. Chúng tôi sẽ liên lạc với Quý khách để xác nhận lịch hẹn.LH 1900565656 khi cần hỗ trợ. Rất hân hạnh được phục vụ!');</script>";
                // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                // TempData["msg"] = "<script>alert('Cam on Quy khach da dang ky DV Kham tai nha. Chung toi se lien lac voi Quy khach de xac nhan lich hen. LH 1900565656 khi can ho tro. Rat han hanh duoc phuc vu!    ');</script>";
            }
            catch (Exception ex)
            {

            }




            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult NewsDetails(string id, FormCollection form)
        {


            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    SQLServerConnection<Cms_News> sQLServer = new SQLServerConnection<Cms_News>();
                    List<Cms_News> _NewsDichvu = sQLServer.SelectQueryCommand("SP_cms_News_SelectByPrimaryKey", Common.getConnectionString(), int.Parse(id));
                    ViewBag.NewsDichvu = _NewsDichvu;


                    if (_NewsDichvu != null)
                    {
                        if (_NewsDichvu.Count > 0)
                        {
                            string url = this.HttpContext.Request.Url.ToString();


                            string linkcheck = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByNews("tin-tuc", _NewsDichvu[0].NewsName.ToString().ToLower().TrimStart().TrimEnd(), "s" + _NewsDichvu[0].CateId.ToString(), "n" + _NewsDichvu[0].NewsId.ToString());

                            if (url != linkcheck)
                            {
                                Response.RedirectPermanent(linkcheck, false);
                            }


                            List<Cms_News> _NewsCate = sQLServer.SelectQueryCommand("SP_cms_News_TinCungChuyenMuc", Common.getConnectionString(), _NewsDichvu[0].CateId);
                            ViewBag.NewsCate = _NewsCate;

                            List<Cms_News> _TinLienquan = sQLServer.SelectQueryCommand("SP_cms_News_Tinlienquan", Common.getConnectionString(), id);
                            ViewBag.TinLienQuan = _TinLienquan;
                        }
                    }
                }
                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

                //}
                //catch (Exception ex)
                //{

                //}
                string ghichuwweb = "";


                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtsdt"].ToString().Trim()))
                {
                    if (IsNumeric(form["txtsdt"].ToString().Trim()))
                    {

                        if ((form["txtsdt"].ToString().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện không đúng');</script>";
                            return View();
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập số điện thoại');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtghichu"].ToString().Trim()))
                {

                }
                else
                {
                    ghichuwweb = "Khách hàng liên hệ từ website medlatec.";

                }



                CMS_Core.Common.Common.DatlichTin(form["txthoten"].ToString(), form["txtsdt"].ToString(), form["txtghichu"].ToString(), form["txtemail"].ToString(), "WebMed - Đăng ký nhanh từ tin chi tiết", "WEBMEDMOI");


                Response.Redirect("/thankyou?u=tinchitiet", false);
                // TempData["msg"] = "<script>alert('Cảm ơn Quý khách đã đăng ký với chúng tôi. Chúng tôi sẽ liên lạc với Quý khách để xác nhận lịch hẹn.LH 1900565656 khi cần hỗ trợ. Rất hân hạnh được phục vụ!');</script>";
                // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                // TempData["msg"] = "<script>alert('Cam on Quy khach da dang ky DV Kham tai nha. Chung toi se lien lac voi Quy khach de xac nhan lich hen. LH 1900565656 khi can ho tro. Rat han hanh duoc phuc vu!    ');</script>";
            }
            catch (Exception ex)
            {
                Response.Redirect("https://medlatec.vn", false);
            }




            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewsCate(string cid, string size, string page, FormCollection form)
        {


            try
            {
                int pagesize = 0;
                if (!string.IsNullOrEmpty(cid))
                {
                    if (page != null)
                    {
                        pagesize = int.Parse(page);
                    }
                    else
                    {
                        pagesize = 1;
                    }

                    SQLServerConnection<Cms_News> sQLServer = new SQLServerConnection<Cms_News>();
                    List<Cms_News> _NewsCate = sQLServer.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), cid, 15, pagesize);
                    ViewBag.NewsCate = _NewsCate;

                    SQLServerConnection<tbl_seo> sQLServerSeo = new SQLServerConnection<tbl_seo>();
                    List<tbl_seo> _seo = sQLServerSeo.SelectQueryCommand("Get_SeoByCateID", Common.getConnectionString(), cid );
                    if(_seo != null)
                    {
                        if(_seo.Count > 0 )
                        {
                            foreach( var data in _seo)
                            {
                                if(data.type == 1)
                                {
                                    ViewBag.keywords = data.Content;
                                }

                                if (data.type == 2)
                                {
                                    ViewBag.description = data.Content;
                                }
                            }
                            
                        }
                    }

                   


                    SQLServerConnection<Cms_News> sQLServer3 = new SQLServerConnection<Cms_News>();
                    List<Cms_News> _NewsCateTotal = sQLServer3.SelectQueryCommand("Get_NewsByCateIDAndPage_Total", Common.getConnectionString(), int.Parse(cid));
                    ViewBag.NewsCateTotal = _NewsCateTotal;

                    ViewBag.page = pagesize;

                }
                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

            }
            catch (Exception ex)
            {

            }


            try
            {

                string ghichuwweb = "";
                if (!this.IsCaptchaValid("Validate your captcha"))
                {
                    TempData["msg"] = "<script>alert('Mã xác nhận không đúng vui lòng nhập chính xác cả chữ in hoa và chữ thường.');</script>";
                    return View();
                }

                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtsdt"].ToString().Trim()))
                {
                    if (IsNumeric(form["txtsdt"].ToString().Trim()))
                    {

                        if ((form["txtsdt"].ToString().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện không đúng');</script>";
                            return View();
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập số điện thoại');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtghichu"].ToString().Trim()))
                {

                }
                else
                {
                    ghichuwweb = "Khách hàng liên hệ từ website medlatec.";

                }


                //SqlConnection _conn;
                //_conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                //_conn.Open();



                //// Info.  
                //string sql = string.Empty;
                //sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,email,Ghichudv,PLDL) values(";
                //sql += "@hoten,@sdt,@ngayhen,@ghichu,0,@email,N'WebMed - Đăng ký nhanh từ webmoi','WEBMEDMOI')";


                //SqlCommand comd = new SqlCommand(sql, _conn);

                //string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");

                //comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                //comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 10).Value = form["txtsdt"].ToString();
                //comd.Parameters.Add("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                //comd.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();
                //comd.Parameters.Add("@email", SqlDbType.NVarChar, 30).Value = form["txtemail"].ToString();





                ////  comd.ExecuteNonQuery();
                //_conn.Close();
                CMS_Core.Common.Common.DatlichTin(form["txthoten"].ToString(), form["txtsdt"].ToString(), form["txtghichu"].ToString(), form["txtemail"].ToString(), "WebMed - Đăng ký nhanh từ danh mục tin", "WEBMEDMOI");


                Response.Redirect("/thankyou?u=trangdanhmuctin", false);
                // TempData["msg"] = "<script>alert('Cảm ơn Quý khách đã đăng ký với chúng tôi. Chúng tôi sẽ liên lạc với Quý khách để xác nhận lịch hẹn.LH 1900565656 khi cần hỗ trợ. Rất hân hạnh được phục vụ!');</script>";
                // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                // TempData["msg"] = "<script>alert('Cam on Quy khach da dang ky DV Kham tai nha. Chung toi se lien lac voi Quy khach de xac nhan lich hen. LH 1900565656 khi can ho tro. Rat han hanh duoc phuc vu!    ');</script>";
            }
            catch (Exception ex)
            {

            }




            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult AmpNews(string id, FormCollection form)
        {


            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    SQLServerConnection<Cms_News> sQLServer = new SQLServerConnection<Cms_News>();
                    SQLServerConnection<Entity.cms_Banner_rows> sQLServer5 = new SQLServerConnection<Entity.cms_Banner_rows>();

                    List<Cms_News> _NewsDichvu = sQLServer.SelectQueryCommand("SP_cms_News_SelectByPrimaryKey", Common.getConnectionString(), int.Parse(id));
                    ViewBag.NewsDichvu = _NewsDichvu;


                    if (_NewsDichvu != null)
                    {
                        if (_NewsDichvu.Count > 0)
                        {
                            List<Cms_News> _NewsCate = sQLServer.SelectQueryCommand("SP_cms_News_TinCungChuyenMuc", Common.getConnectionString(), _NewsDichvu[0].CateId);
                            ViewBag.NewsCate = _NewsCate;

                            List<Cms_News> _TinLienquan = sQLServer.SelectQueryCommand("SP_cms_News_Tinlienquan", Common.getConnectionString(), id);
                            ViewBag.TinLienQuan = _TinLienquan;

                            //List<Entity.cms_Banner_rows> Banner = sQLServer5.SelectQueryCommand("cms_Banner_Plans$Web", Common.getConnectionString());
                            //ViewBag.Banner = Banner;

                        }
                    }
                }
                SQLServerConnection<Cms_News> sQLServer1 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _TinNoiBat = sQLServer1.SelectQueryCommand("SP_cms_News_SelectTopNew", Common.getConnectionString());
                ViewBag.TinNoiBat = _TinNoiBat;

                //}
                //catch (Exception ex)
                //{

                //}
                string ghichuwweb = "";


                if (!string.IsNullOrEmpty(form["txthoten"].ToString().Trim()))
                {

                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập họ tên');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtsdt"].ToString().Trim()))
                {
                    if (IsNumeric(form["txtsdt"].ToString().Trim()))
                    {

                        if ((form["txtsdt"].ToString().Length != 10))
                        {
                            TempData["msg"] = "<script>alert('Số điện không đúng');</script>";
                            return View();
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                    TempData["msg"] = "<script>alert('Mời bạn nhập số điện thoại');</script>";
                    return View();

                }
                if (!string.IsNullOrEmpty(form["txtghichu"].ToString().Trim()))
                {

                }
                else
                {
                    ghichuwweb = "Khách hàng liên hệ từ website medlatec.";

                }


                SqlConnection _conn;
                _conn = new SqlConnection(ConfigurationManager.AppSettings["Datlich.ConnectionString"]);
                _conn.Open();



                // Info.  
                string sql = string.Empty;
                sql = "insert into Datlich(tenkh,sodt,ngayhen,ghichu,tinhtrang,email,Ghichudv,PLDL) values(";
                sql += "@hoten,@sdt,@ngayhen,@ghichu,0,@email,N'WebMed - Đăng ký nhanh từ tin AMP chi tiết','WEBMEDMOI')";


                SqlCommand comd = new SqlCommand(sql, _conn);

                string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");

                comd.Parameters.Add("@hoten", SqlDbType.NVarChar, 30).Value = form["txthoten"].ToString();
                comd.Parameters.Add("@sdt", SqlDbType.NVarChar, 10).Value = form["txtsdt"].ToString();
                comd.Parameters.Add("@ngayhen", SqlDbType.DateTime).Value = DateTime.Parse(abc);
                comd.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = form["txtghichu"].ToString();
                comd.Parameters.Add("@email", SqlDbType.NVarChar, 30).Value = form["txtemail"].ToString();


                comd.ExecuteNonQuery();
                _conn.Close();

                Response.Redirect("/thankyou", false);
                // TempData["msg"] = "<script>alert('Cảm ơn Quý khách đã đăng ký với chúng tôi. Chúng tôi sẽ liên lạc với Quý khách để xác nhận lịch hẹn.LH 1900565656 khi cần hỗ trợ. Rất hân hạnh được phục vụ!');</script>";
                // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                // TempData["msg"] = "<script>alert('Cam on Quy khach da dang ky DV Kham tai nha. Chung toi se lien lac voi Quy khach de xac nhan lich hen. LH 1900565656 khi can ho tro. Rat han hanh duoc phuc vu!    ');</script>";
            }
            catch (Exception ex)
            {
                Response.Redirect("https://medlatec.vn", false);
            }




            return View();
        }

    }
}