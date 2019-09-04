using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proms.models.common
{
    public class STKPush
    {
        public string phone { set; get; }
        public double amount { set; get; }
        public string token { set; get; }
        public int appId { set; get; }

        public STKPush(string phone, double amount, string token, int appId)
        {
            this.phone = phone;
            this.amount = amount;
            this.token = token;
            this.appId = appId;
        }
    }
}