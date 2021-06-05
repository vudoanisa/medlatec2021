using CMS_Core.Common;
using MEDLATEC.BusinessLayer;
using MEDLATEC2019.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MEDLATEC2019.Controllers
{
    public class SiteMapController : Controller
    {
        // GET: SiteMap
        public ActionResult Index()
        {
            return View();
        }


        public class SitemapNode
        {
            public SitemapFrequency? Frequency { get; set; }
            public DateTime? LastModified { get; set; }
            public double? Priority { get; set; }
            public string Url { get; set; }
        }
        public enum SitemapFrequency
        {
            Never,
            Yearly,
            Monthly,
            Weekly,
            Daily,
            Hourly,
            Always
        }
        public string GetSitemapDocument(IEnumerable<SitemapNode> sitemapNodes)
        {
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "urlset");
            foreach (SitemapNode sitemapNode in sitemapNodes)
            {
                XElement urlElement = new XElement(
                    xmlns + "url",
                    new XElement(xmlns + "loc", Uri.EscapeUriString(sitemapNode.Url)),
                    sitemapNode.LastModified == null ? new XElement(
                        xmlns + "lastmod",
                        DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd"))
                        : new XElement(
                        xmlns + "lastmod",
                        sitemapNode.LastModified.Value.ToLocalTime().ToString("yyyy-MM-dd")),
                    sitemapNode.Frequency == null ? null : new XElement(
                        xmlns + "changefreq",
                        sitemapNode.Frequency.Value.ToString().ToLowerInvariant()),
                    sitemapNode.Priority == null ? null : new XElement(
                        xmlns + "priority",
                        sitemapNode.Priority.Value.ToString("F1", CultureInfo.InvariantCulture)));
                root.Add(urlElement);
            }
            XDocument document = new XDocument(root);
            return document.ToString();
        }
        public IReadOnlyCollection<SitemapNode> GetSitemapNodes()
        {
            List<SitemapNode> nodes = new List<SitemapNode>();

            nodes.Add(
                new SitemapNode()
                {
                    Url = "https://medlatec.vn",
                    Frequency = SitemapFrequency.Daily,
                    Priority = 1

                });


            SQLServerConnection<Cms_News> sQLServer = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsCate = sQLServer.SelectQueryCommand("GetAllCate", Common.getConnectionString());

            if (_NewsCate.Count > 0)
            {
                for (int i = 0; i < _NewsCate.Count; i++)
                {
                    SQLServerConnection<Cms_News> sQLServer3 = new SQLServerConnection<Cms_News>();
                    List<Cms_News> _NewsCateTotal = sQLServer3.SelectQueryCommand("Get_NewsByCateIDAndPage_Total", Common.getConnectionString(), _NewsCate[i].CateId);


                    int countPage = _NewsCateTotal[0].Tongso / 15;

                    for (int page = 1; page <= countPage; page++)
                    {
                        if (page == 1)
                        {
                            nodes.Add(
                                                          new SitemapNode()
                                                          {

                                                              //  Url = Url.Action("Detail", "Product", new { id = product.ID, page = page }, Request.Url.Scheme)
                                                              Url = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByCate("tin-tuc", _NewsCate[i].CateName.ToString().ToLower(), "s" + _NewsCate[i].CateId.ToString()),
                                                              Frequency = SitemapFrequency.Daily,
                                                              Priority = 0.9
                                                          });
                        }
                        else
                        {
                            nodes.Add(
                              new SitemapNode()
                              {


                                  Url = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByCate("tin-tuc", _NewsCate[i].CateName.ToString().ToLower(), "s" + _NewsCate[i].CateId.ToString()) + "/" + page,
                                  Frequency = SitemapFrequency.Daily,
                                  Priority = 0.8
                              });
                        }


                    }



                }
            }


            SQLServerConnection<Cms_News> sQLServer5 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsChitiet = sQLServer5.SelectQueryCommand("GetNewsSiteMap", Common.getConnectionString());
            if (_NewsChitiet.Count > 0)
            {
                for (int j = 0; j < _NewsChitiet.Count; j++)
                {
                    nodes.Add(
            new SitemapNode()
            {
                Url = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByNews("tin-tuc", _NewsChitiet[j].NewsName.ToString().ToLower(), "s" + _NewsChitiet[j].CateId.ToString(), "n" + _NewsChitiet[j].NewsId.ToString()),
                Frequency = SitemapFrequency.Daily,
                Priority = 0.9,
                LastModified = _NewsChitiet[j].Datepub

            });
                }

            }

            //string url = string.Empty;
            //string number = Common.getRandom();
            //url = "api/Question/GetSpecialist?number=" + number + "&token=" + Common.generalKeyPrivate(number);
            //List<Question> _DanhMucCauHoi = ImpCallAPI<Question>.geContentAPI(url);

            ////  SQLServerConnection<Question> sQLServer6 = new SQLServerConnection<Question>();
            ////  List<Question> _DanhMucCauHoi = sQLServer6.SelectQueryCommand("Specialist_GetAllWeb", Common.getConnectionStringIcnm());
            //if (_DanhMucCauHoi.Count > 0)
            //{
            //    for (int a = 0; a < _DanhMucCauHoi.Count; a++)
            //    {

            //        url = "api/Question/Question_GetByCateIDAndPage_Total_1?SpecialistID=" + _DanhMucCauHoi[a].SpecialistID.ToString() + "&token=" + Common.generalKeyPrivate(_DanhMucCauHoi[a].SpecialistID.ToString());
            //        List<Question> _TotalCK = ImpCallAPI<Question>.geContentAPI(url);

            //        // SQLServerConnection<Question> sQLServer7 = new SQLServerConnection<Question>();
            //        //  List<Question> _TotalCK = sQLServer7.SelectQueryCommand("Question_GetByCateIDAndPage_Total_1", Common.getConnectionStringIcnm(), _DanhMucCauHoi[a].SpecialistID);
            //        if (_TotalCK != null)
            //        {
            //            if (_TotalCK.Count > 0)
            //            {
            //                int countPage = _TotalCK[0].Total / 15;

            //                for (int page = 1; page <= countPage; page++)
            //                {
            //                    if (page == 1)
            //                    {
            //                        nodes.Add(
            //                                                      new SitemapNode()
            //                                                      {

            //                                                          //  Url = Url.Action("Detail", "Product", new { id = product.ID, page = page }, Request.Url.Scheme)
            //                                                          Url = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByCate("hoi-dap", _DanhMucCauHoi[a].SpecialName.ToString().ToLower(), "c" + _DanhMucCauHoi[a].SpecialistID.ToString()),
            //                                                          Frequency = SitemapFrequency.Daily,
            //                                                          Priority = 0.9
            //                                                      });
            //                    }
            //                    else
            //                    {
            //                        nodes.Add(
            //                          new SitemapNode()
            //                          {
            //                              Url = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByCate("hoi-dap", _DanhMucCauHoi[a].SpecialName.ToString().ToLower(), "c" + _DanhMucCauHoi[a].SpecialistID.ToString()) + "/" + page,

            //                              Frequency = SitemapFrequency.Daily,
            //                              Priority = 0.8
            //                          });
            //                    }


            //                }

            //            }
            //        }
            //    }
            //}

            //url = "api/Question/GetQuestionSitemap?number=" + number + "&token=" + Common.generalKeyPrivate(number);
            //List<Question> _QuestionCT = ImpCallAPI<Question>.geContentAPI(url);


            //// SQLServerConnection<Question> sQLServer8 = new SQLServerConnection<Question>();
            //// List<Question> _QuestionCT = sQLServer8.SelectQueryCommand("GetQuestionSitemap", Common.getConnectionStringIcnm());


            //if (_QuestionCT.Count > 0)
            //{
            //    for (int j = 0; j < _QuestionCT.Count; j++)
            //    {
            //        nodes.Add(
            //new SitemapNode()
            //{
            //    Url = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByNews("hoi-dap", _QuestionCT[j].QuestionTitle.ToString().ToLower(), "c" + _QuestionCT[j].SpecialistID.ToString(), "q" + _QuestionCT[j].QuestionID.ToString()),
            //    Frequency = SitemapFrequency.Daily,
            //    Priority = 0.9,
            //    LastModified = _QuestionCT[j].DateCreate

            //});
            //    }

            //}



            return nodes;
        }

        public IReadOnlyCollection<SitemapNode> GetSitemapNodesHome()
        {
            List<SitemapNode> nodes = new List<SitemapNode>();

            nodes.Add(
                new SitemapNode()
                {
                    Url = "https://medlatec.vn",
                    Frequency = SitemapFrequency.Daily,
                    Priority = 1

                });


            SQLServerConnection<Cms_News> sQLServer = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsCate = sQLServer.SelectQueryCommand("GetAllCate", Common.getConnectionString());

            if (_NewsCate.Count > 0)
            {
                for (int i = 0; i < _NewsCate.Count; i++)
                {
                    SQLServerConnection<Cms_News> sQLServer3 = new SQLServerConnection<Cms_News>();
                    List<Cms_News> _NewsCateTotal = sQLServer3.SelectQueryCommand("Get_NewsByCateIDAndPage_Total", Common.getConnectionString(), _NewsCate[i].CateId);


                    int countPage = _NewsCateTotal[0].Tongso / 15;

                    for (int page = 1; page <= countPage; page++)
                    {
                        if (page == 1)
                        {
                            nodes.Add(
                                                          new SitemapNode()
                                                          {

                                                              //  Url = Url.Action("Detail", "Product", new { id = product.ID, page = page }, Request.Url.Scheme)
                                                              Url = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByCate("tin-tuc", _NewsCate[i].CateName.ToString().ToLower(), "s" + _NewsCate[i].CateId.ToString()),
                                                              Frequency = SitemapFrequency.Daily,
                                                              Priority = 0.9
                                                          });
                        }
                        else
                        {
                            nodes.Add(
                              new SitemapNode()
                              {


                                  Url = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByCate("tin-tuc", _NewsCate[i].CateName.ToString().ToLower(), "s" + _NewsCate[i].CateId.ToString()) + "/" + page,
                                  Frequency = SitemapFrequency.Daily,
                                  Priority = 0.8
                              });
                        }


                    }



                }
            }


            SQLServerConnection<Cms_News> sQLServer5 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsChitiet = sQLServer5.SelectQueryCommand("GetNewsSiteMap", Common.getConnectionString());
            if (_NewsChitiet.Count > 0)
            {
                for (int j = 0; j < _NewsChitiet.Count; j++)
                {
                    nodes.Add(
            new SitemapNode()
            {
                Url = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByNews("tin-tuc", _NewsChitiet[j].NewsName.ToString().ToLower(), "s" + _NewsChitiet[j].CateId.ToString(), "n" + _NewsChitiet[j].NewsId.ToString()),
                Frequency = SitemapFrequency.Daily,
                Priority = 0.9,
                LastModified = _NewsChitiet[j].Datepub

            });
                }

            }

            string url = string.Empty;
            string number = Common.getRandom();
            url = "api/Question/GetSpecialist?number=" + number + "&token=" + Common.generalKeyPrivate(number);
            List<Question> _DanhMucCauHoi = ImpCallAPI<Question>.geContentAPI(url);

            if (_DanhMucCauHoi.Count > 0)
            {
                for (int a = 0; a < _DanhMucCauHoi.Count; a++)
                {

                    url = "api/Question/Question_GetByCateIDAndPage_Total_1?SpecialistID=" + _DanhMucCauHoi[a].SpecialistID.ToString() + "&token=" + Common.generalKeyPrivate(_DanhMucCauHoi[a].SpecialistID.ToString());
                    List<Question> _TotalCK = ImpCallAPI<Question>.geContentAPI(url);

                    // SQLServerConnection<Question> sQLServer7 = new SQLServerConnection<Question>();
                    //  List<Question> _TotalCK = sQLServer7.SelectQueryCommand("Question_GetByCateIDAndPage_Total_1", Common.getConnectionStringIcnm(), _DanhMucCauHoi[a].SpecialistID);
                    if (_TotalCK != null)
                    {
                        if (_TotalCK.Count > 0)
                        {
                            int countPage = _TotalCK[0].Total / 15;

                            for (int page = 1; page <= countPage; page++)
                            {
                                if (page == 1)
                                {
                                    nodes.Add(
                                                                  new SitemapNode()
                                                                  {

                                                                      //  Url = Url.Action("Detail", "Product", new { id = product.ID, page = page }, Request.Url.Scheme)
                                                                      Url = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByCate("hoi-dap", _DanhMucCauHoi[a].SpecialName.ToString().ToLower(), "c" + _DanhMucCauHoi[a].SpecialistID.ToString()),
                                                                      Frequency = SitemapFrequency.Daily,
                                                                      Priority = 0.9
                                                                  });
                                }
                                else
                                {
                                    nodes.Add(
                                      new SitemapNode()
                                      {
                                          Url = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByCate("hoi-dap", _DanhMucCauHoi[a].SpecialName.ToString().ToLower(), "c" + _DanhMucCauHoi[a].SpecialistID.ToString()) + "/" + page,

                                          Frequency = SitemapFrequency.Daily,
                                          Priority = 0.8
                                      });
                                }


                            }

                        }
                    }
                }
            }

            url = "api/Question/GetQuestionSitemap?number=" + number + "&token=" + Common.generalKeyPrivate(number);
            List<Question> _QuestionCT = ImpCallAPI<Question>.geContentAPI(url);


            

            if (_QuestionCT.Count > 0)
            {
                for (int j = 0; j < _QuestionCT.Count; j++)
                {
                    nodes.Add(
            new SitemapNode()
            {
                Url = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByNews("hoi-dap", _QuestionCT[j].QuestionTitle.ToString().ToLower(), "c" + _QuestionCT[j].SpecialistID.ToString(), "q" + _QuestionCT[j].QuestionID.ToString()),
                Frequency = SitemapFrequency.Daily,
                Priority = 0.9,
                LastModified = _QuestionCT[j].DateCreate

            });
                }

            }



            return nodes;
        }


        public IReadOnlyCollection<SitemapNode> GetSitemapNodesAMP()
        {
            List<SitemapNode> nodes = new List<SitemapNode>();

            nodes.Add(
                new SitemapNode()
                {
                    Url = "https://medlatec.vn",
                    Frequency = SitemapFrequency.Daily,
                    Priority = 1

                });




            SQLServerConnection<Cms_News> sQLServer5 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsChitiet = sQLServer5.SelectQueryCommand("GetNewsSiteMap", Common.getConnectionString());
            if (_NewsChitiet.Count > 0)
            {
                for (int j = 0; j < _NewsChitiet.Count; j++)
                {
                    nodes.Add(
            new SitemapNode()
            {
                Url = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByNews("amp/tin-tuc", _NewsChitiet[j].NewsName.ToString().ToLower(), "s" + _NewsChitiet[j].CateId.ToString(), "n" + _NewsChitiet[j].NewsId.ToString()),
                Frequency = SitemapFrequency.Daily,
                Priority = 0.9,
                LastModified = _NewsChitiet[j].Datepub

            });
                }

            }

            //string url = string.Empty;
            //string number = Common.getRandom();
            //url = "api/Question/GetSpecialist?number=" + number + "&token=" + Common.generalKeyPrivate(number);
            //List<Question> _DanhMucCauHoi = ImpCallAPI<Question>.geContentAPI(url);

            ////  SQLServerConnection<Question> sQLServer6 = new SQLServerConnection<Question>();
            ////  List<Question> _DanhMucCauHoi = sQLServer6.SelectQueryCommand("Specialist_GetAllWeb", Common.getConnectionStringIcnm());
            //if (_DanhMucCauHoi.Count > 0)
            //{
            //    for (int a = 0; a < _DanhMucCauHoi.Count; a++)
            //    {

            //        url = "api/Question/Question_GetByCateIDAndPage_Total_1?SpecialistID=" + _DanhMucCauHoi[a].SpecialistID.ToString() + "&token=" + Common.generalKeyPrivate(_DanhMucCauHoi[a].SpecialistID.ToString());
            //        List<Question> _TotalCK = ImpCallAPI<Question>.geContentAPI(url);

            //        // SQLServerConnection<Question> sQLServer7 = new SQLServerConnection<Question>();
            //        //  List<Question> _TotalCK = sQLServer7.SelectQueryCommand("Question_GetByCateIDAndPage_Total_1", Common.getConnectionStringIcnm(), _DanhMucCauHoi[a].SpecialistID);
            //        if (_TotalCK != null)
            //        {
            //            if (_TotalCK.Count > 0)
            //            {
            //                int countPage = _TotalCK[0].Total / 15;

            //                for (int page = 1; page <= countPage; page++)
            //                {
            //                    if (page == 1)
            //                    {
            //                        nodes.Add(
            //                                                      new SitemapNode()
            //                                                      {

            //                                                          //  Url = Url.Action("Detail", "Product", new { id = product.ID, page = page }, Request.Url.Scheme)
            //                                                          Url = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByCate("hoi-dap", _DanhMucCauHoi[a].SpecialName.ToString().ToLower(), "c" + _DanhMucCauHoi[a].SpecialistID.ToString()),
            //                                                          Frequency = SitemapFrequency.Daily,
            //                                                          Priority = 0.9
            //                                                      });
            //                    }
            //                    else
            //                    {
            //                        nodes.Add(
            //                          new SitemapNode()
            //                          {
            //                              Url = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByCate("hoi-dap", _DanhMucCauHoi[a].SpecialName.ToString().ToLower(), "c" + _DanhMucCauHoi[a].SpecialistID.ToString()) + "/" + page,

            //                              Frequency = SitemapFrequency.Daily,
            //                              Priority = 0.8
            //                          });
            //                    }


            //                }

            //            }
            //        }
            //    }
            //}

            //url = "api/Question/GetQuestionSitemap?number=" + number + "&token=" + Common.generalKeyPrivate(number);
            //List<Question> _QuestionCT = ImpCallAPI<Question>.geContentAPI(url);


            //// SQLServerConnection<Question> sQLServer8 = new SQLServerConnection<Question>();
            //// List<Question> _QuestionCT = sQLServer8.SelectQueryCommand("GetQuestionSitemap", Common.getConnectionStringIcnm());


            //if (_QuestionCT.Count > 0)
            //{
            //    for (int j = 0; j < _QuestionCT.Count; j++)
            //    {
            //        nodes.Add(
            //new SitemapNode()
            //{
            //    Url = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByNews("hoi-dap", _QuestionCT[j].QuestionTitle.ToString().ToLower(), "c" + _QuestionCT[j].SpecialistID.ToString(), "q" + _QuestionCT[j].QuestionID.ToString()),
            //    Frequency = SitemapFrequency.Daily,
            //    Priority = 0.9,
            //    LastModified = _QuestionCT[j].DateCreate

            //});
            //    }

            //}



            return nodes;
        }

        public IReadOnlyCollection<SitemapNode> GetSitemapNodesQuestion()
        {
            List<SitemapNode> nodes = new List<SitemapNode>();

            nodes.Add(
                new SitemapNode()
                {
                    Url = "https://medlatec.vn",
                    Frequency = SitemapFrequency.Daily,
                    Priority = 1

                });




            string url = string.Empty;
            string number = Common.getRandom();
            url = "api/Question/GetSpecialist?number=" + number + "&token=" + Common.generalKeyPrivate(number);
            List<Question> _DanhMucCauHoi = ImpCallAPI<Question>.geContentAPI(url);

            //  SQLServerConnection<Question> sQLServer6 = new SQLServerConnection<Question>();
            //  List<Question> _DanhMucCauHoi = sQLServer6.SelectQueryCommand("Specialist_GetAllWeb", Common.getConnectionStringIcnm());
            if (_DanhMucCauHoi.Count > 0)
            {
                for (int a = 0; a < _DanhMucCauHoi.Count; a++)
                {

                    url = "api/Question/Question_GetByCateIDAndPage_Total_1?SpecialistID=" + _DanhMucCauHoi[a].SpecialistID.ToString() + "&token=" + Common.generalKeyPrivate(_DanhMucCauHoi[a].SpecialistID.ToString());
                    List<Question> _TotalCK = ImpCallAPI<Question>.geContentAPI(url);

                    // SQLServerConnection<Question> sQLServer7 = new SQLServerConnection<Question>();
                    //  List<Question> _TotalCK = sQLServer7.SelectQueryCommand("Question_GetByCateIDAndPage_Total_1", Common.getConnectionStringIcnm(), _DanhMucCauHoi[a].SpecialistID);
                    if (_TotalCK != null)
                    {
                        if (_TotalCK.Count > 0)
                        {
                            int countPage = _TotalCK[0].Total / 15;

                            for (int page = 1; page <= countPage; page++)
                            {
                                if (page == 1)
                                {
                                    nodes.Add(
                                                                  new SitemapNode()
                                                                  {

                                                                      //  Url = Url.Action("Detail", "Product", new { id = product.ID, page = page }, Request.Url.Scheme)
                                                                      Url = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByCate("hoi-dap", _DanhMucCauHoi[a].SpecialName.ToString().ToLower(), "c" + _DanhMucCauHoi[a].SpecialistID.ToString()),
                                                                      Frequency = SitemapFrequency.Daily,
                                                                      Priority = 0.9
                                                                  });
                                }
                                else
                                {
                                    nodes.Add(
                                      new SitemapNode()
                                      {
                                          Url = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByCate("hoi-dap", _DanhMucCauHoi[a].SpecialName.ToString().ToLower(), "c" + _DanhMucCauHoi[a].SpecialistID.ToString()) + "/" + page,

                                          Frequency = SitemapFrequency.Daily,
                                          Priority = 0.8
                                      });
                                }


                            }

                        }
                    }
                }
            }

            url = "api/Question/GetQuestionSitemap?number=" + number + "&token=" + Common.generalKeyPrivate(number);
            List<Question> _QuestionCT = ImpCallAPI<Question>.geContentAPI(url);


            // SQLServerConnection<Question> sQLServer8 = new SQLServerConnection<Question>();
            // List<Question> _QuestionCT = sQLServer8.SelectQueryCommand("GetQuestionSitemap", Common.getConnectionStringIcnm());


            if (_QuestionCT.Count > 0)
            {
                for (int j = 0; j < _QuestionCT.Count; j++)
                {
                    nodes.Add(
            new SitemapNode()
            {
                Url = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByNews("hoi-dap", _QuestionCT[j].QuestionTitle.ToString().ToLower(), "c" + _QuestionCT[j].SpecialistID.ToString(), "q" + _QuestionCT[j].QuestionID.ToString()),
                Frequency = SitemapFrequency.Daily,
                Priority = 0.9,
                LastModified = _QuestionCT[j].DateCreate

            });
                }

            }



            return nodes;
        }


        public IReadOnlyCollection<SitemapNode> GetSitemapNodesTestcode()
        {
            List<SitemapNode> nodes = new List<SitemapNode>();

            nodes.Add(
                new SitemapNode()
                {
                    Url = "https://medlatec.vn",
                    Frequency = SitemapFrequency.Daily,
                    Priority = 1

                });

            SQLServerConnection<tbl_TestCode> sQLServer = new SQLServerConnection<tbl_TestCode>();
            List<tbl_TestCode> TestCodes = sQLServer.SelectQueryCommand("tbl_TestCode_SelectSiteMap", Common.getConnectionString() );


            if (TestCodes.Count > 0)
            {
                for (int j = 0; j < TestCodes.Count; j++)
                {
                    nodes.Add(
            new SitemapNode()
            {
                
                Url = "https://medlatec.vn/" + @CMS_Core.Common.Common.GetURLDetailByTestcode(  TestCodes[j].TestName.ToString().ToLower().Replace("\"", ""),    TestCodes[j].ID.ToString()),
                Frequency = SitemapFrequency.Daily,
                Priority = 0.9,
                LastModified = TestCodes[j].UpdateTime

            });
                }

            }




            return nodes;
        }


        //public string GetSitemapMedlatec( )
        //{
        //    XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
        //    XElement root = new XElement(xmlns + "urlset");
        //    foreach (SitemapNode sitemapNode in sitemapNodes)
        //    {
        //        XElement urlElement = new XElement(
        //            xmlns + "url",
        //            new XElement(xmlns + "loc", Uri.EscapeUriString(sitemapNode.Url)),
        //            sitemapNode.LastModified == null ? null : new XElement(
        //                xmlns + "lastmod",
        //                sitemapNode.LastModified.Value.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")),
        //            sitemapNode.Frequency == null ? null : new XElement(
        //                xmlns + "changefreq",
        //                sitemapNode.Frequency.Value.ToString().ToLowerInvariant()),
        //            sitemapNode.Priority == null ? null : new XElement(
        //                xmlns + "priority",
        //                sitemapNode.Priority.Value.ToString("F1", CultureInfo.InvariantCulture)));
        //        root.Add(urlElement);
        //    }
        //    XDocument document = new XDocument(root);
        //    return document.ToString();
        //}

        [Route("sitemap.xml")]
        public ActionResult sitemap()
        {
            var sitemapNodes = GetSitemapNodesHome();
            string xml = GetSitemapDocument(sitemapNodes);
            return this.Content(xml, "text/xml", Encoding.UTF8);
        }



        [Route("sitemap_news.xml")]
        public ActionResult SitemapXml()
        {
            var sitemapNodes = GetSitemapNodes();
            string xml = GetSitemapDocument(sitemapNodes);
            return this.Content(xml, "text/xml", Encoding.UTF8);
        }


        [Route("sitemap_Amp.xml")]
        public ActionResult sitemap_Amp()
        {
            var sitemapNodes = GetSitemapNodesAMP();
            string xml = GetSitemapDocument(sitemapNodes);
            return this.Content(xml, "text/xml", Encoding.UTF8);
        }

        [Route("sitemap_Question.xml")]
        public ActionResult sitemap_Question()
        {
            var sitemapNodes = GetSitemapNodesQuestion();
            string xml = GetSitemapDocument(sitemapNodes);
            return this.Content(xml, "text/xml", Encoding.UTF8);
        }


        [Route("sitemap_Testcode.xml")]
        public ActionResult sitemap_Testcode()
        {
            var sitemapNodes = GetSitemapNodesTestcode();
            string xml = GetSitemapDocument(sitemapNodes);
            return this.Content(xml, "text/xml", Encoding.UTF8);
        }
    }
}