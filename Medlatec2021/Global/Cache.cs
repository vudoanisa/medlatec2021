using System;
using System.Collections;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace MEDLATEC2019.Web
{
    public class Cache
    {
        public static async Task Clear()
        {
            try
            {
                await Task.Run(() =>
                {
                    foreach (object obj in HttpRuntime.Cache)
                    {
                        Remove((string)((DictionaryEntry)obj).Key);
                    }
                });
            }
            catch (Exception ex)
            {
               // Bug.Write(ex);
            }

        }
        private static void Remove(string keyCache)
        {
            if (HttpRuntime.Cache[keyCache] != null)
                HttpRuntime.Cache.Remove(keyCache);

        }

        public async static Task Clear(string tableName)
        {
            try
            {

                await Task.Run(() =>
                {

                    foreach (object obj in HttpRuntime.Cache)
                    {
                        string text = (string)((DictionaryEntry)obj).Key;
                        if (text.StartsWith(CacheName + "." + tableName, StringComparison.OrdinalIgnoreCase))
                            Remove(text);

                    }
                });
            }
            catch (Exception ex)
            {
              //  Bug.Write(ex);
            }

        }

        public async static Task Clear(dynamic objDynamic)
        {
            try
            {
                await Task.Run(() =>
                {
                    foreach (object obj in HttpRuntime.Cache)
                    {
                        string text = (string)((DictionaryEntry)obj).Key;
                        if (text.StartsWith(CacheName + "." + objDynamic.TableName, StringComparison.OrdinalIgnoreCase))
                            Remove(text);
                    }

                });
            }
            catch (Exception ex)
            {
               // Bug.Write(ex);
            }
        }

        public static object GetValue(string key)
        {
            return HttpRuntime.Cache[CacheName + "." + key];
        }


        public static void SetValue(string key, object obj)
        {
            _ = SetValue(key, obj, -1);
        }
        public async static Task SetValue(string key, object obj, int minutes)
        {
            try
            {
                await Task.Run(() =>
                {
                    if (obj != null)
                    {
                        if (minutes > 0)
                            HttpRuntime.Cache.Insert(CacheName + "." + key, obj, null, DateTime.Now.AddMinutes(minutes), TimeSpan.Zero, CacheItemPriority.Normal, null);
                        else
                            HttpRuntime.Cache.Insert(CacheName + "." + key, obj);
                    }
                });
            }
            catch (Exception ex)
            {
              //  Bug.Write(ex);
            }

        }

        public static string CreateKey(string tableName, string key)
        {
            if (!tableName.StartsWith("[", StringComparison.OrdinalIgnoreCase)) tableName = "[" + tableName + "]";

            return tableName + "." + key;
        }

        public static string CreateKey(string tableName) => CreateKey(tableName, string.Empty);

        private static string CacheName = "IMEXsoft.Core.Cache.MEDLATEC2021";


    }
}

