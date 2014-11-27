using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example.Controllers
{
    public class HomeController : Controller
    {
        // 
        // GET: /

        public ActionResult Index()
        {
            // Setup basic route to redirect to show feed
            return RedirectToAction("ShowFeed");
        }

        //
        // GET: /Home/ShowFeed

        public ActionResult ShowFeed()
        {
            return View();
        }
    }
}