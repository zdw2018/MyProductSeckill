using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeckillFront.Controllers
{
    public class SeckillController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
