using proms.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace proms.utils
{
    public class RequestService
    {
        public static object post (KeyValue[] headers, string endPoint, string payLoad)
        {
            var request = (HttpWebRequest)WebRequest.Create(endPoint);
            
            if (headers != null)
            {
                foreach (KeyValue header in headers)
                {
                    request.Headers.Add(header.key, header.value.ToString());
                    //request.Headers[header.key] = header.value.ToString();
                }
            }
            if (payLoad != null)
            {
                var data = Encoding.ASCII.GetBytes(payLoad);
                request.ContentLength = data.Length;
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            request.Method = "POST";
            request.ContentType = "application/json";
            WebResponse response = request.GetResponse();
            switch (((HttpWebResponse)response).StatusCode)
            {
                case HttpStatusCode.OK:
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    reader.Close(); dataStream.Close(); response.Close();
                    return responseFromServer;
                default:
                    return null;
            }
        }

        public static object get(KeyValue[] headers, string endPoint, string payLoad)
        {
            // Create the web request  
            HttpWebRequest request = WebRequest.Create(endPoint) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            return response;
            //// Get response  
            //using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            //{
            //    // Get the response stream  
            //    StreamReader reader = new StreamReader(response.GetResponseStream());

            //    // Console application output  
            //    Console.WriteLine(reader.ReadToEnd());
            //    return reader.ReadToEnd();
            //}

            //try
            //{
            //    var webRequest = (HttpWebRequest)WebRequest.Create(endPoint);
            //    webRequest.Method = "GET";
            //    webRequest.ContentType = "application/json";

            //    if (headers != null)
            //    {
            //        foreach (KeyValue header in headers)
            //        {
            //            webRequest.Headers.Add(header.key, header.value.ToString());
            //        }
            //    }
            //    webRequest.Headers.Add("cache-control", "no-cache");
            //    webRequest.KeepAlive = false;
            //    try
            //    {
            //        HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            //        // Get the stream associated with the response.
            //        Stream receiveStream = response.GetResponseStream();
            //        // Pipes the stream to a higher level stream reader with the required encoding format. 
            //        StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            //        string resString = readStream.ReadToEnd();
            //        //Console.WriteLine(readStream.ReadToEnd());
            //        response.Close();
            //        readStream.Close();
            //        return resString;
            //    }
            //    catch (WebException ex)
            //    {
            //        //var resp = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
            //        //Console.WriteLine(resp);
            //        return ex;
            //    }


            //    //var httpResponse = (HttpWebResponse)webRequest.GetResponse();
            //    //var webpageReader = new StreamReader(httpResponse.GetResponseStream());
            //    //var response = webpageReader.ReadToEnd();
            //    //return response;
            //}
            //catch (WebException ex)
            //{
            //    return ex;
            //}
        }

        //public static object get(KeyValue[] headers, string endPoint, string payLoad)
        //{
        //    WebRequest wrGETURL = WebRequest.Create(endPoint);
        //    if (headers != null)
        //    {
        //        foreach (KeyValue header in headers)
        //        {
        //            wrGETURL.Headers.Add(header.key, header.value.ToString());
        //        }
        //    }
        //    //WebProxy myProxy = new WebProxy("myproxy", 80);
        //    //myProxy.BypassProxyOnLocal = true;
        //    //wrGETURL.Proxy = WebProxy.GetDefaultProxy();
        //    Stream objStream  = wrGETURL.GetResponse().GetResponseStream();
        //    using (StreamReader reader = new StreamReader(objStream))
        //    {
        //        return reader.ReadToEnd();
        //    }

        //    //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
        //    //request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
        //    //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        //    //using (Stream stream = response.GetResponseStream())

        //    //using (StreamReader reader = new StreamReader(stream))
        //    //{
        //    //    return reader.ReadToEnd();
        //    //}

        //    //var request = (HttpWebRequest)WebRequest.Create(endPoint);

        //    //if (headers != null)
        //    //{
        //    //    foreach (KeyValue header in headers)
        //    //    {
        //    //        request.Headers.Add(header.key, header.value.ToString());
        //    //        //request.Headers[header.key] = header.value.ToString();
        //    //    }
        //    //}
        //    //if (payLoad != null)
        //    //{
        //    //    var data = Encoding.ASCII.GetBytes(payLoad);
        //    //    request.ContentLength = data.Length;
        //    //    using (var stream = request.GetRequestStream())
        //    //    {
        //    //        stream.Write(data, 0, data.Length);
        //    //    }
        //    //}
        //    //request.Method = "GET";
        //    //request.ContentType = "application/json";
        //    //WebResponse response = request.GetResponse();
        //    //switch (((HttpWebResponse)response).StatusCode)
        //    //{
        //    //    case HttpStatusCode.OK:
        //    //        Stream dataStream = response.GetResponseStream();
        //    //        StreamReader reader = new StreamReader(dataStream);
        //    //        string responseFromServer = reader.ReadToEnd();
        //    //        reader.Close(); dataStream.Close(); response.Close();
        //    //        return responseFromServer;
        //    //    default:
        //    //        return null;
        //    //}
        //}

    }
}