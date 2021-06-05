using HtmlAgilityPack;
using MEDLATEC.BusinessLayer;
using MEDLATEC2019.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace CMS_Core.Common
{
    public class Common
    {
        #region Properties
        private static string ConnStr = ConfigurationSettings.AppSettings["Main.ConnectionString"];
        private static string ConnStrIcnm = ConfigurationSettings.AppSettings["Icnm.ConnectionString"];
        private static string ConnStrLabconn = ConfigurationSettings.AppSettings["Labconn.ConnectionString"];
        private static string ConnStrPMBV = ConfigurationSettings.AppSettings["PMBV.ConnectionString"];
        //private static string ConnStrIMGPMBV = ConfigurationSettings.AppSettings["IMGPMBV.ConnectionString"];

        //private static string ConnStr1 = ConfigurationSettings.AppSettings["Main.ConnectionString1"];
        //private static string ConnStrOracle = ConfigurationSettings.AppSettings["ConnStrOracle"];
        //private static string CMSNEWLogError = ConfigurationSettings.AppSettings["CMSNEWLogError"];
        private static string ImagePath = ConfigurationSettings.AppSettings["ImagePath"];

        //private static string ConnStrLabconnBK = ConfigurationSettings.AppSettings["LabconnBK.ConnectionString"];
        private static string LINKAPI = ConfigurationSettings.AppSettings["LINKAPI"];
        private static string KeyPrivate = ConfigurationSettings.AppSettings["KeyPrivate"];
        private static Random rnd = new Random();
        #endregion Properties

        #region private

        /// <summary>
        /// get Connection
        /// </summary>        
        /// <returns></returns> 
        public static string getConnectionString()
        {

            return ConnStr;
        }

        /// <summary>
        /// getKeyPrivate
        /// </summary>        
        /// <returns></returns> 
        public static string getKeyPrivate()
        {
            return KeyPrivate;
        }
        public static string getRandom()
        {
            return rnd.Next(99999).ToString();
        }

        /// <summary>
        /// getKeyPrivate
        /// </summary>        
        /// <returns></returns> 
        public static string generalKeyPrivate(string sid, string pid)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(sid))
                {
                    sid = string.Empty;
                }
                if (string.IsNullOrWhiteSpace(pid))
                {
                    pid = string.Empty;
                }

                return SaltedHash.GetSHA512(sid + getKeyPrivate() + pid);

            }
            catch
            {
                return string.Empty;
            }

        }

        /// <summary>
        /// getKeyPrivate
        /// </summary>        
        /// <returns></returns> 
        public static string generalKeyPrivate(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    id = string.Empty;
                }
                return SaltedHash.GetSHA512(id + getKeyPrivate());
            }
            catch
            {
                return string.Empty;
            }

        }

        /// <summary>
        /// get Connection
        /// </summary>        
        /// <returns></returns> 
        public static string getLINKAPI()
        {

            return LINKAPI;
        }

        public static string getConnectionStringIcnm()
        {

            return ConnStrIcnm;
        }

        public static string getConnectionStringLabconn()
        {

            return ConnStrLabconn;
        }
        public static string getConnectionStringPMBV()
        {

            return ConnStrPMBV;
        }



        public static DataSet ImportLandingHNKH2020(string Content)
        {
            DataSet mDataSet = null;
            SqlConnection conn = new SqlConnection(getConnectionString());

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_tbl_hoinghi_Insert";
                cmd.Parameters.AddWithValue("@Content", Content);


                conn.Open();
                using (SqlDataAdapter reader = new SqlDataAdapter(cmd))
                {
                    try
                    {
                        mDataSet = new DataSet();
                        reader.Fill(mDataSet);
                    }
                    catch
                    {
                        mDataSet = null;
                    }
                }
            }
            catch
            {
                mDataSet = null;
            }
            finally
            {
                conn.Close();
            }

            return mDataSet;
        }

        public static DataSet ImportLandingKyniem25(string Hovaten, string Manv, string Donvi)
        {
            DataSet mDataSet = null;
            SqlConnection conn = new SqlConnection(getConnectionString());

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "tbl_kyniem25_Insert";
                cmd.Parameters.AddWithValue("@Hovaten", Hovaten);
                cmd.Parameters.AddWithValue("@Manv", Manv);
                cmd.Parameters.AddWithValue("@Donvi", Donvi);



                conn.Open();
                using (SqlDataAdapter reader = new SqlDataAdapter(cmd))
                {
                    try
                    {
                        mDataSet = new DataSet();
                        reader.Fill(mDataSet);
                    }
                    catch (Exception ex)
                    {
                        mDataSet = null;
                    }
                }
            }
            catch
            {
                mDataSet = null;
            }
            finally
            {
                conn.Close();
            }

            return mDataSet;
        }



        public static DataSet LogtraCuu(string Username, string IP, string doctorID)
        {
            DataSet mDataSet = null;
            SqlConnection conn = new SqlConnection(getConnectionString());

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "tbl_logSearch_Insert";
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@IP", IP);
                cmd.Parameters.AddWithValue("@doctorID", doctorID);



                conn.Open();
                using (SqlDataAdapter reader = new SqlDataAdapter(cmd))
                {
                    try
                    {
                        mDataSet = new DataSet();
                        reader.Fill(mDataSet);
                    }
                    catch (Exception ex)
                    {
                        mDataSet = null;
                    }
                }
            }
            catch
            {
                mDataSet = null;
            }
            finally
            {
                conn.Close();
            }

            return mDataSet;
        }


        public static DataSet ImportLandingHNKH2020Cautraloi(string hoten, string namsinh, string mobile, string nghenghiep, string email, string donvi, string chuyenkhoa, string cau8, string cau9, string cau10, string cau11, string cau12, string cau13, string cau14)
        {
            DataSet mDataSet = null;
            SqlConnection conn = new SqlConnection(getConnectionString());

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "tbl_kyniem25_Insert";
                cmd.Parameters.AddWithValue("@hoten", hoten);
                cmd.Parameters.AddWithValue("@namsinh", namsinh);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.Parameters.AddWithValue("@nghenghiep", nghenghiep);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@donvi", donvi);
                cmd.Parameters.AddWithValue("@chuyenkhoa", chuyenkhoa);
                cmd.Parameters.AddWithValue("@cau8", cau8);
                cmd.Parameters.AddWithValue("@cau9", cau9);
                cmd.Parameters.AddWithValue("@cau10", cau10);
                cmd.Parameters.AddWithValue("@cau11", cau11);
                cmd.Parameters.AddWithValue("@cau12", cau12);
                cmd.Parameters.AddWithValue("@cau13", cau13);
                cmd.Parameters.AddWithValue("@cau14", cau14);


                conn.Open();
                using (SqlDataAdapter reader = new SqlDataAdapter(cmd))
                {
                    try
                    {
                        mDataSet = new DataSet();
                        reader.Fill(mDataSet);
                    }
                    catch (Exception ex)
                    {
                        mDataSet = null;
                    }
                }
            }
            catch
            {
                mDataSet = null;
            }
            finally
            {
                conn.Close();
            }

            return mDataSet;
        }


        //public static string getConnectionStringIMGPMBV()
        //{

        //    return ConnStrIMGPMBV;
        //}
        ///// <summary>
        ///// get connect Oracle
        ///// </summary>        
        ///// <returns></returns> 
        //public static string getConnStrOracle()
        //{

        //    return ConnStrOracle;
        //}

        ///// <summary>
        ///// get connect Log4net
        ///// </summary>        
        ///// <returns></returns> 
        //public static string getCMSNEWLogError()
        //{

        //    return CMSNEWLogError;
        //}

        // <summary>
        /// format datetime
        /// </summary>
        /// <param name="obj">string datatime</param>
        /// <returns></returns>
        public static string ReFmtTime(object obj)
        {
            try
            {
                string ss = obj.ToString();

                if (DateTime.Parse(ss) < DateTime.Now.AddYears(-100))
                    return "";
                else return DateTime.Parse(ss).ToString("dd/MM/yyyy HH:mm");
            }
            catch
            {
                return "";
            }
        }

        public static string FormatTitleNews(string title, int count)
        {
            string Chuoi = "";
            int icontent = title.Length;
            if (icontent < count || icontent == count)
            {
                Chuoi = title;
            }
            else
            {
                for (int i = 1; i < icontent; i++)
                {
                    string substring = title;
                    substring = substring.Substring(count - i, 1);
                    if (substring.IndexOf(" ") > 0 || substring == "" || substring == " ")
                    {
                        substring = title.Substring(0, count - i);
                        //substring = substring.Substring(0, substring.Length - 1);
                        Chuoi = substring + "...";
                        break;
                    }
                }
            }
            return Chuoi;
        }
        #endregion




        public static string GetURLHome(string aliasCate)
        {
            try
            {

                return aliasCate;

            }
            catch
            {
                return aliasCate;
            }
        }
        public static string GetURLDetailByMap(string title, string newsid)
        {
            try
            {

                return getNiceUrl(title) + "-" + newsid;

            }
            catch
            {
                return getNiceUrl(title) + "-" + newsid;
            }
        }
        public static string GetURLDetailByTags(string aliasCate, string title, string newsid)
        {
            try
            {

                return aliasCate + "/" + getNiceUrl(title) + "-" + newsid;

            }
            catch
            {
                return aliasCate + "/" + getNiceUrl(title) + "-" + newsid;
            }
        }

        public static string GetURLDetailByCate(string aliasCate, string title, string cateid)
        {
            try
            {

                return aliasCate + "/" + getNiceUrl(title) + "-" + cateid;

            }
            catch
            {
                return aliasCate + "/" + getNiceUrl(title) + "-" + cateid;
            }
        }

        public static string GetURLScientistDetailByCate(string aliasCate, string title, string cateid)
        {
            try
            {

                return aliasCate + "/" + getNiceUrl(title) + "-n" + cateid;

            }
            catch
            {
                return aliasCate + "/" + getNiceUrl(title) + "-" + cateid;
            }
        }


        public static string GetURLVideoByCate(string aliasCate, string title, string cateid)
        {
            try
            {

                return aliasCate + "/" + getNiceUrl(title) + "-s" + cateid;

            }
            catch
            {
                return aliasCate + "/" + getNiceUrl(title) + "-s" + cateid;
            }
        }


        public static string GetURLDetailVideoByNews(string aliasCate, string title, string cateid, string newsid)
        {
            try
            {

                return aliasCate + "/" + getNiceUrl(title) + "-s" + cateid + "-n" + newsid;

            }
            catch
            {
                return aliasCate + "/" + getNiceUrl(title) + "-s" + cateid + "-n" + newsid;
            }
        }


        public static string GetURLDetailByNews(string aliasCate, string title, string cateid, string newsid)
        {
            try
            {

                return aliasCate + "/" + getNiceUrl(title) + "-" + cateid + "-" + newsid;

            }
            catch
            {
                return aliasCate + "/" + getNiceUrl(title) + "-" + cateid + "-" + newsid;
            }
        }


        public static string GetURLDetailByTestcode(string title, string newsid)
        {
            try
            {
                return "y-nghia-xet-nghiem/" + getNiceUrl(title.Trim()) + "-n" + newsid;
            }
            catch
            {
                return "y-nghia-xet-nghiem/" + getNiceUrl(title.Trim()) + "-n" + newsid;
            }
        }

        public static string GetIPHelper()
        {
            string ip = string.Empty;
            try
            {
                ip = HttpContext.Current.Request.UserHostAddress;
            }
            catch { }

            return ip;
        }

        public static string getNiceUrl(Object objurl)
        {
            try
            {
                String url = objurl.ToString();
                String niceurl = ConvertEN(url);
                niceurl = niceurl.Replace("-", "");
                niceurl = niceurl.Replace(" ", "-");
                niceurl = niceurl.Replace("_", "-");
                niceurl = niceurl.Replace("nbsp;", "-");
                niceurl = niceurl.Replace("'", "");


                niceurl = removeChar(niceurl, new String[] { "/", "m²", ":", ",", "<", ">", "”", "“", ".", "!", "?", "@", "#", "$", "%", "^", "&", "*", "(", ")", "+", "~", "`", "'", "'", "\"" });
                return niceurl;
            }
            catch
            {
                return "";
            }
        }

        public static string getNiceUrl_TV(Object objurl)
        {
            try
            {
                String url = objurl.ToString();
                String niceurl = url;
                niceurl = niceurl.Replace("-", "");
                niceurl = niceurl.Replace(" ", "-");
                niceurl = niceurl.Replace("_", "-");
                niceurl = niceurl.Replace("nbsp;", "-");
                niceurl = niceurl.Replace("'", "");


                niceurl = removeChar(niceurl, new String[] { "/", "m²", ":", ",", "<", ">", "”", "“", ".", "!", "?", "@", "#", "$", "%", "^", "&", "*", "(", ")", "+", "~", "`", "'", "'", "\"" });
                return niceurl;
            }
            catch
            {
                return "";
            }
        }



        public static String removeChar(String niceurl, String[] danhsach)
        {
            foreach (String xoa in danhsach)
            {
                niceurl = niceurl.Replace(xoa, "");
            }
            return niceurl;
        }
        public static string ConvertVietnameseCharacterToEN(string sCharacter)
        {
            string sTemplate = "ĂẮẰẲẴẶăắằẳẵặÂẤẦẨẪẬâấầẩẫậÁÀẢÃẠáàảãạÔỐỒỔỖỘôốồổỗộƠỚỜỞỠỢơớờởỡợÓÒỎÕỌóòỏõọĐđÊẾỀỂỄỆêếềểễệÉÈẺẼẸéèẻẽẹƯỨỪỬỮỰưứừửữựÚÙỦŨỤúùủũụÍÌỈĨỊíìỉĩịÝỲỶỸỴýỳỷỹỵ";
            string sReplate = "AAAAAAaaaaaaAAAAAAaaaaaaAAAAAaaaaaOOOOOOooooooOOOOOOooooooOOOOOoooooDdEEEEEEeeeeeeEEEEEeeeeeUUUUUUuuuuuuUUUUUuuuuuIIIIIiiiiiYYYYYyyyyy";
            char[] arrChar = sTemplate.ToCharArray();
            char[] arrReChar = sReplate.ToCharArray();
            string sResult = "";//sCharacter;
            char digit;

            for (int ch = 0; ch < sCharacter.Length; ch++)
            {
                digit = Convert.ToChar(sCharacter.Substring(ch, 1));//arrChar[ch].ToString();;
                for (int i = 0; i < arrChar.Length; i++)
                    if (digit.Equals(arrChar[i]))
                        digit = arrReChar[i];
                sResult += digit;
            }

            return sResult;
        }
        public static string ConvertEN(string sCharacter)
        {
            string sTemplate = "ĂẮẰẲẴẶăắằẳẵặÂẤẦẨẪẬâấầẩẫậÁÀẢÃẠáàảãạÔỐỒỔỖỘôốồổỗộƠỚỜỞỠỢơớờởỡợÓÒỎÕỌóòỏõọĐđÊẾỀỂỄỆêếềểễệÉÈẺẼẸéèẻẽẹƯỨỪỬỮỰưứừửữựÚÙỦŨỤúùủũụÍÌỈĨỊíìỉĩịÝỲỶỸỴýỳỷỹỵ";
            string sReplate = "AAAAAAaaaaaaAAAAAAaaaaaaAAAAAaaaaaOOOOOOooooooOOOOOOooooooOOOOOoooooDdEEEEEEeeeeeeEEEEEeeeeeUUUUUUuuuuuuUUUUUuuuuuIIIIIiiiiiYYYYYyyyyy";
            string sDau = "[̃́]"; // dấu ngã, sắc, nặng, hỏi, ngã
            char[] arrChar = sTemplate.ToCharArray();
            char[] arrReChar = sReplate.ToCharArray();
            string sResult = "";//sCharacter;
            char digit;
            // modified by datnd - 1/4/2010
            // xoa di tat ca cac dau
            System.Text.RegularExpressions.Regex reg = new Regex(sDau);
            sCharacter = reg.Replace(sCharacter, "");

            try
            {
                sCharacter = Regex.Replace(sCharacter, @"&(\w)(\w){4,5};", "$1");
            }
            catch (ArgumentException ex) { }

            // end modified
            for (int ch = 0; ch < sCharacter.Length; ch++)
            {
                digit = Convert.ToChar(sCharacter.Substring(ch, 1));//arrChar[ch].ToString();;
                for (int i = 0; i < arrChar.Length; i++)
                {
                    if (digit.Equals(arrChar[i]))
                        digit = arrReChar[i];
                }
                sResult += digit;
            }

            return sResult;
        }
        public static string buildUrl(string url, int page, int total, int pageSize)
        {
            string result = string.Empty;
            int countPage = total / pageSize;
            if (total % pageSize != 0)
            {
                countPage = countPage + 1;
            }


            if (total > pageSize)
            {
                result = "<nav aria-label=\"Page navigation example\">";
                result += "<ul class=\"pagination pagination-circle pg-blue justify-content-center\">";
                if (page == 1)
                {
                    result += "<li class=\"page-item disabled\"><a href=\"" + url + "\" class=\"page-link\">Đầu tiên</a></li>";
                }
                else
                {
                    result += "<li class=\"page-item \"><a href=\"" + url + "\" class=\"page-link\">Đầu tiên</a></li>";
                }
                if (page > 1)
                {
                    result += "<li class=\"page-item disabled\"><a href=\"" + url + "/" + (page - 1) + "\" class=\"page-link\" aria-label=\"Previous\"><span aria-hidden=\"true\">&laquo;</span><span class=\"sr-only\">Quay lại</span></a></li>";
                }

                if (page < 4)
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        if (i <= countPage)
                        {
                            if (i == page)
                            {
                                result += "<li class=\"page-item active\"><a  href=\"" + url + "/" + i + "\" class=\"page-link\">" + i + "</a></li>";
                            }
                            else
                            {
                                result += "<li class=\"page-item\"><a  href=\"" + url + "/" + i + "\"class=\"page-link\">" + i + "</a></li>";
                            }
                        }
                    }
                }
                else
                {
                    for (int i = page - 2; i <= page + 2; i++)
                    {
                        if (i <= countPage)
                        {
                            if (i == page)
                            {
                                result += "<li class=\"page-item active\"><a  href=\"" + url + "/" + i + "\" class=\"page-link\">" + i + "</a></li>";
                            }
                            else
                            {
                                result += "<li class=\"page-item\"><a  href=\"" + url + "/" + i + "\"class=\"page-link\">" + i + "</a></li>";
                            }
                        }
                    }


                }
                if (page < countPage - 1)
                {
                    result += "<li class=\"page-item\"><a href=\"" + url + "/" + (page + 1) + "\" class=\"page-link\" aria-label=\"Next\"><span aria-hidden=\"true\">&raquo;</span><span class=\"sr-only\">Tiếp theo</span></a></li>";
                }
                if (page != countPage)
                {
                    result += "<li class=\"page-item\"><a href=\"" + url + "/" + countPage + "\" class=\"page-link\">Cuối cùng</a></li></ul></nav> ";
                }
                else
                {
                    result += "<li class=\"page-item disabled\"><a href=\"" + url + "/" + countPage + "\" class=\"page-link\">Cuối cùng</a></li></ul></nav> ";
                }




            }
            else
            {
                result = string.Empty;
            }





            return result;
        }

        public static string buildUrlbanggia(string url, int page, int total, int pageSize)
        {
            string result = string.Empty;
            int countPage = total / pageSize;
            if (total % pageSize != 0)
            {
                countPage = countPage + 1;
            }


            if (total > pageSize)
            {
                result = "<nav aria-label=\"Page navigation example\">";
                result += "<ul class=\"pagination pagination-circle pg-blue justify-content-center\">";
                if (page == 1)
                {
                    result += "<li class=\"page-item disabled\"><a href=\"" + url + "\" class=\"page-link\">Đầu tiên</a></li>";
                }
                else
                {
                    result += "<li class=\"page-item \"><a href=\"" + url + "\" class=\"page-link\">Đầu tiên</a></li>";
                }
                if (page > 1)
                {
                    result += "<li class=\"page-item disabled\"><a href=\"" + url + "/" + (page - 1) + "\" class=\"page-link\" aria-label=\"Previous\"><span aria-hidden=\"true\">&laquo;</span><span class=\"sr-only\">Quay lại</span></a></li>";
                }

                if (page < 4)
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        if (i <= countPage)
                        {
                            if (i == page)
                            {
                                result += "<li class=\"page-item active\"><a  href=\"" + url + "/" + i + "\" class=\"page-link\">" + i + "</a></li>";
                            }
                            else
                            {
                                result += "<li class=\"page-item\"><a  href=\"" + url + "/" + i + "\"class=\"page-link\">" + i + "</a></li>";
                            }
                        }
                    }
                }
                else
                {
                    for (int i = page - 2; i <= page + 2; i++)
                    {
                        if (i <= countPage)
                        {
                            if (i == page)
                            {
                                result += "<li class=\"page-item active\"><a  href=\"" + url + "/" + i + "\" class=\"page-link\">" + i + "</a></li>";
                            }
                            else
                            {
                                result += "<li class=\"page-item\"><a  href=\"" + url + "/" + i + "\"class=\"page-link\">" + i + "</a></li>";
                            }
                        }
                    }


                }
                if (page < countPage - 1)
                {
                    result += "<li class=\"page-item\"><a href=\"" + url + "/" + (page + 1) + "\" class=\"page-link\" aria-label=\"Next\"><span aria-hidden=\"true\">&raquo;</span><span class=\"sr-only\">Tiếp theo</span></a></li>";
                }
                if (page != countPage)
                {
                    result += "<li class=\"page-item\"><a href=\"" + url + "/" + countPage + "\" class=\"page-link\">Cuối cùng</a></li></ul></nav> ";
                }
                else
                {
                    result += "<li class=\"page-item disabled\"><a href=\"" + url + "/" + countPage + "\" class=\"page-link\">Cuối cùng</a></li></ul></nav> ";
                }




            }
            else
            {
                result = string.Empty;
            }





            return result;
        }
        //public static List<AnyType> geContentAPI(string url)
        //{

        //    try
        //    {
        //        HttpClient http = new HttpClient();
        //        string baseUrl = getLINKAPI() + url;

        //        HttpResponseMessage response = http.GetAsync(new Uri(baseUrl)).Result;
        //        string responseBody = response.Content.ReadAsStringAsync().Result;
        //        var countries = JsonConvert.DeserializeObject(responseBody);

        //     //   JArray jsonResponse = JArray.Parse(responseBody);
        //        return (object)countries;
        //    }
        //    catch
        //    {
        //        return null;
        //    }

        //}

        public static List<Cms_ImgPMBV> GetImage(int IDCLS, string macp)
        {


            if (IDCLS != 0)
            {
                string url = "api/Result/GetImgPMBV1?IDCLS=" + IDCLS.ToString() + "&macp=" + macp + "&token=" + Common.generalKeyPrivate(IDCLS.ToString());
                var result = ImpCallAPI<Cms_ImgPMBV>.geContentAPINew(url);

                //SQLServerConnection<Cms_ImgPMBV> sQLServer2 = new SQLServerConnection<Cms_ImgPMBV>();
                //List<Cms_ImgPMBV> _Ketqua = sQLServer2.SelectQueryCommand("GetAllIMG_IDCLS1", Common.getConnectionStringIMGPMBV(), IDCLS, macp);
                return result;
            }
            else
            {
                return null;
            }

        }

        public static List<ImageCLS> GetlinkImage(int IDCLS, string macp)
        {


            if (IDCLS != 0)
            {
                string url = "api/Result/GetLinkImg?IDCLS=" + IDCLS.ToString() + "&macp=" + macp + "&token=" + Common.generalKeyPrivate(IDCLS.ToString());
                var result = ImpCallAPI<ImageCLS>.geContentAPINew(url);

                 
                return result;
            }
            else
            {
                return null;
            }

        }

        public static string GetPathImage(string pathImage)
        {
            if(!string.IsNullOrEmpty(pathImage))
            {
                pathImage = pathImage.Replace("https://login.medlatec.vn", "https://img.medlatec.vn");
                return pathImage;
            }
            else
            {
                return string.Empty;
            }
             
        }


        public static string GetLinkSId(string sid)
        {
            if (sid != null)
            {
                string tokenkey = "m$dl4tec";
                tokenkey = SaltedHash.GetSHA512(tokenkey + sid.Trim());
                sid = AES.EncryptString(sid.Trim(), "").Trim();
                return "/tra-cuu-ket-qua/sid?sid=" + sid + "&place=HN&" + "La=VN&token=" + tokenkey;

            }
            else
            {
                return "/tra-cuu-ket-qua";
            }
        }
        //public static string GetLinkSId(string sid)
        //{
        //    if (sid != null)
        //    {
        //        string tokenkey = "m$dl4tec";
        //        tokenkey = SaltedHash.GetSHA512(tokenkey + sid);
        //        sid = AES.EncryptString(sid.Trim(), "").Trim();
        //        return "/tra-cuu-ket-qua/sid?sid=" + sid + "&place=HN&" + "La=VN&token=" + tokenkey;

        //    }
        //    else
        //    {
        //        return "/tra-cuu-ket-qua";
        //    }
        //}
        public static string GetLinkDoiMKDVGM(string doctorid)
        {
            if (doctorid != null)
            {
                string tokenkey = "m$dl4tec";
                tokenkey = SaltedHash.GetSHA512(tokenkey);
                doctorid = AES.EncryptString(doctorid.Trim(), "").Trim();
                return "/tra-cuu-ket-qua/doi-mat-khau-dvgm?U=" + doctorid + "&token=" + tokenkey;

            }
            else
            {
                return "";
            }
        }
        public static void AddToLogFile(string content)
        {
            string fn = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + ".txt";
            try
            {

                String path = "";

                path = ConfigurationSettings.AppSettings["LOG_PATH"];

                path += "/" + fn;
                if (path != "")
                {
                    System.IO.StreamWriter writer = new StreamWriter(path, true, System.Text.Encoding.UTF8);
                    writer.WriteLine(content);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static string ConvertISO8859EntityNameToUnicode(string s)
        {
            string[] src = {"&Agrave;","&Aacute;","&Acirc;","&Atilde;","&Aring;","&Egrave;","&Eacute;","&Ecirc;","&Igrave;","&Iacute;","&ETH;","&Ograve;","&Ocirc;","&Otilde;","&Ugrave;","&Uacute;","&Yacute;","&agrave;","&acirc;","&atilde;","&egrave;","&eacute;","&ecirc;","&igrave;","&iacute;","&ograve;","&oacute;","&ocirc;","&otilde;","&ugrave;","&uacute;","&yacute;","&aacute;", "&nbsp;"
            };

            string[] taget = {"À","Á","Â","Ã","Å ","È","É","Ê","Ì","Í","Ð","Ò","Ô","Õ","Ù","Ú","Ý","à","â","ã","è","é","ê","ì","í","ò","ó","ô","õ","ù","ú","ý","á", " "
            };

            string result = s;
            for (int i = 0; i < src.Length; i++)
            {
                result = result.Replace(src[i], taget[i]);
            }
            return result;
        }

        public static string ConvertHtml(string s)
        {
            HtmlDocument contenthtml = new HtmlDocument();
            contenthtml.LoadHtml(s);
            string content = contenthtml.DocumentNode.InnerText;
            content = ConvertISO8859EntityNameToUnicode(content);
            return content;
        }

        public static List<Cms_News> GetNewsidByTags(int tagid, int newsid)
        {
            if ((tagid != 0) && (newsid != 0))
            {
                SQLServerConnection<Cms_News> sQLServer4 = new SQLServerConnection<Cms_News>();
                List<Cms_News> _NewsDichvu = sQLServer4.SelectQueryCommand("Get_Newsid_Bytagsid", Common.getConnectionString(), tagid, newsid);

                return _NewsDichvu;
            }
            else
            {
                return null;
            }

        }


        //public static string RemoveStyleAttributes(HtmlDocument html)
        //{
        //    var elementsWithStyleAttribute = html.DocumentNode.SelectNodes("//@style");

        //    if (elementsWithStyleAttribute != null)
        //    {
        //        foreach (var element in elementsWithStyleAttribute)
        //        {
        //            element.Attributes["style"].Remove();
        //        }
        //    }

        //    return elementsWithStyleAttribute.ToString();

        //}
        /// <summary>
        /// Removes all FONT and SPAN tags, and all Class and Style attributes.
        /// Designed to get rid of non-standard Microsoft Word HTML tags.
        /// </summary>
        public static string CleanHtml(string html)
        {
            // start by completely removing all unwanted tags 
            html = Regex.Replace(html, @"<[/]?(font|span|xml|del|ins|[ovwxp]:\w+)[^>]*?>", "", RegexOptions.IgnoreCase);
            // then run another pass over the html (twice), removing unwanted attributes 
            html = Regex.Replace(html, @"<([^>]*)(?:class|lang|style|size|face|[ovwxp]:\w+)=(?:'[^']*'|""[^""]*""|[^\s>]+)([^>]*)>", "<$1$2>", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"<([^>]*)(?:class|lang|style|size|face|[ovwxp]:\w+)=(?:'[^']*'|""[^""]*""|[^\s>]+)([^>]*)>", "<$1$2>", RegexOptions.IgnoreCase);
            return html;
        }

        /// <summary>
        /// Remove region tag style
        /// </summary>
        /// <param name="html">Input content</param>
        /// <returns>Output content</returns>
        public static string StripStyleTags(string html)
        {
            html = Regex.Replace(html, @"\<style(.*?)\>(.*?)\<\/style(.*?)\>", "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            return html;
        }
        public static string RemoveHeight(string html)
        {
            html = Regex.Replace(html, "height=\"(.*?)\"", "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            return html;
        }
        public static string RemoveWidth(string html)
        {
            html = Regex.Replace(html, "width=\"(.*?)\"", "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            return html;
        }
        public static string Removevspace(string html)
        {
            html = Regex.Replace(html, "vspace=\"(.*?)\"", "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            return html;
        }

        public static string RemoveBorder(string html)
        {
            html = Regex.Replace(html, "border=\"(.*?)\"", "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            return html;
        }


        public static string removeCharEncode(string niceurl)
        {
            string[] danhsach1 = { "&Agrave;", "&Aacute;", "&Acirc;", "&Atilde;", "&Aring;", "&Egrave;", "&Eacute;", "&Ecirc;", "&Igrave;", "&Iacute;", "&ETH;", "&Ograve;", "&Ocirc;", "&Otilde;", "&Ugrave;", "&Uacute;", "&Yacute;", "&agrave;", "&acirc;", "&atilde;", "&egrave;", "&eacute;", "&ecirc;", "&igrave;", "&iacute;", "&ograve;", "&oacute;", "&ocirc;", "&otilde;", "&ugrave;", "&uacute;", "&yacute;", "&aacute;", "&nbsp;", ";", "," };
            foreach (string xoa in danhsach1)
            {
                niceurl = niceurl.Replace(xoa, "");
            }
            return niceurl;
        }
        public static List<Cms_News> GetNewsBy_Cateid(int cid)
        {

            SQLServerConnection<Cms_News> sQLServer4 = new SQLServerConnection<Cms_News>();
            List<Cms_News> _NewsCate = sQLServer4.SelectQueryCommand("Get_NewsByCateIDAndPage", Common.getConnectionString(), cid, 15, 1);

            return _NewsCate;


        }

        ///Toàn viết thêm cho đặt lịch
        public static void Datlich(string gt1, string hoten1, string dt1, string ghichu1, string email1, string date1, string diachi1, string ghichudv, string pldl)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    // Next two lines are not required. You can comment or delete that lines without any regrets

                    client.BaseAddress = new Uri(CMS_Core.Common.Common.getLINKAPI());

                    var gt = gt1;
                    gt.ToString();
                    string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");


                    string date = date1;
                    DateTime Tungay = new DateTime();
                    if (!string.IsNullOrEmpty(date))
                    {
                        Tungay = DateTime.ParseExact(date, "dd/MM/yyyy", new CultureInfo("en-US"));

                    }
                    else
                    {
                        Tungay = DateTime.Parse(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2"));
                    }



                    string hoten = hoten1;
                    string dt = dt1;
                    string ngayhen = DateTime.Parse(abc).ToString();
                    string ghichu = ghichu1;
                    string email = email1;
                    string gioitinh = gt.ToString();
                    string namsinh = Tungay.ToString();

                    string diachi = diachi1;

                    string danhmuc = gt.ToString();
                    string namsinh2 = Tungay.ToString("MM-dd-yyyy");

                    string number = Common.getRandom().ToString();
                    string urlfull = $"{CMS_Core.Common.Common.getLINKAPI()}/api/Appointment/AppointmentPost/?token=" + Common.generalKeyPrivate(number) + "&number=" + number;

                    MEDLATEC2019.Entity.DatLich obj = new MEDLATEC2019.Entity.DatLich();
                    obj.Hoten = hoten;
                    obj.Sdt = dt;
                    obj.Ngayhen = DateTime.Parse(abc);
                    obj.Ghichu = ghichu;
                    obj.Email = email;
                    obj.Gioitinh = int.Parse(gioitinh);
                    obj.Namsinh = Tungay;
                    obj.Diachi = diachi1;


                    obj.Ghichudv = ghichudv;

                    obj.PLDL1 = pldl;

                    object result = string.Empty;

                    string serialisedData = JsonConvert.SerializeObject(obj);


                    HttpContent httpContent = new StringContent(serialisedData);
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage message = client.PostAsync(urlfull, httpContent).Result;


                    //string urlfull = $"{CMS_Core.Common.Common.getLINKAPI()}/api/Appointment/AppointmentPost/?token=" + Common.generalKeyPrivate(hoten);

                    //MEDLATEC2019.Entity.DatLich obj = new MEDLATEC2019.Entity.DatLich();
                    //obj.Hoten = hoten;
                    //obj.Sdt = dt;
                    //obj.Ngayhen = DateTime.Parse(abc);
                    //obj.Ghichu = ghichu;
                    //obj.Email = email;
                    //obj.Gioitinh = int.Parse(gioitinh);
                    //obj.Namsinh = Tungay;
                    //obj.Diachi = diachi1;


                    //obj.Ghichudv = ghichudv;

                    //obj.PLDL1 = pldl;

                    //object result = string.Empty;

                    //string serialisedData = JsonConvert.SerializeObject(obj);


                    //HttpContent httpContent = new StringContent(serialisedData);
                    //httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //HttpResponseMessage message = client.PostAsync(urlfull, httpContent).Result;

                    //using (var c = new WebClient())
                    //{
                    //    c.Headers[HttpRequestHeader.ContentType] = "application/json";
                    //    string serialisedData = JsonConvert.SerializeObject(obj);
                    //    var response = c.UploadString(urlfull, serialisedData);
                    //    result = JsonConvert.DeserializeObject(response);
                    //}
                }
                catch (Exception ex)
                {

                }
            }
        }

        public static void DatlichTin(string hoten1, string dt1, string ghichu1, string email1, string ghichudv, string pldl)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    // Next two lines are not required. You can comment or delete that lines without any regrets

                    client.BaseAddress = new Uri(CMS_Core.Common.Common.getLINKAPI());


                    string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");





                    string hoten = hoten1;
                    string dt = dt1;
                    string ngayhen = DateTime.Parse(abc).ToString();
                    string ghichu = ghichu1;
                    string email = email1;



                    string number = Common.getRandom().ToString();

                    string urlfull = $"{CMS_Core.Common.Common.getLINKAPI()}/api/Appointment/AppointmentPost/?token=" + Common.generalKeyPrivate(number) + "&number=" + number;

                    MEDLATEC2019.Entity.DatLich obj = new MEDLATEC2019.Entity.DatLich();



                    obj.Hoten = hoten;
                    obj.Sdt = dt;
                    obj.Ngayhen = DateTime.Parse(abc);
                    obj.Ghichu = ghichu;
                    obj.Email = email;
                    obj.Gioitinh = 1;
                    obj.Namsinh = DateTime.Parse("01-01-1900");
                    obj.Diachi = "";


                    obj.Ghichudv = ghichudv;

                    obj.PLDL1 = pldl;




                    object result = string.Empty;

                    string serialisedData = JsonConvert.SerializeObject(obj);


                    HttpContent httpContent = new StringContent(serialisedData);
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage message = client.PostAsync(urlfull, httpContent).Result;

                    //using (var c = new WebClient())
                    //{
                    //    c.Headers[HttpRequestHeader.ContentType] = "application/json";
                    //    string serialisedData = JsonConvert.SerializeObject(obj);
                    //    var response = c.UploadString(urlfull, serialisedData);
                    //    result = JsonConvert.DeserializeObject(response);
                    //}
                }
                catch (Exception ex)
                {

                }
            }
        }


        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetDichvu()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Siêu âm tuyến giáp", Value = "20KMTGTX" });
                items.Add(new SelectListItem { Text = "Xét nghiệm tầm soát ung thư Gan", Value = "20KMATX" });


                return items;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetGioiTinh()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Nam", Value = "1" });
                items.Add(new SelectListItem { Text = "Nữ", Value = "2" });


                return items;
            }
            catch (Exception ex)
            {

                return null;
            }
        }


        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> Getkyniem25()
        {

            try
            {
                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Đơn vị/Phòng ban", Value = "" });
                List<tbl_kyniem25> kyniem25;
                SQLServerConnection<tbl_kyniem25> sQLServer = new SQLServerConnection<tbl_kyniem25>();
                kyniem25 = sQLServer.SelectQueryCommand("tbl_kyniem25_donvi_select", Common.getConnectionString());


                foreach (var item in kyniem25)
                {
                    items.Add(new SelectListItem { Text = item.Hovaten.ToString(), Value = item.Hovaten });
                }


                return items;
            }
            catch (Exception ex)
            {

                return null;
            }


        }

        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> benhlycoban()
        {

            try
            {
                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Địa điểm sử dụng dịch vụ", Value = "" });
                items.Add(new SelectListItem { Text = "Hà Nội hoặc Vĩnh Phúc", Value = "1" });
                items.Add(new SelectListItem { Text = "Bắc Ninh", Value = "2" });
                items.Add(new SelectListItem { Text = "Đà Nẵng", Value = "3" });
                items.Add(new SelectListItem { Text = "Huế", Value = "4" });
                items.Add(new SelectListItem { Text = "Hồ Chí Minh hoặc Cần Thơ ", Value = "5" });
                items.Add(new SelectListItem { Text = "Các tỉnh khác", Value = "6" });



                return items;
            }
            catch (Exception ex)
            {

                return null;
            }


        }

        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetDichvuShopee()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = " Chọn gói khám ", Value = "" });
                items.Add(new SelectListItem { Text = "Miễn phí khám Nhi Khoa", Value = "20KMSHOPE1" });
                items.Add(new SelectListItem { Text = "Voucher 200.000vnđ", Value = "200" });
                items.Add(new SelectListItem { Text = "GK Tổng quát và vi chất cơ bản", Value = "20KMSHOPE2" });
                items.Add(new SelectListItem { Text = "GK Tổng quát và vi chất nâng cao", Value = "20KMSHOPE3" });




                return items;
            }
            catch (Exception ex)
            {

                return null;
            }
        }


        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> XetNghiemTongQuat()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = " Chọn gói khám ", Value = "" });
                items.Add(new SelectListItem { Text = "GK Tổng quát-ung thư cơ bản Nữ", Value = "20KMGKTN8" });
                items.Add(new SelectListItem { Text = "GK Tổng quát-ung thư cơ bản Nam", Value = "20KMGKTN9" });
                items.Add(new SelectListItem { Text = "GK Tổng quát-ung thư nâng cao Nữ", Value = "20KMGKTN10" });
                items.Add(new SelectListItem { Text = "GK Tổng quát-ung thư nâng cao Nam", Value = "20KMGKTN11" });




                return items;
            }
            catch (Exception ex)
            {

                return null;
            }
        }



        public static List<SelectListItem> Getthoigiankham()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Thời gian đặt lịch khám", Value = string.Empty });
                items.Add(new SelectListItem { Text = "7h15-12h", Value = "7h12h" });
                items.Add(new SelectListItem { Text = "13h30-17h", Value = "13h17h" });



                return items;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetDichvuNIPT()
        {
            try
            {
                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "--Chọn dịch vụ--", Value = "" });

                items.Add(new SelectListItem { Text = "Gói NIPT - BasicSave 4 ngày", Value = "18820NIPTBA" });
                items.Add(new SelectListItem { Text = "Gói NIPT - BasicSave 6 ngày", Value = "20KMNIBA" });
                items.Add(new SelectListItem { Text = "Gói NIPT - ProSave 4 ngày", Value = "18820NIPTPO" });
                items.Add(new SelectListItem { Text = "Gói NIPT - ProSave 6 ngày", Value = "20KMNIPO" });

                return items;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetDichvuNIPTNew()
        {         
            try
            {
                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "--Chọn dịch vụ--", Value = "" });

                items.Add(new SelectListItem { Text = "Gói NIPT BASIC 6 ngày", Value = "21KDTT16" });
                items.Add(new SelectListItem { Text = "Gói NIPT PRO 6 ngày", Value = "21KDTT17" });
                items.Add(new SelectListItem { Text = "Gói NIPT PLUS", Value = "21KDTT18" });
                items.Add(new SelectListItem { Text = "Gói NIPT TWIN", Value = "21KDTT19" });
                items.Add(new SelectListItem { Text = "Gói NIPT BASIC 4 ngày", Value = "21KDTT20" });
                items.Add(new SelectListItem { Text = "Gói NIPT PRO 4 ngày", Value = "21KDTT21" });



                return items;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static List<SelectListItem> getNamThuchien()
        {
            try
            {
                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Năm", Value = "" });
                for (int i = 0; i <= 10; i++)
                {
                    items.Add(new SelectListItem { Text = DateTime.Now.AddYears(-i).Year.ToString(), Value = DateTime.Now.AddYears(-i).Year.ToString() });
                }


                return items;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static List<SelectListItem> getChuyenKhoa()
        {
            try
            {
                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Chuyên khoa", Value = "0" });
                List<cms_Scientist_Cate> Scientist_Cate;
                SQLServerConnection<cms_Scientist_Cate> sQLServer = new SQLServerConnection<cms_Scientist_Cate>();
                Scientist_Cate = sQLServer.SelectQueryCommand("cms_Scientist_Cate_SelectActive", Common.getConnectionString());


                foreach (var item in Scientist_Cate)
                {
                    items.Add(new SelectListItem { Text = item.ID.ToString(), Value = item.ScientistTitle });
                }


                return items;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static string StripTagsHTML(string tags, string html)
        {
            string pattern = @"</*(" + tags + ")[^>]*>";
            return Regex.Replace(html, pattern, string.Empty);
        }

        /// <summary>
        /// Remove attributes of tag
        /// </summary>
        /// <param name="attributes">attributes</param>
        /// <param name="html">Input content</param>
        /// <returns>Output content</returns>
        public static string StripAttributesTags(string attributes, string html)
        {
            //Replace width and height of tag HTML
            html = Regex.Replace(html, @"(" + attributes + @")\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?", String.Empty);
            return html;
        }

        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetChuyengia()
        {
            try
            {
                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Lựa chọn chuyên gia bạn muốn", Value = "" });
                items.Add(new SelectListItem { Text = "CK Gan mật - PGS. TS Trịnh Thị Ngọc, Thứ 3-5-7, 99 Trích Sài", Value = "1_20KMCG1" });
                items.Add(new SelectListItem { Text = "CK Gan mật - TS. BS Trần Văn Giang, Thứ 7-CN, 42-44 Nghĩa Dũng", Value = "2_20KMCG1" });
                items.Add(new SelectListItem { Text = "CK Hô hấp - PGS. TS Hoàng Thị Phượng, Thứ 3-4-5, 42-44 Nghĩa Dũng", Value = "1_20KMCG2" });
                items.Add(new SelectListItem { Text = "CK Hô hấp - BS CKI Vũ Thanh Tuấn, 42-44 Nghĩa Dũng", Value = "2_20KMCG2" });
                items.Add(new SelectListItem { Text = "CK Hô hấp - BS CKI Lê Thị Hoài Thanh, 99 Trích Sài", Value = "3_20KMCG2" });
                items.Add(new SelectListItem { Text = "CK Tiêu hóa - PGS. TS Trần Việt Tú, Thứ 7, 42-44 Nghĩa Dũng", Value = "1_20KMCG3" });
                items.Add(new SelectListItem { Text = "CK Tiêu hóa - BS Bùi Văn Long, 42-44 Nghĩa Dũng", Value = "2_20KMCG3" });
                items.Add(new SelectListItem { Text = "CK Tiêu hóa - BS CKI Lê Văn Khoa, 99 Trích Sài", Value = "3_20KMCG3" });
                items.Add(new SelectListItem { Text = "CK Sản - BS Nguyễn Thị Hiền, 42-44 Nghĩa Dũng", Value = "1_20KMCG4" });
                items.Add(new SelectListItem { Text = "CK Sản - BS CKI Dương Ngọc Vân, 99 Trích Sài", Value = "2_20KMCG4" });
                items.Add(new SelectListItem { Text = "CK Sản - BS Nguyễn Thị Thủy, 03 Khuất Duy Tiến", Value = "3_20KMCG4" });

                return items;
            }
            catch (Exception ex)
            {

                return null;
            }
        }



        public static List<SelectListItem> GetTypeLocaltion()
        {
            try
            {


                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "Tất cả", Value = "" });
                items.Add(new SelectListItem { Text = "Khu vực miền Bắc", Value = "MB" });
                items.Add(new SelectListItem { Text = "Khu vực miền Nam", Value = "MN" });
                items.Add(new SelectListItem { Text = "Khu vực miền Trung", Value = "MT" });



                return items;
            }
            catch (Exception ex)
            {

                return null;
            }
        }


        /// <summary>  
        /// Get GetTypeStatus method.  
        /// </summary>  
        /// <returns>Return Type for drop down list.</returns>  
        public static List<SelectListItem> GetNgayThucHien(int type)
        {
            try
            {
                List<SelectListItem> items = new List<SelectListItem>();
                if (type == 1)
                {
                    items.Add(new SelectListItem { Text = "Thứ 3", Value = "thu3" });
                    items.Add(new SelectListItem { Text = "Thứ 5", Value = "thu5" });
                    items.Add(new SelectListItem { Text = "Thứ 5", Value = "thu6" });
                }
                else
                {
                    items.Add(new SelectListItem { Text = "Thứ 3", Value = "thu3" });
                    items.Add(new SelectListItem { Text = "Thứ 5", Value = "thu5" });
                    items.Add(new SelectListItem { Text = "Thứ 5", Value = "thu6" });
                }
                return items;
            }
            catch (Exception ex)
            {

                return null;
            }
        }


        public static void DatGoiKham(int IDGoi, string MaGoi, string TenGoi, DateTime NgayBan, string Tel, DateTime NgayKham, DateTime GioHen1, DateTime GioHen2, string NguoiMua, string DiaChi, string noikham)
        {

            using (var client = new HttpClient())
            {
                try
                {
                    // Next two lines are not required. You can comment or delete that lines without any regrets

                    client.BaseAddress = new Uri(CMS_Core.Common.Common.getLINKAPI());


                    string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");






                    string ngayhen = DateTime.Parse(abc).ToString();




                    string number = Common.getRandom().ToString();

                    string urlfull = $"{CMS_Core.Common.Common.getLINKAPI()}api/CCOMed/AddGoiKhamCTBan/?token=" + Common.generalKeyPrivate(number) + "&number=" + number;

                    MEDLATEC.BusinessLayer.GoiKhamCTBan obj = new MEDLATEC.BusinessLayer.GoiKhamCTBan();


                    if (string.IsNullOrEmpty(noikham))
                    {
                        noikham = string.Empty;
                    }


                    obj.IDGoi = IDGoi;
                    obj.MaGoi = MaGoi;
                    obj.TenGoi = TenGoi;
                    obj.NgayBan = NgayBan;
                    obj.Tel = Tel;
                    obj.NgayKham = NgayKham;
                    obj.GioHen1 = GioHen1;
                    obj.GioHen2 = GioHen2;

                    obj.NguoiMua = NguoiMua;
                    obj.DiaChi = DiaChi;
                    obj.NoiKham = noikham;

                    object result = string.Empty;

                    string serialisedData = JsonConvert.SerializeObject(obj);


                    HttpContent httpContent = new StringContent(serialisedData);
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage message = client.PostAsync(urlfull, httpContent).Result;


                }
                catch (Exception ex)
                {

                }
            }
        }

        public static void DatGoiKham(int IDGoi, string MaGoi, string TenGoi, DateTime NgayBan, string Tel, DateTime NgayKham, DateTime GioHen1, DateTime GioHen2, string NguoiMua, string DiaChi )
        {

            using (var client = new HttpClient())
            {
                try
                {
                    // Next two lines are not required. You can comment or delete that lines without any regrets

                    client.BaseAddress = new Uri(CMS_Core.Common.Common.getLINKAPI());


                    string abc = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");






                    string ngayhen = DateTime.Parse(abc).ToString();




                    string number = Common.getRandom().ToString();

                    string urlfull = $"{CMS_Core.Common.Common.getLINKAPI()}api/CCOMed/AddGoiKhamCTBan/?token=" + Common.generalKeyPrivate(number) + "&number=" + number;

                    MEDLATEC.BusinessLayer.GoiKhamCTBan obj = new MEDLATEC.BusinessLayer.GoiKhamCTBan();


                  

                    obj.IDGoi = IDGoi;
                    obj.MaGoi = MaGoi;
                    obj.TenGoi = TenGoi;
                    obj.NgayBan = NgayBan;
                    obj.Tel = Tel;
                    obj.NgayKham = NgayKham;
                    obj.GioHen1 = GioHen1;
                    obj.GioHen2 = GioHen2;

                    obj.NguoiMua = NguoiMua;
                    obj.DiaChi = DiaChi;
                    
                    object result = string.Empty;

                    string serialisedData = JsonConvert.SerializeObject(obj);


                    HttpContent httpContent = new StringContent(serialisedData);
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage message = client.PostAsync(urlfull, httpContent).Result;
                    

                }
                catch (Exception ex)
                {
                    Common.AddToLogFile("Loi he thong: " + ex.Message);
                }
            }
        }

    }

}
