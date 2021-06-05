using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Serialization;

namespace MEDLATEC2019.Global
{
    /// <summary>
    /// add by TruongBeo
    /// </summary>
    public class Utils
    {
        public static string Domain
        {
            get
            {
                return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + (HttpContext.Current.Request.IsLocal ? ":" + HttpContext.Current.Request.UserHostAddress : string.Empty);
            }
        }
        public static string GetResponseJson(string url)
        {
            Uri uri = new Uri(url);
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
                request.Method = WebRequestMethods.Http.Get;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string output = reader.ReadToEnd();
                response.Close();
                return output;

            }
            catch (Exception ex)
            {

                throw;
            }


        }





        public static string GetFirstChar(string s)
        {
            if (string.IsNullOrEmpty(s))
                return "";

            string result = "";

            //lấy danh sách các từ  
            s = RemoveNotAbcChar(RemoveVietNamese(s));

            string[] words = s.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {

                if (words[i].Length >= 1)
                    result += words[i].Substring(0, 1).ToLower();
            }

            return result.Trim();
        }
        public static string RemoveVietNamese(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            const string findText = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";
            const string replText = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY";

            int index;
            while ((index = s.IndexOfAny(findText.ToCharArray())) != -1)
            {
                var index2 = findText.IndexOf(s[index]);
                s = s.Replace(s[index], replText[index2]);
            }
            return s;
        }
        private static string RemoveNotAbcChar(string s)
        {
            var result = string.Empty;
            foreach (var t in s)
            {
                var c = t;

                if (c == 160)
                    c = ' ';

                if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
                    result += c.ToString();
            }
            return result;
        }
        /// <summary>
        /// Validate Định dạng số điện thoại
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsPhoneNumber(string number)
        {
            number = number.Replace("-", "").Replace(".", "");
            return Regex.Match(number, @"^(0)+([0-9]{9})$").Success;
        }
        //hàm covert kiểu decimal thành kiểu float 123,456,789.00
        public static string FormatFloat(decimal money)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0:#,##0.##}", money);
        }
        //hàm covert kiểu int thành kiểu float 123,456,789.00
        public static string FormatFloat(int money)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0:#,##0.##}", money);
        }
        //hàm covert kiểu double thành kiểu float 123,456,789.00
        public static string FormatFloat(double money)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0:#,##0.##}", money);
        }
        //hàm covert kiểu decimal thành kiểu tiền tệ 123,456,789
        public static string FormatMoney(decimal money)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0:#,##0}", money);
        }
        //hàm covert kiểu int thành kiểu tiền tệ 123,456,789
        public static string FormatMoney(int money)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0:#,##0}", money);
        }
        //hàm covert kiểu double thành kiểu tiền tệ 123,456,789
        public static string FormatMoney(double money)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0:#,##0}", money);
        }
        //hàm covert kiểu double thành kiểu tiền tệ 123,456,789
        public static string FormatMoney(long money)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0:#,##0}", money);
        }
        //hàm cồng chuỗi 
        public static string GetText(string[] arrString)
        {
            string @string = "";

            for (int i = 0; arrString != null && i < arrString.Length; i++)
                if (!string.IsNullOrEmpty(arrString[i])) @string += (!string.IsNullOrEmpty(@string) ? "," : "") + arrString[i];

            return @string;
        }
        public static string FormatDate(DateTime datetime)
        {
            if (datetime <= DateTime.MinValue)
            {
                return "";
            }
            return string.Format("{0:dd/MM/yyyy}", datetime);
        }

        public static T Deserialize<T>(string input) where T : class
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input))
            {
                return (T)ser.Deserialize(sr);
            }
        }

        /// <summary>
        /// convert object to xml string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ObjectToSerialize"></param>
        /// <returns></returns>
        public string Serialize<T>(T ObjectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, ObjectToSerialize);
                return textWriter.ToString();
            }
        }
    }
}