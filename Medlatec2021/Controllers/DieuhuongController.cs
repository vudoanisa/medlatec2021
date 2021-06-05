using CMS_Core.Common;
using MEDLATEC.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MEDLATEC2019.Controllers
{
    public class DieuhuongController : Controller
    {
        // GET: Dieuhuong
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Chuyendoi(string id)
        {
            try
            {



                if (!string.IsNullOrEmpty(id))
                {
                    SQLServerConnection<Cms_News> sQLServer = new SQLServerConnection<Cms_News>();
                    List<Cms_News> NewsCate = sQLServer.SelectQueryCommand("SP_cms_News_SelectByPrimaryKey", Common.getConnectionString(), int.Parse(id));
                    if(NewsCate.Count > 0)
                    {
                        ViewBag.NewsCate = NewsCate;

                        // / @CMS_Core.Common.Common.GetURLDetailByNews("tin-tuc", NewsCate[i].NewsName.ToString().ToLower(), "s" + NewsCate[i].CateId.ToString(), "n" + NewsCate[i].NewsId.ToString())" title="@NewsCate[i].NewsName.ToString()"
                        Response.RedirectPermanent("/" + @CMS_Core.Common.Common.GetURLDetailByNews("tin-tuc", NewsCate[0].NewsName.ToString().ToLower(), "s" + NewsCate[0].CateId.ToString(), "n" + NewsCate[0].NewsId.ToString()), false);
                        //  Response.Redirect("/"+@CMS_Core.Common.Common.GetURLDetailByNews("tin-tuc", NewsCate[0].NewsName.ToString().ToLower(), "s" + NewsCate[0].CateId.ToString(), "n" + NewsCate[0].NewsId.ToString()), false);

                    }
                    else
                    {
                        
                        Response.RedirectPermanent("https://medlatec.vn",false);
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }



        public ActionResult datcauhoi()
        {
            try
            {

                // / @CMS_Core.Common.Common.GetURLDetailByNews("tin-tuc", NewsCate[i].NewsName.ToString().ToLower(), "s" + NewsCate[i].CateId.ToString(), "n" + NewsCate[i].NewsId.ToString())" title="@NewsCate[i].NewsName.ToString()"
                Response.RedirectPermanent("https://medlatec.vn/dat-cau-hoi", false);
                //  Response.Redirect("/"+@CMS_Core.Common.Common.GetURLDetailByNews("tin-tuc", NewsCate[0].NewsName.ToString().ToLower(), "s" + NewsCate[0].CateId.ToString(), "n" + NewsCate[0].NewsId.ToString()), false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult danhmuccauhoi(string qid)
        {
            try
            {

                SQLServerConnection<Question> sQLServer = new SQLServerConnection<Question>();
                List<Question> _QuestionCate = sQLServer.SelectQueryCommand("Question_GetByCateIDAndPage", Common.getConnectionStringIcnm(), qid, 20, 1);

                if (_QuestionCate.Count > 0)
                {
                    Response.RedirectPermanent("/" + @CMS_Core.Common.Common.GetURLDetailByCate("hoi-dap", _QuestionCate[0].SpecialName.ToString().ToLower(), "c" + _QuestionCate[0].SpecialistID.ToString()), false);
                }
                else
                {
                    Response.RedirectPermanent("https://medlatec.vn", false);
                }
               
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult cauhoi11(string id)
        {
            try
            {

                SQLServerConnection<Question> sQLServer = new SQLServerConnection<Question>();
                List<Question> _Cauhoi = sQLServer.SelectQueryCommand("Question_GetTheoID", Common.getConnectionStringIcnm(), int.Parse(id));
                ViewBag.CauHoi = _Cauhoi;
                if(_Cauhoi.Count > 0)
                {
                    Response.RedirectPermanent("/" + @CMS_Core.Common.Common.GetURLDetailByNews("hoi-dap", _Cauhoi[0].QuestionTitle.ToString().ToLower(), "c" + _Cauhoi[0].SpecialistID.ToString(), "q" + _Cauhoi[0].QuestionID.ToString()), false);
                }
                else
                {
                    Response.RedirectPermanent("https://medlatec.vn",false);
                }

                
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult cauhoi12(string id)
        {
            try
            {
                
                SQLServerConnection<Question> sQLServer = new SQLServerConnection<Question>();
                List<Question> _Cauhoi = sQLServer.SelectQueryCommand("Question_GetTheoID", Common.getConnectionStringIcnm(), int.Parse(id));
                ViewBag.CauHoi = _Cauhoi;
                if (_Cauhoi.Count > 0)
                {
                    Response.RedirectPermanent("/" + @CMS_Core.Common.Common.GetURLDetailByNews("hoi-dap", _Cauhoi[0].QuestionTitle.ToString().ToLower(), "c" + _Cauhoi[0].SpecialistID.ToString(), "q" + _Cauhoi[0].QuestionID.ToString()), false);
                }
                else
                {
                    Response.RedirectPermanent("https://medlatec.vn",false);
                }


            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult chuyendoihoidap()
        {
            try
            {

                Response.RedirectPermanent("/hoi-dap", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult Chuyendoi01()
        {
            try
            {
                string abc = "";

                Response.RedirectPermanent("/bmi-online", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult chuyendoixn()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/medlatec--xet-nghiem-s159", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult chuyendoibanggia()
        {
            try
            {

                Response.RedirectPermanent("/bang-gia-dich-vu", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult chuyendoigoikhamtaivien()
        {
            try
            {

                Response.RedirectPermanent("/tin-tuc/kham-suc-khoe-tong-quat--giai-phap-cham-soc-suc-khoe-toan-dien-s28-n10866", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult chuyendoikhamsk(string id)
        {
            try
            {

                Response.RedirectPermanent("/tin-tuc/dia-chi-hang-dau-cung-cap-dich-vu-kham-suc-khoe-doanh-nghiep-s28-n10342", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult chuyendoitinhoatdong()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/tin-hoat-dong-s1", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult chuyendoitinykhoa1()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/tin-tuc-y-hoc-s28", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult chuyendoitintmh1()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/tai-mui-hong-s98", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult chuyendoitinmat1()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/mat-s100", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult chuyendoitintuyendung()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/tuyen-dung-s15", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult chuyendoitinsankhoa()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/san-khoa-s74", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult chuyendoitintucyte1()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/tin-tuc-y-hoc-s28", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult chuyendoitintucyte2()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/tin-tuc-y-hoc-s28", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult chuyendoitingoikhamsk()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/y-khoa-medlatec-s2", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult chuyendoitindalieu()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/da-lieu-s107", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }


        public ActionResult chuyendoitingoikhambaohiem()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/y-khoa-medlatec-s2", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }


        public ActionResult chuyendoitinnoingoai()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/y-khoa-medlatec-s2", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult chuyendoitinuudai1()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/uu-dai-dac-biet-s120", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult chuyendoitinhoptacyte1()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/tin-hoat-dong-s1", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }


        public ActionResult chuyendoitinbandoccanbiet()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/tin-tuc-y-hoc-s28", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }



        public ActionResult chuyendoitinbandocranghammat()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/rang-ham-mat-s99", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult Chuyendoitracuu1111()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/dat-lich-lay-mau", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult chuyendoitindinhduong1()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/dinh-duong-s51", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult chuyendoitinungthu1()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/benh-ung-thu-s91", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult chuyendoitinthuocvask()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/thuoc--suc-khoe-s18", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult chuyendoitinnoitiet()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/noi-tiet-s62", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult chuyendoitintimmach()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/tim-mach-s63", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult chuyendoitinhohap()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/ho-hap-s64", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult chuyendoitinthankinhp()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/than-kinh-s65", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult chuyendoitintietnieu()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/tiet-nieu-s66", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult chuyendoitintieuhoa()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/tieu-hoa-s67", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult chuyendoitinxuongkhop()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/xuong-khop-s68", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult chuyendoitinnhikhoa1()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/benh-tre-em-s75", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult chuyendoitinlaokhoa1()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/lao-khoa-s76", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult chuyendoitinbaochi()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/bao-chi-khach-hang-noi-ve-medlatec-s135", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult chuyendoilaymautanoi1()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/dich-vu-lay-mau-xet-nghiem-tan-noi-nhanh-chong-chinh-xac-s2-n6432", false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult chuyendoikhaosatksk(string a)
        {
            try
            {

                Response.RedirectPermanent("http://static.medlatec.vn/Survey/khdv.aspx?a="+a, false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }


        public ActionResult chuyendoikhaosatksksv(string a)
        {
            try
            {

                Response.RedirectPermanent("http://static.medlatec.vn/Survey/sv.aspx?a=" + a, false);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult chuyendoitracuu11()
        {
            try
            {

                    Response.RedirectPermanent("https://medlatec.vn/tra-cuu-ket-qua", false);
             


            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult chuyendoilaymau123()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/dich-vu-lay-mau-xet-nghiem-tan-noi-nhanh-chong-chinh-xac-s2-n6432", false);



            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult chuyendoillaymau11111()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/dat-lich-lay-mau", false);



            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult chuyendoihoidap1234()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/hoi-dap", false);



            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult chuyendoitimmach111()
        {
            try
            {
                Response.RedirectPermanent("https://medlatec.vn/tin-tuc/tim-mach-s63",true);


            }
            catch (Exception ex)
            {

            }
            return View();
        }
        //public ActionResult chuyendoitimmach11()
        //{
        //    try
        //    {

        //        Response.RedirectPermanent("https://medlatec.vn/tin-tuc/tim-mach-s63", false);



        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return View();
        //}
        public ActionResult chuyendoitracuu111()
        {
            try
            {

                Response.RedirectPermanent("https://medlatec.vn/tra-cuu-ket-qua", true);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

    }
}