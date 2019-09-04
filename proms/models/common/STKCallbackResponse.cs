using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proms.models.common
{
    public class STKCallbackResponse
    {
        public Body body { set; get; }
        public class Body
        {
            public StkCallback stkCallback { set; get; }
            public class StkCallback
            {
                public int ResultCode { set; get; }
                public string ResultDesc { set; get; }
                public string CheckoutRequestID { set; get; }
                public string MerchantRequestID { set; get; }
            }
        }
    }
}