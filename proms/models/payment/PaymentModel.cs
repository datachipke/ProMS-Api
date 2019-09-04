using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proms.models.payment
{
    public class PaymentModel
    {
        public string paymentMode { set; get; }
        public string mpesaPhone { set; get; }
        public double amount { set; get; }

    }
}