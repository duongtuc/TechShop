﻿using Presentation.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TechShop.Service;

namespace Presentation.Api
{
    [RoutePrefix("api/home")]
    [Authorize]
    public class HomeController : ApiControllerBase
    {
        private IErrorService _errorService;
        public HomeController(IErrorService errorService):base(errorService)
        {
            _errorService = errorService;
        }
        [HttpGet]
        [Route("TestMethod")]
        public  string TestMethod()
        {
            return "dang nhap";
        }
    }
}
