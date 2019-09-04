using proms.models;
using proms.models.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proms.controllers
{
    public class AccountController : DatabaseHandler
    {
        public Response update (string account, KeyValue[] keyModel, KeyValue[] updateModel)
        {
            Response response = updateRow(account, keyModel, updateModel);
            if (response.status_code == 1)
            {
                return new Response(true, 1, "Account updated successful.", null, null);
            }
            return new Response(true, 0, "Account update failed.", response.errors, null);
        }
    }
}