using Newtonsoft.Json;
using proms.controllers;
using proms.models;
using proms.models.auth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proms.api.auth
{
    public partial class signIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RequestHandler requestHandler = new RequestHandler();
            //Response response = requestHandler.flagRequest(Request);
            //if (response.status)
            //{
                string payLoad;
                using (var reader = new StreamReader(Request.InputStream))
                    payLoad = reader.ReadToEnd();
            Response response = new AuthController().signIn(JsonConvert.DeserializeObject<SignIn>(payLoad));
            //}
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(JsonConvert.SerializeObject(response));
            Response.End();
        }
    }
}