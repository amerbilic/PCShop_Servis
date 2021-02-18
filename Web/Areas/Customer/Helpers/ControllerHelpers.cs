using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Customer.Helpers
{
    public static class ControllerHelpers
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            return request.IsAjaxRequest();
        }
    }
}
