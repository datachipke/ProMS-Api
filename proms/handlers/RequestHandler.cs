using proms.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proms.controllers
{
    public class RequestHandler
    {
        public Response flagRequest(object request)
        {
            Request rq = (Request)request;

            return new Response(false, 0, "Request NOT flagged through.", new string[] { "{}Bad request method." }, null);
        }
    }
}