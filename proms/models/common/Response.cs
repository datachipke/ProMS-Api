using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proms.models
{
    public class Response
    {
        public bool status { set; get; }
        public int status_code { set; get; }
        public string message { set; get; }
        public string[] errors { set; get; }
        public object data { set; get; }

        public Response(bool status, int status_code, string message, string[] errors, object data)
        {
            this.status = status;
            this.status_code = status_code;
            this.message = message;
            this.errors = errors;
            this.data = data;
        }
    }
}