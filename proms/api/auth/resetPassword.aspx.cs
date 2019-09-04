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

namespace proms.api.auth
{
    public partial class resetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string payLoad;
            using (var reader = new StreamReader(Request.InputStream))
                payLoad = reader.ReadToEnd();
            Commoner commoner = JsonConvert.DeserializeObject<Commoner>(payLoad);
            Response response = new AccountController().update("users",
                new KeyValue[] { new KeyValue("email", commoner.email) },
                new KeyValue[] { new KeyValue("password", Utils.encryptPassword(commoner.password)) }
            );
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(JsonConvert.SerializeObject(response));
            Response.End();
        }
    }
}