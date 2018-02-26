﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkqaWebApi.Util
{
    class HttpResultIntention
    {
        public static IActionResult GetStatusCode(ActionIntent requestIntent, bool status, object data)
        {
            switch (requestIntent)
            {
                case ActionIntent.Get:
                    return new JsonResult(data);
                case ActionIntent.Login:
                    return status ? (IActionResult)new OkResult() : new UnauthorizedResult();
                case ActionIntent.Update:
                    return status ? (IActionResult)new CreatedResult(string.Empty, AppConstants.JsonResultOkText)
                        : new NoContentResult();
                case ActionIntent.Save:
                    return status ? (IActionResult)new CreatedResult(string.Empty, AppConstants.JsonResultOkText) :
                        new NoContentResult();
                case ActionIntent.Delete:
                    return status ? new StatusCodeResult(204) : new NotFoundResult();
                default:
                    return new OkResult();
            }
        }
    }

}
