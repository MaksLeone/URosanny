using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZajazdURosanny.Controllers
{
    public class ControlPanelController : Controller
    {
        // GET: ControlPanel
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

    }
}