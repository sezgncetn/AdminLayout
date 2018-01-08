﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminLayout.Areas.Admin.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        [OutputCache(Duration=30)]
        public ActionResult Index()
        {
            return View();
        }
    }
}