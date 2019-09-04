using Newtonsoft.Json;
using proms.controllers;
using proms.models;
using proms.models.common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proms.api.auth
{
    public partial class requestResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string payLoad;
            using (var reader = new StreamReader(Request.InputStream))
                payLoad = reader.ReadToEnd();
            Commoner commoner = JsonConvert.DeserializeObject<Commoner>(payLoad);
            Response response = new AuthController().requestPasswordReset(commoner);
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(JsonConvert.SerializeObject(response));
            Response.End();
        }
    }
}