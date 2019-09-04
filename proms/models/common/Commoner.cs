using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proms.models.common
{
    public class Commoner
    {
        public int id { set; get; }
        public string token { set; get; }
        public string firstName { set; get; }
        public string lastName { set; get; }
        public string mobile { set; get; }
        public string email { set; get; }
        public string password { set; get; }
        public string avatar { set; get; }
        public int roleId { set; get; }
        public Commoner(int id, string token, string mobile, string email)
        {
            this.id = id; this.token = token; this.mobile = mobile; this.email = email;
        }
    }
}