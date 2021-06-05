using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace CMS_Core.Common
{
    public class ImpCallAPI<AnyType>
    {

        public static List<AnyType> geContentAPI(string url)
        {
            try
            {
                HttpClient http = new HttpClient();
                string baseUrl = CMS_Core.Common.Common.getLINKAPI() + url;
                HttpResponseMessage response = http.GetAsync(new Uri(baseUrl)).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    List<AnyType> convert = JsonConvert.DeserializeObject<List<AnyType>>(result);// as List<AnyType>;
                    return convert;
                    // var data = JsonConvert.DeserializeObject<byte[]>(content);
                }
                else
                {
                    return null;
                }
            }
            catch ( Exception ex)
            {
                return null;
            }

        }


        

        public static List<AnyType> geContentAPINew(string url)
        {

            try
            {
                HttpClient http = new HttpClient();
                string baseUrl = CMS_Core.Common.Common.getLINKAPI() + url;

                HttpResponseMessage response = http.GetAsync(new Uri(baseUrl)).Result;

                JavaScriptSerializer _Serializer = new JavaScriptSerializer();

                var result = response.Content.ReadAsStringAsync().Result ;
                List<AnyType> convert = JsonConvert.DeserializeObject<List<AnyType>>(result);// as List<AnyType>;

               

                return convert;
                // var data = JsonConvert.DeserializeObject<byte[]>(content);

            }
            catch ( Exception ex)
            {
                return null;
            }

        }


        public static bool geContentAPIRespon(string url)
        {

            try
            {
                HttpClient http = new HttpClient();
                string baseUrl = CMS_Core.Common.Common.getLINKAPI() + url;

                HttpResponseMessage response = http.GetAsync(new Uri(baseUrl)).Result;

                var result = response.Content.ReadAsStringAsync().Result;



                return true;

            }
            catch
            {
                return false;
            }

        }

    }
}