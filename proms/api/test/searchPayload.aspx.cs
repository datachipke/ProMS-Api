using Newtonsoft.Json;
using proms.controllers;
using proms.handlers.models;
using proms.models;
using proms.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proms.api.test
{
    public partial class searchPayload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string payLoad;
            using (var reader = new StreamReader(Request.InputStream))
                payLoad = reader.ReadToEnd();
            Utils.generateKeyValueFromJSONString(payLoad);
             Response response = new TestController().search(JsonConvert.DeserializeObject<SearchModel>(payLoad));
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(JsonConvert.SerializeObject(response));
            Response.End();
        }
    }
}