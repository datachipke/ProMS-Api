using Newtonsoft.Json;
using proms.controllers;
using proms.models;
using proms.models.common;
using proms.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proms.api.mpesa
{
    public partial class callback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string payLoad;
            using (var reader = new StreamReader(Request.InputStream))
                payLoad = reader.ReadToEnd();
            Dictionary<string, string> dicGetData = JsonConvert.DeserializeObject<Dictionary<string, string>>(Request.QueryString["getData"].Replace("\\", ""));
            
            Response response = new PaymentController().mpesaCallback(JsonConvert.DeserializeObject<STKCallbackResponse>(payLoad), JsonConvert.DeserializeObject<Commoner>(JsonConvert.SerializeObject(dicGetData)));
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(JsonConvert.SerializeObject(response));
            Response.End();
        }

        public class GetData
        {
            public string token { set; get; }
        }
    }
}