using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie_TARpe20.Controllers
{
    public class Kivikangur : Controller
    {
        public IActionResult Kristjan(int? id)
        {
            ViewData["vanus"] = id;
            return View();
        }
    }
}
