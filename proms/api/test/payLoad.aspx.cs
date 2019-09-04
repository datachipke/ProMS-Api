using Newtonsoft.Json;
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
    public partial class payLoad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string payLoad;
            using (var reader = new StreamReader(Request.InputStream))
                payLoad = reader.ReadToEnd();
            object st = Utils.generateKeyValueFromJSONString(payLoad);
            // Response response = new AuthController().signUp("users", JsonConvert.DeserializeObject<Commoner>(payLoad));

            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(JsonConvert.SerializeObject(st));
            Response.End();
        }
    }
}