using Newtonsoft.Json;
using proms.controllers;
using proms.models;
using proms.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proms.api.account
{
    public partial class update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string payLoad;
            using (var reader = new StreamReader(Request.InputStream))
                payLoad = reader.ReadToEnd();
            Response response = new AccountController().update("users", 
                Utils.generateKeyValueFromJSONString(JsonConvert.DeserializeObject<PayLoad>(payLoad).keyModel),
                Utils.generateKeyValueFromJSONString(JsonConvert.DeserializeObject<PayLoad>(payLoad).updateModel)
            );
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(JsonConvert.SerializeObject(response));
            Response.End();
        }

        public class PayLoad
        {
            public object keyModel { set; get; }
            public object updateModel { set; get; }
           
        }
    }
}