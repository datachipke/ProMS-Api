using Newtonsoft.Json;
using proms.controllers;
using proms.models;
using proms.models.common;
using proms.models.payment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proms.api.payment
{
    public partial class make_payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string payLoad;
            using (var reader = new StreamReader(Request.InputStream))
                payLoad = reader.ReadToEnd();
            PayLoad pa = JsonConvert.DeserializeObject<PayLoad>(payLoad);
            Response response = new PaymentController().makePayment(pa.paymentModel, pa.userModel);
      
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(JsonConvert.SerializeObject(response));
            Response.End();
        }

        class PayLoad
        {
            public PaymentModel paymentModel { set; get; }
            public Commoner userModel { set; get; }
        }
    }
}