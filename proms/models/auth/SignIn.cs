using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proms.models.auth
{
    public class SignIn
    {
        public string uId { set; get; }
        public string uSecret { set; get; }

        public SignIn(string uId, string uSecret)
        {
            this.uId = uId; this.uSecret = uSecret;
        }
    }
}