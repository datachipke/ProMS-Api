using Newtonsoft.Json;
using proms.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace proms.controllers
{
    public class MpesaController
    {
        private string timeNow = "";
        private string businessShortCode = "174379";
        private string passKey = "bfb279f9aa9bdbcf158e97dd71a467cd2e0c893059b10f78e6b72ada1ed2c919";
        private string authKey = "hAVnRxa2UOjyAnydVJMG31A0OuDDCxm5";
        private string stkRequestUrl = "https://sandbox.safaricom.co.ke/mpesa/stkpush/v1/processrequest";
        private string oauthtUrl = "https://sandbox.safaricom.co.ke/oauth/v1/generate?grant_type=client_credentials";
        private string password = "";
        private string accessToken = "";
        private string secret = "UcpmdCdI8bAakdgm";
        private string partyB = "174379";
        public object makeSTKPush()
        {
            return RetrieveAsset(oauthtUrl, "application/json");
        }
        private object RetrieveAsset(string uri, string contentType)
        {
            try
            {
                Byte[] bytes;
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
                webRequest.KeepAlive = false;
                webRequest.ProtocolVersion = HttpVersion.Version10;
                webRequest.ServicePoint.ConnectionLimit = 1;
                webRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(authKey + ":" + secret)));
                using (WebResponse webResponse = webRequest.GetResponse())
                {
                    webRequest.ContentType = "application/json";
                    //contentType = webResponse.ContentType;
                    using (Stream stream = webResponse.GetResponseStream())
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            Byte[] buffer = new Byte[0x1000];

                            Int32 bytesRead;
                            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                memoryStream.Write(buffer, 0, bytesRead);
                            }
                            bytes = memoryStream.ToArray();
                        }
                    }
                }
                return bytes;
            }
            catch (Exception ex)
            {
                return ex;
                //throw new Exception("Failed to retrieve asset from '" + uri + "': " + ex.Message, ex);
            }
        }

        private object getAccessToken()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(oauthtUrl);
            request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(authKey + ":" + secret)));
            request.ContentType = "application/json";
            request.Headers.Add("cache-control", "no-cache");
            request.Method = "GET";
            try
            {
                System.Net.ServicePointManager.Expect100Continue = false;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                // Get the stream associated with the response.
                Stream receiveStream = response.GetResponseStream();
                // Pipes the stream to a higher level stream reader with the required encoding format. 
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                response.Close();
                readStream.Close();
                return readStream.ReadToEnd();
            }
            catch (WebException ex)
            {
                return ex;
            }

            //string outh = authKey+":"+secret;
            //byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(outh);
            //string credentials = Convert.ToBase64String(toEncodeAsBytes);
            //KeyValue[] headers = new KeyValue[] { new KeyValue("Authorization", " Basic " + credentials) };
            //return utils.RequestService.get(headers, authtUrl, null);
        }
    }
}