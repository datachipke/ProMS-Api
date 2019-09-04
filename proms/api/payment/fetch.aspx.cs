using Newtonsoft.Json;
using proms.controllers;
using proms.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proms.api.payment
{
    public partial class fetch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string payLoad;
            using (var reader = new StreamReader(Request.InputStream))
                payLoad = reader.ReadToEnd();
            //object pa = JsonConvert.DeserializeObject<object>(payLoad);
            Response response = new PaymentController().fetch(new KeyValue[] {
                new KeyValue("crId", Request.QueryString["crId"])
            });
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(JsonConvert.SerializeObject(response));
            Response.End();
        }
    }
}