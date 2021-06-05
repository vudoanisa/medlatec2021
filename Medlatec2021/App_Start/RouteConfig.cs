namespace MEDLATEC2019
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Defines the <see cref="RouteConfig" />
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// The RegisterRoutes
        /// </summary>
        /// <param name="routes">The routes<see cref="RouteCollection"/></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //vudoan 18/09/2019
            routes.MapRoute(
                name: "shortUrl",
                url: "s/{shortUrl}",
                defaults: new { controller = "Result", action = "ShortUrl" }
            );


            routes.MapRoute(
         name: "RedirectBanner",
         url: "RedirectBanner/{idBanner}",
         defaults: new { controller = "s", action = "RedirectBanner", idBanner = UrlParameter.Optional }
         );


            routes.MapRoute(
              name: "",
              url: "s/{shortUrl}",
              defaults: new { controller = "Result", action = "ShortUrl" }
          );

            //vudoan 18/09/2019
            routes.MapRoute(
                name: "shortUrlNew",
                url: "u/{shortUrl}",
                defaults: new { controller = "Result", action = "ShortUrlNew" }
            );

            routes.MapRoute(
                 name: "chuyendoitinhoatdong",
                 url: "Tin-Hoat-dong.aspx",
                 defaults: new { controller = "Dieuhuong", action = "chuyendoitinhoatdong" }
                 );
            routes.MapRoute(
                 name: "chuyendoitinykhoa",
                 url: "Tin-Y-khoa-medlatec.aspx",
                 defaults: new { controller = "Dieuhuong", action = "chuyendoitinykhoa1" }
                 );
            routes.MapRoute(
                  name: "chuyendoitintmh",
                  url: "Tai-Mui-Hong.aspx",
                  defaults: new { controller = "Dieuhuong", action = "chuyendoitintmh1" }
                  );
            routes.MapRoute(
                  name: "chuyendoitindanhmucmat",
                  url: "Danh-muc-tu-van-Mat.aspx",
                  defaults: new { controller = "Dieuhuong", action = "chuyendoitinmat1" }
                  );
            routes.MapRoute(
                  name: "chuyendoitintintuyendung",
                  url: "Tin-Tuyen-Dung.aspx",
                  defaults: new { controller = "Dieuhuong", action = "chuyendoitintuyendung" }
                  );
            routes.MapRoute(
                  name: "chuyendoitintinsankhoa",
                  url: "San-khoa.aspx",
                  defaults: new { controller = "Dieuhuong", action = "chuyendoitinsankhoa" }
                  );
            routes.MapRoute(
                  name: "chuyendoitintucyte1",
                  url: "Tin-tuc-y-te.aspx",
                  defaults: new { controller = "Dieuhuong", action = "chuyendoitintucyte1" }
                  );
            routes.MapRoute(
                   name: "chuyendoitintucyte2",
                   url: "News/index.aspx",
                   defaults: new { controller = "Dieuhuong", action = "chuyendoitintucyte2" }
                   );
            routes.MapRoute(
                   name: "chuyendoitingoikhamsuckhoe",
                   url: "Goi-kham-suc-khoe.aspx",
                   defaults: new { controller = "Dieuhuong", action = "chuyendoitingoikhamsk" }
                   );
            routes.MapRoute(
                   name: "chuyendoitindalieu1111",
                   url: "Da-lieu.aspx",
                   defaults: new { controller = "Dieuhuong", action = "chuyendoitindalieu" }
                   );
            routes.MapRoute(
                   name: "chuyendoitindalieu111221",
                   url: "{abc}medlatec.vn/Da-lieu.aspx",
                   defaults: new { controller = "Dieuhuong", action = "chuyendoitindalieu" }
            );

            routes.MapRoute(
                    name: "chuyendoitinkhambaohiem111",
                    url: "Kham-bao-hiem-y-te.aspx",
                    defaults: new { controller = "Dieuhuong", action = "chuyendoitingoikhambaohiem" }
            );

            routes.MapRoute(
                    name: "chuyendoitinkhambaohiem11111",
                    url: " {abc}medlatec.vn/Kham-bao-hiem-y-te.aspx",
                    defaults: new { controller = "Dieuhuong", action = "chuyendoitingoikhambaohiem" }
                    );

            routes.MapRoute(
                   name: "chuyendoitinnoingoaikhoa",
                   url: "Tin-Noi-khoa-Ngoai-khoa.aspx",
                   defaults: new { controller = "Dieuhuong", action = "chuyendoitinnoingoai" }
                   );

            routes.MapRoute(
                   name: "chuyendoitinuudaidacbiet1",
                   url: "Uu-dai-dac-biet.aspx",
                   defaults: new { controller = "Dieuhuong", action = "chuyendoitinnoingoai" }
                   );

            routes.MapRoute(
                    name: "chuyendoitinhoptacyte",
                    url: "Hop-tac-y-te.aspx",
                    defaults: new { controller = "Dieuhuong", action = "chuyendoitinhoptacyte1" }
                    );

            routes.MapRoute(
                   name: "chuyendoitinbandoccanbiet",
                   url: "Ban-doc-can-biet.aspx",
                   defaults: new { controller = "Dieuhuong", action = "chuyendoitinbandoccanbiet" }
                   );


            routes.MapRoute(
                   name: "chuyendoitinrnghammat",
                   url: "Rang-Ham-Mat.aspx",
                   defaults: new { controller = "Dieuhuong", action = "chuyendoitinbandocranghammat" }
                   );


            routes.MapRoute(
                   name: "chuyendoitinrnghammat1111",
                   url: "{abc}medlatec.vn/Rang-Ham-Mat.aspx",
                   defaults: new { controller = "Dieuhuong", action = "chuyendoitinbandocranghammat" }
                   );



            routes.MapRoute(
                    name: "chuyendoitindanhmucrhm",
                    url: "Danh-muc-tu-van-Rang-ham-mat.aspx",
                    defaults: new { controller = "Dieuhuong", action = "chuyendoitinbandocranghammat" }
                    );

            routes.MapRoute(
                     name: "chuyendoitindinh1",
                     url: "Tin-Dinh-duong.aspx",
                     defaults: new { controller = "Dieuhuong", action = "chuyendoitindinhduong1" }
                     );
            routes.MapRoute(
                    name: "chuyendoitindinh2",
                    url: "Danh-muc-tu-van-Dinh-duong.aspx",
                    defaults: new { controller = "Dieuhuong", action = "chuyendoitindinhduong1" }
                    );
            routes.MapRoute(
                   name: "chuyendoitinungthu",
                   url: "Ung-thu.aspx",
                   defaults: new { controller = "Dieuhuong", action = "chuyendoitinungthu1" }
                   );


            routes.MapRoute(
                   name: "chuyendoitintrongnuoc",
                   url: "Tin-trong-nuoc.aspx",
                   defaults: new { controller = "Dieuhuong", action = "chuyendoitinbandoccanbiet" }
                   );

            routes.MapRoute(
                   name: "chuyendoitindmcsha",
                   url: "Danh-muc-tu-van-Chan-doan-hinh-anh.aspx",
                   defaults: new { controller = "Dieuhuong", action = "chuyendoitingoikhamsk" }
                   );
            routes.MapRoute(
               name: "chuyendoitindmcsha2",
               url: "dich-vu/8.aspx",
               defaults: new { controller = "Dieuhuong", action = "chuyendoitingoikhamsk" }
               );
            routes.MapRoute(
            name: "chuyendoitinthuocvask",
            url: "Tin-thuoc-va-suc-khoe.aspx",
            defaults: new { controller = "Dieuhuong", action = "chuyendoitinthuocvask" }
            );
            routes.MapRoute(
     name: "chuyendoitinlamsang",
     url: "Tin-Lam-sang.aspx",
     defaults: new { controller = "Dieuhuong", action = "chuyendoitingoikhamsk" }
     );
            routes.MapRoute(
     name: "chuyendoitincanlamsang",
     url: "Tin-Can-lam-sang.aspx",
     defaults: new { controller = "Dieuhuong", action = "chuyendoitingoikhamsk" }
     );
            routes.MapRoute(
         name: "chuyendoitintuvansk",
         url: "tu-van-suc-khoe.aspx",
          defaults: new { controller = "Dieuhuong", action = "chuyendoihoidap1234" }
         );


            routes.MapRoute(
           name: "chuyendoitintinyhockythuat",
           url: "Tin-Y-hoc-ky-thuat-cao.aspx",
           defaults: new { controller = "Dieuhuong", action = "chuyendoitintucyte1" }
           );
            routes.MapRoute(
       name: "chuyendoitintinsudungthuoc",
       url: "Tin-su-dung-thuoc.aspx",
       defaults: new { controller = "Dieuhuong", action = "chuyendoitinthuocvask" }
       );
            routes.MapRoute(
   name: "chuyendoitintindanhmucthuoc",
   url: "Tin-danh-muc-thuoc.aspx",
   defaults: new { controller = "Dieuhuong", action = "chuyendoitinthuocvask" }
   );
            routes.MapRoute(
     name: "chuyendoitintindanhmucthd1",
     url: "Tin-cho-nguoi-lon.aspx",
     defaults: new { controller = "Dieuhuong", action = "chuyendoitindinhduong1" }
     );
            routes.MapRoute(
            name: "chuyendoitintindanhmucthd111",
            url: "Tin-cho-tre-em.aspx",
            defaults: new { controller = "Dieuhuong", action = "chuyendoitindinhduong1" }
            );
            routes.MapRoute(
                   name: "chuyendoitinchonoitiet",
                   url: "Tin-noi-tiet.aspx",
                   defaults: new { controller = "Dieuhuong", action = "chuyendoitinnoitiet" }
                   );

            routes.MapRoute(
                  name: "chuyendoitinhohap",
                  url: "Tin-ho-hap.aspx",
                  defaults: new { controller = "Dieuhuong", action = "chuyendoitinhohap" }
                  );
            routes.MapRoute(
              name: "chuyendoitinthankinh",
              url: "Tin-than-kinh.aspx",
              defaults: new { controller = "Dieuhuong", action = "chuyendoitinthankinhp" }
              );

            routes.MapRoute(
             name: "chuyendoitintietnieu",
             url: "Tin-tiet-nieu.aspx",
             defaults: new { controller = "Dieuhuong", action = "chuyendoitintietnieu" }
             );

            routes.MapRoute(
         name: "chuyendoitintieuhoa",
         url: "Tin-tieu-hoa.aspx",
         defaults: new { controller = "Dieuhuong", action = "chuyendoitintieuhoa" }
         );

            routes.MapRoute(
       name: "chuyendoitinxuongkhop",
       url: "Tin-xuong-khop.aspx",
       defaults: new { controller = "Dieuhuong", action = "chuyendoitinxuongkhop" }
       );


            routes.MapRoute(
              name: "chuyendoitinnhikhoa1",
              url: "Tin-Nhi-khoa.aspx",
              defaults: new { controller = "Dieuhuong", action = "chuyendoitinnhikhoa1" }
              );

            routes.MapRoute(
            name: "chuyendoitinlaokhoa1",
            url: "Tin-Lao-khoa.aspx",
            defaults: new { controller = "Dieuhuong", action = "chuyendoitinlaokhoa1" }
            );

            routes.MapRoute(
            name: "chuyendoitinldanhmucviemgan1",
            url: "Danh-muc-tu-van-Viem-gan-virus.aspx",
            defaults: new { controller = "Dieuhuong", action = "chuyendoitinnoitiet" }
            );

            routes.MapRoute(
        name: "chuyendoitinldanhmucvi111",
        url: "dich-vu/25.aspx",
        defaults: new { controller = "Dieuhuong", action = "chuyendoitingoikhamsk" }
        );


            routes.MapRoute(
        name: "chuyendoitinldanhmucvi11111",
        url: "MEDLATEC-trong-toi.aspx",
        defaults: new { controller = "Dieuhuong", action = "chuyendoitinhoptacyte1" }
        );


            routes.MapRoute(
        name: "chuyendoitinlaaaaaa",
        url: "Bao-chi.aspx",
        defaults: new { controller = "Dieuhuong", action = "chuyendoitinbaochi" }
        );


            routes.MapRoute(
        name: "chuyendoitinlaaa11",
        url: "Danh-muc-tu-van-Rang-ham-mat.aspx",
        defaults: new { controller = "Dieuhuong", action = "chuyendoitinbandocranghammat" }
        );

            routes.MapRoute(
            name: "chuyendoibangia11",
            url: "Price/index",
            defaults: new { controller = "Dieuhuong", action = "chuyendoibanggia" }
            );
            routes.MapRoute(
           name: "chuyendoibangia1111",
           url: "Price/Home",
           defaults: new { controller = "Dieuhuong", action = "chuyendoibanggia" }
           );

            routes.MapRoute(
          name: "chuyendoibangia111111",
          url: "ListPrice.aspx",
          defaults: new { controller = "Dieuhuong", action = "chuyendoibanggia" }
          );
            routes.MapRoute(
          name: "chuyendoibangia1111111",
          url: "Home/Price.aspx",
          defaults: new { controller = "Dieuhuong", action = "chuyendoibanggia" }
          );
            routes.MapRoute(
       name: "chuyendoilaymautano",
       url: "Lay-mau-tan-noi.aspx",
       defaults: new { controller = "Dieuhuong", action = "chuyendoilaymautanoi1" }
       );


            routes.MapRoute(
            name: "abcdddd",
            url: "BMI-Online.aspx",
            defaults: new { controller = "Dieuhuong", action = "Chuyendoi01" }
            );
            routes.MapRoute(
name: "abc1222",
url: "bmi-online",
defaults: new { controller = "BMI", action = "Home" }
);






            routes.MapRoute(
      name: "abc12",
      url: "Doctor/index.aspx",
      defaults: new { controller = "Dieuhuong", action = "chuyendoihoidap" }
      );





            routes.MapRoute(
 name: "abc1234",
 url: "Xet-nghiem.aspx",
 defaults: new { controller = "Dieuhuong", action = "chuyendoixn" }
 );

            routes.MapRoute(
      name: "abc1237",
      url: "bang-gia-dich-vu",
      defaults: new { controller = "Price", action = "Home" }
      );
            routes.MapRoute(
           name: "abc1237111",
           url: "bang-gia-dich-vu/{page}",
           defaults: new { controller = "Price", action = "Home", page = UrlParameter.Optional }
           );

            routes.MapRoute(
            name: "abc1236",
            url: "bang-gia-dich-vu.aspx",
            defaults: new { controller = "Dieuhuong", action = "chuyendoibanggia" }
            );

            routes.MapRoute(
           name: "abc1238",
           url: "Goi-kham-tai-vien.aspx",
           defaults: new { controller = "Dieuhuong", action = "chuyendoigoikhamtaivien" }
           );


            routes.MapRoute(
           name: "abc1239",
           url: "HLanding/KSK/Details.aspx",
           defaults: new { controller = "Dieuhuong", action = "chuyendoikhamsk", id = UrlParameter.Optional }
           );



            routes.MapRoute(
          name: "TinTinChiTiet",
          url: "tin-tuc/{url}-s{cid}-n{id}",
          defaults: new { controller = "News", action = "NewsDetails", cid = UrlParameter.Optional, id = UrlParameter.Optional }
              );



            routes.MapRoute(
          name: "tintucynghiaxn",
          url: "y-nghia-xet-nghiem/{url}-n{id}",
          defaults: new { controller = "Testcode", action = "TestcodeDetails", id = UrlParameter.Optional }
              );



            routes.MapRoute(
 name: "TinTinChiTietAMP1",
 url: "amp/tin-tuc/{url}-ss{cid}-nn{id}",
 defaults: new { controller = "News", action = "AmpNews", cid = UrlParameter.Optional, id = UrlParameter.Optional }
     );


            routes.MapRoute(
     name: "TinTinChiTietAMP",
     url: "amp/tin-tuc/{url}-s{cid}-n{id}",
     defaults: new { controller = "News", action = "AmpNews", cid = UrlParameter.Optional, id = UrlParameter.Optional }
         );


            routes.MapRoute(
           name: "Danhmuctin",
            url: "tin-tuc/{url}-s{cid}",
            defaults: new { controller = "News", action = "NewsCate", cid = UrlParameter.Optional }
            );


            routes.MapRoute(
         name: "ynghiaxetnghiem",
         url: "y-nghia-xet-nghiem/{url}-n{id}",
         defaults: new { controller = "Scientist", action = "ScientistDetails", cid = UrlParameter.Optional, id = UrlParameter.Optional }
             );



            routes.MapRoute(
           name: "chuyenmucnghiencuukhoahocChitiet",
           url: "cong-trinh-nghien-cuu/{url}-s{cid}-n{id}",
           defaults: new { controller = "Scientist", action = "ScientistDetails", cid = UrlParameter.Optional, id = UrlParameter.Optional }
               );


            routes.MapRoute(
         name: "chuyenmucnghiencuukhoahoc1",
         url: "cong-trinh-nghien-cuu/{url}-s{cid}/{page}",
         defaults: new { controller = "Scientist", action = "ScientistCate", cid = UrlParameter.Optional, page = UrlParameter.Optional, size = 15 }
         );

            routes.MapRoute(
           name: "chuyenmucnghiencuukhoahoc",
            url: "cong-trinh-nghien-cuu/{url}-s{cid}",
            defaults: new { controller = "Scientist", action = "ScientistCate", cid = UrlParameter.Optional, page = 1, size = 15 }
            );



            routes.MapRoute(
          name: "Cauhoichitiet",
          url: "hoi-dap/{url}-c{qid}-q{id}",
          defaults: new { controller = "Question", action = "QuestionDetails", qid = UrlParameter.Optional, id = UrlParameter.Optional }
          );

            routes.MapRoute(
         name: "Cauhoichitiet1",
         url: "hoi-dap/{url}-sc{qid}-nq{id}",
         defaults: new { controller = "Question", action = "QuestionDetails", qid = UrlParameter.Optional, id = UrlParameter.Optional }
         );


            routes.MapRoute(
                name: "Cauhoichitietamp",
                url: "amp/hoi-dap/{url}-c{qid}-q{id}",
                defaults: new { controller = "Question", action = "AMPQuestionDetails", qid = UrlParameter.Optional, id = UrlParameter.Optional }
                );

            routes.MapRoute(
       name: "Danhmuccauhoi",
       url: "hoi-dap/{url}-c{cid}",
       defaults: new { controller = "Question", action = "QuestionCate", cid = UrlParameter.Optional }
       );

            routes.MapRoute(
  name: "HoidapTrangchu",
  url: "hoi-dap",
  defaults: new { controller = "Question", action = "Index" }
  );

            routes.MapRoute(
                name: "Datcauhoi",
                url: "dat-cau-hoi",
                defaults: new { controller = "Question", action = "SendQuestion" }
                );


            routes.MapRoute(
           name: "DanhmuctinPage",
           url: "tin-tuc/{url}-s{cid}/{page}",
           defaults: new { controller = "News", action = "NewsCate", cid = UrlParameter.Optional, page = UrlParameter.Optional }
           );

            routes.MapRoute(
       name: "TinTuccate",
       url: "tin-tuc",
       defaults: new { controller = "News", action = "HomeNews" }
       );


            routes.MapRoute(
       name: "videochitiet",
       url: "video/{url}-s{cid}-n{id}",
       defaults: new { controller = "Video", action = "VideoDetails", cid = UrlParameter.Optional, id = UrlParameter.Optional }
           );


            routes.MapRoute(
         name: "videocate",
         url: "video/{url}-s{cid}",
         defaults: new { controller = "video", action = "VideoCate", cid = UrlParameter.Optional, page = 1 }
         );

            routes.MapRoute(
       name: "video",
       url: "video",
       defaults: new { controller = "video", action = "Index" }
       );

            routes.MapRoute(
    name: "Scientist",
    url: "cong-trinh-nghien-cuu-khoa-hoc",
    defaults: new { controller = "Scientist", action = "Index" }
    );

            routes.MapRoute(
        name: "DanhmuccauhoiPage",
        url: "hoi-dap/{url}-c{cid}/{page}",
        defaults: new { controller = "Question", action = "QuestionCate", cid = UrlParameter.Optional, page = UrlParameter.Optional }
        );





            routes.MapRoute(
        name: "trangchuhoidapPage",
        url: "hoi-dap/{page}",
        defaults: new { controller = "Question", action = "Index", page = UrlParameter.Optional }
        );
            routes.MapRoute(
               name: "loi404",
               url: "404",
               defaults: new { controller = "Result", action = "Link404", page = UrlParameter.Optional }
               );
            routes.MapRoute(
              name: "thankyou",
              url: "thankyou",
              defaults: new { controller = "Appointment", action = "Thankyou1", page = UrlParameter.Optional }
              );

            routes.MapRoute(
             name: "thankyou1",
             url: "thankyou1",
             defaults: new { controller = "Appointment", action = "Thankyou2", page = UrlParameter.Optional }
             );

            routes.MapRoute(
            name: "thankyou4",
            url: "thankyou4",
            defaults: new { controller = "Appointment", action = "Thankyou4", page = UrlParameter.Optional }
            );

            routes.MapRoute(
          name: "thankyou5",
          url: "thankyou5",
          defaults: new { controller = "Appointment", action = "Thankyou5", page = UrlParameter.Optional }
          );



            routes.MapRoute(
             name: "tracuuketqua1",
             url: "tra-cuu-ket-qua",
             defaults: new { controller = "Result", action = "Home" }
             );

            routes.MapRoute(
            name: "tracuuketqua1sid",
            url: "tra-cuu-ket-qua/sid",
            defaults: new { controller = "Result", action = "KQSID" }
            );

            routes.MapRoute(
     name: "tracuuketqua1dvgm",
     url: "tra-cuu-ket-qua/dvgm",
     defaults: new { controller = "Result", action = "KQDVGM" }
     );
            routes.MapRoute(
       name: "doimkdvgm",
       url: "tra-cuu-ket-qua/doi-mat-khau-dvgm",
       defaults: new { controller = "Result", action = "DoiMKGM" }
       );

            routes.MapRoute(
          name: "trapidthongtin",
          url: "thekhachhang/thong-tin",
          defaults: new { controller = "Result", action = "PID_Thongtin" }
          );
            routes.MapRoute(
              name: "lichsukham",
              url: "thekhachhang/lich-su-kham",
              defaults: new { controller = "Result", action = "PID_Lichsukham" }
              );


            routes.MapRoute(
                name: "datlichlaymau1",
                url: "dat-lich-lay-mau",
                defaults: new { controller = "Appointment", action = "Home" }
                );



            routes.MapRoute(
                name: "datlichlaymau2",
                url: "dat-lich-lay-mau-can-bo-medlatec",
                defaults: new { controller = "Appointment", action = "DatLich" }
                );



            routes.MapRoute(
          name: "dieuhuongtintuc1",
          url: "chi-tiet/{url1}/{url}-{id}.aspx",
          defaults: new { controller = "Dieuhuong", action = "Chuyendoi", id = UrlParameter.Optional }
          );



            routes.MapRoute(
        name: "dieuhuongtintuc2",
        url: "NewsDetails.aspx",
        defaults: new { controller = "Dieuhuong", action = "Chuyendoi", id = UrlParameter.Optional }
        );
            routes.MapRoute(
  name: "dieuhuongtintuc3",
  url: "News/Details.aspx",
  defaults: new { controller = "Dieuhuong", action = "Chuyendoi", id = UrlParameter.Optional }
  );


            routes.MapRoute(
name: "dieuhuongcauhoi1",
url: "Doctor/SendQuestion.aspx",
defaults: new { controller = "Dieuhuong", action = "datcauhoi" }
);

            routes.MapRoute(
             name: "dieuhuongdanhmucch1",
             url: "Doctor/index.aspx",
             defaults: new { controller = "Dieuhuong", action = "danhmuccauhoi", qid = UrlParameter.Optional }
             );



            routes.MapRoute(
name: "dddd11111",
url: "QADetails.aspx",
    defaults: new { controller = "Dieuhuong", action = "cauhoi12", id = UrlParameter.Optional }
);


            routes.MapRoute(
name: "dddd",
url: "Doctor/QuestionDetails.aspx",
    defaults: new { controller = "Dieuhuong", action = "cauhoi12", id = UrlParameter.Optional }
);

            routes.MapRoute(
          name: "ssfsdf",
          url: "cau-hoi-tu-van/{id}/{url}.aspx",
          defaults: new { controller = "Dieuhuong", action = "cauhoi11", id = UrlParameter.Optional }
          );

            routes.MapRoute(
     name: "sdfsd",
     url: "cau-hoi/{id}.aspx",
     defaults: new { controller = "Dieuhuong", action = "cauhoi11", id = UrlParameter.Optional }
     );

            routes.MapRoute(
     name: "chuyendoikskhle",
      url: "Survey/khdv.aspx",
      defaults: new { controller = "Dieuhuong", action = "chuyendoikhaosatksk", a = UrlParameter.Optional }
      );
            routes.MapRoute(
         name: "chuyendoiksksksss",
          url: "Survey/sv.aspx",
          defaults: new { controller = "Dieuhuong", action = "chuyendoikhaosatksksv", a = UrlParameter.Optional }
          );


            routes.MapRoute(
                  name: "chuyendoitracuuww",
                   url: "Result/Index.aspx",
                   defaults: new { controller = "Dieuhuong", action = "chuyendoitracuu11" }
                   );


            routes.MapRoute(
                  name: "chuyendoitracuuww1",
                   url: "Tra-cuu-ket-qua.aspx",
                   defaults: new { controller = "Dieuhuong", action = "chuyendoitracuu11" }
                   );

            routes.MapRoute(
             name: "chuyendoitracuuww111",
              url: "Appointment/Home",
              defaults: new { controller = "Dieuhuong", action = "chuyendoitracuu11" }
              );



            routes.MapRoute(
                  name: "chuyendoilaymau1",
                   url: "Lay-mau-tai-nha.aspx",
                   defaults: new { controller = "Dieuhuong", action = "chuyendoilaymau123" }
                   );


            routes.MapRoute(
                  name: "chuyendoituntuc",
                   url: "NewService/NewRS.aspx",
                   defaults: new { controller = "Dieuhuong", action = "chuyendoitingoikhamsk" }
                   );

            routes.MapRoute(
             name: "chuyendoituntuc111",
              url: "datlich/index.aspx",
              defaults: new { controller = "Dieuhuong", action = "chuyendoillaymau11111" }
              );

            routes.MapRoute(
          name: "chuyendoituntuc112",
           url: "Booking/AtHome.aspx",
           defaults: new { controller = "Dieuhuong", action = "chuyendoillaymau11111" }
           );

            routes.MapRoute(
             name: "chuyendoimoi1",
              url: "Tin-tim-mach.aspx",
              defaults: new { controller = "Dieuhuong", action = "chuyendoitimmach111" }
              );





            routes.MapRoute(
         name: "chuyendoituntuc11223",
          url: "NewService/MedicalNews.aspx",
          defaults: new { controller = "Dieuhuong", action = "chuyendoitingoikhamsk" }
          );

            routes.MapRoute(
              name: "kyniem25",
              url: "check-in-medlatec-25-nam",
              defaults: new { controller = "Landing", action = "kyniem25" }
                  );

            routes.MapRoute(
          name: "benhlycoban",
          url: "benh-ly-co-ban-mau-va-mem-gan",
          defaults: new { controller = "Landing", action = "benhlycoban" }
              );



            routes.MapRoute(
                name: "ungthugan",
                url: "dich-vu/xet-nghiem-tam-soat-nguy-co-ung-thu-gan",
                defaults: new { controller = "Landing", action = "LandingXNTSUTGan" }
                    );

            routes.MapRoute(
              name: "noisoitieuhoa",
              url: "dich-vu/noi-soi-tieu-hoa",
              defaults: new { controller = "Landing", action = "LandingNoiSoiTieuHoa" }
                  );


            routes.MapRoute(
                name: "landingungthu1",
                url: "dich-vu/chuong-trinh-tam-soat-ung-thu-gan-afp-mien-phi-tai-nha",
                defaults: new { controller = "Landing", action = "LandingUngThu" }
                    );
            routes.MapRoute(
             name: "landingtieuduongmp",
             url: "dich-vu/mien-phi-xet-nghiem-tieu-duong",
             defaults: new { controller = "Landing", action = "LandingSongkhoe" }
                 );

            routes.MapRoute(
           name: "LandingSuckhoeTQ111",

           url: "dich-vu/goi-kiem-tra-suc-khoe-tong-quat-tai-nha",
           defaults: new { controller = "Landing", action = "LandingSuckhoeTQ" }
               );


            routes.MapRoute(
        name: "quisleShopee",

        url: "dich-vu/Medlatec-dong-hanh-cung-me-cham-soc-bao-ve-suc-khoe-cua-be",
        defaults: new { controller = "Landing", action = "quisleShopee" }
            );

            routes.MapRoute(
          name: "BenhHoHap",

          url: "dich-vu/Medlatec-cac-benh-ly-ve-duong-ho-hap",
          defaults: new { controller = "Landing", action = "BenhHoHap" }
              );



            routes.MapRoute(
   name: "LandingChuyengiaLink",
   url: "dich-vu/chon-chuyen-gia-gui-suc-khoe",
   defaults: new { controller = "Landing", action = "LandingChuyengia" }
       );

            routes.MapRoute(
 name: "udaiksk",
 url: "dich-vu/goi-kham-suc-khoe-toan-dien-tai-nha",
 defaults: new { controller = "Landing", action = "udaiksk" }
     );

            routes.MapRoute(
name: "coxuongkhop",
url: "dich-vu/cham-dut-noi-dau-benh-ly-co-xuong-khop-cung-chuyen-gia",
defaults: new { controller = "Landing", action = "coxuongkhop" }
  );

            routes.MapRoute(
      name: "Landingsieuamthaichudong11",

      url: "dich-vu/sieu-am-thai-chu-dong",
      defaults: new { controller = "Landing", action = "LandingSieuamthaichudong" }
          );

            routes.MapRoute(
  name: "Medem",
  url: "dich-vu/kham-va-dieu-tri-du-phong-truoc-phoi-nhiem-hiv",
  defaults: new { controller = "Landing", action = "Medem" }
      );



            routes.MapRoute(
       name: "timkiembanggia1",
       url: "bang-gia-dich-vu/s/{tukhoa}",
       defaults: new { controller = "Price", action = "SearchKeyword", tukhoa = UrlParameter.Optional }
       );
            routes.MapRoute(
           name: "timkiembanggia2",
           url: "bang-gia-dich-vu/s/{tukhoa}/{page}",
           defaults: new { controller = "Price", action = "SearchKeyword", tukhoa = UrlParameter.Optional, page = UrlParameter.Optional }
           );

            routes.MapRoute(
          name: "landingtainha11",
          url: "dich-vu/xet-nghiem-lay-mau-tai-nha",
          defaults: new { controller = "Landing", action = "LandingTN" }
              );

            routes.MapRoute(
         name: "landingnipt",
         url: "dich-vu/sang-loc-truoc-sinh-khong-xam-lan-nipt",
         defaults: new { controller = "Landing", action = "nipt" }
             );

            routes.MapRoute(
        name: "landingnipt11",
        url: "dich-vu/xet-nghiem-nipt-sang-loc-truoc-sinh-khong-xam-lan",
        defaults: new { controller = "Landing", action = "niptNew" }
            );



            routes.MapRoute(
       name: "landingungthu11",
       url: "dich-vu/kham-phat-hien-benh-ly-phoi",
       defaults: new { controller = "Landing", action = "LandingBenhlyPhoi" }
           );


            routes.MapRoute(
           name: "landingbaohiemyte111",
           url: "dich-vu/bao-hiem-y-te",
           defaults: new { controller = "Landing", action = "LandingBaohiemyte" }
               );
            routes.MapRoute(
          name: "landingbaohiemvienphi1111",
          url: "dich-vu/bao-lanh-vien-phi",
          defaults: new { controller = "Landing", action = "LandingBaolanhvienphi" }
              );
            routes.MapRoute(
       name: "landingkhamskdoanhnghiep1111",
       url: "dich-vu/kham-suc-khoe-doanh-nghiep",
       defaults: new { controller = "Landing", action = "LandingKhamsk" }
           );

            routes.MapRoute(
 name: "landingkhambenhlytuyengian11",
 url: "dich-vu/kham-sieu-am-cac-benh-ly-tuyen-giap",
 defaults: new { controller = "Landing", action = "LandingTuyengiap" }
     );

            routes.MapRoute(
name: "trangcamon11111",
url: "thankyou",
defaults: new { controller = "Appointment", action = "Thankyou1" }
);


            routes.MapRoute(
name: "trangloin",
url: "thankyou3",
defaults: new { controller = "Appointment", action = "Thankyou3" }
);


            routes.MapRoute(
name: "trangfinish",
url: "Finish",
defaults: new { controller = "Result", action = "Finish" }
);

            routes.MapRoute(
 name: "trangcamon11111111",
 url: "tim-kiem",
 defaults: new { controller = "Home", action = "KQTimkiem" }
 );
            routes.MapRoute(
name: "trangbanggia12333",
url: "banggia/banggiaxetnghiem.aspx",
defaults: new { controller = "Dieuhuong", action = "chuyendoibanggia" }
);


            routes.MapRoute(
name: "hethongmedgr",
url: "he-thong-medlatec-chi-nhanh",
defaults: new { controller = "MapGroup", action = "Home" }
);

            routes.MapRoute(
name: "hethongmedgr1",
url: "he-thong-medlatec-benh-vien",
defaults: new { controller = "MapGroup", action = "HomeHospitor" }
);

            routes.MapRoute(
name: "hethongmedgr2",
url: "he-thong-medlatec-van-phong",
defaults: new { controller = "MapGroup", action = "HomeVanphong" }
);


            routes.MapRoute(
name: "hethongmedgr1111",
url: "he-thong-medlatec-group/{url}-{id}",
defaults: new { controller = "MapGroup", action = "MapDetails", id = UrlParameter.Optional }
);

            routes.MapRoute(
          name: "PrintSID111",
          url: "PrintSID",
          defaults: new { controller = "Result", action = "PrintKQ", sid = UrlParameter.Optional, token = UrlParameter.Optional }
              );


            routes.MapRoute(
name: "doingubs1",
url: "doi-ngu-bac-sy",
defaults: new { controller = "Doctor", action = "CateDoctor" }
);
            routes.MapRoute(
        name: "doingubs1111",
        url: "doi-ngu-bac-sy/{url}-{did}",
        defaults: new { controller = "Doctor", action = "DoctorDetails", did = UrlParameter.Optional }
        );
            routes.MapRoute(
name: "doingubs111111111",
url: "doi-ngu-bac-sy/{page}",
defaults: new { controller = "Doctor", action = "CateDoctor", page = UrlParameter.Optional }
);



            routes.MapRoute(
        name: "trangdanhmuctags",
        url: "chu-de/{url}-t{id}",
        defaults: new { controller = "News", action = "Newstags", id = UrlParameter.Optional }
        );
            routes.MapRoute(
                       name: "trangdanhmuctags111",
                       url: "chu-de/{url}-t{id}/{page}",
                       defaults: new { controller = "News", action = "Newstags", id = UrlParameter.Optional, page = UrlParameter.Optional }
                       );

            routes.MapRoute(
      name: "trangbanggia12311",
      url: "chuyen-khoa/san-khoa",
      defaults: new { controller = "Service", action = "Sankhoa" }
      );
            routes.MapRoute(
                 name: "trangchuyenkhoatruyennhiem",
                 url: "chuyen-khoa/truyen-nhiem",
                 defaults: new { controller = "Service", action = "Truyennhiem" }
                 );
            routes.MapRoute(
               name: "trangchuyenkhoanoitiet",
               url: "chuyen-khoa/noi-tiet",
               defaults: new { controller = "Service", action = "Noitiet" }
               );
            routes.MapRoute(
             name: "trangchuyenkhoanamkhoa",
             url: "chuyen-khoa/nam-khoa",
             defaults: new { controller = "Service", action = "Namkhoa" }
             );

            routes.MapRoute(
           name: "trangchuyenkhoatmh",
           url: "chuyen-khoa/tai-mui-hong",
           defaults: new { controller = "Service", action = "Taimuihong" }
           );

            routes.MapRoute(
        name: "trangchuyenkhoatimmach",
        url: "chuyen-khoa/tim-mach",
        defaults: new { controller = "Service", action = "Timmach" }
        );


            routes.MapRoute(
        name: "trangchuyenkhoangoaikhoa",
        url: "chuyen-khoa/ngoai-khoa",
        defaults: new { controller = "Service", action = "Ngoaikhoa" }
        );
            routes.MapRoute(
    name: "trangchuyenkhoamat",
    url: "chuyen-khoa/chuyen-khoa-mat",
    defaults: new { controller = "Service", action = "Mat" }
    );
            routes.MapRoute(
        name: "trangchuyenungbuou",
        url: "chuyen-khoa/ung-buou",
        defaults: new { controller = "Service", action = "Ungbuou" }
        );
            routes.MapRoute(
   name: "trangchuyenthankinh",
   url: "chuyen-khoa/than-kinh",
   defaults: new { controller = "Service", action = "Thankinh" }
   );

            routes.MapRoute(
name: "trangchuyenranghammat",
url: "chuyen-khoa/rang-ham-mat",
defaults: new { controller = "Service", action = "ranghammat" }
);
            routes.MapRoute(
name: "trangchuyencdha",
url: "chuyen-khoa/chan-doan-hinh-anh",
defaults: new { controller = "Service", action = "Chandoanhinhanh" }
);

            routes.MapRoute(
name: "trangchuyenchuyenkhoanoi",
url: "chuyen-khoa/chuyen-khoa-noi",
defaults: new { controller = "Service", action = "ChuyenkhoaNoi" }
);
            routes.MapRoute(
 name: "trangchuyencoxuongkhop",
 url: "chuyen-khoa/co-xuong-khop",
 defaults: new { controller = "Service", action = "Coxuongkhop" }
 );

            routes.MapRoute(
name: "trangchuyendalieu1",
url: "chuyen-khoa/da-lieu",
defaults: new { controller = "Service", action = "Dalieu" }
);

            routes.MapRoute(
name: "trangchuyennhikhoa",
url: "chuyen-khoa/nhi-khoa",
defaults: new { controller = "Service", action = "Nhikhoa" }
);

            routes.MapRoute(
name: "trangchuyentieuhoa",
url: "chuyen-khoa/tieu-hoa",
defaults: new { controller = "Service", action = "Tieuhoa" }
);

            routes.MapRoute(
name: "trangchuyentieuhoa111",
url: "chuyen-khoa/trung-tam-xet-nghiem",
defaults: new { controller = "Service", action = "XetNghiem" }
);


            routes.MapRoute(
    name: "trangchuyenchuchuyenkhoa",
    url: "chuyen-khoa",
    defaults: new { controller = "Service", action = "Home" }
    );



            routes.MapRoute(
    name: "quyche",
    url: "quy-che-hoat-dong",
    defaults: new { controller = "Home", action = "Quyche" }
    );

            routes.MapRoute(
    name: "chinhsach",
    url: "chinh-sach-bao-mat",
    defaults: new { controller = "Home", action = "Chinhsach" }
    );

            routes.MapRoute(
        name: "trachnhiem",
        url: "trach-nhiem-va-cam-ket",
        defaults: new { controller = "Home", action = "Trachnhiem" }
        );



            routes.MapRoute(
name: "chuyendoitracuu11",
url: "Result/Home",
defaults: new { controller = "Dieuhuong", action = "chuyendoitracuu111" }
);



            routes.MapRoute(
name: "chuyendoitracuu11111",
url: "mien-phi-tong-phan-tich-mau-va-men-gen",
defaults: new { controller = "Landing", action = "LandingMPXNMauT9" }
);


            routes.MapRoute(
name: "chuyendoitracuu111232",
url: "dich-vu/chuong-trinh-tam-soat-ung-thu-dai-truc-trang-cea-mien-phi-tai-nha",
defaults: new { controller = "Landing", action = "LandingCEA2019" }
);


            routes.MapRoute(
name: "landingthanhxuan1",
url: "co-so/benh-vien-da-khoa-medlatec-thanh-xuan",
defaults: new { controller = "Landing", action = "LandingThanhXuan" }
);
            routes.MapRoute(
name: "landingsangkien",
url: "noi-bo/sang-kien-cai-tien-ky-niem-25-nam-thanh-lap",
defaults: new { controller = "Landing", action = "LandingSangkien" }
);

            routes.MapRoute(
name: "landinggoikhamngayle",
url: "dich-vu/chuong-trinh-giam-gia-goi-kham-suc-khoe-ngay-le",
defaults: new { controller = "Landing", action = "Goichamsocskngayle" }
);
            routes.MapRoute(
   name: "landinghanh",
   url: "dich-vu/chuong-trinh-mien-phi-sieu-am-tai-thanh-xuan",
   defaults: new { controller = "Landing", action = "LandingMPTX" }
   );

            routes.MapRoute(
name: "xuanmoi2021",
url: "dich-vu/mung-xuan-moi-khoe-phoi-phoi",
defaults: new { controller = "Landing", action = "xuanmoi2021" }
);

            routes.MapRoute(
name: "LandingHNKH2020",
url: "dich-vu/hoi-nghi-y-hoc-4-0",
defaults: new { controller = "Landing", action = "LandingHNKH2020" }
);

            routes.MapRoute(
name: "LandingHNKH2020Value",
url: "dich-vu/dan-sach-cau-hoi-hoi-nghi-y-hoc-4-0",
defaults: new { controller = "Landing", action = "LandingHNKH2020Value" }
);


            routes.MapRoute(
                              name: "daxem1",
                              url: "daxem/{id}",
                              defaults: new { controller = "Home", action = "Daxem", id = UrlParameter.Optional }
                              );
            routes.MapRoute(
name: "camonhn11",
url: "camon",
defaults: new { controller = "Home", action = "CamonHN" }
);
            routes.MapRoute(
name: "hoinghi1",
url: "hoi-nghi",
defaults: new { controller = "Home", action = "Hoinghi" }
);
            routes.MapRoute(
name: "hoinghi122",
url: "cauhoihoinghi",
defaults: new { controller = "Home", action = "CauhoiHoinghi" }
);
            routes.MapRoute(
   name: "hoinghi1233",
   url: "dscauhoi",
   defaults: new { controller = "Home", action = "DsCauhoi" }
   );
            routes.MapRoute(
          name: "hoinghi12444",
          url: "kscauhoi",
          defaults: new { controller = "Home", action = "KSHoinghi" }
          );
            routes.MapRoute(
        name: "toadam1",
        url: "toa-dam-truc-tuyen",
        defaults: new { controller = "Landing", action = "LandingToaDam" }
        );
            routes.MapRoute(
      name: "landinghotrosk111",
      url: "dich-vu/ho-tro-chi-phi-giup-nguoi-dan-cham-soc-suc-khoe",
      defaults: new { controller = "Landing", action = "LandingHotrosuckhoe" }
      );

            routes.MapRoute(
     name: "XetNghiemTongQuat",
     url: "dich-vu/goi-xet-nghiem-tong-quat-va-tam-soat-ung-thu",
     defaults: new { controller = "Landing", action = "XetNghiemTongQuat" }
     );


            routes.MapRoute(
                             name: "Goikhamchitiet111",
                             url: "goi-kham/{url}-r{rid}-g{gid}",
                             defaults: new { controller = "Goikham", action = "ServiceDetail", rid = UrlParameter.Optional, gid = UrlParameter.Optional }
                                 );
            routes.MapRoute(
                     name: "danhmucgoikham111",
                     url: "goi-kham/{url}-r{id}",
                     defaults: new { controller = "Goikham", action = "ServiceGroup", rid = UrlParameter.Optional }
                     );

            routes.MapRoute(
      name: "danhmucgoikham1111111",
      url: "goi-kham",
      defaults: new { controller = "Goikham", action = "index" }
      );
            routes.MapRoute(
name: "dotsongcaotang",
url: "dich-vu/dot-song-cao-tang",
defaults: new { controller = "Landing", action = "Dotsongcaotang" }
);

            routes.MapRoute(
name: "dotsongcaotang1",
url: "dich-vu/dot-song-cao-tang-rfa",
defaults: new { controller = "Landing", action = "Dotsongcaotangrfa" }
);


            //anh sơn
            routes.MapRoute(
                name: "tracuuketqua1siden",
                url: "tra-cuu-ket-qua-en/sid",
                defaults: new { controller = "Result", action = "KQSIDEN" }
            );

            routes.MapRoute(
                        name: "datlichlaymautaivien11",
                        url: "dat-lich-lay-mau-tai-vien",
                        defaults: new { controller = "Appointment", action = "TaiVien" }
                        );


            //trường add danh sách phòng khám
            routes.MapRoute(
                name: "Danh sách phòng khám",
                url: "danh-sach-phong-kham/",
                defaults: new { controller = "DatlichTaiPhongKham", action = "Index" }
                );
            routes.MapRoute(
               name: "Chọn bác sĩ",
               url: "dat-lich-bac-si/{id}",
               defaults: new { controller = "DatlichTaiPhongKham", action = "Bacsi", id = UrlParameter.Optional }
               );

            routes.MapRoute(
              name: "Đặt lịch",
              url: "dat-lich/",
              defaults: new { controller = "DatlichTaiPhongKham", action = "Datlich" }
              );


            routes.MapRoute(
 name: "tudienbenhly",
 url: "tu-dien-benh-ly",
 defaults: new { controller = "Dictionary", action = "Index", page = UrlParameter.Optional }
 );

            routes.MapRoute(
      name: "tudienbenhlychitiet",
      url: "tu-dien-benh-ly/{url}",
      defaults: new { controller = "Dictionary", action = "Detail", url = UrlParameter.Optional }
      );


            routes.MapRoute(
       name: "gopyonline",
       url: "gop-y-online/{sid}",
       defaults: new { controller = "CustomerService", action = "Index", sid = UrlParameter.Optional }
       );

            //
            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );










            //   routes.MapRoute(
            //   name: "sitemap",
            //   url: "sitemap.xml",
            //   defaults: new { controller = "SiteMap", action = "sitemap_news" }
            //   );


            //   routes.MapRoute(
            //    name: "sitemap_news",
            //    url: "sitemap_news.xml",
            //    defaults: new { controller = "SiteMap", action = "sitemap_news"  }
            //    );


            //   routes.MapRoute(
            //   name: "sitemap_Amp",
            //   url: "sitemap_Amp.xml",
            //   defaults: new { controller = "SiteMap", action = "sitemap_Amp" }
            //   );

            //   routes.MapRoute(
            //name: "sitemap_Testcode",
            //url: "sitemap_Testcode.xml",
            //defaults: new { controller = "SiteMap", action = "sitemap_Testcode" }
            //);


        }
    }
}
