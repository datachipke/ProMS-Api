using Newtonsoft.Json;
using proms.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace proms.utils
{
    public class Utils
    {
        public static KeyValue[] generateKeyValueFromJSONString(object cObject)
        {
            Dictionary<string, object> myDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(cObject));
            KeyValue[] keyValues = new KeyValue[myDictionary.Count];
            int i = 0;
            foreach (KeyValuePair<string, object> pair in myDictionary)
            {
                if (pair.Value.GetType().FullName == "Newtonsoft.Json.Linq.JObject")
                {
                    keyValues[i] = new KeyValue(pair.Key, generateKeyValueFromJSONString(JsonConvert.SerializeObject(pair.Value)));
                }
                else
                {
                    keyValues[i] = new KeyValue(pair.Key, pair.Value.ToString());
                }
                i++;
            }
            return keyValues;
        }
        public static object serializedArrayToObject(object[] data)
        {
            return data[0];
        }
        public static KeyValue[] pairRequestQuery(string requestQuery)
        {
            string[] pairs = requestQuery.Split('&');
            KeyValue[] pairModel = new KeyValue[pairs.Length];
            int i = 0;
            foreach (string pair in pairs)
            {
                string[] paxes = pair.Split('=');
                pairModel[i] = new KeyValue(paxes[0], paxes[1]);
                i ++;
            }
            return pairModel;
        }
        public static string encryptPassword(string source)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return GetMd5Hash(md5Hash, source);
            }
        }
        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public static int randomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public static string randomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
    }
}