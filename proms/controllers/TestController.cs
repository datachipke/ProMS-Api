using proms.handlers.models;
using proms.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proms.controllers
{
    public class TestController : DatabaseHandler
    {
        public Response search(SearchModel searchModel)
        {
            return searchDB(searchModel);
        }
    }
}